using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x0200049F RID: 1183
	public abstract class SessionGeneral<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable> : SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, DireccionDeEstimulo> where TCalculador : ICalculadorDeEstimulo<TCalculoResult>, IActivable where TCalculoResult : ICalculoDeEstimulo<TEstimulo>, ICalculoDeEstimuloGenerando, IConvinable, IClearable, ICopiableA, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloPrioridadModificable, new() where TSelf : SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, DireccionDeEstimulo> where TResultWrapper : SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, DireccionDeEstimulo>.ResultadoDeSession, IClearable, new() where TEstimulo : InteracionEstimulanteBasica where T_TipoDeEstimuloEnumerable : struct
	{
		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06001C10 RID: 7184 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public sealed override TipoDeCalculadorDeEstimulo tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.sesionGeneral;
			}
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool EsAcumulable(TCalculoResult calculo)
		{
			return true;
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Acumulado(TResultWrapper resultado, TCalculoResult resultadoAcumulado, TCalculoResult acumulando)
		{
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x0007044C File Offset: 0x0006E64C
		protected override void Acumuladondo(TResultWrapper resultado, TCalculoResult resultadoAcumulado, TCalculoResult acumulando)
		{
			resultadoAcumulado.estimulanteParte = acumulando.estimulanteParte;
		}
	}
}
