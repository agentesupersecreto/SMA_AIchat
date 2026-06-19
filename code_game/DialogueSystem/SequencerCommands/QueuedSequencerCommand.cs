using System;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000232 RID: 562
	public class QueuedSequencerCommand
	{
		// Token: 0x0600192B RID: 6443 RVA: 0x00025500 File Offset: 0x00023700
		public QueuedSequencerCommand(string command, string[] parameters, float startTime, string messageToWaitFor, string endMessage, bool required)
		{
			this.command = command;
			this.parameters = parameters;
			this.startTime = startTime;
			this.messageToWaitFor = messageToWaitFor;
			this.endMessage = endMessage;
			this.required = required;
		}

		// Token: 0x04000DFE RID: 3582
		public string command;

		// Token: 0x04000DFF RID: 3583
		public string[] parameters;

		// Token: 0x04000E00 RID: 3584
		public float startTime;

		// Token: 0x04000E01 RID: 3585
		public string messageToWaitFor;

		// Token: 0x04000E02 RID: 3586
		public string endMessage;

		// Token: 0x04000E03 RID: 3587
		public bool required;
	}
}
