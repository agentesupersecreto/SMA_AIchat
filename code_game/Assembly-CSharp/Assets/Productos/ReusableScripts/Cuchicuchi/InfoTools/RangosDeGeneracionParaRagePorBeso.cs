using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000068 RID: 104
	public class RangosDeGeneracionParaRagePorBeso : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000201 RID: 513 RVA: 0x0000DFF4 File Offset: 0x0000C1F4
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000E004 File Offset: 0x0000C204
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
