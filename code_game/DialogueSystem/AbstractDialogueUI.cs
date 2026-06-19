using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000261 RID: 609
	public abstract class AbstractDialogueUI : MonoBehaviour, IDialogueUI
	{
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06001A51 RID: 6737 RVA: 0x0002CF74 File Offset: 0x0002B174
		// (remove) Token: 0x06001A52 RID: 6738 RVA: 0x0002CF90 File Offset: 0x0002B190
		public event EventHandler<SelectedResponseEventArgs> SelectedResponseHandler;

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06001A53 RID: 6739
		public abstract AbstractUIRoot UIRoot { get; }

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06001A54 RID: 6740
		public abstract AbstractDialogueUIControls Dialogue { get; }

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06001A55 RID: 6741
		public abstract AbstractUIQTEControls QTEs { get; }

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06001A56 RID: 6742
		public abstract AbstractUIAlertControls Alert { get; }

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06001A57 RID: 6743 RVA: 0x0002CFAC File Offset: 0x0002B1AC
		// (set) Token: 0x06001A58 RID: 6744 RVA: 0x0002CFB4 File Offset: 0x0002B1B4
		public bool IsOpen { get; set; }

		// Token: 0x06001A59 RID: 6745 RVA: 0x0002CFC0 File Offset: 0x0002B1C0
		public virtual void Awake()
		{
			this.IsOpen = false;
			this.SelectedResponseHandler = null;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x0002CFD0 File Offset: 0x0002B1D0
		public virtual void Start()
		{
			if (this.UIRoot == null || this.Dialogue == null || this.QTEs == null || this.Alert == null)
			{
				base.enabled = false;
			}
			else
			{
				this.UIRoot.Show();
				this.Dialogue.Hide();
				this.QTEs.Hide();
				if (!this.Alert.IsVisible)
				{
					this.Alert.Hide();
				}
				if (this.IsOpen)
				{
					this.Open();
				}
				if (!this.Alert.IsVisible && !this.IsOpen)
				{
					this.UIRoot.Hide();
				}
			}
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x0002D088 File Offset: 0x0002B288
		public virtual void Open()
		{
			this.hasOpenedBefore = true;
			this.Dialogue.ShowPanel();
			this.UIRoot.Show();
			this.IsOpen = true;
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		public virtual void Close()
		{
			this.Dialogue.Hide();
			if (!this.AreNonDialogueControlsVisible)
			{
				this.UIRoot.Hide();
			}
			this.IsOpen = false;
		}

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06001A5D RID: 6749 RVA: 0x0002D0F4 File Offset: 0x0002B2F4
		protected virtual bool AreNonDialogueControlsVisible
		{
			get
			{
				return this.Alert.IsVisible || this.QTEs.AreVisible;
			}
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x0002D120 File Offset: 0x0002B320
		public virtual void ShowAlert(string message, float duration)
		{
			if (!this.IsOpen)
			{
				if (!this.hasOpenedBefore)
				{
					this.Dialogue.Hide();
				}
				this.UIRoot.Show();
			}
			this.Alert.ShowMessage(message, duration);
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x0002D168 File Offset: 0x0002B368
		public virtual void HideAlert()
		{
			if (this.Alert.IsVisible)
			{
				this.Alert.Hide();
				if (!this.IsOpen && !this.QTEs.AreVisible)
				{
					this.UIRoot.Hide();
				}
			}
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x0002D1B8 File Offset: 0x0002B3B8
		public virtual void Update()
		{
			if (this.Alert.IsVisible && this.Alert.IsDone)
			{
				this.Alert.Hide();
			}
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x0002D1F0 File Offset: 0x0002B3F0
		public virtual void ShowSubtitle(Subtitle subtitle)
		{
			this.SetSubtitle(subtitle, true);
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x0002D1FC File Offset: 0x0002B3FC
		public virtual void HideSubtitle(Subtitle subtitle)
		{
			this.SetSubtitle(subtitle, false);
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x0002D208 File Offset: 0x0002B408
		public virtual void ShowContinueButton(Subtitle subtitle)
		{
			AbstractUISubtitleControls subtitleControls = this.GetSubtitleControls(subtitle);
			if (subtitleControls != null)
			{
				subtitleControls.ShowContinueButton();
			}
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x0002D22C File Offset: 0x0002B42C
		public virtual void HideContinueButton(Subtitle subtitle)
		{
			AbstractUISubtitleControls subtitleControls = this.GetSubtitleControls(subtitle);
			if (subtitleControls != null)
			{
				subtitleControls.HideContinueButton();
			}
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x0002D250 File Offset: 0x0002B450
		protected virtual void SetSubtitle(Subtitle subtitle, bool value)
		{
			AbstractUISubtitleControls subtitleControls = this.GetSubtitleControls(subtitle);
			if (subtitleControls != null)
			{
				if (value)
				{
					subtitleControls.ShowSubtitle(subtitle);
				}
				else
				{
					subtitleControls.Hide();
				}
			}
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x0002D284 File Offset: 0x0002B484
		private AbstractUISubtitleControls GetSubtitleControls(Subtitle subtitle)
		{
			return (subtitle != null) ? ((subtitle.speakerInfo.characterType != CharacterType.NPC) ? this.Dialogue.PCSubtitle : this.Dialogue.NPCSubtitle) : null;
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x0002D2CC File Offset: 0x0002B4CC
		public virtual void ShowResponses(Subtitle subtitle, Response[] responses, float timeout)
		{
			try
			{
				if (this.Dialogue == null)
				{
					Debug.LogError("Dialogue System: In ShowResponses(): The dialogue UI's main dialogue controls field is not set.", this);
				}
				else if (this.Dialogue.ResponseMenu == null)
				{
					Debug.LogError("Dialogue System: In ShowResponses(): The dialogue UI's response menu controls field is not set.", this);
				}
				else if (base.transform == null)
				{
					Debug.LogError("Dialogue System: In ShowResponses(): The dialogue UI's transform is null.", this);
				}
				else
				{
					this.Dialogue.ResponseMenu.ShowResponses(subtitle, responses, base.transform);
					if (timeout > 0f)
					{
						this.Dialogue.ResponseMenu.StartTimer(timeout);
					}
				}
			}
			catch (NullReferenceException ex)
			{
				Debug.LogError("Dialogue System: In ShowResponses(): " + ex.Message);
			}
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x0002D3A8 File Offset: 0x0002B5A8
		public virtual void HideResponses()
		{
			this.Dialogue.ResponseMenu.Hide();
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x0002D3BC File Offset: 0x0002B5BC
		public virtual void ShowQTEIndicator(int index)
		{
			this.QTEs.ShowIndicator(index);
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x0002D3CC File Offset: 0x0002B5CC
		public virtual void HideQTEIndicator(int index)
		{
			this.QTEs.HideIndicator(index);
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x0002D3DC File Offset: 0x0002B5DC
		public virtual void OnClick(object data)
		{
			if (this.SelectedResponseHandler != null)
			{
				this.SelectedResponseHandler(this, new SelectedResponseEventArgs(data as Response));
			}
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x0002D40C File Offset: 0x0002B60C
		public virtual void OnContinue()
		{
			this.OnContinueAlert();
			this.OnContinueConversation();
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x0002D41C File Offset: 0x0002B61C
		public virtual void OnContinueAlert()
		{
			if (this.Alert.IsVisible)
			{
				this.HideAlert();
			}
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x0002D434 File Offset: 0x0002B634
		public virtual void OnContinueConversation()
		{
			if (this.IsOpen)
			{
				DialogueManager.Instance.SendMessage("OnConversationContinue", this, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x0002D454 File Offset: 0x0002B654
		public virtual void SetPCPortrait(Texture2D portraitTexture, string portraitName)
		{
			this.Dialogue.ResponseMenu.SetPCPortrait(portraitTexture, portraitName);
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x0002D468 File Offset: 0x0002B668
		public virtual void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			this.Dialogue.NPCSubtitle.SetActorPortraitTexture(actorName, portraitTexture);
			this.Dialogue.PCSubtitle.SetActorPortraitTexture(actorName, portraitTexture);
			this.Dialogue.ResponseMenu.SetActorPortraitTexture(actorName, portraitTexture);
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x0002D4AC File Offset: 0x0002B6AC
		public static Texture2D GetValidPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (portraitTexture != null)
			{
				return portraitTexture;
			}
			Actor actor = DialogueManager.MasterDatabase.GetActor(actorName);
			return (actor == null) ? null : actor.portrait;
		}

		// Token: 0x04000EFA RID: 3834
		private bool hasOpenedBefore;
	}
}
