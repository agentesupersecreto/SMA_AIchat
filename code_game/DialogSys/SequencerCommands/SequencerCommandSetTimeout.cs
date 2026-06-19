using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000055 RID: 85
	[AddComponentMenu("")]
	public class SequencerCommandSetTimeout : SequencerCommand
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000D4B8 File Offset: 0x0000B6B8
		public void Start()
		{
			float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SetTimeout({1})", "Dialogue System", parameterAsFloat));
			}
			if (DialogueManager.DisplaySettings != null && DialogueManager.DisplaySettings.inputSettings != null)
			{
				DialogueManager.DisplaySettings.inputSettings.responseTimeout = parameterAsFloat;
			}
			base.Stop();
		}
	}
}
