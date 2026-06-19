using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000084 RID: 132
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class BotonDePanelConfirmableAttribute : ClickableConfirmableAttribute
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00007BAD File Offset: 0x00005DAD
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.botonDePanelConfirmable;
			}
		}
	}
}
