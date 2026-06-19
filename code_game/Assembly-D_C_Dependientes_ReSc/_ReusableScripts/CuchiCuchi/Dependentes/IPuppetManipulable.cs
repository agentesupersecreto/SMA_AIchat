using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000034 RID: 52
	public interface IPuppetManipulable
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000F5 RID: 245
		bool siendoManipulado { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000F6 RID: 246
		IPuppetManipulator by { get; }
	}
}
