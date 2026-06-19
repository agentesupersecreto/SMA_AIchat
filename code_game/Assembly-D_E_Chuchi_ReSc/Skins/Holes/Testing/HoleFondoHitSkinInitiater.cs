using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Holes.Testing
{
	// Token: 0x020000A7 RID: 167
	public class HoleFondoHitSkinInitiater : CustomMonobehaviour
	{
		// Token: 0x060003AF RID: 943 RVA: 0x0000DD7C File Offset: 0x0000BF7C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.hole.stared += this.Hole_stared;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000DD9B File Offset: 0x0000BF9B
		private void Hole_stared(object sender)
		{
			this.target.Init(this.hole, null, this.tipo);
		}

		// Token: 0x040002BD RID: 701
		public BoneStretchedChain hole;

		// Token: 0x040002BE RID: 702
		public FemalePenetracionTipo tipo;

		// Token: 0x040002BF RID: 703
		public HoleFondoHitSkin target;
	}
}
