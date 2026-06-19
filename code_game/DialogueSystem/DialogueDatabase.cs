using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001C RID: 28
	public class DialogueDatabase : ScriptableObject
	{
		// Token: 0x06000166 RID: 358 RVA: 0x00006B30 File Offset: 0x00004D30
		public void ResetEmphasisSettings()
		{
			this.emphasisSettings[0] = new EmphasisSetting(Color.white, false, false, false);
			this.emphasisSettings[1] = new EmphasisSetting(Color.red, false, false, false);
			this.emphasisSettings[2] = new EmphasisSetting(Color.green, false, false, false);
			this.emphasisSettings[3] = new EmphasisSetting(Color.blue, false, false, false);
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006B94 File Offset: 0x00004D94
		public int playerID
		{
			get
			{
				Actor actor = this.actors.Find((Actor a) => a.IsPlayer);
				return (actor == null) ? 0 : actor.id;
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00006BDC File Offset: 0x00004DDC
		public bool IsPlayerID(int actorID)
		{
			Actor actor = this.actors.Find((Actor a) => a.id == actorID);
			return actor != null && actor.IsPlayer;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00006C20 File Offset: 0x00004E20
		public bool IsPlayer(string actorName)
		{
			Actor actor = this.GetActor(actorName);
			return actor != null && actor.IsPlayer;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00006C44 File Offset: 0x00004E44
		public CharacterType GetCharacterType(int actorID)
		{
			return (!this.IsPlayerID(actorID)) ? CharacterType.NPC : CharacterType.PC;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006C5C File Offset: 0x00004E5C
		public Actor GetActor(string actorName)
		{
			return this.actors.Find((Actor a) => string.Equals(a.Name, actorName));
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006C90 File Offset: 0x00004E90
		public Actor GetActor(int id)
		{
			return this.actors.Find((Actor a) => a.id == id);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006CC4 File Offset: 0x00004EC4
		public Item GetItem(string itemName)
		{
			return this.items.Find((Item i) => string.Equals(i.Name, itemName));
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006CF8 File Offset: 0x00004EF8
		public Item GetItem(int id)
		{
			return this.items.Find((Item i) => i.id == id);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006D2C File Offset: 0x00004F2C
		public Location GetLocation(string locationName)
		{
			return this.locations.Find((Location l) => string.Equals(l.Name, locationName));
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006D60 File Offset: 0x00004F60
		public Location GetLocation(int id)
		{
			return this.locations.Find((Location l) => l.id == id);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006D94 File Offset: 0x00004F94
		public Variable GetVariable(string variableName)
		{
			return this.variables.Find((Variable v) => string.Equals(v.Name, variableName));
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00006DC8 File Offset: 0x00004FC8
		public Variable GetVariable(int id)
		{
			return this.variables.Find((Variable v) => v.id == id);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006DFC File Offset: 0x00004FFC
		public void AddConversation(Conversation conversation)
		{
			this.conversations.Add(conversation);
			LinkTools.SortOutgoingLinks(this, conversation);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006E14 File Offset: 0x00005014
		public Conversation GetConversation(string conversationTitle)
		{
			return this.conversations.Find((Conversation c) => string.Equals(c.Title, conversationTitle));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006E48 File Offset: 0x00005048
		public Conversation GetConversation(int conversationID)
		{
			return this.conversations.Find((Conversation c) => c.id == conversationID);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006E7C File Offset: 0x0000507C
		public DialogueEntry GetDialogueEntry(int conversationID, int dialogueEntryID)
		{
			Conversation conversation = this.GetConversation(conversationID);
			return (conversation == null) ? null : conversation.GetDialogueEntry(dialogueEntryID);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006EA4 File Offset: 0x000050A4
		public DialogueEntry GetDialogueEntry(Link link)
		{
			if (link != null)
			{
				Conversation conversation = this.GetConversation(link.destinationConversationID);
				if (conversation != null && conversation.dialogueEntries != null)
				{
					return conversation.dialogueEntries.Find((DialogueEntry e) => e.id == link.destinationDialogueID);
				}
			}
			return null;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006F08 File Offset: 0x00005108
		public string GetLinkText(Link link)
		{
			DialogueEntry dialogueEntry = this.GetDialogueEntry(link);
			return (dialogueEntry != null) ? dialogueEntry.ResponseButtonText : string.Empty;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00006F34 File Offset: 0x00005134
		public void Add(DialogueDatabase database)
		{
			if (database != null)
			{
				this.AddEmphasisSettings(database.emphasisSettings);
				this.AddGlobalUserScript(database);
				foreach (Actor actor in database.actors)
				{
					if (!DialogueDatabase.Contains(this, actor))
					{
						this.actors.Add(actor);
					}
				}
				foreach (Item item in database.items)
				{
					if (!DialogueDatabase.Contains(this, item))
					{
						this.items.Add(item);
					}
				}
				foreach (Location location in database.locations)
				{
					if (!DialogueDatabase.Contains(this, location))
					{
						this.locations.Add(location);
					}
				}
				foreach (Variable variable in database.variables)
				{
					if (!DialogueDatabase.Contains(this, variable))
					{
						this.variables.Add(variable);
					}
				}
				foreach (Conversation conversation in database.conversations)
				{
					if (!DialogueDatabase.Contains(this, conversation))
					{
						this.conversations.Add(conversation);
					}
				}
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007174 File Offset: 0x00005374
		private void AddEmphasisSettings(EmphasisSetting[] newEmphasisSettings)
		{
			if (this.emphasisSettings == null || this.emphasisSettings.Length < 4)
			{
				this.emphasisSettings = newEmphasisSettings;
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					if (this.emphasisSettings[i] == null || this.emphasisSettings[i].IsEmpty)
					{
						this.emphasisSettings[i] = newEmphasisSettings[i];
					}
				}
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000071E4 File Offset: 0x000053E4
		private void AddGlobalUserScript(DialogueDatabase database)
		{
			if (!string.IsNullOrEmpty(this.globalUserScript))
			{
				if (!string.IsNullOrEmpty(database.globalUserScript))
				{
					this.globalUserScript = string.Format("{0}; {1}", new object[] { this.globalUserScript, database.globalUserScript });
				}
			}
			else if (!string.IsNullOrEmpty(database.globalUserScript))
			{
				this.globalUserScript = database.globalUserScript;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000725C File Offset: 0x0000545C
		public void Remove(DialogueDatabase database)
		{
			if (database != null)
			{
				this.actors.RemoveAll((Actor x) => database.actors.Contains(x));
				this.items.RemoveAll((Item x) => database.items.Contains(x));
				this.locations.RemoveAll((Location x) => database.locations.Contains(x));
				this.variables.RemoveAll((Variable x) => database.variables.Contains(x));
				this.conversations.RemoveAll((Conversation x) => database.conversations.Contains(x));
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00007300 File Offset: 0x00005500
		public void Remove(DialogueDatabase database, List<DialogueDatabase> keep)
		{
			if (database != null)
			{
				this.actors.RemoveAll((Actor x) => database.actors.Contains(x) && !DialogueDatabase.Contains(keep, x));
				this.items.RemoveAll((Item x) => database.items.Contains(x) && !DialogueDatabase.Contains(keep, x));
				this.locations.RemoveAll((Location x) => database.locations.Contains(x) && !DialogueDatabase.Contains(keep, x));
				this.variables.RemoveAll((Variable x) => database.variables.Contains(x) && !DialogueDatabase.Contains(keep, x));
				this.conversations.RemoveAll((Conversation x) => database.conversations.Contains(x) && !DialogueDatabase.Contains(keep, x));
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000073AC File Offset: 0x000055AC
		public void Clear()
		{
			this.actors.Clear();
			this.items.Clear();
			this.locations.Clear();
			this.variables.Clear();
			this.conversations.Clear();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000073F0 File Offset: 0x000055F0
		public void SyncAll()
		{
			this.SyncActors();
			this.SyncItems();
			this.SyncLocations();
			this.SyncVariables();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000740C File Offset: 0x0000560C
		public void SyncActors()
		{
			if (!this.syncInfo.syncActors || this.syncInfo.syncActorsDatabase == null)
			{
				return;
			}
			this.actors.RemoveAll((Actor x) => this.syncInfo.syncActorsDatabase.GetActor(x.id) != null);
			foreach (Actor actor in this.syncInfo.syncActorsDatabase.actors)
			{
				this.actors.Add(new Actor(actor));
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000074C8 File Offset: 0x000056C8
		public void SyncItems()
		{
			if (!this.syncInfo.syncItems || this.syncInfo.syncItemsDatabase == null)
			{
				return;
			}
			this.items.RemoveAll((Item x) => this.syncInfo.syncItemsDatabase.GetItem(x.id) != null);
			foreach (Item item in this.syncInfo.syncItemsDatabase.items)
			{
				this.items.Add(new Item(item));
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00007584 File Offset: 0x00005784
		public void SyncLocations()
		{
			if (!this.syncInfo.syncLocations || this.syncInfo.syncLocationsDatabase == null)
			{
				return;
			}
			this.locations.RemoveAll((Location x) => this.syncInfo.syncLocationsDatabase.GetLocation(x.id) != null);
			foreach (Location location in this.syncInfo.syncLocationsDatabase.locations)
			{
				this.locations.Add(new Location(location));
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00007640 File Offset: 0x00005840
		public void SyncVariables()
		{
			if (!this.syncInfo.syncVariables || this.syncInfo.syncVariablesDatabase == null)
			{
				return;
			}
			this.variables.RemoveAll((Variable x) => this.syncInfo.syncVariablesDatabase.GetVariable(x.id) != null);
			foreach (Variable variable in this.syncInfo.syncVariablesDatabase.variables)
			{
				this.variables.Add(new Variable(variable));
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000076FC File Offset: 0x000058FC
		public static bool ContainsName<T>(List<T> assetList, string assetName) where T : Asset
		{
			return assetList != null && assetList.Find((T x) => string.Equals(x.Name, assetName)) != null;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000773C File Offset: 0x0000593C
		public static bool ContainsID<T>(List<T> assetList, int assetID) where T : Asset
		{
			return assetList != null && assetList.Find((T x) => x.id == assetID) != null;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000777C File Offset: 0x0000597C
		public static bool ContainsTitle(List<Conversation> conversations, string title)
		{
			return conversations != null && conversations.Find((Conversation x) => string.Equals(x.Title, title)) != null;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000077B8 File Offset: 0x000059B8
		public static bool Contains(DialogueDatabase database, Asset asset)
		{
			if (asset == null)
			{
				return false;
			}
			if (asset is Actor)
			{
				return DialogueDatabase.ContainsName<Actor>(database.actors, asset.Name);
			}
			if (asset is Item)
			{
				return DialogueDatabase.ContainsName<Item>(database.items, asset.Name);
			}
			if (asset is Location)
			{
				return DialogueDatabase.ContainsName<Location>(database.locations, asset.Name);
			}
			if (asset is Variable)
			{
				return DialogueDatabase.ContainsName<Variable>(database.variables, asset.Name);
			}
			if (asset is Conversation)
			{
				return DialogueDatabase.ContainsTitle(database.conversations, (asset as Conversation).Title);
			}
			Debug.LogError(string.Format("{0}: Unexpected asset type {1}", new object[]
			{
				"Dialogue System",
				asset.GetType().Name
			}));
			return false;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00007890 File Offset: 0x00005A90
		public static bool Contains(List<DialogueDatabase> databaseList, Asset asset)
		{
			foreach (DialogueDatabase dialogueDatabase in databaseList)
			{
				if (DialogueDatabase.Contains(dialogueDatabase, asset))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00007900 File Offset: 0x00005B00
		public string GetEntrytag(Conversation conversation, DialogueEntry entry, EntrytagFormat entrytagFormat)
		{
			if (conversation == null || entry == null)
			{
				return "invalid_entrytag";
			}
			Regex regex = new Regex("[;:,!'\"\t\r\n\\/\\?\\[\\] ]");
			switch (entrytagFormat)
			{
			case EntrytagFormat.ActorName_ConversationID_EntryID:
			{
				Actor actor = this.GetActor(entry.ActorID);
				if (actor == null)
				{
					return "invalid_entrytag";
				}
				return string.Format("{0}_{1}_{2}", regex.Replace(actor.Name, "_"), conversation.id, entry.id);
			}
			case EntrytagFormat.ConversationTitle_EntryID:
				return string.Format("{0}_{1}", regex.Replace(conversation.Title, "_"), entry.id);
			case EntrytagFormat.ActorNameLineNumber:
			{
				Actor actor = this.GetActor(entry.ActorID);
				if (actor == null)
				{
					return "invalid_entrytag";
				}
				int num = conversation.id * 500 + entry.id;
				return string.Format("{0}{1}", new Regex("[,\"\t\r\n\\/<>?]").Replace(actor.Name, "_"), num);
			}
			case EntrytagFormat.ConversationID_ActorName_EntryID:
			{
				Actor actor = this.GetActor(entry.ActorID);
				if (actor == null)
				{
					return "invalid_entrytag";
				}
				return string.Format("{0}_{1}_{2}", conversation.id, regex.Replace(actor.Name, "_"), entry.id);
			}
			case EntrytagFormat.ActorName_ConversationTitle_EntryDescriptor:
			{
				Actor actor = this.GetActor(entry.ActorID);
				if (actor == null)
				{
					return "invalid_entrytag";
				}
				string text = (string.IsNullOrEmpty(entry.Title) ? (string.IsNullOrEmpty(entry.MenuText) ? entry.id.ToString() : entry.MenuText) : entry.Title);
				return string.Format("{0}_{1}_{2}", regex.Replace(actor.Name, "_"), regex.Replace(conversation.Title, "_"), regex.Replace(text, "_"));
			}
			case EntrytagFormat.VoiceOverFile:
				return (entry != null) ? Field.LookupValue(entry.fields, "VoiceOverFile") : "invalid_entrytag";
			default:
				return "invalid_entrytag";
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007B24 File Offset: 0x00005D24
		public string GetEntrytag(int conversationID, int dialogueEntryID, EntrytagFormat entrytagFormat)
		{
			Conversation conversation = this.GetConversation(conversationID);
			DialogueEntry dialogueEntry = ((conversation == null) ? null : conversation.GetDialogueEntry(dialogueEntryID));
			return this.GetEntrytag(conversation, dialogueEntry, entrytagFormat);
		}

		// Token: 0x04000091 RID: 145
		public const int NumEmphasisSettings = 4;

		// Token: 0x04000092 RID: 146
		public const string InvalidEntrytag = "invalid_entrytag";

		// Token: 0x04000093 RID: 147
		public const string VoiceOverFileFieldName = "VoiceOverFile";

		// Token: 0x04000094 RID: 148
		public string version;

		// Token: 0x04000095 RID: 149
		public string author;

		// Token: 0x04000096 RID: 150
		public string description;

		// Token: 0x04000097 RID: 151
		public string globalUserScript;

		// Token: 0x04000098 RID: 152
		public EmphasisSetting[] emphasisSettings = new EmphasisSetting[4];

		// Token: 0x04000099 RID: 153
		public List<Actor> actors = new List<Actor>();

		// Token: 0x0400009A RID: 154
		public List<Item> items = new List<Item>();

		// Token: 0x0400009B RID: 155
		public List<Location> locations = new List<Location>();

		// Token: 0x0400009C RID: 156
		public List<Variable> variables = new List<Variable>();

		// Token: 0x0400009D RID: 157
		public List<Conversation> conversations = new List<Conversation>();

		// Token: 0x0400009E RID: 158
		public DialogueDatabase.SyncInfo syncInfo = new DialogueDatabase.SyncInfo();

		// Token: 0x0200001D RID: 29
		[Serializable]
		public class SyncInfo
		{
			// Token: 0x040000A0 RID: 160
			public bool syncActors;

			// Token: 0x040000A1 RID: 161
			public bool syncItems;

			// Token: 0x040000A2 RID: 162
			public bool syncLocations;

			// Token: 0x040000A3 RID: 163
			public bool syncVariables;

			// Token: 0x040000A4 RID: 164
			public DialogueDatabase syncActorsDatabase;

			// Token: 0x040000A5 RID: 165
			public DialogueDatabase syncItemsDatabase;

			// Token: 0x040000A6 RID: 166
			public DialogueDatabase syncLocationsDatabase;

			// Token: 0x040000A7 RID: 167
			public DialogueDatabase syncVariablesDatabase;
		}
	}
}
