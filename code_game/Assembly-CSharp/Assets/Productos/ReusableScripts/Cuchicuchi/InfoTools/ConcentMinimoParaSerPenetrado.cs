using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000058 RID: 88
	public class ConcentMinimoParaSerPenetrado : ConcentMinimoPara
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000DCEB File Offset: 0x0000BEEB
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.dedo,
					ParteQuePuedeEstimular.pene,
					ParteQuePuedeEstimular.propSexToy
				};
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0000DCFE File Offset: 0x0000BEFE
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000DD01 File Offset: 0x0000BF01
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.coital;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000DD04 File Offset: 0x0000BF04
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}
	}
}
