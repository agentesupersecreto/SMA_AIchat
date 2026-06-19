using System;
using com.ootii.Helpers;
using com.ootii.Input;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x0200008A RID: 138
	[AddComponentMenu("ootii/Actor Drivers/Actor Driver")]
	public class ActorDriver : MonoBehaviour
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x0002A782 File Offset: 0x00028982
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x0002A78A File Offset: 0x0002898A
		public virtual bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0002A793 File Offset: 0x00028993
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x0002A79B File Offset: 0x0002899B
		public virtual GameObject InputSourceOwner
		{
			get
			{
				return this._InputSourceOwner;
			}
			set
			{
				this._InputSourceOwner = value;
				if (this._InputSourceOwner != null)
				{
					this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
				}
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x0002A7C3 File Offset: 0x000289C3
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x0002A7CB File Offset: 0x000289CB
		public virtual float MovementSpeed
		{
			get
			{
				return this._MovementSpeed;
			}
			set
			{
				this._MovementSpeed = value;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0002A7D4 File Offset: 0x000289D4
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x0002A7DC File Offset: 0x000289DC
		public virtual float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
				this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x0002A7F7 File Offset: 0x000289F7
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x0002A7FF File Offset: 0x000289FF
		public virtual float JumpForce
		{
			get
			{
				return this._JumpForce;
			}
			set
			{
				this._JumpForce = value;
			}
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0002A808 File Offset: 0x00028A08
		protected virtual void Awake()
		{
			this.mActorController = base.gameObject.GetComponent<ActorController>();
			if (this._InputSourceOwner != null)
			{
				this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			if (this.mInputSource == null)
			{
				this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(base.gameObject);
			}
			if (this.mInputSource == null)
			{
				IInputSource[] components = InterfaceHelper.GetComponents<IInputSource>();
				for (int i = 0; i < components.Length; i++)
				{
					GameObject gameObject = ((MonoBehaviour)components[i]).gameObject;
					if (gameObject.activeSelf && components[i].IsEnabled)
					{
						this.mInputSource = components[i];
						this._InputSourceOwner = gameObject;
					}
				}
			}
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0002A8BC File Offset: 0x00028ABC
		protected virtual void Update()
		{
			if (!this._IsEnabled)
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
			if (this.mInputSource.IsViewingActivated)
			{
				float viewX = this.mInputSource.ViewX;
				Quaternion quaternion = Quaternion.Euler(0f, viewX * this.mDegreesPer60FPSTick, 0f);
				this.mActorController.Rotate(quaternion);
			}
			Vector3 vector = new Vector3(this.mInputSource.MovementX, 0f, this.mInputSource.MovementY) * this._MovementSpeed * smoothedDeltaTime;
			if (vector.sqrMagnitude > 0f)
			{
				this.mActorController.RelativeMove(vector);
			}
			if (this.mInputSource.IsJustPressed("Jump") && this.mActorController.State.IsGrounded)
			{
				this.mActorController.AddImpulse(base.transform.up * this._JumpForce);
			}
		}

		// Token: 0x040003D2 RID: 978
		public bool _IsEnabled = true;

		// Token: 0x040003D3 RID: 979
		public GameObject _InputSourceOwner;

		// Token: 0x040003D4 RID: 980
		public float _MovementSpeed = 5f;

		// Token: 0x040003D5 RID: 981
		public float _RotationSpeed = 240f;

		// Token: 0x040003D6 RID: 982
		public float _JumpForce = 10f;

		// Token: 0x040003D7 RID: 983
		protected IInputSource mInputSource;

		// Token: 0x040003D8 RID: 984
		protected ActorController mActorController;

		// Token: 0x040003D9 RID: 985
		protected float mDegreesPer60FPSTick = 1f;
	}
}
