using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007D RID: 125
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class WorkingModelPortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00007B10 File Offset: 0x00005D10
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.workingModelPortrait;
			}
		}
	}
}
