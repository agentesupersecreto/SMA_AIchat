using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000066 RID: 102
	public class RangosDeGeneracionParaPlacerPorHump : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000DFC0 File Offset: 0x0000C1C0
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.piernas,
					ParteQuePuedeEstimular.torzo
				};
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000DFD1 File Offset: 0x0000C1D1
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
