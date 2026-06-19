using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E1 RID: 481
	public sealed class SiendoCambiadoEjecutarPosePorCharacterConVoz : SiendoCambiadoDePosePorCharacter<CambiarEstadoDeInteraccionesConAI>
	{
		// Token: 0x06000B79 RID: 2937 RVA: 0x0003805F File Offset: 0x0003625F
		public SiendoCambiadoEjecutarPosePorCharacterConVoz(CambiarEstadoDeInteraccionesConAI estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override EstimuloPorCambiarPose.Estado paraEstado
		{
			get
			{
				return EstimuloPorCambiarPose.Estado.ejecutada;
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0003807C File Offset: 0x0003627C
		protected override bool DataEsValida(ref CambioDePoseData data)
		{
			return data.estimulante == ParteQuePuedeEstimular.boca;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x00026DED File Offset: 0x00024FED
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.ejecucionDePose;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x00038057 File Offset: 0x00036257
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaComunicarse;
		}
	}
}
