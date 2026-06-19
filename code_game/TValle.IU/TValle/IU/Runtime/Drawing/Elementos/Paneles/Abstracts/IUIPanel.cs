using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000141 RID: 321
	public interface IUIPanel : IUIElemento
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000979 RID: 2425
		IReadOnlyDictionary<string, IUIElemento> elementoPorModelo { get; }

		// Token: 0x0600097A RID: 2426
		void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares);

		// Token: 0x0600097B RID: 2427
		void AddElementOnAsyncMode(string model, IUIElemento element);

		// Token: 0x0600097C RID: 2428
		void ReplaceElemento(IUIElemento elemento);

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x0600097D RID: 2429
		Image panel { get; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x0600097E RID: 2430
		int getParentCount { get; }

		// Token: 0x0600097F RID: 2431
		Transform GetParentPara(int index);

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000980 RID: 2432
		Scrollbar scrollbar { get; }
	}
}
