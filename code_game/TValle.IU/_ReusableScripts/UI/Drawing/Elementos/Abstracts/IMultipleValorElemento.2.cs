using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x0200009F RID: 159
	public interface IMultipleValorElemento<T1, T2> : IMultipleValorElemento<T1>
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600050B RID: 1291
		T2 item2 { get; }
	}
}
