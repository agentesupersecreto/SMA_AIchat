using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000224 RID: 548
	public class Subtitle
	{
		// Token: 0x060018C6 RID: 6342 RVA: 0x00024154 File Offset: 0x00022354
		public Subtitle(CharacterInfo speakerInfo, CharacterInfo listenerInfo, FormattedText formattedText, string sequence, string responseMenuSequence, DialogueEntry dialogueEntry)
		{
			this.speakerInfo = speakerInfo;
			this.listenerInfo = listenerInfo;
			this.formattedText = formattedText;
			this.sequence = sequence;
			this.responseMenuSequence = responseMenuSequence;
			this.dialogueEntry = dialogueEntry;
			this.entrytag = null;
			this.CheckVariableInputPrompt();
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x000241AC File Offset: 0x000223AC
		public Subtitle(CharacterInfo speakerInfo, CharacterInfo listenerInfo, FormattedText formattedText, string sequence, string responseMenuSequence, DialogueEntry dialogueEntry, string entrytag)
		{
			this.speakerInfo = speakerInfo;
			this.listenerInfo = listenerInfo;
			this.formattedText = formattedText;
			this.sequence = sequence;
			this.responseMenuSequence = responseMenuSequence;
			this.dialogueEntry = dialogueEntry;
			this.entrytag = entrytag;
			this.CheckVariableInputPrompt();
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x00024208 File Offset: 0x00022408
		private void CheckVariableInputPrompt()
		{
			if (this.formattedText != null && this.formattedText.hasVariableInputPrompt)
			{
				this.sequence = string.Format("{0}{1}TextInput(Text Field UI,{2},{2})", this.sequence, (!string.IsNullOrEmpty(this.sequence)) ? "; " : string.Empty, this.formattedText.variableInputPrompt);
			}
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x00024270 File Offset: 0x00022470
		public Texture2D GetSpeakerPortrait()
		{
			if (this.speakerInfo == null)
			{
				return null;
			}
			if (this.formattedText == null)
			{
				return this.speakerInfo.portrait;
			}
			if (this.formattedText.pic != 0)
			{
				return this.speakerInfo.GetPicOverride(this.formattedText.pic);
			}
			if (this.formattedText.picActor != 0)
			{
				return this.speakerInfo.GetPicOverride(this.formattedText.picActor);
			}
			if (this.formattedText.picConversant != 0 && this.listenerInfo != null)
			{
				return this.listenerInfo.GetPicOverride(this.formattedText.picConversant);
			}
			return this.speakerInfo.portrait;
		}

		// Token: 0x04000DD6 RID: 3542
		public CharacterInfo speakerInfo;

		// Token: 0x04000DD7 RID: 3543
		public CharacterInfo listenerInfo;

		// Token: 0x04000DD8 RID: 3544
		public FormattedText formattedText;

		// Token: 0x04000DD9 RID: 3545
		public string sequence;

		// Token: 0x04000DDA RID: 3546
		public string responseMenuSequence;

		// Token: 0x04000DDB RID: 3547
		public DialogueEntry dialogueEntry;

		// Token: 0x04000DDC RID: 3548
		public string entrytag = string.Empty;
	}
}
