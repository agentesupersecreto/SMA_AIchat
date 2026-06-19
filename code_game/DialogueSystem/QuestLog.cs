using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200026C RID: 620
	public static class QuestLog
	{
		// Token: 0x06001A9E RID: 6814 RVA: 0x0002D730 File Offset: 0x0002B930
		public static void RegisterQuestLogFunctions()
		{
			Lua.RegisterFunction("CurrentQuestState", null, SymbolExtensions.GetMethodInfo(() => QuestLog.CurrentQuestState(string.Empty)));
			Lua.RegisterFunction("CurrentQuestEntryState", null, SymbolExtensions.GetMethodInfo(() => QuestLog.CurrentQuestEntryState(string.Empty, 0.0)));
			Lua.RegisterFunction("SetQuestState", null, SymbolExtensions.GetMethodInfo(() => QuestLog.SetQuestState(string.Empty, string.Empty)));
			Lua.RegisterFunction("SetQuestEntryState", null, SymbolExtensions.GetMethodInfo(() => QuestLog.SetQuestEntryState(string.Empty, 0.0, string.Empty)));
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x0002D8C8 File Offset: 0x0002BAC8
		public static void AddQuest(string questName, string description, string successDescription, string failureDescription, QuestState state)
		{
			if (!string.IsNullOrEmpty(questName))
			{
				Lua.Run(string.Format("Item[\"{0}\"] = {{ Name = \"{1}\", Description = \"{2}\", Success_Description = \"{3}\", Failure_Description = \"{4}\", State = \"{5}\" }}", new object[]
				{
					DialogueLua.StringToTableIndex(questName),
					DialogueLua.DoubleQuotesToSingle(questName),
					DialogueLua.DoubleQuotesToSingle(description),
					DialogueLua.DoubleQuotesToSingle(successDescription),
					DialogueLua.DoubleQuotesToSingle(failureDescription),
					QuestLog.StateToString(state)
				}), DialogueDebug.LogInfo);
			}
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x0002D934 File Offset: 0x0002BB34
		public static void AddQuest(string questName, string description, QuestState state)
		{
			if (!string.IsNullOrEmpty(questName))
			{
				Lua.Run(string.Format("Item[\"{0}\"] = {{ Name = \"{1}\", Description = \"{2}\", State = \"{3}\" }}", new object[]
				{
					DialogueLua.StringToTableIndex(questName),
					DialogueLua.DoubleQuotesToSingle(questName),
					DialogueLua.DoubleQuotesToSingle(description),
					QuestLog.StateToString(state)
				}), DialogueDebug.LogInfo);
			}
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x0002D98C File Offset: 0x0002BB8C
		public static void AddQuest(string questName, string description)
		{
			QuestLog.AddQuest(questName, description, QuestState.Unassigned);
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x0002D998 File Offset: 0x0002BB98
		public static void DeleteQuest(string questName)
		{
			if (!string.IsNullOrEmpty(questName))
			{
				Lua.Run(string.Format("Item[\"{0}\"] = nil", new object[] { DialogueLua.StringToTableIndex(questName) }), DialogueDebug.LogInfo);
			}
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x0002D9CC File Offset: 0x0002BBCC
		public static QuestState GetQuestState(string questName)
		{
			return QuestLog.StringToState(QuestLog.CurrentQuestState(questName));
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x0002D9E0 File Offset: 0x0002BBE0
		public static string CurrentQuestState(string questName)
		{
			if (QuestLog.CurrentQuestStateOverride != null)
			{
				return QuestLog.CurrentQuestStateOverride(questName);
			}
			return QuestLog.DefaultCurrentQuestState(questName);
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x0002DA00 File Offset: 0x0002BC00
		public static string DefaultCurrentQuestState(string questName)
		{
			return DialogueLua.GetQuestField(questName, "State").AsString;
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x0002DA20 File Offset: 0x0002BC20
		public static void SetQuestState(string questName, QuestState state)
		{
			QuestLog.SetQuestState(questName, QuestLog.StateToString(state));
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x0002DA30 File Offset: 0x0002BC30
		public static void SetQuestState(string questName, string state)
		{
			if (QuestLog.SetQuestStateOverride != null)
			{
				QuestLog.SetQuestStateOverride(questName, state);
			}
			else
			{
				QuestLog.DefaultSetQuestState(questName, state);
			}
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x0002DA60 File Offset: 0x0002BC60
		public static void DefaultSetQuestState(string questName, string state)
		{
			if (DialogueLua.DoesTableElementExist("Quest", questName))
			{
				DialogueLua.SetQuestField(questName, "State", state);
				QuestLog.SendUpdateTracker();
				QuestLog.InformQuestStateChange(questName);
			}
			else if (DialogueDebug.LogWarnings)
			{
				Debug.LogWarning("Dialogue System: Quest '" + questName + "' doesn't exist. Can't set state to " + state);
			}
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x0002DABC File Offset: 0x0002BCBC
		private static void SendUpdateTracker()
		{
			DialogueManager.SendUpdateTracker();
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x0002DAC4 File Offset: 0x0002BCC4
		public static void InformQuestStateChange(string questName)
		{
			DialogueManager.Instance.BroadcastMessage("OnQuestStateChange", questName, SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x0002DAD8 File Offset: 0x0002BCD8
		public static void InformQuestEntryStateChange(string questName, int entryNumber)
		{
			DialogueManager.Instance.BroadcastMessage("OnQuestEntryStateChange", new QuestEntryArgs(questName, entryNumber), SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x0002DAF8 File Offset: 0x0002BCF8
		public static bool IsQuestUnassigned(string questName)
		{
			return QuestLog.GetQuestState(questName) == QuestState.Unassigned;
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x0002DB04 File Offset: 0x0002BD04
		public static bool IsQuestActive(string questName)
		{
			return QuestLog.GetQuestState(questName) == QuestState.Active;
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x0002DB10 File Offset: 0x0002BD10
		public static bool IsQuestSuccessful(string questName)
		{
			return QuestLog.GetQuestState(questName) == QuestState.Success;
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x0002DB1C File Offset: 0x0002BD1C
		public static bool IsQuestFailed(string questName)
		{
			return QuestLog.GetQuestState(questName) == QuestState.Failure;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x0002DB28 File Offset: 0x0002BD28
		public static bool IsQuestAbandoned(string questName)
		{
			return QuestLog.GetQuestState(questName) == QuestState.Abandoned;
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x0002DB34 File Offset: 0x0002BD34
		public static bool IsQuestDone(string questName)
		{
			QuestState questState = QuestLog.GetQuestState(questName);
			return questState == QuestState.Success || questState == QuestState.Failure;
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x0002DB58 File Offset: 0x0002BD58
		public static bool IsQuestInStateMask(string questName, QuestState stateMask)
		{
			QuestState questState = QuestLog.GetQuestState(questName);
			return (stateMask & questState) == questState;
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x0002DB74 File Offset: 0x0002BD74
		public static void StartQuest(string questName)
		{
			QuestLog.SetQuestState(questName, QuestState.Active);
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x0002DB80 File Offset: 0x0002BD80
		public static void CompleteQuest(string questName)
		{
			QuestLog.SetQuestState(questName, QuestState.Success);
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x0002DB8C File Offset: 0x0002BD8C
		public static void FailQuest(string questName)
		{
			QuestLog.SetQuestState(questName, QuestState.Failure);
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x0002DB98 File Offset: 0x0002BD98
		public static void AbandonQuest(string questName)
		{
			QuestLog.SetQuestState(questName, QuestState.Abandoned);
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x0002DBA4 File Offset: 0x0002BDA4
		public static QuestState DefaultStringToState(string s)
		{
			if (string.Equals(s, "active"))
			{
				return QuestState.Active;
			}
			if (string.Equals(s, "success") || string.Equals(s, "done"))
			{
				return QuestState.Success;
			}
			if (string.Equals(s, "failure"))
			{
				return QuestState.Failure;
			}
			if (string.Equals(s, "abandoned"))
			{
				return QuestState.Abandoned;
			}
			return QuestState.Unassigned;
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x0002DC0C File Offset: 0x0002BE0C
		public static string StateToString(QuestState state)
		{
			switch (state)
			{
			case QuestState.Unassigned:
				return "unassigned";
			case QuestState.Active:
				return "active";
			default:
				if (state != QuestState.Abandoned)
				{
					return "unassigned";
				}
				return "abandoned";
			case QuestState.Success:
				return "success";
			case QuestState.Failure:
				return "failure";
			}
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x0002DC74 File Offset: 0x0002BE74
		public static string GetQuestTitle(string questName)
		{
			string text = DialogueLua.GetLocalizedQuestField(questName, "Display Name").AsString;
			if (string.IsNullOrEmpty(text))
			{
				text = DialogueLua.GetLocalizedQuestField(questName, "Name").AsString;
			}
			return text;
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x0002DCB8 File Offset: 0x0002BEB8
		public static string GetQuestDescription(string questName)
		{
			QuestState questState = QuestLog.GetQuestState(questName);
			if (questState == QuestState.Success)
			{
				return QuestLog.GetQuestDescription(questName, QuestState.Success) ?? QuestLog.GetQuestDescription(questName, QuestState.Active);
			}
			if (questState != QuestState.Failure)
			{
				return QuestLog.GetQuestDescription(questName, QuestState.Active);
			}
			return QuestLog.GetQuestDescription(questName, QuestState.Failure) ?? QuestLog.GetQuestDescription(questName, QuestState.Active);
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x0002DD14 File Offset: 0x0002BF14
		public static string GetQuestDescription(string questName, QuestState state)
		{
			string defaultDescriptionFieldForState = QuestLog.GetDefaultDescriptionFieldForState(state);
			string asString = DialogueLua.GetLocalizedQuestField(questName, defaultDescriptionFieldForState).AsString;
			return (!string.Equals(asString, "nil") && !string.IsNullOrEmpty(asString)) ? asString : null;
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x0002DD5C File Offset: 0x0002BF5C
		private static string GetDefaultDescriptionFieldForState(QuestState state)
		{
			if (state == QuestState.Success)
			{
				return "Success_Description";
			}
			if (state != QuestState.Failure)
			{
				return "Description";
			}
			return "Failure_Description";
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x0002DD90 File Offset: 0x0002BF90
		public static void SetQuestDescription(string questName, QuestState state, string description)
		{
			DialogueLua.SetQuestField(questName, QuestLog.GetDefaultDescriptionFieldForState(state), description);
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x0002DDA0 File Offset: 0x0002BFA0
		public static string GetQuestAbandonSequence(string questName)
		{
			return DialogueLua.GetLocalizedQuestField(questName, "Abandon Sequence").AsString;
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x0002DDC0 File Offset: 0x0002BFC0
		public static void SetQuestAbandonSequence(string questName, string sequence)
		{
			DialogueLua.SetLocalizedQuestField(questName, "Abandon Sequence", sequence);
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x0002DDD0 File Offset: 0x0002BFD0
		public static int GetQuestEntryCount(string questName)
		{
			return DialogueLua.GetQuestField(questName, "Entry_Count").AsInt;
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x0002DDF0 File Offset: 0x0002BFF0
		public static void AddQuestEntry(string questName, string description)
		{
			int num = QuestLog.GetQuestEntryCount(questName);
			num++;
			DialogueLua.SetQuestField(questName, "Entry_Count", num);
			string entryFieldName = QuestLog.GetEntryFieldName(num);
			DialogueLua.SetQuestField(questName, entryFieldName, DialogueLua.DoubleQuotesToSingle(description));
			string entryStateFieldName = QuestLog.GetEntryStateFieldName(num);
			DialogueLua.SetQuestField(questName, entryStateFieldName, "unassigned");
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x0002DE40 File Offset: 0x0002C040
		public static string GetQuestEntry(string questName, int entryNumber)
		{
			string entryFieldName = QuestLog.GetEntryFieldName(entryNumber);
			return DialogueLua.GetLocalizedQuestField(questName, entryFieldName).AsString;
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x0002DE64 File Offset: 0x0002C064
		public static void SetQuestEntry(string questName, int entryNumber, string description)
		{
			string entryFieldName = QuestLog.GetEntryFieldName(entryNumber);
			DialogueLua.SetLocalizedQuestField(questName, entryFieldName, DialogueLua.DoubleQuotesToSingle(description));
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x0002DE88 File Offset: 0x0002C088
		public static QuestState GetQuestEntryState(string questName, int entryNumber)
		{
			return QuestLog.StringToState(QuestLog.CurrentQuestEntryState(questName, (double)entryNumber));
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x0002DE9C File Offset: 0x0002C09C
		public static string CurrentQuestEntryState(string questName, double entryNumber)
		{
			if (QuestLog.CurrentQuestEntryStateOverride != null)
			{
				return QuestLog.CurrentQuestEntryStateOverride(questName, (int)entryNumber);
			}
			return QuestLog.DefaultCurrentQuestEntryState(questName, (int)entryNumber);
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0002DECC File Offset: 0x0002C0CC
		public static string DefaultCurrentQuestEntryState(string questName, int entryNumber)
		{
			return DialogueLua.GetQuestField(questName, QuestLog.GetEntryStateFieldName(entryNumber)).AsString;
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x0002DEF0 File Offset: 0x0002C0F0
		public static void SetQuestEntryState(string questName, int entryNumber, QuestState state)
		{
			QuestLog.SetQuestEntryState(questName, (double)entryNumber, QuestLog.StateToString(state));
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0002DF00 File Offset: 0x0002C100
		public static void SetQuestEntryState(string questName, double entryNumber, string state)
		{
			if (QuestLog.SetQuestEntryStateOverride != null)
			{
				QuestLog.SetQuestEntryStateOverride(questName, (int)entryNumber, state);
			}
			else
			{
				QuestLog.DefaultSetQuestEntryState(questName, (int)entryNumber, state);
			}
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x0002DF34 File Offset: 0x0002C134
		public static void DefaultSetQuestEntryState(string questName, int entryNumber, string state)
		{
			if (DialogueLua.DoesTableElementExist("Quest", questName))
			{
				DialogueLua.SetQuestField(questName, QuestLog.GetEntryStateFieldName(entryNumber), state);
				QuestLog.InformQuestStateChange(questName);
				QuestLog.InformQuestEntryStateChange(questName, entryNumber);
				QuestLog.SendUpdateTracker();
			}
			else if (DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Concat(new object[] { "Dialogue System: Quest '", questName, "' doesn't exist. Can't set entry ", entryNumber, " state to ", state }));
			}
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x0002DFB8 File Offset: 0x0002C1B8
		private static string GetEntryFieldName(int entryNumber)
		{
			return string.Format("Entry_{0}", new object[] { entryNumber });
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x0002DFD4 File Offset: 0x0002C1D4
		private static string GetEntryStateFieldName(int entryNumber)
		{
			return string.Format("Entry_{0}_State", new object[] { entryNumber });
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0002DFF0 File Offset: 0x0002C1F0
		public static bool IsQuestTrackingAvailable(string questName)
		{
			return DialogueLua.GetQuestField(questName, "Trackable").AsBool;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x0002E010 File Offset: 0x0002C210
		public static void SetQuestTrackingAvailable(string questName, bool value)
		{
			DialogueLua.SetQuestField(questName, "Trackable", value);
			QuestLog.SendUpdateTracker();
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x0002E028 File Offset: 0x0002C228
		public static bool IsQuestTrackingEnabled(string questName)
		{
			return QuestLog.IsQuestTrackingAvailable(questName) && DialogueLua.GetQuestField(questName, "Track").AsBool;
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x0002E05C File Offset: 0x0002C25C
		public static void SetQuestTracking(string questName, bool value)
		{
			if (value && !QuestLog.IsQuestTrackingAvailable(questName))
			{
				QuestLog.SetQuestTrackingAvailable(questName, true);
			}
			DialogueLua.SetQuestField(questName, "Track", value);
			QuestLog.SendUpdateTracker();
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x0002E098 File Offset: 0x0002C298
		public static bool IsQuestAbandonable(string questName)
		{
			return DialogueLua.GetQuestField(questName, "Abandonable").AsBool;
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x0002E0B8 File Offset: 0x0002C2B8
		public static string GetQuestGroup(string questName)
		{
			return DialogueLua.GetLocalizedQuestField(questName, "Group").AsString;
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x0002E0D8 File Offset: 0x0002C2D8
		public static string[] GetAllGroups()
		{
			return QuestLog.GetAllGroups(QuestState.Active, true);
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x0002E0E4 File Offset: 0x0002C2E4
		public static string[] GetAllGroups(QuestState flags)
		{
			return QuestLog.GetAllGroups(flags, true);
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x0002E0F0 File Offset: 0x0002C2F0
		public static string[] GetAllGroups(QuestState flags, bool sortByGroupName)
		{
			List<string> list = new List<string>();
			LuaTableWrapper asTable = Lua.Run("return Item").AsTable;
			if (!asTable.IsValid)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Quest Log couldn't access Lua Item[] table. Has the Dialogue Manager loaded a database yet?", new object[] { "Dialogue System" }));
				}
				return list.ToArray();
			}
			foreach (object obj in asTable.Values)
			{
				LuaTableWrapper luaTableWrapper = obj as LuaTableWrapper;
				if (luaTableWrapper != null)
				{
					string text = null;
					string text2 = null;
					bool flag = false;
					try
					{
						object obj2 = luaTableWrapper["Name"];
						text = ((obj2 == null) ? string.Empty : obj2.ToString());
						object obj3 = luaTableWrapper["Group"];
						text2 = ((obj3 == null) ? string.Empty : obj3.ToString());
						flag = false;
						object obj4 = luaTableWrapper["Is_Item"];
						if (obj4 != null)
						{
							if (obj4.GetType() == typeof(bool))
							{
								flag = (bool)obj4;
							}
							else
							{
								flag = Tools.StringToBool(obj4.ToString());
							}
						}
					}
					catch
					{
					}
					if (!flag && !list.Contains(text2) && QuestLog.IsQuestInStateMask(text, flags))
					{
						list.Add(text2);
					}
				}
			}
			if (sortByGroupName)
			{
				list.Sort();
			}
			return list.ToArray();
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x0002E2B4 File Offset: 0x0002C4B4
		public static string[] GetAllQuests()
		{
			return QuestLog.GetAllQuests(QuestState.Active, true, null);
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x0002E2C0 File Offset: 0x0002C4C0
		public static string[] GetAllQuests(QuestState flags)
		{
			return QuestLog.GetAllQuests(flags, true, null);
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x0002E2CC File Offset: 0x0002C4CC
		public static string[] GetAllQuests(QuestState flags, bool sortByName)
		{
			return QuestLog.GetAllQuests(flags, sortByName, null);
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x0002E2D8 File Offset: 0x0002C4D8
		public static string[] GetAllQuests(QuestState flags, bool sortByName, string group)
		{
			List<string> list = new List<string>();
			LuaTableWrapper asTable = Lua.Run("return Item").AsTable;
			if (!asTable.IsValid)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Quest Log couldn't access Lua Item[] table. Has the Dialogue Manager loaded a database yet?", new object[] { "Dialogue System" }));
				}
				return list.ToArray();
			}
			bool flag = group != null;
			foreach (object obj in asTable.Values)
			{
				LuaTableWrapper luaTableWrapper = obj as LuaTableWrapper;
				if (luaTableWrapper != null)
				{
					string text = null;
					string text2 = null;
					bool flag2 = false;
					try
					{
						object obj2 = luaTableWrapper["Name"];
						text = ((obj2 == null) ? string.Empty : obj2.ToString());
						if (flag)
						{
							object obj3 = luaTableWrapper["Group"];
							text2 = ((obj3 == null) ? string.Empty : obj3.ToString());
						}
						flag2 = false;
						object obj4 = luaTableWrapper["Is_Item"];
						if (obj4 != null)
						{
							if (obj4.GetType() == typeof(bool))
							{
								flag2 = (bool)obj4;
							}
							else
							{
								flag2 = Tools.StringToBool(obj4.ToString());
							}
						}
					}
					catch
					{
					}
					if (!flag2)
					{
						if (string.IsNullOrEmpty(text))
						{
							if (DialogueDebug.LogWarnings)
							{
								Debug.LogWarning(string.Format("{0}: A quest name (item name in Item[] table) is null or empty", new object[] { "Dialogue System" }));
							}
						}
						else if ((!flag || string.Equals(group, text2)) && QuestLog.IsQuestInStateMask(text, flags))
						{
							list.Add(text);
						}
					}
				}
			}
			if (sortByName)
			{
				list.Sort();
			}
			return list.ToArray();
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x0002E4F0 File Offset: 0x0002C6F0
		public static QuestGroupRecord[] GetAllGroupsAndQuests(QuestState flags, bool sort = true)
		{
			List<QuestGroupRecord> list = new List<QuestGroupRecord>();
			LuaTableWrapper asTable = Lua.Run("return Item").AsTable;
			if (!asTable.IsValid)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Quest Log couldn't access Lua Item[] table. Has the Dialogue Manager loaded a database yet?", new object[] { "Dialogue System" }));
				}
				return list.ToArray();
			}
			foreach (object obj in asTable.Values)
			{
				LuaTableWrapper luaTableWrapper = obj as LuaTableWrapper;
				if (luaTableWrapper != null)
				{
					string text = null;
					string text2 = null;
					bool flag = false;
					try
					{
						object obj2 = luaTableWrapper["Name"];
						text = ((obj2 == null) ? string.Empty : obj2.ToString());
						object obj3 = luaTableWrapper["Group"];
						text2 = ((obj3 == null) ? string.Empty : obj3.ToString());
						flag = false;
						object obj4 = luaTableWrapper["Is_Item"];
						if (obj4 != null)
						{
							if (obj4.GetType() == typeof(bool))
							{
								flag = (bool)obj4;
							}
							else
							{
								flag = Tools.StringToBool(obj4.ToString());
							}
						}
					}
					catch
					{
					}
					if (!flag)
					{
						if (string.IsNullOrEmpty(text))
						{
							if (DialogueDebug.LogWarnings)
							{
								Debug.LogWarning(string.Format("{0}: A quest name (item name in Item[] table) is null or empty", new object[] { "Dialogue System" }));
							}
						}
						else if (QuestLog.IsQuestInStateMask(text, flags))
						{
							list.Add(new QuestGroupRecord(text2, text));
						}
					}
				}
			}
			if (sort)
			{
				list.Sort();
			}
			return list.ToArray();
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x0002E6E8 File Offset: 0x0002C8E8
		public static void AddQuestStateObserver(string questName, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
		{
			QuestLog.questWatchList.Add(new QuestLog.QuestWatchItem(questName, frequency, questChangedHandler));
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x0002E6FC File Offset: 0x0002C8FC
		public static void AddQuestStateObserver(string questName, int entryNumber, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
		{
			QuestLog.questWatchList.Add(new QuestLog.QuestWatchItem(questName, entryNumber, frequency, questChangedHandler));
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x0002E714 File Offset: 0x0002C914
		public static void RemoveQuestStateObserver(string questName, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
		{
			foreach (QuestLog.QuestWatchItem questWatchItem2 in QuestLog.questWatchList)
			{
				if (questWatchItem2.Matches(questName, frequency, questChangedHandler))
				{
					questWatchItem2.StopObserving();
				}
			}
			QuestLog.questWatchList.RemoveAll((QuestLog.QuestWatchItem questWatchItem) => questWatchItem.Matches(questName, frequency, questChangedHandler));
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x0002E7C8 File Offset: 0x0002C9C8
		public static void RemoveQuestStateObserver(string questName, int entryNumber, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
		{
			foreach (QuestLog.QuestWatchItem questWatchItem2 in QuestLog.questWatchList)
			{
				if (questWatchItem2.Matches(questName, entryNumber, frequency, questChangedHandler))
				{
					questWatchItem2.StopObserving();
				}
			}
			QuestLog.questWatchList.RemoveAll((QuestLog.QuestWatchItem questWatchItem) => questWatchItem.Matches(questName, entryNumber, frequency, questChangedHandler));
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x0002E888 File Offset: 0x0002CA88
		public static void RemoveAllQuestStateObservers()
		{
			foreach (QuestLog.QuestWatchItem questWatchItem in QuestLog.questWatchList)
			{
				questWatchItem.StopObserving();
			}
			QuestLog.questWatchList.Clear();
		}

		// Token: 0x04000F05 RID: 3845
		public const string UnassignedStateString = "unassigned";

		// Token: 0x04000F06 RID: 3846
		public const string ActiveStateString = "active";

		// Token: 0x04000F07 RID: 3847
		public const string SuccessStateString = "success";

		// Token: 0x04000F08 RID: 3848
		public const string FailureStateString = "failure";

		// Token: 0x04000F09 RID: 3849
		public const string AbandonedStateString = "abandoned";

		// Token: 0x04000F0A RID: 3850
		public const string DoneStateString = "done";

		// Token: 0x04000F0B RID: 3851
		public static StringToQuestStateDelegate StringToState = new StringToQuestStateDelegate(QuestLog.DefaultStringToState);

		// Token: 0x04000F0C RID: 3852
		public static CurrentQuestStateDelegate CurrentQuestStateOverride = null;

		// Token: 0x04000F0D RID: 3853
		public static SetQuestStateDelegate SetQuestStateOverride = null;

		// Token: 0x04000F0E RID: 3854
		public static CurrentQuestEntryStateDelegate CurrentQuestEntryStateOverride = null;

		// Token: 0x04000F0F RID: 3855
		public static SetQuestEntryStateDelegate SetQuestEntryStateOverride = null;

		// Token: 0x04000F10 RID: 3856
		private static readonly List<QuestLog.QuestWatchItem> questWatchList = new List<QuestLog.QuestWatchItem>();

		// Token: 0x0200026D RID: 621
		public class QuestWatchItem
		{
			// Token: 0x06001ADF RID: 6879 RVA: 0x0002E8F8 File Offset: 0x0002CAF8
			public QuestWatchItem(string questName, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
			{
				this.questName = questName;
				this.entryNumber = 0;
				this.frequency = frequency;
				this.luaExpression = string.Format("return Item[\"{0}\"].State", new object[] { DialogueLua.StringToTableIndex(questName) });
				this.questChangedHandler = questChangedHandler;
				DialogueManager.AddLuaObserver(this.luaExpression, frequency, new LuaChangedDelegate(this.OnLuaChanged));
			}

			// Token: 0x06001AE0 RID: 6880 RVA: 0x0002E960 File Offset: 0x0002CB60
			public QuestWatchItem(string questName, int entryNumber, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
			{
				this.questName = questName;
				this.entryNumber = entryNumber;
				this.frequency = frequency;
				this.luaExpression = string.Format("return Item[\"{0}\"].Entry_{1}_State", new object[]
				{
					DialogueLua.StringToTableIndex(questName),
					entryNumber
				});
				this.questChangedHandler = questChangedHandler;
				DialogueManager.AddLuaObserver(this.luaExpression, frequency, new LuaChangedDelegate(this.OnLuaChanged));
			}

			// Token: 0x06001AE1 RID: 6881 RVA: 0x0002E9D0 File Offset: 0x0002CBD0
			public bool Matches(string questName, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
			{
				return string.Equals(questName, this.questName) && frequency == this.frequency && questChangedHandler == this.questChangedHandler;
			}

			// Token: 0x06001AE2 RID: 6882 RVA: 0x0002EA0C File Offset: 0x0002CC0C
			public bool Matches(string questName, int entryNumber, LuaWatchFrequency frequency, QuestLog.QuestChangedDelegate questChangedHandler)
			{
				return string.Equals(questName, this.questName) && entryNumber == this.entryNumber && frequency == this.frequency && questChangedHandler == this.questChangedHandler;
			}

			// Token: 0x06001AE3 RID: 6883 RVA: 0x0002EA48 File Offset: 0x0002CC48
			public void StopObserving()
			{
				DialogueManager.RemoveLuaObserver(this.luaExpression, this.frequency, new LuaChangedDelegate(this.OnLuaChanged));
			}

			// Token: 0x06001AE4 RID: 6884 RVA: 0x0002EA68 File Offset: 0x0002CC68
			private void OnLuaChanged(LuaWatchItem luaWatchItem, Lua.Result newResult)
			{
				if (string.Equals(luaWatchItem.LuaExpression, this.luaExpression) && this.questChangedHandler != null)
				{
					this.questChangedHandler(this.questName, QuestLog.StringToState(newResult.AsString));
				}
			}

			// Token: 0x04000F11 RID: 3857
			private string questName;

			// Token: 0x04000F12 RID: 3858
			private int entryNumber;

			// Token: 0x04000F13 RID: 3859
			private LuaWatchFrequency frequency;

			// Token: 0x04000F14 RID: 3860
			private string luaExpression;

			// Token: 0x04000F15 RID: 3861
			private QuestLog.QuestChangedDelegate questChangedHandler;
		}

		// Token: 0x020002DF RID: 735
		// (Invoke) Token: 0x06001DF5 RID: 7669
		public delegate void QuestChangedDelegate(string questName, QuestState newState);
	}
}
