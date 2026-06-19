using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000253 RID: 595
	[Serializable]
	public class InputTrigger
	{
		// Token: 0x06001A0D RID: 6669 RVA: 0x0002C190 File Offset: 0x0002A390
		public InputTrigger()
		{
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0002C1A4 File Offset: 0x0002A3A4
		public InputTrigger(KeyCode key)
		{
			this.key = key;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x0002C1C0 File Offset: 0x0002A3C0
		public InputTrigger(string buttonName)
		{
			this.buttonName = buttonName;
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x0002C1DC File Offset: 0x0002A3DC
		public InputTrigger(KeyCode key, string buttonName)
		{
			this.key = key;
			this.buttonName = buttonName;
		}

		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x06001A11 RID: 6673 RVA: 0x0002C200 File Offset: 0x0002A400
		public bool IsDown
		{
			get
			{
				return !DialogueManager.IsDialogueSystemInputDisabled() && (Input.GetKeyDown(this.key) || (!string.IsNullOrEmpty(this.buttonName) && DialogueManager.GetInputButtonDown(this.buttonName)));
			}
		}

		// Token: 0x04000ED7 RID: 3799
		[Tooltip("This key fires the trigger.")]
		public KeyCode key;

		// Token: 0x04000ED8 RID: 3800
		[Tooltip("This button fires the trigger. The button name must be defined in your project's Input Settings.")]
		public string buttonName = string.Empty;
	}
}
