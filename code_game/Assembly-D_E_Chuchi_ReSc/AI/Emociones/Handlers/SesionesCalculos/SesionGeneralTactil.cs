using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004B6 RID: 1206
	public sealed class SesionGeneralTactil : SessionGeneral<CalculoDeEstimuloPorTactilesRecibidos, CalculoDeEstimuloPorCariciasResultado, SesionGeneralTactil, SesionGeneralTactil.Resultado, EstimuloTactil, TipoDeEstimuloTactil>, ISesionGeneralTactil, ICalculadorDeSessionDeTipoConResultado<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil, TipoDeEstimuloTactil, DireccionDeEstimulo>, ICalculadorDeSessionDeTipo<TipoDeEstimuloTactil, DireccionDeEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil>, ICalculadorDeSessionConResultado<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil>, ICalculadorDeSessionDeCalculosDeEstimulo<EstimuloTactil>
	{
		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06001CB1 RID: 7345 RVA: 0x00071ABF File Offset: 0x0006FCBF
		public override DireccionDeEstimulo direccionDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraDireccion;
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06001CB2 RID: 7346 RVA: 0x00071AC7 File Offset: 0x0006FCC7
		public override TipoDeEstimuloTactil tipoDeEstimuloEnumerableV2
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x00071ACF File Offset: 0x0006FCCF
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloTactil enumerable, DireccionDeEstimulo direccion, CalculoDeEstimuloPorCariciasResultado calculo)
		{
			return calculo.estimulo.tipoDeEstimuloTactil == enumerable && calculo.estimulo.tipo == direccion;
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x00071AEF File Offset: 0x0006FCEF
		protected override double ObtenerPrioridad()
		{
			return (double)this.m_paraTipo.Prioridad();
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040013FE RID: 5118
		[SerializeField]
		private TipoDeEstimuloTactil m_paraTipo;

		// Token: 0x040013FF RID: 5119
		[SerializeField]
		private DireccionDeEstimulo m_paraDireccion;

		// Token: 0x020004B7 RID: 1207
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimulo<CalculoDeEstimuloPorTactilesRecibidos, CalculoDeEstimuloPorCariciasResultado, SesionGeneralTactil, SesionGeneralTactil.Resultado, EstimuloTactil, TipoDeEstimuloTactil, DireccionDeEstimulo>.ResultadoDeSession
		{
		}
	}
}
