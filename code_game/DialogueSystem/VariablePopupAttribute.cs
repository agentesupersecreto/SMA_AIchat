using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002B0 RID: 688
	public class VariablePopupAttribute : PropertyAttribute
	{
		// Token: 0x06001CD2 RID: 7378 RVA: 0x00036184 File Offset: 0x00034384
		public VariablePopupAttribute(bool showReferenceDatabase = false)
		{
			this.showReferenceDatabase = showReferenceDatabase;
		}

		// Token: 0x04001060 RID: 4192
		public bool showReferenceDatabase;
	}
}
