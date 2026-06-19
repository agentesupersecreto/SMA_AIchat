using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000229 RID: 553
	public interface IDepthPositionContainer
	{
		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000E39 RID: 3641
		float minDepth { get; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000E3A RID: 3642
		float maxDepth { get; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000E3B RID: 3643
		// (set) Token: 0x06000E3C RID: 3644
		float defaultDepth { get; set; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000E3D RID: 3645
		// (set) Token: 0x06000E3E RID: 3646
		float depthPosition { get; set; }
	}
}
