using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007D RID: 125
	public abstract class ConcentMinimoParaVisionesDadas : ConcentMinimoPara
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000E3B6 File Offset: 0x0000C5B6
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.visual;
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000E3B9 File Offset: 0x0000C5B9
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.ojos;
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000E3C3 File Offset: 0x0000C5C3
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.ojos,
					ParteQuePuedeEstimular.pene,
					ParteQuePuedeEstimular.dedo,
					ParteQuePuedeEstimular.semen
				};
			}
		}
	}
}
