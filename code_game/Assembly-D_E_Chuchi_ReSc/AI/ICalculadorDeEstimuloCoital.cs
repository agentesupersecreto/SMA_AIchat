using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002DD RID: 733
	public interface ICalculadorDeEstimuloCoital : ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001062 RID: 4194
		[Obsolete("", true)]
		ICalculoDeEstimuloCoital GetCalculos();
	}
}
