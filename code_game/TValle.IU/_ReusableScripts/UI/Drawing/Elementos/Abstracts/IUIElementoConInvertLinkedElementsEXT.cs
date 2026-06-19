using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A4 RID: 164
	public static class IUIElementoConInvertLinkedElementsEXT
	{
		// Token: 0x06000511 RID: 1297 RVA: 0x000148B0 File Offset: 0x00012AB0
		public static void RefreshInvertLinked(this IUIElementoConInvertLinkedElements linkable)
		{
			for (int i = 0; i < linkable.InvertLinked.Count; i++)
			{
				IUIElementoRefreshable iuielementoRefreshable = linkable.InvertLinked[i] as IUIElementoRefreshable;
				if (iuielementoRefreshable != null)
				{
					iuielementoRefreshable.Refresh();
				}
			}
		}
	}
}
