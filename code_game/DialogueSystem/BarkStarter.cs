using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200029C RID: 668
	[AddComponentMenu("")]
	public abstract class BarkStarter : ConversationStarter
	{
		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06001C0E RID: 7182 RVA: 0x000333C0 File Offset: 0x000315C0
		// (set) Token: 0x06001C0F RID: 7183 RVA: 0x000333C8 File Offset: 0x000315C8
		public Sequencer sequencer { get; private set; }

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06001C10 RID: 7184 RVA: 0x000333D4 File Offset: 0x000315D4
		// (set) Token: 0x06001C11 RID: 7185 RVA: 0x000333E4 File Offset: 0x000315E4
		public int BarkIndex
		{
			get
			{
				return this.barkHistory.index;
			}
			set
			{
				this.barkHistory.index = value;
			}
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x000333F4 File Offset: 0x000315F4
		protected virtual void Awake()
		{
			this.barkHistory = new BarkHistory(this.barkOrder);
			this.sequencer = null;
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x00033410 File Offset: 0x00031610
		protected virtual void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
		}

		// Token: 0x06001C14 RID: 7188 RVA: 0x00033420 File Offset: 0x00031620
		protected virtual void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x00033430 File Offset: 0x00031630
		public void TryBark(Transform target)
		{
			this.TryBark(target, target);
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x0003343C File Offset: 0x0003163C
		public void TryBark(Transform target, Transform interactor)
		{
			if (!this.tryingToBark)
			{
				this.tryingToBark = true;
				try
				{
					if (this.condition == null || this.condition.IsTrue(interactor))
					{
						if (string.IsNullOrEmpty(this.conversation))
						{
							if (DialogueDebug.LogWarnings)
							{
								Debug.LogWarning(string.Format("{0}: Bark triggered on {1}, but conversation name is blank.", new object[] { "Dialogue System", base.name }), this.GetBarker());
							}
						}
						else if (DialogueManager.IsConversationActive && !this.allowDuringConversations)
						{
							if (DialogueDebug.LogWarnings)
							{
								Debug.LogWarning(string.Format("{0}: Bark triggered on {1}, but a conversation is already active.", new object[] { "Dialogue System", base.name }), this.GetBarker());
							}
						}
						else if (this.cacheBarkLines)
						{
							this.BarkCachedLine(this.GetBarker(), target);
						}
						else
						{
							DialogueManager.Bark(this.conversation, this.GetBarker(), target, this.barkHistory);
							this.sequencer = BarkController.LastSequencer;
						}
						base.DestroyIfOnce();
					}
				}
				finally
				{
					this.tryingToBark = false;
				}
			}
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x00033584 File Offset: 0x00031784
		private Transform GetBarker()
		{
			return Tools.Select(new Transform[] { this.conversant, base.transform });
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x000335A4 File Offset: 0x000317A4
		private string GetBarkerName()
		{
			return OverrideActorName.GetActorName(this.GetBarker());
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x000335B4 File Offset: 0x000317B4
		private void BarkCachedLine(Transform speaker, Transform listener)
		{
			if (this.barkUI == null)
			{
				this.barkUI = speaker.GetComponentInChildren(typeof(IBarkUI)) as IBarkUI;
			}
			if (this.cachedState == null)
			{
				this.PopulateCache(speaker, listener);
			}
			this.BarkNextCachedLine(speaker, listener);
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x00033604 File Offset: 0x00031804
		private void PopulateCache(Transform speaker, Transform listener)
		{
			if (string.IsNullOrEmpty(this.conversation) && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): conversation title is blank", new object[] { "Dialogue System", speaker, listener }), speaker);
			}
			ConversationModel conversationModel = new ConversationModel(DialogueManager.MasterDatabase, this.conversation, speaker, listener, DialogueManager.AllowLuaExceptions, DialogueManager.IsDialogueEntryValid, -1, false, false);
			this.cachedState = conversationModel.FirstState;
			if (this.cachedState == null && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no START entry", new object[] { "Dialogue System", speaker, listener, this.conversation }), speaker);
			}
			if (!this.cachedState.HasAnyResponses && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no valid bark lines", new object[] { "Dialogue System", speaker, listener, this.conversation }), speaker);
			}
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x0003370C File Offset: 0x0003190C
		private void BarkNextCachedLine(Transform speaker, Transform listener)
		{
			if (this.barkUI != null && this.cachedState != null && this.cachedState.HasAnyResponses)
			{
				Response[] array = ((!this.cachedState.HasNPCResponse) ? this.cachedState.pcResponses : this.cachedState.npcResponses);
				int nextIndex = (this.barkHistory ?? new BarkHistory(BarkOrder.Random)).GetNextIndex(array.Length);
				DialogueEntry destinationEntry = array[nextIndex].destinationEntry;
				if (destinationEntry == null && DialogueDebug.LogWarnings)
				{
					Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' bark entry is null", new object[] { "Dialogue System", speaker, listener, this.conversation }), speaker);
				}
				if (destinationEntry != null)
				{
					Subtitle subtitle = new Subtitle(this.cachedState.subtitle.listenerInfo, this.cachedState.subtitle.speakerInfo, new FormattedText(destinationEntry.DialogueText, null, false, -1, true, 0, 0, 0, null), string.Empty, string.Empty, destinationEntry);
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}'", new object[]
						{
							"Dialogue System",
							speaker,
							listener,
							subtitle.formattedText.text
						}), speaker);
					}
					base.StartCoroutine(BarkController.Bark(subtitle, speaker, listener, this.barkUI));
				}
			}
		}

		// Token: 0x06001C1C RID: 7196 RVA: 0x0003386C File Offset: 0x00031A6C
		public void ResetBarkHistory()
		{
			this.barkHistory.Reset();
		}

		// Token: 0x06001C1D RID: 7197 RVA: 0x0003387C File Offset: 0x00031A7C
		public void OnRecordPersistentData()
		{
			if (base.enabled && this.barkHistory != null)
			{
				DialogueLua.SetActorField(this.GetBarkerName(), "Bark_Index", this.barkHistory.index);
			}
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x000338C0 File Offset: 0x00031AC0
		public void OnApplyPersistentData()
		{
			if (base.enabled)
			{
				if (this.barkHistory == null)
				{
					this.barkHistory = new BarkHistory(this.barkOrder);
				}
				this.barkHistory.index = DialogueLua.GetActorField(this.GetBarkerName(), "Bark_Index").AsInt;
			}
		}

		// Token: 0x04000FDA RID: 4058
		[Tooltip("The order in which to bark dialogue entries.")]
		public BarkOrder barkOrder;

		// Token: 0x04000FDB RID: 4059
		[Tooltip("Allow barks during active conversations.")]
		public bool allowDuringConversations;

		// Token: 0x04000FDC RID: 4060
		[Tooltip("Cache all lines during first bark. This can reduce stutter when barking on slower mobile devices, but barks' conditions are not reevaluated each time as the state changes, barks use no em formatting codes, and sequences are not played with barks.")]
		public bool cacheBarkLines;

		// Token: 0x04000FDD RID: 4061
		private BarkHistory barkHistory;

		// Token: 0x04000FDE RID: 4062
		private bool tryingToBark;

		// Token: 0x04000FDF RID: 4063
		private ConversationState cachedState;

		// Token: 0x04000FE0 RID: 4064
		private IBarkUI barkUI;
	}
}
