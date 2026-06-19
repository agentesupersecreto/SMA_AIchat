using System;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000125 RID: 293
	public class SelectableFavoritableGenericPortrait : SelectableFavoritablePortrait
	{
		// Token: 0x060008BF RID: 2239 RVA: 0x0001DF8E File Offset: 0x0001C18E
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			throw new NotSupportedException("deberia usarse el custom loader");
		}
	}
}
