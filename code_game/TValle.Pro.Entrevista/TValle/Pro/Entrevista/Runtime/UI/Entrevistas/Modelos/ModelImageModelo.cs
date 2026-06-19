using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004E RID: 78
	[Modelo]
	[UnTittle]
	[Panel(width = 110, height = 180, controlChildHeight = false, controlChildWidth = false, childForceExpandHeight = false, childForceExpandWidth = false)]
	[Serializable]
	public class ModelImageModelo
	{
		// Token: 0x04000198 RID: 408
		[Imagen(height = 160, width = 90)]
		public Texture portrait;
	}
}
