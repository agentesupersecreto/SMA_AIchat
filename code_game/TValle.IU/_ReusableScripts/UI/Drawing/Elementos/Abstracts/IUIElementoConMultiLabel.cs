using System;
using System.Collections.Generic;
using TMPro;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000B1 RID: 177
	public interface IUIElementoConMultiLabel : IUIElemento
	{
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000524 RID: 1316
		IReadOnlyList<TextMeshProUGUI> labels { get; }
	}
}
