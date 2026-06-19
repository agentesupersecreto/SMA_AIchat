using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x0200009B RID: 155
	public interface IDataOfInteraccionMultArg
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000342 RID: 834
		// (set) Token: 0x06000343 RID: 835
		TipoDeEstimulo[] tipos { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000344 RID: 836
		// (set) Token: 0x06000345 RID: 837
		DireccionDeEstimulo direccion { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000346 RID: 838
		// (set) Token: 0x06000347 RID: 839
		ParteQuePuedeEstimular[] estiulantes { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000348 RID: 840
		// (set) Token: 0x06000349 RID: 841
		ParteDelCuerpoHumano[] estimuladas { get; set; }
	}
}
