using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002EE RID: 750
	public abstract class VaginalPosibilidadScore : AutoSexPosibilidadScore<IVagHole>
	{
		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x0005A39A File Offset: 0x0005859A
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.entrepierna;
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x060012E6 RID: 4838 RVA: 0x0005A3AC File Offset: 0x000585AC
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.entrepierna;
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0005A3BE File Offset: 0x000585BE
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.vag;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x0005A3C2 File Offset: 0x000585C2
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaHacerEjercicio;
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x0005A3C6 File Offset: 0x000585C6
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.entrepiernaPercentage;
			}
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x0005A3D8 File Offset: 0x000585D8
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

		// Token: 0x04000DE4 RID: 3556
		private CoolDown m_anglesCalculeCooldown = new CoolDown(1f);
	}
}
