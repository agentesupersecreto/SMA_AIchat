using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000299 RID: 665
	[AddComponentMenu("Dialogue System/Trigger/Stop Conversation If Too Far")]
	public class StopConversationIfTooFar : MonoBehaviour
	{
		// Token: 0x06001BED RID: 7149 RVA: 0x00032EA4 File Offset: 0x000310A4
		private void OnConversationStart(Transform actor)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.MonitorDistance(actor));
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x00032EBC File Offset: 0x000310BC
		private void OnConversationEnd(Transform actor)
		{
			base.StopAllCoroutines();
		}

		// Token: 0x06001BEF RID: 7151 RVA: 0x00032EC4 File Offset: 0x000310C4
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x06001BF0 RID: 7152 RVA: 0x00032ECC File Offset: 0x000310CC
		private IEnumerator MonitorDistance(Transform actor)
		{
			if (actor != null)
			{
				Transform myTransform = base.transform;
				do
				{
					yield return base.StartCoroutine(DialogueTime.WaitForSeconds(this.monitorFrequency));
				}
				while (Vector3.Distance(myTransform.position, actor.position) <= this.maxDistance);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Stopping conversation. Exceeded max distance {1} between {2} and {3}", new object[] { "Dialogue System", this.maxDistance, base.name, actor.name }));
				}
				DialogueManager.StopConversation();
				yield break;
			}
			yield break;
		}

		// Token: 0x04000FCD RID: 4045
		public float maxDistance = 5f;

		// Token: 0x04000FCE RID: 4046
		public float monitorFrequency = 1f;
	}
}
