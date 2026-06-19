using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000128 RID: 296
	public class SelectableMakeoverPortrait : SelectablePortraitBase
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0001DFCD File Offset: 0x0001C1CD
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadMakeover.CargarThumbnail(nombreDeProtrait, ref loadedTexture);
		}
	}
}
