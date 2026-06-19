using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E7 RID: 999
	public interface IViendoOSiendoVistoUser
	{
		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x060015C5 RID: 5573
		Transform camara { get; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x060015C6 RID: 5574
		Transform cabeza { get; }

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x060015C7 RID: 5575
		Transform ojoIzqierdo { get; }

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x060015C8 RID: 5576
		Transform ojoDerecho { get; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x060015C9 RID: 5577
		Vector3 ojoIzqierdoDireccion { get; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x060015CA RID: 5578
		Vector3 ojoIzqierdoPosicion { get; }

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x060015CB RID: 5579
		Vector3 ojoDerechoDireccion { get; }

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x060015CC RID: 5580
		Vector3 ojoDerechoPosicion { get; }

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x060015CD RID: 5581
		float maxDistance { get; }

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x060015CE RID: 5582
		float maxDistanceIgnorandoAngulo { get; }

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x060015CF RID: 5583
		float maxAngleDeVision { get; }

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x060015D0 RID: 5584
		float scala { get; }
	}
}
