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
	// Token: 0x020001ED RID: 493
	public sealed class DolorPorManipulacionDeBones : CalculoDeEmocionesPorManipulacionDeBones
	{
		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x00023905 File Offset: 0x00021B05
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x00039176 File Offset: 0x00037376
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0003918D File Offset: 0x0003738D
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x0003915A File Offset: 0x0003735A
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Caricias.porCaricias;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00023ABA File Offset: 0x00021CBA
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x000391A4 File Offset: 0x000373A4
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Dolor;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0003922F File Offset: 0x0003742F
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DolorPorToques = this.GetComponentEnRoot(false);
			if (this.m_DolorPorToques == null)
			{
				throw new ArgumentNullException("m_DolorPorToques", "m_DolorPorToques null reference.");
			}
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00039262 File Offset: 0x00037462
		protected override bool EstimuloEsValido(ParteQuePuedeEstimular estimulanteParte, EstimuloPorManipulacionDeBone estimulo)
		{
			return base.EstimuloEsValido(estimulanteParte, estimulo) && ParteQuePuedeEstimularHelper.puedenManipularSet.Contains((int)estimulanteParte);
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0003927C File Offset: 0x0003747C
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorManipulacionDeBone estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues? emocionesFemeninasValues = null;
			this.m_DolorPorToques.ModificarUmbralesDeCalculo(parteEstimulante, parteEstimulada, estimulo, ref cambio, ref intervalo, ref estimulacionGenerada, ref emocionesFemeninasValues);
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x040008B5 RID: 2229
		private DolorPorToques m_DolorPorToques;
	}
}
