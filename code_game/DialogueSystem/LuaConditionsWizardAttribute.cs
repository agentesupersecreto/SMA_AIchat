using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200025B RID: 603
	public class LuaConditionsWizardAttribute : PropertyAttribute
	{
		// Token: 0x06001A22 RID: 6690 RVA: 0x0002C498 File Offset: 0x0002A698
		public LuaConditionsWizardAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x04000EF2 RID: 3826
		public bool showReferenceDatabase;
	}
}
