using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D9 RID: 729
	[Serializable]
	public class UnityResponseMenuControls : AbstractUIResponseMenuControls
	{
		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06001DD3 RID: 7635 RVA: 0x0003AE04 File Offset: 0x00039004
		public override AbstractUISubtitleControls SubtitleReminder
		{
			get
			{
				return this.subtitleReminder;
			}
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x0003AE0C File Offset: 0x0003900C
		public override void SetPCPortrait(Texture2D portraitTexture, string portraitName)
		{
			this.pcPortraitTexture = portraitTexture;
			this.pcPortraitName = portraitName;
		}

		// Token: 0x06001DD5 RID: 7637 RVA: 0x0003AE1C File Offset: 0x0003901C
		public override void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (string.Equals(actorName, this.pcPortraitName))
			{
				Texture2D validPortraitTexture = AbstractDialogueUI.GetValidPortraitTexture(actorName, portraitTexture);
				this.pcPortraitTexture = validPortraitTexture;
				if (this.pcImage != null && DialogueManager.MasterDatabase.IsPlayer(actorName))
				{
					this.pcImage.image = validPortraitTexture;
				}
			}
		}

		// Token: 0x06001DD6 RID: 7638 RVA: 0x0003AE78 File Offset: 0x00039078
		public override void SetActive(bool value)
		{
			this.SubtitleReminder.SetActive(value && this.SubtitleReminder.HasText);
			foreach (GUIButton guibutton in this.buttons)
			{
				UnityDialogueUIControls.SetControlActive(guibutton, value && guibutton.visible);
			}
			UnityDialogueUIControls.SetControlActive(this.timer, false);
			UnityDialogueUIControls.SetControlActive(this.pcImage, value);
			UnityDialogueUIControls.SetControlActive(this.pcName, value);
			UnityDialogueUIControls.SetControlActive(this.panel, value);
			if (value)
			{
				if (this.pcImage != null && this.pcPortraitTexture != null)
				{
					this.pcImage.image = this.pcPortraitTexture;
				}
				if (this.pcName != null && this.pcPortraitName != null)
				{
					this.pcName.text = this.pcPortraitName;
				}
			}
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x0003AF70 File Offset: 0x00039170
		protected override void ClearResponseButtons()
		{
			if (this.buttons != null)
			{
				for (int i = 0; i < this.buttons.Length; i++)
				{
					this.SetResponseButton(this.buttons[i], null, null);
					this.buttons[i].visible = this.showUnusedButtons;
				}
			}
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x0003AFC4 File Offset: 0x000391C4
		protected override void SetResponseButtons(Response[] responses, Transform target)
		{
			if (this.buttons != null && this.buttons.Length > 0 && responses != null)
			{
				for (int i = 0; i < responses.Length; i++)
				{
					if (responses[i].formattedText.position != -1)
					{
						int num = Mathf.Clamp(responses[i].formattedText.position, 0, this.buttons.Length - 1);
						this.SetResponseButton(this.buttons[num], responses[i], target);
					}
				}
				if (this.buttonAlignment == ResponseButtonAlignment.ToFirst)
				{
					for (int j = 0; j < Mathf.Min(this.buttons.Length, responses.Length); j++)
					{
						if (responses[j].formattedText.position == -1)
						{
							int num2 = Mathf.Clamp(this.GetNextAvailableResponseButtonPosition(0, 1), 0, this.buttons.Length - 1);
							this.SetResponseButton(this.buttons[num2], responses[j], target);
						}
					}
				}
				else
				{
					for (int k = Mathf.Min(this.buttons.Length, responses.Length) - 1; k >= 0; k--)
					{
						if (responses[k].formattedText.position == -1)
						{
							int num3 = Mathf.Clamp(this.GetNextAvailableResponseButtonPosition(this.buttons.Length - 1, -1), 0, this.buttons.Length - 1);
							this.SetResponseButton(this.buttons[num3], responses[k], target);
						}
					}
				}
			}
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x0003B128 File Offset: 0x00039328
		private void SetResponseButton(GUIButton button, Response response, Transform target)
		{
			if (button != null)
			{
				button.visible = true;
				button.clickable = response != null && response.enabled;
				if (response != null)
				{
					button.SetFormattedText(response.formattedText);
				}
				else if (this.showUnusedButtons)
				{
					button.SetUnformattedText(" ");
				}
				button.target = target;
				button.data = response;
			}
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x0003B198 File Offset: 0x00039398
		private int GetNextAvailableResponseButtonPosition(int start, int direction)
		{
			if (this.buttons != null)
			{
				int num = start;
				while (0 <= num && num < this.buttons.Length)
				{
					if (!this.buttons[num].clickable)
					{
						return num;
					}
					num += direction;
				}
			}
			return 0;
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x0003B1EC File Offset: 0x000393EC
		public override void StartTimer(float timeout)
		{
			if (this.timer != null)
			{
				if (this.timerEffect == null)
				{
					UnityDialogueUIControls.SetControlActive(this.timer, true);
					this.timerEffect = this.timer.GetComponent<TimerEffect>();
					UnityDialogueUIControls.SetControlActive(this.timer, false);
				}
				if (this.timerEffect != null)
				{
					this.timer.progress = 1f;
					this.timerEffect.duration = timeout;
					this.timerEffect.TimeoutHandler -= this.OnTimeout;
					this.timerEffect.TimeoutHandler += this.OnTimeout;
					UnityDialogueUIControls.SetControlActive(this.timer, true);
				}
			}
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x0003B2AC File Offset: 0x000394AC
		public void OnTimeout()
		{
			DialogueManager.Instance.SendMessage("OnConversationTimeout");
		}

		// Token: 0x04001151 RID: 4433
		public GUIControl panel;

		// Token: 0x04001152 RID: 4434
		public GUILabel pcImage;

		// Token: 0x04001153 RID: 4435
		public GUILabel pcName;

		// Token: 0x04001154 RID: 4436
		public UnitySubtitleControls subtitleReminder;

		// Token: 0x04001155 RID: 4437
		public GUIProgressBar timer;

		// Token: 0x04001156 RID: 4438
		public GUIButton[] buttons;

		// Token: 0x04001157 RID: 4439
		private TimerEffect timerEffect;

		// Token: 0x04001158 RID: 4440
		private Texture2D pcPortraitTexture;

		// Token: 0x04001159 RID: 4441
		private string pcPortraitName;
	}
}
