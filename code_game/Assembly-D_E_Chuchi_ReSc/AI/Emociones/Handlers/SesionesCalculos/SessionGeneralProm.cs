using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A2 RID: 1186
	public abstract class SessionGeneralProm<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> : SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculador : ICalculadorDeEstimuloConCalculos, IActivable where TSelf : SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> where TResultWrapper : SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.ResultadoDeSession, IClearable, new() where T_TipoDeEstimuloSegundario : struct
	{
		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x00004252 File Offset: 0x00002452
		public virtual DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06001C18 RID: 7192 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public sealed override TipoDeCalculadorDeEstimulo tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.sesionGeneral;
			}
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x00070470 File Offset: 0x0006E670
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return calculo is ICalculoDeInteracionEstimulante && (calculo as ICalculoDeInteracionEstimulante).estimuloBasico.tipo == this.direccionDeEstimulo;
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Acumulado(TResultWrapper resultado, ICalculoDeEstimulo resultadoAcumulado, ICalculoDeEstimulo acumulando)
		{
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x00070494 File Offset: 0x0006E694
		protected override void Acumuladondo(TResultWrapper resultado, ICalculoDeEstimulo resultadoAcumulado, ICalculoDeEstimulo acumulando)
		{
			(resultadoAcumulado as ICalculoDeEstimuloDeParteEstimulante).estimulanteParte = (resultadoAcumulado as ICalculoDeEstimuloDeParteEstimulante).estimulanteParte;
		}

		// Token: 0x06001C1D RID: 7197 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
