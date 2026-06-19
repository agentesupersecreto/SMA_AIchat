using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000D RID: 13
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/how_to_set_up_dialogue_manager.html")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Dialogue System Controller")]
	public class DialogueSystemController : MonoBehaviour
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00003834 File Offset: 0x00001A34
		public DatabaseManager DatabaseManager
		{
			get
			{
				return this.databaseManager;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000383C File Offset: 0x00001A3C
		public DialogueDatabase MasterDatabase
		{
			get
			{
				return this.databaseManager.MasterDatabase;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000384C File Offset: 0x00001A4C
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00003854 File Offset: 0x00001A54
		public IDialogueUI DialogueUI
		{
			get
			{
				return this.GetDialogueUI();
			}
			set
			{
				this.SetDialogueUI(value);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00003860 File Offset: 0x00001A60
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00003868 File Offset: 0x00001A68
		public IsDialogueEntryValidDelegate IsDialogueEntryValid
		{
			get
			{
				return this.isDialogueEntryValid;
			}
			set
			{
				this.isDialogueEntryValid = value;
				if (this.conversationController != null)
				{
					this.conversationController.IsDialogueEntryValid = value;
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00003888 File Offset: 0x00001A88
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00003890 File Offset: 0x00001A90
		public GetInputButtonDownDelegate GetInputButtonDown { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000389C File Offset: 0x00001A9C
		public bool IsConversationActive
		{
			get
			{
				return this.conversationController != null && this.conversationController.IsActive;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000038B8 File Offset: 0x00001AB8
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000038C0 File Offset: 0x00001AC0
		public Transform CurrentActor { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000038CC File Offset: 0x00001ACC
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000038D4 File Offset: 0x00001AD4
		public Transform CurrentConversant { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000038E0 File Offset: 0x00001AE0
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000038E8 File Offset: 0x00001AE8
		public ConversationState CurrentConversationState { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000038F4 File Offset: 0x00001AF4
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000038FC File Offset: 0x00001AFC
		public string LastConversationStarted { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003908 File Offset: 0x00001B08
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003910 File Offset: 0x00001B10
		public int LastConversationID { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000391C File Offset: 0x00001B1C
		public ConversationController ConversationController
		{
			get
			{
				return this.conversationController;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003924 File Offset: 0x00001B24
		public ConversationModel ConversationModel
		{
			get
			{
				return (this.conversationController == null) ? null : this.conversationController.ConversationModel;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003944 File Offset: 0x00001B44
		public ConversationView ConversationView
		{
			get
			{
				return (this.conversationController == null) ? null : this.conversationController.ConversationView;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003964 File Offset: 0x00001B64
		public List<ActiveConversationRecord> ActiveConversations
		{
			get
			{
				return this.activeConversations;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000396C File Offset: 0x00001B6C
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00003974 File Offset: 0x00001B74
		public bool AllowLuaExceptions { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003980 File Offset: 0x00001B80
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00003988 File Offset: 0x00001B88
		public bool WarnIfActorAndConversantSame { get; set; }

		// Token: 0x060000BA RID: 186 RVA: 0x00003994 File Offset: 0x00001B94
		public void OnDestroy()
		{
			if (this.dontDestroyOnLoad && this.allowOnlyOneInstance)
			{
				DialogueSystemController.applicationIsQuitting = true;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000039B4 File Offset: 0x00001BB4
		public void Awake()
		{
			if (this.allowOnlyOneInstance && Object.FindObjectsOfType(typeof(DialogueSystemController)).Length > 1)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				this.GetInputButtonDown = new GetInputButtonDownDelegate(this.StandardGetInputButtonDown);
				if (this.instantiateDatabase && this.initialDatabase != null)
				{
					DialogueDatabase dialogueDatabase = Object.Instantiate<DialogueDatabase>(this.initialDatabase);
					dialogueDatabase.name = this.initialDatabase.name;
					this.initialDatabase = dialogueDatabase;
				}
				bool flag = this.displaySettings != null && this.displaySettings.inputSettings != null && this.displaySettings.inputSettings.emTagForOldResponses != EmTag.None;
				DialogueLua.includeSimStatus = this.includeSimStatus || flag;
				PersistentDataManager.includeSimStatus = DialogueLua.includeSimStatus;
				PersistentDataManager.includeActorData = this.persistentDataSettings.includeActorData;
				PersistentDataManager.includeAllItemData = this.persistentDataSettings.includeAllItemData;
				PersistentDataManager.includeLocationData = this.persistentDataSettings.includeLocationData;
				PersistentDataManager.includeRelationshipAndStatusData = this.persistentDataSettings.includeStatusAndRelationshipData;
				PersistentDataManager.includeAllConversationFields = this.persistentDataSettings.includeAllConversationFields;
				PersistentDataManager.saveConversationSimStatusWithField = this.persistentDataSettings.saveConversationSimStatusWithField;
				PersistentDataManager.saveDialogueEntrySimStatusWithField = this.persistentDataSettings.saveDialogueEntrySimStatusWithField;
				PersistentDataManager.recordPersistentDataOn = this.persistentDataSettings.recordPersistentDataOn;
				PersistentDataManager.asyncGameObjectBatchSize = this.persistentDataSettings.asyncGameObjectBatchSize;
				PersistentDataManager.asyncDialogueEntryBatchSize = this.persistentDataSettings.asyncDialogueEntryBatchSize;
				if (this.dontDestroyOnLoad)
				{
					if (base.transform.parent != null)
					{
						base.transform.SetParent(null, false);
					}
					Object.DontDestroyOnLoad(base.gameObject);
				}
				this.AllowLuaExceptions = false;
				this.WarnIfActorAndConversantSame = false;
				DialogueDebug.Level = this.debugLevel;
				this.lastDebugLevelSet = this.debugLevel;
				this.LastConversationStarted = string.Empty;
				this.LastConversationID = -1;
				this.CurrentActor = null;
				this.CurrentConversant = null;
				this.CurrentConversationState = null;
				this.InitializeDatabase();
				this.InitializeDisplaySettings();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003BCC File Offset: 0x00001DCC
		public bool StandardGetInputButtonDown(string buttonName)
		{
			return Input.GetButtonDown(buttonName);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003BD4 File Offset: 0x00001DD4
		private bool DisabledGetInputButtonDown(string buttonName)
		{
			return false;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003BD8 File Offset: 0x00001DD8
		public bool IsDialogueSystemInputDisabled()
		{
			return this.GetInputButtonDown == new GetInputButtonDownDelegate(this.DisabledGetInputButtonDown);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003BF4 File Offset: 0x00001DF4
		public void SetDialogueSystemInput(bool value)
		{
			if (value)
			{
				if (this.IsDialogueSystemInputDisabled())
				{
					this.GetInputButtonDown = this.savedGetInputButtonDownDelegate ?? new GetInputButtonDownDelegate(this.StandardGetInputButtonDown);
				}
			}
			else if (!this.IsDialogueSystemInputDisabled())
			{
				this.savedGetInputButtonDownDelegate = this.GetInputButtonDown;
				this.GetInputButtonDown = new GetInputButtonDownDelegate(this.DisabledGetInputButtonDown);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003C60 File Offset: 0x00001E60
		public void Start()
		{
			base.StartCoroutine(this.MonitorAlerts());
			this.hasStarted = true;
			if (this.preloadResources)
			{
				this.PreloadResources();
			}
			QuestLog.RegisterQuestLogFunctions();
			this.RegisterLuaFunctions();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003CA0 File Offset: 0x00001EA0
		private void InitializeDisplaySettings()
		{
			if (this.displaySettings == null)
			{
				this.displaySettings = new DisplaySettings();
				this.displaySettings.cameraSettings = new DisplaySettings.CameraSettings();
				this.displaySettings.inputSettings = new DisplaySettings.InputSettings();
				this.displaySettings.inputSettings.cancel = new InputTrigger(KeyCode.Escape);
				this.displaySettings.inputSettings.qteButtons = new string[] { "Fire1", "Fire2" };
				this.displaySettings.subtitleSettings = new DisplaySettings.SubtitleSettings();
				this.displaySettings.localizationSettings = new DisplaySettings.LocalizationSettings();
			}
			if (this.displaySettings.localizationSettings.useSystemLanguage)
			{
				this.displaySettings.localizationSettings.language = Localization.GetLanguage(Application.systemLanguage);
			}
			Localization.Language = this.displaySettings.localizationSettings.language;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003D84 File Offset: 0x00001F84
		public void SetLanguage(string language)
		{
			this.displaySettings.localizationSettings.language = language;
			Localization.Language = language;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003DA0 File Offset: 0x00001FA0
		private void CheckDebugLevel()
		{
			if (this.debugLevel != this.lastDebugLevelSet)
			{
				DialogueDebug.Level = this.debugLevel;
				this.lastDebugLevelSet = this.debugLevel;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003DD8 File Offset: 0x00001FD8
		private void InitializeDatabase()
		{
			this.databaseManager = new DatabaseManager(this.initialDatabase);
			if (this.initialDatabase != null && this.initialDatabase.name == DialogueSystemController.lastInitialDatabaseName)
			{
				this.databaseManager.Add(this.initialDatabase);
			}
			else
			{
				this.databaseManager.Reset(DatabaseResetOptions.KeepAllLoaded);
			}
			if (this.initialDatabase != null)
			{
				DialogueSystemController.lastInitialDatabaseName = this.initialDatabase.name;
			}
			if (DialogueDebug.LogWarnings && this.initialDatabase == null)
			{
				Debug.LogWarning(string.Format("{0}: No dialogue database is assigned.", new object[] { "Dialogue System" }));
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003E9C File Offset: 0x0000209C
		public void AddDatabase(DialogueDatabase database)
		{
			if (this.databaseManager != null)
			{
				this.databaseManager.Add(database);
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003EB8 File Offset: 0x000020B8
		public void RemoveDatabase(DialogueDatabase database)
		{
			if (this.databaseManager != null)
			{
				this.databaseManager.Remove(database);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003ED4 File Offset: 0x000020D4
		public void ResetDatabase(DatabaseResetOptions databaseResetOptions)
		{
			if (this.databaseManager != null)
			{
				this.databaseManager.Reset(databaseResetOptions);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003EF0 File Offset: 0x000020F0
		public void PreloadMasterDatabase()
		{
			DialogueDatabase masterDatabase = this.MasterDatabase;
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Loaded master database '{1}'", new object[] { "Dialogue System", masterDatabase.name }));
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003F34 File Offset: 0x00002134
		public void PreloadDialogueUI()
		{
			if (this.DialogueUI == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Unable to load the dialogue UI.", "Dialogue System"));
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003F6C File Offset: 0x0000216C
		public bool ConversationHasValidEntry(string title, Transform actor, Transform conversant)
		{
			if (string.IsNullOrEmpty(title))
			{
				return false;
			}
			ConversationModel conversationModel = new ConversationModel(this.databaseManager.MasterDatabase, title, actor, conversant, this.AllowLuaExceptions, this.IsDialogueEntryValid, -1, false, false);
			return conversationModel.HasValidEntry;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003FB0 File Offset: 0x000021B0
		public bool ConversationHasValidEntry(string title, Transform actor)
		{
			return this.ConversationHasValidEntry(title, actor, null);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003FBC File Offset: 0x000021BC
		public bool ConversationHasValidEntry(string title)
		{
			return this.ConversationHasValidEntry(title, null, null);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003FC8 File Offset: 0x000021C8
		public void PreloadResources()
		{
			this.PreloadMasterDatabase();
			this.PreloadDialogueUI();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003FD8 File Offset: 0x000021D8
		public void StartConversation(string title, Transform actor, Transform conversant, int initialDialogueEntryID)
		{
			if (this.IsConversationActive && !this.allowSimultaneousConversations)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Another conversation is already active. Not starting '{1}'.", new object[] { "Dialogue System", title }));
				}
			}
			else if (this.DialogueUI == null)
			{
				if (DialogueDebug.LogErrors)
				{
					Debug.LogError(string.Format("{0}: No Dialogue UI is assigned. Can't start conversation '{1}'.", new object[] { "Dialogue System", title }));
				}
			}
			else
			{
				if (actor == null)
				{
					actor = this.FindActorTransformFromConversation(title, "Actor");
				}
				if (conversant == null)
				{
					conversant = this.FindActorTransformFromConversation(title, "Conversant");
				}
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Starting conversation '{1}', actor={2}, conversant={3}.", new object[] { "Dialogue System", title, actor, conversant }), actor);
				}
				if (this.WarnIfActorAndConversantSame && actor != null && actor == conversant && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Actor and conversant are the same GameObject.", new object[] { "Dialogue System" }));
				}
				this.CheckDebugLevel();
				this.CurrentActor = actor;
				this.CurrentConversant = conversant;
				this.LastConversationStarted = title;
				this.SetConversationUI(actor, conversant);
				ConversationModel conversationModel = new ConversationModel(this.databaseManager.MasterDatabase, title, actor, conversant, this.AllowLuaExceptions, this.IsDialogueEntryValid, initialDialogueEntryID, false, false);
				if (!conversationModel.HasValidEntry)
				{
					return;
				}
				if (conversationModel.FirstState != null && conversationModel.FirstState.subtitle != null && conversationModel.FirstState.subtitle.dialogueEntry != null)
				{
					this.LastConversationID = conversationModel.FirstState.subtitle.dialogueEntry.conversationID;
				}
				ConversationView conversationView = base.gameObject.AddComponent<ConversationView>();
				conversationView.Initialize(this.DialogueUI, this.GetNewSequencer(), this.displaySettings, new DialogueEntrySpokenDelegate(this.OnDialogueEntrySpoken));
				conversationView.SetPCPortrait(conversationModel.GetPCTexture(), conversationModel.GetPCName());
				this.conversationController = new ConversationController(conversationModel, conversationView, this.displaySettings.inputSettings.alwaysForceResponseMenu, new ConversationController.EndConversationDelegate(this.OnEndConversation));
				Transform transform = ((!(actor != null)) ? base.transform : actor);
				if (actor != base.transform)
				{
					base.gameObject.BroadcastMessage("OnConversationStart", transform, SendMessageOptions.DontRequireReceiver);
				}
				ActiveConversationRecord activeConversationRecord = new ActiveConversationRecord();
				activeConversationRecord.Actor = actor;
				activeConversationRecord.Conversant = conversant;
				activeConversationRecord.ConversationController = this.conversationController;
				activeConversationRecord.originalDialogueUI = this.originalDialogueUI;
				activeConversationRecord.originalDisplaySettings = this.originalDisplaySettings;
				activeConversationRecord.isOverrideUIPrefab = this.isOverrideUIPrefab;
				this.activeConversations.Add(activeConversationRecord);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000042B0 File Offset: 0x000024B0
		public void StartConversation(string title, Transform actor, Transform conversant)
		{
			this.StartConversation(title, actor, conversant, -1);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000042BC File Offset: 0x000024BC
		public void StartConversation(string title, Transform actor)
		{
			this.StartConversation(title, actor, null, -1);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000042C8 File Offset: 0x000024C8
		public void StartConversation(string title)
		{
			this.StartConversation(title, null, null, -1);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000042D4 File Offset: 0x000024D4
		public void StopConversation()
		{
			if (this.conversationController != null)
			{
				this.conversationController.Close();
				this.conversationController = null;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000042F4 File Offset: 0x000024F4
		public void UpdateResponses()
		{
			if (this.conversationController != null)
			{
				this.conversationController.UpdateResponses();
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000430C File Offset: 0x0000250C
		public Transform FindActorTransformFromConversation(string conversationTitle, string actorField)
		{
			Conversation conversation = this.MasterDatabase.GetConversation(conversationTitle);
			if (conversation == null)
			{
				return null;
			}
			Actor actor = this.MasterDatabase.GetActor(conversation.LookupInt(actorField));
			if (actor == null)
			{
				return null;
			}
			GameObject gameObject = SequencerTools.FindSpecifier(actor.Name, true);
			return (!(gameObject != null)) ? null : gameObject.transform;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004370 File Offset: 0x00002570
		public void SetPortrait(string actorName, string portraitName)
		{
			Actor actor = this.MasterDatabase.GetActor(actorName);
			if (actor == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: SetPortrait({1}, {2}): actor '{1}' not found.", new object[] { "Dialogue System", actorName, portraitName }));
				}
				return;
			}
			Texture2D texture2D;
			if (string.IsNullOrEmpty(portraitName) || string.Equals(portraitName, "default"))
			{
				DialogueLua.SetActorField(actorName, "Current Portrait", string.Empty);
				texture2D = actor.portrait;
			}
			else
			{
				DialogueLua.SetActorField(actorName, "Current Portrait", portraitName);
				if (portraitName.StartsWith("pic="))
				{
					texture2D = actor.GetPortraitTexture(Tools.StringToInt(portraitName.Substring("pic=".Length)));
				}
				else
				{
					texture2D = DialogueManager.LoadAsset(portraitName) as Texture2D;
				}
			}
			if (DialogueDebug.LogWarnings && texture2D == null)
			{
				Debug.LogWarning(string.Format("{0}: SetPortrait({1}, {2}): portrait texture not found.", new object[] { "Dialogue System", actorName, portraitName }));
			}
			this.SetActorPortraitTexture(actorName, texture2D);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004488 File Offset: 0x00002688
		public void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (this.IsConversationActive && this.conversationController != null)
			{
				this.conversationController.SetActorPortraitTexture(actorName, portraitTexture);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000044B0 File Offset: 0x000026B0
		private void SetConversationUI(Transform actor, Transform conversant)
		{
			OverrideUIBase overrideUIBase = this.FindHighestPriorityOverrideUI(actor, conversant);
			if (overrideUIBase != null)
			{
				this.ApplyOverrideUI(overrideUIBase);
			}
			this.ValidateCurrentDialogueUI();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000044E0 File Offset: 0x000026E0
		private OverrideUIBase FindHighestPriorityOverrideUI(Transform actor, Transform conversant)
		{
			OverrideUIBase overrideUIBase = this.FindOverrideUI(actor);
			OverrideUIBase overrideUIBase2 = this.FindOverrideUI(conversant);
			if (!(overrideUIBase != null))
			{
				return overrideUIBase2;
			}
			if (overrideUIBase2 != null)
			{
				return (overrideUIBase.priority <= overrideUIBase2.priority) ? overrideUIBase2 : overrideUIBase;
			}
			return overrideUIBase;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004534 File Offset: 0x00002734
		private OverrideUIBase FindOverrideUI(Transform character)
		{
			if (character == null)
			{
				return null;
			}
			OverrideUIBase componentInChildren = character.GetComponentInChildren<OverrideUIBase>();
			OverrideDialogueUI overrideDialogueUI = componentInChildren as OverrideDialogueUI;
			OverrideDisplaySettings overrideDisplaySettings = componentInChildren as OverrideDisplaySettings;
			return (!(componentInChildren != null) || !componentInChildren.enabled || ((!(overrideDialogueUI != null) || !(overrideDialogueUI.ui != null)) && !(overrideDisplaySettings != null))) ? null : componentInChildren;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000045AC File Offset: 0x000027AC
		private void ApplyOverrideUI(OverrideUIBase overrideUI)
		{
			OverrideDialogueUI overrideDialogueUI = overrideUI as OverrideDialogueUI;
			OverrideDisplaySettings overrideDisplaySettings = overrideUI as OverrideDisplaySettings;
			if (overrideDialogueUI != null)
			{
				this.isOverrideUIPrefab = Tools.IsPrefab(overrideDialogueUI.ui);
				this.originalDialogueUI = this.DialogueUI;
				this.displaySettings.dialogueUI = overrideDialogueUI.ui;
				this.currentDialogueUI = null;
			}
			else if (overrideDisplaySettings)
			{
				if (overrideDisplaySettings.displaySettings.dialogueUI != null)
				{
					this.isOverrideUIPrefab = Tools.IsPrefab(overrideDisplaySettings.displaySettings.dialogueUI);
					this.originalDialogueUI = this.DialogueUI;
					this.currentDialogueUI = null;
				}
				this.originalDisplaySettings = this.displaySettings;
				this.displaySettings = overrideDisplaySettings.displaySettings;
				if (overrideDisplaySettings.displaySettings.dialogueUI == null)
				{
					overrideDisplaySettings.displaySettings.dialogueUI = this.originalDisplaySettings.dialogueUI;
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000469C File Offset: 0x0000289C
		private void RestoreOriginalUI()
		{
			if (this.originalDisplaySettings != null)
			{
				this.displaySettings = this.originalDisplaySettings;
			}
			if (this.originalDialogueUI != null)
			{
				if (this.isOverrideUIPrefab)
				{
					MonoBehaviour monoBehaviour = this.currentDialogueUI as MonoBehaviour;
					if (monoBehaviour != null)
					{
						Object.Destroy(monoBehaviour.gameObject);
					}
				}
				this.currentDialogueUI = this.originalDialogueUI;
				this.displaySettings.dialogueUI = (this.originalDialogueUI as MonoBehaviour).gameObject;
			}
			this.isOverrideUIPrefab = false;
			this.originalDialogueUI = null;
			this.originalDisplaySettings = null;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004738 File Offset: 0x00002938
		private void OnDialogueEntrySpoken(Subtitle subtitle)
		{
			this.luaWatchers.NotifyObservers(LuaWatchFrequency.EveryDialogueEntry);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004748 File Offset: 0x00002948
		public void OnEndConversation(ConversationController endingConversationController)
		{
			ActiveConversationRecord activeConversationRecord = this.activeConversations.Find((ActiveConversationRecord r) => r.ConversationController == endingConversationController);
			this.activeConversations.Remove(activeConversationRecord);
			if (this.activeConversations.Count > 0)
			{
				ActiveConversationRecord activeConversationRecord2 = this.activeConversations[0];
				this.conversationController = activeConversationRecord2.ConversationController;
				this.CurrentActor = activeConversationRecord2.Actor;
				this.CurrentConversant = activeConversationRecord2.Conversant;
			}
			else
			{
				this.conversationController = null;
				this.CurrentActor = null;
				this.CurrentConversant = null;
			}
			this.originalDialogueUI = activeConversationRecord.originalDialogueUI;
			this.originalDisplaySettings = activeConversationRecord.originalDisplaySettings;
			this.isOverrideUIPrefab = activeConversationRecord.isOverrideUIPrefab;
			this.RestoreOriginalUI();
			this.luaWatchers.NotifyObservers(LuaWatchFrequency.EndOfConversation);
			this.CheckAlerts();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004820 File Offset: 0x00002A20
		public void OnConversationTimeout()
		{
			if (this.IsConversationActive)
			{
				switch (this.displaySettings.inputSettings.responseTimeoutAction)
				{
				case ResponseTimeoutAction.ChooseFirstResponse:
					base.StartCoroutine(this.ChooseResponseAfterOneFrame(true));
					break;
				case ResponseTimeoutAction.ChooseRandomResponse:
					base.StartCoroutine(this.ChooseResponseAfterOneFrame(false));
					break;
				case ResponseTimeoutAction.EndConversation:
					this.StopConversation();
					break;
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004894 File Offset: 0x00002A94
		private IEnumerator ChooseResponseAfterOneFrame(bool chooseFirstResponse)
		{
			yield return null;
			if (this.IsConversationActive)
			{
				if (chooseFirstResponse)
				{
					this.conversationController.GotoFirstResponse();
				}
				else
				{
					this.conversationController.GotoRandomResponse();
				}
			}
			yield break;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000048C0 File Offset: 0x00002AC0
		public void Bark(string conversationTitle, Transform speaker, Transform listener, BarkHistory barkHistory)
		{
			this.CheckDebugLevel();
			base.StartCoroutine(BarkController.Bark(conversationTitle, speaker, listener, barkHistory, null, false));
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000048E8 File Offset: 0x00002AE8
		public void Bark(string conversationTitle, Transform speaker, Transform listener)
		{
			this.Bark(conversationTitle, speaker, listener, new BarkHistory(BarkOrder.Random));
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000048FC File Offset: 0x00002AFC
		public void Bark(string conversationTitle, Transform speaker)
		{
			this.Bark(conversationTitle, speaker, null, new BarkHistory(BarkOrder.Random));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004910 File Offset: 0x00002B10
		public void Bark(string conversationTitle, Transform speaker, BarkHistory barkHistory)
		{
			this.Bark(conversationTitle, speaker, null, barkHistory);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000491C File Offset: 0x00002B1C
		public void BarkString(string barkText, Transform speaker, Transform listener = null, string sequence = null)
		{
			if (speaker == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Can't bark '" + barkText + "'. No speaker specified.");
				}
				return;
			}
			CharacterInfo characterInfoFromTransform = this.GetCharacterInfoFromTransform(speaker);
			CharacterInfo characterInfoFromTransform2 = this.GetCharacterInfoFromTransform(listener);
			FormattedText formattedText = FormattedText.Parse(barkText, this.MasterDatabase.emphasisSettings);
			if (sequence == null)
			{
				sequence = string.Empty;
			}
			string empty = string.Empty;
			DialogueEntry dialogueEntry = null;
			Subtitle subtitle = new Subtitle(characterInfoFromTransform, characterInfoFromTransform2, formattedText, sequence, empty, dialogueEntry);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Concat(new object[] { "Dialogue System: ", speaker, " barking string '", barkText, "'." }));
			}
			base.StartCoroutine(BarkController.Bark(subtitle, false));
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000049E8 File Offset: 0x00002BE8
		public float GetBarkDuration(string barkText)
		{
			float num = this.displaySettings.barkSettings.minBarkSeconds;
			if (Mathf.Approximately(0f, num))
			{
				num = this.displaySettings.subtitleSettings.minSubtitleSeconds;
			}
			float num2 = this.displaySettings.barkSettings.barkCharsPerSecond;
			if (Mathf.Approximately(0f, num2))
			{
				num2 = this.displaySettings.subtitleSettings.subtitleCharsPerSecond;
			}
			return (!string.IsNullOrEmpty(barkText)) ? Mathf.Max(num, (float)barkText.Length / num2) : 0f;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004A80 File Offset: 0x00002C80
		private CharacterInfo GetCharacterInfoFromTransform(Transform actorTransform)
		{
			string actorName = OverrideActorName.GetActorName(actorTransform);
			Actor actor = this.MasterDatabase.GetActor(actorName);
			int num = ((actor == null) ? 1 : actor.id);
			Texture2D texture2D = ((actor == null) ? null : actor.portrait);
			return new CharacterInfo(num, actorName, actorTransform, CharacterType.NPC, texture2D);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004AD4 File Offset: 0x00002CD4
		public void ShowAlert(string message, float duration)
		{
			if (this.DialogueUI != null)
			{
				this.DialogueUI.ShowAlert(this.GetLocalizedText(message), duration);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004B00 File Offset: 0x00002D00
		public void ShowAlert(string message)
		{
			float num = this.displaySettings.alertSettings.minAlertSeconds;
			if (Mathf.Approximately(0f, num))
			{
				num = this.displaySettings.subtitleSettings.minSubtitleSeconds;
			}
			float num2 = this.displaySettings.alertSettings.alertCharsPerSecond;
			if (Mathf.Approximately(0f, num2))
			{
				num2 = this.displaySettings.subtitleSettings.subtitleCharsPerSecond;
			}
			float num3 = ((!string.IsNullOrEmpty(message)) ? Mathf.Max(num, (float)message.Length / num2) : 0f);
			this.ShowAlert(message, num3);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004BA0 File Offset: 0x00002DA0
		public void CheckAlerts()
		{
			if (this.displaySettings.alertSettings.allowAlertsDuringConversations || !this.IsConversationActive)
			{
				string asString = DialogueLua.GetVariable("Alert").AsString;
				if (!string.IsNullOrEmpty(asString))
				{
					Lua.Run("Variable['Alert'] = ''");
					this.ShowAlert(asString);
				}
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004C00 File Offset: 0x00002E00
		private IEnumerator MonitorAlerts()
		{
			if (this.displaySettings == null || this.displaySettings.alertSettings == null || Tools.ApproximatelyZero(this.displaySettings.alertSettings.alertCheckFrequency))
			{
				yield break;
			}
			float currentFrequency = this.displaySettings.alertSettings.alertCheckFrequency;
			WaitForSeconds waitForSeconds = new WaitForSeconds(this.displaySettings.alertSettings.alertCheckFrequency);
			for (;;)
			{
				if (currentFrequency != this.displaySettings.alertSettings.alertCheckFrequency)
				{
					waitForSeconds = new WaitForSeconds(this.displaySettings.alertSettings.alertCheckFrequency);
				}
				yield return waitForSeconds;
				this.CheckAlerts();
			}
			yield break;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004C1C File Offset: 0x00002E1C
		public string GetLocalizedText(string s)
		{
			if (this.displaySettings.localizationSettings.localizedText == null)
			{
				return s;
			}
			string text = this.displaySettings.localizationSettings.localizedText[s];
			return (!string.IsNullOrEmpty(text)) ? text : s;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004C70 File Offset: 0x00002E70
		public Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone, string entrytag)
		{
			this.CheckDebugLevel();
			Sequencer newSequencer = this.GetNewSequencer();
			newSequencer.Open();
			newSequencer.entrytag = entrytag;
			newSequencer.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone);
			return newSequencer;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004CA8 File Offset: 0x00002EA8
		public Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone)
		{
			return this.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone, string.Empty);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004CBC File Offset: 0x00002EBC
		public Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants)
		{
			return this.PlaySequence(sequence, speaker, listener, informParticipants, true, string.Empty);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004CD0 File Offset: 0x00002ED0
		public Sequencer PlaySequence(string sequence, Transform speaker, Transform listener)
		{
			return this.PlaySequence(sequence, speaker, listener, true);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004CDC File Offset: 0x00002EDC
		public Sequencer PlaySequence(string sequence)
		{
			return this.PlaySequence(sequence, null, null, false);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004CE8 File Offset: 0x00002EE8
		public void StopSequence(Sequencer sequencer)
		{
			if (sequencer != null)
			{
				sequencer.Close();
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004CFC File Offset: 0x00002EFC
		public void Pause()
		{
			DialogueTime.IsPaused = true;
			this.BroadcastDialogueSystemMessage("OnDialogueSystemPause");
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004D10 File Offset: 0x00002F10
		public void Unpause()
		{
			DialogueTime.IsPaused = false;
			this.BroadcastDialogueSystemMessage("OnDialogueSystemUnpause");
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004D24 File Offset: 0x00002F24
		private void BroadcastDialogueSystemMessage(string message)
		{
			base.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
			if (this.IsConversationActive)
			{
				if (this.CurrentActor != null)
				{
					this.CurrentActor.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
				}
				if (this.CurrentConversant != null)
				{
					this.CurrentConversant.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004D80 File Offset: 0x00002F80
		public void UseDialogueUI(GameObject gameObject)
		{
			this.currentDialogueUI = null;
			this.displaySettings.dialogueUI = gameObject;
			this.ValidateCurrentDialogueUI();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004D9C File Offset: 0x00002F9C
		private IDialogueUI GetDialogueUI()
		{
			this.ValidateCurrentDialogueUI();
			return this.currentDialogueUI;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004DAC File Offset: 0x00002FAC
		private void SetDialogueUI(IDialogueUI ui)
		{
			MonoBehaviour monoBehaviour = ui as MonoBehaviour;
			if (monoBehaviour != null)
			{
				this.displaySettings.dialogueUI = monoBehaviour.gameObject;
				this.currentDialogueUI = null;
				this.ValidateCurrentDialogueUI();
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004DEC File Offset: 0x00002FEC
		private void ValidateCurrentDialogueUI()
		{
			if (this.currentDialogueUI == null)
			{
				this.GetDialogueUIFromDisplaySettings();
				if (this.currentDialogueUI == null)
				{
					this.currentDialogueUI = this.LoadDefaultDialogueUI();
				}
				MonoBehaviour monoBehaviour = this.currentDialogueUI as MonoBehaviour;
				if (monoBehaviour != null)
				{
					this.displaySettings.dialogueUI = monoBehaviour.gameObject;
				}
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004E4C File Offset: 0x0000304C
		private void GetDialogueUIFromDisplaySettings()
		{
			if (this.displaySettings.dialogueUI != null)
			{
				IDialogueUI dialogueUI2;
				if (Tools.IsPrefab(this.displaySettings.dialogueUI))
				{
					IDialogueUI dialogueUI = this.LoadDialogueUIPrefab(this.displaySettings.dialogueUI);
					dialogueUI2 = dialogueUI;
				}
				else
				{
					dialogueUI2 = this.displaySettings.dialogueUI.GetComponentInChildren(typeof(IDialogueUI)) as IDialogueUI;
				}
				this.currentDialogueUI = dialogueUI2;
				if (this.currentDialogueUI == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: No Dialogue UI found on '{1}'. Is the GameObject active and the dialogue UI script enabled? (Will load default UI for now.)", new object[]
					{
						"Dialogue System",
						this.displaySettings.dialogueUI
					}), this.displaySettings.dialogueUI);
				}
			}
			else
			{
				this.currentDialogueUI = base.GetComponentInChildren(typeof(IDialogueUI)) as IDialogueUI;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004F2C File Offset: 0x0000312C
		private IDialogueUI LoadDefaultDialogueUI()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Loading default Dialogue UI '{1}'.", new object[] { "Dialogue System", "Default Dialogue UI" }));
			}
			GameObject gameObject = DialogueManager.LoadAsset("Default Dialogue UI") as GameObject;
			if (gameObject == null)
			{
				Debug.LogError("Dialogue System: Can't load Default Dialogue UI! Did you delete this file from Dialogue System/Prefabs/Legacy Unity GUI Prefabs/Default/Resources? If so, add it back, or assign a dialogue UI to the Dialogue Manager so it doesn't have to try to load the default UI.");
				return null;
			}
			return this.LoadDialogueUIPrefab(gameObject);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004F98 File Offset: 0x00003198
		private IDialogueUI LoadDialogueUIPrefab(GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(prefab);
			IDialogueUI dialogueUI = null;
			if (gameObject != null)
			{
				gameObject.transform.SetParent(base.transform, false);
				dialogueUI = gameObject.GetComponentInChildren(typeof(IDialogueUI)) as IDialogueUI;
				if (dialogueUI == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: No Dialogue UI component found on {1}.", new object[] { "Dialogue System", prefab }));
					}
					Object.Destroy(gameObject);
				}
			}
			return dialogueUI;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000501C File Offset: 0x0000321C
		private Sequencer GetNewSequencer()
		{
			Sequencer sequencer = base.gameObject.AddComponent<Sequencer>();
			if (sequencer != null)
			{
				sequencer.UseCamera(this.displaySettings.cameraSettings.sequencerCamera, this.displaySettings.cameraSettings.alternateCameraObject, this.displaySettings.cameraSettings.cameraAngles);
				sequencer.disableInternalSequencerCommands = this.displaySettings.cameraSettings.disableInternalSequencerCommands;
			}
			return sequencer;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005090 File Offset: 0x00003290
		private void RegisterLuaFunctions()
		{
			Lua.RegisterFunction("ShowAlert", null, SymbolExtensions.GetMethodInfo(() => DialogueSystemController.LuaShowAlert(string.Empty)));
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000050E8 File Offset: 0x000032E8
		public static void LuaShowAlert(string message)
		{
			DialogueManager.ShowAlert(message);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000050F0 File Offset: 0x000032F0
		public void AddLuaObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			base.StartCoroutine(this.AddLuaObserverAfterStart(luaExpression, frequency, luaChangedHandler));
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005104 File Offset: 0x00003304
		private IEnumerator AddLuaObserverAfterStart(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			int MaxFramesToWait = 10;
			int framesWaited = 0;
			while (!this.hasStarted && framesWaited < MaxFramesToWait)
			{
				framesWaited++;
				yield return null;
			}
			yield return null;
			this.luaWatchers.AddObserver(luaExpression, frequency, luaChangedHandler);
			yield break;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000514C File Offset: 0x0000334C
		public void RemoveLuaObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			this.luaWatchers.RemoveObserver(luaExpression, frequency, luaChangedHandler);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000515C File Offset: 0x0000335C
		public void RemoveAllObservers(LuaWatchFrequency frequency)
		{
			this.luaWatchers.RemoveAllObservers(frequency);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000516C File Offset: 0x0000336C
		public void RemoveAllObservers()
		{
			this.luaWatchers.RemoveAllObservers();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000517C File Offset: 0x0000337C
		private void Update()
		{
			if (Lua.WasInvoked)
			{
				this.luaWatchers.NotifyObservers(LuaWatchFrequency.EveryUpdate);
				Lua.WasInvoked = false;
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000519C File Offset: 0x0000339C
		public void RegisterAssetBundle(AssetBundle bundle)
		{
			this.assetBundleManager.RegisterAssetBundle(bundle);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000051AC File Offset: 0x000033AC
		public void UnregisterAssetBundle(AssetBundle bundle)
		{
			this.assetBundleManager.UnregisterAssetBundle(bundle);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000051BC File Offset: 0x000033BC
		public Object LoadAsset(string name)
		{
			return this.assetBundleManager.Load(name);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000051CC File Offset: 0x000033CC
		public Object LoadAsset(string name, Type type)
		{
			return this.assetBundleManager.Load(name, type);
		}

		// Token: 0x04000028 RID: 40
		private const string DefaultDialogueUIResourceName = "Default Dialogue UI";

		// Token: 0x04000029 RID: 41
		[Tooltip("This dialogue database is loaded automatically. Use an Extra Databases component to load additional databases.")]
		public DialogueDatabase initialDatabase;

		// Token: 0x0400002A RID: 42
		public DisplaySettings displaySettings = new DisplaySettings();

		// Token: 0x0400002B RID: 43
		public PersistentDataSettings persistentDataSettings = new PersistentDataSettings();

		// Token: 0x0400002C RID: 44
		[Tooltip("Allow more than one conversation to play simultaneously.")]
		public bool allowSimultaneousConversations;

		// Token: 0x0400002D RID: 45
		[Tooltip("Tick if your conversations reference Dialog[x].SimStatus.")]
		public bool includeSimStatus;

		// Token: 0x0400002E RID: 46
		[Tooltip("Preload the dialogue database and dialogue UI at Start. Otherwise they're loaded at first use.")]
		public bool preloadResources;

		// Token: 0x0400002F RID: 47
		[Tooltip("Use a copy of the dialogue database at runtime instead of the asset file directly. This allows you to change the database without affecting the asset.")]
		public bool instantiateDatabase;

		// Token: 0x04000030 RID: 48
		[Tooltip("Retain this GameObject when changing levels.")]
		public bool dontDestroyOnLoad = true;

		// Token: 0x04000031 RID: 49
		[Tooltip("Ensure only one Dialogue Manager in the scene.")]
		public bool allowOnlyOneInstance = true;

		// Token: 0x04000032 RID: 50
		[Tooltip("Set to higher levels for troubleshooting.")]
		public DialogueDebug.DebugLevel debugLevel = DialogueDebug.DebugLevel.Warning;

		// Token: 0x04000033 RID: 51
		private DatabaseManager databaseManager;

		// Token: 0x04000034 RID: 52
		private IDialogueUI currentDialogueUI;

		// Token: 0x04000035 RID: 53
		[HideInInspector]
		private IDialogueUI originalDialogueUI;

		// Token: 0x04000036 RID: 54
		[HideInInspector]
		private DisplaySettings originalDisplaySettings;

		// Token: 0x04000037 RID: 55
		private bool isOverrideUIPrefab;

		// Token: 0x04000038 RID: 56
		private ConversationController conversationController;

		// Token: 0x04000039 RID: 57
		private IsDialogueEntryValidDelegate isDialogueEntryValid;

		// Token: 0x0400003A RID: 58
		private GetInputButtonDownDelegate savedGetInputButtonDownDelegate;

		// Token: 0x0400003B RID: 59
		private LuaWatchers luaWatchers = new LuaWatchers();

		// Token: 0x0400003C RID: 60
		private AssetBundleManager assetBundleManager = new AssetBundleManager();

		// Token: 0x0400003D RID: 61
		private bool hasStarted;

		// Token: 0x0400003E RID: 62
		private DialogueDebug.DebugLevel lastDebugLevelSet;

		// Token: 0x0400003F RID: 63
		private List<ActiveConversationRecord> activeConversations = new List<ActiveConversationRecord>();

		// Token: 0x04000040 RID: 64
		public static bool applicationIsQuitting;

		// Token: 0x04000041 RID: 65
		public static string lastInitialDatabaseName;
	}
}
