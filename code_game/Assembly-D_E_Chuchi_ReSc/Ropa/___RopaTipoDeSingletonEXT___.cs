using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000E7 RID: 231
	public static class ___RopaTipoDeSingletonEXT___
	{
		// Token: 0x06000595 RID: 1429 RVA: 0x0001A890 File Offset: 0x00018A90
		[Obsolete("Se unificaron los mapas", true)]
		public static IRopaParaAvatar ObtenerMapaDeRopa(this RopaTipoDeSingleton tipo)
		{
			IRopaParaAvatar ropaParaAvatar;
			if (tipo != RopaTipoDeSingleton.femenine)
			{
				if (tipo != RopaTipoDeSingleton.masculine)
				{
					Debug.LogException(new ArgumentOutOfRangeException(tipo.ToString()));
					return null;
				}
				ropaParaAvatar = AsyncSingleton<RopaParaAvatarMasculino>.instance;
			}
			else
			{
				ropaParaAvatar = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			}
			return ropaParaAvatar;
		}
	}
}
