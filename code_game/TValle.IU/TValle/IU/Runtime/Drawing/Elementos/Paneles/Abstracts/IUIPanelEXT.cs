using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000142 RID: 322
	public static class IUIPanelEXT
	{
		// Token: 0x06000981 RID: 2433 RVA: 0x0001F7FF File Offset: 0x0001D9FF
		public static bool EsPadreDe(this IUIPanel panel, IUIElemento elemento)
		{
			return IUIPanelEXT.esPadreDe(panel, elemento);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0001F808 File Offset: 0x0001DA08
		private static bool esPadreDe(IUIPanel panel, IUIElemento elemento)
		{
			foreach (KeyValuePair<string, IUIElemento> keyValuePair in panel.elementoPorModelo)
			{
				if (elemento == keyValuePair.Value)
				{
					return true;
				}
			}
			foreach (KeyValuePair<string, IUIElemento> keyValuePair2 in panel.elementoPorModelo)
			{
				IUIPanel iuipanel = keyValuePair2.Value as IUIPanel;
				if (iuipanel != null && IUIPanelEXT.esPadreDe(iuipanel, elemento))
				{
					return true;
				}
			}
			return false;
		}
	}
}
