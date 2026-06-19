using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000B4 RID: 180
	public interface IUIElementoConDescripcionSimple : IUIElemento
	{
		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000527 RID: 1319
		// (set) Token: 0x06000528 RID: 1320
		string descripcion { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000529 RID: 1321
		// (set) Token: 0x0600052A RID: 1322
		float widthMod { get; set; }
	}
}
