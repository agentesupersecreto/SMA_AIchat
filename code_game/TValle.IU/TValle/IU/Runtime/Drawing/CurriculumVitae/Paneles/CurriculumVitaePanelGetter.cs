using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles
{
	// Token: 0x02000150 RID: 336
	[RequireComponent(typeof(CurriculumVitaePanel))]
	public class CurriculumVitaePanelGetter : Singleton<CurriculumVitaePanelGetter>
	{
		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00020F5B File Offset: 0x0001F15B
		public CurriculumVitaePanel curriculumVitaePanel
		{
			get
			{
				return this.m_CurriculumVitaePanel;
			}
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00020F63 File Offset: 0x0001F163
		protected override void Awaking()
		{
			base.Awaking();
			this.m_CurriculumVitaePanel = base.GetComponent<CurriculumVitaePanel>();
		}

		// Token: 0x040003F1 RID: 1009
		private CurriculumVitaePanel m_CurriculumVitaePanel;
	}
}
