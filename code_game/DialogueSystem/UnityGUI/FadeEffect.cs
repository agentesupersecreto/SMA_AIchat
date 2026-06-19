using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BF RID: 703
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Fade Effect (Unity GUI)")]
	public class FadeEffect : GUIEffect
	{
		// Token: 0x06001D4C RID: 7500 RVA: 0x00038658 File Offset: 0x00036858
		public void SetFadeDurations(float fadeInDuration, float duration, float fadeOutDuration)
		{
			this.fadeInDuration = fadeInDuration;
			this.duration = duration;
			this.fadeOutDuration = fadeOutDuration;
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x00038670 File Offset: 0x00036870
		public override IEnumerator Play()
		{
			this.control = base.GetComponent<GUIVisibleControl>();
			if (this.control == null)
			{
				yield break;
			}
			float startTime = DialogueTime.time;
			float endTime = startTime + this.fadeInDuration;
			while (DialogueTime.time < endTime)
			{
				float elapsed = DialogueTime.time - startTime;
				this.control.Alpha = elapsed / this.fadeInDuration;
				yield return null;
			}
			this.control.Alpha = 1f;
			if (Tools.ApproximatelyZero(this.fadeOutDuration))
			{
				yield break;
			}
			yield return base.StartCoroutine(DialogueTime.WaitForSeconds(this.duration));
			startTime = DialogueTime.time;
			endTime = startTime + this.fadeOutDuration;
			while (DialogueTime.time < endTime)
			{
				float elapsed2 = DialogueTime.time - startTime;
				this.control.Alpha = 1f - elapsed2 / this.fadeOutDuration;
				yield return null;
			}
			this.control.Alpha = 0f;
			yield break;
		}

		// Token: 0x040010B6 RID: 4278
		public float fadeInDuration = 0.5f;

		// Token: 0x040010B7 RID: 4279
		public float duration = 1f;

		// Token: 0x040010B8 RID: 4280
		public float fadeOutDuration = 0.5f;

		// Token: 0x040010B9 RID: 4281
		private GUIVisibleControl control;
	}
}
