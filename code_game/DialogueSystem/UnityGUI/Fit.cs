using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002CC RID: 716
	[Serializable]
	public class Fit
	{
		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06001D75 RID: 7541 RVA: 0x00038F38 File Offset: 0x00037138
		public bool IsSpecified
		{
			get
			{
				return this.above != null || this.below != null || this.leftOf != null || this.rightOf != null;
			}
		}

		// Token: 0x040010F3 RID: 4339
		public GUIControl above;

		// Token: 0x040010F4 RID: 4340
		public GUIControl below;

		// Token: 0x040010F5 RID: 4341
		public GUIControl leftOf;

		// Token: 0x040010F6 RID: 4342
		public GUIControl rightOf;

		// Token: 0x040010F7 RID: 4343
		public bool expandToFit = true;
	}
}
