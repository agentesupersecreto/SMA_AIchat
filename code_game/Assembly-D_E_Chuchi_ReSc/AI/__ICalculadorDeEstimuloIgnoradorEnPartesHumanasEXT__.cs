using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002CD RID: 717
	public static class __ICalculadorDeEstimuloIgnoradorEnPartesHumanasEXT__
	{
		// Token: 0x06001027 RID: 4135 RVA: 0x000492A4 File Offset: 0x000474A4
		public static void IgnorarPartesHumanas(this ICalculadorDeEstimuloIgnoradorEnPartesHumanas ignorador, IList<ParteDelCuerpoHumano> partes, bool ignorar)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				ignorador.IgnorarParteHumana(partes[i], ignorar);
			}
		}
	}
}
