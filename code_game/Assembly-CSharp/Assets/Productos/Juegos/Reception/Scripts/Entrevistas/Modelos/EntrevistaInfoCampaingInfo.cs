using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000B3 RID: 179
	[Panel(width = 500, height = 580)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class EntrevistaInfoCampaingInfo
	{
		// Token: 0x040001C5 RID: 453
		[Texto(height = 120)]
		public string GuiaProf = "*If none of the models in this phase pique your interest, proceed to the next phase to find additional models. A more expensive campaign will allow you to access more phases.";

		// Token: 0x040001C6 RID: 454
		[Label("Campaing")]
		[InfoLabel(height = 60)]
		public string campaing;

		// Token: 0x040001C7 RID: 455
		[Label("Phases")]
		[InfoLabel(height = 90)]
		public string phases;

		// Token: 0x040001C8 RID: 456
		[Label("Models")]
		[InfoLabel(height = 90)]
		public string models;
	}
}
