using System;
using Assets.TValle.SystemasConstraints.RunTime.FixTransformConstraints.Abstracts;
using Assets.TValle.SystemasConstraints.RunTime.FixTransformConstraints.Implementation.Constraints;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.Globales.Mapas;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Bocas
{
	// Token: 0x020000AB RID: 171
	public class LabiosFixTransfomrsConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x00010702 File Offset: 0x0000E902
		protected override void OnInit()
		{
			this.AddOfInner();
			this.AddOfOutter();
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00010710 File Offset: 0x0000E910
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
			this.CreateAndInitConstraint(ref this.inner_Up_R, deflabioInUp_R, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Up_L, deflabioInUp_L, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Down_R, deflabioInDown_R, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Down_L, deflabioInDown_L, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Up_001_R, deflabioInUp_R_, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Up_001_L, deflabioInUp_L_, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Down_001_R, deflabioInDown_R_, this.configiracion);
			this.CreateAndInitConstraint(ref this.inner_Down_001_L, deflabioInDown_L_, this.configiracion);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000107FC File Offset: 0x0000E9FC
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
			this.CreateAndInitConstraint(ref this.outter_Up, labioOutSTREUp, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_Down, labioOutSTREDown, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_Up_R, labioOutSTREUp_L, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_Up_L, labioOutSTREUp_R, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_Down_R, labioOutSTREDown_R, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_Down_L, labioOutSTREDown_L, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_R, labioOutSTRESide_R, this.configiracion);
			this.CreateAndInitConstraint(ref this.outter_L, labioOutSTRESide_L, this.configiracion);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x000108E5 File Offset: 0x0000EAE5
		private void CreateAndInitConstraint(ref FixTransformMainUserForSkeleton constraint, string constrained, FixTransformConfig config)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<FixTransformMainUserForSkeleton>(ref constraint, constrained);
			constraint.config = config;
			constraint.Init(this.constrainedSkeleton, constrained);
		}

		// Token: 0x0400030B RID: 779
		public FixTransformMainUserForSkeleton inner_Up_R;

		// Token: 0x0400030C RID: 780
		public FixTransformMainUserForSkeleton inner_Up_L;

		// Token: 0x0400030D RID: 781
		public FixTransformMainUserForSkeleton inner_Down_R;

		// Token: 0x0400030E RID: 782
		public FixTransformMainUserForSkeleton inner_Down_L;

		// Token: 0x0400030F RID: 783
		public FixTransformMainUserForSkeleton inner_Up_001_R;

		// Token: 0x04000310 RID: 784
		public FixTransformMainUserForSkeleton inner_Up_001_L;

		// Token: 0x04000311 RID: 785
		public FixTransformMainUserForSkeleton inner_Down_001_R;

		// Token: 0x04000312 RID: 786
		public FixTransformMainUserForSkeleton inner_Down_001_L;

		// Token: 0x04000313 RID: 787
		public FixTransformMainUserForSkeleton outter_Up;

		// Token: 0x04000314 RID: 788
		public FixTransformMainUserForSkeleton outter_Down;

		// Token: 0x04000315 RID: 789
		public FixTransformMainUserForSkeleton outter_Up_R;

		// Token: 0x04000316 RID: 790
		public FixTransformMainUserForSkeleton outter_Up_L;

		// Token: 0x04000317 RID: 791
		public FixTransformMainUserForSkeleton outter_Down_R;

		// Token: 0x04000318 RID: 792
		public FixTransformMainUserForSkeleton outter_Down_L;

		// Token: 0x04000319 RID: 793
		public FixTransformMainUserForSkeleton outter_R;

		// Token: 0x0400031A RID: 794
		public FixTransformMainUserForSkeleton outter_L;

		// Token: 0x0400031B RID: 795
		public FixTransformConfig configiracion = new FixTransformConfig
		{
			usarPosicion = true,
			usarRotacion = true,
			usarScala = true
		};
	}
}
