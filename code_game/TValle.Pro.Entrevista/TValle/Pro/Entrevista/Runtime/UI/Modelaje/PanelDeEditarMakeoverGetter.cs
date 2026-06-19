using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje
{
	// Token: 0x0200002D RID: 45
	[RequireComponent(typeof(PanelDeEditarMakeover))]
	public class PanelDeEditarMakeoverGetter : Singleton<PanelDeEditarMakeoverGetter>
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000AB77 File Offset: 0x00008D77
		public PanelDeEditarMakeover panel
		{
			get
			{
				if (this.m_panel == null)
				{
					this.m_panel = base.GetComponent<PanelDeEditarMakeover>();
				}
				return this.m_panel;
			}
		}

		// Token: 0x040000FB RID: 251
		private PanelDeEditarMakeover m_panel;
	}
}
