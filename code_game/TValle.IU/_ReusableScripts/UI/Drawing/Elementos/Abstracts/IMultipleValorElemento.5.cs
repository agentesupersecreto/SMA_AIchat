using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A2 RID: 162
	public interface IMultipleValorElemento<T1, T2, T3, T4, T5> : IMultipleValorElemento<T1, T2, T3, T4>, IMultipleValorElemento<T1, T2, T3>, IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600050E RID: 1294
		T5 item5 { get; }
	}
}
