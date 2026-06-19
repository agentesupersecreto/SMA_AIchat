using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E1 RID: 225
	public interface ILinearChain
	{
		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000929 RID: 2345
		EstadoDeCadena estado { get; }

		// Token: 0x0600092A RID: 2346
		void FixEnOrdenAsc();

		// Token: 0x0600092B RID: 2347
		void KillForces();

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x0600092C RID: 2348
		IReadOnlyList<RecalculableJointBase> puntosExcluyendoRootList { get; }
	}
}
