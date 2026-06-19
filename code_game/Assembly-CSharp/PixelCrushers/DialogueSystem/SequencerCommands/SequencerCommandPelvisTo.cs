using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003E RID: 62
	public class SequencerCommandPelvisTo : SequencerCommand
	{
		// Token: 0x06000131 RID: 305 RVA: 0x0000B190 File Offset: 0x00009390
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(3, true);
				PelvisMovementController pelvisMovementController;
				if (parameterAsBool)
				{
					pelvisMovementController = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					pelvisMovementController = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (pelvisMovementController == null)
				{
					Debug.LogError("PelvisMovementController no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else if (pelvisMovementController == null)
				{
					Debug.LogWarning("no EXISTE pelvis en " + base.Sequencer.Listener.name);
				}
				else
				{
					float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
					float parameterAsFloat2 = base.GetParameterAsFloat(1, 0f);
					float parameterAsFloat3 = base.GetParameterAsFloat(2, 0f);
					pelvisMovementController.ControlForze(new Vector3(parameterAsFloat, parameterAsFloat2, parameterAsFloat3));
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000B27C File Offset: 0x0000947C
		public void Update()
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000B27E File Offset: 0x0000947E
		public void OnDestroy()
		{
		}
	}
}
