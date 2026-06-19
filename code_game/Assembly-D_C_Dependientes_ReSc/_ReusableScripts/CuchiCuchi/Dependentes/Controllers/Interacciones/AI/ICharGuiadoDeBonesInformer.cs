using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001CF RID: 463
	public interface ICharGuiadoDeBonesInformer
	{
		// Token: 0x06000AF0 RID: 2800
		void EstimulosRecibidosDe(Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result);
	}
}
