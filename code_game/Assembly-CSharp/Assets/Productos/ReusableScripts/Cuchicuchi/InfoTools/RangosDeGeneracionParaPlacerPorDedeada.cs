using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000064 RID: 100
	public class RangosDeGeneracionParaPlacerPorDedeada : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000DF8A File Offset: 0x0000C18A
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.dedo };
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000DF9A File Offset: 0x0000C19A
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
