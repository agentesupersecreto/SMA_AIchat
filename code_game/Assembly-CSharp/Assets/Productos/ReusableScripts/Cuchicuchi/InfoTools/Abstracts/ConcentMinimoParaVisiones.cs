using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007C RID: 124
	public abstract class ConcentMinimoParaVisiones : ConcentMinimoPara
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000E393 File Offset: 0x0000C593
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.visual;
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000E396 File Offset: 0x0000C596
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000E399 File Offset: 0x0000C599
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.ojos,
					ParteQuePuedeEstimular.propSexToy
				};
			}
		}
	}
}
