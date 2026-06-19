using System;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000071 RID: 113
	public class NonBodyDynamicHitSkin : NonBodyManualDynamicHitSkin
	{
		// Token: 0x060002F6 RID: 758 RVA: 0x0000AFE6 File Offset: 0x000091E6
		protected override void Scheduling()
		{
			base.Scheduling();
			if (this.updateCollider)
			{
				base.flagCanBake = true;
			}
		}

		// Token: 0x040001E3 RID: 483
		public bool updateCollider = true;
	}
}
