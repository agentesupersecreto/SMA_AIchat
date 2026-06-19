using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000300 RID: 768
	public interface ICharPeticionDesvestiduraInformer
	{
		// Token: 0x060010CC RID: 4300
		void EstimulosRecibidosDe(Character productor, ICharDesvestiduraInformerInstanceGetter<EstimuloPorDesvestir> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> result);
	}
}
