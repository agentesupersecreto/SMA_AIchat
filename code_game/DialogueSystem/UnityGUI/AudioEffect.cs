using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BD RID: 701
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Audio Effect (Unity GUI)")]
	public class AudioEffect : GUIEffect
	{
		// Token: 0x06001D47 RID: 7495 RVA: 0x0003859C File Offset: 0x0003679C
		public void Awake()
		{
			this.myAudio = base.GetComponent<AudioSource>();
		}

		// Token: 0x06001D48 RID: 7496 RVA: 0x000385AC File Offset: 0x000367AC
		public override IEnumerator Play()
		{
			if (this.myAudio != null)
			{
				this.myAudio.Play();
			}
			yield return null;
			yield break;
		}

		// Token: 0x040010B3 RID: 4275
		private AudioSource myAudio;
	}
}
