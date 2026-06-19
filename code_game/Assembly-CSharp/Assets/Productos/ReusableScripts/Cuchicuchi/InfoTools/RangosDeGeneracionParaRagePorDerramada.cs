using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200006C RID: 108
	public class RangosDeGeneracionParaRagePorDerramada : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000E05D File Offset: 0x0000C25D
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.semen };
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000E06D File Offset: 0x0000C26D
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
