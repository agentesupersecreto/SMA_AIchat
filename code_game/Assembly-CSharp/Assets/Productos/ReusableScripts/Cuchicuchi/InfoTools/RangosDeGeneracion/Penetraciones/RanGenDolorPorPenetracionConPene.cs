using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000071 RID: 113
	public class RanGenDolorPorPenetracionConPene : RangosDeGeneracionParaPenetracion<DolorPorPenetracion>
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
