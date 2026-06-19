using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004D2 RID: 1234
	public class SesionPromTactil : SessionGeneralProm<FearPorDesHielo, SesionPromTactil, SesionPromTactil.Resultado, TipoDeEstimuloTactil>
	{
		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06001D12 RID: 7442 RVA: 0x00071C9D File Offset: 0x0006FE9D
		public override TipoDeEstimuloTactil tipoDeEstimuloSegundario
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D13 RID: 7443 RVA: 0x00071B98 File Offset: 0x0006FD98
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x00071CA5 File Offset: 0x0006FEA5
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloTactil;
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x00071CBB File Offset: 0x0006FEBB
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloTactil tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return (calculo as ICalculoDeEstimuloTactil).estimulo.tipoDeEstimuloTactil == tipoDeEstimuloSegundario;
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001405 RID: 5125
		[SerializeField]
		private TipoDeEstimuloTactil m_paraTipo;

		// Token: 0x020004D3 RID: 1235
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromTactil, SesionPromTactil.Resultado, TipoDeEstimuloTactil>.ResultadoDeSession
		{
		}
	}
}
