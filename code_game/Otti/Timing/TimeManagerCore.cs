using System;
using System.Collections;
using UnityEngine;

namespace com.ootii.Timing
{
	// Token: 0x0200001E RID: 30
	public class TimeManagerCore : MonoBehaviour
	{
		// Token: 0x0600019D RID: 413 RVA: 0x0000A49C File Offset: 0x0000869C
		private void Awake()
		{
			Object.DontDestroyOnLoad(base.gameObject);
			TimeManager.Initialize();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000A4AE File Offset: 0x000086AE
		public IEnumerator Start()
		{
			WaitForEndOfFrame lWaitForEndOfFrame = new WaitForEndOfFrame();
			for (;;)
			{
				yield return lWaitForEndOfFrame;
				TimeManager.Update();
			}
			yield break;
		}
	}
}
