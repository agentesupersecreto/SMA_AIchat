using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.DeDecepcion
{
	// Token: 0x020004DA RID: 1242
	public sealed class SesionGeneralDeDecepcionCoital : SessionGeneral<DecepcionPorPenetraciones, CalculoDeEstimuloPorPenetracionHoleResultadoSimple, SesionGeneralDeDecepcionCoital, SesionGeneralDeDecepcionCoital.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital>
	{
		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x06001D37 RID: 7479 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06001D38 RID: 7480 RVA: 0x00071D97 File Offset: 0x0006FF97
		public override TipoDeEstimuloCoital tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x00071D33 File Offset: 0x0006FF33
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloCoital enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculo)
		{
			return calculo.estimulo.tipoDeEstimuloCoital == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001D3A RID: 7482 RVA: 0x00071D9F File Offset: 0x0006FF9F
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001D3B RID: 7483 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D3D RID: 7485 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x0400140A RID: 5130
		[SerializeField]
		private TipoDeEstimuloCoital m_paraTipo;

		// Token: 0x020004DB RID: 1243
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<DecepcionPorPenetraciones, CalculoDeEstimuloPorPenetracionHoleResultadoSimple, SesionGeneralDeDecepcionCoital, SesionGeneralDeDecepcionCoital.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
