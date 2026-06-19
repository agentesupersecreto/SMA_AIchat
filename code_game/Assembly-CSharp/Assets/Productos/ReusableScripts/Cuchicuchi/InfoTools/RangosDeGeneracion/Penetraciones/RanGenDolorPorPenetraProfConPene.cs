using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000073 RID: 115
	public class RanGenDolorPorPenetraProfConPene : RangosDeGeneracionParaPenetraProfundidad<DolorPorPenetracion>
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600021E RID: 542 RVA: 0x0000E0FC File Offset: 0x0000C2FC
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
