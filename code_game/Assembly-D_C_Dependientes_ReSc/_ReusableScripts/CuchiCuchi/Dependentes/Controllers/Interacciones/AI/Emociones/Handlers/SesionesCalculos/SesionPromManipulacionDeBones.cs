using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020001FC RID: 508
	public class SesionPromManipulacionDeBones : SessionGeneralProm<FearPorDesHielo, SesionPromManipulacionDeBones, SesionPromManipulacionDeBones.Resultado, int>
	{
		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000C78 RID: 3192 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int tipoDeEstimuloSegundario
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0003A47D File Offset: 0x0003867D
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0003A4E3 File Offset: 0x000386E3
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloPorMovimientoDeBones && (calculo as ICalculoDeEstimuloPorMovimientoDeBones).estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.manipulandoBone;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool CalculoEsDeTipoEnumerable(int tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return true;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020001FD RID: 509
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromManipulacionDeBones, SesionPromManipulacionDeBones.Resultado, int>.ResultadoDeSession
		{
		}
	}
}
