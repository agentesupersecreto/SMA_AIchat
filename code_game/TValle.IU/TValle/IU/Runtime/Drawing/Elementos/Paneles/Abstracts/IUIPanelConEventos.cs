using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000148 RID: 328
	public interface IUIPanelConEventos : IUIPanel, IUIElemento
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000988 RID: 2440
		UIPanelEvent onEvent { get; }
	}
}
