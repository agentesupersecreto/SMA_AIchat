using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200005B RID: 91
	public sealed class ToggleAttribute : DynamicUIElementAttribute
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00007649 File Offset: 0x00005849
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.toggle;
			}
		}
	}
}
