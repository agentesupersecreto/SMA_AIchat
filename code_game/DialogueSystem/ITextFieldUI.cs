using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200022C RID: 556
	public interface ITextFieldUI
	{
		// Token: 0x06001924 RID: 6436
		void StartTextInput(string labelText, string text, int maxLength, AcceptedTextDelegate acceptedText);

		// Token: 0x06001925 RID: 6437
		void CancelTextInput();
	}
}
