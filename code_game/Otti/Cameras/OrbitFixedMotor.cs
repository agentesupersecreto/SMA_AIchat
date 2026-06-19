using System;
using com.ootii.Actors;
using com.ootii.Base;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000077 RID: 119
	[BaseName("3rd Person Fixed")]
	[BaseDescription("Motor that allows the rig to orbit the anchor and anchor offset. This rig follows the anchor as if attached by a hard pole.")]
	public class OrbitFixedMotor : YawPitchMotor
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001FE0F File Offset: 0x0001E00F
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0001FE17 File Offset: 0x0001E017
		public override Transform Anchor
		{
			get
			{
				return base.Anchor;
			}
			set
			{
				base.Anchor = value;
				if (this.Anchor != null)
				{
					this.mCharacterController = InterfaceHelper.GetComponent<ICharacterController>(this.Anchor.gameObject);
				}
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001FE44 File Offset: 0x0001E044
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001FE4C File Offset: 0x0001E04C
		public override float Distance
		{
			get
			{
				return this.mDistance;
			}
			set
			{
				this.mDistance = value;
				this._MaxDistance = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0001FE5C File Offset: 0x0001E05C
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0001FE64 File Offset: 0x0001E064
		public bool RotateWithAnchor
		{
			get
			{
				return this._RotateWithAnchor;
			}
			set
			{
				this._RotateWithAnchor = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0001FE6D File Offset: 0x0001E06D
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0001FE75 File Offset: 0x0001E075
		public bool RotateAnchor
		{
			get
			{
				return this._RotateAnchor;
			}
			set
			{
				this._RotateAnchor = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0001FE7E File Offset: 0x0001E07E
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x0001FE86 File Offset: 0x0001E086
		public string RotateAnchorAlias
		{
			get
			{
				return this._RotateAnchorAlias;
			}
			set
			{
				this._RotateAnchorAlias = value;
			}
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001FE90 File Offset: 0x0001E090
		public override void Awake()
		{
			base.Awake();
			if (this.Anchor != null)
			{
				this.mCharacterController = InterfaceHelper.GetComponent<ICharacterController>(this.Anchor.gameObject);
			}
			if (Application.isPlaying && this.Anchor == null)
			{
				this.mRigTransform.Position = this.RigController._Transform.position;
				this.mRigTransform.Rotation = this.RigController._Transform.rotation;
			}
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0001FF12 File Offset: 0x0001E112
		public override void Clear()
		{
			this.mCharacterController = null;
			base.Clear();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0001FF24 File Offset: 0x0001E124
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			Transform anchor = this.Anchor;
			if (anchor == null)
			{
				return this.mRigTransform;
			}
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			Transform transform = this.RigController._Transform;
			float num = this.mAnchorLastRotation.Forward().HorizontalAngleTo(anchor.forward, anchor.up);
			float num2 = ((Mathf.Abs(rTiltAngle) >= 2f) ? num : 0f);
			if (!this.RigController.RotateAnchorOffset)
			{
				num = 0f;
				num2 = 0f;
			}
			this.mFrameEuler = this.GetFrameEuler(true, true);
			Quaternion quaternion = Quaternion.AngleAxis(this.mFrameEuler.y + num2, this.RigController.RotateAnchorOffset ? this.RigController.Tilt.Up() : Vector3.up) * transform.rotation;
			Vector3 focusPosition = this.GetFocusPosition(quaternion);
			Vector3 vector = transform.position;
			Vector3 vector2 = transform.forward;
			if (this._RotateWithAnchor || this.RigController.FrameForceToFollowAnchor || Mathf.Abs(rTiltAngle) >= 2f)
			{
				Matrix4x4 matrix4x = Matrix4x4.TRS(this.mFocusLastPosition, this.RigController.RotateAnchorOffset ? this.mAnchorLastRotation : Quaternion.identity, Vector3.one);
				Matrix4x4 matrix4x2 = Matrix4x4.TRS(focusPosition, this.RigController.RotateAnchorOffset ? anchor.rotation : Quaternion.identity, Vector3.one);
				if (this.mTargetYaw < 3.4028235E+38f)
				{
					this.mFrameEuler.y = this.mFrameEuler.y - num;
				}
				if (this.mFrameEuler.sqrMagnitude != 0f || matrix4x != matrix4x2)
				{
					Vector3 vector3 = matrix4x.inverse.MultiplyPoint(transform.position);
					Vector3 vector4 = matrix4x.inverse.MultiplyVector(transform.right);
					vector3 = Quaternion.AngleAxis(this.mFrameEuler.y, Vector3.up) * Quaternion.AngleAxis(this.mFrameEuler.x, vector4) * vector3;
					vector = matrix4x2.MultiplyPoint(vector3);
					Vector3 normalized = (vector - focusPosition).normalized;
					vector = focusPosition + normalized * this.mDistance;
				}
				float num3 = Vector3.Distance(this.AnchorPosition, vector);
				float num4 = Vector3.Distance(this.AnchorPosition, focusPosition);
				if (num3 < num4)
				{
					vector = focusPosition - quaternion.Forward() * this.mDistance;
				}
			}
			else
			{
				quaternion *= Quaternion.AngleAxis(this.mFrameEuler.x, Vector3.right);
				vector = focusPosition - quaternion.Forward() * this.mDistance;
			}
			vector2 = focusPosition - vector;
			if (vector2.sqrMagnitude < 0.0001f)
			{
				vector2 = transform.forward;
			}
			quaternion = Quaternion.LookRotation(vector2.normalized, this.RigController.RotateAnchorOffset ? anchor.up : Vector3.up);
			if (vector2.magnitude != this.mDistance)
			{
				vector = focusPosition - vector2.normalized * this.mDistance;
			}
			this.mRigTransform.Position = vector;
			this.mRigTransform.Rotation = quaternion;
			return this.mRigTransform;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00020284 File Offset: 0x0001E484
		public override void PostRigLateUpdate()
		{
			base.PostRigLateUpdate();
			if (this._RotateAnchor && this.Anchor != null && (this._RotateAnchorAlias.Length == 0 || this.RigController.InputSource == null || this.RigController.InputSource.IsPressed(this._RotateAnchorAlias)))
			{
				if (this.mCharacterController != null)
				{
					Quaternion quaternion = Quaternion.AngleAxis(this.Anchor.forward.HorizontalAngleTo(this.RigController.Transform.forward, this.Anchor.up), Vector3.up);
					this.mCharacterController.Yaw = this.mCharacterController.Yaw * quaternion;
					this.Anchor.rotation = this.mCharacterController.Tilt * this.mCharacterController.Yaw;
					return;
				}
				Quaternion quaternion2 = Quaternion.AngleAxis(this.Anchor.forward.HorizontalAngleTo(this.RigController.Transform.forward, this.Anchor.up), Vector3.up);
				this.Anchor.rotation = this.Anchor.rotation * quaternion2;
			}
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x000203BB File Offset: 0x0001E5BB
		public override void DeserializeMotor(string rDefinition)
		{
			base.DeserializeMotor(rDefinition);
			if (this.Anchor != null)
			{
				this.mCharacterController = InterfaceHelper.GetComponent<ICharacterController>(this.Anchor.gameObject);
			}
		}

		// Token: 0x040002BF RID: 703
		public bool _RotateWithAnchor;

		// Token: 0x040002C0 RID: 704
		public bool _RotateAnchor;

		// Token: 0x040002C1 RID: 705
		public string _RotateAnchorAlias = "Camera Rotate Character";

		// Token: 0x040002C2 RID: 706
		protected ICharacterController mCharacterController;
	}
}
