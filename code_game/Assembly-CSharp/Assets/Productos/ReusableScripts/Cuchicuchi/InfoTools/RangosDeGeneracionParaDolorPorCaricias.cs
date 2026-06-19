using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005B RID: 91
	public class RangosDeGeneracionParaDolorPorCaricias : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000DE9F File Offset: 0x0000C09F
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000DEAB File Offset: 0x0000C0AB
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
