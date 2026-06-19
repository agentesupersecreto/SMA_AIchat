using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Anus
{
	// Token: 0x02000129 RID: 297
	public class AnusHoleConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CC8 RID: 3272 RVA: 0x0002C2CF File Offset: 0x0002A4CF
		protected override void OnInit()
		{
			this.AddOfInner();
			this.AddOfOutter();
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0002C2E0 File Offset: 0x0002A4E0
		private void AddOfInner()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string defanusHole_L_ = instance.DEFAnusHole_L_000;
			string defanusHole_L_2 = instance.DEFAnusHole_L_001;
			string defanusHole_L_3 = instance.DEFAnusHole_L_002;
			string defanusHole_L_4 = instance.DEFAnusHole_L_003;
			string defanusHole_R_ = instance.DEFAnusHole_R_000;
			string defanusHole_R_2 = instance.DEFAnusHole_R_001;
			string defanusHole_R_3 = instance.DEFAnusHole_R_002;
			string defanusHole_R_4 = instance.DEFAnusHole_R_003;
			string anusHole_L_ = instance.AnusHole_L_001;
			string anusHole_L_2 = instance.AnusHole_L_002;
			string anusHole_L_3 = instance.AnusHole_L_003;
			string anusHole_B = instance.AnusHole_B;
			string anusHole_R_ = instance.AnusHole_R_001;
			string anusHole_R_2 = instance.AnusHole_R_002;
			string anusHole_R_3 = instance.AnusHole_R_003;
			string anusHole_B2 = instance.AnusHole_B;
			this.CreateAndInitConstraint(ref this.inner_000_l, defanusHole_L_, anusHole_L_, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_l, defanusHole_L_2, anusHole_L_2, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_l, defanusHole_L_3, anusHole_L_3, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_l, defanusHole_L_4, anusHole_B, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_000_r, defanusHole_R_, anusHole_R_, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_r, defanusHole_R_2, anusHole_R_2, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_r, defanusHole_R_3, anusHole_R_3, this.holeConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_r, defanusHole_R_4, anusHole_B2, this.holeConfiguracion, this.dampedTrackConfig);
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0002C44C File Offset: 0x0002A64C
		private void AddOfOutter()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string stretchanusHoleOut_F = instance.STRETCHAnusHoleOut_F;
			string stretchanusHoleOut_L_ = instance.STRETCHAnusHoleOut_L_001;
			string stretchanusHoleOut_L_2 = instance.STRETCHAnusHoleOut_L_002;
			string stretchanusHoleOut_L_3 = instance.STRETCHAnusHoleOut_L_003;
			string stretchanusHoleOut_R_ = instance.STRETCHAnusHoleOut_R_001;
			string stretchanusHoleOut_R_2 = instance.STRETCHAnusHoleOut_R_002;
			string stretchanusHoleOut_R_3 = instance.STRETCHAnusHoleOut_R_003;
			string stretchanusHoleOut_B = instance.STRETCHAnusHoleOut_B;
			string anusHole_F = instance.AnusHole_F;
			string anusHole_L_ = instance.AnusHole_L_001;
			string anusHole_L_2 = instance.AnusHole_L_002;
			string anusHole_L_3 = instance.AnusHole_L_003;
			string anusHole_R_ = instance.AnusHole_R_001;
			string anusHole_R_2 = instance.AnusHole_R_002;
			string anusHole_R_3 = instance.AnusHole_R_003;
			string anusHole_B = instance.AnusHole_B;
			this.CreateAndInitConstraint(ref this.outter_f, stretchanusHoleOut_F, anusHole_F, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_001_l, stretchanusHoleOut_L_, anusHole_L_, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_002_l, stretchanusHoleOut_L_2, anusHole_L_2, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_003_l, stretchanusHoleOut_L_3, anusHole_L_3, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_001_r, stretchanusHoleOut_R_, anusHole_R_, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_002_r, stretchanusHoleOut_R_2, anusHole_R_2, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_003_r, stretchanusHoleOut_R_3, anusHole_R_3, this.holeOutterConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_b, stretchanusHoleOut_B, anusHole_B, this.holeOutterConfiguracion, this.dampedTrackConfig);
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0002C5B5 File Offset: 0x0002A7B5
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

		// Token: 0x04000737 RID: 1847
		public StretchToPhysicsUserForSkeleton inner_000_l;

		// Token: 0x04000738 RID: 1848
		public StretchToPhysicsUserForSkeleton inner_001_l;

		// Token: 0x04000739 RID: 1849
		public StretchToPhysicsUserForSkeleton inner_002_l;

		// Token: 0x0400073A RID: 1850
		public StretchToPhysicsUserForSkeleton inner_003_l;

		// Token: 0x0400073B RID: 1851
		public StretchToPhysicsUserForSkeleton inner_000_r;

		// Token: 0x0400073C RID: 1852
		public StretchToPhysicsUserForSkeleton inner_001_r;

		// Token: 0x0400073D RID: 1853
		public StretchToPhysicsUserForSkeleton inner_002_r;

		// Token: 0x0400073E RID: 1854
		public StretchToPhysicsUserForSkeleton inner_003_r;

		// Token: 0x0400073F RID: 1855
		public StretchToPhysicsUserForSkeleton outter_f;

		// Token: 0x04000740 RID: 1856
		public StretchToPhysicsUserForSkeleton outter_001_l;

		// Token: 0x04000741 RID: 1857
		public StretchToPhysicsUserForSkeleton outter_002_l;

		// Token: 0x04000742 RID: 1858
		public StretchToPhysicsUserForSkeleton outter_003_l;

		// Token: 0x04000743 RID: 1859
		public StretchToPhysicsUserForSkeleton outter_001_r;

		// Token: 0x04000744 RID: 1860
		public StretchToPhysicsUserForSkeleton outter_002_r;

		// Token: 0x04000745 RID: 1861
		public StretchToPhysicsUserForSkeleton outter_003_r;

		// Token: 0x04000746 RID: 1862
		public StretchToPhysicsUserForSkeleton outter_b;

		// Token: 0x04000747 RID: 1863
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x04000748 RID: 1864
		public StretchToConfig holeConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up
		};

		// Token: 0x04000749 RID: 1865
		public StretchToConfig holeOutterConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			positiveVolumeVariation = 0.5f,
			negativeVolumeVariation = 0.5f,
			maxXLocalScale = 5f,
			maxYLocalScale = 5f
		};
	}
}
