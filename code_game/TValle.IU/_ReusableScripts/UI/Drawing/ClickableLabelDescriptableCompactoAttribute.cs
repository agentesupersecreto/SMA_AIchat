using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000064 RID: 100
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ClickableLabelDescriptableCompactoAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000306 RID: 774 RVA: 0x000076B1 File Offset: 0x000058B1
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.clickableLabelDescriptableCompacto;
			}
		}
	}
}
