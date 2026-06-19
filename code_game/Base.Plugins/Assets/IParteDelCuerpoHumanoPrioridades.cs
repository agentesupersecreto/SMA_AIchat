using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x0200015C RID: 348
	public interface IParteDelCuerpoHumanoPrioridades
	{
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000A37 RID: 2615
		// (set) Token: 0x06000A38 RID: 2616
		Sexo para { get; set; }

		// Token: 0x06000A39 RID: 2617
		void UpdatePrioridades();

		// Token: 0x06000A3A RID: 2618
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A3B RID: 2619
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A3C RID: 2620
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A3D RID: 2621
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A3E RID: 2622
		ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A3F RID: 2623
		ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null);

		// Token: 0x06000A40 RID: 2624
		float PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte);

		// Token: 0x06000A41 RID: 2625
		float PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte);

		// Token: 0x06000A42 RID: 2626
		float PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte);

		// Token: 0x06000A43 RID: 2627
		IParteDelCuerpoHumanoPrioridadesContexto ObtenerContexto(PrioridadDeParteDelCuerpoHumanoContexto contexto);
	}
}
