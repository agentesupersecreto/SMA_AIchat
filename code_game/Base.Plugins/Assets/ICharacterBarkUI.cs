using System;
using UnityEngine.UI;

namespace Assets
{
	// Token: 0x020000AA RID: 170
	public interface ICharacterBarkUI
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000503 RID: 1283
		Text barkText { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000504 RID: 1284
		Text nameText { get; }

		// Token: 0x06000505 RID: 1285
		bool ShouldShowText();

		// Token: 0x06000506 RID: 1286
		void Hide();

		// Token: 0x06000507 RID: 1287
		bool BarkPermanente(string subtitle, string speakerName = "NONE");
	}
}
