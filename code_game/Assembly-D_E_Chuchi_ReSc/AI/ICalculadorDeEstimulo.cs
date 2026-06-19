using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002CF RID: 719
	public interface ICalculadorDeEstimulo : IComponentAwakeable
	{
		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600102C RID: 4140
		bool isActiveAndEnabled { get; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600102D RID: 4141
		// (set) Token: 0x0600102E RID: 4142
		bool enabled { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x0600102F RID: 4143
		string name { get; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06001030 RID: 4144
		TipoDeCalculadorDeEstimulo tipo { get; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06001031 RID: 4145
		Emocion emo { get; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06001032 RID: 4146
		double prioridad { get; }
	}
}
