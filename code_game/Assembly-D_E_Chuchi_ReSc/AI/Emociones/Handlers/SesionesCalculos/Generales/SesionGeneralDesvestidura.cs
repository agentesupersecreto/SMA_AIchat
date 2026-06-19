using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004C3 RID: 1219
	public class SesionGeneralDesvestidura : SessionGeneral<CalculoDeEmocionesPorSerDesvestido, CalculoDeEstimuloDesvestidoResultado, SesionGeneralDesvestidura, SesionGeneralDesvestidura.Resultado, EstimuloPorDesvestir, int>
	{
		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06001CDB RID: 7387 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06001CDC RID: 7388 RVA: 0x00004252 File Offset: 0x00002452
		public override int tipoDeEstimuloEnumerableV2
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06001CDD RID: 7389 RVA: 0x00071B83 File Offset: 0x0006FD83
		protected override bool CalculoEsDeTipoEnumerable(int enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloDesvestidoResultado calculo)
		{
			return enumerable == 0 && calculo.estimuloBasico.tipo == direccion;
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x00071B98 File Offset: 0x0006FD98
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020004C4 RID: 1220
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEmocionesPorSerDesvestido, CalculoDeEstimuloDesvestidoResultado, SesionGeneralDesvestidura, SesionGeneralDesvestidura.Resultado, EstimuloPorDesvestir, int, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
