using System;

namespace Assets
{
	// Token: 0x020000D4 RID: 212
	public interface IConvinableValue<T> : IEsConvinableValue<T> where T : struct
	{
		// Token: 0x0600060C RID: 1548
		void Convinar(ref T other);
	}
}
