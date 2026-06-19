using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres
{
	// Token: 0x020000B1 RID: 177
	public interface IGrabableProp
	{
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000547 RID: 1351
		GrabbablePropEstado estado { get; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000548 RID: 1352
		Transform physcisRoot { get; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000549 RID: 1353
		Transform skeletonRoot { get; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600054A RID: 1354
		GameObject notGrabedPhysics { get; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600054B RID: 1355
		float worldLength { get; }
	}
}
