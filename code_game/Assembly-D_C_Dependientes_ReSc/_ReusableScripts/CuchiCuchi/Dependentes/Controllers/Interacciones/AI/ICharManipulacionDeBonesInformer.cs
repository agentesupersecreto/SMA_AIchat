using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D0 RID: 464
	public interface ICharManipulacionDeBonesInformer
	{
		// Token: 0x06000AF1 RID: 2801
		void EstimulosRecibidosDe(Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result);
	}
}
