using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000015 RID: 21
	public class ConversationController
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00005814 File Offset: 0x00003A14
		public ConversationController(ConversationModel model, ConversationView view, bool alwaysForceResponseMenu, ConversationController.EndConversationDelegate endConversationHandler)
		{
			this.IsActive = true;
			this.model = model;
			this.view = view;
			this.alwaysForceResponseMenu = alwaysForceResponseMenu;
			this.endConversationHandler = endConversationHandler;
			model.InformParticipants("OnConversationStart", false);
			view.FinishedSubtitleHandler += this.OnFinishedSubtitle;
			view.SelectedResponseHandler += this.OnSelectedResponse;
			this.currentConversationID = model.GetConversationID(model.FirstState);
			this.SetConversationOverride(model.FirstState);
			this.GotoState(model.FirstState);
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000121 RID: 289 RVA: 0x000058A8 File Offset: 0x00003AA8
		// (set) Token: 0x06000122 RID: 290 RVA: 0x000058B0 File Offset: 0x00003AB0
		public bool IsActive { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000058BC File Offset: 0x00003ABC
		public CharacterInfo ActorInfo
		{
			get
			{
				return (this.model == null) ? null : this.model.ActorInfo;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000124 RID: 292 RVA: 0x000058DC File Offset: 0x00003ADC
		public ConversationModel ConversationModel
		{
			get
			{
				return this.model;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000058E4 File Offset: 0x00003AE4
		public ConversationView ConversationView
		{
			get
			{
				return this.view;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000058EC File Offset: 0x00003AEC
		// (set) Token: 0x06000127 RID: 295 RVA: 0x000058FC File Offset: 0x00003AFC
		public IsDialogueEntryValidDelegate IsDialogueEntryValid
		{
			get
			{
				return this.model.IsDialogueEntryValid;
			}
			set
			{
				this.model.IsDialogueEntryValid = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000128 RID: 296 RVA: 0x0000590C File Offset: 0x00003B0C
		public CharacterInfo ConversantInfo
		{
			get
			{
				return (this.model == null) ? null : this.model.ConversantInfo;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000592C File Offset: 0x00003B2C
		public void Close()
		{
			if (this.IsActive)
			{
				this.IsActive = false;
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Ending conversation.", new object[] { "Dialogue System" }));
				}
				this.view.displaySettings.conversationOverrideSettings = null;
				this.view.FinishedSubtitleHandler -= this.OnFinishedSubtitle;
				this.view.SelectedResponseHandler -= this.OnSelectedResponse;
				this.view.Close();
				this.model.InformParticipants("OnConversationEnd", true);
				if (this.endConversationHandler != null)
				{
					this.endConversationHandler(this);
				}
				DialogueManager.Instance.CurrentConversationState = null;
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000059F0 File Offset: 0x00003BF0
		public void GotoState(ConversationState state)
		{
			this.state = state;
			DialogueManager.Instance.CurrentConversationState = state;
			if (state != null)
			{
				int conversationID = this.model.GetConversationID(state);
				if (conversationID != this.currentConversationID)
				{
					this.currentConversationID = conversationID;
					this.model.InformParticipants("OnLinkedConversationStart", true);
					this.SetConversationOverride(state);
				}
				if (state.IsGroup)
				{
					this.view.ShowLastNPCSubtitle();
				}
				else
				{
					bool hasPCAutoResponse = state.HasPCAutoResponse;
					bool flag = state.HasPCResponses && !state.HasNPCResponse;
					if (hasPCAutoResponse && !this.view.displaySettings.GetAlwaysForceResponseMenu())
					{
						flag = false;
					}
					this.view.StartSubtitle(state.subtitle, flag, hasPCAutoResponse);
				}
			}
			else
			{
				this.Close();
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00005AC4 File Offset: 0x00003CC4
		private void SetConversationOverride(ConversationState state)
		{
			this.view.displaySettings.conversationOverrideSettings = this.model.GetConversationOverrideSettings(state);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005AE4 File Offset: 0x00003CE4
		private void OnFinishedSubtitle(object sender, EventArgs e)
		{
			if (this.state.HasNPCResponse)
			{
				this.GotoState(this.model.GetState(this.state.FirstNPCResponse.destinationEntry));
			}
			else if (this.state.HasPCResponses)
			{
				if (this.state.HasPCAutoResponse && (!this.alwaysForceResponseMenu || this.state.pcResponses[0].destinationEntry.isGroup))
				{
					this.GotoState(this.model.GetState(this.state.PCAutoResponse.destinationEntry));
				}
				else
				{
					this.view.StartResponses(this.state.subtitle, this.state.pcResponses);
				}
			}
			else
			{
				this.Close();
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00005BC0 File Offset: 0x00003DC0
		private void OnSelectedResponse(object sender, SelectedResponseEventArgs e)
		{
			this.GotoState(this.model.GetState(e.DestinationEntry));
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005BDC File Offset: 0x00003DDC
		public void GotoFirstResponse()
		{
			if (this.state != null && this.state.pcResponses.Length > 0)
			{
				this.view.SelectResponse(new SelectedResponseEventArgs(this.state.pcResponses[0]));
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005C1C File Offset: 0x00003E1C
		public void GotoRandomResponse()
		{
			if (this.state != null && this.state.pcResponses.Length > 0)
			{
				this.view.SelectResponse(new SelectedResponseEventArgs(this.state.pcResponses[Random.Range(0, this.state.pcResponses.Length)]));
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005C78 File Offset: 0x00003E78
		public void UpdateResponses()
		{
			if (this.state != null)
			{
				this.model.UpdateResponses(this.state);
				this.OnFinishedSubtitle(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005CB0 File Offset: 0x00003EB0
		public void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			this.model.SetActorPortraitTexture(actorName, portraitTexture);
			this.view.SetActorPortraitTexture(actorName, portraitTexture);
		}

		// Token: 0x04000067 RID: 103
		private ConversationModel model;

		// Token: 0x04000068 RID: 104
		private ConversationView view;

		// Token: 0x04000069 RID: 105
		private ConversationState state;

		// Token: 0x0400006A RID: 106
		private bool alwaysForceResponseMenu;

		// Token: 0x0400006B RID: 107
		private int currentConversationID;

		// Token: 0x0400006C RID: 108
		private ConversationController.EndConversationDelegate endConversationHandler;

		// Token: 0x020002DC RID: 732
		// (Invoke) Token: 0x06001DE9 RID: 7657
		public delegate void EndConversationDelegate(ConversationController ConversationController);
	}
}
