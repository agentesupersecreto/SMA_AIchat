using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D2 RID: 722
	[Obsolete("nunca lo use", true)]
	public interface ICalculadorDeEstimuloReaccionable : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600103C RID: 4156
		// (set) Token: 0x0600103D RID: 4157
		bool reaccionable { get; set; }
	}
}
