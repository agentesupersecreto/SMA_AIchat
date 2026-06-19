using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001CD RID: 461
	public interface ICharPeticionDeCambioDePoseInformer
	{
		// Token: 0x06000AEB RID: 2795
		void EstimulosRecibidosDe(Character productor, ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> result);
	}
}
