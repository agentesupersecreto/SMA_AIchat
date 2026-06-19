using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000218 RID: 536
	[Serializable]
	public class Template
	{
		// Token: 0x06001805 RID: 6149 RVA: 0x00020444 File Offset: 0x0001E644
		public static Template FromDefault()
		{
			Template template = new Template();
			template.actorFields.Clear();
			template.actorFields.Add(new Field("Name", string.Empty, FieldType.Text));
			template.actorFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.actorFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.actorFields.Add(new Field("IsPlayer", "False", FieldType.Boolean));
			template.itemFields.Clear();
			template.itemFields.Add(new Field("Name", string.Empty, FieldType.Text));
			template.itemFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.itemFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.itemFields.Add(new Field("Is Item", "True", FieldType.Boolean));
			template.questFields.Clear();
			template.questFields.Add(new Field("Name", string.Empty, FieldType.Text));
			template.questFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.questFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.questFields.Add(new Field("Success Description", string.Empty, FieldType.Text));
			template.questFields.Add(new Field("Failure Description", string.Empty, FieldType.Text));
			template.questFields.Add(new Field("State", "unassigned", FieldType.Text));
			template.questFields.Add(new Field("Is Item", "False", FieldType.Boolean));
			template.locationFields.Clear();
			template.locationFields.Add(new Field("Name", string.Empty, FieldType.Text));
			template.locationFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.locationFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.variableFields.Add(new Field("Name", string.Empty, FieldType.Text));
			template.variableFields.Add(new Field("Initial Value", string.Empty, FieldType.Text));
			template.variableFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.conversationFields.Add(new Field("Title", string.Empty, FieldType.Text));
			template.conversationFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.conversationFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.conversationFields.Add(new Field("Actor", "0", FieldType.Actor));
			template.conversationFields.Add(new Field("Conversant", "0", FieldType.Actor));
			template.dialogueEntryFields.Add(new Field("Title", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Pictures", "[]", FieldType.Files));
			template.dialogueEntryFields.Add(new Field("Description", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Actor", string.Empty, FieldType.Actor));
			template.dialogueEntryFields.Add(new Field("Conversant", string.Empty, FieldType.Actor));
			template.dialogueEntryFields.Add(new Field("Menu Text", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Dialogue Text", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Parenthetical", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Audio Files", "[]", FieldType.Files));
			template.dialogueEntryFields.Add(new Field("Video File", string.Empty, FieldType.Text));
			template.dialogueEntryFields.Add(new Field("Sequence", string.Empty, FieldType.Text));
			return template;
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x0002086C File Offset: 0x0001EA6C
		public Actor CreateActor(int id, string name, bool isPlayer)
		{
			return new Actor
			{
				fields = this.CreateFields(this.actorFields),
				id = id,
				Name = name,
				IsPlayer = isPlayer
			};
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x000208A8 File Offset: 0x0001EAA8
		public Item CreateItem(int id, string name)
		{
			return new Item
			{
				id = id,
				fields = this.CreateFields(this.itemFields),
				Name = name
			};
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x000208DC File Offset: 0x0001EADC
		public Location CreateLocation(int id, string name)
		{
			return new Location
			{
				id = id,
				fields = this.CreateFields(this.locationFields),
				Name = name
			};
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x00020910 File Offset: 0x0001EB10
		public Variable CreateVariable(int id, string name, string value)
		{
			return new Variable
			{
				fields = this.CreateFields(this.variableFields),
				id = id,
				Name = name,
				InitialValue = value
			};
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0002094C File Offset: 0x0001EB4C
		public Conversation CreateConversation(int id, string title)
		{
			return new Conversation
			{
				id = id,
				fields = this.CreateFields(this.conversationFields),
				Title = title
			};
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x00020980 File Offset: 0x0001EB80
		public DialogueEntry CreateDialogueEntry(int id, int conversationID, string title)
		{
			return new DialogueEntry
			{
				fields = this.CreateFields(this.dialogueEntryFields),
				id = id,
				conversationID = conversationID,
				Title = title
			};
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x000209BC File Offset: 0x0001EBBC
		public List<Field> CreateFields(List<Field> templateFields)
		{
			List<Field> list = new List<Field>();
			foreach (Field field in templateFields)
			{
				list.Add(new Field(field.title, field.value, field.type, field.typeString));
			}
			return list;
		}

		// Token: 0x04000D88 RID: 3464
		public bool treatItemsAsQuests = true;

		// Token: 0x04000D89 RID: 3465
		public List<Field> actorFields = new List<Field>();

		// Token: 0x04000D8A RID: 3466
		public List<Field> itemFields = new List<Field>();

		// Token: 0x04000D8B RID: 3467
		public List<Field> questFields = new List<Field>();

		// Token: 0x04000D8C RID: 3468
		public List<Field> locationFields = new List<Field>();

		// Token: 0x04000D8D RID: 3469
		public List<Field> variableFields = new List<Field>();

		// Token: 0x04000D8E RID: 3470
		public List<Field> conversationFields = new List<Field>();

		// Token: 0x04000D8F RID: 3471
		public List<Field> dialogueEntryFields = new List<Field>();

		// Token: 0x04000D90 RID: 3472
		public List<string> actorPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D91 RID: 3473
		public List<string> itemPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D92 RID: 3474
		public List<string> questPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D93 RID: 3475
		public List<string> locationPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D94 RID: 3476
		public List<string> variablePrimaryFieldTitles = new List<string>();

		// Token: 0x04000D95 RID: 3477
		public List<string> conversationPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D96 RID: 3478
		public List<string> dialogueEntryPrimaryFieldTitles = new List<string>();

		// Token: 0x04000D97 RID: 3479
		public Color npcLineColor = Color.red;

		// Token: 0x04000D98 RID: 3480
		public Color pcLineColor = Color.blue;

		// Token: 0x04000D99 RID: 3481
		public Color repeatLineColor = Color.gray;
	}
}
