using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000244 RID: 580
	[AddComponentMenu("")]
	public class SequencerCommandSwitchCamera : SequencerCommand
	{
		// Token: 0x060019E4 RID: 6628 RVA: 0x0002B134 File Offset: 0x00029334
		public void Start()
		{
			Transform subject = base.GetSubject(0, null);
			Camera camera = ((!(subject != null)) ? null : subject.GetComponent<Camera>());
			if (camera != null)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: SwitchCamera({1})", new object[] { "Dialogue System", camera.name }));
				}
				base.Sequencer.SwitchCamera(camera);
			}
			else if (DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: SwitchCamera({1}): Camera not found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(0, null)
				}));
			}
			base.Stop();
		}
	}
}
