using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A6 RID: 166
	public interface IUIElementoConExtraData : IUIElemento
	{
		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000513 RID: 1299
		// (set) Token: 0x06000514 RID: 1300
		IReadOnlyList<Func<object>> extradata { get; set; }
	}
}
