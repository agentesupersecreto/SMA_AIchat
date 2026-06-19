using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005A RID: 90
	public class RangosDeGeneracionParaDolorPorBeso : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x0000DE84 File Offset: 0x0000C084
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000DE94 File Offset: 0x0000C094
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
