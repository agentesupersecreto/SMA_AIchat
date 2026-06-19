using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales.DeDecepcion
{
	// Token: 0x020004D8 RID: 1240
	public class SesionGeneralDeDecepcionCoitalProfunda : SessionGeneral<DecepcionPorPenetracionProfundidad, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda, SesionGeneralDeDecepcionCoitalProfunda, SesionGeneralDeDecepcionCoitalProfunda.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital>
	{
		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x06001D2E RID: 7470 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x06001D2F RID: 7471 RVA: 0x00071D71 File Offset: 0x0006FF71
		public override TipoDeEstimuloCoital tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D30 RID: 7472 RVA: 0x00071D33 File Offset: 0x0006FF33
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloCoital enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculo)
		{
			return calculo.estimulo.tipoDeEstimuloCoital == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x00071D79 File Offset: 0x0006FF79
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001409 RID: 5129
		[SerializeField]
		private TipoDeEstimuloCoital m_paraTipo;

		// Token: 0x020004D9 RID: 1241
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<DecepcionPorPenetracionProfundidad, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda, SesionGeneralDeDecepcionCoitalProfunda, SesionGeneralDeDecepcionCoitalProfunda.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
