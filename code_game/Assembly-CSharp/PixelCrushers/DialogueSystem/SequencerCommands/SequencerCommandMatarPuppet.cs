using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000030 RID: 48
	public class SequencerCommandMatarPuppet : SequencerCommand
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000952C File Offset: 0x0000772C
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				PuppetMaster puppetMaster;
				if (parameterAsBool)
				{
					puppetMaster = base.Sequencer.Speaker.GetComponentEnRoot(false);
				}
				else
				{
					puppetMaster = base.Sequencer.Listener.GetComponentEnRoot(false);
				}
				if (puppetMaster == null)
				{
					Debug.LogError("PuppetMaster no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					puppetMaster.state = PuppetMaster.State.Dead;
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000095BC File Offset: 0x000077BC
		public void Update()
		{
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000095BE File Offset: 0x000077BE
		public void OnDestroy()
		{
		}
	}
}
