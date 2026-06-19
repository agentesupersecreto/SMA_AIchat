using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007F RID: 127
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class InterpretationProfilePortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00007B39 File Offset: 0x00005D39
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.interpretationProfilePortrait;
			}
		}
	}
}
