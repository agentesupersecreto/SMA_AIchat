using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000069 RID: 105
	public class RangosDeGeneracionParaRagePorCaricias : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000E00F File Offset: 0x0000C20F
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000E01B File Offset: 0x0000C21B
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
