using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Language.Lua;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000278 RID: 632
	public static class PersistentDataManager
	{
		// Token: 0x06001B63 RID: 7011 RVA: 0x00030324 File Offset: 0x0002E524
		public static void RegisterPersistentData(GameObject go)
		{
			if (go == null || !Application.isPlaying)
			{
				return;
			}
			PersistentDataManager.listeners.Add(go);
		}

		// Token: 0x06001B64 RID: 7012 RVA: 0x0003034C File Offset: 0x0002E54C
		public static void UnregisterPersistentData(GameObject go)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			PersistentDataManager.listeners.Remove(go);
		}

		// Token: 0x06001B65 RID: 7013 RVA: 0x00030368 File Offset: 0x0002E568
		public static void Reset(DatabaseResetOptions databaseResetOptions)
		{
			DialogueManager.ResetDatabase(databaseResetOptions);
		}

		// Token: 0x06001B66 RID: 7014 RVA: 0x00030370 File Offset: 0x0002E570
		public static void Reset()
		{
			PersistentDataManager.Reset(DatabaseResetOptions.KeepAllLoaded);
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x00030378 File Offset: 0x0002E578
		public static void Record()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Recording persistent data to Lua environment.", new object[] { "Dialogue System" }));
			}
			PersistentDataManager.SendPersistentDataMessage("OnRecordPersistentData");
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x000303AC File Offset: 0x0002E5AC
		public static void Apply()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Applying persistent data from Lua environment.", new object[] { "Dialogue System" }));
			}
			PersistentDataManager.SendPersistentDataMessage("OnApplyPersistentData");
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x000303E0 File Offset: 0x0002E5E0
		private static void SendPersistentDataMessage(string message)
		{
			PersistentDataManager.RecordPersistentDataOn recordPersistentDataOn = PersistentDataManager.recordPersistentDataOn;
			if (recordPersistentDataOn != PersistentDataManager.RecordPersistentDataOn.AllGameObjects)
			{
				if (recordPersistentDataOn == PersistentDataManager.RecordPersistentDataOn.OnlyRegisteredGameObjects)
				{
					foreach (GameObject gameObject in PersistentDataManager.listeners)
					{
						if (gameObject != null)
						{
							gameObject.SendMessage(message, SendMessageOptions.DontRequireReceiver);
						}
					}
				}
			}
			else
			{
				Tools.SendMessageToEveryone(message);
			}
		}

		// Token: 0x06001B6A RID: 7018 RVA: 0x00030480 File Offset: 0x0002E680
		public static void LevelWillBeUnloaded()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Broadcasting that level will be unloaded.", new object[] { "Dialogue System" }));
			}
			PersistentDataManager.SendPersistentDataMessage("OnLevelWillBeUnloaded");
		}

		// Token: 0x06001B6B RID: 7019 RVA: 0x000304B4 File Offset: 0x0002E6B4
		public static void ApplySaveData(string saveData, DatabaseResetOptions databaseResetOptions = DatabaseResetOptions.KeepAllLoaded)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Resetting Lua environment.", new object[] { "Dialogue System" }));
			}
			DialogueManager.ResetDatabase(databaseResetOptions);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Updating Lua environment with saved data.", new object[] { "Dialogue System" }));
			}
			Lua.Run(saveData, DialogueDebug.LogInfo);
			PersistentDataManager.ExpandCompressedSimStatusData();
			PersistentDataManager.RefreshRelationshipAndStatusTablesFromLua();
			PersistentDataManager.Apply();
		}

		// Token: 0x06001B6C RID: 7020 RVA: 0x00030530 File Offset: 0x0002E730
		public static string GetSaveData()
		{
			PersistentDataManager.Record();
			StringBuilder stringBuilder = new StringBuilder();
			PersistentDataManager.AppendDialogueSystemData(stringBuilder);
			string text = stringBuilder.ToString();
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Saved data: {1}", new object[] { "Dialogue System", text }));
			}
			return text;
		}

		// Token: 0x06001B6D RID: 7021 RVA: 0x00030584 File Offset: 0x0002E784
		public static void AppendDialogueSystemData(StringBuilder sb)
		{
			if (sb == null)
			{
				return;
			}
			PersistentDataManager.AppendVariableData(sb);
			PersistentDataManager.AppendItemData(sb);
			PersistentDataManager.AppendLocationData(sb);
			if (PersistentDataManager.includeActorData)
			{
				PersistentDataManager.AppendActorData(sb);
			}
			PersistentDataManager.AppendConversationData(sb);
			if (PersistentDataManager.includeRelationshipAndStatusData)
			{
				PersistentDataManager.AppendRelationshipAndStatusTables(sb);
			}
			if (PersistentDataManager.GetCustomSaveData != null)
			{
				sb.Append(PersistentDataManager.GetCustomSaveData());
			}
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x000305EC File Offset: 0x0002E7EC
		public static void AppendVariableData(StringBuilder sb)
		{
			try
			{
				LuaTableWrapper asTable = Lua.Run("return Variable").AsTable;
				if (asTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Persistent Data Manager couldn't access Lua Variable[] table", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					sb.Append("Variable={");
					bool flag = true;
					foreach (string text in asTable.Keys)
					{
						if (!flag)
						{
							sb.Append(", ");
						}
						flag = false;
						object obj = asTable[text.ToString()];
						sb.AppendFormat("{0}={1}", new object[]
						{
							PersistentDataManager.GetFieldKeyString(text),
							PersistentDataManager.GetFieldValueString(obj)
						});
					}
					sb.Append("}; ");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get variable data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x0003073C File Offset: 0x0002E93C
		public static void AppendItemData(StringBuilder sb)
		{
			try
			{
				LuaTableWrapper asTable = Lua.Run("return Item").AsTable;
				if (asTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Persistent Data Manager couldn't access Lua Item[] table", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					string title;
					foreach (string text in asTable.Keys)
					{
						title = text;
						LuaTableWrapper luaTableWrapper = asTable[title.ToString()] as LuaTableWrapper;
						bool flag = !PersistentDataManager.includeAllItemData && DialogueManager.MasterDatabase.items.Find((Item i) => string.Equals(DialogueLua.StringToTableIndex(i.Name), title)) != null;
						if (luaTableWrapper != null)
						{
							if (flag)
							{
								foreach (string text2 in luaTableWrapper.Keys)
								{
									string text3 = text2.ToString();
									if (text3.EndsWith("State"))
									{
										sb.AppendFormat("Item[\"{0}\"].{1}=\"{2}\"; ", new object[]
										{
											DialogueLua.StringToTableIndex(title),
											text3,
											luaTableWrapper[text3]
										});
									}
									else if (string.Equals(text3, "Track"))
									{
										sb.AppendFormat("Item[\"{0}\"].Track={1}; ", new object[]
										{
											DialogueLua.StringToTableIndex(title),
											luaTableWrapper[text3].ToString().ToLower()
										});
									}
								}
							}
							else
							{
								sb.AppendFormat("Item[\"{0}\"]=", new object[] { DialogueLua.StringToTableIndex(title) });
								PersistentDataManager.AppendFields(sb, luaTableWrapper);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get item data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x000309A0 File Offset: 0x0002EBA0
		private static void AppendFields(StringBuilder sb, LuaTableWrapper fields)
		{
			sb.Append("{");
			try
			{
				if (fields != null)
				{
					foreach (string text in fields.Keys)
					{
						object obj = fields[text.ToString()];
						sb.AppendFormat("{0}={1}, ", new object[]
						{
							PersistentDataManager.GetFieldKeyString(text),
							PersistentDataManager.GetFieldValueString(obj)
						});
					}
				}
			}
			finally
			{
				sb.Append("}; ");
			}
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x00030A6C File Offset: 0x0002EC6C
		private static string GetFieldKeyString(string key)
		{
			key = DialogueLua.StringToTableIndex(key);
			return (!PersistentDataManager.matchValidVarName.IsMatch(key)) ? ("[\"" + key + "\"]") : key;
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x00030AA8 File Offset: 0x0002ECA8
		private static string GetFieldValueString(object o)
		{
			if (o == null)
			{
				return "nil";
			}
			Type type = o.GetType();
			if (type == typeof(string))
			{
				return string.Format("\"{0}\"", new object[] { DialogueLua.DoubleQuotesToSingle(o.ToString().Replace("\n", "\\n")) });
			}
			if (type == typeof(bool))
			{
				return o.ToString().ToLower();
			}
			return o.ToString();
		}

		// Token: 0x06001B73 RID: 7027 RVA: 0x00030B28 File Offset: 0x0002ED28
		public static void AppendLocationData(StringBuilder sb)
		{
			if (!PersistentDataManager.includeLocationData)
			{
				return;
			}
			try
			{
				LuaTableWrapper asTable = Lua.Run("return Location").AsTable;
				if (asTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Persistent Data Manager couldn't access Lua Location[] table", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					sb.Append("Location={");
					bool flag = true;
					foreach (string text in asTable.Keys)
					{
						LuaTableWrapper luaTableWrapper = asTable[text.ToString()] as LuaTableWrapper;
						if (!flag)
						{
							sb.Append(", ");
						}
						flag = false;
						sb.Append(PersistentDataManager.GetFieldKeyString(text));
						sb.Append("={");
						try
						{
							PersistentDataManager.AppendAssetFieldData(sb, luaTableWrapper);
						}
						finally
						{
							sb.Append("}");
						}
					}
					sb.Append("}; ");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get location data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x00030CAC File Offset: 0x0002EEAC
		public static void AppendActorData(StringBuilder sb)
		{
			try
			{
				LuaTableWrapper asTable = Lua.Run("return Actor").AsTable;
				if (asTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Persistent Data Manager couldn't access Lua Actor[] table", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					sb.Append("Actor={");
					bool flag = true;
					foreach (string text in asTable.Keys)
					{
						LuaTableWrapper luaTableWrapper = asTable[text.ToString()] as LuaTableWrapper;
						if (!flag)
						{
							sb.Append(", ");
						}
						flag = false;
						sb.Append(PersistentDataManager.GetFieldKeyString(text));
						sb.Append("={");
						try
						{
							PersistentDataManager.AppendAssetFieldData(sb, luaTableWrapper);
						}
						finally
						{
							sb.Append("}");
						}
					}
					sb.Append("}; ");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get actor data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x00030E28 File Offset: 0x0002F028
		private static void AppendAssetFieldData(StringBuilder sb, LuaTableWrapper fields)
		{
			if (fields == null)
			{
				return;
			}
			bool flag = true;
			foreach (string text in fields.Keys)
			{
				if (!flag)
				{
					sb.Append(", ");
				}
				flag = false;
				object obj = fields[text.ToString()];
				sb.AppendFormat("{0}={1}", new object[]
				{
					PersistentDataManager.GetFieldKeyString(text),
					PersistentDataManager.GetFieldValueString(obj)
				});
			}
		}

		// Token: 0x06001B76 RID: 7030 RVA: 0x00030ED4 File Offset: 0x0002F0D4
		public static void AppendConversationData(StringBuilder sb)
		{
			if (PersistentDataManager.includeAllConversationFields || DialogueManager.Instance.persistentDataSettings.includeAllConversationFields)
			{
				PersistentDataManager.AppendAllConversationFields(sb);
			}
			if (!PersistentDataManager.includeSimStatus || !DialogueManager.Instance.includeSimStatus)
			{
				return;
			}
			try
			{
				bool flag = string.IsNullOrEmpty(PersistentDataManager.saveConversationSimStatusWithField);
				bool flag2 = string.IsNullOrEmpty(PersistentDataManager.saveDialogueEntrySimStatusWithField);
				foreach (Conversation conversation in DialogueManager.MasterDatabase.conversations)
				{
					if (flag)
					{
						sb.AppendFormat("Conversation[{0}].SimX=\"", conversation.id);
					}
					else
					{
						sb.AppendFormat("Variable[\"Conversation_SimX_{0}\"]=\"", DialogueLua.StringToTableIndex(conversation.LookupValue(PersistentDataManager.saveConversationSimStatusWithField)));
					}
					LuaTableWrapper asTable = Lua.Run("return Conversation[" + conversation.id + "]").AsTable;
					LuaTable luaTable = asTable.luaTable.GetValue("Dialog") as LuaTable;
					bool flag3 = true;
					for (int i = 0; i < conversation.dialogueEntries.Count; i++)
					{
						DialogueEntry dialogueEntry = conversation.dialogueEntries[i];
						int id = dialogueEntry.id;
						LuaTable luaTable2 = luaTable.GetValue(id) as LuaTable;
						if (luaTable2 != null)
						{
							if (!flag3)
							{
								sb.Append(";");
							}
							flag3 = false;
							sb.Append((!flag2) ? Field.LookupValue(dialogueEntry.fields, PersistentDataManager.saveDialogueEntrySimStatusWithField) : id.ToString());
							sb.Append(";");
							string text = luaTable2.GetValue("SimStatus").ToString();
							sb.Append(PersistentDataManager.SimStatusToChar(text));
						}
					}
					sb.Append("\"; ");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get conversation data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B77 RID: 7031 RVA: 0x00031124 File Offset: 0x0002F324
		private static void AppendAllConversationFields(StringBuilder sb)
		{
			try
			{
				LuaTableWrapper asTable = Lua.Run("return Conversation").AsTable;
				if (asTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Persistent Data Manager couldn't access Lua Conversation[] table", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					foreach (string text in asTable.Keys)
					{
						LuaTableWrapper asTable2 = Lua.Run("return Conversation[" + text + "]").AsTable;
						if (asTable2 != null)
						{
							sb.Append("Conversation[" + text + "]={");
							try
							{
								bool flag = true;
								foreach (string text2 in asTable2.Keys)
								{
									if (!string.Equals(text2, "Dialog"))
									{
										if (!flag)
										{
											sb.Append(", ");
										}
										flag = false;
										object obj = asTable2[text2.ToString()];
										sb.AppendFormat("{0}={1}", new object[]
										{
											PersistentDataManager.GetFieldKeyString(text2),
											PersistentDataManager.GetFieldValueString(obj)
										});
									}
								}
							}
							finally
							{
								sb.Append("}; ");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get conversation data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B78 RID: 7032 RVA: 0x00031334 File Offset: 0x0002F534
		private static void ExpandCompressedSimStatusData()
		{
			if (!PersistentDataManager.includeSimStatus || !DialogueManager.Instance.includeSimStatus)
			{
				return;
			}
			try
			{
				bool flag = string.IsNullOrEmpty(PersistentDataManager.saveConversationSimStatusWithField);
				bool flag2 = string.IsNullOrEmpty(PersistentDataManager.saveDialogueEntrySimStatusWithField);
				Dictionary<string, DialogueEntry> dictionary = new Dictionary<string, DialogueEntry>();
				foreach (Conversation conversation in DialogueManager.MasterDatabase.conversations)
				{
					if (!flag2)
					{
						dictionary.Clear();
						for (int i = 0; i < conversation.dialogueEntries.Count; i++)
						{
							DialogueEntry dialogueEntry = conversation.dialogueEntries[i];
							string text = Field.LookupValue(dialogueEntry.fields, PersistentDataManager.saveDialogueEntrySimStatusWithField);
							if (!dictionary.ContainsKey(text))
							{
								dictionary.Add(text, dialogueEntry);
							}
						}
					}
					StringBuilder stringBuilder = new StringBuilder();
					string text2;
					if (flag)
					{
						text2 = Lua.Run("return Conversation[" + conversation.id + "].SimX").AsString;
					}
					else
					{
						string text3 = DialogueLua.StringToTableIndex(conversation.LookupValue(PersistentDataManager.saveConversationSimStatusWithField));
						if (string.IsNullOrEmpty(text3))
						{
							text3 = conversation.id.ToString();
						}
						text2 = Lua.Run("return Variable[\"Conversation_SimX_" + text3 + "\"]").AsString;
					}
					if (!string.IsNullOrEmpty(text2) && !string.Equals(text2, "nil"))
					{
						string text4 = ((!flag) ? ("Variable[\"Conversation_SimX_" + DialogueLua.StringToTableIndex(conversation.LookupValue(PersistentDataManager.saveConversationSimStatusWithField)) + "\"]=nil;") : ("Conversation[" + conversation.id + "].SimX=nil;"));
						stringBuilder.Append("Conversation[");
						stringBuilder.Append(conversation.id);
						stringBuilder.Append("].Dialog={}; ");
						string[] array = text2.Split(new char[] { ';' });
						int num = array.Length / 2;
						for (int j = 0; j < num; j++)
						{
							string text5 = array[2 * j];
							string text6;
							if (flag2)
							{
								text6 = text5;
							}
							else
							{
								text6 = ((!dictionary.ContainsKey(text5)) ? "-1" : dictionary[text5].id.ToString());
							}
							string text7 = PersistentDataManager.CharToSimStatus(array[2 * j + 1][0]);
							stringBuilder.Append("Conversation[");
							stringBuilder.Append(conversation.id);
							stringBuilder.Append("].Dialog[");
							stringBuilder.Append(text6);
							stringBuilder.Append("]={SimStatus='");
							stringBuilder.Append(text7);
							stringBuilder.Append("'}; ");
						}
						stringBuilder.Append(text4);
						Lua.Run(stringBuilder.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: ApplySaveData() failed to re-expand compressed SimStatus data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x00031690 File Offset: 0x0002F890
		private static char SimStatusToChar(string simStatus)
		{
			switch (simStatus)
			{
			case "Untouched":
				return 'u';
			case "WasDisplayed":
				return 'd';
			case "WasOffered":
				return 'o';
			}
			return 'X';
		}

		// Token: 0x06001B7A RID: 7034 RVA: 0x00031714 File Offset: 0x0002F914
		private static string CharToSimStatus(char c)
		{
			if (c == 'd')
			{
				return "WasDisplayed";
			}
			if (c == 'o')
			{
				return "WasOffered";
			}
			if (c != 'u')
			{
				return "ERROR";
			}
			return "Untouched";
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x00031758 File Offset: 0x0002F958
		public static void AppendRelationshipAndStatusTables(StringBuilder sb)
		{
			try
			{
				sb.Append(DialogueLua.GetStatusTableAsLua());
				sb.Append(DialogueLua.GetRelationshipTableAsLua());
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("{0}: GetSaveData() failed to get relationship and status data: {1}", new object[] { "Dialogue System", ex.Message }));
			}
		}

		// Token: 0x06001B7C RID: 7036 RVA: 0x000317CC File Offset: 0x0002F9CC
		public static void RefreshRelationshipAndStatusTablesFromLua()
		{
			DialogueLua.RefreshStatusTableFromLua();
			DialogueLua.RefreshRelationshipTableFromLua();
		}

		// Token: 0x06001B7D RID: 7037 RVA: 0x000317D8 File Offset: 0x0002F9D8
		public static PersistentDataManager.AsyncSaveOperation GetSaveDataAsync()
		{
			PersistentDataManager.AsyncSaveOperation asyncSaveOperation = new PersistentDataManager.AsyncSaveOperation();
			DialogueManager.Instance.StartCoroutine(PersistentDataManager.GetSaveDataAsyncCoroutine(asyncSaveOperation));
			return asyncSaveOperation;
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x00031800 File Offset: 0x0002FA00
		private static IEnumerator GetSaveDataAsyncCoroutine(PersistentDataManager.AsyncSaveOperation asyncOp)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Saving data asynchronously...", new object[]
				{
					"Dialogue System",
					PersistentDataManager.asyncGameObjectBatchSize
				}));
			}
			PersistentDataManager.RecordPersistentDataOn recordPersistentDataOn = PersistentDataManager.recordPersistentDataOn;
			if (recordPersistentDataOn != PersistentDataManager.RecordPersistentDataOn.AllGameObjects)
			{
				if (recordPersistentDataOn == PersistentDataManager.RecordPersistentDataOn.OnlyRegisteredGameObjects)
				{
					int count = 0;
					foreach (GameObject go in PersistentDataManager.listeners)
					{
						if (go != null)
						{
							go.SendMessage("OnRecordPersistentData", SendMessageOptions.DontRequireReceiver);
							count++;
							if (count > PersistentDataManager.asyncGameObjectBatchSize)
							{
								count = 0;
								yield return null;
							}
						}
					}
				}
			}
			else
			{
				yield return DialogueManager.Instance.StartCoroutine(Tools.SendMessageToEveryoneAsync("OnRecordPersistentData", PersistentDataManager.asyncGameObjectBatchSize));
			}
			StringBuilder sb = new StringBuilder();
			PersistentDataManager.AppendVariableData(sb);
			yield return null;
			PersistentDataManager.AppendItemData(sb);
			yield return null;
			PersistentDataManager.AppendLocationData(sb);
			yield return null;
			if (PersistentDataManager.includeActorData)
			{
				PersistentDataManager.AppendActorData(sb);
			}
			yield return null;
			yield return DialogueManager.Instance.StartCoroutine(PersistentDataManager.AppendConversationDataAsync(sb));
			yield return null;
			if (PersistentDataManager.includeRelationshipAndStatusData)
			{
				PersistentDataManager.AppendRelationshipAndStatusTables(sb);
			}
			if (PersistentDataManager.GetCustomSaveData != null)
			{
				sb.Append(PersistentDataManager.GetCustomSaveData());
			}
			string saveData = sb.ToString();
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Saved data asynchronously: {1}", new object[] { "Dialogue System", saveData }));
			}
			asyncOp.content = saveData;
			asyncOp.isDone = true;
			yield break;
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x00031824 File Offset: 0x0002FA24
		public static void RecordAsync()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Recording persistent data to Lua environment in batches of {1} GameObjects.", new object[]
				{
					"Dialogue System",
					PersistentDataManager.asyncGameObjectBatchSize
				}));
			}
			DialogueManager.Instance.StartCoroutine(Tools.SendMessageToEveryoneAsync("OnRecordPersistentData", PersistentDataManager.asyncGameObjectBatchSize));
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x00031880 File Offset: 0x0002FA80
		private static IEnumerator AppendConversationDataAsync(StringBuilder sb)
		{
			if (PersistentDataManager.includeAllConversationFields || DialogueManager.Instance.persistentDataSettings.includeAllConversationFields)
			{
				PersistentDataManager.AppendAllConversationFields(sb);
			}
			if (PersistentDataManager.includeSimStatus && DialogueManager.Instance.includeSimStatus)
			{
				int count = 0;
				bool useConversationID = string.IsNullOrEmpty(PersistentDataManager.saveConversationSimStatusWithField);
				bool useEntryID = string.IsNullOrEmpty(PersistentDataManager.saveDialogueEntrySimStatusWithField);
				foreach (Conversation conversation in DialogueManager.MasterDatabase.conversations)
				{
					if (useConversationID)
					{
						sb.AppendFormat("Conversation[{0}].SimX=\"", conversation.id);
					}
					else
					{
						sb.AppendFormat("Variable[\"Conversation_SimX_{0}\"]=\"", DialogueLua.StringToTableIndex(conversation.LookupValue(PersistentDataManager.saveConversationSimStatusWithField)));
					}
					LuaTableWrapper conversationTable = Lua.Run("return Conversation[" + conversation.id + "]").AsTable;
					LuaTable dialogTable = conversationTable.luaTable.GetValue("Dialog") as LuaTable;
					bool first = true;
					for (int i = 0; i < conversation.dialogueEntries.Count; i++)
					{
						try
						{
							DialogueEntry entry = conversation.dialogueEntries[i];
							int entryID = entry.id;
							LuaTable dialogFields = dialogTable.GetValue(entryID) as LuaTable;
							if (dialogFields != null)
							{
								if (!first)
								{
									sb.Append(";");
								}
								first = false;
								sb.Append((!useEntryID) ? Field.LookupValue(entry.fields, PersistentDataManager.saveDialogueEntrySimStatusWithField) : entryID.ToString());
								sb.Append(";");
								string simStatus = dialogFields.GetValue("SimStatus").ToString();
								sb.Append(PersistentDataManager.SimStatusToChar(simStatus));
							}
						}
						catch (Exception ex)
						{
							Exception e = ex;
							Debug.LogError(string.Format("{0}: GetSaveData() failed to get conversation data: {1}", new object[] { "Dialogue System", e.Message }));
						}
						count++;
						if (count >= PersistentDataManager.asyncDialogueEntryBatchSize)
						{
							count = 0;
							yield return null;
						}
					}
					sb.Append("\"; ");
				}
			}
			yield break;
		}

		// Token: 0x04000F65 RID: 3941
		public static bool includeActorData = true;

		// Token: 0x04000F66 RID: 3942
		public static bool includeAllItemData = false;

		// Token: 0x04000F67 RID: 3943
		public static bool includeLocationData = false;

		// Token: 0x04000F68 RID: 3944
		public static bool includeAllConversationFields = false;

		// Token: 0x04000F69 RID: 3945
		public static bool includeSimStatus = false;

		// Token: 0x04000F6A RID: 3946
		public static string saveConversationSimStatusWithField = string.Empty;

		// Token: 0x04000F6B RID: 3947
		public static string saveDialogueEntrySimStatusWithField = string.Empty;

		// Token: 0x04000F6C RID: 3948
		public static bool includeRelationshipAndStatusData = true;

		// Token: 0x04000F6D RID: 3949
		public static GetCustomSaveDataDelegate GetCustomSaveData = null;

		// Token: 0x04000F6E RID: 3950
		public static PersistentDataManager.RecordPersistentDataOn recordPersistentDataOn = PersistentDataManager.RecordPersistentDataOn.AllGameObjects;

		// Token: 0x04000F6F RID: 3951
		private static HashSet<GameObject> listeners = new HashSet<GameObject>();

		// Token: 0x04000F70 RID: 3952
		private static Regex matchValidVarName = new Regex("^[a-zA-Z_][a-zA-Z0-9_]*$");

		// Token: 0x04000F71 RID: 3953
		public static int asyncGameObjectBatchSize = 1000;

		// Token: 0x04000F72 RID: 3954
		public static int asyncDialogueEntryBatchSize = 100;

		// Token: 0x02000279 RID: 633
		public enum RecordPersistentDataOn
		{
			// Token: 0x04000F75 RID: 3957
			AllGameObjects,
			// Token: 0x04000F76 RID: 3958
			OnlyRegisteredGameObjects,
			// Token: 0x04000F77 RID: 3959
			NoGameObjects
		}

		// Token: 0x0200027A RID: 634
		public class AsyncSaveOperation
		{
			// Token: 0x04000F78 RID: 3960
			public bool isDone;

			// Token: 0x04000F79 RID: 3961
			public string content = string.Empty;
		}
	}
}
