using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomIKs
{
	// Token: 0x020000BD RID: 189
	public sealed class LimbIKTValle : IK
	{
		// Token: 0x06000709 RID: 1801 RVA: 0x000229AC File Offset: 0x00020BAC
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000229B4 File Offset: 0x00020BB4
		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				return;
			}
			switch (this.solver.bendModifier)
			{
			case IKSolverLimbTValle.BendModifier.Animation:
			case IKSolverLimbTValle.BendModifier.Target:
			case IKSolverLimbTValle.BendModifier.Arm:
			case IKSolverLimbTValle.BendModifier.Goal:
				break;
			case IKSolverLimbTValle.BendModifier.Parent:
			{
				IKSolverTrigonometricTValle.TrigonometricBone bone = this.solver.bone1;
				Object @object;
				if (bone == null)
				{
					@object = null;
				}
				else
				{
					Transform transform = bone.transform;
					@object = ((transform != null) ? transform.parent : null);
				}
				IKSolverTrigonometricTValle.TrigonometricBone bone2 = this.solver.bone1;
				Transform transform2 = ((bone2 != null) ? bone2.transform : null);
				IKSolverTrigonometricTValle.TrigonometricBone bone3 = this.solver.bone2;
				Transform transform3 = ((bone3 != null) ? bone3.transform : null);
				IKSolverTrigonometricTValle.TrigonometricBone bone4 = this.solver.bone3;
				Transform transform4 = ((bone4 != null) ? bone4.transform : null);
				if (@object != null && transform2 != null && transform3 != null && transform4 != null)
				{
					Vector3 vector;
					if (!this.solver.inicilizarBendNormalComoLocalDeBone2)
					{
						vector = this.solver.bendNormal.normalized;
					}
					else
					{
						vector = transform3.transform.TransformDirection(this.solver.bendNormal.normalized);
					}
					DebugExtension.DrawArrow(transform2.position, vector * 0.008f, Color.cyan);
					DebugExtension.DrawArrow(transform3.position, vector * 0.022f, Color.cyan);
					DebugExtension.DrawArrow(transform4.position, vector * 0.008f, Color.cyan);
					return;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(this.solver.bendModifier.ToString());
			}
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00022B3D File Offset: 0x00020D3D
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page7.html");
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00022B49 File Offset: 0x00020D49
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_limb_i_k.html");
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00022B55 File Offset: 0x00020D55
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00022B61 File Offset: 0x00020D61
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x040004D8 RID: 1240
		public IKSolverLimbTValle solver = new IKSolverLimbTValle();
	}
}
