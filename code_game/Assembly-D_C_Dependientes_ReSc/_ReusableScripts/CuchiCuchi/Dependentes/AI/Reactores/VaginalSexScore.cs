using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002EF RID: 751
	public abstract class VaginalSexScore : AutoSexScore<IVagHole>
	{
		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x0005A4D6 File Offset: 0x000586D6
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.entrepierna;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x0005A4E8 File Offset: 0x000586E8
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.entrepierna;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x060012EE RID: 4846 RVA: 0x0005A3BE File Offset: 0x000585BE
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.vag;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x0005A4FA File Offset: 0x000586FA
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.entrepiernaPercentage;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x060012F0 RID: 4848 RVA: 0x0005A3C2 File Offset: 0x000585C2
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaHacerEjercicio;
			}
		}
	}
}
