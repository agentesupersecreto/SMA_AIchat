using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004CA RID: 1226
	public class SesionGeneralVisualDada : SessionGeneral<CalculoDeEstimuloPorVerPartesMasculinas<CalculoDeEstimuloVisualResultado>, CalculoDeEstimuloVisualResultado, SesionGeneralVisualDada, SesionGeneralVisualDada.Resultado, EstimuloVisual, TipoDeEstimuloVisual>
	{
		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x06001CF5 RID: 7413 RVA: 0x00005F51 File Offset: 0x00004151
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.dada;
			}
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x06001CF6 RID: 7414 RVA: 0x00071BF9 File Offset: 0x0006FDF9
		public override TipoDeEstimuloVisual tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x00071BBB File Offset: 0x0006FDBB
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloVisual enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloVisualResultado calculo)
		{
			return calculo.estimulo.tipoDeEstimuloVisual == enumerable && calculo.estimuloBasico.tipo == direccion;
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x00071C01 File Offset: 0x0006FE01
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001403 RID: 5123
		[SerializeField]
		private TipoDeEstimuloVisual m_paraTipo;

		// Token: 0x020004CB RID: 1227
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEstimuloPorVerPartesMasculinas<CalculoDeEstimuloVisualResultado>, CalculoDeEstimuloVisualResultado, SesionGeneralVisualDada, SesionGeneralVisualDada.Resultado, EstimuloVisual, TipoDeEstimuloVisual, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
