using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000023 RID: 35
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Unity UI Timer")]
	public class UnityUITimer : MonoBehaviour
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0000536C File Offset: 0x0000356C
		public virtual void Awake()
		{
			this.slider = base.GetComponent<Slider>();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000537A File Offset: 0x0000357A
		public virtual void StartCountdown(float duration, Action timeoutHandler)
		{
			base.StartCoroutine(this.Countdown(duration, timeoutHandler));
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000538B File Offset: 0x0000358B
		private IEnumerator Countdown(float duration, Action timeoutHandler)
		{
			float startTime = DialogueTime.time;
			float endTime = startTime + duration;
			while (DialogueTime.time < endTime)
			{
				float num = DialogueTime.time - startTime;
				this.UpdateTimeLeft(Mathf.Clamp(1f - num / duration, 0f, 1f));
				yield return null;
			}
			if (timeoutHandler != null)
			{
				timeoutHandler();
			}
			yield break;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000053A8 File Offset: 0x000035A8
		public virtual void UpdateTimeLeft(float normalizedTimeLeft)
		{
			if (this.slider == null)
			{
				return;
			}
			this.slider.value = normalizedTimeLeft;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000053C5 File Offset: 0x000035C5
		public virtual void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x04000095 RID: 149
		private Slider slider;
	}
}
