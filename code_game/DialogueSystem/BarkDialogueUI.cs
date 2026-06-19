using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000225 RID: 549
	[AddComponentMenu("Dialogue System/UI/Miscellaneous/Bark Dialogue UI")]
	public class BarkDialogueUI : MonoBehaviour, IDialogueUI
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060018CB RID: 6347 RVA: 0x00024334 File Offset: 0x00022534
		// (remove) Token: 0x060018CC RID: 6348 RVA: 0x00024350 File Offset: 0x00022550
		public event EventHandler<SelectedResponseEventArgs> SelectedResponseHandler;

		// Token: 0x060018CD RID: 6349 RVA: 0x0002436C File Offset: 0x0002256C
		public void Open()
		{
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x00024370 File Offset: 0x00022570
		public void Close()
		{
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x00024374 File Offset: 0x00022574
		public void ShowSubtitle(Subtitle subtitle)
		{
			base.StartCoroutine(BarkController.Bark(subtitle, true));
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x00024384 File Offset: 0x00022584
		public void HideSubtitle(Subtitle subtitle)
		{
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x00024388 File Offset: 0x00022588
		public void ShowResponses(Subtitle subtitle, Response[] responses, float timeout)
		{
			if (responses.Length > 0)
			{
				this.SelectedResponseHandler(this, new SelectedResponseEventArgs(responses[0]));
			}
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x000243A8 File Offset: 0x000225A8
		public void HideResponses()
		{
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x000243AC File Offset: 0x000225AC
		public void ShowQTEIndicator(int index)
		{
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x000243B0 File Offset: 0x000225B0
		public void HideQTEIndicator(int index)
		{
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x000243B4 File Offset: 0x000225B4
		public void ShowAlert(string message, float duration)
		{
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000243B8 File Offset: 0x000225B8
		public void HideAlert()
		{
		}
	}
}
