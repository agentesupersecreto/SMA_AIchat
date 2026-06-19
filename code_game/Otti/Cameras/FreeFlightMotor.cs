using System;
using com.ootii.Base;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000075 RID: 117
	[BaseName("Free Flight")]
	[BaseDescription("Editor style motor that allows the player to move the camera around the scene without an anchor.")]
	public class FreeFlightMotor : YawPitchMotor
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0001F97A File Offset: 0x0001DB7A
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x0001F982 File Offset: 0x0001DB82
		public float Speed
		{
			get
			{
				return this._Speed;
			}
			set
			{
				this._Speed = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0001F98B File Offset: 0x0001DB8B
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x0001F993 File Offset: 0x0001DB93
		public float VerticalSpeed
		{
			get
			{
				return this._VerticalSpeed;
			}
			set
			{
				this._VerticalSpeed = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001F99C File Offset: 0x0001DB9C
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0001F9A4 File Offset: 0x0001DBA4
		public string UpActionAlias
		{
			get
			{
				return this._UpActionAlias;
			}
			set
			{
				this._UpActionAlias = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001F9AD File Offset: 0x0001DBAD
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0001F9B5 File Offset: 0x0001DBB5
		public string DownActionAlias
		{
			get
			{
				return this._DownActionAlias;
			}
			set
			{
				this._DownActionAlias = value;
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0001F9C0 File Offset: 0x0001DBC0
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			if (this.RigController.InputSource == null)
			{
				return this.mRigTransform;
			}
			Transform transform = this.RigController._Transform;
			this.mFrameEuler = this.GetFrameEuler(false, true);
			Quaternion quaternion = Quaternion.AngleAxis(this.mFrameEuler.y, Vector3.up) * transform.rotation;
			quaternion *= Quaternion.AngleAxis(this.mFrameEuler.x, Vector3.right);
			Vector3 vector = new Vector3(this.RigController.InputSource.MovementX, 0f, this.RigController.InputSource.MovementY);
			Vector3 vector2 = transform.position + quaternion * (vector * this._Speed * rDeltaTime);
			if (this._UpActionAlias.Length > 0 && this.RigController.InputSource.IsPressed(this._UpActionAlias))
			{
				vector2 += Vector3.up * (this._VerticalSpeed * rDeltaTime);
			}
			if (this._DownActionAlias.Length > 0 && this.RigController.InputSource.IsPressed(this._DownActionAlias))
			{
				vector2 += Vector3.down * (this._VerticalSpeed * rDeltaTime);
			}
			this.mRigTransform.Position = vector2;
			this.mRigTransform.Rotation = quaternion;
			return this.mRigTransform;
		}

		// Token: 0x040002B5 RID: 693
		public float _Speed = 5f;

		// Token: 0x040002B6 RID: 694
		public float _VerticalSpeed = 5f;

		// Token: 0x040002B7 RID: 695
		public string _UpActionAlias = "";

		// Token: 0x040002B8 RID: 696
		public string _DownActionAlias = "";
	}
}
