using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000062 RID: 98
	public class RangosDeGeneracionParaPlacerPorCaricias : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000DF57 File Offset: 0x0000C157
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000DF63 File Offset: 0x0000C163
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
