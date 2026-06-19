using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001A RID: 26
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Bark Subtitle Dialogue UI")]
	public class UnityUIBarkSubtitleDialogueUI : UnityUIDialogueUI
	{
		// Token: 0x0600006A RID: 106 RVA: 0x000035DC File Offset: 0x000017DC
		public override void ShowSubtitle(Subtitle subtitle)
		{
			UnityUIBarkUI componentInChildren = subtitle.speakerInfo.transform.GetComponentInChildren<UnityUIBarkUI>();
			if (componentInChildren == null)
			{
				Debug.Log("Null bark UI: " + subtitle.formattedText.text);
			}
			else
			{
				componentInChildren.Bark(subtitle);
			}
			this.HideResponses();
		}
	}
}
