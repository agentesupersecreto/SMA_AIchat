using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200002F RID: 47
	public class SequencerCommandPoseToggleCurrentClicked : SequencerCommand
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x000093AC File Offset: 0x000075AC
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				Character character;
				if (parameterAsBool)
				{
					character = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				else
				{
					character = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				bool flag = DialogueLua.GetVariable("SELECTED_POSE_FORZAR_EJECUTADO").AsBool || base.GetParameterAsBool(1, false);
				int asInt = DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt;
				bool asBool = DialogueLua.GetVariable("SELECTED_POSE_TRY_USAR_TRANSICION").AsBool;
				ICambioDePoseRegistrador cambioDePoseRegistrador;
				if (parameterAsBool)
				{
					if (flag)
					{
						cambioDePoseRegistrador = base.Sequencer.Speaker.GetComponentEnRoot(true);
					}
					else
					{
						cambioDePoseRegistrador = base.Sequencer.Speaker.GetComponentEnRoot(true);
					}
				}
				else if (flag)
				{
					cambioDePoseRegistrador = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				else
				{
					cambioDePoseRegistrador = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (cambioDePoseRegistrador == null)
				{
					Debug.LogError("ICambioDePoseRegistrador no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					cambioDePoseRegistrador.IDFlag = asInt;
					cambioDePoseRegistrador.RegistrarToggle(character, true, flag ? ParteQuePuedeEstimular.manos : ParteQuePuedeEstimular.boca, flag || DialogueLua.GetVariable("SELECTED_POSE_PUEDE_EJECUTARSE").AsBool, false, null, true, asBool);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00009520 File Offset: 0x00007720
		public void Update()
		{
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00009522 File Offset: 0x00007722
		public void OnDestroy()
		{
		}
	}
}
