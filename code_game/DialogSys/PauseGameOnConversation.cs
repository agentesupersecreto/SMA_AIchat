using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000041 RID: 65
	[AddComponentMenu("Dialogue System/Miscellaneous/Pause Game On Conversation")]
	public class PauseGameOnConversation : MonoBehaviour
	{
		// Token: 0x060001E4 RID: 484 RVA: 0x0000A269 File Offset: 0x00008469
		public void OnConversationStart(Transform actor)
		{
			if (!base.enabled)
			{
				return;
			}
			this.preConversationTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000A289 File Offset: 0x00008489
		public void OnConversationEnd(Transform actor)
		{
			if (!base.enabled)
			{
				return;
			}
			Time.timeScale = this.preConversationTimeScale;
		}

		// Token: 0x0400016C RID: 364
		private float preConversationTimeScale = 1f;
	}
}
