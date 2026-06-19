using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts
{
	// Token: 0x02000149 RID: 329
	public interface IUIPanelConExtraData : IUIPanel, IUIElemento
	{
		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000989 RID: 2441
		IReadOnlyDictionary<string, Func<object>> extradata { get; }

		// Token: 0x0600098A RID: 2442
		void SetExtraData(Dictionary<string, Func<object>> Extradata);
	}
}
