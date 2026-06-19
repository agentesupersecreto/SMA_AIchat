using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000223 RID: 547
	public class Response
	{
		// Token: 0x060018C5 RID: 6341 RVA: 0x00024134 File Offset: 0x00022334
		public Response(FormattedText formattedText, DialogueEntry destinationEntry, bool enabled = true)
		{
			this.formattedText = formattedText;
			this.destinationEntry = destinationEntry;
			this.enabled = enabled;
		}

		// Token: 0x04000DD3 RID: 3539
		public FormattedText formattedText;

		// Token: 0x04000DD4 RID: 3540
		public DialogueEntry destinationEntry;

		// Token: 0x04000DD5 RID: 3541
		public bool enabled;
	}
}
