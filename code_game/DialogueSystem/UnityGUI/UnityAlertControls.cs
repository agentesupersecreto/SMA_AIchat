using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D5 RID: 725
	[Serializable]
	public class UnityAlertControls : AbstractUIAlertControls
	{
		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x06001DBF RID: 7615 RVA: 0x0003AA94 File Offset: 0x00038C94
		public override bool IsVisible
		{
			get
			{
				return this.line != null && this.line.gameObject.activeSelf;
			}
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x0003AAC8 File Offset: 0x00038CC8
		public override void SetActive(bool value)
		{
			UnityDialogueUIControls.SetControlActive(this.line, value);
			UnityDialogueUIControls.SetControlActive(this.panel, value);
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x0003AAE4 File Offset: 0x00038CE4
		public override void SetMessage(string message, float duration)
		{
			if (this.line != null)
			{
				this.line.SetFormattedText(FormattedText.Parse(message, DialogueManager.MasterDatabase.emphasisSettings));
				this.SetFadeDuration(this.line.gameObject, duration);
				if (this.panel != null)
				{
					this.SetFadeDuration(this.panel.gameObject, duration);
				}
			}
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x0003AB54 File Offset: 0x00038D54
		private void SetFadeDuration(GameObject go, float duration)
		{
			if (go != null)
			{
				FadeEffect component = go.GetComponent<FadeEffect>();
				if (component != null)
				{
					component.SetFadeDurations(component.fadeInDuration, duration, component.fadeOutDuration);
					this.alertDoneTime = Mathf.Max(this.alertDoneTime, DialogueTime.time + component.fadeInDuration + duration + component.fadeOutDuration);
					if (go.activeInHierarchy)
					{
						component.StopAllCoroutines();
						component.StartCoroutine(component.Play());
					}
				}
			}
		}

		// Token: 0x04001148 RID: 4424
		public GUIControl panel;

		// Token: 0x04001149 RID: 4425
		public GUILabel line;

		// Token: 0x0400114A RID: 4426
		public GUIButton continueButton;
	}
}
