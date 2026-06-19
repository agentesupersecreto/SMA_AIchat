using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000228 RID: 552
	public interface IBarkUI
	{
		// Token: 0x060018E5 RID: 6373
		void Bark(Subtitle subtitle);

		// Token: 0x060018E6 RID: 6374
		void Hide();

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x060018E7 RID: 6375
		bool IsPlaying { get; }
	}
}
