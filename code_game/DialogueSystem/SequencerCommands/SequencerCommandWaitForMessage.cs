using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000247 RID: 583
	[AddComponentMenu("")]
	public class SequencerCommandWaitForMessage : SequencerCommand
	{
		// Token: 0x060019F0 RID: 6640 RVA: 0x0002B8B4 File Offset: 0x00029AB4
		public void Start()
		{
			this.requiredMessage = base.GetParameter(0, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1})", new object[] { "Dialogue System", this.requiredMessage }));
			}
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x0002B900 File Offset: 0x00029B00
		public void OnSequencerMessage(string message)
		{
			if (string.Equals(message, this.requiredMessage))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1}) received message", new object[] { "Dialogue System", this.requiredMessage }));
				}
				base.Stop();
			}
		}

		// Token: 0x04000E87 RID: 3719
		private string requiredMessage;
	}
}
