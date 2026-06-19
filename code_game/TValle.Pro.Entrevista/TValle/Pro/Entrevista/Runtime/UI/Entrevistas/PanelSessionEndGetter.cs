using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000046 RID: 70
	[RequireComponent(typeof(PanelSessionEnd))]
	public class PanelSessionEndGetter : Singleton<PanelSessionEndGetter>
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000EF5A File Offset: 0x0000D15A
		public PanelSessionEnd panel
		{
			get
			{
				return this.m_Panel;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000EF62 File Offset: 0x0000D162
		protected override void Awaking()
		{
			base.Awaking();
			this.m_Panel = base.GetComponent<PanelSessionEnd>();
		}

		// Token: 0x04000175 RID: 373
		private PanelSessionEnd m_Panel;
	}
}
