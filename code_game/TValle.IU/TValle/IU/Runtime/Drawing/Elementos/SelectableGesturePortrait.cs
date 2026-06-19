using System;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000126 RID: 294
	public class SelectableGesturePortrait : SelectablePortraitBase
	{
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0001DFA2 File Offset: 0x0001C1A2
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001DFA5 File Offset: 0x0001C1A5
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadGestos.CargarThumbnail(nombreDeProtrait, ref loadedTexture);
		}
	}
}
