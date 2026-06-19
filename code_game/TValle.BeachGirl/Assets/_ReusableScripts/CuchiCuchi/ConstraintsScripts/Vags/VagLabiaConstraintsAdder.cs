using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags
{
	// Token: 0x02000127 RID: 295
	public class VagLabiaConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CBF RID: 3263 RVA: 0x0002BB29 File Offset: 0x00029D29
		protected override void OnInit()
		{
			this.AddOfInner();
			this.AddOfOutter();
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0002BB38 File Offset: 0x00029D38
		private void AddOfOutter()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string stretchvagLipOut_L = instance.STRETCHVagLipOut_L;
			string stretchvagLipOut_L_ = instance.STRETCHVagLipOut_L_001;
			string stretchvagLipOut_L_2 = instance.STRETCHVagLipOut_L_002;
			string stretchvagLipOut_L_3 = instance.STRETCHVagLipOut_L_003;
			string stretchvagLipOut_L_4 = instance.STRETCHVagLipOut_L_004;
			string stretchvagLipOut_L_5 = instance.STRETCHVagLipOut_L_005;
			string stretchvagLipOut_L_6 = instance.STRETCHVagLipOut_L_006;
			string vagLip_L = instance.VagLip_L;
			string vagLip_L_ = instance.VagLip_L_001;
			string vagLip_L_2 = instance.VagLip_L_002;
			string vagLip_L_3 = instance.VagLip_L_003;
			string vagLip_L_4 = instance.VagLip_L_004;
			string vagLip_L_5 = instance.VagLip_L_005;
			string vagLip_L_6 = instance.VagLip_L_006;
			string stretchvagLipOut_R = instance.STRETCHVagLipOut_R;
			string stretchvagLipOut_R_ = instance.STRETCHVagLipOut_R_001;
			string stretchvagLipOut_R_2 = instance.STRETCHVagLipOut_R_002;
			string stretchvagLipOut_R_3 = instance.STRETCHVagLipOut_R_003;
			string stretchvagLipOut_R_4 = instance.STRETCHVagLipOut_R_004;
			string stretchvagLipOut_R_5 = instance.STRETCHVagLipOut_R_005;
			string stretchvagLipOut_R_6 = instance.STRETCHVagLipOut_R_006;
			string vagLip_R = instance.VagLip_R;
			string vagLip_R_ = instance.VagLip_R_001;
			string vagLip_R_2 = instance.VagLip_R_002;
			string vagLip_R_3 = instance.VagLip_R_003;
			string vagLip_R_4 = instance.VagLip_R_004;
			string vagLip_R_5 = instance.VagLip_R_005;
			string vagLip_R_6 = instance.VagLip_R_006;
			this.CreateAndInitConstraint(ref this.outter_000_l, stretchvagLipOut_L, vagLip_L, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_001_l, stretchvagLipOut_L_, vagLip_L_, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_002_l, stretchvagLipOut_L_2, vagLip_L_2, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_003_l, stretchvagLipOut_L_3, vagLip_L_3, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_004_l, stretchvagLipOut_L_4, vagLip_L_4, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_005_l, stretchvagLipOut_L_5, vagLip_L_5, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_006_l, stretchvagLipOut_L_6, vagLip_L_6, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_000_r, stretchvagLipOut_R, vagLip_R, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_001_r, stretchvagLipOut_R_, vagLip_R_, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_002_r, stretchvagLipOut_R_2, vagLip_R_2, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_003_r, stretchvagLipOut_R_3, vagLip_R_3, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_004_r, stretchvagLipOut_R_4, vagLip_R_4, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_005_r, stretchvagLipOut_R_5, vagLip_R_5, this.exteriorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.outter_006_r, stretchvagLipOut_R_6, vagLip_R_6, this.exteriorConfigiracion, this.dampedTrackConfig);
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0002BDAC File Offset: 0x00029FAC
		private void AddOfInner()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string defvagLip_L = instance.DEFVagLip_L;
			string defvagLip_L_ = instance.DEFVagLip_L_001;
			string defvagLip_L_2 = instance.DEFVagLip_L_002;
			string defvagLip_L_3 = instance.DEFVagLip_L_003;
			string defvagLip_L_4 = instance.DEFVagLip_L_004;
			string defvagLip_L_5 = instance.DEFVagLip_L_005;
			string defvagLip_L_6 = instance.DEFVagLip_L_006;
			string vagLip_L_ = instance.VagLip_L_001;
			string vagLip_L_2 = instance.VagLip_L_002;
			string vagLip_L_3 = instance.VagLip_L_003;
			string vagLip_L_4 = instance.VagLip_L_004;
			string vagLip_L_5 = instance.VagLip_L_005;
			string vagLip_L_6 = instance.VagLip_L_006;
			string vagLip_B = instance.VagLip_B;
			string defvagLip_R = instance.DEFVagLip_R;
			string defvagLip_R_ = instance.DEFVagLip_R_001;
			string defvagLip_R_2 = instance.DEFVagLip_R_002;
			string defvagLip_R_3 = instance.DEFVagLip_R_003;
			string defvagLip_R_4 = instance.DEFVagLip_R_004;
			string defvagLip_R_5 = instance.DEFVagLip_R_005;
			string defvagLip_R_6 = instance.DEFVagLip_R_006;
			string vagLip_R_ = instance.VagLip_R_001;
			string vagLip_R_2 = instance.VagLip_R_002;
			string vagLip_R_3 = instance.VagLip_R_003;
			string vagLip_R_4 = instance.VagLip_R_004;
			string vagLip_R_5 = instance.VagLip_R_005;
			string vagLip_R_6 = instance.VagLip_R_006;
			string vagLip_B2 = instance.VagLip_B;
			this.CreateAndInitConstraint(ref this.inner_000_l, defvagLip_L, vagLip_L_, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_l, defvagLip_L_, vagLip_L_2, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_l, defvagLip_L_2, vagLip_L_3, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_l, defvagLip_L_3, vagLip_L_4, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_004_l, defvagLip_L_4, vagLip_L_5, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_005_l, defvagLip_L_5, vagLip_L_6, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_006_l, defvagLip_L_6, vagLip_B, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_000_r, defvagLip_R, vagLip_R_, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_001_r, defvagLip_R_, vagLip_R_2, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_002_r, defvagLip_R_2, vagLip_R_3, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_003_r, defvagLip_R_3, vagLip_R_4, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_004_r, defvagLip_R_4, vagLip_R_5, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_005_r, defvagLip_R_5, vagLip_R_6, this.interiorConfigiracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.inner_006_r, defvagLip_R_6, vagLip_B2, this.interiorConfigiracion, this.dampedTrackConfig);
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0002C01D File Offset: 0x0002A21D
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

		// Token: 0x0400070D RID: 1805
		public StretchToPhysicsUserForSkeleton inner_000_l;

		// Token: 0x0400070E RID: 1806
		public StretchToPhysicsUserForSkeleton inner_001_l;

		// Token: 0x0400070F RID: 1807
		public StretchToPhysicsUserForSkeleton inner_002_l;

		// Token: 0x04000710 RID: 1808
		public StretchToPhysicsUserForSkeleton inner_003_l;

		// Token: 0x04000711 RID: 1809
		public StretchToPhysicsUserForSkeleton inner_004_l;

		// Token: 0x04000712 RID: 1810
		public StretchToPhysicsUserForSkeleton inner_005_l;

		// Token: 0x04000713 RID: 1811
		public StretchToPhysicsUserForSkeleton inner_006_l;

		// Token: 0x04000714 RID: 1812
		public StretchToPhysicsUserForSkeleton inner_000_r;

		// Token: 0x04000715 RID: 1813
		public StretchToPhysicsUserForSkeleton inner_001_r;

		// Token: 0x04000716 RID: 1814
		public StretchToPhysicsUserForSkeleton inner_002_r;

		// Token: 0x04000717 RID: 1815
		public StretchToPhysicsUserForSkeleton inner_003_r;

		// Token: 0x04000718 RID: 1816
		public StretchToPhysicsUserForSkeleton inner_004_r;

		// Token: 0x04000719 RID: 1817
		public StretchToPhysicsUserForSkeleton inner_005_r;

		// Token: 0x0400071A RID: 1818
		public StretchToPhysicsUserForSkeleton inner_006_r;

		// Token: 0x0400071B RID: 1819
		public StretchToPhysicsUserForSkeleton outter_000_l;

		// Token: 0x0400071C RID: 1820
		public StretchToPhysicsUserForSkeleton outter_001_l;

		// Token: 0x0400071D RID: 1821
		public StretchToPhysicsUserForSkeleton outter_002_l;

		// Token: 0x0400071E RID: 1822
		public StretchToPhysicsUserForSkeleton outter_003_l;

		// Token: 0x0400071F RID: 1823
		public StretchToPhysicsUserForSkeleton outter_004_l;

		// Token: 0x04000720 RID: 1824
		public StretchToPhysicsUserForSkeleton outter_005_l;

		// Token: 0x04000721 RID: 1825
		public StretchToPhysicsUserForSkeleton outter_006_l;

		// Token: 0x04000722 RID: 1826
		public StretchToPhysicsUserForSkeleton outter_000_r;

		// Token: 0x04000723 RID: 1827
		public StretchToPhysicsUserForSkeleton outter_001_r;

		// Token: 0x04000724 RID: 1828
		public StretchToPhysicsUserForSkeleton outter_002_r;

		// Token: 0x04000725 RID: 1829
		public StretchToPhysicsUserForSkeleton outter_003_r;

		// Token: 0x04000726 RID: 1830
		public StretchToPhysicsUserForSkeleton outter_004_r;

		// Token: 0x04000727 RID: 1831
		public StretchToPhysicsUserForSkeleton outter_005_r;

		// Token: 0x04000728 RID: 1832
		public StretchToPhysicsUserForSkeleton outter_006_r;

		// Token: 0x04000729 RID: 1833
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x0400072A RID: 1834
		public StretchToConfig exteriorConfigiracion = new StretchToConfig
		{
			volumeVariation = 0.25f,
			upwardAxis = Vector3.up
		};

		// Token: 0x0400072B RID: 1835
		public StretchToConfig interiorConfigiracion = new StretchToConfig
		{
			upwardAxis = Vector3.up
		};

		// Token: 0x0400072C RID: 1836
		private Transform m_vagRoot;
	}
}
