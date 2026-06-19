using System;
using com.ootii.Actors;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Input;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000085 RID: 133
	[AddComponentMenu("ootii/Camera Rigs/Orbit Rig")]
	public class OrbitRig : BaseCameraRig
	{
		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x000248F9 File Offset: 0x00022AF9
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x00024901 File Offset: 0x00022B01
		public GameObject InputSourceOwner
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

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00024929 File Offset: 0x00022B29
		// (set) Token: 0x060006DD RID: 1757 RVA: 0x00024934 File Offset: 0x00022B34
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

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x00024A34 File Offset: 0x00022C34
		// (set) Token: 0x060006DF RID: 1759 RVA: 0x00024A3C File Offset: 0x00022C3C
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

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060006E0 RID: 1760 RVA: 0x00024A45 File Offset: 0x00022C45
		// (set) Token: 0x060006E1 RID: 1761 RVA: 0x00024A4D File Offset: 0x00022C4D
		public float Radius
		{
			get
			{
				return this._Radius;
			}
			set
			{
				this._Radius = value;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x00024A56 File Offset: 0x00022C56
		// (set) Token: 0x060006E3 RID: 1763 RVA: 0x00024A5E File Offset: 0x00022C5E
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

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x00024A79 File Offset: 0x00022C79
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x00024A81 File Offset: 0x00022C81
		public virtual bool InvertPitch
		{
			get
			{
				return this._InvertPitch;
			}
			set
			{
				this._InvertPitch = value;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x00024A8C File Offset: 0x00022C8C
		public virtual float LocalYaw
		{
			get
			{
				Transform anchor = this._Anchor;
				float num;
				if (anchor == null)
				{
					num = this._Transform.rotation.eulerAngles.y;
				}
				else
				{
					num = (Quaternion.Inverse(anchor.rotation) * this._Transform.rotation).eulerAngles.y;
				}
				if (num > 180f)
				{
					num -= 360f;
				}
				else if (num < -180f)
				{
					num += 360f;
				}
				return num;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00024B18 File Offset: 0x00022D18
		public virtual float LocalPitch
		{
			get
			{
				Transform anchor = this._Anchor;
				float num;
				if (anchor == null)
				{
					num = this._Transform.rotation.eulerAngles.x;
				}
				else
				{
					num = (Quaternion.Inverse(anchor.rotation) * this._Transform.rotation).eulerAngles.x;
				}
				if (num > 180f)
				{
					num -= 360f;
				}
				else if (num < -180f)
				{
					num += 360f;
				}
				return num;
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00024BA4 File Offset: 0x00022DA4
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
					}
					else
					{
						base.IsInternalUpdateEnabled = true;
					}
				}
				else
				{
					base.IsInternalUpdateEnabled = false;
					this.IsFixedUpdateEnabled = false;
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
				this.mTilt = QuaternionExt.FromToRotation(this._Transform.up, this._Anchor.up);
				this.mToCameraDirection = this._Transform.position - this._Anchor.position;
				this.mToCameraDirection.y = 0f;
				this.mToCameraDirection.Normalize();
				if (this.mToCameraDirection.sqrMagnitude == 0f)
				{
					this.mToCameraDirection = -this._Anchor.forward;
				}
			}
			if (this._InputSourceOwner != null)
			{
				this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00024D18 File Offset: 0x00022F18
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

		// Token: 0x060006EA RID: 1770 RVA: 0x00024DF4 File Offset: 0x00022FF4
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

		// Token: 0x060006EB RID: 1771 RVA: 0x00024E80 File Offset: 0x00023080
		public override void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation)
		{
			rPosition = this._Anchor.position;
			rRotation = this._Anchor.rotation;
			Vector3 vector = this._Transform.position + this._Transform.forward * this._Radius;
			Quaternion quaternion = this._Transform.rotation * Quaternion.Inverse(Quaternion.Euler(this.LocalPitch, this.LocalYaw, 0f));
			Vector3 vector2 = vector - quaternion * this.AnchorOffset;
			rPosition = vector2;
			rRotation = quaternion;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00024F24 File Offset: 0x00023124
		public override void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			Vector3 vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			Vector3 vector2 = this._Transform.position;
			Quaternion quaternion = this._Transform.rotation;
			if (this.mFrameLockForward)
			{
				this.mFrameLockForward = false;
			}
			else if (this._FrameForceToFollowAnchor)
			{
				Quaternion quaternion2 = QuaternionExt.FromToRotation(this._Anchor.up, Vector3.up);
				Quaternion quaternion3 = Quaternion.AngleAxis(NumberHelper.GetHorizontalAngle(this._Transform.forward, this._Anchor.forward, this._Anchor.up), quaternion2 * this._Anchor.up);
				Quaternion quaternion4 = Quaternion.identity;
				if (this.mInputSource.IsViewingActivated)
				{
					float num = Vector3.Angle(this.mToCameraDirection, quaternion2 * this._Anchor.up);
					float num2 = (this._InvertPitch ? (-1f) : 1f) * this.mInputSource.ViewY;
					if (num < 10f && num2 > 0f)
					{
						num2 = 0f;
					}
					else if (num > 170f && num2 < 0f)
					{
						num2 = 0f;
					}
					quaternion4 = Quaternion.AngleAxis(num2, quaternion2 * this._Transform.right);
				}
				this.mToCameraDirection = quaternion4 * quaternion3 * this.mToCameraDirection;
				this.mTilt = QuaternionExt.FromToRotation(this.mTilt.Up(), this._Anchor.up) * this.mTilt;
				Vector3 vector3 = this.mTilt * this.mToCameraDirection;
				if (vector3.sqrMagnitude == 0f)
				{
					vector3 = -this._Anchor.forward;
				}
				vector2 = vector + vector3.normalized * this._Radius;
				quaternion = Quaternion.LookRotation(vector - vector2, this._Anchor.up);
				this._FrameForceToFollowAnchor = false;
			}
			else
			{
				if (this.mInputSource.IsViewingActivated)
				{
					Quaternion quaternion5 = QuaternionExt.FromToRotation(this._Anchor.up, Vector3.up);
					Quaternion quaternion6 = Quaternion.AngleAxis(this.mInputSource.ViewX * this.mDegreesPer60FPSTick, quaternion5 * this._Transform.up);
					float num3 = Vector3.Angle(this.mToCameraDirection, quaternion5 * this._Anchor.up);
					float num4 = (this._InvertPitch ? (-1f) : 1f) * this.mInputSource.ViewY;
					if (num3 < 10f && num4 > 0f)
					{
						num4 = 0f;
					}
					else if (num3 > 170f && num4 < 0f)
					{
						num4 = 0f;
					}
					Quaternion quaternion7 = Quaternion.AngleAxis(num4, quaternion5 * this._Transform.right);
					this.mToCameraDirection = quaternion7 * quaternion6 * this.mToCameraDirection;
				}
				this.mTilt = QuaternionExt.FromToRotation(this.mTilt.Up(), this._Anchor.up) * this.mTilt;
				Vector3 vector4 = this.mTilt * this.mToCameraDirection;
				if (vector4.sqrMagnitude == 0f)
				{
					vector4 = -this._Anchor.forward;
				}
				vector2 = vector + vector4.normalized * this._Radius;
				quaternion = Quaternion.LookRotation(vector - vector2, this._Anchor.up);
			}
			this._Transform.position = vector2;
			this._Transform.rotation = quaternion;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x000252E2 File Offset: 0x000234E2
		private void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.RigLateUpdate(rDeltaTime, rUpdateIndex);
			if (this.mOnPostLateUpdate != null)
			{
				this.mOnPostLateUpdate(rDeltaTime, this.mUpdateIndex, this);
			}
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00025307 File Offset: 0x00023507
		public override void ClearTargetForward()
		{
			this.mFrameLockForward = false;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00025310 File Offset: 0x00023510
		public override void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			Vector3 vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			Quaternion quaternion = QuaternionExt.FromToRotation(this._Anchor.up, Vector3.up);
			Quaternion quaternion2 = Quaternion.AngleAxis(rYaw - this.LocalYaw, quaternion * this._Transform.up);
			float num = Vector3.Angle(this.mToCameraDirection, quaternion * this._Anchor.up);
			float num2 = rPitch - this.LocalPitch;
			if (num < 10f && num2 > 0f)
			{
				num2 = 0f;
			}
			else if (num > 170f && num2 < 0f)
			{
				num2 = 0f;
			}
			Quaternion quaternion3 = Quaternion.AngleAxis(num2, quaternion * this._Transform.right);
			this.mToCameraDirection = quaternion3 * quaternion2 * this.mToCameraDirection;
			this.mTilt = QuaternionExt.FromToRotation(this.mTilt.Up(), this._Anchor.up) * this.mTilt;
			Vector3 vector2 = this.mTilt * this.mToCameraDirection;
			if (vector2.sqrMagnitude == 0f)
			{
				vector2 = -this._Anchor.forward;
			}
			Vector3 vector3 = vector + vector2.normalized * this._Radius;
			Quaternion quaternion4 = Quaternion.LookRotation(vector - vector3, this._Anchor.up);
			this._Transform.position = vector3;
			this._Transform.rotation = quaternion4;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000254AC File Offset: 0x000236AC
		public override void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			this.mFrameLockForward = true;
			Vector3 vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			this._Transform.position = vector - rForward * this._Radius;
			this._Transform.rotation = Quaternion.LookRotation(rForward, this._Anchor.up);
			this.mToCameraDirection = -rForward;
		}

		// Token: 0x04000359 RID: 857
		private const float MIN_PITCH = 10f;

		// Token: 0x0400035A RID: 858
		private const float MAX_PITCH = 170f;

		// Token: 0x0400035B RID: 859
		public GameObject _InputSourceOwner;

		// Token: 0x0400035C RID: 860
		public Vector3 _AnchorOffset = new Vector3(0f, 2f, 0f);

		// Token: 0x0400035D RID: 861
		public float _Radius = 4f;

		// Token: 0x0400035E RID: 862
		public float _RotationSpeed = 120f;

		// Token: 0x0400035F RID: 863
		public bool _InvertPitch = true;

		// Token: 0x04000360 RID: 864
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000361 RID: 865
		protected Vector3 mToCameraDirection = Vector3.back;

		// Token: 0x04000362 RID: 866
		protected Quaternion mTilt = Quaternion.identity;

		// Token: 0x04000363 RID: 867
		protected IInputSource mInputSource;
	}
}
