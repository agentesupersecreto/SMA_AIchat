using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000314 RID: 788
	public interface IParaReactor
	{
		// Token: 0x06001110 RID: 4368
		void BeforeReacciones();

		// Token: 0x06001111 RID: 4369
		void Reaccionar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame);
	}
}
