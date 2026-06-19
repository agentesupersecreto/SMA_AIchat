using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004BF RID: 1215
	public class SesionGeneralCoital : SessionGeneral<CalculoDeEstimuloPorPenetracionRecibida, CalculoDeEstimuloPorPenetracionHoleResultado, SesionGeneralCoital, SesionGeneralCoital.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital>, ISesionGeneralCoital, ICalculadorDeSessionDeTipoConResultado<CalculoDeEstimuloPorPenetracionHoleResultado, EstimuloPenetrante, TipoDeEstimuloCoital, DireccionDeEstimulo>, ICalculadorDeSessionDeTipo<TipoDeEstimuloCoital, DireccionDeEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<CalculoDeEstimuloPorPenetracionHoleResultado, EstimuloPenetrante>, ICalculadorDeSessionConResultado<CalculoDeEstimuloPorPenetracionHoleResultado, EstimuloPenetrante>, ICalculadorDeSessionDeCalculosDeEstimulo<EstimuloPenetrante>
	{
		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06001CCA RID: 7370 RVA: 0x00071B25 File Offset: 0x0006FD25
		public override TipoDeEstimuloCoital tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06001CCB RID: 7371 RVA: 0x00071B2D File Offset: 0x0006FD2D
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraDireccion;
			}
		}

		// Token: 0x06001CCC RID: 7372 RVA: 0x00071B35 File Offset: 0x0006FD35
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloCoital enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorPenetracionHoleResultado calculo)
		{
			return calculo.estimulo.tipoDeEstimuloCoital == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001CCD RID: 7373 RVA: 0x00071B55 File Offset: 0x0006FD55
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001CCE RID: 7374 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001CCF RID: 7375 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001CD0 RID: 7376 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001CD4 RID: 7380 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001400 RID: 5120
		[SerializeField]
		private TipoDeEstimuloCoital m_paraTipo;

		// Token: 0x04001401 RID: 5121
		[SerializeField]
		private DireccionDeEstimulo m_paraDireccion;

		// Token: 0x020004C0 RID: 1216
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEstimuloPorPenetracionRecibida, CalculoDeEstimuloPorPenetracionHoleResultado, SesionGeneralCoital, SesionGeneralCoital.Resultado, EstimuloPenetrante, TipoDeEstimuloCoital, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
