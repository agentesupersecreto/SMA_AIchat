using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002F3 RID: 755
	public interface ICalculoDeEstimuloCoital : ICalculoDeEstimulo, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando
	{
		// Token: 0x170003CE RID: 974
		// (get) Token: 0x0600109F RID: 4255
		ICalculoDeEstimuloCoitalHole vaginal { get; }

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060010A0 RID: 4256
		ICalculoDeEstimuloCoitalHole anal { get; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060010A1 RID: 4257
		ICalculoDeEstimuloCoitalHole facial { get; }
	}
}
