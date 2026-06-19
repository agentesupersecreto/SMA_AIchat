using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000050 RID: 80
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/usable.html")]
	[AddComponentMenu("Dialogue System/Actor/Usable")]
	public class Usable : MonoBehaviour
	{
		// Token: 0x0600025A RID: 602 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		public string GetName()
		{
			if (string.IsNullOrEmpty(this.overrideName))
			{
				return base.name;
			}
			if (this.overrideName.Contains("[lua") || this.overrideName.Contains("[var"))
			{
				return FormattedText.Parse(this.overrideName, DialogueManager.MasterDatabase.emphasisSettings).text;
			}
			return this.overrideName;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public virtual void Start()
		{
			if (string.IsNullOrEmpty(this.overrideName))
			{
				OverrideActorName componentInChildren = base.GetComponentInChildren<OverrideActorName>();
				if (componentInChildren != null)
				{
					this.overrideName = componentInChildren.overrideName;
				}
			}
		}

		// Token: 0x040001F8 RID: 504
		public string overrideName;

		// Token: 0x040001F9 RID: 505
		public string overrideUseMessage;

		// Token: 0x040001FA RID: 506
		public float maxUseDistance = 5f;
	}
}
