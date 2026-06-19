using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000535 RID: 1333
	[Obsolete("", true)]
	public interface IConsentPorInteraciones
	{
		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x060020CB RID: 8395
		bool alMaximo { get; }

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x060020CC RID: 8396
		float maxCantidadDeConsentPor { get; }

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x060020CD RID: 8397
		BufferDeMaxValue maxValueBuffer { get; }
	}
}
