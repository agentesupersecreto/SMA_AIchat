using System;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers
{
	// Token: 0x020001EC RID: 492
	public class DolorPorEjecucionDePose : CalculoDeEmocionesPorEjecutarDePose
	{
		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00023905 File Offset: 0x00021B05
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0003915A File Offset: 0x0003735A
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Caricias.porCaricias;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00039176 File Offset: 0x00037376
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0003918D File Offset: 0x0003738D
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x000391A4 File Offset: 0x000373A4
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Dolor;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x000391AF File Offset: 0x000373AF
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DolorPorToques = this.GetComponentEnRoot(false);
			if (this.m_DolorPorToques == null)
			{
				throw new ArgumentNullException("m_DolorPorToques", "m_DolorPorToques null reference.");
			}
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x000391E2 File Offset: 0x000373E2
		protected override bool EstimuloEsValido(ParteQuePuedeEstimular estimulanteParte, EstimuloPorCambiarPose estimulo)
		{
			return base.EstimuloEsValido(estimulanteParte, estimulo) && ParteQuePuedeEstimularHelper.puedenManipularSet.Contains((int)estimulanteParte);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x000391FC File Offset: 0x000373FC
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorCambiarPose estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues? emocionesFemeninasValues = null;
			this.m_DolorPorToques.ModificarUmbralesDeCalculo(parteEstimulante, parteEstimulada, estimulo, ref cambio, ref intervalo, ref estimulacionGenerada, ref emocionesFemeninasValues);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x040008B4 RID: 2228
		private DolorPorToques m_DolorPorToques;
	}
}
