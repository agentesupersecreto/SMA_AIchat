using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x0200015D RID: 349
	public interface IParteDelCuerpoHumanoPrioridadesContexto
	{
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000A44 RID: 2628
		// (set) Token: 0x06000A45 RID: 2629
		Sexo para { get; set; }

		// Token: 0x06000A46 RID: 2630
		void UpdatePrioridades();

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000A47 RID: 2631
		PrioridadDeParteDelCuerpoHumanoContexto contexto { get; }

		// Token: 0x06000A48 RID: 2632
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A49 RID: 2633
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A4A RID: 2634
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A4B RID: 2635
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A4C RID: 2636
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A4D RID: 2637
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A4E RID: 2638
		float PrioridadVisual(ParteDelCuerpoHumano parte);

		// Token: 0x06000A4F RID: 2639
		float PrioridadTactil(ParteDelCuerpoHumano parte);

		// Token: 0x06000A50 RID: 2640
		float PrioridadCoital(ParteDelCuerpoHumano parte);
	}
}
