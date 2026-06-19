using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales.DeDecepcion
{
	// Token: 0x020004D6 RID: 1238
	public class SesionGeneralDeDecepcionCoitalAnchura : SessionGeneral<DecepcionPorPenetracionAnchura, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura, SesionGeneralDeDecepcionCoitalAnchura, SesionGeneralDeDecepcionCoitalAnchura.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital>
	{
		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06001D25 RID: 7461 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06001D26 RID: 7462 RVA: 0x00071D2B File Offset: 0x0006FF2B
		public override TipoDeEstimuloCoital tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D27 RID: 7463 RVA: 0x00071D33 File Offset: 0x0006FF33
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloCoital enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculo)
		{
			return calculo.estimulo.tipoDeEstimuloCoital == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001D28 RID: 7464 RVA: 0x00071D53 File Offset: 0x0006FF53
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001D29 RID: 7465 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D2A RID: 7466 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001408 RID: 5128
		[SerializeField]
		private TipoDeEstimuloCoital m_paraTipo;

		// Token: 0x020004D7 RID: 1239
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<DecepcionPorPenetracionAnchura, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura, SesionGeneralDeDecepcionCoitalAnchura, SesionGeneralDeDecepcionCoitalAnchura.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
