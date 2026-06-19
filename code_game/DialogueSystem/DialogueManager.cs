using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000C RID: 12
	public static class DialogueManager
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003328 File Offset: 0x00001528
		public static DialogueSystemController Instance
		{
			get
			{
				return DialogueManager.FindOrCreateInstance();
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003330 File Offset: 0x00001530
		public static bool HasInstance
		{
			get
			{
				return DialogueManager.instance != null;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00003340 File Offset: 0x00001540
		public static DatabaseManager DatabaseManager
		{
			get
			{
				return DialogueManager.Instance.DatabaseManager;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000334C File Offset: 0x0000154C
		public static DialogueDatabase MasterDatabase
		{
			get
			{
				return DialogueManager.Instance.MasterDatabase;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003358 File Offset: 0x00001558
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00003364 File Offset: 0x00001564
		public static IDialogueUI DialogueUI
		{
			get
			{
				return DialogueManager.Instance.DialogueUI;
			}
			set
			{
				DialogueManager.Instance.DialogueUI = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00003374 File Offset: 0x00001574
		public static DisplaySettings DisplaySettings
		{
			get
			{
				return DialogueManager.Instance.displaySettings;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003380 File Offset: 0x00001580
		public static bool IsConversationActive
		{
			get
			{
				return DialogueManager.Instance.IsConversationActive;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000338C File Offset: 0x0000158C
		public static bool AllowSimultaneousConversations
		{
			get
			{
				return DialogueManager.Instance.allowSimultaneousConversations;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003398 File Offset: 0x00001598
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000033A4 File Offset: 0x000015A4
		public static IsDialogueEntryValidDelegate IsDialogueEntryValid
		{
			get
			{
				return DialogueManager.Instance.IsDialogueEntryValid;
			}
			set
			{
				DialogueManager.Instance.IsDialogueEntryValid = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000033B4 File Offset: 0x000015B4
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000033C0 File Offset: 0x000015C0
		public static GetInputButtonDownDelegate GetInputButtonDown
		{
			get
			{
				return DialogueManager.Instance.GetInputButtonDown;
			}
			set
			{
				DialogueManager.Instance.GetInputButtonDown = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000033D0 File Offset: 0x000015D0
		public static Transform CurrentActor
		{
			get
			{
				return DialogueManager.Instance.CurrentActor;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000033DC File Offset: 0x000015DC
		public static Transform CurrentConversant
		{
			get
			{
				return DialogueManager.Instance.CurrentConversant;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000033E8 File Offset: 0x000015E8
		public static ConversationState CurrentConversationState
		{
			get
			{
				return DialogueManager.Instance.CurrentConversationState;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000033F4 File Offset: 0x000015F4
		public static string LastConversationStarted
		{
			get
			{
				return DialogueManager.Instance.LastConversationStarted;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003400 File Offset: 0x00001600
		public static int LastConversationID
		{
			get
			{
				return DialogueManager.Instance.LastConversationID;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000340C File Offset: 0x0000160C
		public static ConversationController ConversationController
		{
			get
			{
				return DialogueManager.Instance.ConversationController;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003418 File Offset: 0x00001618
		public static ConversationModel ConversationModel
		{
			get
			{
				return DialogueManager.Instance.ConversationModel;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003424 File Offset: 0x00001624
		public static ConversationView ConversationView
		{
			get
			{
				return DialogueManager.Instance.ConversationView;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003430 File Offset: 0x00001630
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000343C File Offset: 0x0000163C
		public static DialogueDebug.DebugLevel DebugLevel
		{
			get
			{
				return DialogueManager.Instance.debugLevel;
			}
			set
			{
				DialogueManager.Instance.debugLevel = value;
				DialogueDebug.Level = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003450 File Offset: 0x00001650
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000345C File Offset: 0x0000165C
		public static bool AllowLuaExceptions
		{
			get
			{
				return DialogueManager.Instance.AllowLuaExceptions;
			}
			set
			{
				DialogueManager.Instance.AllowLuaExceptions = value;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000346C File Offset: 0x0000166C
		public static void SetLanguage(string language)
		{
			DialogueManager.Instance.SetLanguage(language);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000347C File Offset: 0x0000167C
		public static void SetDialogueSystemInput(bool value)
		{
			DialogueManager.Instance.SetDialogueSystemInput(value);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000348C File Offset: 0x0000168C
		public static bool IsDialogueSystemInputDisabled()
		{
			return DialogueManager.Instance.IsDialogueSystemInputDisabled();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003498 File Offset: 0x00001698
		public static void AddDatabase(DialogueDatabase database)
		{
			DialogueManager.Instance.AddDatabase(database);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000034A8 File Offset: 0x000016A8
		public static void RemoveDatabase(DialogueDatabase database)
		{
			DialogueManager.Instance.RemoveDatabase(database);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000034B8 File Offset: 0x000016B8
		public static void ResetDatabase(DatabaseResetOptions databaseResetOptions)
		{
			DialogueManager.Instance.ResetDatabase(databaseResetOptions);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000034C8 File Offset: 0x000016C8
		public static void PreloadMasterDatabase()
		{
			DialogueManager.Instance.PreloadMasterDatabase();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000034D4 File Offset: 0x000016D4
		public static void PreloadDialogueUI()
		{
			DialogueManager.Instance.PreloadDialogueUI();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000034E0 File Offset: 0x000016E0
		public static bool ConversationHasValidEntry(string title, Transform actor, Transform conversant)
		{
			return DialogueManager.Instance.ConversationHasValidEntry(title, actor, conversant);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000034F0 File Offset: 0x000016F0
		public static bool ConversationHasValidEntry(string title, Transform actor)
		{
			return DialogueManager.Instance.ConversationHasValidEntry(title, actor, null);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003500 File Offset: 0x00001700
		public static bool ConversationHasValidEntry(string title)
		{
			return DialogueManager.Instance.ConversationHasValidEntry(title, null, null);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003510 File Offset: 0x00001710
		public static void StartConversation(string title, Transform actor, Transform conversant, int initialDialogueEntryID)
		{
			DialogueManager.Instance.StartConversation(title, actor, conversant, initialDialogueEntryID);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003520 File Offset: 0x00001720
		public static void StartConversation(string title, Transform actor, Transform conversant)
		{
			DialogueManager.Instance.StartConversation(title, actor, conversant);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003530 File Offset: 0x00001730
		public static void StartConversation(string title, Transform actor)
		{
			DialogueManager.Instance.StartConversation(title, actor);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003540 File Offset: 0x00001740
		public static void StartConversation(string title)
		{
			DialogueManager.Instance.StartConversation(title, null, null);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003550 File Offset: 0x00001750
		public static void StopConversation()
		{
			DialogueManager.Instance.StopConversation();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000355C File Offset: 0x0000175C
		public static void UpdateResponses()
		{
			DialogueManager.Instance.UpdateResponses();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003568 File Offset: 0x00001768
		public static void Bark(string conversationTitle, Transform speaker, Transform listener, BarkHistory barkHistory)
		{
			DialogueManager.Instance.Bark(conversationTitle, speaker, listener, barkHistory);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003578 File Offset: 0x00001778
		public static void Bark(string conversationTitle, Transform speaker, Transform listener)
		{
			DialogueManager.Instance.Bark(conversationTitle, speaker, listener);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003588 File Offset: 0x00001788
		public static void Bark(string conversationTitle, Transform speaker)
		{
			DialogueManager.Instance.Bark(conversationTitle, speaker);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003598 File Offset: 0x00001798
		public static void Bark(string conversationTitle, Transform speaker, BarkHistory barkHistory)
		{
			DialogueManager.Instance.Bark(conversationTitle, speaker, barkHistory);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000035A8 File Offset: 0x000017A8
		public static void BarkString(string barkText, Transform speaker, Transform listener = null, string sequence = null)
		{
			DialogueManager.Instance.BarkString(barkText, speaker, listener, sequence);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000035B8 File Offset: 0x000017B8
		public static float GetBarkDuration(string barkText)
		{
			return DialogueManager.Instance.GetBarkDuration(barkText);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000035C8 File Offset: 0x000017C8
		public static void ShowAlert(string message, float duration)
		{
			DialogueManager.Instance.ShowAlert(message, duration);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000035D8 File Offset: 0x000017D8
		public static void ShowAlert(string message)
		{
			DialogueManager.Instance.ShowAlert(message);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000035E8 File Offset: 0x000017E8
		public static void CheckAlerts()
		{
			DialogueManager.Instance.CheckAlerts();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000035F4 File Offset: 0x000017F4
		public static string GetLocalizedText(string s)
		{
			return DialogueManager.Instance.GetLocalizedText(s);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003604 File Offset: 0x00001804
		public static Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone, string entrytag)
		{
			return DialogueManager.Instance.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone, entrytag);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003624 File Offset: 0x00001824
		public static Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone)
		{
			return DialogueManager.Instance.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003638 File Offset: 0x00001838
		public static Sequencer PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants)
		{
			return DialogueManager.Instance.PlaySequence(sequence, speaker, listener, informParticipants);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003648 File Offset: 0x00001848
		public static Sequencer PlaySequence(string sequence, Transform speaker, Transform listener)
		{
			return DialogueManager.Instance.PlaySequence(sequence, speaker, listener);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003658 File Offset: 0x00001858
		public static Sequencer PlaySequence(string sequence)
		{
			return DialogueManager.Instance.PlaySequence(sequence);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003668 File Offset: 0x00001868
		public static void StopSequence(Sequencer sequencer)
		{
			DialogueManager.Instance.StopSequence(sequencer);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003678 File Offset: 0x00001878
		public static void Pause()
		{
			DialogueManager.Instance.Pause();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003684 File Offset: 0x00001884
		public static void Unpause()
		{
			DialogueManager.Instance.Unpause();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003690 File Offset: 0x00001890
		public static void UseDialogueUI(GameObject gameObject)
		{
			DialogueManager.Instance.UseDialogueUI(gameObject);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000036A0 File Offset: 0x000018A0
		public static void SetPortrait(string actorName, string portraitName)
		{
			DialogueManager.Instance.SetPortrait(actorName, portraitName);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000036B0 File Offset: 0x000018B0
		public static void AddLuaObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			DialogueManager.Instance.AddLuaObserver(luaExpression, frequency, luaChangedHandler);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000036C0 File Offset: 0x000018C0
		public static void RemoveLuaObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			DialogueManager.Instance.RemoveLuaObserver(luaExpression, frequency, luaChangedHandler);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000036D0 File Offset: 0x000018D0
		public static void RemoveAllObservers(LuaWatchFrequency frequency)
		{
			DialogueManager.Instance.RemoveAllObservers(frequency);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000036E0 File Offset: 0x000018E0
		public static void RemoveAllObservers()
		{
			DialogueManager.Instance.RemoveAllObservers();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000036EC File Offset: 0x000018EC
		public static void RegisterAssetBundle(AssetBundle bundle)
		{
			DialogueManager.Instance.RegisterAssetBundle(bundle);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000036FC File Offset: 0x000018FC
		public static void UnregisterAssetBundle(AssetBundle bundle)
		{
			DialogueManager.Instance.UnregisterAssetBundle(bundle);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000370C File Offset: 0x0000190C
		public static Object LoadAsset(string name)
		{
			return DialogueManager.Instance.LoadAsset(name);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000371C File Offset: 0x0000191C
		public static Object LoadAsset(string name, Type type)
		{
			return DialogueManager.Instance.LoadAsset(name, type);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000372C File Offset: 0x0000192C
		private static DialogueSystemController FindOrCreateInstance()
		{
			if (DialogueManager.instance == null)
			{
				DialogueManager.instance = Object.FindObjectOfType(typeof(DialogueSystemController)) as DialogueSystemController;
				if (DialogueManager.instance == null)
				{
					if (DialogueSystemController.applicationIsQuitting)
					{
						DialogueManager.instance = null;
					}
					else
					{
						DialogueManager.instance = new GameObject("Dialogue Manager").AddComponent<DialogueSystemController>();
					}
				}
			}
			return DialogueManager.instance;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000037A0 File Offset: 0x000019A0
		public static void SendUpdateTracker()
		{
			if (DialogueManager.Instance != null)
			{
				DialogueManager.Instance.BroadcastMessage("UpdateTracker", SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x04000027 RID: 39
		private static DialogueSystemController instance;
	}
}
