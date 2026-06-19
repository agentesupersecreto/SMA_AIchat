using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000357 RID: 855
	public sealed class DedoOralPosibilidadScore : OralPosibilidadScore
	{
		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06001570 RID: 5488 RVA: 0x0005AB40 File Offset: 0x00058D40
		public override ParteQuePuedeEstimular paraParte
		{
			get
			{
				return ParteQuePuedeEstimular.dedo;
			}
		}
	}
}
