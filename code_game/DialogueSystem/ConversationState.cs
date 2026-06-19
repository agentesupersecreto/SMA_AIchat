using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000220 RID: 544
	public class ConversationState
	{
		// Token: 0x060018B2 RID: 6322 RVA: 0x00023DE0 File Offset: 0x00021FE0
		public ConversationState(Subtitle subtitle, Response[] npcResponses, Response[] pcResponses, bool isGroup = false)
		{
			this.subtitle = subtitle;
			this.npcResponses = npcResponses;
			this.pcResponses = pcResponses;
			this.IsGroup = isGroup;
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x060018B3 RID: 6323 RVA: 0x00023E08 File Offset: 0x00022008
		public bool HasNPCResponse
		{
			get
			{
				return this.npcResponses != null && this.npcResponses.Length > 0;
			}
		}

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x060018B4 RID: 6324 RVA: 0x00023E24 File Offset: 0x00022024
		public Response FirstNPCResponse
		{
			get
			{
				return (!this.HasNPCResponse) ? null : this.npcResponses[0];
			}
		}

		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x060018B5 RID: 6325 RVA: 0x00023E40 File Offset: 0x00022040
		public bool HasPCResponses
		{
			get
			{
				return this.pcResponses != null && this.pcResponses.Length > 0;
			}
		}

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x060018B6 RID: 6326 RVA: 0x00023E5C File Offset: 0x0002205C
		public bool HasPCAutoResponse
		{
			get
			{
				return this.pcResponses != null && this.pcResponses.Length == 1 && !this.pcResponses[0].formattedText.forceMenu;
			}
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x060018B7 RID: 6327 RVA: 0x00023E90 File Offset: 0x00022090
		public Response PCAutoResponse
		{
			get
			{
				return (!this.HasPCAutoResponse) ? null : this.pcResponses[0];
			}
		}

		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x060018B8 RID: 6328 RVA: 0x00023EAC File Offset: 0x000220AC
		public bool HasAnyResponses
		{
			get
			{
				return this.HasNPCResponse || this.HasPCResponses;
			}
		}

		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x060018B9 RID: 6329 RVA: 0x00023EC4 File Offset: 0x000220C4
		// (set) Token: 0x060018BA RID: 6330 RVA: 0x00023ECC File Offset: 0x000220CC
		public bool IsGroup { get; set; }

		// Token: 0x04000DCB RID: 3531
		public Subtitle subtitle;

		// Token: 0x04000DCC RID: 3532
		public Response[] npcResponses;

		// Token: 0x04000DCD RID: 3533
		public Response[] pcResponses;
	}
}
