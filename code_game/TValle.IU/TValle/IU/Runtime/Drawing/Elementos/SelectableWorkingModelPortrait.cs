using System;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012E RID: 302
	public class SelectableWorkingModelPortrait : SelectablePortraitBase
	{
		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0001E049 File Offset: 0x0001C249
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001E04C File Offset: 0x0001C24C
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			throw new NotSupportedException("deberia usarse el custom loader");
		}
	}
}
