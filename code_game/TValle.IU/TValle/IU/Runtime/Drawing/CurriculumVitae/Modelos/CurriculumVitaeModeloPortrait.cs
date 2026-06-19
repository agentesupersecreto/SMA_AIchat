using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos
{
	// Token: 0x02000156 RID: 342
	[Panel(width = 530, height = 200, controlChildHeight = false, controlChildWidth = false, childForceExpandHeight = false, childForceExpandWidth = false, unlockParentFlexibleIfWidthWasSet = true, unlockFlexibleIfWidthWasSet = true)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class CurriculumVitaeModeloPortrait
	{
		// Token: 0x0400040B RID: 1035
		[Imagen(height = 160, width = 90)]
		public Texture2D imagen;
	}
}
