using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200030A RID: 778
	public interface ICharVisionInformer
	{
		// Token: 0x060010F7 RID: 4343
		void EstimulosRecibidosPor(ICharacter productor, Func<EstimuloVisual> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> result, IList<EstimuloVisual> resultList);

		// Token: 0x060010F8 RID: 4344
		void EstimulosDadoA(ICharacter productor, Func<EstimuloVisual> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> result);
	}
}
