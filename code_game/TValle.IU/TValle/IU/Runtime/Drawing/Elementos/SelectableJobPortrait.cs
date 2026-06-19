using System;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000127 RID: 295
	public class SelectableJobPortrait : SelectablePortraitBase
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0001DFB6 File Offset: 0x0001C1B6
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0001DFB9 File Offset: 0x0001C1B9
		protected override void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			throw new NotSupportedException("deberia usarse el custom loader");
		}
	}
}
