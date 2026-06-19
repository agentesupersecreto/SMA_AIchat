using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000047 RID: 71
	[RequireComponent(typeof(PanelDeEntrevistaCalificacion))]
	public class PanelDeEntrevistaCalificacionGetter : Singleton<PanelDeEntrevistaCalificacionGetter>
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000EF7E File Offset: 0x0000D17E
		public PanelDeEntrevistaCalificacion panel
		{
			get
			{
				if (this.m_panel == null)
				{
					this.m_panel = base.GetComponent<PanelDeEntrevistaCalificacion>();
				}
				return this.m_panel;
			}
		}

		// Token: 0x04000176 RID: 374
		private PanelDeEntrevistaCalificacion m_panel;
	}
}
