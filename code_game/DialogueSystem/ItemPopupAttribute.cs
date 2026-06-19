using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002AD RID: 685
	public class ItemPopupAttribute : PropertyAttribute
	{
		// Token: 0x06001CCF RID: 7375 RVA: 0x0003615C File Offset: 0x0003435C
		public ItemPopupAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x0400105E RID: 4190
		public bool showReferenceDatabase;
	}
}
