using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000009 RID: 9
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.nestedContainer)]
	[Serializable]
	public class AcountModel
	{
		// Token: 0x04000046 RID: 70
		[Modelo]
		public BalanceModel balance = new BalanceModel();

		// Token: 0x04000047 RID: 71
		[Modelo]
		public TransactionsModel transactions = new TransactionsModel();
	}
}
