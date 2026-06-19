using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002FF RID: 767
	public interface ICharDesvestiduraInformer
	{
		// Token: 0x060010CB RID: 4299
		void EstimulosRecibidosDe(Character productor, ICharDesvestiduraInformerInstanceGetter<EstimuloPorDesvestir> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> result);
	}
}
