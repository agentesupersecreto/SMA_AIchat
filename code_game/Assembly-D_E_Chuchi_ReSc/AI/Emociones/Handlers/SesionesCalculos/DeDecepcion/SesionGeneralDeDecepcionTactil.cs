using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.DeDecepcion
{
	// Token: 0x020004DC RID: 1244
	public sealed class SesionGeneralDeDecepcionTactil : SessionGeneral<DecepcionPorToques, CalculoDeEstimuloPorCariciasResultado, SesionGeneralDeDecepcionTactil, SesionGeneralDeDecepcionTactil.Resultado, EstimuloTactil, TipoDeEstimuloTactil>
	{
		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06001D40 RID: 7488 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06001D41 RID: 7489 RVA: 0x00071DBD File Offset: 0x0006FFBD
		public override TipoDeEstimuloTactil tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D42 RID: 7490 RVA: 0x00071ACF File Offset: 0x0006FCCF
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloTactil enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorCariciasResultado calculo)
		{
			return calculo.estimulo.tipoDeEstimuloTactil == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x00071DC5 File Offset: 0x0006FFC5
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001D44 RID: 7492 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x0400140B RID: 5131
		[SerializeField]
		private TipoDeEstimuloTactil m_paraTipo;

		// Token: 0x020004DD RID: 1245
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<DecepcionPorToques, CalculoDeEstimuloPorCariciasResultado, SesionGeneralDeDecepcionTactil, SesionGeneralDeDecepcionTactil.Resultado, EstimuloTactil, TipoDeEstimuloTactil, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
