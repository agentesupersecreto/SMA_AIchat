using System;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200002D RID: 45
	public class SequencerCommandEreccion : SequencerCommand
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x000092EC File Offset: 0x000074EC
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(1, true);
				Penis penis;
				if (parameterAsBool)
				{
					penis = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					penis = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (penis == null)
				{
					Debug.LogError("Penis no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
					penis.SetErectionTarget(parameterAsFloat);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00009388 File Offset: 0x00007588
		public void Update()
		{
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000938A File Offset: 0x0000758A
		public void OnDestroy()
		{
		}
	}
}
