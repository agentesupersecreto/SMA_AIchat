using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007C RID: 124
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class OutfitPortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00007B04 File Offset: 0x00005D04
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.outfitPortrait;
			}
		}
	}
}
