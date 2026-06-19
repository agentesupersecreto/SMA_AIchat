using System;
using com.ootii.Base;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000074 RID: 116
	[BaseName("Fixed Motor")]
	[BaseDescription("Rig Motor that keeps the camera at the fixed position and rotation from the anchor.")]
	public class FixedMotor : CameraMotor
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0001F87E File Offset: 0x0001DA7E
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x0001F886 File Offset: 0x0001DA86
		public Quaternion RotationOffset
		{
			get
			{
				return this._RotationOffset;
			}
			set
			{
				this._RotationOffset = value;
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001F890 File Offset: 0x0001DA90
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			if (this.Anchor != null)
			{
				this.mRigTransform.Position = this.AnchorPosition + this.Anchor.rotation * this._Offset;
			}
			else
			{
				this.mRigTransform.Position = this.AnchorOffset + this._Offset;
			}
			if (this.Anchor != null)
			{
				this.mRigTransform.Rotation = this.Anchor.rotation * this._RotationOffset;
			}
			else
			{
				this.mRigTransform.Rotation = this.RigController._Transform.rotation * this._RotationOffset;
			}
			return this.mRigTransform;
		}

		// Token: 0x040002B4 RID: 692
		public Quaternion _RotationOffset = Quaternion.identity;
	}
}
