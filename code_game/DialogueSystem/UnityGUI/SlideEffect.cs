using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C3 RID: 707
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Slide Effect (Unity GUI)")]
	public class SlideEffect : GUIEffect
	{
		// Token: 0x06001D56 RID: 7510 RVA: 0x00038710 File Offset: 0x00036910
		public override IEnumerator Play()
		{
			this.control = base.GetComponent<GUIControl>();
			if (this.control == null)
			{
				yield break;
			}
			this.control.visible = false;
			Rect rect = this.control.scaledRect.GetPixelRect();
			float startTime = DialogueTime.time;
			float endTime = startTime + this.duration;
			while (DialogueTime.time < endTime)
			{
				float elapsed = DialogueTime.time - startTime;
				float progress = Mathf.Clamp(elapsed / this.duration, 0f, 1f);
				switch (this.direction)
				{
				case SlideEffect.SlideDirection.FromBottom:
					this.control.Offset = new Vector2(0f, (1f - progress) * ((float)Screen.height - rect.y));
					break;
				case SlideEffect.SlideDirection.FromTop:
					this.control.Offset = new Vector2(0f, -(1f - progress) * (rect.y + rect.height));
					break;
				case SlideEffect.SlideDirection.FromLeft:
					this.control.Offset = new Vector2(-(1f - progress) * (rect.x + rect.width), 0f);
					break;
				case SlideEffect.SlideDirection.FromRight:
					this.control.Offset = new Vector2((1f - progress) * ((float)Screen.width - rect.x), 0f);
					break;
				}
				this.control.visible = true;
				this.control.Refresh();
				yield return null;
			}
			this.control.Offset = Vector2.zero;
			this.control.visible = true;
			this.control.Refresh();
			yield break;
		}

		// Token: 0x040010BF RID: 4287
		public SlideEffect.SlideDirection direction;

		// Token: 0x040010C0 RID: 4288
		public float duration = 0.3f;

		// Token: 0x040010C1 RID: 4289
		private GUIControl control;

		// Token: 0x020002C4 RID: 708
		public enum SlideDirection
		{
			// Token: 0x040010C3 RID: 4291
			FromBottom,
			// Token: 0x040010C4 RID: 4292
			FromTop,
			// Token: 0x040010C5 RID: 4293
			FromLeft,
			// Token: 0x040010C6 RID: 4294
			FromRight
		}
	}
}
