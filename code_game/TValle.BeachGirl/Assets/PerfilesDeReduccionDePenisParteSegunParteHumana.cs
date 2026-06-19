using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000014 RID: 20
	public static class PerfilesDeReduccionDePenisParteSegunParteHumana
	{
		// Token: 0x06000064 RID: 100 RVA: 0x0000268C File Offset: 0x0000088C
		public static float ModDeMinScalaSegunParteHumana(IReadOnlyList<ParteDelCuerpoHumano> partes)
		{
			float num = 1f;
			for (int i = 0; i < partes.Count; i++)
			{
				num = Mathf.Max(num, PerfilesDeReduccionDePenisParteSegunParteHumana.ModDeMinScalaSegunParteHumana(partes[i]));
			}
			return num;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000026C4 File Offset: 0x000008C4
		public static float ModDeMinScalaSegunParteHumana(ParteDelCuerpoHumano parte)
		{
			float num;
			if (!PerfilesDeReduccionDePenisParteSegunParteHumana.m_modDeMinScalaSegunParteHumana.TryGetValue((int)parte, out num))
			{
				return 1f;
			}
			return num;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000026E7 File Offset: 0x000008E7
		public static float ModDeVelocidadSegunModDeMinScala(float minScaleMod)
		{
			return 1f / minScaleMod;
		}

		// Token: 0x0400003F RID: 63
		private static Dictionary<int, float> m_modDeMinScalaSegunParteHumana = new Dictionary<int, float>
		{
			{ 26, 0.8f },
			{ 24, 1f },
			{ 22, 0.8f },
			{ 23, 0.9f },
			{ 2, 0.9f },
			{ 25, 0.9f },
			{ 34, 0.85f },
			{ 28, 1f },
			{ 32, 1f },
			{ 31, 1f },
			{ 30, 1f }
		};
	}
}
