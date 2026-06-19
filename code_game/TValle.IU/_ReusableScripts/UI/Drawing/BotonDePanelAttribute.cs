using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000083 RID: 131
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class BotonDePanelAttribute : ClickableAttribute
	{
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00007BA2 File Offset: 0x00005DA2
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.botonDePanel;
			}
		}
	}
}
