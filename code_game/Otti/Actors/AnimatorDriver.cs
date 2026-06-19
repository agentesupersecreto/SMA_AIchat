using System;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x0200008C RID: 140
	[AddComponentMenu("ootii/Actor Drivers/Animator Driver")]
	public class AnimatorDriver : ActorDriver
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0002AC3C File Offset: 0x00028E3C
		// (set) Token: 0x060007D3 RID: 2003 RVA: 0x0002AC44 File Offset: 0x00028E44
		public virtual Vector3 RootMotionMovement
		{
			get
			{
				return this.mRootMotionMovement;
			}
			set
			{
				this.mRootMotionMovement = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0002AC4D File Offset: 0x00028E4D
		// (set) Token: 0x060007D5 RID: 2005 RVA: 0x0002AC55 File Offset: 0x00028E55
		public virtual Quaternion RootMotionRotation
		{
			get
			{
				return this.mRootMotionRotation;
			}
			set
			{
				this.mRootMotionRotation = value;
			}
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002AC60 File Offset: 0x00028E60
		protected override void Awake()
		{
			this.mAnimator = base.gameObject.GetComponent<Animator>();
			base.Awake();
			if (this.mActorController != null && base.enabled)
			{
				ActorController mActorController = this.mActorController;
				mActorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(mActorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0002ACC4 File Offset: 0x00028EC4
		protected void OnEnable()
		{
			if (this.mActorController != null)
			{
				if (this.mActorController.OnControllerPreLateUpdate != null)
				{
					ActorController mActorController = this.mActorController;
					mActorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(mActorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
				ActorController mActorController2 = this.mActorController;
				mActorController2.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(mActorController2.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0002AD3C File Offset: 0x00028F3C
		protected void OnDisable()
		{
			if (this.mActorController != null && this.mActorController.OnControllerPreLateUpdate != null)
			{
				ActorController mActorController = this.mActorController;
				mActorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(mActorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0002AD8C File Offset: 0x00028F8C
		protected virtual void OnAnimatorMove()
		{
			if (Time.deltaTime == 0f)
			{
				return;
			}
			if (this.mAnimator == null)
			{
				this.mRootMotionMovement = Vector3.zero;
				this.mRootMotionRotation = Quaternion.identity;
				return;
			}
			this.mRootMotionMovement = Quaternion.Inverse(base.transform.rotation) * this.mAnimator.deltaPosition;
			this.mRootMotionRotation = this.mAnimator.deltaRotation;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0002AE04 File Offset: 0x00029004
		public virtual void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (this.mAnimator == null)
			{
				return;
			}
			if (this.mActorController == null)
			{
				return;
			}
			if (this.mInputSource == null || !this.mInputSource.IsEnabled)
			{
				return;
			}
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			Quaternion quaternion = Quaternion.identity;
			if (this.mInputSource.IsViewingActivated)
			{
				float viewX = this.mInputSource.ViewX;
				quaternion = Quaternion.Euler(0f, viewX * this.mDegreesPer60FPSTick, 0f);
			}
			Quaternion quaternion2 = this.mRootMotionRotation * quaternion;
			this.mActorController.Rotate(quaternion2);
			Vector3 vector = new Vector3(this.mInputSource.MovementX, 0f, this.mInputSource.MovementY);
			Vector3 vector2 = vector * this.MovementSpeed * smoothedDeltaTime;
			if (this.mRootMotionMovement.sqrMagnitude > 0f)
			{
				vector2 = this.mRootMotionMovement;
			}
			this.mActorController.RelativeMove(vector2);
			this.SetAnimatorProperties(vector, vector2, quaternion2);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0002AF0D File Offset: 0x0002910D
		protected virtual void SetAnimatorProperties(Vector3 rInput, Vector3 rMovement, Quaternion rRotation)
		{
		}

		// Token: 0x04000404 RID: 1028
		protected Animator mAnimator;

		// Token: 0x04000405 RID: 1029
		protected Vector3 mRootMotionMovement = Vector3.zero;

		// Token: 0x04000406 RID: 1030
		protected Quaternion mRootMotionRotation = Quaternion.identity;
	}
}
