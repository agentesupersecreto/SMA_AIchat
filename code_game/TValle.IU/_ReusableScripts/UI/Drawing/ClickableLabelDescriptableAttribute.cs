using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000063 RID: 99
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ClickableLabelDescriptableAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000304 RID: 772 RVA: 0x000076A6 File Offset: 0x000058A6
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.clickableLabelDescriptable;
			}
		}
	}
}
