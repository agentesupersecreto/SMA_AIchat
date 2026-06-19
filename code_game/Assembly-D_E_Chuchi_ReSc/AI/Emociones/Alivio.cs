using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000403 RID: 1027
	public sealed class Alivio : Emocion
	{
		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x0600166C RID: 5740 RVA: 0x00030684 File Offset: 0x0002E884
		public override float prioridad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x0600166D RID: 5741 RVA: 0x0005CDD7 File Offset: 0x0005AFD7
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.alivio;
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x0600166E RID: 5742 RVA: 0x0005CDE0 File Offset: 0x0005AFE0
		[Obsolete("reemplazado por modificadorDeEmocion", true)]
		public float sensivilidadMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_personalidad.GetTraitScore(TraitHumano.sensibilidadV2);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.3333334f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.75f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x0005CE48 File Offset: 0x0005B048
		[Obsolete("reemplazado por modificadorDeEmocion", true)]
		public float estadoFisicoMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_personalidad.GetTraitScore(TraitHumano.estadoFisico);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.3333334f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.75f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06001670 RID: 5744 RVA: 0x0005CEAF File Offset: 0x0005B0AF
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.alivioGananciaPorPersonalidad;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06001671 RID: 5745 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x0005CEBC File Offset: 0x0005B0BC
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0005CEEF File Offset: 0x0005B0EF
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.estado = Alivio.Estado.None;
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0005CF00 File Offset: 0x0005B100
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			float dolorGananciaPorPersonalidad = this.m_personalidad.dolorGananciaPorPersonalidad;
			try
			{
				aumento *= Singleton<ConfiguracionGeneralDeCheats>.instance.reliefGainMod;
				aumentoCrudo = aumento;
				if (this.puedeDismunuir() && valorACambiar < 0f)
				{
					aumento -= this.disminucionPorSegundo * Time.deltaTime;
					this.estado = Alivio.Estado.disminuyendo;
					this.m_coolDownParaCambioDeEstado.ApplyNext(2f * dolorGananciaPorPersonalidad);
				}
			}
			finally
			{
				if (this.puedeAumentar() && aumento == 0f && base.value.total < 100f)
				{
					aumento = this.aumentoPorSegundo * Time.deltaTime;
					this.estado = Alivio.Estado.aumentando;
					this.m_coolDownParaCambioDeEstado.ApplyNext(2f * dolorGananciaPorPersonalidad);
				}
			}
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x00005F51 File Offset: 0x00004151
		private bool puedeDismunuir()
		{
			return true;
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x0005CFC8 File Offset: 0x0005B1C8
		private bool puedeAumentar()
		{
			switch (this.estado)
			{
			case Alivio.Estado.None:
				return true;
			case Alivio.Estado.disminuyendo:
				return !this.m_coolDownParaCambioDeEstado.isOn;
			case Alivio.Estado.aumentando:
				return true;
			default:
				throw new ArgumentOutOfRangeException(this.estado.ToString());
			}
		}

		// Token: 0x06001677 RID: 5751 RVA: 0x0005D019 File Offset: 0x0005B219
		protected override void IncreaseValueNextUpdatePostMod(ref float amount)
		{
			amount *= Singleton<ConfiguracionGeneralDeCheats>.instance.reliefGainMod;
		}

		// Token: 0x040011AF RID: 4527
		public float disminucionPorSegundo = 25f;

		// Token: 0x040011B0 RID: 4528
		public float aumentoPorSegundo = 20f;

		// Token: 0x040011B1 RID: 4529
		public Alivio.Estado estado;

		// Token: 0x040011B2 RID: 4530
		private Personalidad m_personalidad;

		// Token: 0x040011B3 RID: 4531
		private CoolDown m_coolDownParaCambioDeEstado = new CoolDown();

		// Token: 0x02000404 RID: 1028
		public enum Estado
		{
			// Token: 0x040011B5 RID: 4533
			None,
			// Token: 0x040011B6 RID: 4534
			disminuyendo,
			// Token: 0x040011B7 RID: 4535
			aumentando
		}
	}
}
