using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002CC RID: 716
	public interface ICalculadorDeEstimuloIgnoradorEnPartesHumanas : ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001026 RID: 4134
		void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar);
	}
}
