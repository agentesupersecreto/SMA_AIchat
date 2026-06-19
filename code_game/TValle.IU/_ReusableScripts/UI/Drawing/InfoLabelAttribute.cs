using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006A RID: 106
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class InfoLabelAttribute : LayoutedElementAttribute
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00007749 File Offset: 0x00005949
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.infoLabel;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000774D File Offset: 0x0000594D
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00007755 File Offset: 0x00005955
		public string separador { get; set; } = ":";
	}
}
