using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200005C RID: 92
	public class RangosDeGeneracionParaDolorPorClutch : RangosDeGeneracionParaToquesRecibidos<DolorPorToques>
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000DEB6 File Offset: 0x0000C0B6
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

		// Token: 0x060001DE RID: 478 RVA: 0x0000DEC7 File Offset: 0x0000C0C7
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
