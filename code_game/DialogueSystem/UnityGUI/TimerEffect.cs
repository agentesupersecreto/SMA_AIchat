using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C5 RID: 709
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Timer Effect (Unity GUI)")]
	public class TimerEffect : GUIEffect
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06001D58 RID: 7512 RVA: 0x00038740 File Offset: 0x00036940
		// (remove) Token: 0x06001D59 RID: 7513 RVA: 0x0003875C File Offset: 0x0003695C
		public event Action TimeoutHandler;

		// Token: 0x06001D5A RID: 7514 RVA: 0x00038778 File Offset: 0x00036978
		public override IEnumerator Play()
		{
			this.progressBar = base.GetComponent<GUIProgressBar>();
			if (this.progressBar == null)
			{
				yield break;
			}
			float startTime = DialogueTime.time;
			float endTime = startTime + this.duration;
			while (DialogueTime.time < endTime)
			{
				float elapsed = DialogueTime.time - startTime;
				this.progressBar.progress = Mathf.Clamp(1f - elapsed / this.duration, 0f, 1f);
				yield return null;
			}
			if (this.TimeoutHandler != null)
			{
				this.TimeoutHandler();
			}
			yield break;
		}

		// Token: 0x040010C7 RID: 4295
		public float duration = 5f;

		// Token: 0x040010C8 RID: 4296
		private GUIProgressBar progressBar;
	}
}
