using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.Globales.Mapas;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Bocas
{
	// Token: 0x020000AE RID: 174
	public class LabiosStretchToPhysicsConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000539 RID: 1337 RVA: 0x00011124 File Offset: 0x0000F324
		protected override void OnInit()
		{
			this.AddOfInner();
			this.AddOfOutter();
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00011134 File Offset: 0x0000F334
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
			this.CreateAndInitConstraint(ref this.inner_Up_R, deflabioInUp_R, labioInUp_R, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_L, deflabioInUp_L, labioInUp_L, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_R, deflabioInDown_R, labioInDown_R, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_L, deflabioInDown_L, labioInDown_L, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_001_R, deflabioInUp_R_, labioInSide_R, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Up_001_L, deflabioInUp_L_, labioInSide_L, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_001_R, deflabioInDown_R_, labioInSide_R2, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_Down_001_L, deflabioInDown_L_, labioInSide_L2, this.interiorConfigiracion, this.dampedTrackConfig);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000112A0 File Offset: 0x0000F4A0
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
			this.CreateAndInitConstraint(ref this.outter_Up, labioOutSTREUp, labioInUp, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down, labioOutSTREDown, labioInDown, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Up_R, labioOutSTREUp_L, labioInUp_L, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Up_L, labioOutSTREUp_R, labioInUp_R, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down_R, labioOutSTREDown_R, labioInDown_R, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_Down_L, labioOutSTREDown_L, labioInDown_L, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_R, labioOutSTRESide_R, labioInSide_R, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_L, labioOutSTRESide_L, labioInSide_L, this.exteriorConfigiracion, this.dampedTrackConfig);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00011409 File Offset: 0x0000F609
		private void CreateAndInitConstraint(ref StretchToPhysicsUserForSkeleton constraint, string constrained, string target, StretchToConfig stretchToConfig, DampedTrackConfig dampedTrackConfig)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<StretchToPhysicsUserForSkeleton>(ref constraint, constrained);
			constraint.stretchToConfig = stretchToConfig;
			constraint.dampedTrackConfig = dampedTrackConfig;
			constraint.Init(this.constrainedSkeleton, constrained, target);
		}

		// Token: 0x0400034A RID: 842
		public StretchToPhysicsUserForSkeleton inner_Up_R;

		// Token: 0x0400034B RID: 843
		public StretchToPhysicsUserForSkeleton inner_Up_L;

		// Token: 0x0400034C RID: 844
		public StretchToPhysicsUserForSkeleton inner_Down_R;

		// Token: 0x0400034D RID: 845
		public StretchToPhysicsUserForSkeleton inner_Down_L;

		// Token: 0x0400034E RID: 846
		public StretchToPhysicsUserForSkeleton inner_Up_001_R;

		// Token: 0x0400034F RID: 847
		public StretchToPhysicsUserForSkeleton inner_Up_001_L;

		// Token: 0x04000350 RID: 848
		public StretchToPhysicsUserForSkeleton inner_Down_001_R;

		// Token: 0x04000351 RID: 849
		public StretchToPhysicsUserForSkeleton inner_Down_001_L;

		// Token: 0x04000352 RID: 850
		public StretchToPhysicsUserForSkeleton outter_Up;

		// Token: 0x04000353 RID: 851
		public StretchToPhysicsUserForSkeleton outter_Down;

		// Token: 0x04000354 RID: 852
		public StretchToPhysicsUserForSkeleton outter_Up_R;

		// Token: 0x04000355 RID: 853
		public StretchToPhysicsUserForSkeleton outter_Up_L;

		// Token: 0x04000356 RID: 854
		public StretchToPhysicsUserForSkeleton outter_Down_R;

		// Token: 0x04000357 RID: 855
		public StretchToPhysicsUserForSkeleton outter_Down_L;

		// Token: 0x04000358 RID: 856
		public StretchToPhysicsUserForSkeleton outter_R;

		// Token: 0x04000359 RID: 857
		public StretchToPhysicsUserForSkeleton outter_L;

		// Token: 0x0400035A RID: 858
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x0400035B RID: 859
		public StretchToConfig exteriorConfigiracion = new StretchToConfig
		{
			volumeVariation = 0.5f,
			upwardAxis = Vector3.up,
			maxScale = new float2(2f, 2f)
		};

		// Token: 0x0400035C RID: 860
		public StretchToConfig interiorConfigiracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			maxScale = new float2(3f, 3f)
		};
	}
}
