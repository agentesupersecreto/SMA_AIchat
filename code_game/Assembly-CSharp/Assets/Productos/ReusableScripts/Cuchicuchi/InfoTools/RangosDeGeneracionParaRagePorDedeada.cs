using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200006B RID: 107
	public class RangosDeGeneracionParaRagePorDedeada : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000E042 File Offset: 0x0000C242
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.dedo };
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000E052 File Offset: 0x0000C252
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
