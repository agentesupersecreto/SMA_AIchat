using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000067 RID: 103
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ClickableFavoritableLabelAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000076D4 File Offset: 0x000058D4
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.clickableFavoritableLabel;
			}
		}
	}
}
