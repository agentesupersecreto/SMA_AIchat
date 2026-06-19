using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200002B RID: 43
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questLogWindowUnityUI")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Quest/Unity UI Quest Group Template")]
	public class UnityUIQuestGroupTemplate : MonoBehaviour
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000678C File Offset: 0x0000498C
		public bool ArePropertiesAssigned
		{
			get
			{
				return this.heading != null;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000679A File Offset: 0x0000499A
		public void Initialize()
		{
		}

		// Token: 0x040000D2 RID: 210
		[Header("Quest Group Heading")]
		[Tooltip("The quest group name")]
		public Text heading;
	}
}
