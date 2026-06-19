using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012A RID: 298
	public class SelectableOutfitPortrait : SelectablePortraitBase
	{
		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x0001DFF8 File Offset: 0x0001C1F8
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0001DFFB File Offset: 0x0001C1FB
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadOutfit.CargarThumbnail(nombreDeProtrait, ref loadedTexture);
		}
	}
}
