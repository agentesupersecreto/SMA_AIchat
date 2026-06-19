using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000076 RID: 118
	public class RanGenPlacerPorPenetracionConPene : RangosDeGeneracionParaPenetracion<PlacerPorPenetraciones>
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000E138 File Offset: 0x0000C338
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
