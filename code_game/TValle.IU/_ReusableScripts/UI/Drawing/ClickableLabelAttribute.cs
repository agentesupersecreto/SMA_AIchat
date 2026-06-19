using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000066 RID: 102
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ClickableLabelAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000076C9 File Offset: 0x000058C9
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.clickableLabel;
			}
		}
	}
}
