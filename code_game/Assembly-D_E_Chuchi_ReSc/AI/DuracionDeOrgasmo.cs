using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Globales;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000348 RID: 840
	public class DuracionDeOrgasmo : CustomMonobehaviour, IDuracionDeOrgasmo
	{
		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x0004E270 File Offset: 0x0004C470
		protected float duracionDeOrgasmoMod
		{
			get
			{
				switch (this.m_personalidad.GetTraitScore(TraitHumano.orgasmoDuracion))
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.2f;
				case HumanTraitScore.muyAlto:
					return 1.4f;
				case HumanTraitScore.bajo:
					return 0.8333333f;
				case HumanTraitScore.muyBajo:
					return 0.71428573f;
				default:
					throw new ArgumentOutOfRangeException(this.m_personalidad.GetTraitScore(TraitHumano.orgasmoDuracion).ToString());
				}
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x0600120C RID: 4620 RVA: 0x0004E2E5 File Offset: 0x0004C4E5
		public float currentDuracionTotalDeOrgasmo
		{
			get
			{
				return this.GetCurrentDuracionTotalDeOrgasmo();
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x0004E2ED File Offset: 0x0004C4ED
		public ExpresionVerbalData nextOrgasmSound
		{
			get
			{
				this.GetCurrentDuracionTotalDeOrgasmo();
				if (this.m_nextOrgasmSound == null)
				{
					throw new InvalidOperationException("mapa de orgas nunca deberia ser null");
				}
				return this.m_nextOrgasmSound;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x0600120E RID: 4622 RVA: 0x0004E315 File Offset: 0x0004C515
		public bool nextOrgasmApretaraBoca
		{
			get
			{
				this.GetCurrentDuracionTotalDeOrgasmo();
				return this.m_nextOrgasmApretaraBoca;
			}
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x0004E324 File Offset: 0x0004C524
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_CharacterPitchDeExpulsiones = this.GetComponentEnRoot(false);
			if (this.m_CharacterPitchDeExpulsiones == null)
			{
				throw new ArgumentNullException("m_CharacterPitchDeExpulsiones", "m_CharacterPitchDeExpulsiones null reference.");
			}
			this.m_emos = this.GetComponentEnRoot(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0004E3B8 File Offset: 0x0004C5B8
		public void FlagSonidoDeOrgasmoUsado(ExpresionVerbalData usado)
		{
			this.m_lastOrgasmSound = usado;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x0004E3C4 File Offset: 0x0004C5C4
		private float GetCurrentDuracionTotalDeOrgasmo()
		{
			if (this.m_coolDownParaRecalcular.isOn)
			{
				return this.m_currentDuracionDeOrgasmo;
			}
			this.m_nextOrgasmSound = Singleton<MapasDeSonidosDeExpresionesVerbalesSexuales>.instance.ObtenerMapaDeOrgasmo(this.m_CharacterPitchDeExpulsiones.expresionesSonidosIndex, this.m_lastOrgasmSound);
			if (this.m_nextOrgasmSound == null)
			{
				throw new InvalidOperationException("mapa de orgas nunca deberia ser null");
			}
			float mod = this.m_emos.arousal.value.mod;
			bool flag = (!this.m_personalidad.respetuoso && !this.m_personalidad.timido && !this.m_personalidad.sumiso) || this.m_personalidad.extrovertido || this.m_personalidad.pervertido || this.m_personalidad.exhibicionista || Mathf.Lerp(this.probabilidadDeExpresionConSonidoSiEsRespetuosa, 100f, mod.OutPow(3f)).ProcPorcentaje(1f);
			this.m_nextOrgasmApretaraBoca = !flag;
			float num = this.m_nextOrgasmSound.Length(this.m_CharacterPitchDeExpulsiones.pitchDeVocal);
			float num2 = 9f * this.duracionDeOrgasmoMod;
			this.m_currentDuracionDeOrgasmo = Random.Range(num2 * 0.9f, num2 * 1.1f);
			if (this.m_currentDuracionDeOrgasmo < num)
			{
				this.m_currentDuracionDeOrgasmo = num;
			}
			this.m_coolDownParaRecalcular.ApplyNext(this.m_currentDuracionDeOrgasmo * 0.5f);
			return this.m_currentDuracionDeOrgasmo;
		}

		// Token: 0x04000F27 RID: 3879
		[ReadOnlyUI]
		[SerializeField]
		private bool m_nextOrgasmApretaraBoca;

		// Token: 0x04000F28 RID: 3880
		[ReadOnlyUI]
		[SerializeField]
		private ExpresionVerbalData m_nextOrgasmSound;

		// Token: 0x04000F29 RID: 3881
		[ReadOnlyUI]
		[SerializeField]
		private ExpresionVerbalData m_lastOrgasmSound;

		// Token: 0x04000F2A RID: 3882
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentDuracionDeOrgasmo = 9f;

		// Token: 0x04000F2B RID: 3883
		private CoolDown m_coolDownParaRecalcular = new CoolDown();

		// Token: 0x04000F2C RID: 3884
		private Personalidad m_personalidad;

		// Token: 0x04000F2D RID: 3885
		private CharacterPitchDeExpulsiones m_CharacterPitchDeExpulsiones;

		// Token: 0x04000F2E RID: 3886
		private EmocionesFemeninas m_emos;

		// Token: 0x04000F2F RID: 3887
		[Range(0f, 100f)]
		public float probabilidadDeExpresionConSonidoSiEsRespetuosa = 20f;
	}
}
