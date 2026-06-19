using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000078 RID: 120
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class GameplayObjectiveAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.gameplayObjective;
			}
		}
	}
}
