using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C1 RID: 705
	public abstract class GUIEffect : MonoBehaviour
	{
		// Token: 0x06001D51 RID: 7505
		public abstract IEnumerator Play();

		// Token: 0x06001D52 RID: 7506 RVA: 0x000386C4 File Offset: 0x000368C4
		public virtual void Stop()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x06001D53 RID: 7507 RVA: 0x000386CC File Offset: 0x000368CC
		public void OnEnable()
		{
			if (base.enabled && this.trigger == GUIEffectTrigger.OnEnable)
			{
				base.StartCoroutine(this.Play());
			}
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x000386F4 File Offset: 0x000368F4
		public void OnDisable()
		{
			this.Stop();
		}

		// Token: 0x040010BC RID: 4284
		public GUIEffectTrigger trigger;
	}
}
