using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Graphics.UI
{
	// Token: 0x02000042 RID: 66
	public interface IReticle
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000320 RID: 800
		// (set) Token: 0x06000321 RID: 801
		bool IsVisible { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000322 RID: 802
		// (set) Token: 0x06000323 RID: 803
		Vector2 Size { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000324 RID: 804
		// (set) Token: 0x06000325 RID: 805
		float FillPercent { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000326 RID: 806
		// (set) Token: 0x06000327 RID: 807
		Texture2D BGTexture { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000328 RID: 808
		// (set) Token: 0x06000329 RID: 809
		Texture2D FillTexture { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600032A RID: 810
		// (set) Token: 0x0600032B RID: 811
		Transform RaycastRoot { get; set; }

		// Token: 0x0600032C RID: 812
		int RaycastAll(out RaycastHit[] rHitInfos, float rMinDistance, float rMaxDistance, float rRadius, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null);
	}
}
