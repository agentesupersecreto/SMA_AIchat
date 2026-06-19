using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000077 RID: 119
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class PortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00007AC8 File Offset: 0x00005CC8
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.portrait;
			}
		}
	}
}
