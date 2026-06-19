using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000428 RID: 1064
	public sealed class RagePorPeticionDesvestidirPorMain : CalculoDeEmocionesPorPeticionDesvestidura
	{
		// Token: 0x060017AA RID: 6058 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x060017AB RID: 6059 RVA: 0x00030684 File Offset: 0x0002E884
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x0005FE97 File Offset: 0x0005E097
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Desvestidura.porSiMismo;
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x060017AD RID: 6061 RVA: 0x0005FEB3 File Offset: 0x0005E0B3
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x060017AF RID: 6063 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x0005FEEC File Offset: 0x0005E0EC
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
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x0005FFB4 File Offset: 0x0005E1B4
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorDesvestir estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 20f, num4).OutPow(2f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x0006004C File Offset: 0x0005E24C
		protected override bool MaximoAlcanzado(CalculoDeEstimuloDesvestidoResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
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

		// Token: 0x060017B5 RID: 6069 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x0400121E RID: 4638
		private ConsentToHero m_ConcentToHero;

		// Token: 0x0400121F RID: 4639
		private Arousal m_arousal;

		// Token: 0x04001220 RID: 4640
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x04001221 RID: 4641
		private ConsentCorrupted m_ConsentForzado;
	}
}
