using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001CC RID: 460
	public interface ICharCambioDePoseInformer
	{
		// Token: 0x06000AEA RID: 2794
		void EstimulosRecibidosDe(Character productor, ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> result);
	}
}
