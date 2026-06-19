using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	public class Field
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x00008628 File Offset: 0x00006828
		public Field()
		{
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000863C File Offset: 0x0000683C
		public Field(Field chatMapperField)
		{
			this.Assign(chatMapperField);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008658 File Offset: 0x00006858
		public Field(string title, string value, FieldType type)
		{
			this.title = title;
			this.value = ((!Field.filenameFields.Contains(title) || value == null) ? value : value.Replace('\\', '/'));
			this.type = type;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000086B0 File Offset: 0x000068B0
		public Field(string title, string value, FieldType type, string typeString)
		{
			this.title = title;
			this.value = ((!Field.filenameFields.Contains(title) || value == null) ? value : value.Replace('\\', '/'));
			this.type = type;
			this.typeString = typeString;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00008710 File Offset: 0x00006910
		public Field(Field sourceField)
		{
			this.title = sourceField.title;
			this.value = sourceField.value;
			this.type = sourceField.type;
			this.typeString = sourceField.typeString;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000087BC File Offset: 0x000069BC
		public void Assign(Field chatMapperField)
		{
			if (chatMapperField != null)
			{
				this.title = chatMapperField.Title;
				this.value = ((!Field.filenameFields.Contains(this.title) || chatMapperField.Value == null) ? chatMapperField.Value : chatMapperField.Value.Replace('\\', '/'));
				this.type = Field.StringToFieldType(chatMapperField.Type);
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000882C File Offset: 0x00006A2C
		public static FieldType StringToFieldType(string chatMapperType)
		{
			if (string.Equals(chatMapperType, "Text"))
			{
				return FieldType.Text;
			}
			if (string.Equals(chatMapperType, "Number"))
			{
				return FieldType.Number;
			}
			if (string.Equals(chatMapperType, "Boolean"))
			{
				return FieldType.Boolean;
			}
			if (string.Equals(chatMapperType, "Files"))
			{
				return FieldType.Files;
			}
			if (string.Equals(chatMapperType, "Localization"))
			{
				return FieldType.Localization;
			}
			if (string.Equals(chatMapperType, "Actor"))
			{
				return FieldType.Actor;
			}
			if (string.Equals(chatMapperType, "Item"))
			{
				return FieldType.Item;
			}
			if (string.Equals(chatMapperType, "Location"))
			{
				return FieldType.Location;
			}
			if (string.Equals(chatMapperType, "Multiline"))
			{
				return FieldType.Text;
			}
			if (DialogueDebug.LogWarnings)
			{
				Debug.LogError(string.Format("{0}: Unrecognized Chat Mapper type: {1}", new object[] { "Dialogue System", chatMapperType }));
			}
			return FieldType.Text;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00008908 File Offset: 0x00006B08
		public static List<Field> CreateListFromChatMapperFields(List<Field> chatMapperFields)
		{
			List<Field> list = new List<Field>();
			if (chatMapperFields != null)
			{
				foreach (Field field in chatMapperFields)
				{
					list.Add(new Field(field));
				}
			}
			return list;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000897C File Offset: 0x00006B7C
		public static List<Field> CopyFields(List<Field> sourceFields)
		{
			List<Field> list = new List<Field>();
			foreach (Field field in sourceFields)
			{
				list.Add(new Field(field));
			}
			return list;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000089EC File Offset: 0x00006BEC
		public static bool FieldExists(List<Field> fields, string title)
		{
			return Field.Lookup(fields, title) != null;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000089FC File Offset: 0x00006BFC
		public static Field Lookup(List<Field> fields, string title)
		{
			return (fields != null) ? fields.Find((Field f) => string.Equals(f.title, title)) : null;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00008A34 File Offset: 0x00006C34
		public static string LookupValue(List<Field> fields, string title)
		{
			Field field = Field.Lookup(fields, title);
			return (field != null) ? field.value : null;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00008A5C File Offset: 0x00006C5C
		public static string LookupLocalizedValue(List<Field> fields, string title)
		{
			if (Localization.IsDefaultLanguage)
			{
				return Field.LookupValue(fields, title);
			}
			string text = Field.LookupValue(fields, title + " " + Localization.Language);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			text = Field.LookupValue(fields, title + "_" + Localization.Language);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			return Field.LookupValue(fields, title);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00008ACC File Offset: 0x00006CCC
		public static int LookupInt(List<Field> fields, string title)
		{
			return Tools.StringToInt(Field.LookupValue(fields, title));
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00008ADC File Offset: 0x00006CDC
		public static float LookupFloat(List<Field> fields, string title)
		{
			return Tools.StringToFloat(Field.LookupValue(fields, title));
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00008AEC File Offset: 0x00006CEC
		public static bool LookupBool(List<Field> fields, string title)
		{
			return Tools.StringToBool(Field.LookupValue(fields, title));
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00008AFC File Offset: 0x00006CFC
		public static void SetValue(List<Field> fields, string title, string value, FieldType type)
		{
			Field field = Field.Lookup(fields, title);
			if (field != null)
			{
				field.value = value;
				field.type = type;
			}
			else
			{
				fields.Add(new Field(title, value, type));
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00008B38 File Offset: 0x00006D38
		public static void SetValue(List<Field> fields, string title, string value)
		{
			Field.SetValue(fields, title, value, FieldType.Text);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00008B44 File Offset: 0x00006D44
		public static void SetValue(List<Field> fields, string title, float value)
		{
			Field.SetValue(fields, title, value.ToString(), FieldType.Number);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00008B58 File Offset: 0x00006D58
		public static void SetValue(List<Field> fields, string title, int value)
		{
			Field.SetValue(fields, title, value.ToString(), FieldType.Number);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00008B6C File Offset: 0x00006D6C
		public static void SetValue(List<Field> fields, string title, bool value)
		{
			Field.SetValue(fields, title, value.ToString(), FieldType.Boolean);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00008B80 File Offset: 0x00006D80
		public static bool IsFieldAssigned(List<Field> fields, string title)
		{
			return Field.AssignedField(fields, title) != null;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00008B90 File Offset: 0x00006D90
		public static Field AssignedField(List<Field> fields, string title)
		{
			Field field = Field.Lookup(fields, title);
			return (field == null || string.IsNullOrEmpty(field.value)) ? null : field;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00008BC4 File Offset: 0x00006DC4
		public static string FieldValue(Field field)
		{
			return (field == null) ? null : field.value;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public static string LocalizedTitle(string title)
		{
			return (!Localization.IsDefaultLanguage) ? string.Format("{0} {1}", new object[]
			{
				title,
				Localization.Language
			}) : title;
		}

		// Token: 0x040000C3 RID: 195
		public string title;

		// Token: 0x040000C4 RID: 196
		public string value;

		// Token: 0x040000C5 RID: 197
		public FieldType type;

		// Token: 0x040000C6 RID: 198
		public string typeString = string.Empty;

		// Token: 0x040000C7 RID: 199
		private static readonly List<string> filenameFields = new List<string> { "Pictures", "Texture Files", "Model Files", "Audio Files", "Lipsync Files", "Animation Files" };
	}
}
