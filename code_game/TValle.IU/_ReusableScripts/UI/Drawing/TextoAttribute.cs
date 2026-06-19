using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200005A RID: 90
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class TextoAttribute : LayoutedElementAttribute
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0000763E File Offset: 0x0000583E
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.texto;
			}
		}
	}
}
