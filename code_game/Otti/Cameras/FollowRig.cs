using System;
using com.ootii.Actors;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000082 RID: 130
	[AddComponentMenu("ootii/Camera Rigs/Follow Rig")]
	public class FollowRig : BaseCameraRig
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x000244DB File Offset: 0x000226DB
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x000244E4 File Offset: 0x000226E4
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
					if (component2 == null)
					{
						IBaseCameraAnchor component3 = this._Anchor.GetComponent<IBaseCameraAnchor>();
						if (component3 != null)
						{
							base.IsInternalUpdateEnabled = false;
							this.IsFixedUpdateEnabled = false;
							IBaseCameraAnchor baseCameraAnchor = component3;
							baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
							return;
						}
						base.IsInternalUpdateEnabled = true;
						return;
					}
					else
					{
						base.IsInternalUpdateEnabled = false;
						this.IsFixedUpdateEnabled = false;
						ICharacterController characterController2 = component2;
						characterController2.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController2.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
				}
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x000245E4 File Offset: 0x000227E4
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x000245EC File Offset: 0x000227EC
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

		// Token: 0x060006B7 RID: 1719 RVA: 0x000245F8 File Offset: 0x000227F8
		protected override void Awake_Camera()
		{
			base.Awake_Camera();
			if (this._Anchor != null && base.enabled)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component == null)
				{
					IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
					if (component2 != null)
					{
						base.IsInternalUpdateEnabled = false;
						this.IsFixedUpdateEnabled = false;
						IBaseCameraAnchor baseCameraAnchor = component2;
						baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
						return;
					}
					base.IsInternalUpdateEnabled = true;
					return;
				}
				else
				{
					base.IsInternalUpdateEnabled = false;
					this.IsFixedUpdateEnabled = false;
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x000246B4 File Offset: 0x000228B4
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
					return;
				}
				IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
				if (component2 != null)
				{
					if (component2.OnAnchorPostLateUpdate != null)
					{
						IBaseCameraAnchor baseCameraAnchor = component2;
						baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					IBaseCameraAnchor baseCameraAnchor2 = component2;
					baseCameraAnchor2.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor2.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00024790 File Offset: 0x00022990
		protected void OnDisable()
		{
			if (this._Anchor != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null && component.OnControllerPostLateUpdate != null)
				{
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					return;
				}
				IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
				if (component2 != null)
				{
					IBaseCameraAnchor baseCameraAnchor = component2;
					baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0002481B File Offset: 0x00022A1B
		public override void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation)
		{
			rRotation = this._Transform.rotation;
			rPosition = this._Transform.position - Quaternion.Inverse(rRotation) * this._AnchorOffset;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0002485C File Offset: 0x00022A5C
		public override void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			Vector3 vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			this._Transform.position = vector;
			this._Transform.rotation = this._Anchor.rotation;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000248B2 File Offset: 0x00022AB2
		private void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.RigLateUpdate(rDeltaTime, rUpdateIndex);
			if (this.mOnPostLateUpdate != null)
			{
				this.mOnPostLateUpdate(rDeltaTime, this.mUpdateIndex, this);
			}
		}

		// Token: 0x04000358 RID: 856
		public Vector3 _AnchorOffset = new Vector3(0f, 2f, -3f);
	}
}
