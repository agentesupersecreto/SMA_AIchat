using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200006E RID: 110
	public class RangosDeGeneracionParaRagePorLambida : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000E094 File Offset: 0x0000C294
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.lengua };
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000E0A1 File Offset: 0x0000C2A1
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
