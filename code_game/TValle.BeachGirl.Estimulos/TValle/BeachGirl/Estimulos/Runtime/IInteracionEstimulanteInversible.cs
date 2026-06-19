using System;

namespace Assets.TValle.BeachGirl.Estimulos.Runtime
{
	// Token: 0x02000020 RID: 32
	public interface IInteracionEstimulanteInversible : IInteracionEstimulanteBasica
	{
		// Token: 0x060000F6 RID: 246
		void ClearInvertedCopy();

		// Token: 0x060000F7 RID: 247
		void ClearOriginalCopy();

		// Token: 0x060000F8 RID: 248
		void SetAsInvertedCopy(IInteracionEstimulanteBasica original);

		// Token: 0x060000F9 RID: 249
		void SwitchReferencias();
	}
}
