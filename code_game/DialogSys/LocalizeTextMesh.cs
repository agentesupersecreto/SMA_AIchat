using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003F RID: 63
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/localize_text_mesh.html")]
	[RequireComponent(typeof(TextMesh))]
	[AddComponentMenu("Dialogue System/UI/Miscellaneous/Localize Text Mesh")]
	public class LocalizeTextMesh : LocalizeUIText
	{
		// Token: 0x060001DE RID: 478 RVA: 0x00009E7C File Offset: 0x0000807C
		public override void LocalizeText()
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
			if (this.m_textMesh == null)
			{
				this.m_textMesh = base.GetComponent<TextMesh>();
				if (this.m_textMesh == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: LocalizeUILabel didn't find a TextMesh component on " + base.name + ".", this);
					}
					return;
				}
			}
			if (string.IsNullOrEmpty(this.fieldName))
			{
				this.fieldName = ((this.m_textMesh != null) ? this.m_textMesh.text : string.Empty);
			}
			if (this.m_textMesh != null)
			{
				if (!this.localizedTextTable.ContainsField(this.fieldName))
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: Localized text table '" + this.localizedTextTable.name + "' does not have a field: " + this.fieldName, this);
						return;
					}
				}
				else
				{
					this.m_textMesh.text = this.localizedTextTable[this.fieldName];
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000A032 File Offset: 0x00008232
		public override void UpdateFieldName(string newFieldName = "")
		{
			if (this.m_textMesh == null)
			{
				this.m_textMesh = base.GetComponent<TextMesh>();
			}
			this.fieldName = (string.IsNullOrEmpty(newFieldName) ? this.m_textMesh.text : newFieldName);
		}

		// Token: 0x04000163 RID: 355
		protected TextMesh m_textMesh;
	}
}
