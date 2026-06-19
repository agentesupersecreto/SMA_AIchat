using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000067 RID: 103
	public class RangosDeGeneracionParaPlacerPorLambida : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001FE RID: 510 RVA: 0x0000DFDC File Offset: 0x0000C1DC
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.lengua };
			}
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000DFE9 File Offset: 0x0000C1E9
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
