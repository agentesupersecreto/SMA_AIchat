using System;
using Assets.Base.Bones.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.SystemasConstraints._Abstract;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Abstracts;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Implementation;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Implementation.Constraints;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Bocas
{
	// Token: 0x020000AC RID: 172
	public class LabiosJawConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x0600052C RID: 1324 RVA: 0x0001093D File Offset: 0x0000EB3D
		protected override void OnInit()
		{
			this.AddOfInner();
			this.AddOfOutter();
			Singleton<SystemaMainChildOf>.instance.completedCalled += this.Instance_completedCalled;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00010961 File Offset: 0x0000EB61
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (Singleton<SystemaMainChildOf>.IsInScene)
			{
				Singleton<SystemaMainChildOf>.instance.completedCalled -= this.Instance_completedCalled;
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00010987 File Offset: 0x0000EB87
		private void Instance_completedCalled(SystemaMainChildOf obj)
		{
			this.m_innerCopier.DoUpdate();
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00010994 File Offset: 0x0000EB94
		private void AddOfOutter()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string jawRoot = instance.JawRoot;
			string labioOutDown = instance.LabioOutDown;
			string labioOutUp_L = instance.LabioOutUp_L;
			string labioOutUp_R = instance.LabioOutUp_R;
			string labioOutDown_R = instance.LabioOutDown_R;
			string labioOutDown_L = instance.LabioOutDown_L;
			string labioOutSide_R = instance.LabioOutSide_R;
			string labioOutSide_L = instance.LabioOutSide_L;
			this.CreateAndInitConstraint(ref this.outter_Down, labioOutDown, jawRoot, this.config_outter_Down);
			this.CreateAndInitConstraint(ref this.outter_Up_R, labioOutUp_L, jawRoot, this.config_outter_Up_RL);
			this.CreateAndInitConstraint(ref this.outter_Up_L, labioOutUp_R, jawRoot, this.config_outter_Up_RL);
			this.CreateAndInitConstraint(ref this.outter_Down_R, labioOutDown_R, jawRoot, this.config_outter_Down_RL);
			this.CreateAndInitConstraint(ref this.outter_Down_L, labioOutDown_L, jawRoot, this.config_outter_Down_RL);
			this.CreateAndInitConstraint(ref this.outter_R, labioOutSide_R, jawRoot, this.config_outter_RL);
			this.CreateAndInitConstraint(ref this.outter_L, labioOutSide_L, jawRoot, this.config_outter_RL);
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00010A74 File Offset: 0x0000EC74
		private void AddOfInner()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string jawRoot = instance.JawRoot;
			string labiosEntrada = instance.LabiosEntrada;
			Transform transform = BaseConstraint.ObtenerBone(this.constrainedSkeleton, labiosEntrada);
			Transform transform2 = transform.Copy(transform.name + "_Constrained");
			this.m_innerCopier = transform.gameObject.AddComponent<TransformSmoothLocalCopier>();
			this.m_innerCopier.toCopyFrom = transform2;
			this.m_innerCopier.config.velocity = 5f;
			string labioInUp = instance.LabioInUp;
			string labioInDown = instance.LabioInDown;
			string labioInUp_L = instance.LabioInUp_L;
			string labioInUp_R = instance.LabioInUp_R;
			string labioInDown_R = instance.LabioInDown_R;
			string labioInDown_L = instance.LabioInDown_L;
			string labioInSide_R = instance.LabioInSide_R;
			string labioInSide_L = instance.LabioInSide_L;
			this.CreateAndInitConstraint(ref this.inner, transform2, labiosEntrada, jawRoot, this.config_inner);
			this.CreateAndInitConstraint(ref this.inner_Up, labioInUp, jawRoot, this.config_inner_Up);
			this.CreateAndInitConstraint(ref this.inner_Down, labioInDown, jawRoot, this.config_inner_Down);
			this.CreateAndInitConstraint(ref this.inner_Up_R, labioInUp_L, jawRoot, this.config_inner_Up_RL);
			this.CreateAndInitConstraint(ref this.inner_Up_L, labioInUp_R, jawRoot, this.config_inner_Up_RL);
			this.CreateAndInitConstraint(ref this.inner_Down_R, labioInDown_R, jawRoot, this.config_inner_Down_RL);
			this.CreateAndInitConstraint(ref this.inner_Down_L, labioInDown_L, jawRoot, this.config_inner_Down_RL);
			this.CreateAndInitConstraint(ref this.inner_R, labioInSide_R, jawRoot, this.config_inner_RL);
			this.CreateAndInitConstraint(ref this.inner_L, labioInSide_L, jawRoot, this.config_inner_RL);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00010BE6 File Offset: 0x0000EDE6
		private void CreateAndInitConstraint(ref ChildOfMainUserForSkeleton constraint, string constrained, string target, ChildOfConfig config)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<ChildOfMainUserForSkeleton>(ref constraint, constrained);
			constraint.config = config;
			constraint.Init(this.constrainedSkeleton, constrained, target);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00010C18 File Offset: 0x0000EE18
		private void CreateAndInitConstraint(ref ChildOfMainUserForSkeletonProxyBone constraint, Transform constrained, string constrainedProxy, string target, ChildOfConfig config)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<ChildOfMainUserForSkeletonProxyBone>(ref constraint, constrainedProxy);
			constraint.config = config;
			constraint.Init(this.constrainedSkeleton, constrained, constrainedProxy, target);
		}

		// Token: 0x0400031C RID: 796
		public ChildOfMainUserForSkeletonProxyBone inner;

		// Token: 0x0400031D RID: 797
		public ChildOfMainUserForSkeleton inner_Up;

		// Token: 0x0400031E RID: 798
		public ChildOfMainUserForSkeleton inner_Down;

		// Token: 0x0400031F RID: 799
		public ChildOfMainUserForSkeleton inner_Up_R;

		// Token: 0x04000320 RID: 800
		public ChildOfMainUserForSkeleton inner_Up_L;

		// Token: 0x04000321 RID: 801
		public ChildOfMainUserForSkeleton inner_Down_R;

		// Token: 0x04000322 RID: 802
		public ChildOfMainUserForSkeleton inner_Down_L;

		// Token: 0x04000323 RID: 803
		public ChildOfMainUserForSkeleton inner_R;

		// Token: 0x04000324 RID: 804
		public ChildOfMainUserForSkeleton inner_L;

		// Token: 0x04000325 RID: 805
		public ChildOfMainUserForSkeleton outter_Up;

		// Token: 0x04000326 RID: 806
		public ChildOfMainUserForSkeleton outter_Down;

		// Token: 0x04000327 RID: 807
		public ChildOfMainUserForSkeleton outter_Up_R;

		// Token: 0x04000328 RID: 808
		public ChildOfMainUserForSkeleton outter_Up_L;

		// Token: 0x04000329 RID: 809
		public ChildOfMainUserForSkeleton outter_Down_R;

		// Token: 0x0400032A RID: 810
		public ChildOfMainUserForSkeleton outter_Down_L;

		// Token: 0x0400032B RID: 811
		public ChildOfMainUserForSkeleton outter_R;

		// Token: 0x0400032C RID: 812
		public ChildOfMainUserForSkeleton outter_L;

		// Token: 0x0400032D RID: 813
		public ChildOfConfig config_inner = new ChildOfConfig
		{
			weight = 0.15f
		};

		// Token: 0x0400032E RID: 814
		public ChildOfConfig config_inner_Up = new ChildOfConfig
		{
			weight = 0.05f
		};

		// Token: 0x0400032F RID: 815
		public ChildOfConfig config_inner_Down = new ChildOfConfig
		{
			weight = 0.975f
		};

		// Token: 0x04000330 RID: 816
		public ChildOfConfig config_inner_Up_RL = new ChildOfConfig
		{
			weight = 0.125f
		};

		// Token: 0x04000331 RID: 817
		public ChildOfConfig config_inner_Down_RL = new ChildOfConfig
		{
			weight = 0.97f
		};

		// Token: 0x04000332 RID: 818
		public ChildOfConfig config_inner_RL = new ChildOfConfig
		{
			weight = 0.5f
		};

		// Token: 0x04000333 RID: 819
		public ChildOfConfig config_outter_Up = new ChildOfConfig
		{
			weight = 0f
		};

		// Token: 0x04000334 RID: 820
		public ChildOfConfig config_outter_Down = new ChildOfConfig
		{
			weight = 1f
		};

		// Token: 0x04000335 RID: 821
		public ChildOfConfig config_outter_Up_RL = new ChildOfConfig
		{
			weight = 0.25f
		};

		// Token: 0x04000336 RID: 822
		public ChildOfConfig config_outter_Down_RL = new ChildOfConfig
		{
			weight = 0.7f
		};

		// Token: 0x04000337 RID: 823
		public ChildOfConfig config_outter_RL = new ChildOfConfig
		{
			weight = 0.5f
		};

		// Token: 0x04000338 RID: 824
		private TransformSmoothLocalCopier m_innerCopier;
	}
}
