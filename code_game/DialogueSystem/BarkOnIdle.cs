using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200029B RID: 667
	[AddComponentMenu("Dialogue System/Trigger/Bark On Idle")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/bark_on_idle.html")]
	public class BarkOnIdle : BarkStarter
	{
		// Token: 0x06001C09 RID: 7177 RVA: 0x00033358 File Offset: 0x00031558
		private void Start()
		{
			this.started = true;
			this.StartBarkLoop();
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x00033368 File Offset: 0x00031568
		protected override void OnEnable()
		{
			base.OnEnable();
			this.StartBarkLoop();
		}

		// Token: 0x06001C0B RID: 7179 RVA: 0x00033378 File Offset: 0x00031578
		public void StartBarkLoop()
		{
			if (!this.started)
			{
				return;
			}
			base.StopAllCoroutines();
			base.StartCoroutine(this.BarkLoop());
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x0003339C File Offset: 0x0003159C
		private IEnumerator BarkLoop()
		{
			for (;;)
			{
				yield return new WaitForSeconds(Random.Range(this.minSeconds, this.maxSeconds));
				if (base.enabled && (!DialogueManager.IsConversationActive || this.allowDuringConversations) && !DialogueTime.IsPaused)
				{
					base.TryBark(this.target);
				}
			}
			yield break;
		}

		// Token: 0x04000FD6 RID: 4054
		[Tooltip("Minimum seconds between barks.")]
		public float minSeconds = 5f;

		// Token: 0x04000FD7 RID: 4055
		[Tooltip("Maximum seconds between barks.")]
		public float maxSeconds = 10f;

		// Token: 0x04000FD8 RID: 4056
		[Tooltip("Target to whom bark is addressed. Leave unassigned to just bark into the air.")]
		public Transform target;

		// Token: 0x04000FD9 RID: 4057
		private bool started;
	}
}
