using System;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.Memoria
{
	// Token: 0x02000095 RID: 149
	[Serializable]
	public class MakeoverToDisk
	{
		// Token: 0x040003AC RID: 940
		public string name;

		// Token: 0x040003AD RID: 941
		public int serialVersionMateriales;

		// Token: 0x040003AE RID: 942
		public MakeoverToEdit makeover = new MakeoverToEdit();
	}
}
