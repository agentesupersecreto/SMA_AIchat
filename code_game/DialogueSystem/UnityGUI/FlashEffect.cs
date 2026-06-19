using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C0 RID: 704
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Flash Effect (Unity GUI)")]
	public class FlashEffect : GUIEffect
	{
		// Token: 0x06001D4F RID: 7503 RVA: 0x000386A0 File Offset: 0x000368A0
		public override IEnumerator Play()
		{
			this.control = base.GetComponent<GUIControl>();
			if (this.control == null)
			{
				yield break;
			}
			this.control.visible = true;
			for (;;)
			{
				yield return base.StartCoroutine(DialogueTime.WaitForSeconds(this.interval));
				this.control.visible = !this.control.visible;
			}
			yield break;
		}

		// Token: 0x040010BA RID: 4282
		public float interval = 0.5f;

		// Token: 0x040010BB RID: 4283
		private GUIControl control;
	}
}
