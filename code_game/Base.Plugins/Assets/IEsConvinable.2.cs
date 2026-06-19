using System;

namespace Assets
{
	// Token: 0x020000D0 RID: 208
	public interface IEsConvinable<T> where T : class
	{
		// Token: 0x06000608 RID: 1544
		bool Convinable(T other);
	}
}
