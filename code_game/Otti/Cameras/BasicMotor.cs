using System;
using com.ootii.Base;

namespace com.ootii.Cameras
{
	// Token: 0x02000073 RID: 115
	[BaseName("Basic Motor")]
	[BaseDescription("Basic Motor that moves and rotates based on the Camera Controller's transform. It does not use the Anchor.")]
	public class BasicMotor : CameraMotor
	{
		// Token: 0x0600057D RID: 1405 RVA: 0x0001F818 File Offset: 0x0001DA18
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			this.mRigTransform.Position = this.RigController._Transform.position;
			this.mRigTransform.Rotation = this.RigController._Transform.rotation;
			return this.mRigTransform;
		}
	}
}
