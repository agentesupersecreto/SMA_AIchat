using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002E3 RID: 739
	public abstract class AnalPosibilidadScore : AutoSexPosibilidadScore<IAnusHole>
	{
		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x000593DD File Offset: 0x000575DD
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.trasero;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060012AF RID: 4783 RVA: 0x000593EF File Offset: 0x000575EF
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.trasero;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x00059401 File Offset: 0x00057601
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.ano;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x00059405 File Offset: 0x00057605
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaHacerEjercicioNoNatural;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x00059409 File Offset: 0x00057609
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.traseroPercentage;
			}
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x0005941C File Offset: 0x0005761C
		protected override void CalcularEvacion(Vector3 worldTargetPosition, float score, ref Vector3 anglesOffsets, ref bool evadingEsPositivo)
		{
			evadingEsPositivo = true;
			if (this.m_anglesCalculeCooldown.isOn)
			{
				anglesOffsets = base.resultados.anglesOffsets;
				return;
			}
			this.m_anglesCalculeCooldown.ApplyRandomMod(0.5f);
			Vector3 vector = worldTargetPosition - this.m_Hole.entrada.position;
			if (vector == Vector3.zero)
			{
				return;
			}
			Quaternion quaternion = Quaternion.LookRotation(this.m_Hole.worldOutHoleDirection, this.m_Hole.worldUpHoleDirection);
			Quaternion quaternion2 = Quaternion.LookRotation(vector, this.m_Hole.worldUpHoleDirection);
			quaternion2 = Quaternion.RotateTowards(quaternion, quaternion2, 60f);
			Quaternion quaternion3 = Quaternion.Inverse(quaternion) * quaternion2;
			float num = (score * -1f).OutPow(base.config.evacionOutPowerV2);
			anglesOffsets = Vector3.Lerp(Vector3.zero, quaternion3.eulerAngles, num);
			anglesOffsets.z = 0f;
		}

		// Token: 0x04000D96 RID: 3478
		private CoolDown m_anglesCalculeCooldown = new CoolDown(1f);
	}
}
