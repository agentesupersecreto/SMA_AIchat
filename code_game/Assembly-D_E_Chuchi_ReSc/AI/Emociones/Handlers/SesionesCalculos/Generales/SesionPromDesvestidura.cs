using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004D0 RID: 1232
	public class SesionPromDesvestidura : SessionGeneralProm<FearPorDesHielo, SesionPromDesvestidura, SesionPromDesvestidura.Resultado, int>
	{
		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06001D09 RID: 7433 RVA: 0x00004252 File Offset: 0x00002452
		public override int tipoDeEstimuloSegundario
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x00071B98 File Offset: 0x0006FD98
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x00071C62 File Offset: 0x0006FE62
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloPorDesvestir && (calculo as ICalculoDeEstimuloPorDesvestir).estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.desvestidura;
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool CalculoEsDeTipoEnumerable(int tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return true;
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020004D1 RID: 1233
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromDesvestidura, SesionPromDesvestidura.Resultado, int>.ResultadoDeSession
		{
		}
	}
}
