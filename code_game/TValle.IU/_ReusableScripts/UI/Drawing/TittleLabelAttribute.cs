using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000072 RID: 114
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class TittleLabelAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00007A29 File Offset: 0x00005C29
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.tittleLabel;
			}
		}
	}
}
