using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A3 RID: 931
	[Obsolete("los para reactores son solo reactores q no necesitan data y que son de baja prioridad", true)]
	public class MainParaReactorGenerico : ReactorPadreSinLogica, IParaReactor
	{
		// Token: 0x0600147E RID: 5246 RVA: 0x00058522 File Offset: 0x00056722
		protected sealed override bool ArgumentoEsValido(object arg)
		{
			return arg == null;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x00005A42 File Offset: 0x00003C42
		public void Reaccionar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00005A42 File Offset: 0x00003C42
		public void BeforeReacciones()
		{
			throw new NotImplementedException();
		}
	}
}
