using System;

namespace Assets
{
	// Token: 0x020000D6 RID: 214
	public interface IConvinableInterval<T> : IEsConvinable<T> where T : class
	{
		// Token: 0x0600060E RID: 1550
		void ConvinarInterval(T other, float coolDown);
	}
}
