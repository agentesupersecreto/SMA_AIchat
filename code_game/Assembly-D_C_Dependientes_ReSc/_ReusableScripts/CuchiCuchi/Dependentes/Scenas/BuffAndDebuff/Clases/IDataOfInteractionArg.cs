using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x0200009A RID: 154
	public interface IDataOfInteractionArg
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600033A RID: 826
		// (set) Token: 0x0600033B RID: 827
		TipoDeEstimulo tipo { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600033C RID: 828
		// (set) Token: 0x0600033D RID: 829
		DireccionDeEstimulo direccion { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600033E RID: 830
		// (set) Token: 0x0600033F RID: 831
		ParteQuePuedeEstimular estiulante { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000340 RID: 832
		// (set) Token: 0x06000341 RID: 833
		ParteDelCuerpoHumano[] estimuladas { get; set; }
	}
}
