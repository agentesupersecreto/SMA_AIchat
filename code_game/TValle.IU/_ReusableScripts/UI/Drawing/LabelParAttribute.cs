using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000073 RID: 115
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class LabelParAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00007A35 File Offset: 0x00005C35
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.labelPar;
			}
		}
	}
}
