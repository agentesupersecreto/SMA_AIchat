using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005F RID: 95
	public class RangosDeGeneracionParaDolorPorHump : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000DF08 File Offset: 0x0000C108
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

		// Token: 0x060001E7 RID: 487 RVA: 0x0000DF19 File Offset: 0x0000C119
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
