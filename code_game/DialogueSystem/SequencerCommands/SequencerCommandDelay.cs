using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023E RID: 574
	[AddComponentMenu("")]
	public class SequencerCommandDelay : SequencerCommand
	{
		// Token: 0x060019CB RID: 6603 RVA: 0x0002A108 File Offset: 0x00028308
		public void Start()
		{
			float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
			this.stopTime = DialogueTime.time + parameterAsFloat;
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Delay({1})", new object[] { "Dialogue System", parameterAsFloat }));
			}
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x0002A160 File Offset: 0x00028360
		public void Update()
		{
			if (DialogueTime.time >= this.stopTime)
			{
				base.Stop();
			}
		}

		// Token: 0x04000E50 RID: 3664
		private float stopTime;
	}
}
