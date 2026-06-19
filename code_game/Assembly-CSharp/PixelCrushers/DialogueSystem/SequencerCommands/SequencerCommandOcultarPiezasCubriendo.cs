using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000035 RID: 53
	public class SequencerCommandOcultarPiezasCubriendo : SequencerCommand
	{
		// Token: 0x06000108 RID: 264 RVA: 0x0000A464 File Offset: 0x00008664
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(2, true);
				ConjuntoDeRopaLoader conjuntoDeRopaLoader;
				if (parameterAsBool)
				{
					conjuntoDeRopaLoader = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					conjuntoDeRopaLoader = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (conjuntoDeRopaLoader == null)
				{
					Debug.LogError("ConjuntoDeRopaLoader no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					string[] array = base.GetParameter(0, string.Empty).Replace(" ", "").Split('|', StringSplitOptions.None);
					RopaCubre ropaCubre = RopaCubre.None;
					for (int i = 0; i < array.Length; i++)
					{
						RopaCubre ropaCubre2;
						if (Enum.TryParse<RopaCubre>(array[i], out ropaCubre2))
						{
							ropaCubre |= ropaCubre2;
						}
					}
					bool parameterAsBool2 = base.GetParameterAsBool(1, false);
					conjuntoDeRopaLoader.OcultarPiezasCubriendo(ropaCubre, parameterAsBool2, null);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000A54C File Offset: 0x0000874C
		public void Update()
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000A54E File Offset: 0x0000874E
		public void OnDestroy()
		{
		}
	}
}
