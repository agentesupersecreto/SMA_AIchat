using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000063 RID: 99
	public class RangosDeGeneracionParaPlacerPorClutch : RangosDeGeneracionParaToquesRecibidos<PlacerPorToques>
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000DF6E File Offset: 0x0000C16E
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

		// Token: 0x060001F3 RID: 499 RVA: 0x0000DF7F File Offset: 0x0000C17F
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
