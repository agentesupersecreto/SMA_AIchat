using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200033B RID: 827
	public class ContraccionesDeOrgasmo : CustomMonobehaviour, IContraccionesDeOrgasmo
	{
		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x0004C218 File Offset: 0x0004A418
		protected float contracionesDeOrgasmoMod
		{
			get
			{
				switch (this.m_personalidad.GetTraitScore(TraitHumano.orgasmoContraciones))
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.25f;
				case HumanTraitScore.muyAlto:
					return 1.5f;
				case HumanTraitScore.bajo:
					return 0.8f;
				case HumanTraitScore.muyBajo:
					return 0.6666667f;
				default:
					throw new ArgumentOutOfRangeException(this.m_personalidad.GetTraitScore(TraitHumano.orgasmoContraciones).ToString());
				}
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x060011C1 RID: 4545 RVA: 0x0004C290 File Offset: 0x0004A490
		public int currentContraccionesDeOrgasmo
		{
			get
			{
				if (this.m_coolDownParaRecalcular.isOn)
				{
					return this.m_currentContraccionesDeOrgasmo;
				}
				int num = Mathf.CeilToInt(24f * this.contracionesDeOrgasmoMod);
				this.m_currentContraccionesDeOrgasmo = Random.Range(num - 2, num + 3);
				this.m_currentContraccionesDeOrgasmo = Mathf.Clamp(this.m_currentContraccionesDeOrgasmo, 1, int.MaxValue);
				this.m_coolDownParaRecalcular.ApplyNext(this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo * 0.5f);
				return this.m_currentContraccionesDeOrgasmo;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x0004C30D File Offset: 0x0004A50D
		public AnimationCurve contraccionCurva
		{
			get
			{
				return Singleton<CollecionDeCurvasParaEmocionesReacciones>.instance.ObtenerCurvaMaxValue(ReaccionHumana.placer);
			}
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0004C31C File Offset: 0x0004A51C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_DuracionDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_DuracionDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_DuracionDeOrgasmo", "m_DuracionDeOrgasmo null reference.");
			}
		}

		// Token: 0x04000EEE RID: 3822
		[ReadOnlyUI]
		[SerializeField]
		private int m_currentContraccionesDeOrgasmo = 24;

		// Token: 0x04000EEF RID: 3823
		private CoolDown m_coolDownParaRecalcular = new CoolDown();

		// Token: 0x04000EF0 RID: 3824
		private Personalidad m_personalidad;

		// Token: 0x04000EF1 RID: 3825
		private IDuracionDeOrgasmo m_DuracionDeOrgasmo;
	}
}
