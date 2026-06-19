using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002EA RID: 746
	public abstract class AutoSexScore<THole> : AutoSexScore where THole : IHole
	{
		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x060012D5 RID: 4821
		public abstract Deseos.ThresholdPositivo deseosThresholdPositivo { get; }

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060012D6 RID: 4822
		public abstract Deseos.ThresholdNegativo deseosThresholdNegativo { get; }

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060012D7 RID: 4823
		public abstract ParteDelCuerpoHumano paraEstimulado { get; }

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060012D8 RID: 4824
		public abstract float currentDeseoPercentage { get; }

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060012D9 RID: 4825
		protected abstract TraitHumano trait { get; }

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x060012DA RID: 4826 RVA: 0x00059FD3 File Offset: 0x000581D3
		public override IHole paraHole
		{
			get
			{
				return this.m_Hole;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x00059FE0 File Offset: 0x000581E0
		public AutoSexScore.Config config
		{
			get
			{
				return this.m_Config;
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x00059FE8 File Offset: 0x000581E8
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

		// Token: 0x060012DD RID: 4829 RVA: 0x0005A0CC File Offset: 0x000582CC
		public void DoUpdate(IPeneConPartes pene, ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			if (this.m_unpdateID.IsCurrent() || !base.enabled)
			{
				return;
			}
			this.m_unpdateID = ForcedUpdateId.current;
			this.m_Resultados.thresholds = AutoSexPosibilidadScore.Thresholds.Producir(this.m_Personalidad.GetTraitScore(this.trait));
			this.m_Resultados.targetTransform = pene.lookAtTarget;
			Vector3 position = this.m_Resultados.targetTransform.position;
			this.m_Resultados.scoreV2 = (this.m_Resultados.scoreByDesires = AutoSexPosibilidadScore.GetScorePorDeseoPercentage(this.currentDeseoPercentage, this.deseosThresholdPositivo.deseoParaSex, this.deseosThresholdNegativo.deseoParaRechazarSex));
			this.m_Resultados.distanceToTarget = (position - this.m_Hole.entrada.position).magnitude;
			this.m_Resultados.weightTeasing = 1f;
			float num;
			float num2;
			this.m_IAutoSexRangesGetter.EsConsentido(this.paraEstimulado, this.paraParte, out num, out num2);
			this.m_Resultados.penetracionEsConsentida = num2 >= 1f;
			float num3 = Mathf.Min(num, num2);
			float num4 = ((this.paraEstimulado == ParteDelCuerpoHumano.bocaInterno) ? 0.333f : 0f);
			if (num3 < 1f)
			{
				float num5 = Mathf.InverseLerp(0f, 1f, num3);
				float num6 = Mathf.Lerp(-1f, this.m_Config.maxScoreAtNoConsent, num5);
				this.m_Resultados.scoreV2 = num6;
			}
			else if (num3 >= 1f && this.m_Resultados.scoreV2 < num4)
			{
				this.m_Resultados.scoreV2 = num4;
			}
			float num7;
			this.m_Resultados.muyEstrecho = this.m_IAutoSexRangesGetter.EsMuyApretado(pene.worldMaxWidth, this.paraEstimulado, this.paraParte, out num7);
			this.m_Resultados.muyEstrechoOffsetMod = num7;
			if (this.m_Resultados.muyEstrecho)
			{
				this.m_Resultados.scoreV2 = -1f;
			}
			if (this.m_Resultados.scoreV2 >= 0f)
			{
				this.m_Resultados.proyection = this.config.maxProyection;
				return;
			}
			this.m_Resultados.proyection = Mathf.Lerp(this.config.maxProyection, this.config.minProyection, (this.m_Resultados.scoreV2 * -1f).OutPow(this.m_Config.proyectionOutPower));
		}

		// Token: 0x04000DC9 RID: 3529
		private ForcedUpdateId m_unpdateID;

		// Token: 0x04000DCA RID: 3530
		protected THole m_Hole;

		// Token: 0x04000DCB RID: 3531
		protected ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000DCC RID: 3532
		protected Deseos m_Deseos;

		// Token: 0x04000DCD RID: 3533
		protected Personalidad m_Personalidad;

		// Token: 0x04000DCE RID: 3534
		private IAutoSexRangesGetter m_IAutoSexRangesGetter;
	}
}
