using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000146 RID: 326
	public interface IUIPanelConControles : IUIPanel, IUIElemento
	{
		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000985 RID: 2437
		Transform padreParaControles { get; }
	}
}
