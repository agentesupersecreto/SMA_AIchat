using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000071 RID: 113
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class LabelCortoLabelLargoParAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00007A1D File Offset: 0x00005C1D
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.labelCortoLabelLargoPar;
			}
		}
	}
}
