using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000044 RID: 68
	[AddComponentMenu("Dialogue System/Miscellaneous/Quest Log Window Hotkey")]
	public class QuestLogWindowHotkey : MonoBehaviour
	{
		// Token: 0x06000205 RID: 517 RVA: 0x0000AA59 File Offset: 0x00008C59
		private void Awake()
		{
			if (this.questLogWindow == null)
			{
				this.questLogWindow = Object.FindObjectOfType<QuestLogWindow>();
			}
			if (this.questLogWindow == null)
			{
				base.enabled = false;
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000AA8C File Offset: 0x00008C8C
		private void Update()
		{
			if (DialogueManager.IsDialogueSystemInputDisabled())
			{
				return;
			}
			if (Input.GetKeyDown(this.key) || (!string.IsNullOrEmpty(this.buttonName) && DialogueManager.GetInputButtonDown(this.buttonName)))
			{
				if (this.questLogWindow.IsOpen)
				{
					this.questLogWindow.Close();
					return;
				}
				this.questLogWindow.Open();
			}
		}

		// Token: 0x0400018A RID: 394
		[Tooltip("Toggle the quest log window when this key is pressed.")]
		public KeyCode key = KeyCode.J;

		// Token: 0x0400018B RID: 395
		[Tooltip("Toggle the quest log window when this input button is presed.")]
		public string buttonName = string.Empty;

		// Token: 0x0400018C RID: 396
		[Tooltip("Use this quest log window. If unassigned, will automatically find quest log window in scene.")]
		public QuestLogWindow questLogWindow;
	}
}
