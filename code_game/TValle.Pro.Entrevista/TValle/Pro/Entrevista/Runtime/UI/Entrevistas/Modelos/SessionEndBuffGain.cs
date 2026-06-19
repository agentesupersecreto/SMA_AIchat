using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000052 RID: 82
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 550)]
	[Serializable]
	public class SessionEndBuffGain
	{
		// Token: 0x0600027F RID: 639 RVA: 0x0000F75E File Offset: 0x0000D95E
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x040001A5 RID: 421
		[Ignore]
		public string title = "NONE";

		// Token: 0x040001A6 RID: 422
		[Modelo]
		public List<SessionEndBuffGainCategoria> buffGains = new List<SessionEndBuffGainCategoria>();
	}
}
