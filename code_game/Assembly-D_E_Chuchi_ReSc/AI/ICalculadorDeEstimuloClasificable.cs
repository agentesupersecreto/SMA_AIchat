using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002CE RID: 718
	public interface ICalculadorDeEstimuloClasificable : ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06001028 RID: 4136
		DireccionDeEstimulo direccionDeEstimulo { get; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001029 RID: 4137
		TipoDeEstimulo tipoDeEstimulo { get; }

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600102A RID: 4138
		ReaccionHumana reaccion { get; }

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600102B RID: 4139
		bool esGolpe { get; }
	}
}
