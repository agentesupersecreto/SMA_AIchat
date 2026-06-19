using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000078 RID: 120
	public class RanGenPlacerPorPenetraProfConPene : RangosDeGeneracionParaPenetraProfundidad<PlacerPorPenetraciones>
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000E160 File Offset: 0x0000C360
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
