using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000A RID: 10
	public class ActiveConversationRecord
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003120 File Offset: 0x00001320
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003128 File Offset: 0x00001328
		public Transform Actor { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003134 File Offset: 0x00001334
		// (set) Token: 0x06000047 RID: 71 RVA: 0x0000313C File Offset: 0x0000133C
		public Transform Conversant { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003148 File Offset: 0x00001348
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00003150 File Offset: 0x00001350
		public ConversationController ConversationController { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004A RID: 74 RVA: 0x0000315C File Offset: 0x0000135C
		public ConversationModel ConversationModel
		{
			get
			{
				return (this.ConversationController == null) ? null : this.ConversationController.ConversationModel;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000317C File Offset: 0x0000137C
		public ConversationView ConversationView
		{
			get
			{
				return (this.ConversationController == null) ? null : this.ConversationController.ConversationView;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000319C File Offset: 0x0000139C
		public bool IsConversationActive
		{
			get
			{
				return this.ConversationController != null && this.ConversationController.IsActive;
			}
		}

		// Token: 0x04000020 RID: 32
		public IDialogueUI originalDialogueUI;

		// Token: 0x04000021 RID: 33
		public DisplaySettings originalDisplaySettings;

		// Token: 0x04000022 RID: 34
		public bool isOverrideUIPrefab;
	}
}
