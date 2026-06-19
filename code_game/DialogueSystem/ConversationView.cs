using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200022A RID: 554
	public class ConversationView : MonoBehaviour
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060018ED RID: 6381 RVA: 0x000247F8 File Offset: 0x000229F8
		// (remove) Token: 0x060018EE RID: 6382 RVA: 0x00024814 File Offset: 0x00022A14
		public event EventHandler FinishedSubtitleHandler;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060018EF RID: 6383 RVA: 0x00024830 File Offset: 0x00022A30
		// (remove) Token: 0x060018F0 RID: 6384 RVA: 0x0002484C File Offset: 0x00022A4C
		public event EventHandler<SelectedResponseEventArgs> SelectedResponseHandler;

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x060018F1 RID: 6385 RVA: 0x00024868 File Offset: 0x00022A68
		public DisplaySettings displaySettings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x060018F2 RID: 6386 RVA: 0x00024870 File Offset: 0x00022A70
		public bool isWaitingForContinue
		{
			get
			{
				return this.waitForContinue;
			}
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x00024878 File Offset: 0x00022A78
		public void Initialize(IDialogueUI ui, Sequencer sequencer, DisplaySettings displaySettings, DialogueEntrySpokenDelegate dialogueEntrySpokenHandler)
		{
			this.ui = ui;
			this.sequencer = sequencer;
			this.settings = displaySettings;
			this.dialogueEntrySpokenHandler = dialogueEntrySpokenHandler;
			ui.Open();
			sequencer.Open();
			ui.SelectedResponseHandler += this.OnSelectedResponse;
			sequencer.FinishedSequenceHandler += this.OnFinishedSubtitle;
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x000248D4 File Offset: 0x00022AD4
		public void Close()
		{
			this.ui.SelectedResponseHandler -= this.OnSelectedResponse;
			this.sequencer.FinishedSequenceHandler -= this.OnFinishedSubtitle;
			this.ui.Close();
			this.sequencer.Close();
			Object.Destroy(this);
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x0002492C File Offset: 0x00022B2C
		public void Update()
		{
			if (this.Cancelled() && this.CancelledHandler != null)
			{
				this.CancelledHandler();
			}
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x00024950 File Offset: 0x00022B50
		private bool Cancelled()
		{
			return this.IsCancelKeyDown != null && this.IsCancelKeyDown();
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00024970 File Offset: 0x00022B70
		private bool IsSubtitleCancelKeyDown()
		{
			return this.settings.inputSettings.cancel.IsDown;
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00024988 File Offset: 0x00022B88
		private bool IsConversationCancelKeyDown()
		{
			return this.settings.inputSettings.cancelConversation.IsDown;
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x000249A0 File Offset: 0x00022BA0
		public void StartSubtitle(Subtitle subtitle, bool isPCResponseMenuNext, bool isPCAutoResponseNext)
		{
			if (subtitle != null)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: {1} says '{2}'", new object[]
					{
						"Dialogue System",
						Tools.GetGameObjectName(subtitle.speakerInfo.transform),
						subtitle.formattedText.text
					}));
				}
				this.NotifyParticipantsOnConversationLine(subtitle);
				if (this.ShouldShowSubtitle(subtitle))
				{
					this.ui.ShowSubtitle(subtitle);
					this._subtitle = subtitle;
					this._isPCResponseMenuNext = isPCResponseMenuNext;
					this._isPCAutoResponseNext = isPCAutoResponseNext;
					this.SetupContinueButton(subtitle, isPCResponseMenuNext, isPCAutoResponseNext);
				}
				else
				{
					this.waitForContinue = false;
				}
				this.sequencer.SetParticipants(subtitle.speakerInfo.transform, subtitle.listenerInfo.transform);
				this.sequencer.entrytag = subtitle.entrytag;
				this.sequencer.SubtitleEndTime = this.GetDefaultSubtitleDuration(subtitle.formattedText.text);
				if (!string.IsNullOrEmpty(subtitle.sequence) && subtitle.sequence.Contains("{{defaultsequence}}"))
				{
					subtitle.sequence = subtitle.sequence.Replace("{{defaultsequence}}", this.GetDefaultSequence(subtitle));
				}
				this.sequencer.PlaySequence((!string.IsNullOrEmpty(subtitle.sequence)) ? this.PreprocessSequence(subtitle) : this.GetDefaultSequence(subtitle), this.settings.subtitleSettings.informSequenceStartAndEnd, false);
				if (subtitle.speakerInfo.IsNPC)
				{
					this.lastNPCSubtitle = subtitle;
				}
				else
				{
					this.lastPCSubtitle = subtitle;
				}
				this.lastSubtitle = subtitle;
				if (this.dialogueEntrySpokenHandler != null)
				{
					this.dialogueEntrySpokenHandler(subtitle);
				}
			}
			else
			{
				this.FinishSubtitle();
			}
			this.IsCancelKeyDown = new ConversationView.IsCancelKeyDownDelegate(this.IsSubtitleCancelKeyDown);
			this.CancelledHandler = new Action(this.OnCancelSubtitle);
			this._lastModeWasResponseMenu = false;
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x00024B8C File Offset: 0x00022D8C
		public void SetupContinueButton()
		{
			this.SetupContinueButton(this._subtitle, this._isPCResponseMenuNext, this._isPCAutoResponseNext);
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00024BA8 File Offset: 0x00022DA8
		private void SetupContinueButton(Subtitle subtitle, bool isPCResponseMenuNext, bool isPCAutoResponseNext)
		{
			if (subtitle == null)
			{
				return;
			}
			bool flag = subtitle.speakerInfo.characterType == CharacterType.PC;
			this.waitForContinue = this.ShouldWaitForContinueButton(flag, isPCResponseMenuNext, isPCAutoResponseNext);
			bool flag2 = this.ShouldShowContinueButton(flag, isPCResponseMenuNext, isPCAutoResponseNext);
			if (this.waitForContinue && string.IsNullOrEmpty(subtitle.formattedText.text) && subtitle.dialogueEntry.id == 0)
			{
				this.waitForContinue = false;
			}
			AbstractDialogueUI abstractDialogueUI = this.ui as AbstractDialogueUI;
			if (abstractDialogueUI != null)
			{
				if (flag2)
				{
					abstractDialogueUI.ShowContinueButton(subtitle);
				}
				else
				{
					abstractDialogueUI.HideContinueButton(subtitle);
				}
			}
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x00024C4C File Offset: 0x00022E4C
		private bool ShouldWaitForContinueButton(bool isPCLine, bool isPCResponseMenuNext, bool isPCAutoResponseNext)
		{
			switch (this.settings.GetContinueButtonMode())
			{
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Never:
				return false;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Always:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Optional:
				return false;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalBeforeResponseMenu:
				return !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforeResponseMenu:
				return !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalBeforePCAutoresponseOrMenu:
				return !isPCResponseMenuNext && !isPCAutoResponseNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforePCAutoresponseOrMenu:
				return !isPCResponseMenuNext && !isPCAutoResponseNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPC:
				return !isPCLine;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPC:
				return !isPCLine;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPCOrBeforeResponseMenu:
				return !isPCLine && !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPCOrBeforeResponseMenu:
				return !isPCLine && !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPCOrBeforePCAutoresponseOrMenu:
				return !isPCLine && !isPCResponseMenuNext && !isPCAutoResponseNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPCOrBeforePCAutoresponseOrMenu:
				return !isPCLine && !isPCResponseMenuNext && !isPCAutoResponseNext;
			default:
				return false;
			}
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00024D20 File Offset: 0x00022F20
		private bool ShouldShowContinueButton(bool isPCLine, bool isPCResponseMenuNext, bool isPCAutoResponseNext)
		{
			switch (this.settings.GetContinueButtonMode())
			{
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Never:
				return false;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Always:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.Optional:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalBeforeResponseMenu:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforeResponseMenu:
				return !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalBeforePCAutoresponseOrMenu:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforePCAutoresponseOrMenu:
				return !isPCResponseMenuNext && !isPCAutoResponseNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPC:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPC:
				return !isPCLine;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPCOrBeforeResponseMenu:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPCOrBeforeResponseMenu:
				return !isPCLine && !isPCResponseMenuNext;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.OptionalForPCOrBeforePCAutoresponseOrMenu:
				return true;
			case DisplaySettings.SubtitleSettings.ContinueButtonMode.NotForPCOrBeforePCAutoresponseOrMenu:
				return !isPCLine && !isPCResponseMenuNext && !isPCAutoResponseNext;
			default:
				return false;
			}
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x00024DC4 File Offset: 0x00022FC4
		public void ShowLastNPCSubtitle()
		{
			if (this.ShouldShowLastNPCSubtitle())
			{
				this.ui.ShowSubtitle(this.lastNPCSubtitle);
			}
			this.FinishSubtitle();
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x00024DF4 File Offset: 0x00022FF4
		private bool ShouldShowLastNPCSubtitle()
		{
			return this.settings != null && this.settings.GetShowNPCSubtitlesWithResponses() && this.lastNPCSubtitle != null && this.lastNPCSubtitle.speakerInfo.characterType == CharacterType.NPC;
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00024E40 File Offset: 0x00023040
		private bool ShouldShowLastPCSubtitle()
		{
			return this.settings != null && this.settings.GetShowNPCSubtitlesWithResponses() && this.settings.subtitleSettings.allowPCSubtitleReminders && this.lastPCSubtitle != null && this.lastSubtitle == this.lastPCSubtitle && this.lastPCSubtitle.speakerInfo.characterType == CharacterType.PC;
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00024EB0 File Offset: 0x000230B0
		private bool ShouldShowSubtitle(Subtitle subtitle)
		{
			if (subtitle != null && this.settings != null && this.settings.subtitleSettings != null)
			{
				if (subtitle.speakerInfo.characterType == CharacterType.NPC && this.settings.GetShowNPCSubtitlesDuringLine())
				{
					return true;
				}
				if (subtitle.speakerInfo.characterType == CharacterType.PC && this.settings.GetShowPCSubtitlesDuringLine())
				{
					return !this._lastModeWasResponseMenu || !this.settings.GetSkipPCSubtitleAfterResponseMenu();
				}
			}
			return false;
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00024F40 File Offset: 0x00023140
		public void OnConversationContinue(IDialogueUI dialogueUI)
		{
			if (dialogueUI == this.ui)
			{
				this.HandleContinueButtonClick();
			}
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00024F54 File Offset: 0x00023154
		public void OnConversationContinueAll()
		{
			this.HandleContinueButtonClick();
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x00024F5C File Offset: 0x0002315C
		private void HandleContinueButtonClick()
		{
			this.waitForContinue = false;
			this.FinishSubtitle();
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x00024F6C File Offset: 0x0002316C
		private void OnCancelSubtitle()
		{
			base.BroadcastMessage("OnConversationLineCancelled", this.lastNPCSubtitle, SendMessageOptions.DontRequireReceiver);
			this.waitForContinue = false;
			this.FinishSubtitle();
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x00024F90 File Offset: 0x00023190
		private void FinishSubtitle()
		{
			if (!this.waitForContinue)
			{
				if (this.sequencer != null)
				{
					this.sequencer.Stop();
				}
				if (this.lastNPCSubtitle != null)
				{
					this.ui.HideSubtitle(this.lastNPCSubtitle);
				}
				if (this.lastPCSubtitle != null)
				{
					this.ui.HideSubtitle(this.lastPCSubtitle);
				}
				if (this._subtitle != null)
				{
					this.NotifyParticipantsOnConversationLineEnd(this.lastSubtitle);
				}
				if (this.FinishedSubtitleHandler != null)
				{
					this.FinishedSubtitleHandler(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x00025030 File Offset: 0x00023230
		private void OnFinishedSubtitle()
		{
			this.FinishSubtitle();
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00025038 File Offset: 0x00023238
		public void StartResponses(Subtitle subtitle, Response[] responses)
		{
			this.PlayResponseMenuSequence(subtitle.responseMenuSequence);
			Subtitle subtitle2 = ((!this.ShouldShowLastPCSubtitle()) ? ((!this.ShouldShowLastNPCSubtitle()) ? null : this.lastNPCSubtitle) : this.lastPCSubtitle);
			this.NotifyOnResponseMenu(responses);
			this.ui.ShowResponses(subtitle2, responses, this.settings.GetResponseTimeout());
			this.IsCancelKeyDown = new ConversationView.IsCancelKeyDownDelegate(this.IsConversationCancelKeyDown);
			this.CancelledHandler = new Action(this.OnCancelResponseMenu);
			this._lastModeWasResponseMenu = true;
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x000250CC File Offset: 0x000232CC
		private void PlayResponseMenuSequence(string responseMenuSequence)
		{
			if (string.IsNullOrEmpty(responseMenuSequence) && !string.IsNullOrEmpty(this.settings.GetDefaultResponseMenuSequence()))
			{
				responseMenuSequence = this.settings.GetDefaultResponseMenuSequence();
			}
			if (!string.IsNullOrEmpty(responseMenuSequence))
			{
				this.sequencer.FinishedSequenceHandler -= this.OnFinishedSubtitle;
				this.sequencer.Stop();
				this.sequencer.PlaySequence(responseMenuSequence);
				this.isPlayingResponseMenuSequence = true;
			}
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00025148 File Offset: 0x00023348
		private void StopResponseMenuSequence()
		{
			if (this.isPlayingResponseMenuSequence)
			{
				this.isPlayingResponseMenuSequence = false;
				this.sequencer.Stop();
				this.sequencer.StopAllCoroutines();
				this.sequencer.FinishedSequenceHandler += this.OnFinishedSubtitle;
			}
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x00025194 File Offset: 0x00023394
		private void OnCancelResponseMenu()
		{
			base.BroadcastMessage("OnConversationCancelled", this.sequencer.Speaker, SendMessageOptions.DontRequireReceiver);
			this.SelectResponse(new SelectedResponseEventArgs(null));
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x000251BC File Offset: 0x000233BC
		private void OnSelectedResponse(object sender, SelectedResponseEventArgs e)
		{
			this.SelectResponse(e);
		}

		// Token: 0x0600190D RID: 6413 RVA: 0x000251C8 File Offset: 0x000233C8
		public void SelectResponse(SelectedResponseEventArgs e)
		{
			this.StopResponseMenuSequence();
			this.ui.HideResponses();
			if (this.SelectedResponseHandler != null)
			{
				this.SelectedResponseHandler(this, e);
			}
		}

		// Token: 0x0600190E RID: 6414 RVA: 0x000251F4 File Offset: 0x000233F4
		public string GetDefaultSequence(Subtitle subtitle)
		{
			bool flag = subtitle.speakerInfo.characterType == CharacterType.PC;
			if (flag && !this.settings.GetShowPCSubtitlesDuringLine())
			{
				return this.settings.GetDefaultPlayerSequence();
			}
			float subtitleEndTime = this.sequencer.SubtitleEndTime;
			string text = this.settings.GetDefaultSequence();
			if (flag && !string.IsNullOrEmpty(this.settings.GetDefaultPlayerSequence()))
			{
				text = this.settings.GetDefaultPlayerSequence();
			}
			if (string.IsNullOrEmpty(text))
			{
				return string.Format("Delay({0})", new object[] { subtitleEndTime });
			}
			return text.Replace("{{end}}", subtitleEndTime.ToString());
		}

		// Token: 0x0600190F RID: 6415 RVA: 0x000252A8 File Offset: 0x000234A8
		private float GetDefaultSubtitleDuration(string text)
		{
			int num = ((!string.IsNullOrEmpty(text)) ? Tools.StripRichTextCodes(text).Length : 0);
			return Mathf.Max(this.settings.GetMinSubtitleSeconds(), (float)num / Mathf.Max(1f, this.settings.GetSubtitleCharsPerSecond()));
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x000252FC File Offset: 0x000234FC
		private string PreprocessSequence(Subtitle subtitle)
		{
			if (subtitle == null || string.IsNullOrEmpty(subtitle.sequence))
			{
				return string.Empty;
			}
			if (!subtitle.sequence.Contains("{{end}}"))
			{
				return subtitle.sequence;
			}
			float subtitleEndTime = this.sequencer.SubtitleEndTime;
			return subtitle.sequence.Replace("{{end}}", subtitleEndTime.ToString());
		}

		// Token: 0x06001911 RID: 6417 RVA: 0x00025364 File Offset: 0x00023564
		private void NotifyParticipantsOnConversationLine(Subtitle subtitle)
		{
			this.NotifyParticipants("OnConversationLine", subtitle);
		}

		// Token: 0x06001912 RID: 6418 RVA: 0x00025374 File Offset: 0x00023574
		private void NotifyParticipantsOnConversationLineEnd(Subtitle subtitle)
		{
			this.NotifyParticipants("OnConversationLineEnd", subtitle);
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x00025384 File Offset: 0x00023584
		private void NotifyParticipants(string message, Subtitle subtitle)
		{
			if (subtitle != null)
			{
				bool flag = this.CharacterInfoHasValidTransform(subtitle.speakerInfo);
				bool flag2 = this.CharacterInfoHasValidTransform(subtitle.listenerInfo);
				bool flag3 = flag && flag2 && subtitle.speakerInfo.transform == subtitle.listenerInfo.transform;
				if (flag)
				{
					subtitle.speakerInfo.transform.BroadcastMessage(message, subtitle, SendMessageOptions.DontRequireReceiver);
				}
				if (flag2 && !flag3)
				{
					subtitle.listenerInfo.transform.BroadcastMessage(message, subtitle, SendMessageOptions.DontRequireReceiver);
				}
				DialogueManager.Instance.BroadcastMessage(message, subtitle, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x00025424 File Offset: 0x00023624
		private void NotifyOnResponseMenu(Response[] responses)
		{
			if (responses != null)
			{
				DialogueManager.Instance.BroadcastMessage("OnConversationResponseMenu", responses, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x00025440 File Offset: 0x00023640
		private bool CharacterInfoHasValidTransform(CharacterInfo characterInfo)
		{
			return characterInfo != null && characterInfo.transform != null;
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x00025458 File Offset: 0x00023658
		public void SetPCPortrait(Texture2D pcTexture, string pcName)
		{
			AbstractDialogueUI abstractDialogueUI = DialogueManager.DialogueUI as AbstractDialogueUI;
			if (abstractDialogueUI == null)
			{
				return;
			}
			abstractDialogueUI.SetPCPortrait(pcTexture, pcName);
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00025488 File Offset: 0x00023688
		public void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			AbstractDialogueUI abstractDialogueUI = DialogueManager.DialogueUI as AbstractDialogueUI;
			if (abstractDialogueUI == null)
			{
				return;
			}
			abstractDialogueUI.SetActorPortraitTexture(actorName, portraitTexture);
		}

		// Token: 0x04000DE6 RID: 3558
		private IDialogueUI ui;

		// Token: 0x04000DE7 RID: 3559
		private Sequencer sequencer;

		// Token: 0x04000DE8 RID: 3560
		private DisplaySettings settings;

		// Token: 0x04000DE9 RID: 3561
		private Subtitle lastNPCSubtitle;

		// Token: 0x04000DEA RID: 3562
		private Subtitle lastPCSubtitle;

		// Token: 0x04000DEB RID: 3563
		private Subtitle lastSubtitle;

		// Token: 0x04000DEC RID: 3564
		private ConversationView.IsCancelKeyDownDelegate IsCancelKeyDown;

		// Token: 0x04000DED RID: 3565
		private Action CancelledHandler;

		// Token: 0x04000DEE RID: 3566
		private DialogueEntrySpokenDelegate dialogueEntrySpokenHandler;

		// Token: 0x04000DEF RID: 3567
		private bool waitForContinue;

		// Token: 0x04000DF0 RID: 3568
		private bool isPlayingResponseMenuSequence;

		// Token: 0x04000DF1 RID: 3569
		private Subtitle _subtitle;

		// Token: 0x04000DF2 RID: 3570
		private bool _isPCResponseMenuNext;

		// Token: 0x04000DF3 RID: 3571
		private bool _isPCAutoResponseNext;

		// Token: 0x04000DF4 RID: 3572
		private bool _lastModeWasResponseMenu;

		// Token: 0x020002DE RID: 734
		// (Invoke) Token: 0x06001DF1 RID: 7665
		private delegate bool IsCancelKeyDownDelegate();
	}
}
