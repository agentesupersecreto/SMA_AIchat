using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A0 RID: 160
	public interface IMultipleValorElemento<T1, T2, T3> : IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600050C RID: 1292
		T3 item3 { get; }
	}
}
