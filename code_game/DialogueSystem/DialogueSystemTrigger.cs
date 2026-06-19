using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A3 RID: 675
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/dialogue_system_trigger.html")]
	[AddComponentMenu("Dialogue System/Trigger/Dialogue System Trigger")]
	public class DialogueSystemTrigger : DialogueEventStarter
	{
		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x06001C60 RID: 7264 RVA: 0x00034808 File Offset: 0x00032A08
		// (set) Token: 0x06001C61 RID: 7265 RVA: 0x00034810 File Offset: 0x00032A10
		public Sequencer sequencer { get; private set; }

		// Token: 0x06001C62 RID: 7266 RVA: 0x0003481C File Offset: 0x00032A1C
		public virtual void Awake()
		{
			this.barkHistory = new BarkHistory(this.barkOrder);
			this.sequencer = null;
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x00034838 File Offset: 0x00032A38
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x00034858 File Offset: 0x00032A58
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x00034878 File Offset: 0x00032A78
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x00034898 File Offset: 0x00032A98
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C67 RID: 7271 RVA: 0x000348BC File Offset: 0x00032ABC
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C68 RID: 7272 RVA: 0x000348E0 File Offset: 0x00032AE0
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x00034904 File Offset: 0x00032B04
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x0003492C File Offset: 0x00032B2C
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C6B RID: 7275 RVA: 0x00034954 File Offset: 0x00032B54
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x00034980 File Offset: 0x00032B80
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x000349AC File Offset: 0x00032BAC
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C6E RID: 7278 RVA: 0x000349E8 File Offset: 0x00032BE8
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C6F RID: 7279 RVA: 0x00034A20 File Offset: 0x00032C20
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C70 RID: 7280 RVA: 0x00034A5C File Offset: 0x00032C5C
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C71 RID: 7281 RVA: 0x00034A98 File Offset: 0x00032C98
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C72 RID: 7282 RVA: 0x00034AB4 File Offset: 0x00032CB4
		public void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x00034AF0 File Offset: 0x00032CF0
		public void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C74 RID: 7284 RVA: 0x00034B20 File Offset: 0x00032D20
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C75 RID: 7285 RVA: 0x00034B2C File Offset: 0x00032D2C
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C76 RID: 7286 RVA: 0x00034B38 File Offset: 0x00032D38
		public void OnDestroy()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C77 RID: 7287 RVA: 0x00034B68 File Offset: 0x00032D68
		private IEnumerator StartAfterOneFrame()
		{
			yield return null;
			this.TryStart(null);
			yield break;
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x00034B84 File Offset: 0x00032D84
		public void TryStart(Transform actor)
		{
			this.TryStart(actor, actor);
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x00034B90 File Offset: 0x00032D90
		public void TryStart(Transform actor, Transform interactor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if (this.condition == null || this.condition.IsTrue(interactor))
				{
					this.Fire(actor);
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x00034BFC File Offset: 0x00032DFC
		public void Fire(Transform actor)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Dialogue System Trigger is firing.", new object[] { "Dialogue System" }), this);
			}
			if (!string.IsNullOrEmpty(this.questName))
			{
				if (this.setQuestState)
				{
					QuestLog.SetQuestState(this.questName, this.questState);
				}
				if (this.setQuestEntryState)
				{
					QuestLog.SetQuestEntryState(this.questName, this.questEntryNumber, this.questEntryState);
				}
			}
			if (!string.IsNullOrEmpty(this.luaCode))
			{
				Lua.Run(this.luaCode, DialogueDebug.LogInfo);
			}
			if (!string.IsNullOrEmpty(this.sequence))
			{
				DialogueManager.PlaySequence(this.sequence, Tools.Select(new Transform[] { this.sequenceSpeaker, base.transform }), Tools.Select(new Transform[] { this.sequenceListener, actor }));
			}
			if (!string.IsNullOrEmpty(this.alertMessage))
			{
				string text = this.alertMessage;
				if (this.localizedTextTable != null && this.localizedTextTable.ContainsField(this.alertMessage))
				{
					text = this.localizedTextTable[this.alertMessage];
				}
				if (Mathf.Approximately(0f, this.alertDuration))
				{
					DialogueManager.ShowAlert(text);
				}
				else
				{
					DialogueManager.ShowAlert(text, this.alertDuration);
				}
			}
			foreach (DialogueSystemTrigger.SendMessageAction sendMessageAction in this.sendMessages)
			{
				if (sendMessageAction.gameObject != null && !string.IsNullOrEmpty(sendMessageAction.message))
				{
					sendMessageAction.gameObject.SendMessage(sendMessageAction.message, sendMessageAction.parameter, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (!string.IsNullOrEmpty(this.barkConversation))
			{
				if (DialogueManager.IsConversationActive && !this.allowBarksDuringConversations)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Bark triggered on {1}, but a conversation is already active.", new object[] { "Dialogue System", base.name }), this.GetBarker());
					}
				}
				else if (this.cacheBarkLines)
				{
					this.BarkCachedLine(this.GetBarker(), Tools.Select(new Transform[] { this.barkTarget, actor }));
				}
				else
				{
					DialogueManager.Bark(this.barkConversation, this.GetBarker(), Tools.Select(new Transform[] { this.barkTarget, actor }), this.barkHistory);
					this.sequencer = BarkController.LastSequencer;
				}
			}
			if (!string.IsNullOrEmpty(this.conversation))
			{
				bool flag = this.skipIfNoValidEntries && !DialogueManager.ConversationHasValidEntry(this.conversation, Tools.Select(new Transform[] { this.conversationActor, actor }), Tools.Select(new Transform[] { this.conversationConversant, base.transform }));
				if (this.exclusive && DialogueManager.IsConversationActive)
				{
					flag = true;
				}
				if (flag)
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Conversation triggered on {1}, but skipping because no entries are currently valid.", new object[] { "Dialogue System", base.name }));
					}
				}
				else
				{
					DialogueManager.StartConversation(this.conversation, Tools.Select(new Transform[] { this.conversationActor, actor }), Tools.Select(new Transform[] { this.conversationConversant, base.transform }));
				}
			}
			DialogueManager.SendUpdateTracker();
			base.DestroyIfOnce();
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x00034F98 File Offset: 0x00033198
		private Transform GetBarker()
		{
			return Tools.Select(new Transform[] { this.barker, base.transform });
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x00034FB8 File Offset: 0x000331B8
		private string GetBarkerName()
		{
			return OverrideActorName.GetActorName(this.GetBarker());
		}

		// Token: 0x06001C7D RID: 7293 RVA: 0x00034FC8 File Offset: 0x000331C8
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

		// Token: 0x06001C7E RID: 7294 RVA: 0x00035018 File Offset: 0x00033218
		private void PopulateCache(Transform speaker, Transform listener)
		{
			if (string.IsNullOrEmpty(this.barkConversation) && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): conversation title is blank", new object[] { "Dialogue System", speaker, listener }), speaker);
			}
			ConversationModel conversationModel = new ConversationModel(DialogueManager.MasterDatabase, this.barkConversation, speaker, listener, DialogueManager.AllowLuaExceptions, DialogueManager.IsDialogueEntryValid, -1, false, false);
			this.cachedState = conversationModel.FirstState;
			if (this.cachedState == null && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no START entry", new object[] { "Dialogue System", speaker, listener, this.barkConversation }), speaker);
			}
			if (!this.cachedState.HasAnyResponses && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no valid bark lines", new object[] { "Dialogue System", speaker, listener, this.barkConversation }), speaker);
			}
		}

		// Token: 0x06001C7F RID: 7295 RVA: 0x00035120 File Offset: 0x00033320
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

		// Token: 0x06001C80 RID: 7296 RVA: 0x00035280 File Offset: 0x00033480
		public void ResetBarkHistory()
		{
			this.barkHistory.Reset();
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x00035290 File Offset: 0x00033490
		public void OnRecordPersistentData()
		{
			if (base.enabled && !string.IsNullOrEmpty(this.barkConversation))
			{
				DialogueLua.SetActorField(this.GetBarkerName(), "Bark_Index", this.barkHistory.index);
			}
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x000352D8 File Offset: 0x000334D8
		public void OnApplyPersistentData()
		{
			if (base.enabled && !string.IsNullOrEmpty(this.barkConversation))
			{
				if (this.barkHistory == null)
				{
					this.barkHistory = new BarkHistory(this.barkOrder);
				}
				this.barkHistory.index = DialogueLua.GetActorField(this.GetBarkerName(), "Bark_Index").AsInt;
			}
		}

		// Token: 0x04001004 RID: 4100
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x04001005 RID: 4101
		public Condition condition;

		// Token: 0x04001006 RID: 4102
		[Tooltip("Only trigger if no other conversation is already active.")]
		public bool exclusive;

		// Token: 0x04001007 RID: 4103
		[ConversationPopup(false)]
		public string conversation = string.Empty;

		// Token: 0x04001008 RID: 4104
		[Tooltip("The other actor (e.g., NPC). If unassigned, this GameObject.")]
		public Transform conversationConversant;

		// Token: 0x04001009 RID: 4105
		[Tooltip("The primary actor (e.g., player). If unassigned, the GameObject that triggered the conversation.")]
		public Transform conversationActor;

		// Token: 0x0400100A RID: 4106
		[Tooltip("Only trigger if at least one entry's Conditions are currently true.")]
		public bool skipIfNoValidEntries;

		// Token: 0x0400100B RID: 4107
		[Tooltip("")]
		public bool stopConversationOnTriggerExit;

		// Token: 0x0400100C RID: 4108
		[ConversationPopup(false)]
		public string barkConversation = string.Empty;

		// Token: 0x0400100D RID: 4109
		public Transform barker;

		// Token: 0x0400100E RID: 4110
		[Tooltip("Target of the bark. Receives OnBark events.")]
		public Transform barkTarget;

		// Token: 0x0400100F RID: 4111
		public BarkOrder barkOrder;

		// Token: 0x04001010 RID: 4112
		public bool allowBarksDuringConversations;

		// Token: 0x04001011 RID: 4113
		[Tooltip("Only trigger if at least one entry's Conditions are currently true.")]
		public bool skipBarkIfNoValidEntries;

		// Token: 0x04001012 RID: 4114
		[Tooltip("Cache all lines during first bark. This can reduce stutter when barking on slower mobile devices, but barks' conditions are not reevaluated each time as the state changes, barks use no em formatting codes, and sequences are not played with barks.")]
		public bool cacheBarkLines;

		// Token: 0x04001013 RID: 4115
		[TextArea(1, 10)]
		public string sequence = string.Empty;

		// Token: 0x04001014 RID: 4116
		public Transform sequenceSpeaker;

		// Token: 0x04001015 RID: 4117
		public Transform sequenceListener;

		// Token: 0x04001016 RID: 4118
		public bool waitOneFrameOnStartOrEnable = true;

		// Token: 0x04001017 RID: 4119
		public bool setQuestState = true;

		// Token: 0x04001018 RID: 4120
		[QuestPopup(false)]
		public string questName;

		// Token: 0x04001019 RID: 4121
		[QuestState]
		public QuestState questState;

		// Token: 0x0400101A RID: 4122
		public bool setQuestEntryState;

		// Token: 0x0400101B RID: 4123
		public int questEntryNumber = 1;

		// Token: 0x0400101C RID: 4124
		[QuestState]
		public QuestState questEntryState;

		// Token: 0x0400101D RID: 4125
		public string luaCode = string.Empty;

		// Token: 0x0400101E RID: 4126
		public string alertMessage;

		// Token: 0x0400101F RID: 4127
		public LocalizedTextTable localizedTextTable;

		// Token: 0x04001020 RID: 4128
		public float alertDuration;

		// Token: 0x04001021 RID: 4129
		public DialogueSystemTrigger.SendMessageAction[] sendMessages = new DialogueSystemTrigger.SendMessageAction[0];

		// Token: 0x04001022 RID: 4130
		[HideInInspector]
		public bool useConversationTitlePicker = true;

		// Token: 0x04001023 RID: 4131
		[HideInInspector]
		public bool useBarkTitlePicker = true;

		// Token: 0x04001024 RID: 4132
		[HideInInspector]
		public bool useQuestNamePicker = true;

		// Token: 0x04001025 RID: 4133
		[HideInInspector]
		public DialogueDatabase selectedDatabase;

		// Token: 0x04001026 RID: 4134
		private BarkHistory barkHistory;

		// Token: 0x04001027 RID: 4135
		private ConversationState cachedState;

		// Token: 0x04001028 RID: 4136
		private IBarkUI barkUI;

		// Token: 0x04001029 RID: 4137
		private bool tryingToStart;

		// Token: 0x0400102A RID: 4138
		private bool listenForOnDestroy;

		// Token: 0x020002A4 RID: 676
		[Serializable]
		public class SendMessageAction
		{
			// Token: 0x0400102C RID: 4140
			public GameObject gameObject;

			// Token: 0x0400102D RID: 4141
			public string message = "OnUse";

			// Token: 0x0400102E RID: 4142
			public string parameter = string.Empty;
		}
	}
}
