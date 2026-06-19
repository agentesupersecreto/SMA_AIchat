using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020001FA RID: 506
	public class SesionPromGuiaDeBones : SessionGeneralProm<FearPorDesHielo, SesionPromGuiaDeBones, SesionPromGuiaDeBones.Resultado, int>
	{
		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int tipoDeEstimuloSegundario
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0003A47D File Offset: 0x0003867D
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0003A4A8 File Offset: 0x000386A8
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloPorMovimientoDeBones && (calculo as ICalculoDeEstimuloPorMovimientoDeBones).estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.guiandoBone;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool CalculoEsDeTipoEnumerable(int tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return true;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020001FB RID: 507
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromGuiaDeBones, SesionPromGuiaDeBones.Resultado, int>.ResultadoDeSession
		{
		}
	}
}
