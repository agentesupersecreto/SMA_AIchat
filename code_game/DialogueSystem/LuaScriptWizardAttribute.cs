using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200025C RID: 604
	public class LuaScriptWizardAttribute : PropertyAttribute
	{
		// Token: 0x06001A23 RID: 6691 RVA: 0x0002C4A8 File Offset: 0x0002A6A8
		public LuaScriptWizardAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x04000EF3 RID: 3827
		public bool showReferenceDatabase;
	}
}
