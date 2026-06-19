using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000536 RID: 1334
	public class ArousalPorOrgasmo : EmocionPorEmocionMax
	{
		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x060020CE RID: 8398 RVA: 0x0007AE87 File Offset: 0x00079087
		protected override Emocion atMax
		{
			get
			{
				return this.m_placer;
			}
		}

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x060020CF RID: 8399 RVA: 0x0007AE8F File Offset: 0x0007908F
		protected override Emocion target
		{
			get
			{
				return this.m_Arousal;
			}
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x060020D0 RID: 8400 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float aumentoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x060020D1 RID: 8401 RVA: 0x0007AE97 File Offset: 0x00079097
		protected override float aumentoTemporalMod
		{
			get
			{
				return this.ModDeTrait(this.m_personalidad.GetTraitScore(TraitHumano.orgasmoAumentoTempDeArousal));
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x060020D2 RID: 8402 RVA: 0x0007AEAC File Offset: 0x000790AC
		protected override float tiempoParaReducirAumentoTemporalAproxMod
		{
			get
			{
				return this.ModDeTrait(this.m_personalidad.GetTraitScore(TraitHumano.orgasmoRecuperacionDeArousal));
			}
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x0007AEC1 File Offset: 0x000790C1
		protected override void AwakeUnityEvent()
		{
			this.m_Arousal = base.GetComponentInParent<Arousal>();
			if (this.m_Arousal == null)
			{
				throw new ArgumentNullException("m_Arousal", "m_Arousal null reference.");
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x0007AEF4 File Offset: 0x000790F4
		protected override void StartUnityEvent()
		{
			CharAi componentInParent = this.m_Arousal.owner.GetComponentInParent<CharAi>();
			this.m_personalidad = ((componentInParent != null) ? componentInParent.GetComponentInChildren<Personalidad>() : null);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_placer = this.m_Arousal.owner.placer;
			base.StartUnityEvent();
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x0007AF60 File Offset: 0x00079160
		private float ModDeTrait(HumanTraitScore score)
		{
			switch (score)
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 1.5f;
			case HumanTraitScore.muyAlto:
				return 2.5f;
			case HumanTraitScore.bajo:
				return 0.5f;
			case HumanTraitScore.muyBajo:
				return 0.2f;
			default:
				throw new ArgumentOutOfRangeException(score.ToString());
			}
		}

		// Token: 0x04001562 RID: 5474
		private Arousal m_Arousal;

		// Token: 0x04001563 RID: 5475
		private PlacerBase m_placer;

		// Token: 0x04001564 RID: 5476
		private Personalidad m_personalidad;
	}
}
