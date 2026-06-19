using System;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200007F RID: 127
	public class StandAloneFemaleSkin : Skin
	{
		// Token: 0x06000331 RID: 817 RVA: 0x0000C446 File Offset: 0x0000A646
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.ConfigSkinOnAdded(this.isMainSkin, this.isExtraMainSkin, this.cloneMaterials);
		}

		// Token: 0x04000238 RID: 568
		public bool isMainSkin;

		// Token: 0x04000239 RID: 569
		public bool isExtraMainSkin;

		// Token: 0x0400023A RID: 570
		public bool cloneMaterials;
	}
}
