using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000024 RID: 36
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUILocalization")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Localize UI Text")]
	public class LocalizeUIText : MonoBehaviour
	{
		// Token: 0x060000DC RID: 220 RVA: 0x000053D5 File Offset: 0x000035D5
		protected virtual void Start()
		{
			this.started = true;
			this.LocalizeText();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000053E4 File Offset: 0x000035E4
		protected virtual void OnEnable()
		{
			this.LocalizeText();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000053EC File Offset: 0x000035EC
		public virtual void LocalizeText()
		{
			if (!this.started)
			{
				return;
			}
			if (string.IsNullOrEmpty(Localization.Language))
			{
				return;
			}
			if (this.localizedTextTable == null)
			{
				this.localizedTextTable = DialogueManager.DisplaySettings.localizationSettings.localizedText;
				if (this.localizedTextTable == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: No localized text table is assigned to " + base.name + " or the Dialogue Manager.", this);
					}
					return;
				}
			}
			if (!this.HasCurrentLanguage())
			{
				if (DialogueDebug.LogWarnings)
				{
					string[] array = new string[5];
					array[0] = "Dialogue SystemLocalized text table '";
					int num = 1;
					LocalizedTextTable localizedTextTable = this.localizedTextTable;
					array[num] = ((localizedTextTable != null) ? localizedTextTable.ToString() : null);
					array[2] = "' does not have a language '";
					array[3] = Localization.Language;
					array[4] = "'";
					Debug.LogWarning(string.Concat(array), this);
				}
				return;
			}
			if (this.text == null && this.dropdown == null)
			{
				this.text = base.GetComponent<Text>();
				this.dropdown = base.GetComponent<Dropdown>();
				if (this.text == null && this.dropdown == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: LocalizeUIText didn't find a Text or Dropdown component on " + base.name + ".", this);
					}
					return;
				}
			}
			if (string.IsNullOrEmpty(this.fieldName))
			{
				this.fieldName = ((this.text != null) ? this.text.text : string.Empty);
			}
			if (this.fieldNames.Count == 0 && this.dropdown != null)
			{
				this.dropdown.options.ForEach(delegate(Dropdown.OptionData opt)
				{
					this.fieldNames.Add(opt.text);
				});
			}
			if (this.text != null)
			{
				if (!this.localizedTextTable.ContainsField(this.fieldName))
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: Localized text table '" + this.localizedTextTable.name + "' does not have a field: " + this.fieldName, this);
					}
				}
				else
				{
					this.text.text = this.localizedTextTable[this.fieldName];
				}
			}
			if (this.dropdown != null)
			{
				for (int i = 0; i < this.dropdown.options.Count; i++)
				{
					if (i < this.fieldNames.Count)
					{
						this.dropdown.options[i].text = this.localizedTextTable[this.fieldNames[i]];
					}
				}
				this.dropdown.captionText.text = this.localizedTextTable[this.fieldNames[this.dropdown.value]];
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000569C File Offset: 0x0000389C
		protected virtual bool HasCurrentLanguage()
		{
			if (this.localizedTextTable == null)
			{
				return false;
			}
			using (List<string>.Enumerator enumerator = this.localizedTextTable.languages.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (string.Equals(enumerator.Current, Localization.Language))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005710 File Offset: 0x00003910
		public virtual void UpdateFieldName(string newFieldName = "")
		{
			if (this.text == null)
			{
				this.text = base.GetComponent<Text>();
			}
			this.fieldName = (string.IsNullOrEmpty(newFieldName) ? this.text.text : newFieldName);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005748 File Offset: 0x00003948
		public virtual void UpdateOptions()
		{
			this.fieldNames.Clear();
			this.LocalizeText();
		}

		// Token: 0x04000096 RID: 150
		[Tooltip("Optional; overrides the Dialogue Manager's table.")]
		public LocalizedTextTable localizedTextTable;

		// Token: 0x04000097 RID: 151
		[Tooltip("Optional; if assigned, use this instead of the Text field's value as the field lookup value.")]
		public string fieldName = string.Empty;

		// Token: 0x04000098 RID: 152
		protected Text text;

		// Token: 0x04000099 RID: 153
		protected List<string> fieldNames = new List<string>();

		// Token: 0x0400009A RID: 154
		protected bool started;

		// Token: 0x0400009B RID: 155
		protected Dropdown dropdown;
	}
}
