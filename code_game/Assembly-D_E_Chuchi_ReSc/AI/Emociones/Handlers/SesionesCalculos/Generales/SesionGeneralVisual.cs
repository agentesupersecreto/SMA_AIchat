using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004C8 RID: 1224
	public class SesionGeneralVisual : SessionGeneral<CalculoDeEmocionesPorSerVisto, CalculoDeEstimuloVisualResultado, SesionGeneralVisual, SesionGeneralVisual.Resultado, EstimuloVisual, TipoDeEstimuloVisual>, ISesionGeneralVisual, ICalculadorDeSessionDeTipoConResultado<CalculoDeEstimuloVisualResultado, EstimuloVisual, TipoDeEstimuloVisual, DireccionDeEstimulo>, ICalculadorDeSessionDeTipo<TipoDeEstimuloVisual, DireccionDeEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<CalculoDeEstimuloVisualResultado, EstimuloVisual>, ICalculadorDeSessionConResultado<CalculoDeEstimuloVisualResultado, EstimuloVisual>, ICalculadorDeSessionDeCalculosDeEstimulo<EstimuloVisual>
	{
		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06001CE6 RID: 7398 RVA: 0x00004252 File Offset: 0x00002452
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06001CE7 RID: 7399 RVA: 0x00071BB3 File Offset: 0x0006FDB3
		public override TipoDeEstimuloVisual tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x00071BBB File Offset: 0x0006FDBB
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloVisual enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloVisualResultado calculo)
		{
			return calculo.estimulo.tipoDeEstimuloVisual == enumerable && calculo.estimuloBasico.tipo == direccion;
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x00071BDB File Offset: 0x0006FDDB
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001402 RID: 5122
		[SerializeField]
		private TipoDeEstimuloVisual m_paraTipo;

		// Token: 0x020004C9 RID: 1225
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEmocionesPorSerVisto, CalculoDeEstimuloVisualResultado, SesionGeneralVisual, SesionGeneralVisual.Resultado, EstimuloVisual, TipoDeEstimuloVisual, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
