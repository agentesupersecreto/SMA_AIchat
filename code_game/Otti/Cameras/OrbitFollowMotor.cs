using System;
using com.ootii.Base;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000078 RID: 120
	[BaseName("3rd Person Follow")]
	[BaseDescription("Motor that allows the rig to orbit the anchor and anchor offset. This rig drags behind the anchor as if attached by a rope.")]
	public class OrbitFollowMotor : YawPitchMotor
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x000203FB File Offset: 0x0001E5FB
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00020403 File Offset: 0x0001E603
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

		// Token: 0x060005AC RID: 1452 RVA: 0x00020414 File Offset: 0x0001E614
		public override void Awake()
		{
			base.Awake();
			if (Application.isPlaying && this.Anchor == null)
			{
				this.mRigTransform.Position = this.RigController._Transform.position;
				this.mRigTransform.Rotation = this.RigController._Transform.rotation;
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00020474 File Offset: 0x0001E674
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
			Vector3 vector = this.GetFocusPosition(quaternion);
			Vector3 vector2 = transform.position;
			Vector3 vector3 = transform.forward;
			if (this.RigController.FrameForceToFollowAnchor || Mathf.Abs(rTiltAngle) >= 2f)
			{
				Matrix4x4 matrix4x = Matrix4x4.TRS(this.mFocusLastPosition, this.RigController.RotateAnchorOffset ? this.mAnchorLastRotation : Quaternion.identity, Vector3.one);
				Matrix4x4 matrix4x2 = Matrix4x4.TRS(vector, this.RigController.RotateAnchorOffset ? anchor.rotation : Quaternion.identity, Vector3.one);
				if (this.mTargetYaw < 3.4028235E+38f)
				{
					this.mFrameEuler.y = this.mFrameEuler.y - num;
				}
				if (this.mFrameEuler.sqrMagnitude != 0f || matrix4x != matrix4x2)
				{
					Vector3 vector4 = matrix4x.inverse.MultiplyPoint(transform.position);
					Vector3 vector5 = matrix4x.inverse.MultiplyVector(transform.right);
					vector4 = Quaternion.AngleAxis(this.mFrameEuler.y, Vector3.up) * Quaternion.AngleAxis(this.mFrameEuler.x, vector5) * vector4;
					vector2 = matrix4x2.MultiplyPoint(vector4);
				}
			}
			else if (this.mTargetForward.sqrMagnitude > 0f)
			{
				quaternion *= Quaternion.AngleAxis(this.mFrameEuler.x, Vector3.right);
				vector2 = vector - quaternion.Forward() * this.mDistance;
			}
			else
			{
				quaternion *= Quaternion.AngleAxis(this.mFrameEuler.x, Vector3.right);
				Vector3 vector6 = this.mFocusLastPosition - quaternion.Forward() * this.mDistance;
				vector3 = vector - vector6;
				if (vector3.sqrMagnitude < 0.0001f)
				{
					vector3 = transform.forward;
				}
				quaternion = Quaternion.LookRotation(vector3.normalized, this.RigController.RotateAnchorOffset ? anchor.up : Vector3.up);
				vector = this.GetFocusPosition(quaternion);
				Vector3 vector7 = Vector3.zero;
				if (this.RigController.RotateAnchorOffset)
				{
					vector7 = anchor.position + anchor.rotation * this.AnchorOffset + anchor.up * this._Offset.y;
				}
				else
				{
					vector7 = anchor.position + this.AnchorOffset + Vector3.up * this._Offset.y;
				}
				vector3 = vector - vector7;
				vector3 = vector - vector6;
				if (vector3.sqrMagnitude < 0.0001f)
				{
					vector3 = transform.forward;
				}
				Vector3 vector8 = Vector3.Project(vector3, this.RigController.RotateAnchorOffset ? this.RigController.Tilt.Up() : Vector3.up);
				Vector3 vector9 = vector3 - vector8;
				quaternion = transform.rotation * Quaternion.AngleAxis(this.mFrameEuler.x, Vector3.right);
				Vector3 eulerAngles = (this.RigController.RotateAnchorOffset ? (Quaternion.Inverse(this.RigController.Tilt) * quaternion) : quaternion).eulerAngles;
				Quaternion quaternion2 = Quaternion.LookRotation(vector9, this.RigController.RotateAnchorOffset ? this.RigController.Tilt.Up() : Vector3.up) * Quaternion.Euler(eulerAngles.x, 0f, 0f);
				vector2 = vector - quaternion2.Forward() * this.mDistance;
			}
			vector3 = vector - vector2;
			if (vector3.sqrMagnitude < 0.0001f)
			{
				vector3 = transform.forward;
			}
			quaternion = Quaternion.LookRotation(vector3.normalized, this.RigController.RotateAnchorOffset ? anchor.up : Vector3.up);
			Vector3 eulerAngles2 = ((this.RigController.RotateAnchorOffset ? Quaternion.Inverse(this.Anchor.transform.rotation) : Quaternion.identity) * quaternion).eulerAngles;
			if (eulerAngles2.y > 180f)
			{
				eulerAngles2.y -= 360f;
			}
			else if (eulerAngles2.y < -180f)
			{
				eulerAngles2.y += 360f;
			}
			if (eulerAngles2.x > 180f)
			{
				eulerAngles2.x -= 360f;
			}
			else if (eulerAngles2.x < -180f)
			{
				eulerAngles2.x += 360f;
			}
			float num3 = ((this._MinYaw > -180f || this._MaxYaw < 180f) ? Mathf.Clamp(eulerAngles2.y, this._MinYaw, this._MaxYaw) : eulerAngles2.y);
			float num4 = Mathf.Clamp(eulerAngles2.x, this._MinPitch, this._MaxPitch);
			if (num3 != eulerAngles2.y || num4 != eulerAngles2.x)
			{
				quaternion = (this.RigController.RotateAnchorOffset ? this.Anchor.transform.rotation : Quaternion.identity) * Quaternion.Euler(num4, num3, 0f);
				vector2 = vector - quaternion.Forward() * this.mDistance;
			}
			this.mRigTransform.Position = vector2;
			this.mRigTransform.Rotation = quaternion;
			return this.mRigTransform;
		}
	}
}
