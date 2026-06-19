using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000B7 RID: 183
	public interface IUIElementoConfirmable : IUIElemento
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000531 RID: 1329
		// (set) Token: 0x06000532 RID: 1330
		bool confirmar { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000533 RID: 1331
		// (set) Token: 0x06000534 RID: 1332
		ConfirmacionHandler confirmarDelegate { get; set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000535 RID: 1333
		// (set) Token: 0x06000536 RID: 1334
		string confirmarText { get; set; }
	}
}
