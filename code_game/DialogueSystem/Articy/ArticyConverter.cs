using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000028 RID: 40
	public class ArticyConverter
	{
		// Token: 0x06000209 RID: 521 RVA: 0x000091DC File Offset: 0x000073DC
		// Note: this type is marked as 'beforefieldinit'.
		static ArticyConverter()
		{
			ArticyConverter.onProgressCallback = delegate
			{
			};
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600020A RID: 522 RVA: 0x00009218 File Offset: 0x00007418
		// (remove) Token: 0x0600020B RID: 523 RVA: 0x00009230 File Offset: 0x00007430
		public static event ArticyConverter.ProgressCallbackDelegate onProgressCallback;

		// Token: 0x0600020C RID: 524 RVA: 0x00009248 File Offset: 0x00007448
		public static DialogueDatabase ConvertXmlDataToDatabase(string xmlData, ConverterPrefs prefs = null, Template template = null)
		{
			if (prefs == null)
			{
				prefs = new ConverterPrefs();
			}
			if (template == null)
			{
				template = new Template();
			}
			DialogueDatabase dialogueDatabase = ScriptableObject.CreateInstance<DialogueDatabase>();
			ArticyData articyData = ArticySchemaTools.LoadArticyDataFromXmlData(xmlData, prefs);
			if (articyData == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Can't convert articy:draft project; unable to import articy:draft data.");
				}
				return null;
			}
			ArticyConverter.ConvertArticyDataToDatabase(articyData, prefs, template, dialogueDatabase);
			return dialogueDatabase;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000092A4 File Offset: 0x000074A4
		public static void ConvertArticyDataToDatabase(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			ArticyConverter articyConverter = new ArticyConverter();
			articyConverter.Convert(articyData, prefs, template, database);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x000092C4 File Offset: 0x000074C4
		private void ResetStacks()
		{
			this.flowFragmentNameStack.Clear();
			this.conversationStack.Clear();
			this.conversationLastEntryID.Clear();
			this.entriesByPinID.Clear();
			this.jumpsToProcess.Clear();
			this.unusedOutputEntries.Clear();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00009314 File Offset: 0x00007514
		private void PushFlowFragment(ArticyData.FlowFragment flowFragment)
		{
			if (flowFragment == null)
			{
				return;
			}
			this.flowFragmentNameStack.Add(flowFragment.displayName.DefaultText);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00009334 File Offset: 0x00007534
		private void PopFlowFragment()
		{
			if (this.flowFragmentNameStack.Count < 1)
			{
				return;
			}
			this.flowFragmentNameStack.RemoveAt(this.flowFragmentNameStack.Count - 1);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000936C File Offset: 0x0000756C
		private void PushConversation(Conversation conversation)
		{
			if (conversation == null)
			{
				return;
			}
			this.conversationStack.Add(conversation);
			string text = conversation.LookupValue("Articy Id");
			ArticyData.Dialogue dialogue = ((!this.articyData.dialogues.ContainsKey(text)) ? null : this.articyData.dialogues[text]);
			if (dialogue != null && dialogue.isDocument)
			{
				this.documentConversation = conversation;
				this.lastDocumentEntry = conversation.GetFirstDialogueEntry();
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000093EC File Offset: 0x000075EC
		private void PopConversation()
		{
			if (this.conversationStack.Count < 1)
			{
				return;
			}
			this.conversationStack.RemoveAt(this.conversationStack.Count - 1);
			this.documentConversation = null;
			this.lastDocumentEntry = null;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00009434 File Offset: 0x00007634
		private Conversation GetConversationStackTop()
		{
			return (this.conversationStack.Count <= 0) ? null : this.conversationStack[this.conversationStack.Count - 1];
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00009468 File Offset: 0x00007668
		private int GetNextConversationEntryID(Conversation conversation)
		{
			if (conversation == null)
			{
				return 0;
			}
			if (!this.conversationLastEntryID.ContainsKey(conversation))
			{
				this.conversationLastEntryID.Add(conversation, 0);
				return 0;
			}
			Dictionary<Conversation, int> dictionary2;
			Dictionary<Conversation, int> dictionary = (dictionary2 = this.conversationLastEntryID);
			int num = dictionary2[conversation];
			dictionary[conversation] = num + 1;
			return this.conversationLastEntryID[conversation];
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000094C4 File Offset: 0x000076C4
		private void ResetArticyIdIndex()
		{
			this.entriesByArticyId.Clear();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000094D4 File Offset: 0x000076D4
		private void IndexDialogueEntryByArticyId(DialogueEntry entry, string articyId)
		{
			if (this.entriesByArticyId.ContainsKey(articyId))
			{
				if (!this.entriesByArticyId[articyId].Contains(entry))
				{
					this.entriesByArticyId[articyId].Add(entry);
				}
			}
			else
			{
				this.entriesByArticyId.Add(articyId, new List<DialogueEntry>());
				this.entriesByArticyId[articyId].Add(entry);
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00009544 File Offset: 0x00007744
		public void Convert(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			if (articyData != null)
			{
				ArticyConverter.onProgressCallback("Converting non-dialogue elements", 0.01f);
				this.Setup(articyData, prefs, template, database);
				this.ConvertProjectAttributes();
				this.ConvertEntities();
				this.ConvertLocations();
				this.ConvertFlowFragmentsToQuests();
				this.ConvertVariables();
				this.ConvertDialogues();
				this.ResetArticyIdIndex();
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000095A0 File Offset: 0x000077A0
		private void Setup(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			this.articyData = articyData;
			this.prefs = prefs;
			this.database = database;
			database.actors = new List<Actor>();
			database.items = new List<Item>();
			database.locations = new List<Location>();
			database.variables = new List<Variable>();
			database.conversations = new List<Conversation>();
			this.conversationID = 0;
			this.actorID = 0;
			this.itemID = 0;
			this.locationID = 0;
			this.documentConversation = null;
			this.lastDocumentEntry = null;
			ArticyConverter.fullVariableNames.Clear();
			this.ResetArticyIdIndex();
			this.template = template;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00009640 File Offset: 0x00007840
		private void ConvertProjectAttributes()
		{
			this.database.version = this.articyData.ProjectVersion;
			this.database.author = this.articyData.ProjectAuthor;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000967C File Offset: 0x0000787C
		private void ConvertEntities()
		{
			foreach (ArticyData.Entity entity in this.articyData.entities.Values)
			{
				ConversionSetting conversionSetting = this.prefs.ConversionSettings.GetConversionSetting(entity.id);
				if (conversionSetting.Include)
				{
					EntityCategory entityCategory = conversionSetting.Category;
					if (ArticyConverter.HasField(entity.features, "IsNPC", false))
					{
						entityCategory = EntityCategory.NPC;
					}
					if (ArticyConverter.HasField(entity.features, "IsPlayer", true))
					{
						entityCategory = EntityCategory.Player;
					}
					if (ArticyConverter.HasField(entity.features, "IsItem", true))
					{
						entityCategory = EntityCategory.Item;
					}
					if (ArticyConverter.HasField(entity.features, "IsQuest", true))
					{
						entityCategory = EntityCategory.Quest;
					}
					switch (entityCategory)
					{
					case EntityCategory.NPC:
					case EntityCategory.Player:
					{
						this.actorID++;
						bool flag = conversionSetting.Category == EntityCategory.Player;
						Actor actor = this.template.CreateActor(this.actorID, entity.displayName.DefaultText, flag);
						Field.SetValue(actor.fields, "Articy Id", entity.id, FieldType.Text);
						Field.SetValue(actor.fields, "Technical Name", entity.technicalName, FieldType.Text);
						Field.SetValue(actor.fields, "Description", entity.text.DefaultText, FieldType.Text);
						if (!string.IsNullOrEmpty(entity.previewImage))
						{
							Field.SetValue(actor.fields, "Pictures", string.Format("[{0}]", entity.previewImage), FieldType.Text);
						}
						this.SetFeatureFields(actor.fields, entity.features);
						this.ConvertLocalizableText(actor.fields, "Name", entity.displayName);
						this.database.actors.Add(actor);
						break;
					}
					case EntityCategory.Item:
					case EntityCategory.Quest:
					{
						this.itemID++;
						Item item = this.template.CreateItem(this.itemID, entity.displayName.DefaultText);
						Field.SetValue(item.fields, "Articy Id", entity.id, FieldType.Text);
						Field.SetValue(item.fields, "Technical Name", entity.technicalName, FieldType.Text);
						Field.SetValue(item.fields, "Description", entity.text.DefaultText, FieldType.Text);
						Field.SetValue(item.fields, "Is Item", (entityCategory != EntityCategory.Item) ? "False" : "True", FieldType.Boolean);
						this.SetFeatureFields(item.fields, entity.features);
						this.ConvertLocalizableText(item.fields, "Name", entity.displayName);
						this.database.items.Add(item);
						break;
					}
					default:
						Debug.LogError(string.Concat(new object[] { "Dialogue System: Internal error converting entity type '", conversionSetting.Category, "' (Articy ID: ", entity.id, ")." }));
						break;
					}
				}
			}
			foreach (Actor actor2 in this.database.actors)
			{
				this.FindPortraitTextureInResources(actor2);
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00009A0C File Offset: 0x00007C0C
		private void ConvertLocations()
		{
			foreach (ArticyData.Location location in this.articyData.locations.Values)
			{
				if (this.prefs.ConversionSettings.GetConversionSetting(location.id).Include)
				{
					this.locationID++;
					Location location2 = this.template.CreateLocation(this.locationID, location.displayName.DefaultText);
					Field.SetValue(location2.fields, "Articy Id", location.id, FieldType.Text);
					Field.SetValue(location2.fields, "Technical Name", location.technicalName, FieldType.Text);
					Field.SetValue(location2.fields, "Description", location.text.DefaultText, FieldType.Text);
					this.SetFeatureFields(location2.fields, location.features);
					this.ConvertLocalizableText(location2.fields, "Name", location.displayName);
					this.database.locations.Add(location2);
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00009B44 File Offset: 0x00007D44
		private void ConvertFlowFragmentsToQuests()
		{
			if (this.prefs.FlowFragmentMode != ConverterPrefs.FlowFragmentModes.Quests)
			{
				return;
			}
			foreach (ArticyData.FlowFragment flowFragment in this.articyData.flowFragments.Values)
			{
				if (this.prefs.ConversionSettings.GetConversionSetting(flowFragment.id).Include)
				{
					this.itemID++;
					Item item = this.template.CreateItem(this.itemID, flowFragment.displayName.DefaultText);
					Field.SetValue(item.fields, "Articy Id", flowFragment.id, FieldType.Text);
					Field.SetValue(item.fields, "Technical Name", flowFragment.technicalName, FieldType.Text);
					Field.SetValue(item.fields, "Description", flowFragment.text.DefaultText, FieldType.Text);
					Field.SetValue(item.fields, "Success Description", string.Empty, FieldType.Text);
					Field.SetValue(item.fields, "Failure Description", string.Empty, FieldType.Text);
					Field.SetValue(item.fields, "State", "unassigned", FieldType.Text);
					Field.SetValue(item.fields, "Is Item", "False", FieldType.Boolean);
					this.SetFeatureFields(item.fields, flowFragment.features);
					this.ConvertLocalizableText(item.fields, "Name", flowFragment.displayName);
					this.database.items.Add(item);
				}
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00009CE8 File Offset: 0x00007EE8
		private void SetFeatureFields(List<Field> fields, ArticyData.Features features)
		{
			foreach (ArticyData.Feature feature in features.features)
			{
				foreach (ArticyData.Property property in feature.properties)
				{
					foreach (Field field in property.fields)
					{
						if (!string.IsNullOrEmpty(field.title))
						{
							string text = this.ConvertSpecialTechnicalNames(field.title);
							Field field2 = Field.Lookup(fields, text);
							if (field2 != null)
							{
								field2.value = field.value;
							}
							else
							{
								fields.Add(new Field(text, field.value, field.type));
							}
						}
					}
				}
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00009E48 File Offset: 0x00008048
		private string ConvertSpecialTechnicalNames(string technicalName)
		{
			if (string.Equals(technicalName, "Success_Description") || string.Equals(technicalName, "Failure_Description") || string.Equals(technicalName, "Entry_Count") || Regex.Match(technicalName, "^Entry_[0-9]").Success)
			{
				return technicalName.Replace("_", " ");
			}
			return technicalName;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00009EAC File Offset: 0x000080AC
		public static bool HasField(ArticyData.Features features, string fieldName, bool mustBeTrue)
		{
			foreach (ArticyData.Feature feature in features.features)
			{
				foreach (ArticyData.Property property in feature.properties)
				{
					foreach (Field field in property.fields)
					{
						if (string.Equals(field.title, fieldName))
						{
							return !mustBeTrue || string.Equals(field.value, "True", StringComparison.OrdinalIgnoreCase);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00009FE8 File Offset: 0x000081E8
		private void ConvertVariables()
		{
			int num = 0;
			foreach (ArticyData.VariableSet variableSet in this.articyData.variableSets.Values)
			{
				foreach (ArticyData.Variable variable in variableSet.variables)
				{
					string text = ArticyData.FullVariableName(variableSet, variable);
					ArticyConverter.fullVariableNames.Add(text);
					if (this.prefs.ConversionSettings.GetConversionSetting(text).Include)
					{
						num++;
						Variable variable2 = this.template.CreateVariable(num, text, variable.defaultValue);
						variable2.Type = ((variable.dataType != ArticyData.VariableDataType.Boolean) ? ((variable.dataType != ArticyData.VariableDataType.Integer) ? FieldType.Text : FieldType.Number) : FieldType.Boolean);
						if (!string.IsNullOrEmpty(variable.description))
						{
							Field field = Field.Lookup(variable2.fields, "Description");
							if (field != null)
							{
								field.value = variable.description;
							}
							else
							{
								variable2.fields.Add(new Field("Description", variable.description, FieldType.Text));
							}
						}
						this.database.variables.Add(variable2);
					}
				}
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000A184 File Offset: 0x00008384
		private void ConvertDialogues()
		{
			this.ResetStacks();
			ArticyConverter.onProgressCallback("Converting dialogues", 0.2f);
			this.ConvertDialoguesToConversations();
			ArticyConverter.onProgressCallback("Processing hierarchy", 0.3f);
			this.ProcessHierarchy();
			ArticyConverter.onProgressCallback("Sorting links by position", 0.7f);
			this.SortAllLinksByPosition();
			this.SplitPipesIntoEntries();
			ArticyConverter.onProgressCallback("Converting VoiceOver properties", 0.9f);
			this.ConvertVoiceOverProperties();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000A208 File Offset: 0x00008408
		private bool IncludeDialogue(string dialogueId)
		{
			ConversionSetting conversionSetting = ((this.prefs != null) ? this.prefs.ConversionSettings.GetConversionSetting(dialogueId) : null);
			return conversionSetting == null || conversionSetting.Include;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000A248 File Offset: 0x00008448
		private void ConvertDialoguesToConversations()
		{
			foreach (ArticyData.Dialogue dialogue in this.articyData.dialogues.Values)
			{
				if (this.IncludeDialogue(dialogue.id))
				{
					this.CreateNewConversation(dialogue);
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000A2D0 File Offset: 0x000084D0
		private Conversation CreateNewConversation(ArticyData.Dialogue articyDialogue)
		{
			if (articyDialogue == null)
			{
				return null;
			}
			this.conversationID++;
			string text = string.Empty;
			text += articyDialogue.displayName.DefaultText;
			Conversation conversation = this.template.CreateConversation(this.conversationID, text);
			Field.SetValue(conversation.fields, "Articy Id", articyDialogue.id, FieldType.Text);
			Field.SetValue(conversation.fields, "Description", articyDialogue.text.DefaultText, FieldType.Text);
			this.SetFeatureFields(conversation.fields, articyDialogue.features);
			conversation.ActorID = this.FindActorIdFromArticyDialogue(articyDialogue, 0);
			conversation.ConversantID = this.FindActorIdFromArticyDialogue(articyDialogue, 1);
			this.database.conversations.Add(conversation);
			DialogueEntry dialogueEntry = this.template.CreateDialogueEntry(this.GetNextConversationEntryID(conversation), this.conversationID, "START");
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyDialogue.id, FieldType.Text);
			this.IndexDialogueEntryByArticyId(dialogueEntry, articyDialogue.id);
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, articyDialogue.pins);
			dialogueEntry.outgoingLinks = new List<Link>();
			Field.SetValue(dialogueEntry.fields, "Sequence", "None()", FieldType.Text);
			conversation.dialogueEntries.Add(dialogueEntry);
			for (int i = 0; i < articyDialogue.pins.Count; i++)
			{
				ArticyData.Pin pin = articyDialogue.pins[i];
				if (pin.semantic != ArticyData.SemanticType.Output || this.prefs.RecursionMode != ConverterPrefs.RecursionModes.Off)
				{
					int nextConversationEntryID = this.GetNextConversationEntryID(conversation);
					string text2 = ((pin.semantic != ArticyData.SemanticType.Input) ? "output" : "input");
					DialogueEntry dialogueEntry2 = this.template.CreateDialogueEntry(nextConversationEntryID, this.conversationID, text2);
					dialogueEntry2.isGroup = true;
					Field.SetValue(dialogueEntry2.fields, "Sequence", "None()", FieldType.Text);
					Field.SetValue(dialogueEntry2.fields, "Articy Id", pin.id, FieldType.Text);
					if (pin.semantic == ArticyData.SemanticType.Input)
					{
						Link link = new Link();
						link.originConversationID = this.conversationID;
						link.originDialogueID = dialogueEntry.id;
						link.destinationConversationID = this.conversationID;
						link.destinationDialogueID = dialogueEntry2.id;
						dialogueEntry.outgoingLinks.Add(link);
					}
					else
					{
						this.unusedOutputEntries.Add(dialogueEntry2);
					}
					this.IndexDialogueEntryByArticyId(dialogueEntry2, pin.id);
					this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, articyDialogue.pins);
					dialogueEntry2.outgoingLinks = new List<Link>();
					conversation.dialogueEntries.Add(dialogueEntry2);
					this.RecordPin(pin, dialogueEntry2);
				}
			}
			return conversation;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000A578 File Offset: 0x00008778
		private Conversation FindOrCreateFlowFragmentConversation(ArticyData.FlowFragment articyFlowFragment)
		{
			if (articyFlowFragment == null)
			{
				return null;
			}
			this.conversationID++;
			string text = articyFlowFragment.displayName.DefaultText + " Conversation";
			Conversation conversation = this.template.CreateConversation(this.conversationID, text);
			Field.SetValue(conversation.fields, "Articy Id", articyFlowFragment.id, FieldType.Text);
			Field.SetValue(conversation.fields, "Description", articyFlowFragment.text.DefaultText, FieldType.Text);
			this.SetFeatureFields(conversation.fields, articyFlowFragment.features);
			Conversation conversationStackTop = this.GetConversationStackTop();
			conversation.ActorID = ((conversationStackTop == null) ? 1 : conversationStackTop.ActorID);
			conversation.ConversantID = ((conversationStackTop == null) ? 2 : conversationStackTop.ConversantID);
			this.database.conversations.Add(conversation);
			DialogueEntry dialogueEntry = this.template.CreateDialogueEntry(this.GetNextConversationEntryID(conversation), this.conversationID, "START");
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyFlowFragment.id, FieldType.Text);
			this.IndexDialogueEntryByArticyId(dialogueEntry, articyFlowFragment.id);
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, articyFlowFragment.pins);
			dialogueEntry.outgoingLinks = new List<Link>();
			Field.SetValue(dialogueEntry.fields, "Sequence", "None()", FieldType.Text);
			conversation.dialogueEntries.Add(dialogueEntry);
			for (int i = 0; i < articyFlowFragment.pins.Count; i++)
			{
				ArticyData.Pin pin = articyFlowFragment.pins[i];
				if (pin.semantic != ArticyData.SemanticType.Output || this.prefs.RecursionMode != ConverterPrefs.RecursionModes.Off)
				{
					int nextConversationEntryID = this.GetNextConversationEntryID(conversation);
					string text2 = ((pin.semantic != ArticyData.SemanticType.Input) ? "output" : "input");
					DialogueEntry dialogueEntry2 = this.template.CreateDialogueEntry(nextConversationEntryID, this.conversationID, text2);
					dialogueEntry2.isGroup = true;
					Field.SetValue(dialogueEntry2.fields, "Sequence", "None()", FieldType.Text);
					Field.SetValue(dialogueEntry2.fields, "Articy Id", pin.id, FieldType.Text);
					if (pin.semantic == ArticyData.SemanticType.Input)
					{
						Link link = new Link();
						link.originConversationID = this.conversationID;
						link.originDialogueID = dialogueEntry.id;
						link.destinationConversationID = this.conversationID;
						link.destinationDialogueID = dialogueEntry2.id;
						dialogueEntry.outgoingLinks.Add(link);
					}
					else
					{
						this.unusedOutputEntries.Add(dialogueEntry2);
					}
					this.IndexDialogueEntryByArticyId(dialogueEntry2, pin.id);
					this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, articyFlowFragment.pins);
					dialogueEntry2.outgoingLinks = new List<Link>();
					conversation.dialogueEntries.Add(dialogueEntry2);
					this.RecordPin(pin, dialogueEntry2);
				}
			}
			return conversation;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000A83C File Offset: 0x00008A3C
		private void ProcessHierarchy()
		{
			ArticyConverter.onProgressCallback("Processing dialogue nodes", 0.4f);
			this.BuildDialogueEntriesFromNode(this.articyData.hierarchy.node, 0);
			ArticyConverter.onProgressCallback("Connecting dialogue nodes", 0.5f);
			this.ProcessConnections();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000A890 File Offset: 0x00008A90
		private void BuildDialogueEntriesFromNode(ArticyData.Node node, int recursionDepth)
		{
			if (recursionDepth > 1000)
			{
				Debug.LogError("Dialogue System: Internal error - Exceeded max recursion depth " + 1000 + " in ArticyConverter.BuildDialogueEntriesFromNode.");
				return;
			}
			if (node.type == ArticyData.NodeType.Dialogue && !this.IncludeDialogue(node.id))
			{
				return;
			}
			switch (node.type)
			{
			case ArticyData.NodeType.FlowFragment:
			{
				ArticyData.FlowFragment flowFragment = this.LookupArticyFlowFragment(node.id);
				this.PushFlowFragment(flowFragment);
				if (this.GetConversationStackTop() != null)
				{
					if (this.prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups && this.articyData.flowFragments.ContainsKey(node.id))
					{
						Conversation conversation = this.FindOrCreateFlowFragmentConversation(this.articyData.flowFragments[node.id]);
						if (conversation != null)
						{
							this.PushConversation(conversation);
						}
					}
					else
					{
						this.AddFlowFragmentAsDialogueEntry(this.GetConversationStackTop(), flowFragment);
					}
				}
				break;
			}
			case ArticyData.NodeType.Dialogue:
			{
				Conversation conversation2 = this.database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), node.id));
				this.PushConversation(conversation2);
				this.PrependFlowStackToConversationTitle(conversation2);
				break;
			}
			case ArticyData.NodeType.DialogueFragment:
				this.BuildDialogueEntryFromDialogueFragment(this.GetConversationStackTop(), this.LookupArticyDialogueFragment(node.id));
				break;
			case ArticyData.NodeType.Hub:
				this.BuildDialogueEntryFromHub(this.GetConversationStackTop(), this.LookupArticyHub(node.id));
				break;
			case ArticyData.NodeType.Jump:
				this.BuildDialogueEntryFromJump(this.GetConversationStackTop(), this.LookupArticyJump(node.id));
				break;
			case ArticyData.NodeType.Condition:
				this.BuildDialogueEntriesFromCondition(this.GetConversationStackTop(), this.LookupArticyCondition(node.id));
				break;
			case ArticyData.NodeType.Instruction:
				this.BuildDialogueEntryFromInstruction(this.GetConversationStackTop(), this.LookupArticyInstruction(node.id));
				break;
			}
			foreach (ArticyData.Node node2 in node.nodes)
			{
				this.BuildDialogueEntriesFromNode(node2, recursionDepth + 1);
			}
			ArticyData.NodeType type = node.type;
			if (type != ArticyData.NodeType.FlowFragment)
			{
				if (type == ArticyData.NodeType.Dialogue)
				{
					this.PopConversation();
				}
			}
			else
			{
				this.PopFlowFragment();
				if (this.prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups)
				{
					Conversation conversation3 = this.database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), node.id));
					if (conversation3 != null)
					{
						this.PopConversation();
					}
				}
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000AB90 File Offset: 0x00008D90
		private void PrependFlowStackToConversationTitle(Conversation conversation)
		{
			bool flag = this.prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.ConversationGroups || this.prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups;
			if (conversation == null || !flag || this.flowFragmentNameStack.Count <= 0)
			{
				return;
			}
			string text = string.Empty;
			foreach (string text2 in this.flowFragmentNameStack)
			{
				text = text + text2 + "/";
			}
			conversation.Title = text + conversation.Title;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000AC58 File Offset: 0x00008E58
		private void RecordPins(List<ArticyData.Pin> pins, DialogueEntry entry)
		{
			if (pins == null)
			{
				return;
			}
			for (int i = 0; i < pins.Count; i++)
			{
				this.RecordPin(pins[i], entry);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000AC94 File Offset: 0x00008E94
		private void RecordPin(ArticyData.Pin pin, DialogueEntry entry)
		{
			if (pin == null || entry == null || this.entriesByPinID.ContainsKey(pin.id))
			{
				return;
			}
			this.entriesByPinID.Add(pin.id, entry);
			Field.SetValue(entry.fields, (pin.semantic != ArticyData.SemanticType.Input) ? "OutputId" : "InputId", pin.id);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000AD04 File Offset: 0x00008F04
		private void ProcessConnections()
		{
			foreach (KeyValuePair<string, ArticyData.Connection> keyValuePair in this.articyData.connections)
			{
				this.ProcessConnectionNew(keyValuePair.Value);
			}
			foreach (KeyValuePair<ArticyData.Jump, DialogueEntry> keyValuePair2 in this.jumpsToProcess)
			{
				this.ProcessJumpConnection(keyValuePair2.Key, keyValuePair2.Value);
			}
			this.RemoveUnusedOutputEntries();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000ADE0 File Offset: 0x00008FE0
		private void ProcessConnectionNew(ArticyData.Connection connection)
		{
			if (connection == null)
			{
				return;
			}
			if (!this.entriesByPinID.ContainsKey(connection.source.pinRef))
			{
				return;
			}
			if (!this.entriesByPinID.ContainsKey(connection.target.pinRef))
			{
				return;
			}
			DialogueEntry dialogueEntry = this.entriesByPinID[connection.source.pinRef];
			DialogueEntry dialogueEntry2 = this.entriesByPinID[connection.target.pinRef];
			if (dialogueEntry.conversationID != dialogueEntry2.conversationID || dialogueEntry.id != dialogueEntry2.id)
			{
				Link link = new Link();
				link.originConversationID = dialogueEntry.conversationID;
				link.originDialogueID = dialogueEntry.id;
				link.destinationConversationID = dialogueEntry2.conversationID;
				link.destinationDialogueID = dialogueEntry2.id;
				link.isConnector = false;
				link.priority = ArticyData.ColorToPriority(connection.color);
				dialogueEntry.outgoingLinks.Add(link);
			}
			this.MarkTargetUsed(dialogueEntry2);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000AEE4 File Offset: 0x000090E4
		private void ProcessJumpConnection(ArticyData.Jump jump, DialogueEntry jumpEntry)
		{
			if (jump == null || jumpEntry == null || !this.entriesByPinID.ContainsKey(jump.target.pinRef))
			{
				return;
			}
			DialogueEntry dialogueEntry = this.entriesByPinID[jump.target.pinRef];
			Link link = new Link();
			link.originConversationID = jumpEntry.conversationID;
			link.originDialogueID = jumpEntry.id;
			link.destinationConversationID = dialogueEntry.conversationID;
			link.destinationDialogueID = dialogueEntry.id;
			link.isConnector = false;
			jumpEntry.outgoingLinks.Add(link);
			this.MarkTargetUsed(dialogueEntry);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000AF80 File Offset: 0x00009180
		private void MarkTargetUsed(DialogueEntry targetEntry)
		{
			this.unusedOutputEntries.Remove(targetEntry);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000AF90 File Offset: 0x00009190
		private void RemoveUnusedOutputEntries()
		{
			for (int i = 0; i < this.unusedOutputEntries.Count; i++)
			{
				DialogueEntry dialogueEntry = this.unusedOutputEntries[i];
				Conversation conversation = this.database.GetConversation(dialogueEntry.conversationID);
				if (conversation != null)
				{
					conversation.dialogueEntries.Remove(dialogueEntry);
				}
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000AFF0 File Offset: 0x000091F0
		private ArticyData.DialogueFragment LookupArticyDialogueFragment(string id)
		{
			return (!this.articyData.dialogueFragments.ContainsKey(id)) ? null : this.articyData.dialogueFragments[id];
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000B020 File Offset: 0x00009220
		private ArticyData.Hub LookupArticyHub(string id)
		{
			return (!this.articyData.hubs.ContainsKey(id)) ? null : this.articyData.hubs[id];
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000B050 File Offset: 0x00009250
		private ArticyData.Jump LookupArticyJump(string id)
		{
			return (!this.articyData.jumps.ContainsKey(id)) ? null : this.articyData.jumps[id];
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000B080 File Offset: 0x00009280
		private ArticyData.Condition LookupArticyCondition(string id)
		{
			return (!this.articyData.conditions.ContainsKey(id)) ? null : this.articyData.conditions[id];
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000B0B0 File Offset: 0x000092B0
		private ArticyData.Instruction LookupArticyInstruction(string id)
		{
			return (!this.articyData.instructions.ContainsKey(id)) ? null : this.articyData.instructions[id];
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000B0E0 File Offset: 0x000092E0
		private ArticyData.Connection LookupArticyConnection(string id)
		{
			return (!this.articyData.connections.ContainsKey(id)) ? null : this.articyData.connections[id];
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000B110 File Offset: 0x00009310
		private ArticyData.FlowFragment LookupArticyFlowFragment(string id)
		{
			return (!this.articyData.flowFragments.ContainsKey(id)) ? null : this.articyData.flowFragments[id];
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000B140 File Offset: 0x00009340
		private void BuildDialogueEntryFromDialogueFragment(Conversation conversation, ArticyData.DialogueFragment fragment)
		{
			if (fragment == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, fragment.displayName.DefaultText, fragment.id);
			dialogueEntry.canvasRect = new Rect(fragment.position.x, fragment.position.y, 160f, 30f);
			this.ConvertLocalizableText(dialogueEntry, "Dialogue Text", fragment.text);
			this.ConvertLocalizableText(dialogueEntry, "Menu Text", fragment.menuText);
			this.ConvertLocalizableText(dialogueEntry, "Title", fragment.displayName);
			if (this.prefs.StageDirectionsAreSequences)
			{
				this.ConvertLocalizableText(dialogueEntry, "Sequence", fragment.stageDirections);
			}
			this.SetFeatureFields(dialogueEntry.fields, fragment.features);
			Field field = Field.Lookup(dialogueEntry.fields, "Script");
			if (field != null)
			{
				dialogueEntry.userScript = this.AddToUserScript(dialogueEntry.userScript, field.value);
				dialogueEntry.fields.Remove(field);
			}
			Actor actor = this.FindActorByArticyId(fragment.speakerIdRef);
			dialogueEntry.ActorID = ((actor == null) ? conversation.ActorID : actor.id);
			Field field2 = Field.Lookup(dialogueEntry.fields, "ConversantEntity");
			Actor actor2 = ((field2 != null) ? ((this.prefs.ConvertSlotsAs != ConverterPrefs.ConvertSlotsModes.ID) ? this.FindActorByDisplayName(field2.value) : this.FindActorByArticyId(field2.value)) : null);
			if (actor2 != null)
			{
				dialogueEntry.ConversantID = actor2.id;
			}
			else
			{
				dialogueEntry.ConversantID = ((dialogueEntry.ActorID != conversation.ActorID) ? conversation.ActorID : conversation.ConversantID);
			}
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, fragment.pins);
			this.RecordPins(fragment.pins, dialogueEntry);
			if (this.documentConversation != null && this.lastDocumentEntry != null)
			{
				Link link = new Link(this.lastDocumentEntry.conversationID, this.lastDocumentEntry.id, dialogueEntry.conversationID, dialogueEntry.id);
				this.lastDocumentEntry.outgoingLinks.Add(link);
				this.lastDocumentEntry = dialogueEntry;
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000B370 File Offset: 0x00009570
		private void AddFlowFragmentAsDialogueEntry(Conversation conversation, ArticyData.FlowFragment flowFragment)
		{
			if (flowFragment == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, flowFragment.displayName.DefaultText, flowFragment.id);
			dialogueEntry.canvasRect = new Rect(flowFragment.position.x, flowFragment.position.y, 160f, 30f);
			this.ConvertLocalizableText(dialogueEntry, "Title", flowFragment.displayName);
			dialogueEntry.Title = "Flow: " + dialogueEntry.Title;
			this.SetFeatureFields(dialogueEntry.fields, flowFragment.features);
			Field field = Field.Lookup(dialogueEntry.fields, "Script");
			if (field != null)
			{
				dialogueEntry.userScript = this.AddToUserScript(dialogueEntry.userScript, field.value);
				dialogueEntry.fields.Remove(field);
			}
			dialogueEntry.ActorID = conversation.ActorID;
			dialogueEntry.ConversantID = ((dialogueEntry.ActorID != conversation.ActorID) ? conversation.ActorID : conversation.ConversantID);
			if (!string.IsNullOrEmpty(this.prefs.FlowFragmentScript))
			{
				dialogueEntry.userScript = this.prefs.FlowFragmentScript + "(\"" + flowFragment.displayName.DefaultText.Replace("\"", "'") + "\")";
			}
			dialogueEntry.isGroup = true;
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, flowFragment.pins);
			this.RecordPins(flowFragment.pins, dialogueEntry);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000B4E8 File Offset: 0x000096E8
		private void BuildDialogueEntryFromHub(Conversation conversation, ArticyData.Hub hub)
		{
			if (hub == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, hub.displayName.DefaultText, hub.id);
			dialogueEntry.canvasRect = new Rect(hub.position.x, hub.position.y, 160f, 30f);
			this.SetFeatureFields(dialogueEntry.fields, hub.features);
			this.ConvertLocalizableText(dialogueEntry, "Title", hub.displayName);
			dialogueEntry.isGroup = true;
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, hub.pins);
			this.RecordPins(hub.pins, dialogueEntry);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000B58C File Offset: 0x0000978C
		private void BuildDialogueEntryFromJump(Conversation conversation, ArticyData.Jump jump)
		{
			if (jump == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, jump.displayName.DefaultText, jump.id);
			dialogueEntry.canvasRect = new Rect(jump.position.x, jump.position.y, 160f, 30f);
			this.SetFeatureFields(dialogueEntry.fields, jump.features);
			this.ConvertLocalizableText(dialogueEntry, "Title", jump.displayName);
			dialogueEntry.isGroup = true;
			dialogueEntry.Sequence = "None()";
			this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, jump.pins);
			this.RecordPins(jump.pins, dialogueEntry);
			this.jumpsToProcess.Add(jump, dialogueEntry);
			ArticyData.FlowFragment flowFragment = this.FindFlowFragment(jump.target.idRef);
			if (flowFragment != null)
			{
				DialogueEntry dialogueEntry2 = this.CreateNewDialogueEntry(conversation, "Flow: " + flowFragment.displayName.DefaultText, flowFragment.id);
				dialogueEntry2.canvasRect = new Rect(jump.position.x, jump.position.y + 32f, 160f, 30f);
				this.SetFeatureFields(dialogueEntry2.fields, flowFragment.features);
				dialogueEntry2.isGroup = true;
				dialogueEntry2.Sequence = "None()";
				this.ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, flowFragment.pins);
				this.RecordPins(flowFragment.pins, dialogueEntry2);
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000B6F4 File Offset: 0x000098F4
		private void BuildDialogueEntriesFromCondition(Conversation conversation, ArticyData.Condition condition)
		{
			if (condition == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, condition.expression, condition.id);
			dialogueEntry.canvasRect = new Rect(condition.position.x, condition.position.y, 160f, 30f);
			dialogueEntry.ActorID = conversation.ConversantID;
			dialogueEntry.ConversantID = conversation.ActorID;
			dialogueEntry.DialogueText = string.Empty;
			dialogueEntry.MenuText = string.Empty;
			dialogueEntry.Sequence = "None()";
			dialogueEntry.isGroup = true;
			string text = ArticyConverter.ConvertExpression(condition.expression);
			string text2 = ((!string.IsNullOrEmpty(text)) ? string.Format("({0}) == false", text) : "false");
			float num = condition.position.y;
			foreach (ArticyData.Pin pin in condition.pins)
			{
				if (pin.semantic == ArticyData.SemanticType.Input)
				{
					this.RecordPin(pin, dialogueEntry);
					dialogueEntry.conditionsString = this.AddToConditions(dialogueEntry.conditionsString, ArticyConverter.ConvertExpression(pin.expression));
				}
				else if (pin.semantic == ArticyData.SemanticType.Output)
				{
					bool flag = pin.index == 0;
					string text3 = ((!flag) ? string.Format("!({0})", condition.expression) : condition.expression);
					DialogueEntry dialogueEntry2 = this.CreateNewDialogueEntry(conversation, text3, condition.id);
					dialogueEntry2.canvasRect = new Rect(condition.position.x, num, 160f, 30f);
					num += 2f;
					dialogueEntry2.ActorID = conversation.ConversantID;
					dialogueEntry2.ConversantID = conversation.ActorID;
					dialogueEntry2.DialogueText = string.Empty;
					dialogueEntry2.MenuText = string.Empty;
					dialogueEntry2.Sequence = "None()";
					dialogueEntry2.isGroup = true;
					string text4 = ((!flag) ? text2 : text);
					dialogueEntry2.conditionsString = this.AddToConditions(dialogueEntry2.conditionsString, text4);
					dialogueEntry2.userScript = this.AddToUserScript(dialogueEntry2.userScript, ArticyConverter.ConvertExpression(pin.expression));
					Link link = new Link();
					link.originConversationID = dialogueEntry.conversationID;
					link.originDialogueID = dialogueEntry.id;
					link.destinationConversationID = dialogueEntry2.conversationID;
					link.destinationDialogueID = dialogueEntry2.id;
					link.isConnector = false;
					dialogueEntry.outgoingLinks.Add(link);
					this.RecordPin(pin, dialogueEntry2);
				}
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000B9B4 File Offset: 0x00009BB4
		private void BuildDialogueEntryFromInstruction(Conversation conversation, ArticyData.Instruction instruction)
		{
			if (instruction == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = this.CreateNewDialogueEntry(conversation, instruction.expression, instruction.id);
			dialogueEntry.ActorID = conversation.ConversantID;
			dialogueEntry.ConversantID = conversation.ActorID;
			dialogueEntry.DialogueText = string.Empty;
			dialogueEntry.MenuText = string.Empty;
			dialogueEntry.Sequence = "None()";
			dialogueEntry.isGroup = true;
			dialogueEntry.conditionsString = string.Empty;
			dialogueEntry.userScript = this.AddToUserScript(dialogueEntry.userScript, ArticyConverter.ConvertExpression(instruction.expression));
			this.RecordPins(instruction.pins, dialogueEntry);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000BA58 File Offset: 0x00009C58
		private string AddToConditions(string conditions, string moreConditions)
		{
			return (!string.IsNullOrEmpty(conditions)) ? string.Format("({0}) and ({1})", conditions, moreConditions) : moreConditions;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000BA78 File Offset: 0x00009C78
		private string AddToUserScript(string script, string moreScript)
		{
			return (!string.IsNullOrEmpty(script)) ? string.Format("{0}; {1}", script, moreScript) : moreScript;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000BA98 File Offset: 0x00009C98
		private DialogueEntry CreateNewDialogueEntry(Conversation conversation, string title, string articyId)
		{
			if (conversation == null)
			{
				Debug.Log("Conversation is null! " + articyId + " / " + title);
				return null;
			}
			DialogueEntry dialogueEntry = this.template.CreateDialogueEntry(this.GetNextConversationEntryID(conversation), conversation.id, title);
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyId, FieldType.Text);
			this.IndexDialogueEntryByArticyId(dialogueEntry, articyId);
			conversation.dialogueEntries.Add(dialogueEntry);
			return dialogueEntry;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000BB04 File Offset: 0x00009D04
		private void ConvertPinExpressionsToConditionsAndScripts(DialogueEntry entry, List<ArticyData.Pin> pins)
		{
			foreach (ArticyData.Pin pin in pins)
			{
				ArticyData.SemanticType semantic = pin.semantic;
				if (semantic != ArticyData.SemanticType.Input)
				{
					if (semantic != ArticyData.SemanticType.Output)
					{
						Debug.LogWarning(string.Concat(new object[] { "Dialogue System: Unexpected semantic type ", pin.semantic, " for pin ", pin.id, "." }));
					}
					else
					{
						entry.userScript = this.AddToUserScript(entry.userScript, ArticyConverter.ConvertExpression(pin.expression));
					}
				}
				else
				{
					entry.conditionsString = this.AddToConditions(entry.conditionsString, ArticyConverter.ConvertExpression(pin.expression));
				}
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000BC00 File Offset: 0x00009E00
		public static string ConvertExpression(string expression)
		{
			if (string.IsNullOrEmpty(expression))
			{
				return expression;
			}
			if (expression.Contains("Variable["))
			{
				return expression;
			}
			if (!expression.Contains("\""))
			{
				return ArticyConverter.ConvertExpressionFragment(expression);
			}
			string[] array = Regex.Split(expression, "(?<=[^\\\\])[\\\"]", RegexOptions.None);
			string text = string.Empty;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				text += ((!flag) ? ArticyConverter.ConvertExpressionFragment(array[i]) : array[i]);
				if (i + 1 < array.Length)
				{
					text += '"';
				}
				flag = !flag;
			}
			return text;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000BCA8 File Offset: 0x00009EA8
		private static string ConvertExpressionFragment(string expression)
		{
			if (string.IsNullOrEmpty(expression))
			{
				return expression;
			}
			if (expression.Contains("Variable["))
			{
				return expression;
			}
			string text = expression.Trim().Replace("//", "--");
			text = text.Replace("&&", " and ");
			text = text.Replace("||", " or ");
			text = text.Replace("!=", "~=");
			foreach (string text2 in ArticyConverter.fullVariableNames)
			{
				if (text.Contains(text2))
				{
					string text3 = string.Format("Variable[\"{0}\"]", text2);
					text = Regex.Replace(text, "\\b" + text2 + "\\b", text3);
				}
			}
			text = text.Replace("!Variable", "false == Variable");
			if (ArticyConverter.ContainsArithmeticAssignment(text))
			{
				string[] array = text.Split(null);
				for (int i = 1; i < array.Length; i++)
				{
					string text4 = array[i];
					if (ArticyConverter.ContainsArithmeticAssignment(text4))
					{
						char c = text4[0];
						array[i] = string.Format("= {0} {1}", array[i - 1], c);
					}
				}
				text = string.Join(" ", array);
			}
			return text;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000BE24 File Offset: 0x0000A024
		private static bool ContainsArithmeticAssignment(string s)
		{
			return s != null && (s.Contains("+=") || s.Contains("-="));
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000BE50 File Offset: 0x0000A050
		private void ConvertLocalizableText(DialogueEntry entry, string baseFieldTitle, ArticyData.LocalizableText localizableText)
		{
			if (entry == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> keyValuePair in localizableText.localizedString)
			{
				if (string.IsNullOrEmpty(keyValuePair.Key))
				{
					Field.SetValue(entry.fields, baseFieldTitle, this.RemoveFormattingTags(keyValuePair.Value), FieldType.Text);
				}
				else
				{
					string text = ((!string.Equals("Dialogue Text", baseFieldTitle)) ? string.Format("{0} {1}", baseFieldTitle, keyValuePair.Key) : keyValuePair.Key);
					Field.SetValue(entry.fields, text, this.RemoveFormattingTags(keyValuePair.Value), FieldType.Localization);
				}
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000BF30 File Offset: 0x0000A130
		private void ConvertLocalizableText(List<Field> fields, string baseFieldTitle, ArticyData.LocalizableText localizableText)
		{
			foreach (KeyValuePair<string, string> keyValuePair in localizableText.localizedString)
			{
				if (string.IsNullOrEmpty(keyValuePair.Key))
				{
					Field.SetValue(fields, baseFieldTitle, this.RemoveFormattingTags(keyValuePair.Value), FieldType.Text);
				}
				else
				{
					string text = ((!string.Equals("Dialogue Text", baseFieldTitle)) ? string.Format("{0} {1}", baseFieldTitle, keyValuePair.Key) : keyValuePair.Key);
					Field.SetValue(fields, text, this.RemoveFormattingTags(keyValuePair.Value), FieldType.Localization);
				}
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000C000 File Offset: 0x0000A200
		private string RemoveFormattingTags(string s)
		{
			if (!string.IsNullOrEmpty(s) && s.Contains("font-size"))
			{
				Regex regex = new Regex("{font-size:[0-9]+pt;}");
				return regex.Replace(s, string.Empty);
			}
			return s;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000C044 File Offset: 0x0000A244
		private static void SetConversationStartCutsceneToNone(Conversation conversation)
		{
			DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
			if (firstDialogueEntry == null)
			{
				Debug.LogWarning("Dialogue System: Conversation '" + conversation.Title + "' doesn't have a START dialogue entry.");
			}
			else if (string.IsNullOrEmpty(firstDialogueEntry.Sequence))
			{
				firstDialogueEntry.Sequence = "None()";
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000C098 File Offset: 0x0000A298
		private Conversation FindConversationByArticyId(string articyId)
		{
			foreach (Conversation conversation in this.database.conversations)
			{
				if (string.Equals(Field.LookupValue(conversation.fields, "Articy Id"), articyId))
				{
					return conversation;
				}
			}
			return null;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000C124 File Offset: 0x0000A324
		private DialogueEntry FindDialogueEntryByArticyId(Conversation conversation, string articyId)
		{
			if (conversation == null)
			{
				return null;
			}
			if (this.entriesByArticyId.ContainsKey(articyId))
			{
				List<DialogueEntry> list = this.entriesByArticyId[articyId];
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].conversationID == conversation.id)
					{
						return list[i];
					}
				}
			}
			foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
			{
				if (string.Equals(Field.LookupValue(dialogueEntry.fields, "Articy Id"), articyId))
				{
					return dialogueEntry;
				}
			}
			return null;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000C208 File Offset: 0x0000A408
		private DialogueEntry FindDialogueEntryByArticyId(string articyId)
		{
			if (this.entriesByArticyId.ContainsKey(articyId))
			{
				List<DialogueEntry> list = this.entriesByArticyId[articyId];
				if (list.Count > 0)
				{
					return list[0];
				}
			}
			return null;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C248 File Offset: 0x0000A448
		private List<DialogueEntry> FindAllDialogueEntriesByArticyId(string articyId)
		{
			if (this.entriesByArticyId.ContainsKey(articyId))
			{
				return this.entriesByArticyId[articyId];
			}
			return new List<DialogueEntry>();
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C270 File Offset: 0x0000A470
		private ArticyData.FlowFragment FindFlowFragment(string articyId)
		{
			foreach (ArticyData.FlowFragment flowFragment in this.articyData.flowFragments.Values)
			{
				if (this.prefs.ConversionSettings.GetConversionSetting(flowFragment.id).Include && string.Equals(flowFragment.id, articyId))
				{
					return flowFragment;
				}
			}
			return null;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C314 File Offset: 0x0000A514
		private Actor FindActorByArticyId(string articyId)
		{
			foreach (Actor actor in this.database.actors)
			{
				if (string.Equals(actor.LookupValue("Articy Id"), articyId))
				{
					return actor;
				}
			}
			return null;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000C398 File Offset: 0x0000A598
		private Actor FindActorByDisplayName(string displayName)
		{
			foreach (Actor actor in this.database.actors)
			{
				if (string.Equals(actor.Name, displayName))
				{
					return actor;
				}
			}
			return null;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C418 File Offset: 0x0000A618
		private int FindActorIdFromArticyDialogue(ArticyData.Dialogue articyDialogue, int index)
		{
			Actor actor = null;
			if (index < articyDialogue.references.Count)
			{
				actor = this.FindActorByArticyId(articyDialogue.references[index]);
			}
			return (actor == null) ? 0 : actor.id;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000C460 File Offset: 0x0000A660
		private void SplitPipesIntoEntries()
		{
			foreach (Conversation conversation in this.database.conversations)
			{
				conversation.SplitPipesIntoEntries(true);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000C4CC File Offset: 0x0000A6CC
		private void SortAllLinksByPosition()
		{
			foreach (Conversation conversation in this.database.conversations)
			{
				this.SortLinksByPosition(conversation);
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000C538 File Offset: 0x0000A738
		private void SortLinksByPosition(Conversation conversation)
		{
			ArticyConverter.<SortLinksByPosition>c__AnonStorey3F <SortLinksByPosition>c__AnonStorey3F = new ArticyConverter.<SortLinksByPosition>c__AnonStorey3F();
			<SortLinksByPosition>c__AnonStorey3F.conversation = conversation;
			DialogueEntry entry;
			foreach (DialogueEntry dialogueEntry in <SortLinksByPosition>c__AnonStorey3F.conversation.dialogueEntries)
			{
				entry = dialogueEntry;
				entry.outgoingLinks.Sort(delegate(Link A, Link B)
				{
					if (A.destinationConversationID != B.destinationConversationID)
					{
						return 0;
					}
					DialogueEntry dialogueEntry3 = <SortLinksByPosition>c__AnonStorey3F.conversation.GetDialogueEntry(A.destinationDialogueID);
					DialogueEntry dialogueEntry4 = <SortLinksByPosition>c__AnonStorey3F.conversation.GetDialogueEntry(B.destinationDialogueID);
					if (dialogueEntry3 == null || dialogueEntry4 == null)
					{
						Debug.LogWarning(string.Concat(new object[]
						{
							"Dialogue System: Unexpected error sorting links by position. destA=",
							(dialogueEntry3 != null) ? dialogueEntry3.ToString() : "null",
							" (",
							A.destinationConversationID,
							":",
							A.destinationDialogueID,
							"), destB=",
							(dialogueEntry4 != null) ? dialogueEntry4.ToString() : "null",
							" (",
							B.destinationConversationID,
							":",
							B.destinationDialogueID,
							") in conversation '",
							<SortLinksByPosition>c__AnonStorey3F.conversation.Title,
							"' entry ",
							entry.id,
							"."
						}));
					}
					return (dialogueEntry3 != null && dialogueEntry4 != null) ? dialogueEntry3.canvasRect.y.CompareTo(dialogueEntry4.canvasRect.y) : A.destinationDialogueID.CompareTo(B.destinationDialogueID);
				});
			}
			foreach (DialogueEntry dialogueEntry2 in <SortLinksByPosition>c__AnonStorey3F.conversation.dialogueEntries)
			{
				dialogueEntry2.canvasRect = new Rect(0f, 0f, 160f, 30f);
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000C650 File Offset: 0x0000A850
		private void RedirectLinkbacksToStartToLinkOutFromStart()
		{
			Conversation conversation;
			foreach (Conversation conversation2 in this.database.conversations)
			{
				conversation = conversation2;
				DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
				if (firstDialogueEntry != null)
				{
					Link link = firstDialogueEntry.outgoingLinks.Find((Link x) => x.destinationConversationID != conversation.id);
					if (link != null)
					{
						firstDialogueEntry.outgoingLinks.Remove(link);
					}
					foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
					{
						if (dialogueEntry != firstDialogueEntry)
						{
							for (int i = dialogueEntry.outgoingLinks.Count - 1; i >= 0; i--)
							{
								Link link2 = dialogueEntry.outgoingLinks[i];
								if (link2.destinationConversationID == conversation.id && link2.destinationDialogueID == firstDialogueEntry.id)
								{
									if (link == null)
									{
										dialogueEntry.outgoingLinks.RemoveAt(i);
									}
									else
									{
										link2.destinationConversationID = link.destinationConversationID;
										link2.destinationDialogueID = link.destinationDialogueID;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000C7F4 File Offset: 0x0000A9F4
		private bool DoesEntryLinkOutsideConversation(DialogueEntry entry)
		{
			if (entry == null)
			{
				return false;
			}
			foreach (Link link in entry.outgoingLinks)
			{
				if (link.destinationConversationID != entry.conversationID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000C878 File Offset: 0x0000AA78
		private void ConvertVoiceOverProperties()
		{
			foreach (Conversation conversation in this.database.conversations)
			{
				foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
				{
					this.ConvertVoiceOverProperty(dialogueEntry);
				}
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000C934 File Offset: 0x0000AB34
		private void ConvertVoiceOverProperty(DialogueEntry entry)
		{
			if (entry == null)
			{
				return;
			}
			Field field = Field.Lookup(entry.fields, this.prefs.VoiceOverProperty);
			if (field == null)
			{
				return;
			}
			string value = field.value;
			ArticyData.Asset asset = ((!this.articyData.assets.ContainsKey(value)) ? null : this.articyData.assets[value]);
			if (asset == null)
			{
				Debug.LogWarning(string.Concat(new object[] { "Dialogue System: Can't find voice-over asset with ID ", value, " for dialogue entry [", entry.conversationID, ":", entry.id, "]: '", entry.DialogueText, "'." }));
				return;
			}
			entry.fields.Remove(field);
			entry.fields.Add(new Field("VoiceOverFile", Path.GetFileNameWithoutExtension(asset.assetFilename), FieldType.Text));
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000CA34 File Offset: 0x0000AC34
		private void FindPortraitTextureInResources(Actor actor)
		{
			if (actor == null || actor.portrait != null)
			{
				return;
			}
			string textureName = actor.TextureName;
			if (!string.IsNullOrEmpty(textureName))
			{
				string text = Path.GetFileNameWithoutExtension(textureName).Replace('\\', '/');
				if (Application.isPlaying)
				{
					actor.portrait = DialogueManager.LoadAsset(text, typeof(Texture2D)) as Texture2D;
				}
				else
				{
					actor.portrait = Resources.Load(text, typeof(Texture2D)) as Texture2D;
				}
			}
		}

		// Token: 0x040000D9 RID: 217
		private const string ArticyIdFieldTitle = "Articy Id";

		// Token: 0x040000DA RID: 218
		private const string ArticyTechnicalNameFieldTitle = "Technical Name";

		// Token: 0x040000DB RID: 219
		private const string DestinationArticyIdFieldTitle = "destinationArticyId";

		// Token: 0x040000DC RID: 220
		private const int StartEntryID = 0;

		// Token: 0x040000DD RID: 221
		private const int MaxRecursionDepth = 1000;

		// Token: 0x040000DE RID: 222
		private ArticyData articyData;

		// Token: 0x040000DF RID: 223
		private ConverterPrefs prefs;

		// Token: 0x040000E0 RID: 224
		private DialogueDatabase database;

		// Token: 0x040000E1 RID: 225
		private Template template;

		// Token: 0x040000E2 RID: 226
		private int conversationID;

		// Token: 0x040000E3 RID: 227
		private int actorID;

		// Token: 0x040000E4 RID: 228
		private int itemID;

		// Token: 0x040000E5 RID: 229
		private int locationID;

		// Token: 0x040000E6 RID: 230
		private static List<string> fullVariableNames = new List<string>();

		// Token: 0x040000E7 RID: 231
		private Conversation documentConversation;

		// Token: 0x040000E8 RID: 232
		private DialogueEntry lastDocumentEntry;

		// Token: 0x040000E9 RID: 233
		private List<string> flowFragmentNameStack = new List<string>();

		// Token: 0x040000EA RID: 234
		private List<Conversation> conversationStack = new List<Conversation>();

		// Token: 0x040000EB RID: 235
		private Dictionary<Conversation, int> conversationLastEntryID = new Dictionary<Conversation, int>();

		// Token: 0x040000EC RID: 236
		private Dictionary<string, List<DialogueEntry>> entriesByArticyId = new Dictionary<string, List<DialogueEntry>>();

		// Token: 0x040000ED RID: 237
		private Dictionary<string, DialogueEntry> entriesByPinID = new Dictionary<string, DialogueEntry>();

		// Token: 0x040000EE RID: 238
		private Dictionary<ArticyData.Jump, DialogueEntry> jumpsToProcess = new Dictionary<ArticyData.Jump, DialogueEntry>();

		// Token: 0x040000EF RID: 239
		private List<DialogueEntry> unusedOutputEntries = new List<DialogueEntry>();

		// Token: 0x020002DD RID: 733
		// (Invoke) Token: 0x06001DED RID: 7661
		public delegate void ProgressCallbackDelegate(string info, float progress);
	}
}
