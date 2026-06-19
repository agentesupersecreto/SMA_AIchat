using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x0200010D RID: 269
	[Obsolete]
	public interface ICariciaEstimulanteAPuppetPart : IPhysicsCariciaEstimulante, IInteraccionEstimulante
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000549 RID: 1353
		PuppetPart parteEstimulada { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600054A RID: 1354
		List<PuppetPart.PartColision> collisionesContraPuppetPart { get; }
	}
}
