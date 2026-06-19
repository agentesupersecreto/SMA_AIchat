using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005E RID: 94
	public class RangosDeGeneracionParaDolorPorDerramada : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000DEED File Offset: 0x0000C0ED
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.semen };
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000DEFD File Offset: 0x0000C0FD
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
