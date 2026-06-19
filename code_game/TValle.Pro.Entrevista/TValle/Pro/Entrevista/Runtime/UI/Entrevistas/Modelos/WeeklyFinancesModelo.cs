using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000054 RID: 84
	[Modelo]
	[Label("Weekly Finances", "US")]
	[Panel(width = 1150, height = 700)]
	[Serializable]
	public class WeeklyFinancesModelo
	{
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000284 RID: 644 RVA: 0x0000F7C0 File Offset: 0x0000D9C0
		// (remove) Token: 0x06000285 RID: 645 RVA: 0x0000F7F8 File Offset: 0x0000D9F8
		public event Action onPayClick;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000286 RID: 646 RVA: 0x0000F830 File Offset: 0x0000DA30
		// (remove) Token: 0x06000287 RID: 647 RVA: 0x0000F868 File Offset: 0x0000DA68
		public event Action onUpgradeOfficeClick;

		// Token: 0x06000288 RID: 648 RVA: 0x0000F89D File Offset: 0x0000DA9D
		[Label("Upgrade Office", "US")]
		[BotonDePanel]
		public void Upgrade()
		{
			Action action = this.onUpgradeOfficeClick;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000F8AF File Offset: 0x0000DAAF
		[Label("Pay", "US")]
		[BotonDePanel]
		public void Pay()
		{
			Action action = this.onPayClick;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040001AB RID: 427
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 toPayLabel = new LabelData2();

		// Token: 0x040001AC RID: 428
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 rentExpense = new LabelData2();

		// Token: 0x040001AD RID: 429
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 talentSalaries = new LabelData2();

		// Token: 0x040001AE RID: 430
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 totalLabel = new LabelData2();

		// Token: 0x040001AF RID: 431
		[Modelo]
		public WeeklyFinancesIncomeVsExpenses incomeVsExpenses = new WeeklyFinancesIncomeVsExpenses();
	}
}
