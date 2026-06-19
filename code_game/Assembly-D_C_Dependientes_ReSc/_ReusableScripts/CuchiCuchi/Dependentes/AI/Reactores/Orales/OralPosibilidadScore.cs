using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000355 RID: 853
	public abstract class OralPosibilidadScore : AutoSexPosibilidadScore<IBocaHole>
	{
		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06001562 RID: 5474 RVA: 0x000659F2 File Offset: 0x00063BF2
		public override Deseos.ThresholdPositivo deseosThresholdPositivo
		{
			get
			{
				return this.m_Deseos.thresholdsPositivos.labios;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06001563 RID: 5475 RVA: 0x00065A04 File Offset: 0x00063C04
		public override Deseos.ThresholdNegativo deseosThresholdNegativo
		{
			get
			{
				return this.m_Deseos.thresholdsNegativo.labios;
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001564 RID: 5476 RVA: 0x00065A16 File Offset: 0x00063C16
		public override ParteDelCuerpoHumano paraEstimulado
		{
			get
			{
				return ParteDelCuerpoHumano.bocaInterno;
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x00065A1A File Offset: 0x00063C1A
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.leGustaChupar;
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001566 RID: 5478 RVA: 0x00065A1E File Offset: 0x00063C1E
		public override float currentDeseoPercentage
		{
			get
			{
				return this.m_Deseos.valores.labiosPercentage;
			}
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x00065A30 File Offset: 0x00063C30
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_oralIK = this.GetComponentEnRoot(false);
			if (this.m_oralIK == null)
			{
				throw new ArgumentNullException("m_oralIK", "m_oralIK null reference.");
			}
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x00065A60 File Offset: 0x00063C60
		protected override void CalcularEvacion(Vector3 worldTargetPosition, float score, ref Vector3 anglesOffsets, ref bool evadingEsPositivo)
		{
			float anguloHorizontal = this.m_oralIK.estadisticasHaciaTarget.anguloHorizontal;
			float anguloHorizontal2 = this.m_oralIK.estadisticasHead.anguloHorizontal;
			float num = Mathf.Abs(anguloHorizontal);
			float num2 = Mathf.Abs(anguloHorizontal2);
			if ((((anguloHorizontal < 0f && anguloHorizontal2 < 0f) || (anguloHorizontal > 0f && anguloHorizontal2 > 0f)) && num2 > 45f) || (num2 > 10f && num > 10f && num > num2))
			{
				evadingEsPositivo = anguloHorizontal >= 0f;
			}
			float num3 = (float)(60 * (evadingEsPositivo ? 1 : (-1)));
			Vector3 vector = new Vector3(0f, num3, 0f);
			float num4 = (score * -1f).OutPow(base.config.evacionOutPowerV2);
			anglesOffsets = Vector3.Lerp(Vector3.zero, vector, num4);
		}

		// Token: 0x04000F27 RID: 3879
		private IOralAt m_oralIK;
	}
}
