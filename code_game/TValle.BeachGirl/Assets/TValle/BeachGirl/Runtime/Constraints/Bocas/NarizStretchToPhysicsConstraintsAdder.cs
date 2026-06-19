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
	// Token: 0x020000AF RID: 175
	public class NarizStretchToPhysicsConstraintsAdder : ConstraintsAdder
	{
		// Token: 0x0600053E RID: 1342 RVA: 0x000114E0 File Offset: 0x0000F6E0
		protected override void OnInit()
		{
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string tavoNarizSkinStretched = instance.TavoNarizSkinStretched;
			string tavoNarizSkinTip = instance.TavoNarizSkinTip;
			this.CreateAndInitConstraint(ref this.tip, tavoNarizSkinStretched, tavoNarizSkinTip, this.stretchToConfig, this.dampedTrackConfig);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00011519 File Offset: 0x0000F719
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

		// Token: 0x0400035D RID: 861
		public StretchToPhysicsUserForSkeleton tip;

		// Token: 0x0400035E RID: 862
		public DampedTrackConfig dampedTrackConfig = new DampedTrackConfig
		{
			forwardAxis = Vector3.forward
		};

		// Token: 0x0400035F RID: 863
		public StretchToConfig stretchToConfig = new StretchToConfig
		{
			upwardAxis = Vector3.up,
			maxScale = new float2(3f, 3f)
		};
	}
}
