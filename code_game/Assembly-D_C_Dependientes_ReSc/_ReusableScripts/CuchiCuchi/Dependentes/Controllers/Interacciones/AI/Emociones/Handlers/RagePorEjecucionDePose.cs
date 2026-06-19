using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers
{
	// Token: 0x020001F2 RID: 498
	public sealed class RagePorEjecucionDePose : CalculoDeEmocionesPorEjecutarDePose
	{
		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000C25 RID: 3109 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00039D57 File Offset: 0x00037F57
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_EjecucionDePose.PorOtros;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x00039D73 File Offset: 0x00037F73
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00039D8A File Offset: 0x00037F8A
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00039DA1 File Offset: 0x00037FA1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00039DAC File Offset: 0x00037FAC
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConcentToHero = this.m_emocionesDeOwner.GetComponentInChildren<ConsentToHero>();
			if (this.m_ConcentToHero == null)
			{
				throw new ArgumentNullException("m_ConcentToHero", "m_ConcentToHero null reference.");
			}
			this.m_arousal = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousal == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_ConcentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConcentNecesario == null)
			{
				throw new ArgumentNullException("m_ConcentNecesario", "m_ConcentNecesario null reference.");
			}
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00039E74 File Offset: 0x00038074
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorCambiarPose estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 10f, num4).OutPow(3f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00039F0C File Offset: 0x0003810C
		protected override bool MaximoAlcanzado(CalculoDeEstimuloCambioDePoseResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			if (base.MaximoAlcanzado(data, valorDeEmovionActual, out maxEmoValueDeGrupo))
			{
				return true;
			}
			if (this.m_ConsentForzado.EsCorrupted(data.estimuloBasico, data.estimulanteParte, data.tag))
			{
				maxEmoValueDeGrupo = valorDeEmovionActual;
				return true;
			}
			return false;
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x040008BE RID: 2238
		private ConsentToHero m_ConcentToHero;

		// Token: 0x040008BF RID: 2239
		private Arousal m_arousal;

		// Token: 0x040008C0 RID: 2240
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040008C1 RID: 2241
		private ConsentCorrupted m_ConsentForzado;
	}
}
