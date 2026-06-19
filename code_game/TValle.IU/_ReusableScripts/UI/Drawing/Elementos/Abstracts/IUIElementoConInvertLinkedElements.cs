using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A3 RID: 163
	public interface IUIElementoConInvertLinkedElements : IUIElemento
	{
		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600050F RID: 1295
		// (set) Token: 0x06000510 RID: 1296
		IReadOnlyList<IUIElemento> InvertLinked { get; set; }
	}
}
