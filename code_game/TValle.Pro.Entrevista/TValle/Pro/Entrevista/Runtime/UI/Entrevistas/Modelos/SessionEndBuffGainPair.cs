using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000051 RID: 81
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.panel1by1)]
	[Serializable]
	public class SessionEndBuffGainPair
	{
		// Token: 0x040001A3 RID: 419
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public SessionEndBuffGain nonPlayer = new SessionEndBuffGain();

		// Token: 0x040001A4 RID: 420
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public SessionEndBuffGain player = new SessionEndBuffGain();
	}
}
