using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000356 RID: 854
	public abstract class OralSexScore : AutoSexScore<IBocaHole>
	{
		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x0600156A RID: 5482 RVA: 0x00065B56 File Offset: 0x00063D56
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.labios;
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x0600156B RID: 5483 RVA: 0x00065B68 File Offset: 0x00063D68
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.labios;
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x0600156C RID: 5484 RVA: 0x00065A16 File Offset: 0x00063C16
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.bocaInterno;
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x0600156D RID: 5485 RVA: 0x00065B7A File Offset: 0x00063D7A
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.labiosPercentage;
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x0600156E RID: 5486 RVA: 0x00065A1A File Offset: 0x00063C1A
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaChupar;
			}
		}
	}
}
