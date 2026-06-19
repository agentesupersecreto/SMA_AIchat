using System;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000042 RID: 66
	public class PanelMakeWeeklyPayments : PanelBaseSingleModel<WeeklyFinancesModelo>
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000D2A1 File Offset: 0x0000B4A1
		public WeeklyFinancesModelo modelo
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000216 RID: 534 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		// (remove) Token: 0x06000217 RID: 535 RVA: 0x0000D2E4 File Offset: 0x0000B4E4
		public event Action onPayClicked;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000218 RID: 536 RVA: 0x0000D31C File Offset: 0x0000B51C
		// (remove) Token: 0x06000219 RID: 537 RVA: 0x0000D354 File Offset: 0x0000B554
		public event Action onUpgradeOfficeClick;

		// Token: 0x0600021A RID: 538 RVA: 0x0000D389 File Offset: 0x0000B589
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.onPayClick += this.M_model_onPayClick;
			this.m_model.onUpgradeOfficeClick += this.M_model_onUpgradeOfficeClick;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000D3BF File Offset: 0x0000B5BF
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.onPayClick -= this.M_model_onPayClick;
			this.m_model.onUpgradeOfficeClick -= this.M_model_onUpgradeOfficeClick;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000D3F5 File Offset: 0x0000B5F5
		public void ClearLeaveCallBacks()
		{
			this.onPayClicked = null;
			this.onUpgradeOfficeClick = null;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000D405 File Offset: 0x0000B605
		private void M_model_onPayClick()
		{
			Action action = this.onPayClicked;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000D417 File Offset: 0x0000B617
		private void M_model_onUpgradeOfficeClick()
		{
			Action action = this.onUpgradeOfficeClick;
			if (action == null)
			{
				return;
			}
			action();
		}
	}
}
