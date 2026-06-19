using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000002 RID: 2
	public class LocalizedTextTable : ScriptableObject
	{
		// Token: 0x17000001 RID: 1
		public string this[string fieldName]
		{
			get
			{
				return this.GetText(fieldName);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002118 File Offset: 0x00000318
		public bool ContainsField(string fieldName)
		{
			return this.fields.Find((LocalizedTextTable.LocalizedTextField f) => string.Equals(f.name, fieldName)) != null;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002150 File Offset: 0x00000350
		private string GetText(string fieldName)
		{
			return this.GetTextInLanguage(fieldName, this.GetLanguageIndex());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002160 File Offset: 0x00000360
		private string GetTextInLanguage(string fieldName, int languageIndex)
		{
			if (languageIndex != -1)
			{
				foreach (LocalizedTextTable.LocalizedTextField localizedTextField in this.fields)
				{
					if (string.Equals(localizedTextField.name, fieldName))
					{
						if (languageIndex < localizedTextField.values.Count && !string.IsNullOrEmpty(localizedTextField.values[languageIndex]))
						{
							return localizedTextField.values[languageIndex];
						}
						return (!Localization.UseDefaultIfUndefined || localizedTextField.values.Count <= 0) ? string.Empty : localizedTextField.values[0];
					}
				}
			}
			return (!Localization.UseDefaultIfUndefined || languageIndex <= 0) ? string.Empty : this.GetTextInLanguage(fieldName, 0);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000226C File Offset: 0x0000046C
		private int GetLanguageIndex()
		{
			if (Localization.IsDefaultLanguage)
			{
				return 0;
			}
			for (int i = 0; i < this.languages.Count; i++)
			{
				if (string.Equals(this.languages[i], Localization.Language))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x04000001 RID: 1
		private const int LanguageNotFound = -1;

		// Token: 0x04000002 RID: 2
		public List<string> languages = new List<string>();

		// Token: 0x04000003 RID: 3
		public List<LocalizedTextTable.LocalizedTextField> fields = new List<LocalizedTextTable.LocalizedTextField>();

		// Token: 0x02000003 RID: 3
		[Serializable]
		public class LocalizedTextField
		{
			// Token: 0x04000004 RID: 4
			public string name = string.Empty;

			// Token: 0x04000005 RID: 5
			public List<string> values = new List<string>();
		}
	}
}
