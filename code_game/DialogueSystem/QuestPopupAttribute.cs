using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002AE RID: 686
	public class QuestPopupAttribute : PropertyAttribute
	{
		// Token: 0x06001CD0 RID: 7376 RVA: 0x0003616C File Offset: 0x0003436C
		public QuestPopupAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x0400105F RID: 4191
		public bool showReferenceDatabase;
	}
}
