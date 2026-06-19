using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000033 RID: 51
	public interface IPuppetManipulator
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000F2 RID: 242
		bool manipulando { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000F3 RID: 243
		IPuppetManipulable manipulandoA { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000F4 RID: 244
		IPuppetManipulatorData manipulandoData { get; }
	}
}
