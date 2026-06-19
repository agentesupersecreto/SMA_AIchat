using System;
using com.ootii.Actors;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000086 RID: 134
	[AddComponentMenu("ootii/Camera Rigs/Scroller Rig")]
	public class ScrollerRig : BaseCameraRig
	{
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00025597 File Offset: 0x00023797
		// (set) Token: 0x060006F3 RID: 1779 RVA: 0x000255A0 File Offset: 0x000237A0
		public override Transform Anchor
		{
			get
			{
				return this._Anchor;
			}
			set
			{
				if (this._Anchor != null)
				{
					ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
					if (component != null)
					{
						ICharacterController characterController = component;
						characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
				}
				this._Anchor = value;
				if (this._Anchor != null && base.enabled)
				{
					ICharacterController component2 = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
					if (component2 != null)
					{
						base.IsInternalUpdateEnabled = false;
						this.IsFixedUpdateEnabled = false;
						ICharacterController characterController2 = component2;
						characterController2.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController2.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
				}
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00025652 File Offset: 0x00023852
		// (set) Token: 0x060006F5 RID: 1781 RVA: 0x0002565A File Offset: 0x0002385A
		public Vector3 AnchorOffset
		{
			get
			{
				return this._AnchorOffset;
			}
			set
			{
				this._AnchorOffset = value;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00025663 File Offset: 0x00023863
		// (set) Token: 0x060006F7 RID: 1783 RVA: 0x0002566B File Offset: 0x0002386B
		public Vector3 LookDirection
		{
			get
			{
				return this._LookDirection;
			}
			set
			{
				this._LookDirection = value;
				if (this._Transform != null)
				{
					this._Transform.rotation = Quaternion.LookRotation(this._LookDirection);
				}
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00025698 File Offset: 0x00023898
		protected override void Awake_Camera()
		{
			base.Awake_Camera();
			if (this._Anchor != null && base.enabled)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null)
				{
					base.IsInternalUpdateEnabled = false;
					this.IsFixedUpdateEnabled = false;
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
			this._Transform.rotation = Quaternion.LookRotation(this._LookDirection);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0002571C File Offset: 0x0002391C
		protected void OnEnable()
		{
			if (this._Anchor != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null)
				{
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

		// Token: 0x060006FA RID: 1786 RVA: 0x00025798 File Offset: 0x00023998
		protected void OnDisable()
		{
			if (this._Anchor != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null && component.OnControllerPostLateUpdate != null)
				{
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x000257F4 File Offset: 0x000239F4
		public override void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			Vector3 vector = this._Anchor.position + this._AnchorOffset;
			this._Transform.position = vector;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00025824 File Offset: 0x00023A24
		private void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.RigLateUpdate(rDeltaTime, rUpdateIndex);
			if (this.mOnPostLateUpdate != null)
			{
				this.mOnPostLateUpdate(rDeltaTime, this.mUpdateIndex, this);
			}
		}

		// Token: 0x04000364 RID: 868
		public Vector3 _AnchorOffset = new Vector3(0f, 1f, -3f);

		// Token: 0x04000365 RID: 869
		public Vector3 _LookDirection = new Vector3(0f, 0f, 1f);
	}
}
