using System;

namespace Assets
{
	// Token: 0x020000D3 RID: 211
	public interface IConvinable<T> : IEsConvinable<T> where T : class
	{
		// Token: 0x0600060B RID: 1547
		void Convinar(T other);
	}
}
