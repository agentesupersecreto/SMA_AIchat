using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020001F6 RID: 502
	public class SesionGeneralGuiaDeBones : SessionGeneral<CalculoDeEmocionesPorGuiaDeBones, CalculoDeEmocionesPorMovimientoDeBonesResultado, SesionGeneralGuiaDeBones, SesionGeneralGuiaDeBones.Resultado, EstimuloPorManipulacionDeBone, int>
	{
		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int tipoDeEstimuloEnumerableV2
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x0003A468 File Offset: 0x00038668
		protected override bool CalculoEsDeTipoEnumerable(int enumerable, DireccionDeEstimulo direccion, CalculoDeEmocionesPorMovimientoDeBonesResultado calculo)
		{
			return enumerable == 0 && calculo.estimuloBasico.tipo == direccion;
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x0003A47D File Offset: 0x0003867D
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020001F7 RID: 503
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEmocionesPorGuiaDeBones, CalculoDeEmocionesPorMovimientoDeBonesResultado, SesionGeneralGuiaDeBones, SesionGeneralGuiaDeBones.Resultado, EstimuloPorManipulacionDeBone, int, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
