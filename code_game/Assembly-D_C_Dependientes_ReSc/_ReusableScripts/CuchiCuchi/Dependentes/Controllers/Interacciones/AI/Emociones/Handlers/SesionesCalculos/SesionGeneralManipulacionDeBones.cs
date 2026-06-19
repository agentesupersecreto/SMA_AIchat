using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020001F8 RID: 504
	public class SesionGeneralManipulacionDeBones : SessionGeneral<CalculoDeEmocionesPorManipulacionDeBones, CalculoDeEmocionesPorMovimientoDeBonesResultado, SesionGeneralManipulacionDeBones, SesionGeneralManipulacionDeBones.Resultado, EstimuloPorManipulacionDeBone, int>
	{
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int tipoDeEstimuloEnumerableV2
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0003A468 File Offset: 0x00038668
		protected override bool CalculoEsDeTipoEnumerable(int enumerable, DireccionDeEstimulo direccion, CalculoDeEmocionesPorMovimientoDeBonesResultado calculo)
		{
			return enumerable == 0 && calculo.estimuloBasico.tipo == direccion;
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x0003A47D File Offset: 0x0003867D
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x020001F9 RID: 505
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEmocionesPorManipulacionDeBones, CalculoDeEmocionesPorMovimientoDeBonesResultado, SesionGeneralManipulacionDeBones, SesionGeneralManipulacionDeBones.Resultado, EstimuloPorManipulacionDeBone, int, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
