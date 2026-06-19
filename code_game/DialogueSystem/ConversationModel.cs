using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000219 RID: 537
	public class ConversationModel
	{
		// Token: 0x0600180D RID: 6157 RVA: 0x00020A40 File Offset: 0x0001EC40
		public ConversationModel(DialogueDatabase database, string title, Transform actor, Transform conversant, bool allowLuaExceptions, IsDialogueEntryValidDelegate isDialogueEntryValid, int initialDialogueEntryID = -1, bool stopAtFirstValid = false, bool skipExecution = false)
		{
			this.allowLuaExceptions = allowLuaExceptions;
			this.database = database;
			this.IsDialogueEntryValid = isDialogueEntryValid;
			DisplaySettings displaySettings = DialogueManager.DisplaySettings;
			if (displaySettings != null)
			{
				if (displaySettings.cameraSettings != null)
				{
					this.entrytagFormat = displaySettings.cameraSettings.entrytagFormat;
				}
				if (displaySettings.inputSettings != null)
				{
					this.emTagForOldResponses = displaySettings.inputSettings.emTagForOldResponses;
					this.emTagForInvalidResponses = displaySettings.inputSettings.emTagForInvalidResponses;
					this.includeInvalidEntries = displaySettings.inputSettings.includeInvalidEntries;
				}
			}
			Conversation conversation = database.GetConversation(title);
			if (conversation != null)
			{
				this.SetParticipants(conversation, actor, conversant);
				if (initialDialogueEntryID == -1)
				{
					this.FirstState = this.GetState(conversation.GetFirstDialogueEntry(), true, stopAtFirstValid, skipExecution);
					this.FixFirstStateSequence();
				}
				else
				{
					this.FirstState = this.GetState(conversation.GetDialogueEntry(initialDialogueEntryID), true, stopAtFirstValid, skipExecution);
				}
			}
			else
			{
				this.FirstState = null;
				if (DialogueDebug.LogErrors)
				{
					Debug.LogWarning(string.Format("{0}: Conversation '{1}' not found in database.", new object[] { "Dialogue System", title }));
				}
			}
		}

		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x0600180E RID: 6158 RVA: 0x00020B74 File Offset: 0x0001ED74
		// (set) Token: 0x0600180F RID: 6159 RVA: 0x00020B7C File Offset: 0x0001ED7C
		public ConversationState FirstState { get; private set; }

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06001810 RID: 6160 RVA: 0x00020B88 File Offset: 0x0001ED88
		public CharacterInfo ActorInfo
		{
			get
			{
				return this.actorInfo;
			}
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06001811 RID: 6161 RVA: 0x00020B90 File Offset: 0x0001ED90
		public CharacterInfo ConversantInfo
		{
			get
			{
				return this.conversantInfo;
			}
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x00020B98 File Offset: 0x0001ED98
		public bool HasValidEntry
		{
			get
			{
				return this.FirstState != null && (this.FirstState.HasAnyResponses || !this.IsStartEntryState(this.FirstState));
			}
		}

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06001813 RID: 6163 RVA: 0x00020BD8 File Offset: 0x0001EDD8
		// (set) Token: 0x06001814 RID: 6164 RVA: 0x00020BE0 File Offset: 0x0001EDE0
		public IsDialogueEntryValidDelegate IsDialogueEntryValid { get; set; }

		// Token: 0x06001815 RID: 6165 RVA: 0x00020BEC File Offset: 0x0001EDEC
		public int GetConversationID(ConversationState state)
		{
			return (state == null || state.subtitle == null || state.subtitle.dialogueEntry == null) ? (-1) : state.subtitle.dialogueEntry.conversationID;
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x00020C28 File Offset: 0x0001EE28
		public ConversationOverrideDisplaySettings GetConversationOverrideSettings(ConversationState state)
		{
			Conversation conversation = this.database.GetConversation(this.GetConversationID(state));
			return (conversation == null) ? null : conversation.overrideSettings;
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x00020C5C File Offset: 0x0001EE5C
		private void FixFirstStateSequence()
		{
			if (this.FirstState != null && this.FirstState.subtitle != null && string.IsNullOrEmpty(this.FirstState.subtitle.sequence) && string.IsNullOrEmpty(this.FirstState.subtitle.formattedText.text))
			{
				this.FirstState.subtitle.sequence = "None()";
			}
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x00020CD4 File Offset: 0x0001EED4
		private bool IsStartEntryState(ConversationState state)
		{
			return state != null && state.subtitle != null && state.subtitle.dialogueEntry != null && state.subtitle.dialogueEntry.id == 0;
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x00020D10 File Offset: 0x0001EF10
		public void InformParticipants(string message, bool informDialogueManager = false)
		{
			Transform transform = ((this.actorInfo != null) ? this.actorInfo.transform : null);
			Transform transform2 = ((this.conversantInfo != null) ? this.conversantInfo.transform : null);
			if (transform != null)
			{
				Transform transform3 = ((!(transform2 != null)) ? transform : transform2);
				if (transform3 != null)
				{
					transform.BroadcastMessage(message, transform3, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (transform2 != null && transform2 != transform)
			{
				Transform transform3 = ((!(transform != null)) ? transform2 : transform);
				if (transform3 != null)
				{
					transform2.BroadcastMessage(message, transform3, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (informDialogueManager)
			{
				Transform transform4 = DialogueManager.Instance.transform;
				if (transform4 != transform && transform4 != transform2)
				{
					Transform transform3 = ((!(transform != null)) ? transform2 : transform);
					if (transform3 == null)
					{
						transform3 = DialogueManager.Instance.transform;
					}
					DialogueManager.Instance.BroadcastMessage(message, transform3, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x00020E30 File Offset: 0x0001F030
		public ConversationState GetState(DialogueEntry entry, bool includeLinks, bool stopAtFirstValid = false, bool skipExecution = false)
		{
			if (entry != null)
			{
				DialogueManager.Instance.SendMessage("OnPrepareConversationLine", entry, SendMessageOptions.DontRequireReceiver);
				DialogueLua.MarkDialogueEntryDisplayed(entry);
				this.SetDialogTable(entry.conversationID);
				if (!skipExecution)
				{
					Lua.Run(entry.userScript, DialogueDebug.LogInfo, this.allowLuaExceptions);
					entry.onExecute.Invoke();
				}
				CharacterInfo characterInfo = this.GetCharacterInfo(entry.ActorID);
				CharacterInfo characterInfo2 = this.GetCharacterInfo(entry.ConversantID);
				FormattedText formattedText = FormattedText.Parse(entry.SubtitleText, this.database.emphasisSettings);
				this.CheckSequenceField(entry);
				string entrytag = this.database.GetEntrytag(entry.conversationID, entry.id, this.entrytagFormat);
				Subtitle subtitle = new Subtitle(characterInfo, characterInfo2, formattedText, entry.Sequence, entry.ResponseMenuSequence, entry, entrytag);
				List<Response> list = new List<Response>();
				List<Response> list2 = new List<Response>();
				if (includeLinks)
				{
					this.EvaluateLinks(entry, list, list2, new List<DialogueEntry>(), stopAtFirstValid);
				}
				return new ConversationState(subtitle, list.ToArray(), list2.ToArray(), entry.isGroup);
			}
			return null;
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x00020F40 File Offset: 0x0001F140
		public ConversationState GetState(DialogueEntry entry)
		{
			return this.GetState(entry, true, false, false);
		}

		// Token: 0x0600181C RID: 6172 RVA: 0x00020F4C File Offset: 0x0001F14C
		public void UpdateResponses(ConversationState state)
		{
			List<Response> list = new List<Response>();
			List<Response> list2 = new List<Response>();
			this.EvaluateLinks(state.subtitle.dialogueEntry, list, list2, new List<DialogueEntry>(), false);
			state.npcResponses = list.ToArray();
			state.pcResponses = list2.ToArray();
		}

		// Token: 0x0600181D RID: 6173 RVA: 0x00020F98 File Offset: 0x0001F198
		private void SetDialogTable(int newConversationID)
		{
			if (this.currentConversationID != newConversationID)
			{
				this.currentConversationID = newConversationID;
				Lua.Run(string.Format("Dialog = Conversation[{0}].Dialog", new object[] { newConversationID }));
			}
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x00020FD8 File Offset: 0x0001F1D8
		private void CheckSequenceField(DialogueEntry entry)
		{
			if (string.IsNullOrEmpty(entry.Sequence) && !string.IsNullOrEmpty(entry.VideoFile) && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Dialogue entry '{1}' Video File field is assigned but Sequence is blank. Cutscenes now use Sequence field.", new object[] { "Dialogue System", entry.DialogueText }));
			}
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x00021038 File Offset: 0x0001F238
		private void EvaluateLinks(DialogueEntry entry, List<Response> npcResponses, List<Response> pcResponses, List<DialogueEntry> visited, bool stopAtFirstValid = false)
		{
			if (entry != null && !visited.Contains(entry))
			{
				visited.Add(entry);
				for (int i = 4; i >= 0; i--)
				{
					this.EvaluateLinksAtPriority((ConditionPriority)i, entry, npcResponses, pcResponses, visited, stopAtFirstValid);
					if (npcResponses.Count > 0 || pcResponses.Count > 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x0002109C File Offset: 0x0001F29C
		private void EvaluateLinksAtPriority(ConditionPriority priority, DialogueEntry entry, List<Response> npcResponses, List<Response> pcResponses, List<DialogueEntry> visited, bool stopAtFirstValid = false)
		{
			if (entry != null)
			{
				for (int i = 0; i < entry.outgoingLinks.Count; i++)
				{
					Link link = entry.outgoingLinks[i];
					DialogueEntry dialogueEntry = this.database.GetDialogueEntry(link);
					if (dialogueEntry != null && (dialogueEntry.conditionPriority == priority || link.priority == priority))
					{
						CharacterType characterType = this.database.GetCharacterType(dialogueEntry.ActorID);
						bool flag = Lua.IsTrue(dialogueEntry.conditionsString, DialogueDebug.LogInfo, this.allowLuaExceptions) && (this.IsDialogueEntryValid == null || this.IsDialogueEntryValid(dialogueEntry));
						if (flag || (this.includeInvalidEntries && characterType == CharacterType.PC))
						{
							if (dialogueEntry.isGroup)
							{
								if (DialogueDebug.LogInfo)
								{
									Debug.Log(string.Format("{0}: Add Group ({1}): ID={2}:{3} '{4}' ({5})", new object[]
									{
										"Dialogue System",
										this.GetActorName(this.database.GetActor(dialogueEntry.ActorID)),
										link.destinationConversationID,
										link.destinationDialogueID,
										dialogueEntry.Title,
										flag
									}));
								}
								Lua.Run(dialogueEntry.userScript, DialogueDebug.LogInfo, this.allowLuaExceptions);
								for (int j = 4; j >= 0; j--)
								{
									int num = npcResponses.Count + pcResponses.Count;
									this.EvaluateLinksAtPriority((ConditionPriority)j, dialogueEntry, npcResponses, pcResponses, visited, false);
									if (npcResponses.Count + pcResponses.Count > num)
									{
										break;
									}
								}
							}
							else
							{
								if (DialogueDebug.LogInfo)
								{
									Debug.Log(string.Format("{0}: Add Link ({1}): ID={2}:{3} '{4}' ({5})", new object[]
									{
										"Dialogue System",
										this.GetActorName(this.database.GetActor(dialogueEntry.ActorID)),
										link.destinationConversationID,
										link.destinationDialogueID,
										this.GetLinkText(characterType, dialogueEntry),
										flag
									}));
								}
								if (characterType == CharacterType.NPC)
								{
									npcResponses.Add(new Response(FormattedText.Parse(dialogueEntry.SubtitleText, this.database.emphasisSettings), dialogueEntry, flag));
								}
								else
								{
									string text = dialogueEntry.ResponseButtonText;
									if (this.emTagForOldResponses != EmTag.None)
									{
										string asString = Lua.Run(string.Format("return Conversation[{0}].Dialog[{1}].SimStatus", new object[] { dialogueEntry.conversationID, dialogueEntry.id })).AsString;
										bool flag2 = string.Equals(asString, "WasDisplayed");
										if (flag2)
										{
											text = string.Format("[em{0}]{1}[/em{0}]", (int)this.emTagForOldResponses, text);
										}
									}
									if (this.emTagForInvalidResponses != EmTag.None && !flag)
									{
										text = string.Format("[em{0}]{1}[/em{0}]", (int)this.emTagForInvalidResponses, text);
									}
									pcResponses.Add(new Response(FormattedText.Parse(text, this.database.emphasisSettings), dialogueEntry, flag));
									DialogueLua.MarkDialogueEntryOffered(dialogueEntry);
								}
							}
							if (stopAtFirstValid)
							{
								return;
							}
						}
						else if (LinkTools.IsPassthroughOnFalse(dialogueEntry))
						{
							if (DialogueDebug.LogInfo)
							{
								Debug.Log(string.Format("{0}: Passthrough on False Link ({1}): ID={2}:{3} '{4}' Condition='{5}'", new object[]
								{
									"Dialogue System",
									this.GetActorName(this.database.GetActor(dialogueEntry.ActorID)),
									link.destinationConversationID,
									link.destinationDialogueID,
									this.GetLinkText(characterType, dialogueEntry),
									dialogueEntry.conditionsString
								}));
							}
							List<Response> list = new List<Response>();
							List<Response> list2 = new List<Response>();
							this.EvaluateLinks(dialogueEntry, list, list2, visited, false);
							npcResponses.AddRange(list);
							pcResponses.AddRange(list2);
						}
						else if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: Block on False Link ({1}): ID={2}:{3} '{4}' Condition='{5}'", new object[]
							{
								"Dialogue System",
								this.GetActorName(this.database.GetActor(dialogueEntry.ActorID)),
								link.destinationConversationID,
								link.destinationDialogueID,
								this.GetLinkText(characterType, dialogueEntry),
								dialogueEntry.conditionsString
							}));
						}
					}
				}
			}
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x000214EC File Offset: 0x0001F6EC
		private string GetActorName(Actor actor)
		{
			return (actor == null) ? "null" : actor.Name;
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x00021504 File Offset: 0x0001F704
		private string GetLinkText(CharacterType characterType, DialogueEntry entry)
		{
			return (characterType != CharacterType.NPC) ? entry.ResponseButtonText : entry.SubtitleText;
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x00021520 File Offset: 0x0001F720
		private void SetParticipants(Conversation conversation, Transform actor, Transform conversant)
		{
			this.actorInfo = this.GetCharacterInfo(conversation.ActorID, actor);
			this.conversantInfo = this.GetCharacterInfo(conversation.ConversantID, conversant);
			DialogueLua.SetParticipants(this.actorInfo.Name, this.conversantInfo.Name, this.actorInfo.nameInDatabase, this.conversantInfo.nameInDatabase);
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x00021584 File Offset: 0x0001F784
		public CharacterInfo GetCharacterInfo(int id, Transform character)
		{
			if (!this.characterInfoCache.ContainsKey(id))
			{
				string actorName = OverrideActorName.GetActorName(character);
				Actor actor = (string.IsNullOrEmpty(actorName) ? null : this.database.GetActor(actorName));
				if (actor == null)
				{
					actor = this.database.GetActor(id);
				}
				string text = ((actor == null) ? string.Empty : actor.Name);
				int num = ((actor == null) ? id : actor.id);
				CharacterInfo characterInfo = new CharacterInfo(num, text, character, this.database.GetCharacterType(id), this.GetPortrait(character, actor));
				this.characterInfoCache.Add(id, characterInfo);
			}
			return this.characterInfoCache[id];
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x0002163C File Offset: 0x0001F83C
		public CharacterInfo GetCharacterInfo(int id)
		{
			return this.GetCharacterInfo(id, this.GetCharacterTransform(id));
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x0002164C File Offset: 0x0001F84C
		private Transform GetCharacterTransform(int id)
		{
			if (id == this.actorInfo.id)
			{
				return this.actorInfo.transform;
			}
			if (id == this.conversantInfo.id)
			{
				return this.conversantInfo.transform;
			}
			return null;
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x0002168C File Offset: 0x0001F88C
		private Texture2D GetPortrait(Transform character, Actor actor)
		{
			Texture2D texture2D = null;
			if (character != null)
			{
				OverrideActorName overrideActorName = OverrideActorName.GetOverrideActorName(character);
				if (overrideActorName != null)
				{
					texture2D = this.GetPortraitByActorName(overrideActorName.GetOverrideName());
				}
				if (texture2D == null)
				{
					texture2D = this.GetPortraitByActorName(character.name);
				}
			}
			if (texture2D == null && actor != null)
			{
				texture2D = this.GetPortraitByActorName(actor.Name);
				if (texture2D == null)
				{
					texture2D = actor.portrait;
				}
			}
			return texture2D;
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x00021714 File Offset: 0x0001F914
		private Texture2D GetPortraitByActorName(string actorName)
		{
			DialogueDebug.DebugLevel level = DialogueDebug.Level;
			DialogueDebug.Level = DialogueDebug.DebugLevel.Warning;
			string asString = DialogueLua.GetActorField(actorName, "Current Portrait").AsString;
			DialogueDebug.Level = level;
			if (string.IsNullOrEmpty(asString))
			{
				return null;
			}
			if (!asString.StartsWith("pic="))
			{
				return DialogueManager.LoadAsset(asString) as Texture2D;
			}
			Actor actor = this.database.GetActor(actorName);
			if (actor == null)
			{
				return null;
			}
			return actor.GetPortraitTexture(Tools.StringToInt(asString.Substring("pic=".Length)));
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x000217A0 File Offset: 0x0001F9A0
		public void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			foreach (CharacterInfo characterInfo in this.characterInfoCache.Values)
			{
				if (string.Equals(characterInfo.Name, actorName) || string.Equals(characterInfo.nameInDatabase, actorName))
				{
					characterInfo.portrait = portraitTexture;
				}
			}
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x00021830 File Offset: 0x0001FA30
		public string GetPCName()
		{
			if (this.database.IsPlayerID(this.actorInfo.id))
			{
				return this.actorInfo.Name;
			}
			if (this.database.IsPlayerID(this.conversantInfo.id))
			{
				return this.conversantInfo.Name;
			}
			return null;
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x0002188C File Offset: 0x0001FA8C
		public Texture2D GetPCTexture()
		{
			if (this.database.IsPlayerID(this.actorInfo.id))
			{
				return this.actorInfo.portrait;
			}
			if (this.database.IsPlayerID(this.conversantInfo.id))
			{
				return this.conversantInfo.portrait;
			}
			return null;
		}

		// Token: 0x04000D9A RID: 3482
		private DialogueDatabase database;

		// Token: 0x04000D9B RID: 3483
		private CharacterInfo actorInfo;

		// Token: 0x04000D9C RID: 3484
		private CharacterInfo conversantInfo;

		// Token: 0x04000D9D RID: 3485
		private int currentConversationID = -1;

		// Token: 0x04000D9E RID: 3486
		private bool allowLuaExceptions;

		// Token: 0x04000D9F RID: 3487
		private Dictionary<int, CharacterInfo> characterInfoCache = new Dictionary<int, CharacterInfo>();

		// Token: 0x04000DA0 RID: 3488
		private EntrytagFormat entrytagFormat;

		// Token: 0x04000DA1 RID: 3489
		private EmTag emTagForOldResponses;

		// Token: 0x04000DA2 RID: 3490
		private EmTag emTagForInvalidResponses;

		// Token: 0x04000DA3 RID: 3491
		private bool includeInvalidEntries;
	}
}
