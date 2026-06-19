using System;
using com.ootii.Actors;
using com.ootii.Base;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007B RID: 123
	[BaseName("1st Person View")]
	[BaseDescription("Motor that allows the rig to rotate for 1st person views.")]
	public class ViewMotor : YawPitchMotor
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x000219EA File Offset: 0x0001FBEA
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x000219F2 File Offset: 0x0001FBF2
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

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x000219FB File Offset: 0x0001FBFB
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x00021A03 File Offset: 0x0001FC03
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x00021A0C File Offset: 0x0001FC0C
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x00021A14 File Offset: 0x0001FC14
		public bool IsActorMatchingRotation
		{
			get
			{
				return this._IsActorMatchingRotation;
			}
			set
			{
				this._IsActorMatchingRotation = value;
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00021A1D File Offset: 0x0001FC1D
		public ViewMotor()
		{
			this._MaxDistance = 0f;
			this.mDistance = 0f;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00021A50 File Offset: 0x0001FC50
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

		// Token: 0x060005FB RID: 1531 RVA: 0x00021AD2 File Offset: 0x0001FCD2
		public override void Clear()
		{
			this.mCharacterController = null;
			base.Clear();
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00021AE4 File Offset: 0x0001FCE4
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			if (this.RigController.Anchor == null)
			{
				return this.mRigTransform;
			}
			Quaternion tilt = this.RigController.Tilt;
			Transform anchor = this.Anchor;
			Transform transform = this.RigController._Transform;
			if (this._RotateAnchor && anchor != null && (this._RotateAnchorAlias.Length == 0 || this.RigController.InputSource == null || this.RigController.InputSource.IsPressed(this._RotateAnchorAlias)))
			{
				this.mWasRotatingAnchor = true;
			}
			this.mFrameEuler = this.GetFrameEuler(!this.mWasRotatingAnchor, true);
			Vector3 vector = tilt.Up();
			Vector3 right = transform.right;
			Vector3 vector2 = anchor.position + anchor.rotation * this.AnchorOffset + anchor.rotation * this._Offset;
			Matrix4x4 matrix4x = Matrix4x4.TRS(this.mAnchorLastPosition, this.mAnchorLastRotation, Vector3.one);
			Matrix4x4 matrix4x2 = Matrix4x4.TRS(anchor.position, anchor.rotation, Vector3.one);
			Vector3 vector3 = matrix4x.inverse.MultiplyVector(transform.forward);
			Quaternion quaternion = Quaternion.LookRotation(Quaternion.AngleAxis(this.mFrameEuler.x, right) * Quaternion.AngleAxis(this.mFrameEuler.y, vector) * matrix4x2.MultiplyVector(vector3), vector);
			Vector3 vector4 = Vector3.zero;
			if (!this._UseRigAnchor && this._Anchor != null)
			{
				vector4 = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset - this.AnchorPosition;
			}
			this.mRigTransform.Position = vector2 + vector4;
			this.mRigTransform.Rotation = quaternion;
			return this.mRigTransform;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00021CDC File Offset: 0x0001FEDC
		public override void PostRigLateUpdate()
		{
			base.PostRigLateUpdate();
			Transform anchor = this.Anchor;
			if (this._IsActorMatchingRotation && this.RigController.ActiveMotor == this)
			{
				this.RigController._Transform.position = anchor.position + anchor.rotation * this.AnchorOffset + anchor.rotation * this._Offset;
				this.RigController._Transform.rotation = Quaternion.Euler(this.RigController._Transform.rotation.eulerAngles.x, anchor.rotation.eulerAngles.y, 0f);
			}
			if (this._RotateAnchor && anchor != null)
			{
				bool flag = this._RotateAnchorAlias.Length == 0 || this.RigController.InputSource == null || this.RigController.InputSource.IsPressed(this._RotateAnchorAlias);
				if (flag || this.mWasRotatingAnchor)
				{
					if (this.mCharacterController != null)
					{
						Quaternion quaternion = Quaternion.AngleAxis(anchor.forward.HorizontalAngleTo(this.RigController.Transform.forward, anchor.up), Vector3.up);
						this.mCharacterController.Yaw = this.mCharacterController.Yaw * quaternion;
						anchor.rotation = this.mCharacterController.Tilt * this.mCharacterController.Yaw;
					}
					else
					{
						Quaternion quaternion2 = Quaternion.AngleAxis(anchor.forward.HorizontalAngleTo(this.RigController.Transform.forward, anchor.up), Vector3.up);
						anchor.rotation *= quaternion2;
					}
					this.mAnchorLastRotation = anchor.rotation;
					if (!flag)
					{
						this._Euler.y = this.LocalYaw;
						this._Euler.x = this.LocalPitch;
						this._EulerTarget = this._Euler;
						this.mViewVelocityY = 0f;
						this.mViewVelocityX = 0f;
						this.mWasRotatingAnchor = false;
						return;
					}
				}
			}
			else
			{
				this.mWasRotatingAnchor = false;
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00021F0C File Offset: 0x0002010C
		public override void DeserializeMotor(string rDefinition)
		{
			base.DeserializeMotor(rDefinition);
			if (this.Anchor != null)
			{
				this.mCharacterController = InterfaceHelper.GetComponent<ICharacterController>(this.Anchor.gameObject);
			}
		}

		// Token: 0x040002EA RID: 746
		public bool _RotateAnchor = true;

		// Token: 0x040002EB RID: 747
		public string _RotateAnchorAlias = "";

		// Token: 0x040002EC RID: 748
		public bool _IsActorMatchingRotation;

		// Token: 0x040002ED RID: 749
		public ICharacterController mCharacterController;

		// Token: 0x040002EE RID: 750
		protected bool mWasRotatingAnchor;
	}
}
