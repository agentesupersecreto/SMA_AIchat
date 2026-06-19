using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays
{
	// Token: 0x0200005C RID: 92
	public sealed class XRayPelvisCamera : XRayCamera
	{
		// Token: 0x06000193 RID: 403 RVA: 0x000033DB File Offset: 0x000015DB
		protected override void Following(ref Vector3 targetPosition, ref Quaternion targetRotation, ref Vector3 targetScale, ref float targetScaleValue)
		{
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000033DD File Offset: 0x000015DD
		protected override void Followed(float targetLossyScaleValue)
		{
		}
	}
}
