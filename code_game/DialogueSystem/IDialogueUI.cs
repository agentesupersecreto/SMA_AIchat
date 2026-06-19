using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200022B RID: 555
	public interface IDialogueUI
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06001918 RID: 6424
		// (remove) Token: 0x06001919 RID: 6425
		event EventHandler<SelectedResponseEventArgs> SelectedResponseHandler;

		// Token: 0x0600191A RID: 6426
		void Open();

		// Token: 0x0600191B RID: 6427
		void Close();

		// Token: 0x0600191C RID: 6428
		void ShowSubtitle(Subtitle subtitle);

		// Token: 0x0600191D RID: 6429
		void HideSubtitle(Subtitle subtitle);

		// Token: 0x0600191E RID: 6430
		void ShowResponses(Subtitle subtitle, Response[] responses, float timeout);

		// Token: 0x0600191F RID: 6431
		void HideResponses();

		// Token: 0x06001920 RID: 6432
		void ShowQTEIndicator(int index);

		// Token: 0x06001921 RID: 6433
		void HideQTEIndicator(int index);

		// Token: 0x06001922 RID: 6434
		void ShowAlert(string message, float duration);

		// Token: 0x06001923 RID: 6435
		void HideAlert();
	}
}
