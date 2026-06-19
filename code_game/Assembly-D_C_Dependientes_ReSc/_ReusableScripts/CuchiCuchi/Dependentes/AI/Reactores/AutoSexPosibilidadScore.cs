using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002E5 RID: 741
	public abstract class AutoSexPosibilidadScore<THole> : AutoSexPosibilidadScore where THole : IHole
	{
		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060012BB RID: 4795 RVA: 0x00059558 File Offset: 0x00057758
		public Deseos deseos
		{
			get
			{
				return this.m_Deseos;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060012BC RID: 4796
		public abstract Deseos.ThresholdPositivo deseosThresholdPositivo { get; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060012BD RID: 4797
		public abstract Deseos.ThresholdNegativo deseosThresholdNegativo { get; }

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060012BE RID: 4798
		public abstract ParteDelCuerpoHumano paraEstimulado { get; }

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060012BF RID: 4799
		public abstract float currentDeseoPercentage { get; }

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060012C0 RID: 4800
		protected abstract TraitHumano trait { get; }

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060012C1 RID: 4801 RVA: 0x00059560 File Offset: 0x00057760
		public override IHole paraHole
		{
			get
			{
				return this.m_Hole;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060012C2 RID: 4802 RVA: 0x0005956D File Offset: 0x0005776D
		public AutoSexPosibilidadScore.Config config
		{
			get
			{
				return this.m_Config;
			}
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x00059578 File Offset: 0x00057778
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Hole = this.GetComponentEnRoot(false);
			if (this.m_Hole == null)
			{
				throw new ArgumentNullException("m_Hole", "m_Hole null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_Deseos = this.GetComponentEnRoot(false);
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_IAutoSexRangesGetter = this.GetComponentEnRoot(false);
			if (this.m_IAutoSexRangesGetter == null)
			{
				throw new ArgumentNullException("m_IAutoSexRangesGetter", "m_IAutoSexRangesGetter null reference.");
			}
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0005965B File Offset: 0x0005785B
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Resultados.evadingEsPositivo = Random.value > 0.5f;
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0005967C File Offset: 0x0005787C
		public void DoUpdate(IPeneConPartes pene, ICalculoDeInteracionEstimulanteConEstado calculo, int prioridadBase, out int prioridadResult)
		{
			if (this.m_unpdateID.IsCurrent() || !base.enabled)
			{
				prioridadResult = Mathf.RoundToInt((float)prioridadBase * this.m_Resultados.weightModV2);
				return;
			}
			this.m_unpdateID = ForcedUpdateId.current;
			this.m_Resultados.thresholds = AutoSexPosibilidadScore.Thresholds.Producir(this.m_Personalidad.GetTraitScore(this.trait));
			this.m_Resultados.algunaParteEnElPlano = false;
			this.m_Resultados.targetParte = null;
			float worldLength = pene.worldLength;
			Transform entrada = this.m_Hole.entrada;
			Vector3 worldOutHoleDirection = this.m_Hole.worldOutHoleDirection;
			Vector3 vector = entrada.position + worldOutHoleDirection * (pene.worldLengthFromUnderSkin / (float)pene.countDePartes);
			int num = Mathf.CeilToInt(Mathf.Lerp(1f, (float)(pene.countDePartes + 1), (pene.currentRealErectionValue / 100f).OutPow(this.m_Config.elegirTargetSegunEreccionPower)));
			if (!this.m_Resultados.algunaParteEnElPlano)
			{
				for (int i = num - 2; i >= 0; i--)
				{
					PenisPart penisPart = pene.partesEnOrden[i];
					Transform transform = penisPart.physicBone.transform;
					Vector3 vector2 = penisPart.mainCollider.ColliderTipLocalPosition();
					if (Math3dTvalle.PuntoEstaDelanteDePlano(worldOutHoleDirection, vector, transform.TransformPoint(vector2)))
					{
						this.m_Resultados.algunaParteEnElPlano = true;
						this.m_Resultados.targetParte = transform;
						this.m_Resultados.targetLocalOffset = vector2;
						this.m_Resultados.indexDeParte = i;
						break;
					}
				}
			}
			if (!this.m_Resultados.algunaParteEnElPlano)
			{
				this.m_Resultados.targetParte = pene.parteBase;
				this.m_Resultados.targetLocalOffset = Vector3.zero;
				this.m_Resultados.indexDeParte = 0;
			}
			Vector3 vector3 = this.m_Resultados.targetParte.TransformPoint(this.m_Resultados.targetLocalOffset);
			this.m_Resultados.scoreV2 = (this.m_Resultados.scoreByDesires = AutoSexPosibilidadScore.GetScorePorDeseoPercentage(this.currentDeseoPercentage, this.deseosThresholdPositivo.deseoParaTeasing, this.deseosThresholdNegativo.deseoParaRechazarTeasing));
			float num2;
			float num3;
			this.m_IAutoSexRangesGetter.EsConsentido(this.paraEstimulado, this.paraParte, out num2, out num3);
			this.m_Resultados.penetracionEsConsentida = num3 >= 1f;
			if (num2 < 1f)
			{
				float num4 = Mathf.InverseLerp(0f, 1f, num2);
				float num5 = Mathf.Lerp(-1f, this.m_Config.maxScoreAtNoConsent, num4);
				this.m_Resultados.scoreV2 = num5;
			}
			if (num3 < 1f)
			{
				float num6 = Mathf.InverseLerp(0f, 1f, num3);
				float num7 = Mathf.Lerp(-1f, this.m_Config.maxScoreAtNoConsent, num6);
				this.m_Resultados.scoreV2 = num7;
			}
			float num8 = ((this.paraEstimulado == ParteDelCuerpoHumano.bocaInterno) ? 0.333f : 0f);
			if ((num2 >= 1f || num3 >= 1f) && this.m_Resultados.scoreV2 < num8)
			{
				this.m_Resultados.scoreV2 = num8;
			}
			this.m_Resultados.distanceToTarget = (vector3 - this.m_Hole.entrada.position).magnitude;
			float num9 = (this.m_Resultados.algunaParteEnElPlano ? 1f : 0.5f);
			float num10 = (pene.hidden ? 0.5f : 1f);
			this.m_Resultados.distanceToBase = (pene.parteBase.position - this.m_Hole.entrada.position).magnitude;
			float num11 = Mathf.InverseLerp(worldLength * 4f, worldLength * 2f, this.m_Resultados.distanceToBase);
			num11 = Mathf.Lerp(0.25f, 1f, num11);
			this.m_Resultados.weightModV2 = num9 * num10 * num11;
			prioridadResult = Mathf.RoundToInt((float)prioridadBase * this.m_Resultados.weightModV2);
			this.m_Resultados.weightV2 = ((this.m_Resultados.scoreV2 == 0f) ? 0f : Mathf.Lerp(this.m_Config.minWeight, 1f, Mathf.Abs(this.m_Resultados.scoreV2)));
			this.m_Resultados.weightV2 *= this.m_Resultados.weightModV2;
			float num12 = (this.config.maxProyection + this.config.minProyection) / 2f;
			if (this.m_Resultados.scoreV2 >= 0f)
			{
				this.m_Resultados.proyection = Mathf.Lerp(num12, this.config.maxProyection, this.m_Resultados.scoreV2.OutPow(this.m_Config.proyectionOutPower));
			}
			else
			{
				this.m_Resultados.proyection = Mathf.Lerp(num12, this.config.minProyection, (this.m_Resultados.scoreV2 * -1f).OutPow(this.m_Config.proyectionOutPower));
			}
			if (this.m_Resultados.scoreV2 >= 0f)
			{
				this.m_Resultados.anglesOffsets = Vector3.zero;
				return;
			}
			this.CalcularEvacion(vector3, this.m_Resultados.scoreV2, ref this.m_Resultados.anglesOffsets, ref this.m_Resultados.evadingEsPositivo);
		}

		// Token: 0x060012C6 RID: 4806
		protected abstract void CalcularEvacion(Vector3 worldTargetPosition, float score, ref Vector3 anglesOffsets, ref bool evadingEsPositivo);

		// Token: 0x04000D97 RID: 3479
		private ForcedUpdateId m_unpdateID;

		// Token: 0x04000D98 RID: 3480
		protected THole m_Hole;

		// Token: 0x04000D99 RID: 3481
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000D9A RID: 3482
		protected Deseos m_Deseos;

		// Token: 0x04000D9B RID: 3483
		private Personalidad m_Personalidad;

		// Token: 0x04000D9C RID: 3484
		private IAutoSexRangesGetter m_IAutoSexRangesGetter;
	}
}
