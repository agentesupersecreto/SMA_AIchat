using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000331 RID: 817
	public static class TraitHumanoHelper
	{
		// Token: 0x060011AB RID: 4523 RVA: 0x0004B938 File Offset: 0x00049B38
		public static bool EsTraitsDeServicing(this TraitHumano trait)
		{
			return TraitHumanoHelper.traitsDeServicing.Contains((int)trait);
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x0004B945 File Offset: 0x00049B45
		public static bool EsTraitsDeGustoPorHombres(this TraitHumano trait)
		{
			return TraitHumanoHelper.traitsDeGustosPorHombres.Contains((int)trait);
		}

		// Token: 0x04000E7E RID: 3710
		public static readonly IReadOnlyCollection<int> traitsDeServicing = new HashSet<int> { 92, 101, 102 };

		// Token: 0x04000E7F RID: 3711
		public static readonly IReadOnlyCollection<int> traitsDeGustosPorHombres = new HashSet<int>
		{
			42, 43, 44, 45, 46, 104, 105, 21, 26, 22,
			24, 23, 25, 27, 28, 29
		};
	}
}
