using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005D RID: 93
	public class RangosDeGeneracionParaDolorPorDedeada : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000DED2 File Offset: 0x0000C0D2
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.dedo };
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000DEE2 File Offset: 0x0000C0E2
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
