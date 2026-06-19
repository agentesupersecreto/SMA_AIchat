using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000065 RID: 101
	public class RangosDeGeneracionParaPlacerPorDerramada : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0000DFA5 File Offset: 0x0000C1A5
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.semen };
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000DFB5 File Offset: 0x0000C1B5
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
