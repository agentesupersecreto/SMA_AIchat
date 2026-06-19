using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000028 RID: 40
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Scrollbar Enabler")]
	public class UnityUIScrollbarEnabler : MonoBehaviour
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x0000595D File Offset: 0x00003B5D
		private void Start()
		{
			this.started = true;
			this.CheckScrollbar();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000596C File Offset: 0x00003B6C
		public void OnEnable()
		{
			if (this.started)
			{
				this.CheckScrollbar();
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000597C File Offset: 0x00003B7C
		public void OnDisable()
		{
			this.isChecking = false;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005988 File Offset: 0x00003B88
		public void CheckScrollbar()
		{
			if (this.isChecking || this.container == null || this.content == null || this.scrollbar == null)
			{
				return;
			}
			base.StartCoroutine(this.CheckScrollbarAfterUIUpdate());
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000059D5 File Offset: 0x00003BD5
		private IEnumerator CheckScrollbarAfterUIUpdate()
		{
			this.isChecking = true;
			yield return null;
			this.scrollbar.SetActive(this.content.rect.height > this.container.rect.height);
			this.isChecking = false;
			yield break;
		}

		// Token: 0x040000A4 RID: 164
		public RectTransform container;

		// Token: 0x040000A5 RID: 165
		public RectTransform content;

		// Token: 0x040000A6 RID: 166
		public GameObject scrollbar;

		// Token: 0x040000A7 RID: 167
		private bool started;

		// Token: 0x040000A8 RID: 168
		private bool isChecking;
	}
}
