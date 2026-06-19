using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002AB RID: 683
	public class ConversationPopupAttribute : PropertyAttribute
	{
		// Token: 0x06001CCD RID: 7373 RVA: 0x00036144 File Offset: 0x00034344
		public ConversationPopupAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x0400105D RID: 4189
		public bool showReferenceDatabase;
	}
}
