using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000074 RID: 116
	public class RanGenPlacerPorPenetraAnchConPene : RangosDeGeneracionParaPenetraAnchura<PlacerPorPenetraciones>
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000E110 File Offset: 0x0000C310
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
