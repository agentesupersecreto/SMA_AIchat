using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A7 RID: 167
	public interface IUIElementoActivable : IUIElemento, IUIElementoRefreshable
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000515 RID: 1301
		bool isActivated { get; }

		// Token: 0x1700019A RID: 410
		// (set) Token: 0x06000516 RID: 1302
		bool activatedInitialState { set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000517 RID: 1303
		// (set) Token: 0x06000518 RID: 1304
		IReadOnlyList<Func<bool>> canBeActivatedDelegates { get; set; }
	}
}
