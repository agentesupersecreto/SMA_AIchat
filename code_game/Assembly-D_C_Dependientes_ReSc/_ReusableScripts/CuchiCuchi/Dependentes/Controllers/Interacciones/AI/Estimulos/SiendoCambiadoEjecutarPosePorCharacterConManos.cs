using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E0 RID: 480
	public sealed class SiendoCambiadoEjecutarPosePorCharacterConManos : SiendoCambiadoDePosePorCharacter<CambiarEstadoDeInteraccionesConAI>
	{
		// Token: 0x06000B74 RID: 2932 RVA: 0x0003805F File Offset: 0x0003625F
		public SiendoCambiadoEjecutarPosePorCharacterConManos(CambiarEstadoDeInteraccionesConAI estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override EstimuloPorCambiarPose.Estado paraEstado
		{
			get
			{
				return EstimuloPorCambiarPose.Estado.ejecutada;
			}
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x00038069 File Offset: 0x00036269
		protected override bool DataEsValida(ref CambioDePoseData data)
		{
			return data.estimulante == ParteQuePuedeEstimular.manos;
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x00026DED File Offset: 0x00024FED
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.ejecucionDePose;
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x00038074 File Offset: 0x00036274
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaManipular;
		}
	}
}
