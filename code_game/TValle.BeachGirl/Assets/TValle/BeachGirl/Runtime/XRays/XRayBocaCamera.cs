using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays
{
	// Token: 0x0200005A RID: 90
	public sealed class XRayBocaCamera : XRayCamera
	{
		// Token: 0x0600018F RID: 399 RVA: 0x000033A7 File Offset: 0x000015A7
		protected override void Following(ref Vector3 targetPosition, ref Quaternion targetRotation, ref Vector3 targetScale, ref float targetScaleValue)
		{
			if (this.bocaEntrada == null)
			{
				return;
			}
			targetPosition = this.bocaEntrada.position;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000033C9 File Offset: 0x000015C9
		protected override void Followed(float targetLossyScaleValue)
		{
		}

		// Token: 0x040000FD RID: 253
		public Transform bocaEntrada;
	}
}
