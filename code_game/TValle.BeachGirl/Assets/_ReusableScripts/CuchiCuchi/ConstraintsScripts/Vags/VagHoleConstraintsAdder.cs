using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags
{
	// Token: 0x02000124 RID: 292
	public class VagHoleConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CAC RID: 3244 RVA: 0x0002B06C File Offset: 0x0002926C
		protected override void OnInit()
		{
			this.AddOfInner();
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x0002B074 File Offset: 0x00029274
		private void AddOfInner()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string defvagHole_L_ = instance.DEFVagHole_L_000;
			string defvagHole_L_2 = instance.DEFVagHole_L_001;
			string defvagHole_L_3 = instance.DEFVagHole_L_002;
			string defvagHole_L_4 = instance.DEFVagHole_L_003;
			string defvagHole_R_ = instance.DEFVagHole_R_000;
			string defvagHole_R_2 = instance.DEFVagHole_R_001;
			string defvagHole_R_3 = instance.DEFVagHole_R_002;
			string defvagHole_R_4 = instance.DEFVagHole_R_003;
			string vagHole_L_ = instance.VagHole_L_001;
			string vagHole_L_2 = instance.VagHole_L_002;
			string vagHole_L_3 = instance.VagHole_L_003;
			string vagHole_B = instance.VagHole_B;
			string vagHole_R_ = instance.VagHole_R_001;
			string vagHole_R_2 = instance.VagHole_R_002;
			string vagHole_R_3 = instance.VagHole_R_003;
			string vagHole_B2 = instance.VagHole_B;
			this.CreateAndInitConstraint(ref this.inner_000_l, defvagHole_L_, vagHole_L_, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_l, defvagHole_L_2, vagHole_L_2, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_l, defvagHole_L_3, vagHole_L_3, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_l, defvagHole_L_4, vagHole_B, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_000_r, defvagHole_R_, vagHole_R_, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_r, defvagHole_R_2, vagHole_R_2, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_r, defvagHole_R_3, vagHole_R_3, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_r, defvagHole_R_4, vagHole_B2, this.holeConfiguracion, this.dampedTrackConfig);
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x0002B1DD File Offset: 0x000293DD
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

		// Token: 0x040006BC RID: 1724
		public StretchToPhysicsUserForSkeleton inner_000_l;

		// Token: 0x040006BD RID: 1725
		public StretchToPhysicsUserForSkeleton inner_001_l;

		// Token: 0x040006BE RID: 1726
		public StretchToPhysicsUserForSkeleton inner_002_l;

		// Token: 0x040006BF RID: 1727
		public StretchToPhysicsUserForSkeleton inner_003_l;

		// Token: 0x040006C0 RID: 1728
		public StretchToPhysicsUserForSkeleton inner_000_r;

		// Token: 0x040006C1 RID: 1729
		public StretchToPhysicsUserForSkeleton inner_001_r;

		// Token: 0x040006C2 RID: 1730
		public StretchToPhysicsUserForSkeleton inner_002_r;

		// Token: 0x040006C3 RID: 1731
		public StretchToPhysicsUserForSkeleton inner_003_r;

		// Token: 0x040006C4 RID: 1732
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x040006C5 RID: 1733
		public StretchToConfig holeConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			volumeVariation = 0.5f
		};
	}
}
