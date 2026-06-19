using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200005C RID: 92
	public sealed class DesplegableAttribute : DynamicUIElementAttribute
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00007654 File Offset: 0x00005854
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.desplegable;
			}
		}
	}
}
