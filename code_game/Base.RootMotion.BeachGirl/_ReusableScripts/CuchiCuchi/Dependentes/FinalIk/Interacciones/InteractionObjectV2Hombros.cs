using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000AA RID: 170
	public sealed class InteractionObjectV2Hombros : InteractionObjectV2Base
	{
		// Token: 0x06000684 RID: 1668 RVA: 0x0001FC8A File Offset: 0x0001DE8A
		protected override void OnStartInteractionOnSystem(InteractionSystem interactionSystem)
		{
			base.OnStartInteractionOnSystem(interactionSystem);
			this.m_hombrosIKEffector = InteractionObjectV2Hombros.BuscarHombrosIKEffector(interactionSystem, this);
			if (this.m_hombrosIKEffector == null)
			{
				Debug.LogWarning("InteractionObjectV2Hombros no encontro IHombrosIKEffector");
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001FCB2 File Offset: 0x0001DEB2
		protected override void OnStopInteractionOnSystem(InteractionSystem interactionSystem)
		{
			base.OnStopInteractionOnSystem(interactionSystem);
			this.m_hombrosIKEffector = null;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001FCC4 File Offset: 0x0001DEC4
		public sealed override void Applying(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight)
		{
			try
			{
				if (effector == FullBodyBipedEffector.LeftShoulder || effector == FullBodyBipedEffector.RightShoulder)
				{
					if (this.m_hombrosIKEffector != null)
					{
						InteractionTargetTValle interactionTargetTValle;
						if (this.ContieneTargetDeHombro(effector, out interactionTargetTValle))
						{
							if (this.hombroMulti.active)
							{
								int weightCurveIndex = base.GetWeightCurveIndex(this.hombroMulti.curve);
								if (weightCurveIndex != -1)
								{
									IHombroIKEffector hombroIKEffector = this.m_hombrosIKEffector.Obtener(effector);
									float value = this.hombroMulti.GetValue(this.weightCurves[weightCurveIndex], timer, this.m_estado);
									hombroIKEffector.rotation = interactionTargetTValle.transform.rotation;
									hombroIKEffector.rotationWeight = Mathf.Lerp(0f, value, weight);
								}
								else if (!Warning.logged)
								{
									Warning.Log("InteractionObject Multiplier curve " + this.hombroMulti.curve.ToString() + "does not exist.", base.transform, false);
								}
							}
						}
					}
				}
			}
			finally
			{
				base.Applying(solver, interactionEffector, effector, target, timer, weight);
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001FDC8 File Offset: 0x0001DFC8
		private bool ContieneTargetDeHombro(FullBodyBipedEffector effector, out InteractionTargetTValle customTarget)
		{
			customTarget = null;
			bool flag;
			if (effector == FullBodyBipedEffector.LeftShoulder)
			{
				flag = true;
			}
			else
			{
				if (effector != FullBodyBipedEffector.RightShoulder)
				{
					return false;
				}
				flag = false;
			}
			for (int i = 0; i < this.m_customTargets.Length; i++)
			{
				if (flag)
				{
					if (this.m_customTargets[i].effectorType == CustomBipedEffector.hombroIzquierdo)
					{
						customTarget = this.m_customTargets[i];
						return true;
					}
				}
				else if (this.m_customTargets[i].effectorType == CustomBipedEffector.hombroDerecho)
				{
					customTarget = this.m_customTargets[i];
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001FE3C File Offset: 0x0001E03C
		private static IHombrosIKEffector BuscarHombrosIKEffector(InteractionSystem interactionSystem, InteractionObjectV2Hombros objeto)
		{
			IHombrosIKEffector hombrosIKEffector;
			try
			{
				if (interactionSystem == null)
				{
					throw new NotSupportedException("se puede hacer con el solver, pero gastaria mucho tiempo de cpu");
				}
				if (interactionSystem.ik == null)
				{
					throw new InvalidOperationException("interaction system no esta inicializado");
				}
				IHombrosIKEffector componentInChildren = interactionSystem.ik.GetComponentInChildren<IHombrosIKEffector>();
				if (componentInChildren == null)
				{
					throw new NotSupportedException("se podria buscar en root, pero es mejor q este junto al ik");
				}
				hombrosIKEffector = componentInChildren;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				hombrosIKEffector = null;
			}
			return hombrosIKEffector;
		}

		// Token: 0x04000473 RID: 1139
		[Header("Hombros Configs")]
		public InteractionObjectV2Base.MultiplicadorNormal hombroMulti;

		// Token: 0x04000474 RID: 1140
		private IHombrosIKEffector m_hombrosIKEffector;
	}
}
