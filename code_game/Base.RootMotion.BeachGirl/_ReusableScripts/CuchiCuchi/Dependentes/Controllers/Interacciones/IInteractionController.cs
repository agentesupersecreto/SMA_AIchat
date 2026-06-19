using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E2 RID: 226
	public interface IInteractionController
	{
		// Token: 0x06000843 RID: 2115
		bool TryGetFreeNotLockedHand(out Side handSide, out FullBodyBipedEffector handEffector);

		// Token: 0x06000844 RID: 2116
		bool AreBothHandsFree();

		// Token: 0x06000845 RID: 2117
		bool IsLHandsFree();

		// Token: 0x06000846 RID: 2118
		bool IsRHandsFree();

		// Token: 0x06000847 RID: 2119
		[Obsolete("", true)]
		bool IsFijaPorAnimacionEnLayers(FullBodyBipedEffector fullBodyBipedEffector, int layerMinimo, int layerMaximo = 2147483647, bool OApoyando = true);

		// Token: 0x06000848 RID: 2120
		bool IsFijaPorAnimacionEnLayers(FullBodyBipedEffector fullBodyBipedEffector, IKLayerFlag paraFlags, bool OApoyando = true);

		// Token: 0x06000849 RID: 2121
		bool PuedeTrasladarse(FullBodyBipedEffector fullBodyBipedEffector);

		// Token: 0x0600084A RID: 2122
		bool PuedeApoyarse(FullBodyBipedEffector fullBodyBipedEffector, bool esExtencion);

		// Token: 0x0600084B RID: 2123
		[Obsolete("", true)]
		bool InteractuandoEnLayers(FullBodyBipedEffector fullBodyBipedEffector, int layerMinimo, int layerMaximo = 2147483647);

		// Token: 0x0600084C RID: 2124
		bool InteractuandoEnLayers(FullBodyBipedEffector fullBodyBipedEffector, IKLayerFlag paraFlags);

		// Token: 0x0600084D RID: 2125
		void ObtenerEjecutandose(FullBodyBipedEffector fullBodyBipedEffector, int layer, IList<IInteractionOrden> result);

		// Token: 0x0600084E RID: 2126
		bool InteractuarTodos(InteraccionEstado estado, bool terminarDeInmediato, InteractionCallBackHandler justBeforeEjecucionCallBack = null);

		// Token: 0x0600084F RID: 2127
		bool AlgunaEstaInteractuando(InteraccionInfo datos, int layer);

		// Token: 0x06000850 RID: 2128
		[Obsolete("Usar el detener de la interaccion")]
		void DetenerInteracciones(InteraccionInfo info, int layer);
	}
}
