using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000043 RID: 67
	[RequireComponent(typeof(PanelMakeWeeklyPayments))]
	public class PanelMakeWeeklyPaymentsGetter : Singleton<PanelMakeWeeklyPaymentsGetter>
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000D431 File Offset: 0x0000B631
		public PanelMakeWeeklyPayments panel
		{
			get
			{
				return this.m_Panel;
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000D439 File Offset: 0x0000B639
		protected override void Awaking()
		{
			base.Awaking();
			this.m_Panel = base.GetComponent<PanelMakeWeeklyPayments>();
		}

		// Token: 0x0400016E RID: 366
		private PanelMakeWeeklyPayments m_Panel;
	}
}
