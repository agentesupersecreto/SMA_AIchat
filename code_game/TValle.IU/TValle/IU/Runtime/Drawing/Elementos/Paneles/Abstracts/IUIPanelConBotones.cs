using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000147 RID: 327
	public interface IUIPanelConBotones : IUIPanel, IUIElemento
	{
		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000986 RID: 2438
		Transform padreParaBotones { get; }

		// Token: 0x06000987 RID: 2439
		void AddBotones(IEnumerable<KeyValuePair<string, IUIElemento>> pares);
	}
}
