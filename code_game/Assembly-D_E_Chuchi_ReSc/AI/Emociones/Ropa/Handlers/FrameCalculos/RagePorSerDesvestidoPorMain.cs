using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000429 RID: 1065
	public sealed class RagePorSerDesvestidoPorMain : CalculoDeEmocionesPorSerDesvestido
	{
		// Token: 0x060017B8 RID: 6072 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x060017B9 RID: 6073 RVA: 0x00030684 File Offset: 0x0002E884
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x00060080 File Offset: 0x0005E280
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Desvestidura.PorOtros;
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x060017BB RID: 6075 RVA: 0x0005FEB3 File Offset: 0x0005E0B3
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060017BD RID: 6077 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x0006009C File Offset: 0x0005E29C
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

		// Token: 0x060017C1 RID: 6081 RVA: 0x00060164 File Offset: 0x0005E364
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorDesvestir estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesFemeninasValues.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 10f, num4).OutPow(3f);
			estimulacionGenerada.moded *= num5;
		}

		// Token: 0x060017C2 RID: 6082 RVA: 0x000601FC File Offset: 0x0005E3FC
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

		// Token: 0x060017C3 RID: 6083 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x04001222 RID: 4642
		private ConsentToHero m_ConcentToHero;

		// Token: 0x04001223 RID: 4643
		private Arousal m_arousal;

		// Token: 0x04001224 RID: 4644
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x04001225 RID: 4645
		private ConsentCorrupted m_ConsentForzado;
	}
}
