using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles
{
	// Token: 0x02000152 RID: 338
	[RequireComponent(typeof(MaleInfoPanel))]
	public class MaleInfoPanelGetter : Singleton<MaleInfoPanelGetter>
	{
		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x00021313 File Offset: 0x0001F513
		public MaleInfoPanel panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0002131B File Offset: 0x0001F51B
		protected override void Awaking()
		{
			base.Awaking();
			this.m_panel = base.GetComponent<MaleInfoPanel>();
		}

		// Token: 0x040003F8 RID: 1016
		private MaleInfoPanel m_panel;
	}
}
