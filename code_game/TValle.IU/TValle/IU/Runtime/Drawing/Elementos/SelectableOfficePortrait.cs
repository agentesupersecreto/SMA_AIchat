using System;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000129 RID: 297
	public class SelectableOfficePortrait : SelectablePortraitBase
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x0001DFE1 File Offset: 0x0001C1E1
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			throw new NotSupportedException("deberia usarse el custom loader");
		}
	}
}
