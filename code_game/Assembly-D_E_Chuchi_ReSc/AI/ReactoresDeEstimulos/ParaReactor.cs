using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000390 RID: 912
	public abstract class ParaReactor : ReactorPadre
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060013F3 RID: 5107 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool puedeReaccionarANullos
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x00056790 File Offset: 0x00054990
		public sealed override bool ReactorPadrePuedeReaccionar(ReactorPadre padre, object arg, out bool negarTodos)
		{
			negarTodos = false;
			return true;
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool ArgumentoEsValido(object arg)
		{
			return true;
		}
	}
}
