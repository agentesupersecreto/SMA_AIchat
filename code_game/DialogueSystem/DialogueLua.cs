using System;
using System.Collections.Generic;
using System.Text;
using Language.Lua;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200021C RID: 540
	public static class DialogueLua
	{
		// Token: 0x06001837 RID: 6199 RVA: 0x00021B00 File Offset: 0x0001FD00
		static DialogueLua()
		{
			DialogueLua.RegisterChatMapperFunctions();
			DialogueLua.RegisterDialogueSystemFunctions();
			DialogueLua.InitializeChatMapperVariables();
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x00021B2C File Offset: 0x0001FD2C
		public static void InitializeChatMapperVariables()
		{
			Lua.Run("Actor = {}; Item = {}; Quest = Item; Location = {}; Conversation = {}; Variable = {}; Variable[\"Alert\"] = \"\"", DialogueDebug.LogInfo);
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x00021B40 File Offset: 0x0001FD40
		public static void AddChatMapperVariables(DialogueDatabase database, List<DialogueDatabase> loadedDatabases)
		{
			if (database != null)
			{
				DialogueLua.AddToTable<Actor>("Actor", database.actors, loadedDatabases);
				DialogueLua.AddToTable<Item>("Item", database.items, loadedDatabases);
				DialogueLua.AddToTable<Location>("Location", database.locations, loadedDatabases);
				DialogueLua.AddToVariableTable(database.variables, loadedDatabases);
				DialogueLua.AddToConversationTable(database.conversations, loadedDatabases);
				if (!string.IsNullOrEmpty(database.globalUserScript))
				{
					Lua.Run(database.globalUserScript, DialogueDebug.LogInfo);
				}
			}
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x00021BC8 File Offset: 0x0001FDC8
		public static void RemoveChatMapperVariables(DialogueDatabase database, List<DialogueDatabase> loadedDatabases)
		{
			if (database != null)
			{
				DialogueLua.RemoveFromTable<Actor>("Actor", database.actors, loadedDatabases);
				DialogueLua.RemoveFromTable<Item>("Item", database.items, loadedDatabases);
				DialogueLua.RemoveFromTable<Location>("Location", database.locations, loadedDatabases);
				DialogueLua.RemoveFromTable<Variable>("Variable", database.variables, loadedDatabases);
				DialogueLua.RemoveFromTable<Conversation>("Conversation", database.conversations, loadedDatabases);
			}
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x00021C38 File Offset: 0x0001FE38
		public static void SetParticipants(string actorName, string conversantName, string actorIndex = null, string conversantIndex = null)
		{
			DialogueLua.SetVariable("Actor", actorName);
			DialogueLua.SetVariable("Conversant", conversantName);
			DialogueLua.SetVariable("ActorIndex", DialogueLua.StringToTableIndex((!string.IsNullOrEmpty(actorIndex)) ? actorIndex : actorName));
			DialogueLua.SetVariable("ConversantIndex", DialogueLua.StringToTableIndex((!string.IsNullOrEmpty(conversantIndex)) ? conversantIndex : actorName));
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x00021CA0 File Offset: 0x0001FEA0
		public static void MarkDialogueEntryUntouched(DialogueEntry dialogueEntry)
		{
			DialogueLua.MarkDialogueEntry(dialogueEntry, "Untouched");
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		public static void MarkDialogueEntryDisplayed(DialogueEntry dialogueEntry)
		{
			DialogueLua.MarkDialogueEntry(dialogueEntry, "WasDisplayed");
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x00021CC0 File Offset: 0x0001FEC0
		public static void MarkDialogueEntryOffered(DialogueEntry dialogueEntry)
		{
			if (DialogueLua.includeSimStatus && dialogueEntry != null)
			{
				try
				{
					string asString = Lua.Run(string.Format("return Conversation[{0}].Dialog[{1}].SimStatus", new object[] { dialogueEntry.conversationID, dialogueEntry.id })).AsString;
					if (!string.Equals(asString, "WasDisplayed"))
					{
						DialogueLua.MarkDialogueEntry(dialogueEntry, "WasOffered");
					}
				}
				catch (Exception)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: The Lua exception above indicates a dialogue database inconsistency. Is an invalid conversation ID recorded in a dialogue entry? Is the database loaded?", new object[] { "Dialogue System" }));
					}
				}
			}
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x00021D80 File Offset: 0x0001FF80
		public static void MarkDialogueEntry(DialogueEntry dialogueEntry, string status)
		{
			if (DialogueLua.includeSimStatus && dialogueEntry != null)
			{
				bool flag = false;
				try
				{
					Lua.Run(string.Format("Conversation[{0}].Dialog[{1}].SimStatus = \"{2}\"", new object[] { dialogueEntry.conversationID, dialogueEntry.id, status }), false, true);
				}
				catch (Exception)
				{
					flag = true;
				}
				if (flag && DialogueDebug.LogErrors)
				{
					Debug.LogError(string.Format("{0}: The Lua exception above indicates a dialogue database inconsistency. Is an invalid conversation ID recorded in a dialogue entry? Is the database loaded?", new object[] { "Dialogue System" }));
				}
			}
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x00021E30 File Offset: 0x00020030
		private static void AddToTable<T>(string arrayName, List<T> assets, List<DialogueDatabase> loadedDatabases) where T : Asset
		{
			for (int i = 0; i < assets.Count; i++)
			{
				T t = assets[i];
				if (!DialogueDatabase.Contains(loadedDatabases, t))
				{
					DialogueLua.SetFields(string.Format("{0}[\"{1}\"]", new object[]
					{
						arrayName,
						DialogueLua.StringToTableIndex(t.Name)
					}), t.fields, null);
				}
			}
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00021EA8 File Offset: 0x000200A8
		private static void AddToVariableTable(List<Variable> variables, List<DialogueDatabase> loadedDatabases)
		{
			for (int i = 0; i < variables.Count; i++)
			{
				Variable variable = variables[i];
				if (!DialogueDatabase.Contains(loadedDatabases, variable))
				{
					Lua.Run(string.Format("Variable[\"{0}\"] = {1}", new object[]
					{
						DialogueLua.StringToTableIndex(variable.Name),
						DialogueLua.ValueAsString(variable.Type, variable.InitialValue)
					}), DialogueDebug.LogInfo);
				}
			}
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x00021F20 File Offset: 0x00020120
		public static void AddToConversationTable(List<Conversation> conversations, List<DialogueDatabase> loadedDatabases)
		{
			for (int i = 0; i < conversations.Count; i++)
			{
				Conversation conversation = conversations[i];
				if (!DialogueDatabase.Contains(loadedDatabases, conversation))
				{
					DialogueLua.SetFields(string.Format("Conversation[{0}]", new object[] { conversation.id }), conversation.fields, "Dialog = {}");
				}
			}
			if (!DialogueLua.includeSimStatus)
			{
				return;
			}
			for (int j = 0; j < conversations.Count; j++)
			{
				Conversation conversation2 = conversations[j];
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("Conversation[{0}].Dialog = {{ ", new object[] { conversation2.id });
				for (int k = 0; k < conversation2.dialogueEntries.Count; k++)
				{
					DialogueEntry dialogueEntry = conversation2.dialogueEntries[k];
					stringBuilder.AppendFormat("[{0}]={{SimStatus=\"Untouched\"}},", new object[] { dialogueEntry.id });
				}
				stringBuilder.Append('}');
				bool flag = false;
				try
				{
					Lua.Run(stringBuilder.ToString(), false, true);
				}
				catch (Exception)
				{
					flag = true;
				}
				if (flag && DialogueDebug.LogErrors)
				{
					Debug.LogError(string.Format("{0}: LuaExceptions above indicate a dialogue database inconsistency. Is an invalid conversation ID recorded in a dialogue entry?", new object[] { "Dialogue System" }));
				}
			}
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x000220A0 File Offset: 0x000202A0
		private static void SetFields(string record, List<Field> fields, string extraField = null)
		{
			StringBuilder stringBuilder = new StringBuilder(string.Format("{0} = {{ Status = \"\", ", new object[] { record }), 1024);
			for (int i = 0; i < fields.Count; i++)
			{
				Field field = fields[i];
				if (!string.IsNullOrEmpty(field.title))
				{
					stringBuilder.AppendFormat("{0} = {1}, ", new object[]
					{
						DialogueLua.StringToTableIndex(field.title),
						DialogueLua.FieldValueAsString(field)
					});
				}
			}
			if (!string.IsNullOrEmpty(extraField))
			{
				stringBuilder.Append(extraField);
			}
			stringBuilder.Append('}');
			Lua.Run(stringBuilder.ToString(), DialogueDebug.LogInfo);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x00022154 File Offset: 0x00020354
		public static string FieldValueAsString(Field field)
		{
			return DialogueLua.ValueAsString(field.type, field.value);
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x00022168 File Offset: 0x00020368
		public static string ValueAsString(FieldType fieldType, string fieldValue)
		{
			switch (fieldType)
			{
			case FieldType.Number:
			case FieldType.Actor:
			case FieldType.Item:
			case FieldType.Location:
				return (!string.IsNullOrEmpty(fieldValue)) ? fieldValue : "0";
			case FieldType.Boolean:
				return (!string.IsNullOrEmpty(fieldValue)) ? fieldValue.ToLower() : "false";
			}
			return string.Format("\"{0}\"", new object[] { DialogueLua.DoubleQuotesToSingle(fieldValue) });
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x000221EC File Offset: 0x000203EC
		private static void RemoveFromTable<T>(string arrayName, List<T> assets, List<DialogueDatabase> loadedDatabases) where T : Asset
		{
			for (int i = 0; i < assets.Count; i++)
			{
				T t = assets[i];
				if (!DialogueDatabase.Contains(loadedDatabases, t))
				{
					if (t is Conversation)
					{
						Lua.Run(string.Format("{0}[{1}] = nil", new object[] { arrayName, t.id }), DialogueDebug.LogInfo);
					}
					else
					{
						Lua.Run(string.Format("{0}[\"{1}\"] = nil", new object[]
						{
							arrayName,
							DialogueLua.StringToTableIndex(t.Name)
						}), DialogueDebug.LogInfo);
					}
				}
			}
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x000222A4 File Offset: 0x000204A4
		private static void RegisterDialogueSystemFunctions()
		{
			Lua.RegisterFunction("RandomElement", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.RandomElement(string.Empty)));
			Lua.RegisterFunction("GetLocalizedText", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.GetLocalizedText(string.Empty, string.Empty, string.Empty)));
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x0002236C File Offset: 0x0002056C
		public static string RandomElement(string list)
		{
			if (string.IsNullOrEmpty(list))
			{
				return string.Empty;
			}
			string[] array = list.Split(new char[] { '|' }, StringSplitOptions.None);
			return array[Random.Range(0, array.Length)];
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x000223A8 File Offset: 0x000205A8
		public static string GetLocalizedText(string tableName, string elementName, string fieldName)
		{
			return DialogueLua.GetLocalizedTableField(tableName, elementName, fieldName).AsString;
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x000223C8 File Offset: 0x000205C8
		private static void RegisterChatMapperFunctions()
		{
			Lua.RegisterFunction("GetStatus", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.GetStatus(null, null)));
			Lua.RegisterFunction("SetStatus", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.SetStatus(null, null, null)));
			Lua.RegisterFunction("GetRelationship", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.GetRelationship(null, null, null)));
			Lua.RegisterFunction("SetRelationship", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.SetRelationship(null, null, null, 0f)));
			Lua.RegisterFunction("IncRelationship", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.IncRelationship(null, null, null, 0f)));
			Lua.RegisterFunction("DecRelationship", null, SymbolExtensions.GetMethodInfo(() => DialogueLua.DecRelationship(null, null, null, 0f)));
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x000226B0 File Offset: 0x000208B0
		private static string GetStatusKey(LuaTable asset1, LuaTable asset2)
		{
			if (asset1 == null || asset2 == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Syntax error in status function");
				}
				return "INVALID";
			}
			string text = DialogueLua.StringToTableIndex(asset1.GetValue("Name").ToString());
			string text2 = DialogueLua.StringToTableIndex(asset2.GetValue("Name").ToString());
			return text + ',' + text2;
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00022720 File Offset: 0x00020920
		private static string GetRelationshipKey(LuaTable actor1, LuaTable actor2, string relationshipType)
		{
			if (actor1 == null || actor2 == null || relationshipType == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Syntax error in relationship function");
				}
				return "INVALID";
			}
			string text = DialogueLua.StringToTableIndex(actor1.GetValue("Name").ToString());
			string text2 = DialogueLua.StringToTableIndex(actor2.GetValue("Name").ToString());
			string text3 = DialogueLua.SanitizeForStatusTable(relationshipType.ToString());
			return string.Format("{0},{1},'{2}'", new object[] { text, text2, text3 });
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x000227B0 File Offset: 0x000209B0
		private static string SanitizeForStatusTable(string s)
		{
			return string.Join("_", s.Split(new char[] { ',', ';', '"', '\'' }));
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x000227D4 File Offset: 0x000209D4
		private static float GetLuaFloat(LuaNumber luaNumber)
		{
			return (luaNumber == null) ? 0f : ((float)luaNumber.Number);
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x000227F0 File Offset: 0x000209F0
		public static string GetStatus(LuaTable asset1, LuaTable asset2)
		{
			string statusKey = DialogueLua.GetStatusKey(asset1, asset2);
			return (!DialogueLua.statusTable.ContainsKey(statusKey)) ? string.Empty : DialogueLua.statusTable[statusKey];
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x0002282C File Offset: 0x00020A2C
		public static void SetStatus(LuaTable asset1, LuaTable asset2, string statusValue)
		{
			string statusKey = DialogueLua.GetStatusKey(asset1, asset2);
			DialogueLua.statusTable[statusKey] = statusValue ?? string.Empty;
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x0002285C File Offset: 0x00020A5C
		public static float GetRelationship(LuaTable actor1, LuaTable actor2, string relationshipType)
		{
			string relationshipKey = DialogueLua.GetRelationshipKey(actor1, actor2, relationshipType);
			return (!DialogueLua.relationshipTable.ContainsKey(relationshipKey)) ? 0f : DialogueLua.relationshipTable[relationshipKey];
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x00022898 File Offset: 0x00020A98
		public static void SetRelationship(LuaTable actor1, LuaTable actor2, string relationshipType, float value)
		{
			DialogueLua.relationshipTable[DialogueLua.GetRelationshipKey(actor1, actor2, relationshipType)] = value;
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x000228B0 File Offset: 0x00020AB0
		public static void IncRelationship(LuaTable actor1, LuaTable actor2, string relationshipType, float incrementAmount)
		{
			string relationshipKey = DialogueLua.GetRelationshipKey(actor1, actor2, relationshipType);
			if (DialogueLua.relationshipTable.ContainsKey(relationshipKey))
			{
				Dictionary<string, float> dictionary2;
				Dictionary<string, float> dictionary = (dictionary2 = DialogueLua.relationshipTable);
				string text2;
				string text = (text2 = relationshipKey);
				float num = dictionary2[text2];
				dictionary[text] = num + incrementAmount;
			}
			else
			{
				DialogueLua.relationshipTable.Add(relationshipKey, incrementAmount);
			}
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x00022904 File Offset: 0x00020B04
		public static void DecRelationship(LuaTable actor1, LuaTable actor2, string relationshipType, float decrementAmount)
		{
			string relationshipKey = DialogueLua.GetRelationshipKey(actor1, actor2, relationshipType);
			if (DialogueLua.relationshipTable.ContainsKey(relationshipKey))
			{
				Dictionary<string, float> dictionary2;
				Dictionary<string, float> dictionary = (dictionary2 = DialogueLua.relationshipTable);
				string text2;
				string text = (text2 = relationshipKey);
				float num = dictionary2[text2];
				dictionary[text] = num - decrementAmount;
			}
			else
			{
				DialogueLua.relationshipTable.Add(relationshipKey, -decrementAmount);
			}
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x00022958 File Offset: 0x00020B58
		public static string GetStatusTableAsLua()
		{
			StringBuilder stringBuilder = new StringBuilder(1024, 65536);
			stringBuilder.Append("StatusTable = \"");
			foreach (KeyValuePair<string, string> keyValuePair in DialogueLua.statusTable)
			{
				stringBuilder.AppendFormat("{0},'{1}';", new object[]
				{
					keyValuePair.Key,
					DialogueLua.SanitizeForStatusTable(keyValuePair.Value)
				});
			}
			stringBuilder.Append("\"; ");
			return stringBuilder.ToString();
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00022A10 File Offset: 0x00020C10
		public static string GetRelationshipTableAsLua()
		{
			StringBuilder stringBuilder = new StringBuilder(1024, 65536);
			stringBuilder.Append("RelationshipTable = \"");
			foreach (KeyValuePair<string, float> keyValuePair in DialogueLua.relationshipTable)
			{
				stringBuilder.AppendFormat("{0},{1};", new object[] { keyValuePair.Key, keyValuePair.Value });
			}
			stringBuilder.Append("\"; ");
			return stringBuilder.ToString();
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x00022AC8 File Offset: 0x00020CC8
		public static void RefreshStatusTableFromLua()
		{
			DialogueLua.statusTable.Clear();
			string asString = Lua.Run("return StatusTable").AsString;
			char[] array = new char[] { ';' };
			char[] array2 = new char[] { ',' };
			foreach (string text in asString.Split(array))
			{
				string[] array4 = text.Split(array2);
				if (array4.Length > 2)
				{
					string text2 = array4[0] + ',' + array4[1];
					string text3 = array4[2].Substring(1, array4[2].Length - 2);
					DialogueLua.statusTable[text2] = text3;
				}
			}
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x00022B84 File Offset: 0x00020D84
		public static void RefreshRelationshipTableFromLua()
		{
			DialogueLua.relationshipTable.Clear();
			string asString = Lua.Run("return RelationshipTable").AsString;
			char[] array = new char[] { ';' };
			char[] array2 = new char[] { ',' };
			foreach (string text in asString.Split(array))
			{
				string[] array4 = text.Split(array2);
				if (array4.Length > 3)
				{
					string text2 = string.Format("{0},{1},{2}", new string[]
					{
						array4[0],
						array4[1],
						array4[2]
					});
					float num = Tools.StringToFloat(array4[3]);
					DialogueLua.relationshipTable[text2] = num;
				}
			}
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00022C44 File Offset: 0x00020E44
		public static string DoubleQuotesToSingle(string s)
		{
			return (!string.IsNullOrEmpty(s)) ? s.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", string.Empty) : string.Empty;
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x00022C94 File Offset: 0x00020E94
		public static string SpacesToUnderscores(string s)
		{
			return (!string.IsNullOrEmpty(s)) ? s.Replace(' ', '_') : string.Empty;
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x00022CB8 File Offset: 0x00020EB8
		public static string StringToTableIndex(string s)
		{
			return (!string.IsNullOrEmpty(s)) ? DialogueLua.SpacesToUnderscores(DialogueLua.DoubleQuotesToSingle(s.Replace('"', '_'))).Replace('-', '_').Replace('(', '_')
				.Replace(')', '_') : string.Empty;
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x00022D0C File Offset: 0x00020F0C
		public static string StringToLocalizedTableIndex(string s)
		{
			if (Localization.IsDefaultLanguage || string.IsNullOrEmpty(s))
			{
				return DialogueLua.StringToTableIndex(s);
			}
			return DialogueLua.StringToTableIndex(s + "_" + Localization.Language);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00022D4C File Offset: 0x00020F4C
		public static bool DoesTableElementExist(string table, string element)
		{
			LuaTable luaTable = Lua.Environment.GetValue(table) as LuaTable;
			return luaTable != null && luaTable.GetKey(DialogueLua.StringToTableIndex(element)) != LuaNil.Nil;
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00022D8C File Offset: 0x00020F8C
		public static Lua.Result GetTableField(string table, string element, string field)
		{
			LuaTable luaTable = Lua.Environment.GetValue(table) as LuaTable;
			if (luaTable == null)
			{
				return Lua.NoResult;
			}
			LuaTable luaTable2 = luaTable.GetValue(DialogueLua.StringToTableIndex(element)) as LuaTable;
			if (luaTable2 == null)
			{
				return Lua.NoResult;
			}
			LuaValue value = luaTable2.GetValue(DialogueLua.StringToTableIndex(field));
			return (value == null || value == LuaNil.Nil) ? Lua.NoResult : new Lua.Result(value);
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x00022E04 File Offset: 0x00021004
		public static void SetTableField(string table, string element, string field, object value)
		{
			Lua.WasInvoked = true;
			LuaTable luaTable = Lua.Environment.GetValue(table) as LuaTable;
			if (luaTable == null)
			{
				throw new NullReferenceException("Table not found in Lua environment: " + table);
			}
			LuaTable luaTable2 = luaTable.GetValue(DialogueLua.StringToTableIndex(element)) as LuaTable;
			if (luaTable2 == null)
			{
				Lua.Run(string.Format("{0}[\"{1}\"] = {{}}", table, DialogueLua.StringToTableIndex(element)));
				luaTable2 = luaTable.GetValue(DialogueLua.StringToTableIndex(element)) as LuaTable;
				if (luaTable2 == null)
				{
					throw new NullReferenceException("Unable to find or add element: " + element);
				}
			}
			luaTable2.SetNameValue(DialogueLua.StringToTableIndex(field), LuaInterpreterExtensions.ObjectToLuaValue(value));
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x00022EAC File Offset: 0x000210AC
		public static Lua.Result GetActorField(string actor, string field)
		{
			return DialogueLua.GetTableField("Actor", actor, field);
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x00022EBC File Offset: 0x000210BC
		public static void SetActorField(string actor, string field, object value)
		{
			DialogueLua.SetTableField("Actor", actor, field, value);
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x00022ECC File Offset: 0x000210CC
		public static Lua.Result GetItemField(string item, string field)
		{
			return DialogueLua.GetTableField("Item", item, field);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x00022EDC File Offset: 0x000210DC
		public static void SetItemField(string item, string field, object value)
		{
			DialogueLua.SetTableField("Item", item, field, value);
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x00022EEC File Offset: 0x000210EC
		public static Lua.Result GetQuestField(string quest, string field)
		{
			return DialogueLua.GetTableField("Item", quest, field);
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x00022EFC File Offset: 0x000210FC
		public static void SetQuestField(string quest, string field, object value)
		{
			DialogueLua.SetTableField("Item", quest, field, value);
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x00022F0C File Offset: 0x0002110C
		public static Lua.Result GetLocationField(string location, string field)
		{
			return DialogueLua.GetTableField("Location", location, field);
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x00022F1C File Offset: 0x0002111C
		public static void SetLocationField(string location, string field, object value)
		{
			DialogueLua.SetTableField("Location", location, field, value);
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x00022F2C File Offset: 0x0002112C
		public static bool DoesVariableExist(string variable)
		{
			return DialogueLua.DoesTableElementExist("Variable", variable);
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x00022F3C File Offset: 0x0002113C
		public static Lua.Result GetVariable(string variable)
		{
			LuaTable luaTable = Lua.Environment.GetValue("Variable") as LuaTable;
			return (luaTable == null) ? Lua.NoResult : new Lua.Result(luaTable.GetValue(DialogueLua.StringToTableIndex(variable)));
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x00022F80 File Offset: 0x00021180
		public static void SetVariable(string variable, object value)
		{
			Lua.WasInvoked = true;
			LuaTable luaTable = Lua.Environment.GetValue("Variable") as LuaTable;
			if (luaTable == null)
			{
				return;
			}
			luaTable.SetNameValue(DialogueLua.StringToTableIndex(variable), LuaInterpreterExtensions.ObjectToLuaValue(value));
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x00022FC4 File Offset: 0x000211C4
		public static Lua.Result GetLocalizedTableField(string table, string element, string field)
		{
			Lua.Result tableField = DialogueLua.GetTableField(table, element, DialogueLua.StringToLocalizedTableIndex(field));
			if (Localization.UseDefaultIfUndefined && (tableField.luaValue == null || tableField.luaValue is LuaNil || (tableField.luaValue is LuaString && string.IsNullOrEmpty((tableField.luaValue as LuaString).Text))))
			{
				return DialogueLua.GetTableField(table, element, field);
			}
			return tableField;
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0002303C File Offset: 0x0002123C
		public static void SetLocalizedTableField(string table, string element, string field, object value)
		{
			DialogueLua.SetTableField(table, element, DialogueLua.StringToLocalizedTableIndex(field), value);
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x0002304C File Offset: 0x0002124C
		public static Lua.Result GetLocalizedActorField(string actor, string field)
		{
			return DialogueLua.GetLocalizedTableField("Actor", actor, field);
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0002305C File Offset: 0x0002125C
		public static void SetLocalizedActorField(string actor, string field, object value)
		{
			DialogueLua.SetActorField(actor, DialogueLua.StringToLocalizedTableIndex(field), value);
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x0002306C File Offset: 0x0002126C
		public static Lua.Result GetLocalizedItemField(string item, string field)
		{
			return DialogueLua.GetLocalizedTableField("Item", item, field);
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0002307C File Offset: 0x0002127C
		public static void SetLocalizedItemField(string item, string field, object value)
		{
			DialogueLua.SetItemField(item, DialogueLua.StringToLocalizedTableIndex(field), value);
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x0002308C File Offset: 0x0002128C
		public static Lua.Result GetLocalizedQuestField(string quest, string field)
		{
			return DialogueLua.GetLocalizedItemField(quest, field);
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x00023098 File Offset: 0x00021298
		public static void SetLocalizedQuestField(string quest, string field, object value)
		{
			DialogueLua.SetLocalizedItemField(quest, field, value);
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x000230A4 File Offset: 0x000212A4
		public static Lua.Result GetLocalizedLocationField(string location, string field)
		{
			return DialogueLua.GetLocalizedTableField("Location", location, field);
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x000230B4 File Offset: 0x000212B4
		public static void SetLocalizedLocationField(string location, string field, object value)
		{
			DialogueLua.SetLocationField(location, DialogueLua.StringToLocalizedTableIndex(field), value);
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x000230C4 File Offset: 0x000212C4
		public static Lua.Result GetConversationField(int conversationID, string field)
		{
			return Lua.Run(string.Format("return Conversation[{0}].{1}", new object[]
			{
				conversationID,
				DialogueLua.StringToTableIndex(field)
			}), false, true);
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x000230F0 File Offset: 0x000212F0
		public static Lua.Result GetLocalizedConversationField(int conversationID, string field)
		{
			return Lua.Run(string.Format("return Conversation[{0}].{1}", new object[]
			{
				conversationID,
				DialogueLua.StringToLocalizedTableIndex(field)
			}), false, true);
		}

		// Token: 0x04000DAC RID: 3500
		public static bool includeSimStatus = true;

		// Token: 0x04000DAD RID: 3501
		private static Dictionary<string, string> statusTable = new Dictionary<string, string>();

		// Token: 0x04000DAE RID: 3502
		private static Dictionary<string, float> relationshipTable = new Dictionary<string, float>();
	}
}
