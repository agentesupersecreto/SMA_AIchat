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
	// Token: 0x020001F4 RID: 500
	public sealed class RagePorManipulacionDeBones : CalculoDeEmocionesPorManipulacionDeBones
	{
		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x0003A0EF File Offset: 0x000382EF
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidad;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00039D8A File Offset: 0x00037F8A
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x0003A106 File Offset: 0x00038306
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Caricias.porCaricias;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00039DA1 File Offset: 0x00037FA1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0003A124 File Offset: 0x00038324
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

		// Token: 0x06000C49 RID: 3145 RVA: 0x0003A1EC File Offset: 0x000383EC
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorManipulacionDeBone estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 10f, num4).OutPow(3f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0003A283 File Offset: 0x00038483
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

		// Token: 0x06000C4B RID: 3147 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x040008C6 RID: 2246
		private ConsentToHero m_ConcentToHero;

		// Token: 0x040008C7 RID: 2247
		private Arousal m_arousal;

		// Token: 0x040008C8 RID: 2248
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040008C9 RID: 2249
		private ConsentCorrupted m_ConsentForzado;
	}
}
