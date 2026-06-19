using System;
using Assets;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200002B RID: 43
	public class SequencerCommandTavoLookAtHumanBone : SequencerCommand
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00008E0C File Offset: 0x0000700C
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
						base.GetParameterAsBool(1, false);
						HumanBodyBones humanBodyBones;
						if (!Enum.TryParse<HumanBodyBones>(base.GetParameter(0, "LeftEye"), out humanBodyBones))
						{
							Debug.LogError("No se pudo convertir " + base.GetParameter(0, "") + " a humanbone", this);
						}
						else
						{
							Transform boneTransform = componentInParent2.bodyAnimator.GetBoneTransform(humanBodyBones);
							if (boneTransform == null)
							{
								Debug.LogError("No se pudo encontrar bone: " + humanBodyBones.ToString(), componentInParent2.bodyAnimator);
							}
							else
							{
								float parameterAsFloat = base.GetParameterAsFloat(2, 1f);
								if (parameterAsFloat == 0f)
								{
									componentInChildren.TryDejarDeMirar(boneTransform, true);
								}
								else
								{
									float num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
									string parameter = base.GetParameter(3, "0");
									string parameter2 = base.GetParameter(4, "0");
									float parameterAsFloat2 = base.GetParameterAsFloat(5, 1f);
									float parameterAsFloat3 = base.GetParameterAsFloat(6, 1f);
									LookAtControllerV2.LookAtType lookAtType = parameter.ToEnum(LookAtControllerV2.LookAtType.fijamente);
									LookAtControllerV2.LookAtType lookAtType2 = parameter2.ToEnum(LookAtControllerV2.LookAtType.fijamente);
									bool parameterAsBool = base.GetParameterAsBool(7, true);
									bool parameterAsBool2 = base.GetParameterAsBool(8, true);
									float parameterAsFloat4 = base.GetParameterAsFloat(9, 0.5f);
									int num2 = 100;
									ControllerPrioridadConfig controllerPrioridadConfig = ControllerPrioridadConfig.prioridad;
									componentInChildren.Mirar(parameterAsFloat2, parameterAsFloat3, boneTransform, lookAtType, parameterAsBool, lookAtType2, parameterAsBool2, parameterAsFloat4, num2, num, controllerPrioridadConfig, default(Vector3), true, 5f);
								}
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

		// Token: 0x060000D9 RID: 217 RVA: 0x00008FE4 File Offset: 0x000071E4
		public void Update()
		{
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00008FE6 File Offset: 0x000071E6
		public void OnDestroy()
		{
		}
	}
}
