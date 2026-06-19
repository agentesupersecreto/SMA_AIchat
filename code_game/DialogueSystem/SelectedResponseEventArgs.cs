using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200022E RID: 558
	public class SelectedResponseEventArgs : EventArgs
	{
		// Token: 0x06001926 RID: 6438 RVA: 0x000254B8 File Offset: 0x000236B8
		public SelectedResponseEventArgs(Response response)
		{
			this.response = response;
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06001927 RID: 6439 RVA: 0x000254C8 File Offset: 0x000236C8
		public DialogueEntry DestinationEntry
		{
			get
			{
				return (this.response != null) ? this.response.destinationEntry : null;
			}
		}

		// Token: 0x04000DFA RID: 3578
		public Response response;
	}
}
