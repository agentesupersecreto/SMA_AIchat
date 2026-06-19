using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200002A RID: 42
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUILocalization")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Update Localized UI Texts")]
	public class UpdateLocalizedUITexts : MonoBehaviour
	{
		// Token: 0x06000115 RID: 277 RVA: 0x000066E4 File Offset: 0x000048E4
		private IEnumerator Start()
		{
			yield return null;
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.languagePlayerPrefsKey) && PlayerPrefs.HasKey(this.languagePlayerPrefsKey))
			{
				text = PlayerPrefs.GetString(this.languagePlayerPrefsKey);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = DialogueManager.DisplaySettings.localizationSettings.language;
			}
			this.UpdateTexts(text);
			yield break;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000066F4 File Offset: 0x000048F4
		public void UpdateTexts(string languageCode)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: Setting language to '" + languageCode + "'.", this);
			}
			DialogueManager.DisplaySettings.localizationSettings.useSystemLanguage = false;
			DialogueManager.DisplaySettings.localizationSettings.language = languageCode;
			Localization.Language = languageCode;
			if (!string.IsNullOrEmpty(this.languagePlayerPrefsKey))
			{
				PlayerPrefs.SetString(this.languagePlayerPrefsKey, languageCode);
			}
			LocalizeUIText[] array = Object.FindObjectsOfType<LocalizeUIText>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].LocalizeText();
			}
		}

		// Token: 0x040000D1 RID: 209
		public string languagePlayerPrefsKey = "Language";
	}
}
