using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000AE RID: 174
	public interface IUIElementoClickable : IUIElemento
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000521 RID: 1313
		OnElementoClicked onElementoClicked { get; }
	}
}
