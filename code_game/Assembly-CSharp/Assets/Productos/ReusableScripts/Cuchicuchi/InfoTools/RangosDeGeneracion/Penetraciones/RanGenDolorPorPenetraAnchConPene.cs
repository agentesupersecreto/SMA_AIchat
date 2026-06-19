using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.RangosDeGeneracion.Penetraciones
{
	// Token: 0x0200006F RID: 111
	public class RanGenDolorPorPenetraAnchConPene : RangosDeGeneracionParaPenetraAnchura<DolorPorPenetracion>
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000216 RID: 534 RVA: 0x0000E0AC File Offset: 0x0000C2AC
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.pene };
			}
		}
	}
}
