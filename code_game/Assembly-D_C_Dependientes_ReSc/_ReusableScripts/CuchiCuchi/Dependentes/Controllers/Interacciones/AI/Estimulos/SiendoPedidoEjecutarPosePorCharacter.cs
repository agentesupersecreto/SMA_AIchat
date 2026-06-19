using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001DF RID: 479
	public sealed class SiendoPedidoEjecutarPosePorCharacter : SiendoCambiadoDePosePorCharacter<PeticionEstadoDeInteraccionesConAI>
	{
		// Token: 0x06000B6F RID: 2927 RVA: 0x0003804D File Offset: 0x0003624D
		public SiendoPedidoEjecutarPosePorCharacter(PeticionEstadoDeInteraccionesConAI estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override EstimuloPorCambiarPose.Estado paraEstado
		{
			get
			{
				return EstimuloPorCambiarPose.Estado.ejecutada;
			}
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool DataEsValida(ref CambioDePoseData data)
		{
			return true;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00027012 File Offset: 0x00025212
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.peticionEjecucionDePose;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x00038057 File Offset: 0x00036257
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaComunicarse;
		}
	}
}
