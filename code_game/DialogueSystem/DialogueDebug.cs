using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000255 RID: 597
	public static class DialogueDebug
	{
		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x06001A14 RID: 6676 RVA: 0x0002C268 File Offset: 0x0002A468
		// (set) Token: 0x06001A15 RID: 6677 RVA: 0x0002C270 File Offset: 0x0002A470
		public static DialogueDebug.DebugLevel Level { get; set; } = DialogueDebug.DebugLevel.Warning;

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06001A16 RID: 6678 RVA: 0x0002C278 File Offset: 0x0002A478
		public static bool LogInfo
		{
			get
			{
				return DialogueDebug.Level >= DialogueDebug.DebugLevel.Info && Debug.isDebugBuild;
			}
		}

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06001A17 RID: 6679 RVA: 0x0002C290 File Offset: 0x0002A490
		public static bool LogWarnings
		{
			get
			{
				return DialogueDebug.Level >= DialogueDebug.DebugLevel.Warning && Debug.isDebugBuild;
			}
		}

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x0002C2A8 File Offset: 0x0002A4A8
		public static bool LogErrors
		{
			get
			{
				return DialogueDebug.Level >= DialogueDebug.DebugLevel.Error && Debug.isDebugBuild;
			}
		}

		// Token: 0x04000EDA RID: 3802
		public const string Prefix = "Dialogue System";

		// Token: 0x02000256 RID: 598
		public enum DebugLevel
		{
			// Token: 0x04000EDD RID: 3805
			None,
			// Token: 0x04000EDE RID: 3806
			Error,
			// Token: 0x04000EDF RID: 3807
			Warning,
			// Token: 0x04000EE0 RID: 3808
			Info
		}
	}
}
