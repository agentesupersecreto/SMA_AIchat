using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000265 RID: 613
	[Serializable]
	public abstract class AbstractUIQTEControls : AbstractUIControls
	{
		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x06001A82 RID: 6786
		public abstract bool AreVisible { get; }

		// Token: 0x06001A83 RID: 6787
		public abstract void ShowIndicator(int index);

		// Token: 0x06001A84 RID: 6788
		public abstract void HideIndicator(int index);
	}
}
