using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.BeachGirl.Estimulos.Runtime
{
	// Token: 0x0200001F RID: 31
	public interface IInteracionEstimulanteBasica
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000EA RID: 234
		Guid estimuloID { get; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000EB RID: 235
		Guid estimuloOriginalID { get; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000EC RID: 236
		Guid estimuloInvertidoID { get; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000ED RID: 237
		bool esCopiaInvertida { get; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000EE RID: 238
		bool tieneCopiaInvertida { get; }

		// Token: 0x060000EF RID: 239
		ParteDelCuerpoHumano PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto contexto);

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000F0 RID: 240
		// (set) Token: 0x060000F1 RID: 241
		DireccionDeEstimulo tipo { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000F2 RID: 242
		// (set) Token: 0x060000F3 RID: 243
		Side side { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000F4 RID: 244
		// (set) Token: 0x060000F5 RID: 245
		TipoDeEstimulo tipoDeEstimulo { get; set; }
	}
}
