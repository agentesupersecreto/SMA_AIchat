using System;
using Assets;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers.Abstracts;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000028 RID: 40
	public class SequencerCommandPointAtObstacle : SequencerCommand
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00008964 File Offset: 0x00006B64
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
						FingerPointAtInteraction componentInChildren2 = componentInParent.GetComponentInChildren<FingerPointAtInteraction>();
						if (!(componentInChildren2 == null))
						{
							InteraccionDeCharacter interaccionDeCharacter = componentInParent.GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerBase(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
							InteraccionCheckers component = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null).GetComponent<InteraccionCheckers>();
							InteraccionChecker[] array;
							if (component == null)
							{
								array = null;
							}
							else
							{
								Transform checkersRoot = component.checkersRoot;
								array = ((checkersRoot != null) ? checkersRoot.GetComponentsInChildren<InteraccionChecker>(true) : null);
							}
							InteraccionChecker[] array2 = array;
							if (array2 != null && array2.Length != 0)
							{
								Transform transform = null;
								Vector3 vector = Vector3.zero;
								Vector3 zero = Vector3.zero;
								bool flag = false;
								foreach (InteraccionChecker interaccionChecker in array2)
								{
									flag = flag || interaccionChecker.DoCheck(componentInParent, out transform, out zero);
								}
								if (flag)
								{
									vector = transform.InverseTransformPoint(zero);
									float parameterAsFloat = base.GetParameterAsFloat(0, 1f);
									if (parameterAsFloat == 0f)
									{
										componentInChildren2.StopPointAt();
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
										componentInChildren.Mirar(parameterAsFloat2, parameterAsFloat3, transform, lookAtType, parameterAsBool, lookAtType2, parameterAsBool2, parameterAsFloat4, num2, num, controllerPrioridadConfig, vector, true, 5f);
										componentInChildren2.StartPointAt(transform, vector, num, parameterAsFloat4, parameterAsFloat4);
									}
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

		// Token: 0x060000CD RID: 205 RVA: 0x00008B8C File Offset: 0x00006D8C
		public void Update()
		{
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00008B8E File Offset: 0x00006D8E
		public void OnDestroy()
		{
		}
	}
}
