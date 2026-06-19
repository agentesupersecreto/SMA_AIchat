using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000065 RID: 101
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ClickableLabelConValorAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000076BD File Offset: 0x000058BD
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.clickableLabelConValor;
			}
		}
	}
}
