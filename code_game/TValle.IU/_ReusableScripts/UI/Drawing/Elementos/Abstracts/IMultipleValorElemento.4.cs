using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A1 RID: 161
	public interface IMultipleValorElemento<T1, T2, T3, T4> : IMultipleValorElemento<T1, T2, T3>, IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600050D RID: 1293
		T4 item4 { get; }
	}
}
