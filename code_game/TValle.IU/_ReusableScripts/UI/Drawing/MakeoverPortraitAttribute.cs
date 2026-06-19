using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007A RID: 122
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class MakeoverPortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00007AEC File Offset: 0x00005CEC
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.makeoverPortrait;
			}
		}
	}
}
