using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000210 RID: 528
	public static class ChatMapperToDialogueDatabase
	{
		// Token: 0x060017D7 RID: 6103 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
		public static DialogueDatabase ConvertToDialogueDatabase(ChatMapperProject chatMapperProject)
		{
			DialogueDatabase dialogueDatabase = ScriptableObject.CreateInstance<DialogueDatabase>();
			if (dialogueDatabase == null)
			{
				if (DialogueDebug.LogErrors)
				{
					Debug.LogError(string.Format("{0}: Couldn't convert Chat Mapper project '{1}'.", new object[] { "Dialogue System", chatMapperProject.Title }));
				}
			}
			else
			{
				ChatMapperToDialogueDatabase.ConvertProjectAttributes(chatMapperProject, dialogueDatabase);
				ChatMapperToDialogueDatabase.ConvertActors(chatMapperProject, dialogueDatabase);
				ChatMapperToDialogueDatabase.ConvertItems(chatMapperProject, dialogueDatabase);
				ChatMapperToDialogueDatabase.ConvertLocations(chatMapperProject, dialogueDatabase);
				ChatMapperToDialogueDatabase.ConvertVariables(chatMapperProject, dialogueDatabase);
				ChatMapperToDialogueDatabase.ConvertConversations(chatMapperProject, dialogueDatabase);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Converted Chat Mapper project '{1}' containing {2} actors, {3} conversations, {4} items (quests), {5} variables, and {6} locations.", new object[]
					{
						"Dialogue System",
						chatMapperProject.Title,
						dialogueDatabase.actors.Count,
						dialogueDatabase.conversations.Count,
						dialogueDatabase.items.Count,
						dialogueDatabase.variables.Count,
						dialogueDatabase.locations.Count
					}));
				}
			}
			return dialogueDatabase;
		}

		// Token: 0x060017D8 RID: 6104 RVA: 0x0001E5E0 File Offset: 0x0001C7E0
		private static void ConvertProjectAttributes(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.version = chatMapperProject.Version;
			database.author = chatMapperProject.Author;
			database.description = chatMapperProject.Description;
			database.emphasisSettings = new EmphasisSetting[4];
			database.emphasisSettings[0] = new EmphasisSetting(chatMapperProject.EmphasisColor1, chatMapperProject.EmphasisStyle1);
			database.emphasisSettings[1] = new EmphasisSetting(chatMapperProject.EmphasisColor2, chatMapperProject.EmphasisStyle2);
			database.emphasisSettings[2] = new EmphasisSetting(chatMapperProject.EmphasisColor3, chatMapperProject.EmphasisStyle3);
			database.emphasisSettings[3] = new EmphasisSetting(chatMapperProject.EmphasisColor4, chatMapperProject.EmphasisStyle4);
		}

		// Token: 0x060017D9 RID: 6105 RVA: 0x0001E684 File Offset: 0x0001C884
		private static void ConvertActors(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.actors = new List<Actor>();
			foreach (Actor actor in chatMapperProject.Assets.Actors)
			{
				database.actors.Add(new Actor(actor));
			}
		}

		// Token: 0x060017DA RID: 6106 RVA: 0x0001E704 File Offset: 0x0001C904
		private static void ConvertItems(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.items = new List<Item>();
			foreach (Item item in chatMapperProject.Assets.Items)
			{
				database.items.Add(new Item(item));
			}
		}

		// Token: 0x060017DB RID: 6107 RVA: 0x0001E784 File Offset: 0x0001C984
		private static void ConvertLocations(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.locations = new List<Location>();
			foreach (Location location in chatMapperProject.Assets.Locations)
			{
				database.locations.Add(new Location(location));
			}
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x0001E804 File Offset: 0x0001CA04
		private static void ConvertVariables(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.variables = new List<Variable>();
			int num = 0;
			foreach (UserVariable userVariable in chatMapperProject.Assets.UserVariables)
			{
				Variable variable = new Variable(userVariable);
				variable.id = num;
				num++;
				database.variables.Add(variable);
			}
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x0001E894 File Offset: 0x0001CA94
		private static void ConvertConversations(ChatMapperProject chatMapperProject, DialogueDatabase database)
		{
			database.conversations = new List<Conversation>();
			foreach (Conversation conversation in chatMapperProject.Assets.Conversations)
			{
				Conversation conversation2 = new Conversation(conversation, true);
				ChatMapperToDialogueDatabase.SetConversationStartCutsceneToNone(conversation2);
				ChatMapperToDialogueDatabase.ConvertAudioFilesToSequences(conversation2);
				foreach (DialogueEntry dialogueEntry in conversation2.dialogueEntries)
				{
					foreach (Link link in dialogueEntry.outgoingLinks)
					{
						if (link.destinationConversationID == 0)
						{
							link.destinationConversationID = conversation2.id;
						}
						if (link.originConversationID == 0)
						{
							link.originConversationID = conversation2.id;
						}
					}
				}
				database.conversations.Add(conversation2);
			}
			ChatMapperToDialogueDatabase.FixConversationsLinkedToFirstEntry(database, false);
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x0001EA00 File Offset: 0x0001CC00
		private static void SetConversationStartCutsceneToNone(Conversation conversation)
		{
			DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
			if (firstDialogueEntry == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Conversation '{1}' doesn't have a START dialogue entry.", new object[] { "Dialogue System", conversation.Title }));
				}
			}
			else if (string.IsNullOrEmpty(firstDialogueEntry.Sequence))
			{
				if (Field.FieldExists(firstDialogueEntry.fields, "Sequence"))
				{
					firstDialogueEntry.Sequence = "None()";
				}
				else
				{
					firstDialogueEntry.fields.Add(new Field("Sequence", "None()", FieldType.Text));
				}
			}
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x0001EAA0 File Offset: 0x0001CCA0
		public static void FixConversationsLinkedToFirstEntry(DialogueDatabase database, bool resetNodePositions = false)
		{
			try
			{
				List<int> list = new List<int>();
				foreach (Conversation conversation in database.conversations)
				{
					foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
					{
						if (resetNodePositions)
						{
							dialogueEntry.canvasRect = new Rect(0f, 0f, 160f, 30f);
						}
						foreach (Link link in dialogueEntry.outgoingLinks)
						{
							if (link.destinationDialogueID == 0 && !list.Contains(link.destinationConversationID))
							{
								list.Add(link.destinationConversationID);
							}
						}
					}
				}
				foreach (int num in list)
				{
					DialogueEntry firstDialogueEntry = database.GetConversation(num).GetFirstDialogueEntry();
					int actorID = firstDialogueEntry.ActorID;
					firstDialogueEntry.ActorID = firstDialogueEntry.ConversantID;
					firstDialogueEntry.ConversantID = actorID;
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error fixing up linked conversation: " + ex.Message);
			}
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x0001ECAC File Offset: 0x0001CEAC
		public static void ConvertAudioFilesToSequences(Conversation conversation)
		{
			if (conversation == null || conversation.dialogueEntries == null)
			{
				return;
			}
			foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
			{
				string audioFiles = dialogueEntry.AudioFiles;
				if (!string.IsNullOrEmpty(audioFiles) && !string.Equals("[]", audioFiles))
				{
					string text = audioFiles.Substring(1, audioFiles.IndexOfAny(new char[] { ';', ']' }) - 1);
					text = text.Substring(0, text.LastIndexOf('.'));
					text = text.Replace("\\", "/");
					if (text.StartsWith("Resources/", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(10);
					}
					string text2 = string.Format("AudioWait({0})", text);
					if (dialogueEntry.Sequence != null && !dialogueEntry.Sequence.Contains(text2))
					{
						dialogueEntry.Sequence = string.Format("AudioWait({0}); {1}", text, dialogueEntry.Sequence);
					}
				}
			}
		}
	}
}
