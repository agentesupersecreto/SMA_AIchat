using System;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Anus
{
	// Token: 0x020000B0 RID: 176
	public class AnusHoleInnerConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x000115B4 File Offset: 0x0000F7B4
		protected override void OnInit()
		{
			this.CreateAndInitConstraint(ref this.m_anusHoleStart, this.m_anusHoleStart_Par.self, this.m_anusHoleStart_Par.other, this.childOfConfig, false);
			this.CreateAndInitConstraint(ref this.m_Intestinal_RootToPenisEnd, this.m_Intestinal_RootToPenisEnd_Par.self.name, this.m_Intestinal_RootToPenisEnd_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_OverIntestinal_RootToPenisEnd, this.m_OverIntestinal_RootToPenisEnd_Par.self.name, this.m_OverIntestinal_RootToPenisEnd_Par.other.name, this.stretchToOverIntestinalConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_anusRootHoleStart, this.m_anusRootHoleStart_Par.self, this.m_anusRootHoleStart_Par.other, this.childOfConfig);
			this.CreateAndInitConstraint(ref this.m_anusRootToRectusRoot, this.m_anusRootToRectus_Par.self, this.m_anusRootToRectus_Par.other, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Anus_000, this.m_Anus_000_Par.self.name, this.m_Anus_000_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Anus_001, this.m_Anus_001_Par.self.name, this.m_Anus_001_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Anus_002, this.m_Anus_002_Par.self.name, this.m_Anus_002_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Anus_003, this.m_Anus_003_Par.self.name, this.m_Anus_003_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_000, this.m_Rectus_000_Par.self.name, this.m_Rectus_000_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_001, this.m_Rectus_001_Par.self.name, this.m_Rectus_001_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_002, this.m_Rectus_002_Par.self.name, this.m_Rectus_002_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_003, this.m_Rectus_003_Par.self.name, this.m_Rectus_003_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_004, this.m_Rectus_004_Par.self.name, this.m_Rectus_004_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_005, this.m_Rectus_005_Par.self.name, this.m_Rectus_005_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_006, this.m_Rectus_006_Par.self.name, this.m_Rectus_006_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Rectus_007, this.m_Rectus_007_Par.self.name, this.m_Rectus_007_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Intestinal_000, this.m_Intestinal_000_Par.self.name, this.m_Intestinal_000_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Intestinal_001, this.m_Intestinal_001_Par.self.name, this.m_Intestinal_001_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Intestinal_002, this.m_Intestinal_002_Par.self.name, this.m_Intestinal_002_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Intestinal_003, this.m_Intestinal_003_Par.self.name, this.m_Intestinal_003_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_Intestinal_004, this.m_Intestinal_004_Par.self.name, this.m_Intestinal_004_Par.other.name, this.stretchToLastIntestinoConfiguracion, this.dampedTrackConfig);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00011A68 File Offset: 0x0000FC68
		private void CreateAndInitConstraint(ref ChildOfPhysicsUser constraint, Transform constrained, Transform target, ChildOfConfig config, bool esCopier)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<ChildOfPhysicsUser>(ref constraint, constrained.name);
			constraint.config = config;
			if (esCopier)
			{
				Transform parent = constrained.parent;
				constrained.parent = target;
				constrained.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				constrained.localScale = Vector3.one;
				constrained.parent = parent;
			}
			constraint.SetReferences(constrained, target);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00011AD8 File Offset: 0x0000FCD8
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

		// Token: 0x06000544 RID: 1348 RVA: 0x00011B13 File Offset: 0x0000FD13
		private void CreateAndInitConstraint(ref ChildOfFixedUser constraint, Transform constrained, Transform target, ChildOfConfig config)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<ChildOfFixedUser>(ref constraint, constrained.name);
			constraint.config = config;
			constraint.SetReferences(constrained, target);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00011B44 File Offset: 0x0000FD44
		private void CreateAndInitConstraint(ref StretchToFixedUser constraint, Transform constrained, Transform target, StretchToConfig stretchToConfig, DampedTrackConfig dampedTrackConfig)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<StretchToFixedUser>(ref constraint, constrained.name);
			constraint.stretchToConfig = stretchToConfig;
			constraint.dampedTrackConfig = dampedTrackConfig;
			constraint.Init(constrained, target);
		}

		// Token: 0x04000360 RID: 864
		[Header("Hole data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_anusHoleStart_Par;

		// Token: 0x04000361 RID: 865
		[Header("Anus data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_anusRootHoleStart_Par;

		// Token: 0x04000362 RID: 866
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_anusRootToRectus_Par;

		// Token: 0x04000363 RID: 867
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Anus_000_Par;

		// Token: 0x04000364 RID: 868
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Anus_001_Par;

		// Token: 0x04000365 RID: 869
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Anus_002_Par;

		// Token: 0x04000366 RID: 870
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Anus_003_Par;

		// Token: 0x04000367 RID: 871
		[Header("Rectus data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_000_Par;

		// Token: 0x04000368 RID: 872
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_001_Par;

		// Token: 0x04000369 RID: 873
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_002_Par;

		// Token: 0x0400036A RID: 874
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_003_Par;

		// Token: 0x0400036B RID: 875
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_004_Par;

		// Token: 0x0400036C RID: 876
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_005_Par;

		// Token: 0x0400036D RID: 877
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_006_Par;

		// Token: 0x0400036E RID: 878
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Rectus_007_Par;

		// Token: 0x0400036F RID: 879
		[Header("Intestinal data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_RootToPenisEnd_Par;

		// Token: 0x04000370 RID: 880
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_000_Par;

		// Token: 0x04000371 RID: 881
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_001_Par;

		// Token: 0x04000372 RID: 882
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_002_Par;

		// Token: 0x04000373 RID: 883
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_003_Par;

		// Token: 0x04000374 RID: 884
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_Intestinal_004_Par;

		// Token: 0x04000375 RID: 885
		[Header("OverIntestinal data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_OverIntestinal_RootToPenisEnd_Par;

		// Token: 0x04000376 RID: 886
		[Header("Hole Constraints")]
		public ChildOfPhysicsUser m_anusHoleStart;

		// Token: 0x04000377 RID: 887
		[Header("Anus Constraints")]
		public ChildOfFixedUser m_anusRootHoleStart;

		// Token: 0x04000378 RID: 888
		public StretchToFixedUser m_anusRootToRectusRoot;

		// Token: 0x04000379 RID: 889
		public StretchToPhysicsUserForSkeleton m_Anus_000;

		// Token: 0x0400037A RID: 890
		public StretchToPhysicsUserForSkeleton m_Anus_001;

		// Token: 0x0400037B RID: 891
		public StretchToPhysicsUserForSkeleton m_Anus_002;

		// Token: 0x0400037C RID: 892
		public StretchToPhysicsUserForSkeleton m_Anus_003;

		// Token: 0x0400037D RID: 893
		[Header("Rectus Constraints")]
		public StretchToPhysicsUserForSkeleton m_Rectus_000;

		// Token: 0x0400037E RID: 894
		public StretchToPhysicsUserForSkeleton m_Rectus_001;

		// Token: 0x0400037F RID: 895
		public StretchToPhysicsUserForSkeleton m_Rectus_002;

		// Token: 0x04000380 RID: 896
		public StretchToPhysicsUserForSkeleton m_Rectus_003;

		// Token: 0x04000381 RID: 897
		public StretchToPhysicsUserForSkeleton m_Rectus_004;

		// Token: 0x04000382 RID: 898
		public StretchToPhysicsUserForSkeleton m_Rectus_005;

		// Token: 0x04000383 RID: 899
		public StretchToPhysicsUserForSkeleton m_Rectus_006;

		// Token: 0x04000384 RID: 900
		public StretchToPhysicsUserForSkeleton m_Rectus_007;

		// Token: 0x04000385 RID: 901
		[Header("Intestinal Constraints")]
		public StretchToPhysicsUserForSkeleton m_Intestinal_RootToPenisEnd;

		// Token: 0x04000386 RID: 902
		public StretchToPhysicsUserForSkeleton m_Intestinal_000;

		// Token: 0x04000387 RID: 903
		public StretchToPhysicsUserForSkeleton m_Intestinal_001;

		// Token: 0x04000388 RID: 904
		public StretchToPhysicsUserForSkeleton m_Intestinal_002;

		// Token: 0x04000389 RID: 905
		public StretchToPhysicsUserForSkeleton m_Intestinal_003;

		// Token: 0x0400038A RID: 906
		public StretchToPhysicsUserForSkeleton m_Intestinal_004;

		// Token: 0x0400038B RID: 907
		[Header("OverIntestinal Constraints")]
		public StretchToPhysicsUserForSkeleton m_OverIntestinal_RootToPenisEnd;

		// Token: 0x0400038C RID: 908
		[Header("Configs")]
		public ChildOfConfig childOfConfig = new ChildOfConfig();

		// Token: 0x0400038D RID: 909
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x0400038E RID: 910
		public StretchToConfig stretchToConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			volumeVariation = 0f
		};

		// Token: 0x0400038F RID: 911
		public StretchToConfig stretchToOverIntestinalConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			volumeVariation = 1f
		};

		// Token: 0x04000390 RID: 912
		public StretchToConfig stretchToLastIntestinoConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			volumeVariation = 0f,
			minZScale = 1f,
			maxZScale = 1f
		};
	}
}
