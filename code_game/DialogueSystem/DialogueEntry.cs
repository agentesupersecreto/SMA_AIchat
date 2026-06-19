using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	public class DialogueEntry
	{
		// Token: 0x06000191 RID: 401 RVA: 0x00007BE8 File Offset: 0x00005DE8
		public DialogueEntry()
		{
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00007C38 File Offset: 0x00005E38
		public DialogueEntry(DialogEntry chatMapperDialogEntry)
		{
			if (chatMapperDialogEntry != null)
			{
				this.id = chatMapperDialogEntry.ID;
				this.fields = Field.CreateListFromChatMapperFields(chatMapperDialogEntry.Fields);
				this.UseCanvasRectField();
				this.isRoot = chatMapperDialogEntry.IsRoot;
				this.isGroup = chatMapperDialogEntry.IsGroup;
				if (this.isGroup)
				{
					this.Sequence = "None()";
				}
				this.nodeColor = chatMapperDialogEntry.NodeColor;
				this.delaySimStatus = chatMapperDialogEntry.DelaySimStatus;
				this.falseConditionAction = chatMapperDialogEntry.FalseCondtionAction;
				this.conditionPriority = ConditionPriorityTools.StringToConditionPriority(chatMapperDialogEntry.ConditionPriority);
				foreach (Link link in chatMapperDialogEntry.OutgoingLinks)
				{
					this.outgoingLinks.Add(new Link(link));
				}
				this.conditionsString = chatMapperDialogEntry.ConditionsString;
				this.userScript = chatMapperDialogEntry.UserScript;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00007D90 File Offset: 0x00005F90
		public DialogueEntry(DialogueEntry sourceEntry)
		{
			this.id = sourceEntry.id;
			this.fields = Field.CopyFields(sourceEntry.fields);
			this.conversationID = sourceEntry.conversationID;
			this.isRoot = sourceEntry.isRoot;
			this.isGroup = sourceEntry.isGroup;
			this.nodeColor = sourceEntry.nodeColor;
			this.delaySimStatus = sourceEntry.delaySimStatus;
			this.falseConditionAction = sourceEntry.falseConditionAction;
			this.conditionPriority = ConditionPriority.Normal;
			this.outgoingLinks = this.CopyLinks(sourceEntry.outgoingLinks);
			this.conditionsString = sourceEntry.conditionsString;
			this.userScript = sourceEntry.userScript;
			this.canvasRect = sourceEntry.canvasRect;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00007E84 File Offset: 0x00006084
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00007E98 File Offset: 0x00006098
		public int ActorID
		{
			get
			{
				return Field.LookupInt(this.fields, "Actor");
			}
			set
			{
				Field.SetValue(this.fields, "Actor", value.ToString(), FieldType.Actor);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00007EB4 File Offset: 0x000060B4
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00007EC8 File Offset: 0x000060C8
		public int ConversantID
		{
			get
			{
				return Field.LookupInt(this.fields, "Conversant");
			}
			set
			{
				Field.SetValue(this.fields, "Conversant", value.ToString(), FieldType.Actor);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00007EE4 File Offset: 0x000060E4
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00007EF8 File Offset: 0x000060F8
		public string Title
		{
			get
			{
				return Field.LookupLocalizedValue(this.fields, "Title");
			}
			set
			{
				Field.SetValue(this.fields, "Title", value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00007F0C File Offset: 0x0000610C
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00007F1C File Offset: 0x0000611C
		public string MenuText
		{
			get
			{
				return Field.FieldValue(this.GetCurrentMenuTextField());
			}
			set
			{
				Field currentMenuTextField = this.GetCurrentMenuTextField();
				if (currentMenuTextField != null)
				{
					currentMenuTextField.value = value;
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007F40 File Offset: 0x00006140
		private Field GetCurrentMenuTextField()
		{
			return Field.AssignedField(this.fields, Field.LocalizedTitle("Menu Text")) ?? Field.Lookup(this.fields, "Menu Text");
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00007F7C File Offset: 0x0000617C
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00007F90 File Offset: 0x00006190
		public string DefaultMenuText
		{
			get
			{
				return Field.LookupValue(this.fields, "Menu Text");
			}
			set
			{
				Field.SetValue(this.fields, "Menu Text", value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00007FA4 File Offset: 0x000061A4
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00007FBC File Offset: 0x000061BC
		public string LocalizedMenuText
		{
			get
			{
				return Field.LookupValue(this.fields, Field.LocalizedTitle("Menu Text"));
			}
			set
			{
				Field.SetValue(this.fields, Field.LocalizedTitle("Menu Text"), value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00007FD4 File Offset: 0x000061D4
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00007FE4 File Offset: 0x000061E4
		public string DialogueText
		{
			get
			{
				return Field.FieldValue(this.GetCurrentDialogueTextField());
			}
			set
			{
				Field currentDialogueTextField = this.GetCurrentDialogueTextField();
				if (currentDialogueTextField != null)
				{
					currentDialogueTextField.value = value;
				}
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00008008 File Offset: 0x00006208
		private Field GetCurrentDialogueTextField()
		{
			return Field.AssignedField(this.fields, Localization.Language) ?? Field.Lookup(this.fields, "Dialogue Text");
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00008034 File Offset: 0x00006234
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00008048 File Offset: 0x00006248
		public string DefaultDialogueText
		{
			get
			{
				return Field.LookupValue(this.fields, "Dialogue Text");
			}
			set
			{
				Field.SetValue(this.fields, "Dialogue Text", value);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000805C File Offset: 0x0000625C
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00008070 File Offset: 0x00006270
		public string LocalizedDialogueText
		{
			get
			{
				return Field.LookupValue(this.fields, Localization.Language);
			}
			set
			{
				Field.SetValue(this.fields, Localization.Language, value);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00008084 File Offset: 0x00006284
		public string SubtitleText
		{
			get
			{
				return (!string.IsNullOrEmpty(this.DialogueText)) ? this.DialogueText : this.MenuText;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x000080B4 File Offset: 0x000062B4
		public string ResponseButtonText
		{
			get
			{
				return (!string.IsNullOrEmpty(this.MenuText)) ? this.MenuText : this.DialogueText;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000080E4 File Offset: 0x000062E4
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000080F4 File Offset: 0x000062F4
		public string Sequence
		{
			get
			{
				return Field.FieldValue(this.GetCurrentSequenceField());
			}
			set
			{
				this.SetCurrentSequenceField(value);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00008100 File Offset: 0x00006300
		private Field GetCurrentSequenceField()
		{
			return Field.AssignedField(this.fields, Field.LocalizedTitle("Sequence")) ?? Field.Lookup(this.fields, "Sequence");
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000813C File Offset: 0x0000633C
		private void SetCurrentSequenceField(string value)
		{
			Field currentSequenceField = this.GetCurrentSequenceField();
			if (currentSequenceField == null && Localization.IsDefaultLanguage)
			{
				this.fields.Add(new Field("Sequence", value, FieldType.Text));
			}
			else if (currentSequenceField != null)
			{
				currentSequenceField.value = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000818C File Offset: 0x0000638C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000081A0 File Offset: 0x000063A0
		public string DefaultSequence
		{
			get
			{
				return Field.LookupValue(this.fields, "Sequence");
			}
			set
			{
				this.SetSequenceField("Sequence", value);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000081B0 File Offset: 0x000063B0
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000081C8 File Offset: 0x000063C8
		public string LocalizedSequence
		{
			get
			{
				return Field.LookupValue(this.fields, Field.LocalizedTitle("Sequence"));
			}
			set
			{
				this.SetSequenceField(Field.LocalizedTitle("Sequence"), value);
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000081DC File Offset: 0x000063DC
		private void SetSequenceField(string title, string value)
		{
			Field field = Field.Lookup(this.fields, title);
			if (field != null)
			{
				field.value = value;
			}
			else
			{
				this.fields.Add(new Field(title, value, FieldType.Text));
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000821C File Offset: 0x0000641C
		public bool HasResponseMenuSequence()
		{
			return Field.FieldExists(this.fields, "Response Menu Sequence");
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00008230 File Offset: 0x00006430
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00008240 File Offset: 0x00006440
		public string ResponseMenuSequence
		{
			get
			{
				return Field.FieldValue(this.GetCurrentResponseMenuSequenceField());
			}
			set
			{
				this.SetCurrentResponseMenuSequenceField(value);
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000824C File Offset: 0x0000644C
		private Field GetCurrentResponseMenuSequenceField()
		{
			return Field.AssignedField(this.fields, Field.LocalizedTitle("Response Menu Sequence")) ?? Field.Lookup(this.fields, "Response Menu Sequence");
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00008288 File Offset: 0x00006488
		private void SetCurrentResponseMenuSequenceField(string value)
		{
			Field currentSequenceField = this.GetCurrentSequenceField();
			if (currentSequenceField == null && Localization.IsDefaultLanguage)
			{
				this.fields.Add(new Field("Response Menu Sequence", value, FieldType.Text));
			}
			else if (currentSequenceField != null)
			{
				currentSequenceField.value = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x000082D8 File Offset: 0x000064D8
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x000082EC File Offset: 0x000064EC
		public string DefaultResponseMenuSequence
		{
			get
			{
				return Field.LookupValue(this.fields, "Response Menu Sequence");
			}
			set
			{
				this.SetSequenceField("Response Menu Sequence", value);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000082FC File Offset: 0x000064FC
		// (set) Token: 0x060001BB RID: 443 RVA: 0x00008314 File Offset: 0x00006514
		public string LocalizedResponseMenuSequence
		{
			get
			{
				return Field.LookupValue(this.fields, Field.LocalizedTitle("Response Menu Sequence"));
			}
			set
			{
				this.SetSequenceField(Field.LocalizedTitle("Response Menu Sequence"), value);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00008328 File Offset: 0x00006528
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000833C File Offset: 0x0000653C
		public string VideoFile
		{
			get
			{
				return Field.LookupValue(this.fields, "Video File");
			}
			set
			{
				Field.SetValue(this.fields, "Video File", value);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00008350 File Offset: 0x00006550
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00008364 File Offset: 0x00006564
		public string AudioFiles
		{
			get
			{
				return Field.LookupValue(this.fields, "Audio Files");
			}
			set
			{
				Field.SetValue(this.fields, "Audio Files", value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00008378 File Offset: 0x00006578
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000838C File Offset: 0x0000658C
		public string AnimationFiles
		{
			get
			{
				return Field.LookupValue(this.fields, "Animation Files");
			}
			set
			{
				Field.SetValue(this.fields, "Animation Files", value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x000083A0 File Offset: 0x000065A0
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x000083B4 File Offset: 0x000065B4
		public string LipsyncFiles
		{
			get
			{
				return Field.LookupValue(this.fields, "Lipsync Files");
			}
			set
			{
				Field.SetValue(this.fields, "Lipsync Files", value);
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000083C8 File Offset: 0x000065C8
		public void UseCanvasRectField()
		{
			Field field = Field.Lookup(this.fields, "canvasRect");
			if (field != null && !string.IsNullOrEmpty(field.value))
			{
				string[] array = field.value.Split(new char[] { ';' });
				float num = ((array.Length < 1) ? 0f : Tools.StringToFloat(array[0]));
				float num2 = ((array.Length < 2) ? 0f : Tools.StringToFloat(array[1]));
				if (num > 0f && num2 > 0f)
				{
					this.canvasRect = new Rect(num, num2, this.canvasRect.width, this.canvasRect.height);
				}
				this.fields.Remove(field);
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00008494 File Offset: 0x00006694
		private List<Link> CopyLinks(List<Link> sourceLinks)
		{
			List<Link> list = new List<Link>();
			foreach (Link link in sourceLinks)
			{
				list.Add(new Link(link));
			}
			return list;
		}

		// Token: 0x040000A8 RID: 168
		public const float CanvasRectWidth = 160f;

		// Token: 0x040000A9 RID: 169
		public const float CanvasRectHeight = 30f;

		// Token: 0x040000AA RID: 170
		public int id;

		// Token: 0x040000AB RID: 171
		public List<Field> fields;

		// Token: 0x040000AC RID: 172
		public int conversationID;

		// Token: 0x040000AD RID: 173
		public bool isRoot;

		// Token: 0x040000AE RID: 174
		public bool isGroup;

		// Token: 0x040000AF RID: 175
		public string nodeColor;

		// Token: 0x040000B0 RID: 176
		public bool delaySimStatus;

		// Token: 0x040000B1 RID: 177
		public string falseConditionAction;

		// Token: 0x040000B2 RID: 178
		public ConditionPriority conditionPriority = ConditionPriority.Normal;

		// Token: 0x040000B3 RID: 179
		public List<Link> outgoingLinks = new List<Link>();

		// Token: 0x040000B4 RID: 180
		public string conditionsString;

		// Token: 0x040000B5 RID: 181
		public string userScript;

		// Token: 0x040000B6 RID: 182
		public UnityEvent onExecute = new UnityEvent();

		// Token: 0x040000B7 RID: 183
		public Rect canvasRect = new Rect(0f, 0f, 160f, 30f);
	}
}
