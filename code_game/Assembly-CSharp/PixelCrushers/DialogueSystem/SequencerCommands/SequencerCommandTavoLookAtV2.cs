using System;
using Assets;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200002C RID: 44
	public class SequencerCommandTavoLookAtV2 : SequencerCommand
	{
		// Token: 0x060000DC RID: 220 RVA: 0x00008FF0 File Offset: 0x000071F0
		public void Start()
		{
			try
			{
				Character character = base.Sequencer.Speaker.GetComponentInParent<Character>();
				AnimatorCharacter animatorCharacter = base.Sequencer.Listener.GetComponentInParent<AnimatorCharacter>();
				if (base.GetParameterAsBool(0, true))
				{
					character = base.Sequencer.Speaker.GetComponentInParent<Character>();
					animatorCharacter = base.Sequencer.Listener.GetComponentInParent<AnimatorCharacter>();
				}
				else
				{
					character = base.Sequencer.Listener.GetComponentInParent<Character>();
					animatorCharacter = base.Sequencer.Speaker.GetComponentInParent<AnimatorCharacter>();
				}
				if (!(character == null) && !(animatorCharacter == null))
				{
					LookAtControllerV2 componentInChildren = character.GetComponentInChildren<LookAtControllerV2>();
					if (!(componentInChildren == null))
					{
						Transform transform = animatorCharacter.cameraAtadaTransform;
						if (transform == null)
						{
							transform = animatorCharacter.bones.eyeL.transform;
						}
						if (transform == null)
						{
							transform = animatorCharacter.bones.head.transform;
						}
						if (!(transform == null))
						{
							float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
							if (parameterAsFloat == 0f)
							{
								componentInChildren.TryDejarDeMirar(transform, true);
							}
							else
							{
								float num;
								if (base.Sequencer.SubtitleEndTime < 1f)
								{
									num = parameterAsFloat;
								}
								else
								{
									num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
								}
								string parameter = base.GetParameter(2, "0");
								string parameter2 = base.GetParameter(3, "0");
								float parameterAsFloat2 = base.GetParameterAsFloat(4, 1f);
								float parameterAsFloat3 = base.GetParameterAsFloat(5, 1f);
								if (parameter == "random")
								{
									SequencerCommandTavoLookAtV2.evade = (LookAtControllerV2.LookAtType)typeof(LookAtControllerV2.LookAtType).GetEnumRandom();
								}
								else if (parameter == "randomE")
								{
									SequencerCommandTavoLookAtV2.evade = (LookAtControllerV2.LookAtType)typeof(LookAtControllerV2.LookAtType).GetEnumRandomIgnoranzoPrimero();
								}
								else if (!(parameter == "last"))
								{
									SequencerCommandTavoLookAtV2.evade = parameter.ToEnum(LookAtControllerV2.LookAtType.fijamente);
								}
								if (parameter2 == "random")
								{
									SequencerCommandTavoLookAtV2.evadeEyes = (LookAtControllerV2.LookAtType)typeof(LookAtControllerV2.LookAtType).GetEnumRandom();
								}
								else if (parameter2 == "randomE")
								{
									SequencerCommandTavoLookAtV2.evadeEyes = (LookAtControllerV2.LookAtType)typeof(LookAtControllerV2.LookAtType).GetEnumRandomIgnoranzoPrimero();
								}
								else if (!(parameter2 == "last"))
								{
									SequencerCommandTavoLookAtV2.evadeEyes = parameter2.ToEnum(LookAtControllerV2.LookAtType.fijamente);
								}
								bool parameterAsBool = base.GetParameterAsBool(6, true);
								bool parameterAsBool2 = base.GetParameterAsBool(7, true);
								float parameterAsFloat4 = base.GetParameterAsFloat(8, 0.75f);
								bool parameterAsBool3 = base.GetParameterAsBool(9, true);
								float parameterAsFloat5 = base.GetParameterAsFloat(10, 3f);
								int maxValue = int.MaxValue;
								ControllerPrioridadConfig controllerPrioridadConfig = ControllerPrioridadConfig.prioridad;
								componentInChildren.Mirar(parameterAsFloat2, parameterAsFloat3, transform, SequencerCommandTavoLookAtV2.evade, parameterAsBool, SequencerCommandTavoLookAtV2.evadeEyes, parameterAsBool2, parameterAsFloat4, maxValue, num, controllerPrioridadConfig, default(Vector3), parameterAsBool3, parameterAsFloat5);
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

		// Token: 0x060000DD RID: 221 RVA: 0x000092E0 File Offset: 0x000074E0
		public void Update()
		{
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000092E2 File Offset: 0x000074E2
		public void OnDestroy()
		{
		}

		// Token: 0x0400009D RID: 157
		private static LookAtControllerV2.LookAtType evade;

		// Token: 0x0400009E RID: 158
		private static LookAtControllerV2.LookAtType evadeEyes;
	}
}
