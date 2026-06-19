using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000036 RID: 54
	[Obsolete]
	public interface ICariciaEstimulanteAHitSkin : IPhysicsCariciaEstimulante, IInteraccionEstimulante
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001AE RID: 430
		HitSkin skinEstimulada { get; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001AF RID: 431
		List<BodyPartEnum> partesTocadasLista { get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001B0 RID: 432
		HashSet<int> partesTocadasSet { get; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001B1 RID: 433
		List<HitSkin.Colision> collisionesContraHitSkin { get; }
	}
}
