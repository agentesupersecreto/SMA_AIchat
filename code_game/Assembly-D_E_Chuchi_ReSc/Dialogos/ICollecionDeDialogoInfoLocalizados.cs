using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001C8 RID: 456
	public interface ICollecionDeDialogoInfoLocalizados : ICollecionDeDialogoInfo
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000ADB RID: 2779
		Localizacion paraCulturas { get; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000ADC RID: 2780
		int paraCulturasFlags { get; }

		// Token: 0x06000ADD RID: 2781
		bool ParaCultura(Localizacion localization);
	}
}
