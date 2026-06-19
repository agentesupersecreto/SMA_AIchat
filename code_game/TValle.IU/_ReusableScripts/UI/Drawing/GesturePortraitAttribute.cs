using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000079 RID: 121
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class GesturePortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00007AE0 File Offset: 0x00005CE0
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.gesturePortrait;
			}
		}
	}
}
