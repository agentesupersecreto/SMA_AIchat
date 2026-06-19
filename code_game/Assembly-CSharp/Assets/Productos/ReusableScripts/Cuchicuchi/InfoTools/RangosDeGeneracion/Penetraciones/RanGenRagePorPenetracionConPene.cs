using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x02000079 RID: 121
	public class RanGenRagePorPenetracionConPene : RangosDeGeneracionParaPenetracion<RagePorPenetracion>
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000E174 File Offset: 0x0000C374
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
