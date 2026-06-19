using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002E4 RID: 740
	public abstract class AnalSexScore : AutoSexScore<IAnusHole>
	{
		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x0005951A File Offset: 0x0005771A
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.trasero;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x0005952C File Offset: 0x0005772C
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.trasero;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x00059401 File Offset: 0x00057601
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.ano;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060012B8 RID: 4792 RVA: 0x0005953E File Offset: 0x0005773E
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.traseroPercentage;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060012B9 RID: 4793 RVA: 0x00059405 File Offset: 0x00057605
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaHacerEjercicioNoNatural;
			}
		}
	}
}
