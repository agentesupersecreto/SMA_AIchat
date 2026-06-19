using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000070 RID: 112
	public class RanGenDolorPorPenetraApertConPene : RangosDeGeneracionParaPenetraApertura<DolorPorPenetracion>
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000218 RID: 536 RVA: 0x0000E0C0 File Offset: 0x0000C2C0
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
