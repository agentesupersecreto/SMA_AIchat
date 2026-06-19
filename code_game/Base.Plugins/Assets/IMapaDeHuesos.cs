using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000E8 RID: 232
	public interface IMapaDeHuesos
	{
		// Token: 0x0600067E RID: 1662
		bool ContieneHueso(string fieldONombre, Animator anim);

		// Token: 0x0600067F RID: 1663
		Transform ObtenerHueso(string fieldONombre, Animator anim);
	}
}
