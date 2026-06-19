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
	// Token: 0x020001F3 RID: 499
	public sealed class RagePorGuiaDeBones : CalculoDeEmocionesPorGuiaDeBones
	{
		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00039D73 File Offset: 0x00037F73
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x00039D8A File Offset: 0x00037F8A
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00039F40 File Offset: 0x00038140
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Vision.siendoMirado;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00039DA1 File Offset: 0x00037FA1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00039F5C File Offset: 0x0003815C
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

		// Token: 0x06000C3B RID: 3131 RVA: 0x0003A024 File Offset: 0x00038224
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorManipulacionDeBone estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 20f, num4).OutPow(2f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0003A0BB File Offset: 0x000382BB
		protected override bool MaximoAlcanzado(CalculoDeEmocionesPorMovimientoDeBonesResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
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

		// Token: 0x06000C3D RID: 3133 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x040008C2 RID: 2242
		private ConsentToHero m_ConcentToHero;

		// Token: 0x040008C3 RID: 2243
		private Arousal m_arousal;

		// Token: 0x040008C4 RID: 2244
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040008C5 RID: 2245
		private ConsentCorrupted m_ConsentForzado;
	}
}
