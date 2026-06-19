using System;
using com.ootii.Actors;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007F RID: 127
	public class BaseCameraAnchor : MonoBehaviour, IBaseCameraAnchor
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00023A58 File Offset: 0x00021C58
		public virtual Transform Transform
		{
			get
			{
				return this._Transform;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x00023A60 File Offset: 0x00021C60
		// (set) Token: 0x06000662 RID: 1634 RVA: 0x00023A68 File Offset: 0x00021C68
		public virtual bool IsFollowingEnabled
		{
			get
			{
				return this._IsFollowingEnabled;
			}
			set
			{
				this._IsFollowingEnabled = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x00023A71 File Offset: 0x00021C71
		// (set) Token: 0x06000664 RID: 1636 RVA: 0x00023A79 File Offset: 0x00021C79
		public virtual bool RotateWithTarget
		{
			get
			{
				return this._RotateWithTarget;
			}
			set
			{
				this._RotateWithTarget = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x00023A82 File Offset: 0x00021C82
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x00023A8A File Offset: 0x00021C8A
		public virtual Transform Root
		{
			get
			{
				return this._Root;
			}
			set
			{
				if (this._Root != null)
				{
					this.OnDisable();
				}
				this._Root = value;
				if (this._Root != null && base.enabled)
				{
					this.OnEnable();
				}
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x00023AC3 File Offset: 0x00021CC3
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x00023ACB File Offset: 0x00021CCB
		public virtual Transform RotationRoot
		{
			get
			{
				return this._RotationRoot;
			}
			set
			{
				this._RotationRoot = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00023AD4 File Offset: 0x00021CD4
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x00023ADC File Offset: 0x00021CDC
		public virtual Vector3 RootOffset
		{
			get
			{
				return this._RootOffset;
			}
			set
			{
				this._RootOffset = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00023AE5 File Offset: 0x00021CE5
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x00023AED File Offset: 0x00021CED
		public float MovementLerp
		{
			get
			{
				return this._MovementLerp;
			}
			set
			{
				this._MovementLerp = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00023AFB File Offset: 0x00021CFB
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x00023B03 File Offset: 0x00021D03
		public bool FreezePositionX
		{
			get
			{
				return this._FreezePositionX;
			}
			set
			{
				this._FreezePositionX = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00023B0C File Offset: 0x00021D0C
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x00023B14 File Offset: 0x00021D14
		public bool FreezePositionY
		{
			get
			{
				return this._FreezePositionY;
			}
			set
			{
				this._FreezePositionY = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00023B1D File Offset: 0x00021D1D
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x00023B25 File Offset: 0x00021D25
		public bool FreezePositionZ
		{
			get
			{
				return this._FreezePositionZ;
			}
			set
			{
				this._FreezePositionZ = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x00023B2E File Offset: 0x00021D2E
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x00023B36 File Offset: 0x00021D36
		public bool FreezeRotationX
		{
			get
			{
				return this._FreezeRotationX;
			}
			set
			{
				this._FreezeRotationX = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00023B3F File Offset: 0x00021D3F
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x00023B47 File Offset: 0x00021D47
		public bool FreezeRotationY
		{
			get
			{
				return this._FreezeRotationY;
			}
			set
			{
				this._FreezeRotationY = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00023B50 File Offset: 0x00021D50
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x00023B58 File Offset: 0x00021D58
		public bool FreezeRotationZ
		{
			get
			{
				return this._FreezeRotationZ;
			}
			set
			{
				this._FreezeRotationZ = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00023B61 File Offset: 0x00021D61
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00023B69 File Offset: 0x00021D69
		public virtual ControllerLateUpdateDelegate OnAnchorPostLateUpdate
		{
			get
			{
				return this.mOnAnchorPostLateUpdate;
			}
			set
			{
				this.mOnAnchorPostLateUpdate = value;
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00023B72 File Offset: 0x00021D72
		protected virtual void Awake()
		{
			this._Transform = base.gameObject.transform;
			if (this._Root != null && base.enabled)
			{
				this.OnEnable();
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00023BA4 File Offset: 0x00021DA4
		protected virtual void OnEnable()
		{
			if (this._Root != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Root.gameObject);
				if (component != null)
				{
					this.mIsAttachedToCharacterController = true;
					if (component.OnControllerPostLateUpdate != null)
					{
						ICharacterController characterController = component;
						characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					ICharacterController characterController2 = component;
					characterController2.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController2.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00023C28 File Offset: 0x00021E28
		public virtual void ClearTarget(bool rFollowRoot = false)
		{
			this.mTarget = null;
			this.mTargetOffset = Vector3.zero;
			this.mTargetSpeed = 0f;
			this.mTargetLerp = 0f;
			this.mTargetClear = false;
			this.mTargetRoot = false;
			this.mIsTargetPostionSet = false;
			this.IsFollowingEnabled = rFollowRoot;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00023C79 File Offset: 0x00021E79
		public virtual void ClearTarget(float rSpeed = 0f, float rLerp = 0f)
		{
			this.mTarget = null;
			this.mTargetOffset = Vector3.zero;
			this.mTargetSpeed = rSpeed;
			this.mTargetLerp = rLerp;
			this.mTargetClear = true;
			this.mTargetRoot = true;
			this.mIsTargetPostionSet = rSpeed > 0f;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00023CB7 File Offset: 0x00021EB7
		public virtual void SetTargetPosition(Transform rTarget, Vector3 rPosition, float rSpeed, float rLerp = 0f, bool rClearTargetOnArrival = true)
		{
			this.IsFollowingEnabled = false;
			this.mTarget = rTarget;
			this.mTargetOffset = rPosition;
			this.mTargetSpeed = rSpeed;
			this.mTargetLerp = rLerp;
			this.mTargetClear = rClearTargetOnArrival;
			this.mTargetRoot = false;
			this.mIsTargetPostionSet = true;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00023CF4 File Offset: 0x00021EF4
		protected virtual void OnDisable()
		{
			if (this._Root != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Root.gameObject);
				if (component != null && component.OnControllerPostLateUpdate != null)
				{
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00023D4E File Offset: 0x00021F4E
		protected virtual void LateUpdate()
		{
			if (this.mIsAttachedToCharacterController)
			{
				return;
			}
			this.AnchorLateUpdate(Time.deltaTime, 1);
			if (this.OnAnchorPostLateUpdate != null)
			{
				this.OnAnchorPostLateUpdate(null, Time.deltaTime, 1);
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00023D80 File Offset: 0x00021F80
		protected virtual void AnchorLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			if (this._Root == null)
			{
				return;
			}
			if (this.mIsTargetPostionSet)
			{
				Vector3 vector = this.mTargetOffset;
				if (this.mTargetRoot)
				{
					vector = this._Root.position + ((this._RotationRoot != null) ? this._RotationRoot.right : this._Root.right) * this._RootOffset.x;
				}
				else if (this.mTarget != null)
				{
					vector = this.mTarget.position + this.mTarget.rotation * this.mTargetOffset;
				}
				Vector3 vector2 = vector - this._Transform.position;
				float num = vector2.magnitude;
				if (num <= 0.001f)
				{
					if (this.mTargetClear)
					{
						this.ClearTarget(this.mTargetRoot);
					}
					if (this.mTargetRoot)
					{
						this.IsFollowingEnabled = true;
					}
				}
				else
				{
					if (this.mTargetSpeed > 0f)
					{
						num = Mathf.Min(num, this.mTargetSpeed * Time.deltaTime);
					}
					Vector3 vector3 = vector2.normalized * num;
					if (this._FreezePositionX)
					{
						vector3.x = 0f;
					}
					if (this._FreezePositionY)
					{
						vector3.y = 0f;
					}
					if (this._FreezePositionZ)
					{
						vector3.z = 0f;
					}
					vector = this._Transform.position + vector3;
					if (this.mTargetLerp <= 0f || this.mTargetLerp >= 1f)
					{
						this._Transform.position = vector;
					}
					else
					{
						this._Transform.position = Vector3.Lerp(this._Transform.position, vector, this.mTargetLerp);
					}
				}
			}
			if (this._IsFollowingEnabled)
			{
				Vector3 vector4 = this._Root.position + ((this._RotationRoot != null) ? this._RotationRoot.right : this._Root.right) * this._RootOffset.x - this._Transform.position;
				if (this._FreezePositionX)
				{
					vector4.x = 0f;
				}
				if (this._FreezePositionY)
				{
					vector4.y = 0f;
				}
				if (this._FreezePositionZ)
				{
					vector4.z = 0f;
				}
				this._Transform.position = this._Transform.position + Vector3.Lerp(Vector3.zero, vector4, this._MovementLerp);
				if (this._RotateWithTarget)
				{
					this._Transform.rotation = this._Root.rotation;
				}
			}
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00024031 File Offset: 0x00022231
		protected virtual void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.AnchorLateUpdate(rDeltaTime, rUpdateIndex);
			if (this.OnAnchorPostLateUpdate != null)
			{
				this.OnAnchorPostLateUpdate(rController, rDeltaTime, rUpdateIndex);
			}
		}

		// Token: 0x0400032F RID: 815
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x04000330 RID: 816
		public bool _IsFollowingEnabled = true;

		// Token: 0x04000331 RID: 817
		public bool _RotateWithTarget = true;

		// Token: 0x04000332 RID: 818
		public Transform _Root;

		// Token: 0x04000333 RID: 819
		public Transform _RotationRoot;

		// Token: 0x04000334 RID: 820
		public Vector3 _RootOffset = new Vector3(0f, 0f, 0f);

		// Token: 0x04000335 RID: 821
		public float _MovementLerp = 1f;

		// Token: 0x04000336 RID: 822
		public bool _FreezePositionX;

		// Token: 0x04000337 RID: 823
		public bool _FreezePositionY;

		// Token: 0x04000338 RID: 824
		public bool _FreezePositionZ;

		// Token: 0x04000339 RID: 825
		public bool _FreezeRotationX;

		// Token: 0x0400033A RID: 826
		public bool _FreezeRotationY;

		// Token: 0x0400033B RID: 827
		public bool _FreezeRotationZ;

		// Token: 0x0400033C RID: 828
		protected ControllerLateUpdateDelegate mOnAnchorPostLateUpdate;

		// Token: 0x0400033D RID: 829
		protected bool mIsAttachedToCharacterController;

		// Token: 0x0400033E RID: 830
		protected bool mIsTargetPostionSet;

		// Token: 0x0400033F RID: 831
		protected Transform mTarget;

		// Token: 0x04000340 RID: 832
		protected Vector3 mTargetOffset = Vector3.zero;

		// Token: 0x04000341 RID: 833
		protected float mTargetSpeed = 1f;

		// Token: 0x04000342 RID: 834
		protected float mTargetLerp;

		// Token: 0x04000343 RID: 835
		protected bool mTargetClear = true;

		// Token: 0x04000344 RID: 836
		protected bool mTargetRoot;
	}
}
