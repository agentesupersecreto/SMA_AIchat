using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000257 RID: 599
	public static class DialogueTime
	{
		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x0002C2C8 File Offset: 0x0002A4C8
		// (set) Token: 0x06001A1B RID: 6683 RVA: 0x0002C2D0 File Offset: 0x0002A4D0
		public static DialogueTime.TimeMode Mode { get; set; } = DialogueTime.TimeMode.Realtime;

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06001A1C RID: 6684 RVA: 0x0002C2D8 File Offset: 0x0002A4D8
		// (set) Token: 0x06001A1D RID: 6685 RVA: 0x0002C330 File Offset: 0x0002A530
		public static float time
		{
			get
			{
				switch (DialogueTime.Mode)
				{
				default:
					return ((!DialogueTime.m_isPaused) ? Time.realtimeSinceStartup : DialogueTime.realtimeWhenPaused) - DialogueTime.totalRealtimePaused;
				case DialogueTime.TimeMode.Gameplay:
					return Time.time;
				case DialogueTime.TimeMode.Custom:
					return DialogueTime.m_customTime;
				}
			}
			set
			{
				DialogueTime.m_customTime = value;
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06001A1E RID: 6686 RVA: 0x0002C338 File Offset: 0x0002A538
		// (set) Token: 0x06001A1F RID: 6687 RVA: 0x0002C374 File Offset: 0x0002A574
		public static bool IsPaused
		{
			get
			{
				switch (DialogueTime.Mode)
				{
				default:
					return DialogueTime.m_isPaused;
				case DialogueTime.TimeMode.Gameplay:
					return Tools.ApproximatelyZero(Time.timeScale);
				}
			}
			set
			{
				switch (DialogueTime.Mode)
				{
				case DialogueTime.TimeMode.Realtime:
					if (!DialogueTime.m_isPaused && value)
					{
						DialogueTime.realtimeWhenPaused = Time.realtimeSinceStartup;
					}
					else if (DialogueTime.m_isPaused && !value)
					{
						DialogueTime.totalRealtimePaused += Time.realtimeSinceStartup - DialogueTime.realtimeWhenPaused;
					}
					break;
				case DialogueTime.TimeMode.Gameplay:
					Time.timeScale = (float)((!DialogueTime.m_isPaused) ? 1 : 0);
					break;
				}
				DialogueTime.m_isPaused = value;
			}
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0002C410 File Offset: 0x0002A610
		public static IEnumerator WaitForSeconds(float seconds)
		{
			float start = DialogueTime.time;
			while (DialogueTime.time < start + seconds)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x04000EE1 RID: 3809
		private static float m_customTime;

		// Token: 0x04000EE2 RID: 3810
		private static bool m_isPaused;

		// Token: 0x04000EE3 RID: 3811
		private static float realtimeWhenPaused;

		// Token: 0x04000EE4 RID: 3812
		private static float totalRealtimePaused;

		// Token: 0x02000258 RID: 600
		public enum TimeMode
		{
			// Token: 0x04000EE7 RID: 3815
			Realtime,
			// Token: 0x04000EE8 RID: 3816
			Gameplay,
			// Token: 0x04000EE9 RID: 3817
			Custom
		}
	}
}
