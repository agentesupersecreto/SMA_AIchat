using System;

namespace Assets
{
	// Token: 0x020000D1 RID: 209
	public interface IEsConvinableValue<T> where T : struct
	{
		// Token: 0x06000609 RID: 1545
		bool Convinable(ref T other);
	}
}
