using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000055 RID: 85
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.panel1by1)]
	[Serializable]
	public class WeeklyFinancesIncomeVsExpenses
	{
		// Token: 0x040001B0 RID: 432
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public IncomeOrExpenses income = new IncomeOrExpenses();

		// Token: 0x040001B1 RID: 433
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public IncomeOrExpenses expenses = new IncomeOrExpenses();
	}
}
