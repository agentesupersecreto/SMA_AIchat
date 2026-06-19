using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000056 RID: 86
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 550)]
	[HeightDinamico(dinamicoMethodTarget = "GetHeight")]
	[Serializable]
	public class IncomeOrExpenses
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0000F91E File Offset: 0x0000DB1E
		public int GetHeight()
		{
			return 50 + this.items.Count * 50 + 20;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000F934 File Offset: 0x0000DB34
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x040001B2 RID: 434
		[Ignore]
		public string title = "NONE";

		// Token: 0x040001B3 RID: 435
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		public List<LabelData2> items = new List<LabelData2>();
	}
}
