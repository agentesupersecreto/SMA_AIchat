using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004D4 RID: 1236
	public class SesionPromVisual : SessionGeneralProm<FearPorDesHielo, SesionPromVisual, SesionPromVisual.Resultado, TipoDeEstimuloVisual>
	{
		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06001D1B RID: 7451 RVA: 0x00071CE0 File Offset: 0x0006FEE0
		public override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return this.m_direccion;
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x06001D1C RID: 7452 RVA: 0x00071CE8 File Offset: 0x0006FEE8
		public override TipoDeEstimuloVisual tipoDeEstimuloSegundario
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x00071B98 File Offset: 0x0006FD98
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06001D1E RID: 7454 RVA: 0x00071CF0 File Offset: 0x0006FEF0
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloVisual;
		}

		// Token: 0x06001D1F RID: 7455 RVA: 0x00071D06 File Offset: 0x0006FF06
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloVisual tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return (calculo as ICalculoDeEstimuloVisual).estimulo.tipoDeEstimuloVisual == tipoDeEstimuloSegundario;
		}

		// Token: 0x06001D20 RID: 7456 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D21 RID: 7457 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001406 RID: 5126
		[SerializeField]
		private TipoDeEstimuloVisual m_paraTipo;

		// Token: 0x04001407 RID: 5127
		[SerializeField]
		private DireccionDeEstimulo m_direccion;

		// Token: 0x020004D5 RID: 1237
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromVisual, SesionPromVisual.Resultado, TipoDeEstimuloVisual>.ResultadoDeSession
		{
		}
	}
}
