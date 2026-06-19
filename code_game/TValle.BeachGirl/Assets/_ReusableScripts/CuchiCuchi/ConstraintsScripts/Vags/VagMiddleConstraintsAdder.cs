using System;
using Assets.SystemasConstraints.DampedTrackConstraints.Abstracts;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags
{
	// Token: 0x02000128 RID: 296
	public class VagMiddleConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x06000CC4 RID: 3268 RVA: 0x0002C0C8 File Offset: 0x0002A2C8
		protected override void OnInit()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string defvagClit_ = instance.DEFVagClit_001;
			string defvagClitBaseToMiddle = instance.DEFVagClitBaseToMiddle;
			string defvagMiddle_ = instance.DEFVagMiddle_002;
			string defvagMiddle_2 = instance.DEFVagMiddle_001;
			string defvagMiddle_3 = instance.DEFVagMiddle_000;
			string vagClitBase_ = instance.VagClitBase_001;
			string vagMiddle_ = instance.VagMiddle_002;
			string vagMiddle_2 = instance.VagMiddle_001;
			string vagMiddle_3 = instance.VagMiddle_000;
			string vagHole_F = instance.VagHole_F;
			this.CreateAndInitConstraint(ref this.m_clitBaseToClitBasePunta, defvagClit_, vagClitBase_, this.stretchToConfig, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_clitTo002, defvagClitBaseToMiddle, vagMiddle_, this.stretchToConfig, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_002To001, defvagMiddle_, vagMiddle_2, this.stretchToConfig, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_001To000, defvagMiddle_2, vagMiddle_3, this.stretchToConfig, this.dampedTrackConfig);
			this.CreateAndInitConstraint(ref this.m_000ToVagHoleF, defvagMiddle_3, vagHole_F, this.stretchToConfig, this.dampedTrackConfig);
			string vagMiddle_4 = instance.VagMiddle_000;
			string vagMiddle_5 = instance.VagMiddle_001;
			string vagMiddle_6 = instance.VagMiddle_002;
			string vagHole_F2 = instance.VagHole_F;
			string vagHole_F3 = instance.VagHole_F;
			string vagHole_F4 = instance.VagHole_F;
			string vagClitBase_2 = instance.VagClitBase_001;
			string vagClitBase_3 = instance.VagClitBase_001;
			string vagClitBase_4 = instance.VagClitBase_001;
			this.CreateAndInitConstraint(ref this.m_middle_000, vagMiddle_4, vagHole_F2, vagClitBase_2);
			this.CreateAndInitConstraint(ref this.m_middle_001, vagMiddle_5, vagHole_F3, vagClitBase_3);
			this.CreateAndInitConstraint(ref this.m_middle_002, vagMiddle_6, vagHole_F4, vagClitBase_4);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x0002C22B File Offset: 0x0002A42B
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

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0002C266 File Offset: 0x0002A466
		private void CreateAndInitConstraint(ref MaintainRatioBetweenTwoPointsPhysicsUserForSkeleton constraint, string constrained, string target1, string target2)
		{
			if (constraint != null)
			{
				throw new NotSupportedException();
			}
			base.Create<MaintainRatioBetweenTwoPointsPhysicsUserForSkeleton>(ref constraint, constrained);
			constraint.Init(this.constrainedSkeleton, constrained, target1, target2);
		}

		// Token: 0x0400072D RID: 1837
		public StretchToPhysicsUserForSkeleton m_clitBaseToClitBasePunta;

		// Token: 0x0400072E RID: 1838
		public StretchToPhysicsUserForSkeleton m_clitTo002;

		// Token: 0x0400072F RID: 1839
		public StretchToPhysicsUserForSkeleton m_002To001;

		// Token: 0x04000730 RID: 1840
		public StretchToPhysicsUserForSkeleton m_001To000;

		// Token: 0x04000731 RID: 1841
		public StretchToPhysicsUserForSkeleton m_000ToVagHoleF;

		// Token: 0x04000732 RID: 1842
		public MaintainRatioBetweenTwoPointsPhysicsUserForSkeleton m_middle_000;

		// Token: 0x04000733 RID: 1843
		public MaintainRatioBetweenTwoPointsPhysicsUserForSkeleton m_middle_001;

		// Token: 0x04000734 RID: 1844
		public MaintainRatioBetweenTwoPointsPhysicsUserForSkeleton m_middle_002;

		// Token: 0x04000735 RID: 1845
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x04000736 RID: 1846
		public StretchToConfig stretchToConfig = new StretchToConfig
		{
			upwardAxis = Vector3.up
		};
	}
}
