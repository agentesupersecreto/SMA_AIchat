using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Implementation.Constraints;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Bocas
{
	// Token: 0x020000AD RID: 173
	[RequireComponent(typeof(LabiosStretchToPhysicsConstraintsAdder))]
	public class LabiosStretchToConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x00010D51 File Offset: 0x0000EF51
		protected override void OnInit()
		{
			this.m_LabiosStretchToPhysicsConstraintsAdder = base.GetComponent<LabiosStretchToPhysicsConstraintsAdder>();
			this.AddOfInner();
			this.AddOfOutter();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00010D6C File Offset: 0x0000EF6C
		private void AddOfInner()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string deflabioInUp_R = instance.DEFLabioInUp_R;
			string deflabioInUp_L = instance.DEFLabioInUp_L;
			string deflabioInDown_R = instance.DEFLabioInDown_R;
			string deflabioInDown_L = instance.DEFLabioInDown_L;
			string deflabioInUp_R_ = instance.DEFLabioInUp_R_001;
			string deflabioInUp_L_ = instance.DEFLabioInUp_L_001;
			string deflabioInDown_R_ = instance.DEFLabioInDown_R_001;
			string deflabioInDown_L_ = instance.DEFLabioInDown_L_001;
			string labioInUp_R = instance.LabioInUp_R;
			string labioInUp_L = instance.LabioInUp_L;
			string labioInDown_R = instance.LabioInDown_R;
			string labioInDown_L = instance.LabioInDown_L;
			string labioInSide_R = instance.LabioInSide_R;
			string labioInSide_L = instance.LabioInSide_L;
			string labioInSide_R2 = instance.LabioInSide_R;
			string labioInSide_L2 = instance.LabioInSide_L;
			this.CreateAndInitConstraint(ref this.inner_Up_R, deflabioInUp_R, labioInUp_R, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_L, deflabioInUp_L, labioInUp_L, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_R, deflabioInDown_R, labioInDown_R, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_L, deflabioInDown_L, labioInDown_L, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_001_R, deflabioInUp_R_, labioInSide_R, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_001_L, deflabioInUp_L_, labioInSide_L, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_001_R, deflabioInDown_R_, labioInSide_R2, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_001_L, deflabioInDown_L_, labioInSide_L2, this.m_LabiosStretchToPhysicsConstraintsAdder.interiorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00010F28 File Offset: 0x0000F128
		private void AddOfOutter()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string labioOutSTREUp = instance.LabioOutSTREUp;
			string labioOutSTREDown = instance.LabioOutSTREDown;
			string labioOutSTREUp_L = instance.LabioOutSTREUp_L;
			string labioOutSTREUp_R = instance.LabioOutSTREUp_R;
			string labioOutSTREDown_R = instance.LabioOutSTREDown_R;
			string labioOutSTREDown_L = instance.LabioOutSTREDown_L;
			string labioOutSTRESide_R = instance.LabioOutSTRESide_R;
			string labioOutSTRESide_L = instance.LabioOutSTRESide_L;
			string labioInUp = instance.LabioInUp;
			string labioInDown = instance.LabioInDown;
			string labioInUp_L = instance.LabioInUp_L;
			string labioInUp_R = instance.LabioInUp_R;
			string labioInDown_R = instance.LabioInDown_R;
			string labioInDown_L = instance.LabioInDown_L;
			string labioInSide_R = instance.LabioInSide_R;
			string labioInSide_L = instance.LabioInSide_L;
			this.CreateAndInitConstraint(ref this.outter_Up, labioOutSTREUp, labioInUp, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down, labioOutSTREDown, labioInDown, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Up_R, labioOutSTREUp_L, labioInUp_L, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Up_L, labioOutSTREUp_R, labioInUp_R, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down_R, labioOutSTREDown_R, labioInDown_R, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down_L, labioOutSTREDown_L, labioInDown_L, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_R, labioOutSTRESide_R, labioInSide_R, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_L, labioOutSTRESide_L, labioInSide_L, this.m_LabiosStretchToPhysicsConstraintsAdder.exteriorConfigiracion, this.m_LabiosStretchToPhysicsConstraintsAdder.dampedTrackConfig);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000110E1 File Offset: 0x0000F2E1
		private void CreateAndInitConstraint(ref StretchToMainUserForSkeleton constraint, string constrained, string target, StretchToConfig stretchToConfig, DampedTrackConfig dampedTrackConfig)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<StretchToMainUserForSkeleton>(ref constraint, constrained);
			constraint.stretchToConfig = stretchToConfig;
			constraint.dampedTrackConfig = dampedTrackConfig;
			constraint.Init(this.constrainedSkeleton, constrained, target);
		}

		// Token: 0x04000339 RID: 825
		public StretchToMainUserForSkeleton inner_Up_R;

		// Token: 0x0400033A RID: 826
		public StretchToMainUserForSkeleton inner_Up_L;

		// Token: 0x0400033B RID: 827
		public StretchToMainUserForSkeleton inner_Down_R;

		// Token: 0x0400033C RID: 828
		public StretchToMainUserForSkeleton inner_Down_L;

		// Token: 0x0400033D RID: 829
		public StretchToMainUserForSkeleton inner_Up_001_R;

		// Token: 0x0400033E RID: 830
		public StretchToMainUserForSkeleton inner_Up_001_L;

		// Token: 0x0400033F RID: 831
		public StretchToMainUserForSkeleton inner_Down_001_R;

		// Token: 0x04000340 RID: 832
		public StretchToMainUserForSkeleton inner_Down_001_L;

		// Token: 0x04000341 RID: 833
		public StretchToMainUserForSkeleton outter_Up;

		// Token: 0x04000342 RID: 834
		public StretchToMainUserForSkeleton outter_Down;

		// Token: 0x04000343 RID: 835
		public StretchToMainUserForSkeleton outter_Up_R;

		// Token: 0x04000344 RID: 836
		public StretchToMainUserForSkeleton outter_Up_L;

		// Token: 0x04000345 RID: 837
		public StretchToMainUserForSkeleton outter_Down_R;

		// Token: 0x04000346 RID: 838
		public StretchToMainUserForSkeleton outter_Down_L;

		// Token: 0x04000347 RID: 839
		public StretchToMainUserForSkeleton outter_R;

		// Token: 0x04000348 RID: 840
		public StretchToMainUserForSkeleton outter_L;

		// Token: 0x04000349 RID: 841
		private LabiosStretchToPhysicsConstraintsAdder m_LabiosStretchToPhysicsConstraintsAdder;
	}
}
