using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000060 RID: 96
	public class RangosDeGeneracionParaDolorPorLambida : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000DF24 File Offset: 0x0000C124
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.lengua };
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000DF31 File Offset: 0x0000C131
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
