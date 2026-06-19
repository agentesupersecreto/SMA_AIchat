using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000075 RID: 117
	public class RanGenPlacerPorPenetraApertConPene : RangosDeGeneracionParaPenetraApertura<PlacerPorPenetraciones>
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000E124 File Offset: 0x0000C324
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
