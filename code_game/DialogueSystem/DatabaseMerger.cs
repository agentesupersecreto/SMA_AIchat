using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000213 RID: 531
	public static class DatabaseMerger
	{
		// Token: 0x060017E3 RID: 6115 RVA: 0x0001EE44 File Offset: 0x0001D044
		public static void Merge(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.ConflictingIDRule conflictingIDRule, bool mergeProperties, bool mergeActors, bool mergeItems, bool mergeLocations, bool mergeVariables, bool mergeConversations)
		{
			if (destination != null && source != null)
			{
				switch (conflictingIDRule)
				{
				case DatabaseMerger.ConflictingIDRule.ReplaceConflictingIDs:
					DatabaseMerger.MergeReplaceConflictingIDs(destination, source, mergeProperties, mergeActors, mergeItems, mergeLocations, mergeVariables, mergeConversations);
					break;
				case DatabaseMerger.ConflictingIDRule.AllowConflictingIDs:
					DatabaseMerger.MergeAllowConflictingIDs(destination, source, mergeProperties, mergeActors, mergeItems, mergeLocations, mergeVariables, mergeConversations);
					break;
				case DatabaseMerger.ConflictingIDRule.AssignUniqueIDs:
					DatabaseMerger.MergeAssignUniqueIDs(destination, source, mergeProperties, mergeActors, mergeItems, mergeLocations, mergeVariables, mergeConversations);
					break;
				default:
					Debug.LogError(string.Format("{0}: Internal error. Unsupported merge type: {1}", new object[] { "Dialogue System", conflictingIDRule }));
					break;
				}
			}
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x0001EEF4 File Offset: 0x0001D0F4
		public static void Merge(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.ConflictingIDRule conflictingIDRule)
		{
			DatabaseMerger.Merge(destination, source, conflictingIDRule, true, true, true, true, true, true);
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x0001EF10 File Offset: 0x0001D110
		private static void MergeDatabaseProperties(DialogueDatabase destination, DialogueDatabase source)
		{
			if (string.IsNullOrEmpty(destination.author))
			{
				destination.author = source.author;
			}
			if (string.IsNullOrEmpty(destination.version))
			{
				destination.version = source.version;
			}
			if (string.IsNullOrEmpty(destination.description))
			{
				destination.description = source.description;
			}
			if (!string.IsNullOrEmpty(source.globalUserScript))
			{
				if (string.IsNullOrEmpty(destination.globalUserScript))
				{
					destination.globalUserScript = source.description;
				}
				else
				{
					destination.globalUserScript = string.Format("{0}; {1}", new object[] { destination.globalUserScript, source.globalUserScript });
				}
			}
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x0001EFCC File Offset: 0x0001D1CC
		private static void MergeReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source, bool mergeProperties, bool mergeActors, bool mergeItems, bool mergeLocations, bool mergeVariables, bool mergeConversations)
		{
			if (mergeProperties)
			{
				DatabaseMerger.MergeDatabaseProperties(destination, source);
			}
			if (mergeActors)
			{
				DatabaseMerger.MergeActorsReplaceConflictingIDs(destination, source);
			}
			if (mergeItems)
			{
				DatabaseMerger.MergeItemsReplaceConflictingIDs(destination, source);
			}
			if (mergeLocations)
			{
				DatabaseMerger.MergeLocationsReplaceConflictingIDs(destination, source);
			}
			if (mergeVariables)
			{
				DatabaseMerger.MergeVariablesReplaceConflictingIDs(destination, source);
			}
			if (mergeConversations)
			{
				DatabaseMerger.MergeConversationsReplaceConflictingIDs(destination, source);
			}
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x0001F02C File Offset: 0x0001D22C
		private static void MergeActorsReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Actor actor;
			foreach (Actor actor2 in source.actors)
			{
				actor = actor2;
				destination.actors.RemoveAll((Actor x) => x.id == actor.id);
				destination.actors.Add(actor);
			}
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
		private static void MergeItemsReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Item item;
			foreach (Item item2 in source.items)
			{
				item = item2;
				destination.items.RemoveAll((Item x) => x.id == item.id);
				destination.items.Add(item);
			}
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x0001F154 File Offset: 0x0001D354
		private static void MergeLocationsReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Location location;
			foreach (Location location2 in source.locations)
			{
				location = location2;
				destination.locations.RemoveAll((Location x) => x.id == location.id);
				destination.locations.Add(location);
			}
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x0001F1E8 File Offset: 0x0001D3E8
		private static void MergeVariablesReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Variable variable;
			foreach (Variable variable2 in source.variables)
			{
				variable = variable2;
				destination.variables.RemoveAll((Variable x) => x.id == variable.id);
				destination.variables.Add(variable);
			}
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x0001F27C File Offset: 0x0001D47C
		private static void MergeConversationsReplaceConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Conversation conversation;
			foreach (Conversation conversation2 in source.conversations)
			{
				conversation = conversation2;
				destination.conversations.RemoveAll((Conversation x) => x.id == conversation.id);
				destination.conversations.Add(conversation);
			}
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x0001F310 File Offset: 0x0001D510
		private static void MergeAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source, bool mergeProperties, bool mergeActors, bool mergeItems, bool mergeLocations, bool mergeVariables, bool mergeConversations)
		{
			if (mergeProperties)
			{
				DatabaseMerger.MergeDatabaseProperties(destination, source);
			}
			if (mergeActors)
			{
				DatabaseMerger.MergeActorsAllowConflictingIDs(destination, source);
			}
			if (mergeItems)
			{
				DatabaseMerger.MergeItemsAllowConflictingIDs(destination, source);
			}
			if (mergeLocations)
			{
				DatabaseMerger.MergeLocationsAllowConflictingIDs(destination, source);
			}
			if (mergeVariables)
			{
				DatabaseMerger.MergeVariablesAllowConflictingIDs(destination, source);
			}
			if (mergeConversations)
			{
				DatabaseMerger.MergeConversationsAllowConflictingIDs(destination, source);
			}
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x0001F370 File Offset: 0x0001D570
		private static void MergeActorsAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			foreach (Actor actor in source.actors)
			{
				destination.actors.Add(actor);
			}
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x0001F3DC File Offset: 0x0001D5DC
		private static void MergeItemsAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			foreach (Item item in source.items)
			{
				destination.items.Add(item);
			}
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0001F448 File Offset: 0x0001D648
		private static void MergeLocationsAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			foreach (Location location in source.locations)
			{
				destination.locations.Add(location);
			}
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x0001F4B4 File Offset: 0x0001D6B4
		private static void MergeVariablesAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			foreach (Variable variable in source.variables)
			{
				destination.variables.Add(variable);
			}
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x0001F520 File Offset: 0x0001D720
		private static void MergeConversationsAllowConflictingIDs(DialogueDatabase destination, DialogueDatabase source)
		{
			Conversation conversation;
			foreach (Conversation conversation4 in source.conversations)
			{
				conversation = conversation4;
				Conversation conversation2 = destination.conversations.Find((Conversation c) => string.Equals(c.Title, conversation.Title));
				if (conversation2 != null)
				{
					Conversation conversation3 = new Conversation(conversation);
					conversation3.Title = conversation.Title + " Copy";
					destination.conversations.Add(conversation3);
				}
				else
				{
					destination.conversations.Add(conversation);
				}
			}
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
		private static void MergeAssignUniqueIDs(DialogueDatabase destination, DialogueDatabase source, bool mergeProperties, bool mergeActors, bool mergeItems, bool mergeLocations, bool mergeVariables, bool mergeConversations)
		{
			if (mergeProperties)
			{
				DatabaseMerger.MergeDatabaseProperties(destination, source);
			}
			DatabaseMerger.NewIDs newIDs = new DatabaseMerger.NewIDs();
			DatabaseMerger.GetNewActorIDs(destination, source, newIDs);
			DatabaseMerger.GetNewItemIDs(destination, source, newIDs);
			DatabaseMerger.GetNewLocationIDs(destination, source, newIDs);
			DatabaseMerger.GetNewVariableIDs(destination, source, newIDs);
			DatabaseMerger.GetNewConversationIDs(destination, source, newIDs);
			if (mergeActors)
			{
				DatabaseMerger.MergeActors(destination, source, newIDs);
			}
			if (mergeItems)
			{
				DatabaseMerger.MergeItems(destination, source, newIDs);
			}
			if (mergeLocations)
			{
				DatabaseMerger.MergeLocations(destination, source, newIDs);
			}
			if (mergeVariables)
			{
				DatabaseMerger.MergeVariables(destination, source, newIDs);
			}
			if (mergeConversations)
			{
				DatabaseMerger.MergeConversations(destination, source, newIDs);
			}
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x0001F688 File Offset: 0x0001D888
		private static void GetNewActorIDs(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			int num = 0;
			foreach (Actor actor3 in destination.actors)
			{
				num = Mathf.Max(actor3.id, num);
				if (actor3.IsPlayer)
				{
					newIDs.destinationHasPlayerActor = true;
				}
			}
			int num2 = num + 1;
			Actor actor;
			foreach (Actor actor2 in source.actors)
			{
				actor = actor2;
				if ((!actor.IsPlayer || !newIDs.destinationHasPlayerActor) && destination.actors.Find((Actor x) => string.Equals(x.Name, actor.Name)) == null)
				{
					newIDs.actor[actor.id] = num2;
					num2++;
				}
			}
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x0001F7C0 File Offset: 0x0001D9C0
		private static void GetNewItemIDs(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			int num = 0;
			foreach (Item item3 in destination.items)
			{
				num = Mathf.Max(item3.id, num);
			}
			int num2 = num + 1;
			Item item;
			foreach (Item item2 in source.items)
			{
				item = item2;
				if (destination.items.Find((Item x) => string.Equals(x.Name, item.Name)) == null)
				{
					newIDs.item[item.id] = num2;
					num2++;
				}
			}
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x0001F8C8 File Offset: 0x0001DAC8
		private static void GetNewLocationIDs(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			int num = 0;
			foreach (Location location3 in destination.locations)
			{
				num = Mathf.Max(location3.id, num);
			}
			int num2 = num + 1;
			Location location;
			foreach (Location location2 in source.locations)
			{
				location = location2;
				if (destination.locations.Find((Location x) => string.Equals(x.Name, location.Name)) == null)
				{
					newIDs.location[location.id] = num2;
					num2++;
				}
			}
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0001F9D0 File Offset: 0x0001DBD0
		private static void GetNewVariableIDs(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			int num = 0;
			foreach (Variable variable3 in destination.variables)
			{
				num = Mathf.Max(variable3.id, num);
				if (string.Equals(variable3.Name, "Alert"))
				{
					newIDs.destinationHasAlertVariable = true;
				}
			}
			int num2 = num + 1;
			Variable variable;
			foreach (Variable variable2 in source.variables)
			{
				variable = variable2;
				if ((!string.Equals(variable.Name, "Alert") || !newIDs.destinationHasAlertVariable) && destination.variables.Find((Variable x) => string.Equals(x.Name, variable.Name)) == null)
				{
					newIDs.variable[variable.id] = num2;
					num2++;
				}
			}
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0001FB1C File Offset: 0x0001DD1C
		private static void GetNewConversationIDs(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			int num = 0;
			foreach (Conversation conversation in destination.conversations)
			{
				num = Mathf.Max(conversation.id, num);
			}
			int num2 = num + 1;
			foreach (Conversation conversation2 in source.conversations)
			{
				newIDs.conversation[conversation2.id] = num2;
				num2++;
			}
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0001FBF8 File Offset: 0x0001DDF8
		private static void ConvertFieldIDs(List<Field> fields, DatabaseMerger.NewIDs newIDs)
		{
			foreach (Field field in fields)
			{
				int num = Tools.StringToInt(field.value);
				switch (field.type)
				{
				case FieldType.Actor:
					if (newIDs.actor.ContainsKey(num))
					{
						field.value = newIDs.actor[num].ToString();
					}
					break;
				case FieldType.Item:
					if (newIDs.item.ContainsKey(num))
					{
						field.value = newIDs.item[num].ToString();
					}
					break;
				case FieldType.Location:
					if (newIDs.location.ContainsKey(num))
					{
						field.value = newIDs.location[num].ToString();
					}
					break;
				}
			}
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x0001FD14 File Offset: 0x0001DF14
		private static void MergeActors(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			foreach (Actor actor in source.actors)
			{
				if (newIDs.actor.ContainsKey(actor.id))
				{
					Actor actor2 = new Actor(actor);
					actor2.id = newIDs.actor[actor.id];
					DatabaseMerger.ConvertFieldIDs(actor2.fields, newIDs);
					destination.actors.Add(actor2);
				}
			}
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
		private static void MergeItems(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			foreach (Item item in source.items)
			{
				if (newIDs.item.ContainsKey(item.id))
				{
					Item item2 = new Item(item);
					item2.id = newIDs.item[item.id];
					DatabaseMerger.ConvertFieldIDs(item2.fields, newIDs);
					destination.items.Add(item2);
				}
			}
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0001FE6C File Offset: 0x0001E06C
		private static void MergeLocations(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			foreach (Location location in source.locations)
			{
				if (newIDs.location.ContainsKey(location.id))
				{
					Location location2 = new Location(location);
					location2.id = newIDs.location[location.id];
					DatabaseMerger.ConvertFieldIDs(location2.fields, newIDs);
					destination.locations.Add(location2);
				}
			}
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0001FF18 File Offset: 0x0001E118
		private static void MergeVariables(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			foreach (Variable variable in source.variables)
			{
				if (newIDs.variable.ContainsKey(variable.id))
				{
					Variable variable2 = new Variable(variable);
					variable2.id = newIDs.variable[variable.id];
					DatabaseMerger.ConvertFieldIDs(variable2.fields, newIDs);
					destination.variables.Add(variable2);
				}
			}
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x0001FFC4 File Offset: 0x0001E1C4
		private static void MergeConversations(DialogueDatabase destination, DialogueDatabase source, DatabaseMerger.NewIDs newIDs)
		{
			Conversation conversation;
			foreach (Conversation conversation4 in source.conversations)
			{
				conversation = conversation4;
				if (newIDs.conversation.ContainsKey(conversation.id))
				{
					Conversation conversation2 = new Conversation(conversation);
					conversation2.id = newIDs.conversation[conversation.id];
					Conversation conversation3 = destination.conversations.Find((Conversation c) => string.Equals(c.Title, conversation.Title));
					if (conversation3 != null)
					{
						conversation2.Title = conversation.Title + " Copy";
					}
					DatabaseMerger.ConvertFieldIDs(conversation2.fields, newIDs);
					foreach (DialogueEntry dialogueEntry in conversation2.dialogueEntries)
					{
						dialogueEntry.conversationID = conversation2.id;
						foreach (Link link in dialogueEntry.outgoingLinks)
						{
							if (newIDs.conversation.ContainsKey(link.originConversationID))
							{
								link.originConversationID = newIDs.conversation[link.originConversationID];
							}
							if (newIDs.conversation.ContainsKey(link.destinationConversationID))
							{
								link.destinationConversationID = newIDs.conversation[link.destinationConversationID];
							}
						}
					}
					destination.conversations.Add(conversation2);
				}
			}
		}

		// Token: 0x02000214 RID: 532
		public enum ConflictingIDRule
		{
			// Token: 0x04000D7E RID: 3454
			ReplaceConflictingIDs,
			// Token: 0x04000D7F RID: 3455
			AllowConflictingIDs,
			// Token: 0x04000D80 RID: 3456
			AssignUniqueIDs
		}

		// Token: 0x02000215 RID: 533
		private class NewIDs
		{
			// Token: 0x04000D81 RID: 3457
			public bool destinationHasPlayerActor;

			// Token: 0x04000D82 RID: 3458
			public bool destinationHasAlertVariable;

			// Token: 0x04000D83 RID: 3459
			public Dictionary<int, int> actor = new Dictionary<int, int>();

			// Token: 0x04000D84 RID: 3460
			public Dictionary<int, int> item = new Dictionary<int, int>();

			// Token: 0x04000D85 RID: 3461
			public Dictionary<int, int> location = new Dictionary<int, int>();

			// Token: 0x04000D86 RID: 3462
			public Dictionary<int, int> variable = new Dictionary<int, int>();

			// Token: 0x04000D87 RID: 3463
			public Dictionary<int, int> conversation = new Dictionary<int, int>();
		}
	}
}
