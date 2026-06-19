using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200006A RID: 106
	public class RangosDeGeneracionParaRagePorClutch : RangosDeGeneracionParaToquesRecibidos<RagePorToques>
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000E026 File Offset: 0x0000C226
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.pene,
					ParteQuePuedeEstimular.propSexToy
				};
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000E037 File Offset: 0x0000C237
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
