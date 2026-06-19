using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000294 RID: 660
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Show Cursor On Conversation")]
	public class ShowCursorOnConversation : MonoBehaviour
	{
		// Token: 0x06001BDD RID: 7133 RVA: 0x00032C1C File Offset: 0x00030E1C
		public void OnConversationStart(Transform actor)
		{
			this.wasCursorVisible = Cursor.visible;
			this.savedLockState = Cursor.lockState;
			base.StartCoroutine(this.ShowCursorAfterOneFrame());
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x00032C44 File Offset: 0x00030E44
		private IEnumerator ShowCursorAfterOneFrame()
		{
			yield return null;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			yield break;
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x00032C58 File Offset: 0x00030E58
		public void OnConversationEnd(Transform actor)
		{
			Cursor.visible = this.wasCursorVisible;
			Cursor.lockState = this.savedLockState;
		}

		// Token: 0x04000FC0 RID: 4032
		private bool wasCursorVisible;

		// Token: 0x04000FC1 RID: 4033
		private CursorLockMode savedLockState;
	}
}
