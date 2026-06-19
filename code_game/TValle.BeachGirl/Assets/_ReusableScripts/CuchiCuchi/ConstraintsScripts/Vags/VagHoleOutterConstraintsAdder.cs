using System;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags
{
	// Token: 0x02000126 RID: 294
	public class VagHoleOutterConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CB8 RID: 3256 RVA: 0x0002B67B File Offset: 0x0002987B
		protected override void OnInit()
		{
			this.Add();
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0002B684 File Offset: 0x00029884
		private void Add()
		{
			this.CreateAndInitConstraint(ref this.m_InternalVaginaRoot, this.m_internalsRootPar.self, this.m_internalsRootPar.other, this.childOfConfig, true);
			this.CreateAndInitConstraint(ref this.m_canal_000, this.m_canal000Par.self, this.m_canal000Par.other, this.childOfConfigCanal000, true);
			this.CreateAndInitConstraint(ref this.m_canal_001, this.m_canal001Par.self, this.m_canal001Par.other, this.childOfConfigCanal001, true);
			this.CreateAndInitConstraint(ref this.m_canal_002, this.m_canal002Par.self, this.m_canal002Par.other, this.childOfConfigCanal002, true);
			this.CreateAndInitConstraint(ref this.m_canal_003, this.m_canal003Par.self, this.m_canal003Par.other, this.childOfConfigCanal003, true);
			this.CreateAndInitConstraint(ref this.m_canal_004, this.m_canal004Par.self, this.m_canal004Par.other, this.childOfConfigCanal004, true);
			this.CreateAndInitConstraint(ref this.m_canal_005, this.m_canal005Par.self, this.m_canal005Par.other, this.childOfConfigCanal005, true);
			this.CreateAndInitConstraint(ref this.m_CervixCapsule_000, this.m_capsule000Par.self, this.m_capsule000Par.other, this.childOfConfigCapsule, true);
			this.CreateAndInitConstraint(ref this.m_CervixCapsule_001, this.m_capsule001Par.self, this.m_capsule001Par.other, this.childOfConfigCapsule, true);
			this.CreateAndInitConstraint(ref this.m_Cervix_001, this.m_cervix001Par.self, this.m_cervix001Par.other, this.childOfConfig, true);
			this.CreateAndInitConstraint(ref this.m_uterusTip, this.m_uterusTipPar.self, this.m_uterusTipPar.other, this.childOfConfig, true);
			this.CreateAndInitConstraint(ref this.m_uterus000, this.m_uterus000Par.self, this.m_uterus000Par.other, this.childOfConfigUterus, true);
			this.CreateAndInitConstraint(ref this.m_uterus001, this.m_uterus001Par.self, this.m_uterus001Par.other, this.childOfConfigUterus, true);
			this.CreateAndInitConstraint(ref this.m_uterus002, this.m_uterus002Par.self, this.m_uterus002Par.other, this.childOfConfigUterus, true);
			this.CreateAndInitConstraint(ref this.m_overCanal_000, this.m_overCanal000Par.self, this.m_overCanal000Par.other, this.childOfConfigOvercanal, true);
			this.CreateAndInitConstraint(ref this.m_overCanal_001, this.m_overCanal001Par.self, this.m_overCanal001Par.other, this.childOfConfigOvercanal, true);
			this.CreateAndInitConstraint(ref this.m_overCanal_002, this.m_overCanal002Par.self, this.m_overCanal002Par.other, this.childOfConfigOvercanal, true);
			this.CreateAndInitConstraint(ref this.m_overCanal_003, this.m_overCanal003Par.self, this.m_overCanal003Par.other, this.childOfConfigOvercanal, true);
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0002B974 File Offset: 0x00029B74
		private void CreateAndInitConstraint(ref ChildOfGuiaPhysicsUser constraint, Transform constrained, Transform target, ChildOfConfig config, bool esCopier)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<ChildOfGuiaPhysicsUser>(ref constraint, constrained.name);
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

		// Token: 0x06000CBB RID: 3259 RVA: 0x0002B9E4 File Offset: 0x00029BE4
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

		// Token: 0x06000CBC RID: 3260 RVA: 0x0002BA1E File Offset: 0x00029C1E
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

		// Token: 0x06000CBD RID: 3261 RVA: 0x0002BA59 File Offset: 0x00029C59
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

		// Token: 0x040006DF RID: 1759
		[Header("Canal data")]
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_internalsRootPar;

		// Token: 0x040006E0 RID: 1760
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal000Par;

		// Token: 0x040006E1 RID: 1761
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal001Par;

		// Token: 0x040006E2 RID: 1762
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal002Par;

		// Token: 0x040006E3 RID: 1763
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal003Par;

		// Token: 0x040006E4 RID: 1764
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal004Par;

		// Token: 0x040006E5 RID: 1765
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_canal005Par;

		// Token: 0x040006E6 RID: 1766
		[Header("Capsule data")]
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_capsule000Par;

		// Token: 0x040006E7 RID: 1767
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_capsule001Par;

		// Token: 0x040006E8 RID: 1768
		[Header("Uterus data")]
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_cervix001Par;

		// Token: 0x040006E9 RID: 1769
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_uterusTipPar;

		// Token: 0x040006EA RID: 1770
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_uterus000Par;

		// Token: 0x040006EB RID: 1771
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_uterus001Par;

		// Token: 0x040006EC RID: 1772
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_uterus002Par;

		// Token: 0x040006ED RID: 1773
		[Header("Over Canal data")]
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_overCanal000Par;

		// Token: 0x040006EE RID: 1774
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_overCanal001Par;

		// Token: 0x040006EF RID: 1775
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_overCanal002Par;

		// Token: 0x040006F0 RID: 1776
		[SerializeField]
		private VagHoleOutterConstraintsAdder.Par m_overCanal003Par;

		// Token: 0x040006F1 RID: 1777
		[Header("Hole Constraints")]
		public ChildOfGuiaPhysicsUser m_InternalVaginaRoot;

		// Token: 0x040006F2 RID: 1778
		[Header("Canal Constraints")]
		public ChildOfGuiaPhysicsUser m_canal_000;

		// Token: 0x040006F3 RID: 1779
		public ChildOfGuiaPhysicsUser m_canal_001;

		// Token: 0x040006F4 RID: 1780
		public ChildOfGuiaPhysicsUser m_canal_002;

		// Token: 0x040006F5 RID: 1781
		public ChildOfGuiaPhysicsUser m_canal_003;

		// Token: 0x040006F6 RID: 1782
		public ChildOfGuiaPhysicsUser m_canal_004;

		// Token: 0x040006F7 RID: 1783
		public ChildOfGuiaPhysicsUser m_canal_005;

		// Token: 0x040006F8 RID: 1784
		[Header("Capsule Constraints")]
		public ChildOfGuiaPhysicsUser m_CervixCapsule_000;

		// Token: 0x040006F9 RID: 1785
		public ChildOfGuiaPhysicsUser m_CervixCapsule_001;

		// Token: 0x040006FA RID: 1786
		[Header("Uterus Constraints")]
		public ChildOfGuiaPhysicsUser m_Cervix_001;

		// Token: 0x040006FB RID: 1787
		public ChildOfGuiaPhysicsUser m_uterusTip;

		// Token: 0x040006FC RID: 1788
		public ChildOfGuiaPhysicsUser m_uterus000;

		// Token: 0x040006FD RID: 1789
		public ChildOfGuiaPhysicsUser m_uterus001;

		// Token: 0x040006FE RID: 1790
		public ChildOfGuiaPhysicsUser m_uterus002;

		// Token: 0x040006FF RID: 1791
		[Header("Over Canal Constraints")]
		public ChildOfGuiaPhysicsUser m_overCanal_000;

		// Token: 0x04000700 RID: 1792
		public ChildOfGuiaPhysicsUser m_overCanal_001;

		// Token: 0x04000701 RID: 1793
		public ChildOfGuiaPhysicsUser m_overCanal_002;

		// Token: 0x04000702 RID: 1794
		public ChildOfGuiaPhysicsUser m_overCanal_003;

		// Token: 0x04000703 RID: 1795
		[Header("Configs")]
		public ChildOfConfig childOfConfig = new ChildOfConfig();

		// Token: 0x04000704 RID: 1796
		public ChildOfConfig childOfConfigCanal000 = new ChildOfConfig();

		// Token: 0x04000705 RID: 1797
		public ChildOfConfig childOfConfigCanal001 = new ChildOfConfig();

		// Token: 0x04000706 RID: 1798
		public ChildOfConfig childOfConfigCanal002 = new ChildOfConfig();

		// Token: 0x04000707 RID: 1799
		public ChildOfConfig childOfConfigCanal003 = new ChildOfConfig();

		// Token: 0x04000708 RID: 1800
		public ChildOfConfig childOfConfigCanal004 = new ChildOfConfig();

		// Token: 0x04000709 RID: 1801
		public ChildOfConfig childOfConfigCanal005 = new ChildOfConfig();

		// Token: 0x0400070A RID: 1802
		public ChildOfConfig childOfConfigCapsule = new ChildOfConfig();

		// Token: 0x0400070B RID: 1803
		public ChildOfConfig childOfConfigUterus = new ChildOfConfig
		{
			usarScala = false,
			usarPosicion = false
		};

		// Token: 0x0400070C RID: 1804
		public ChildOfConfig childOfConfigOvercanal = new ChildOfConfig
		{
			usarScala = false,
			usarRotacion = false
		};

		// Token: 0x02000200 RID: 512
		[Serializable]
		public class Par
		{
			// Token: 0x04000AFF RID: 2815
			public Transform self;

			// Token: 0x04000B00 RID: 2816
			public Transform other;
		}
	}
}
