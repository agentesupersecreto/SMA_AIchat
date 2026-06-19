using System;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007E RID: 126
	public struct CameraTransform
	{
		// Token: 0x0600065F RID: 1631 RVA: 0x00023A26 File Offset: 0x00021C26
		public void Lerp(CameraTransform rFrom, CameraTransform rTo, float rTime)
		{
			this.Position = Vector3.Lerp(rFrom.Position, rTo.Position, rTime);
			this.Rotation = Quaternion.Slerp(rFrom.Rotation, rTo.Rotation, rTime);
		}

		// Token: 0x0400032C RID: 812
		public Vector3 Position;

		// Token: 0x0400032D RID: 813
		public Quaternion Rotation;

		// Token: 0x0400032E RID: 814
		public float FieldOfView;
	}
}
