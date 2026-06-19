using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012D RID: 301
	public class SelectableProfilePortrait : SelectablePortraitBase
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0001E035 File Offset: 0x0001C235
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001E038 File Offset: 0x0001C238
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadProfilePortraits.CargarThumbnail(nombreDeProtrait, ref loadedTexture);
		}
	}
}
