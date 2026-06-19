using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000062 RID: 98
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DiscordPanelButtonAttribute : ClickableAttribute
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000769A File Offset: 0x0000589A
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.discordPanelButton;
			}
		}
	}
}
