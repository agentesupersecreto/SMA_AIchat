using System;
using RootMotion.Dynamics;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes
{
	// Token: 0x02000117 RID: 279
	public interface IModificableDeVolumenDeMusculo
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060005BE RID: 1470
		Muscle muscle { get; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060005BF RID: 1471
		BoxModificable boxModificable { get; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060005C0 RID: 1472
		SphereModificable sphereModificable { get; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060005C1 RID: 1473
		CapsuleModificable capsuleModificable { get; }
	}
}
