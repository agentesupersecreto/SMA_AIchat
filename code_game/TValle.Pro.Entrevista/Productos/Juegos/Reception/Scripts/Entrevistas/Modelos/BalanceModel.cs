using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x0200000A RID: 10
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, height = 100)]
	[Serializable]
	public class BalanceModel
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00003F7B File Offset: 0x0000217B
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x04000048 RID: 72
		[Ignore]
		[NonSerialized]
		public string title = "Available Balance";

		// Token: 0x04000049 RID: 73
		[Order(121)]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineRight, fontSize = 20, fontStyle = FontStyles.Bold)]
		public string balance;
	}
}
