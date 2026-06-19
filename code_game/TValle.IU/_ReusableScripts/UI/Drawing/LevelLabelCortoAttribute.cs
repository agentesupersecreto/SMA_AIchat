using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006F RID: 111
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class LevelLabelCortoAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00007975 File Offset: 0x00005B75
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.levelLabelCorto;
			}
		}
	}
}
