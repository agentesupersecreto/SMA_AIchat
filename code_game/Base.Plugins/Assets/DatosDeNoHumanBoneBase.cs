using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000C2 RID: 194
	public abstract class DatosDeNoHumanBoneBase : DatosDeBoneBase
	{
		// Token: 0x060005D0 RID: 1488 RVA: 0x00016EAC File Offset: 0x000150AC
		public void Init(Animator anim, string boneFieldName, IMapaDeHuesosDeCharacter mapa)
		{
			if (mapa == null)
			{
				throw new ArgumentNullException("mapa", "mapa null reference.");
			}
			Transform transform = mapa.ObtenerHueso(boneFieldName, anim);
			this.OnInit(anim, transform);
		}
	}
}
