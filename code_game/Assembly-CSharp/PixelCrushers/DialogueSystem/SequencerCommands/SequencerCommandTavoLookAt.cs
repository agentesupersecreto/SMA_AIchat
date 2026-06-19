using System;
using Assets;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200002A RID: 42
	public class SequencerCommandTavoLookAt : SequencerCommand
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00008C64 File Offset: 0x00006E64
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				AnimatorCharacter componentInParent2 = base.Sequencer.Listener.GetComponentInParent<AnimatorCharacter>();
				if (!(componentInParent == null) && !(componentInParent2 == null))
				{
					LookAtControllerV2 componentInChildren = componentInParent.GetComponentInChildren<LookAtControllerV2>();
					if (!(componentInChildren == null))
					{
						Transform transform = componentInParent2.cameraAtadaTransform;
						if (transform == null)
						{
							transform = componentInParent2.bones.eyeL.transform;
						}
						if (transform == null)
						{
							transform = componentInParent2.bones.head.transform;
						}
						if (!(transform == null))
						{
							float parameterAsFloat = base.GetParameterAsFloat(0, 1f);
							if (parameterAsFloat == 0f)
							{
								componentInChildren.TryDejarDeMirar(transform, true);
							}
							else
							{
								float num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
								string parameter = base.GetParameter(1, "0");
								string parameter2 = base.GetParameter(2, "0");
								float parameterAsFloat2 = base.GetParameterAsFloat(3, 1f);
								float parameterAsFloat3 = base.GetParameterAsFloat(4, 1f);
								LookAtControllerV2.LookAtType lookAtType = parameter.ToEnum(LookAtControllerV2.LookAtType.fijamente);
								LookAtControllerV2.LookAtType lookAtType2 = parameter2.ToEnum(LookAtControllerV2.LookAtType.fijamente);
								bool parameterAsBool = base.GetParameterAsBool(5, true);
								bool parameterAsBool2 = base.GetParameterAsBool(6, true);
								float parameterAsFloat4 = base.GetParameterAsFloat(7, 0.75f);
								int num2 = 100;
								ControllerPrioridadConfig controllerPrioridadConfig = ControllerPrioridadConfig.prioridad;
								componentInChildren.Mirar(parameterAsFloat2, parameterAsFloat3, transform, lookAtType, parameterAsBool, lookAtType2, parameterAsBool2, parameterAsFloat4, num2, num, controllerPrioridadConfig, default(Vector3), true, 5f);
							}
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00008E00 File Offset: 0x00007000
		public void Update()
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00008E02 File Offset: 0x00007002
		public void OnDestroy()
		{
		}
	}
}
