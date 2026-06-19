using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje
{
	// Token: 0x0200002B RID: 43
	[RequireComponent(typeof(PanelDeEditarGestosFaciales))]
	public class PanelDeEditarGestosFacialesGetter : Singleton<PanelDeEditarGestosFacialesGetter>
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000A54B File Offset: 0x0000874B
		public PanelDeEditarGestosFaciales panel
		{
			get
			{
				if (this.m_panel == null)
				{
					this.m_panel = base.GetComponent<PanelDeEditarGestosFaciales>();
				}
				return this.m_panel;
			}
		}

		// Token: 0x040000F6 RID: 246
		private PanelDeEditarGestosFaciales m_panel;
	}
}
