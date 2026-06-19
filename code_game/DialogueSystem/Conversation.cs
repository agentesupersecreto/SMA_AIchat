using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class Conversation : Asset
	{
		// Token: 0x0600014C RID: 332 RVA: 0x00005F78 File Offset: 0x00004178
		public Conversation()
		{
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005FB8 File Offset: 0x000041B8
		public Conversation(Conversation sourceConversation)
			: base(sourceConversation)
		{
			this.nodeColor = sourceConversation.nodeColor;
			this.dialogueEntries = this.CopyDialogueEntries(sourceConversation.dialogueEntries);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006018 File Offset: 0x00004218
		public Conversation(Conversation chatMapperConversation, bool putEndSequenceOnLastSplit = true)
		{
			this.Assign(chatMapperConversation, putEndSequenceOnLastSplit);
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00006060 File Offset: 0x00004260
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00006070 File Offset: 0x00004270
		public string Title
		{
			get
			{
				return base.LookupValue("Title");
			}
			set
			{
				Field.SetValue(this.fields, "Title", value);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00006084 File Offset: 0x00004284
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00006094 File Offset: 0x00004294
		public string Description
		{
			get
			{
				return base.LookupValue("Description");
			}
			set
			{
				Field.SetValue(this.fields, "Description", value);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000153 RID: 339 RVA: 0x000060A8 File Offset: 0x000042A8
		// (set) Token: 0x06000154 RID: 340 RVA: 0x000060B8 File Offset: 0x000042B8
		public int ActorID
		{
			get
			{
				return base.LookupInt("Actor");
			}
			set
			{
				Field.SetValue(this.fields, "Actor", value.ToString(), FieldType.Actor);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000060D4 File Offset: 0x000042D4
		// (set) Token: 0x06000156 RID: 342 RVA: 0x000060E4 File Offset: 0x000042E4
		public int ConversantID
		{
			get
			{
				return base.LookupInt("Conversant");
			}
			set
			{
				Field.SetValue(this.fields, "Conversant", value.ToString(), FieldType.Actor);
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00006100 File Offset: 0x00004300
		public void Assign(Conversation chatMapperConversation, bool putEndSequenceOnLastSplit = true)
		{
			if (chatMapperConversation != null)
			{
				base.Assign(chatMapperConversation.ID, chatMapperConversation.Fields);
				this.nodeColor = chatMapperConversation.NodeColor;
				foreach (DialogEntry dialogEntry in chatMapperConversation.DialogEntries)
				{
					this.AddConversationDialogueEntry(dialogEntry);
				}
				this.SplitPipesIntoEntries(putEndSequenceOnLastSplit);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00006194 File Offset: 0x00004394
		private void AddConversationDialogueEntry(DialogEntry chatMapperEntry)
		{
			DialogueEntry dialogueEntry = new DialogueEntry(chatMapperEntry);
			dialogueEntry.conversationID = this.id;
			this.dialogueEntries.Add(dialogueEntry);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000061C0 File Offset: 0x000043C0
		public DialogueEntry GetDialogueEntry(string title)
		{
			return this.dialogueEntries.Find((DialogueEntry e) => string.Equals(e.Title, title));
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000061F4 File Offset: 0x000043F4
		public DialogueEntry GetDialogueEntry(int dialogueEntryID)
		{
			return this.dialogueEntries.Find((DialogueEntry e) => object.Equals(e.id, dialogueEntryID));
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00006228 File Offset: 0x00004428
		public DialogueEntry GetFirstDialogueEntry()
		{
			return this.dialogueEntries.Find((DialogueEntry e) => string.Equals(e.Title, "START"));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006260 File Offset: 0x00004460
		public void SplitPipesIntoEntries(bool putEndSequenceOnLastSplit = true)
		{
			if (this.dialogueEntries != null)
			{
				int count = this.dialogueEntries.Count;
				for (int i = 0; i < count; i++)
				{
					string defaultDialogueText = this.dialogueEntries[i].DefaultDialogueText;
					if (!string.IsNullOrEmpty(defaultDialogueText) && defaultDialogueText.Contains("|"))
					{
						this.SplitEntryAtPipes(i, defaultDialogueText, putEndSequenceOnLastSplit);
					}
				}
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000062CC File Offset: 0x000044CC
		private void SplitEntryAtPipes(int originalEntryIndex, string dialogueText, bool putEndSequenceOnLastSplit)
		{
			string[] array = dialogueText.Split(new char[] { '|' });
			DialogueEntry dialogueEntry = this.dialogueEntries[originalEntryIndex];
			dialogueEntry.DefaultDialogueText = array[0];
			List<Link> outgoingLinks = dialogueEntry.outgoingLinks;
			ConditionPriority conditionPriority = ((outgoingLinks == null || outgoingLinks.Count <= 0) ? ConditionPriority.Normal : outgoingLinks[0].priority);
			DialogueEntry dialogueEntry2 = dialogueEntry;
			List<DialogueEntry> list = new List<DialogueEntry>();
			list.Add(dialogueEntry2);
			string text = ((dialogueEntry == null || dialogueEntry.DefaultMenuText == null) ? string.Empty : dialogueEntry.DefaultMenuText);
			string[] array2 = text.Split(new char[] { '|' });
			string text2 = dialogueEntry.AudioFiles;
			text2 = ((text2 == null || text2.Length < 2) ? string.Empty : text2.Substring(1, text2.Length - 2));
			string[] array3 = text2.Split(new char[] { ';' });
			dialogueEntry2.AudioFiles = string.Format("[{0}]", new object[] { (array3.Length <= 0) ? string.Empty : array3[0] });
			for (int i = 1; i < array.Length; i++)
			{
				DialogueEntry dialogueEntry3 = this.AddNewDialogueEntry(dialogueEntry, array[i], i);
				dialogueEntry3.canvasRect = new Rect(dialogueEntry.canvasRect.x + (float)(i * 20), dialogueEntry.canvasRect.y + (float)(i * 10), dialogueEntry.canvasRect.width, dialogueEntry.canvasRect.height);
				dialogueEntry3.MenuText = ((i >= array2.Length) ? string.Empty : array2[i]);
				dialogueEntry3.AudioFiles = string.Format("[{0}]", new object[] { (i >= array3.Length) ? string.Empty : array3[i] });
				dialogueEntry2.outgoingLinks = new List<Link> { this.NewLink(dialogueEntry2, dialogueEntry3, conditionPriority) };
				dialogueEntry2 = dialogueEntry3;
				list.Add(dialogueEntry3);
			}
			dialogueEntry2.outgoingLinks = outgoingLinks;
			foreach (Field field in dialogueEntry.fields)
			{
				if (!string.IsNullOrEmpty(field.title))
				{
					string text3 = ((field.value == null) ? string.Empty : field.value);
					bool flag = field.title.StartsWith("Sequence");
					bool flag2 = field.type == FieldType.Localization;
					bool flag3 = text3.Contains("|");
					bool flag4 = (flag || flag2) && !string.IsNullOrEmpty(field.value) && flag3;
					if (flag4)
					{
						array = field.value.Split(new char[] { '|' });
						if (array.Length > 1)
						{
							text3 = array[0];
							field.value = text3;
						}
					}
					else if (flag && putEndSequenceOnLastSplit && !flag3 && field.value.Contains("{{end}}"))
					{
						this.PutEndSequenceOnLastSplit(list, field);
					}
				}
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000663C File Offset: 0x0000483C
		private void PutEndSequenceOnLastSplit(List<DialogueEntry> entries, Field field)
		{
			string[] array = field.value.Split(new char[] { ';' });
			for (int i = 0; i < entries.Count; i++)
			{
				DialogueEntry dialogueEntry = entries[i];
				Field field2 = Field.Lookup(dialogueEntry.fields, field.title);
				field2.value = string.Empty;
				if (i == 0)
				{
					foreach (string text in array)
					{
						if (!text.Contains("{{end}}"))
						{
							Field field3 = field2;
							field3.value = field3.value + text.Trim() + "; ";
						}
					}
					Field field4 = field2;
					field4.value += "Delay({{end}})";
				}
				else if (i == entries.Count - 1)
				{
					foreach (string text2 in array)
					{
						if (text2.Contains("{{end}}"))
						{
							Field field5 = field2;
							field5.value = field5.value + text2.Trim() + "; ";
						}
					}
				}
				else
				{
					field2.value = "Delay({{end}})";
				}
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006780 File Offset: 0x00004980
		private DialogueEntry AddNewDialogueEntry(DialogueEntry originalEntry, string dialogueText, int partNum)
		{
			DialogueEntry dialogueEntry = new DialogueEntry();
			dialogueEntry.id = this.GetHighestDialogueEntryID() + 1;
			dialogueEntry.conversationID = originalEntry.conversationID;
			dialogueEntry.isRoot = originalEntry.isRoot;
			dialogueEntry.isGroup = originalEntry.isGroup;
			dialogueEntry.nodeColor = originalEntry.nodeColor;
			dialogueEntry.delaySimStatus = originalEntry.delaySimStatus;
			dialogueEntry.falseConditionAction = originalEntry.falseConditionAction;
			dialogueEntry.conditionsString = ((!string.Equals(originalEntry.falseConditionAction, "Passthrough")) ? string.Empty : originalEntry.conditionsString);
			dialogueEntry.userScript = string.Empty;
			dialogueEntry.fields = new List<Field>();
			foreach (Field field in originalEntry.fields)
			{
				if (!string.IsNullOrEmpty(field.title))
				{
					string text = field.value;
					bool flag = (field.title.StartsWith("Sequence") || field.type == FieldType.Localization) && !string.IsNullOrEmpty(field.value) && field.value.Contains("|");
					if (flag)
					{
						string[] array = field.value.Split(new char[] { '|' });
						if (partNum < array.Length)
						{
							text = array[partNum];
						}
					}
					dialogueEntry.fields.Add(new Field(field.title, text, field.type));
				}
			}
			dialogueEntry.DefaultDialogueText = dialogueText;
			this.dialogueEntries.Add(dialogueEntry);
			return dialogueEntry;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00006940 File Offset: 0x00004B40
		private int GetHighestDialogueEntryID()
		{
			int num = 0;
			foreach (DialogueEntry dialogueEntry in this.dialogueEntries)
			{
				num = Mathf.Max(dialogueEntry.id, num);
			}
			return num;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000069B0 File Offset: 0x00004BB0
		private Link NewLink(DialogueEntry origin, DialogueEntry destination, ConditionPriority priority = ConditionPriority.Normal)
		{
			return new Link
			{
				originConversationID = origin.conversationID,
				originDialogueID = origin.id,
				destinationConversationID = destination.conversationID,
				destinationDialogueID = destination.id,
				isConnector = (origin.conversationID != destination.conversationID),
				priority = priority
			};
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006A14 File Offset: 0x00004C14
		private List<DialogueEntry> CopyDialogueEntries(List<DialogueEntry> sourceEntries)
		{
			List<DialogueEntry> list = new List<DialogueEntry>();
			foreach (DialogueEntry dialogueEntry in sourceEntries)
			{
				list.Add(new DialogueEntry(dialogueEntry));
			}
			return list;
		}

		// Token: 0x0400007B RID: 123
		public ConversationOverrideDisplaySettings overrideSettings = new ConversationOverrideDisplaySettings();

		// Token: 0x0400007C RID: 124
		public string nodeColor;

		// Token: 0x0400007D RID: 125
		public List<DialogueEntry> dialogueEntries = new List<DialogueEntry>();

		// Token: 0x0400007E RID: 126
		[HideInInspector]
		public Vector2 canvasScrollPosition = Vector2.zero;

		// Token: 0x0400007F RID: 127
		[HideInInspector]
		public float canvasZoom = 1f;
	}
}
