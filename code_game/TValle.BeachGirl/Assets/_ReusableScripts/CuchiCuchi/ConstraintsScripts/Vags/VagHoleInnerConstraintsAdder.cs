using System;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags
{
	// Token: 0x02000125 RID: 293
	public class VagHoleInnerConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CB0 RID: 3248 RVA: 0x0002B26C File Offset: 0x0002946C
		protected override void OnInit()
		{
			this.Add();
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0002B274 File Offset: 0x00029474
		private void Add()
		{
			this.CreateAndInitConstraint(ref this.m_vagHoleStart, this.m_vagHoleStart_Par.self, this.m_vagHoleStart_Par.other, this.childOfConfig, false);
			this.CreateAndInitConstraint(ref this.m_canalToStart, this.m_canalToStart_Par.self.name, this.m_canalToStart_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_000, this.m_canal_000_Par.self.name, this.m_canal_000_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_001, this.m_canal_001_Par.self.name, this.m_canal_001_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_002, this.m_canal_002_Par.self.name, this.m_canal_002_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_003, this.m_canal_003_Par.self.name, this.m_canal_003_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_004, this.m_canal_004_Par.self.name, this.m_canal_004_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_canal_005, this.m_canal_005_Par.self.name, this.m_canal_005_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_cervixCapsule_000, this.m_cervixCapsule_000_Par.self.name, this.m_cervixCapsule_000_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_cervixCapsule_001, this.m_cervixCapsule_001_Par.self.name, this.m_cervixCapsule_001_Par.other.name, this.stretchToConfiguracion, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_overCanal, this.m_overCanal_Par.self.name, this.m_overCanal_Par.other.name, this.dampedTrackConfig);
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0002B4D4 File Offset: 0x000296D4
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

		// Token: 0x06000CB3 RID: 3251 RVA: 0x0002B544 File Offset: 0x00029744
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

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0002B575 File Offset: 0x00029775
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

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0002B5AF File Offset: 0x000297AF
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

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0002B5EA File Offset: 0x000297EA
		private void CreateAndInitConstraint(ref DampedTrackPhysicsUserForSkeleton constraint, string constrained, string target, DampedTrackConfig dampedTrackConfig)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<DampedTrackPhysicsUserForSkeleton>(ref constraint, constrained);
			constraint.dampedTrackConfig = dampedTrackConfig;
			constraint.Init(this.constrainedSkeleton, constrained, target);
		}

		// Token: 0x040006C6 RID: 1734
		[Header("Hole data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_vagHoleStart_Par;

		// Token: 0x040006C7 RID: 1735
		[Header("Canal data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canalToStart_Par;

		// Token: 0x040006C8 RID: 1736
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_000_Par;

		// Token: 0x040006C9 RID: 1737
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_001_Par;

		// Token: 0x040006CA RID: 1738
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_002_Par;

		// Token: 0x040006CB RID: 1739
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_003_Par;

		// Token: 0x040006CC RID: 1740
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_004_Par;

		// Token: 0x040006CD RID: 1741
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_canal_005_Par;

		// Token: 0x040006CE RID: 1742
		[Header("Capsule data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_cervixCapsule_000_Par;

		// Token: 0x040006CF RID: 1743
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_cervixCapsule_001_Par;

		// Token: 0x040006D0 RID: 1744
		[Header("Over Canal data")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder.Par m_overCanal_Par;

		// Token: 0x040006D1 RID: 1745
		[Header("Hole Constraints")]
		public ChildOfPhysicsUser m_vagHoleStart;

		// Token: 0x040006D2 RID: 1746
		[Header("Canal Constraints")]
		public StretchToPhysicsUserForSkeleton m_canalToStart;

		// Token: 0x040006D3 RID: 1747
		public StretchToPhysicsUserForSkeleton m_canal_000;

		// Token: 0x040006D4 RID: 1748
		public StretchToPhysicsUserForSkeleton m_canal_001;

		// Token: 0x040006D5 RID: 1749
		public StretchToPhysicsUserForSkeleton m_canal_002;

		// Token: 0x040006D6 RID: 1750
		public StretchToPhysicsUserForSkeleton m_canal_003;

		// Token: 0x040006D7 RID: 1751
		public StretchToPhysicsUserForSkeleton m_canal_004;

		// Token: 0x040006D8 RID: 1752
		public StretchToPhysicsUserForSkeleton m_canal_005;

		// Token: 0x040006D9 RID: 1753
		[Header("Capsule Constraints")]
		public StretchToPhysicsUserForSkeleton m_cervixCapsule_000;

		// Token: 0x040006DA RID: 1754
		public StretchToPhysicsUserForSkeleton m_cervixCapsule_001;

		// Token: 0x040006DB RID: 1755
		[Header("Over Canal Constraints")]
		public DampedTrackPhysicsUserForSkeleton m_overCanal;

		// Token: 0x040006DC RID: 1756
		[Header("Configs")]
		public ChildOfConfig childOfConfig = new ChildOfConfig();

		// Token: 0x040006DD RID: 1757
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x040006DE RID: 1758
		public StretchToConfig stretchToConfiguracion = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			volumeVariation = 0f
		};

		// Token: 0x020001FF RID: 511
		[Serializable]
		public class Par
		{
			// Token: 0x04000AFD RID: 2813
			public Transform self;

			// Token: 0x04000AFE RID: 2814
			public Transform other;
		}
	}
}
