using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000B8 RID: 184
	public interface IUIBoton : IUIElemento
	{
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000537 RID: 1335
		OnClickedEvent onClicked { get; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000538 RID: 1336
		OnClickedBotonEvent onClickedElement { get; }
	}
}
