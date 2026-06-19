using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200006D RID: 109
	public class RangosDeGeneracionParaRagePorHump : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000E078 File Offset: 0x0000C278
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.piernas,
					ParteQuePuedeEstimular.torzo
				};
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000E089 File Offset: 0x0000C289
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
