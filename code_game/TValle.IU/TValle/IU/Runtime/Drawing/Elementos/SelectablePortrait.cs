using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012B RID: 299
	public class SelectablePortrait : SelectablePortraitBase
	{
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0001E00C File Offset: 0x0001C20C
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0001E00F File Offset: 0x0001C20F
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadCharacters.CargarThumbnail(nombreDeProtrait, ref loadedTexture, true);
		}
	}
}
