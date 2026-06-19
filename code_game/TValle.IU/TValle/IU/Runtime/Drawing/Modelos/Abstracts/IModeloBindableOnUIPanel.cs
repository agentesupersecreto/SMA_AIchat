using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts
{
	// Token: 0x02000109 RID: 265
	public interface IModeloBindableOnUIPanel
	{
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060007E0 RID: 2016
		IUIPanel panel { get; }

		// Token: 0x060007E1 RID: 2017
		void Bindig();

		// Token: 0x060007E2 RID: 2018
		void Binded(IUIPanel to);

		// Token: 0x060007E3 RID: 2019
		void Clearing();

		// Token: 0x060007E4 RID: 2020
		void Cleared();
	}
}
