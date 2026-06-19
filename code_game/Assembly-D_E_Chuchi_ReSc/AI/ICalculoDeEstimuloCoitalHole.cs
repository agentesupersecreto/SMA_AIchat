using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002F9 RID: 761
	public interface ICalculoDeEstimuloCoitalHole : ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario
	{
		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060010A6 RID: 4262
		[Obsolete("", true)]
		UmbralBasico.Estado penetracion { get; }

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060010A7 RID: 4263
		[Obsolete("", true)]
		UmbralBasico.Estado apertura { get; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x060010A8 RID: 4264
		[Obsolete("", true)]
		UmbralBasico.Estado movimiento { get; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x060010A9 RID: 4265
		[Obsolete("", true)]
		UmbralBasico.Estado profundidad { get; }

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060010AA RID: 4266
		[Obsolete("", true)]
		UmbralBasico.Estado anchura { get; }

		// Token: 0x060010AB RID: 4267
		void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura);

		// Token: 0x060010AC RID: 4268
		void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado);

		// Token: 0x060010AD RID: 4269
		void SetEstadoAny(ref UmbralBasico.Estado estado);
	}
}
