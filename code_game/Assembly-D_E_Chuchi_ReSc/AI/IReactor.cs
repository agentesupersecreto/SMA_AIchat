using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000311 RID: 785
	public interface IReactor
	{
		// Token: 0x0600110A RID: 4362
		bool Reaccionar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame, Comparison<ICalculoDeEstimulo> comparison);
	}
}
