using System;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.Memoria
{
	// Token: 0x02000094 RID: 148
	[Serializable]
	public class GestosFacialesToDisk
	{
		// Token: 0x040003A9 RID: 937
		public string name;

		// Token: 0x040003AA RID: 938
		public int serialVersionMateriales;

		// Token: 0x040003AB RID: 939
		public GestosFacialesShapesToEdit gestos = new GestosFacialesShapesToEdit();
	}
}
