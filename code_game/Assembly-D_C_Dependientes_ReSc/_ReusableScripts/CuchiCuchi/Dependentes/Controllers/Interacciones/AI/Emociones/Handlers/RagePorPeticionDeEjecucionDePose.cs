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
	// Token: 0x020001F5 RID: 501
	public sealed class RagePorPeticionDeEjecucionDePose : CalculoDeEmocionesPorPeticionEjecutarDePose
	{
		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x0003A2B7 File Offset: 0x000384B7
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_EjecucionDePose.porSiMismo;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000C53 RID: 3155 RVA: 0x00039D73 File Offset: 0x00037F73
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x00039D8A File Offset: 0x00037F8A
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00039DA1 File Offset: 0x00037FA1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0003A2D4 File Offset: 0x000384D4
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

		// Token: 0x06000C58 RID: 3160 RVA: 0x0003A39C File Offset: 0x0003859C
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorCambiarPose estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 20f, num4).OutPow(2f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0003A434 File Offset: 0x00038634
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

		// Token: 0x06000C5A RID: 3162 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x040008CA RID: 2250
		private ConsentToHero m_ConcentToHero;

		// Token: 0x040008CB RID: 2251
		private Arousal m_arousal;

		// Token: 0x040008CC RID: 2252
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040008CD RID: 2253
		private ConsentCorrupted m_ConsentForzado;
	}
}
