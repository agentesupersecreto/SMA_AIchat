using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000060 RID: 96
	public sealed class DesplegableHelpBotonAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00007683 File Offset: 0x00005883
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.desplegableHelpBoton;
			}
		}
	}
}
