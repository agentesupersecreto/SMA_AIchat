using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public class UnityUIQuestTemplateAlternateDescriptions
	{
		// Token: 0x06000140 RID: 320 RVA: 0x0000775A File Offset: 0x0000595A
		public void SetActive(bool value)
		{
			if (this.successDescription != null)
			{
				this.successDescription.gameObject.SetActive(value);
			}
			if (this.failureDescription != null)
			{
				this.failureDescription.gameObject.SetActive(value);
			}
		}

		// Token: 0x040000F4 RID: 244
		[Tooltip("(Optional) If set, use if state is success")]
		public Text successDescription;

		// Token: 0x040000F5 RID: 245
		[Tooltip("(Optional) If set, use if state is failure")]
		public Text failureDescription;
	}
}
