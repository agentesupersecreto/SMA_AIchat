using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000027 RID: 39
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Ignore Pause Codes")]
	[DisallowMultipleComponent]
	public class UnityUIIgnorePauseCodes : MonoBehaviour
	{
		// Token: 0x060000EB RID: 235 RVA: 0x000058F4 File Offset: 0x00003AF4
		public void Awake()
		{
			this.control = base.GetComponent<Text>();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005902 File Offset: 0x00003B02
		public void Start()
		{
			this.CheckText();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000590A File Offset: 0x00003B0A
		public void OnEnable()
		{
			this.CheckText();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005912 File Offset: 0x00003B12
		public void CheckText()
		{
			if (this.control != null && this.control.text.Contains("\\"))
			{
				base.StartCoroutine(this.Clean());
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005946 File Offset: 0x00003B46
		private IEnumerator Clean()
		{
			this.control.text = UnityUITypewriterEffect.StripRPGMakerCodes(this.control.text);
			yield return null;
			this.control.text = UnityUITypewriterEffect.StripRPGMakerCodes(this.control.text);
			yield break;
		}

		// Token: 0x040000A3 RID: 163
		private Text control;
	}
}
