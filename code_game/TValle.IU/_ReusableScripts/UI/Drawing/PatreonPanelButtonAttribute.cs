using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000061 RID: 97
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class PatreonPanelButtonAttribute : ClickableAttribute
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000768F File Offset: 0x0000588F
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.patreonPanelButton;
			}
		}
	}
}
