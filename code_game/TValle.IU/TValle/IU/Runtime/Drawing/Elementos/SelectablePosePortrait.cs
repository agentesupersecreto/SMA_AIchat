using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012C RID: 300
	public class SelectablePosePortrait : SelectablePortraitBase
	{
		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0001E021 File Offset: 0x0001C221
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0001E024 File Offset: 0x0001C224
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadPoses.CargarThumbnail(nombreDeProtrait, ref loadedTexture);
		}
	}
}
