using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002EB RID: 747
	public interface ICalculoDeEstimuloConEstado : ICalculoDeEstimuloGenerando, ICalculoDeEstimulo
	{
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06001091 RID: 4241
		bool esSingleEstado { get; }

		// Token: 0x06001092 RID: 4242
		void GetSingleEstado(out UmbralBasico.Estado estado);

		// Token: 0x06001093 RID: 4243
		void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado);

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06001094 RID: 4244
		int cantidadDeEstados { get; }

		// Token: 0x06001095 RID: 4245
		void GetEstadoCopia(int index, out UmbralBasico.Estado estado);

		// Token: 0x06001096 RID: 4246
		void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado);

		// Token: 0x06001097 RID: 4247
		[Obsolete("", true)]
		UmbralBasico.Estado EstadoMasFuerte();

		// Token: 0x06001098 RID: 4248
		[Obsolete("", true)]
		void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte);
	}
}
