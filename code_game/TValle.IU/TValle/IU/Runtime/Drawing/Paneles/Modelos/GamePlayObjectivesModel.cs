using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x020000FE RID: 254
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.objectivesPanel)]
	[Serializable]
	public class GamePlayObjectivesModel
	{
		// Token: 0x040002FB RID: 763
		[GameplayObjective]
		public List<GamePlayObjectiveModel> objectives = new List<GamePlayObjectiveModel>();
	}
}
