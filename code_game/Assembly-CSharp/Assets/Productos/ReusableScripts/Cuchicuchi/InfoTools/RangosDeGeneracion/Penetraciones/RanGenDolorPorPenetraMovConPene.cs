using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000072 RID: 114
	public class RanGenDolorPorPenetraMovConPene : RangosDeGeneracionParaPenetraMovimiento<DolorPorPenetracion>
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600021C RID: 540 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
