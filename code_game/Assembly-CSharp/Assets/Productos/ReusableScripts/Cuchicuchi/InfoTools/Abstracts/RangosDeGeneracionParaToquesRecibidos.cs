using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x02000084 RID: 132
	public abstract class RangosDeGeneracionParaToquesRecibidos<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000EB6B File Offset: 0x0000CD6B
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600026F RID: 623 RVA: 0x0000EBA3 File Offset: 0x0000CDA3
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetroPorSegundo;
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000EBA8 File Offset: 0x0000CDA8
		protected override void Simular(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, out float rangoMinimo, out float rangoMaximo, out float generacionMinima, out float generacionMaxima)
		{
			RangeValueV2 rangeValueV;
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			float num;
			UmbralBasico.TipoDeCambio tipoDeCambio;
			this.m_calculador.SimularGlobal(estimulante, estimulada, 1f, out rangeValueV, out estado, out estado2, out num, out tipoDeCambio, null);
			rangoMinimo = rangeValueV.min * 100f;
			rangoMaximo = rangeValueV.max * 100f;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000EC13 File Offset: 0x0000CE13
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000FD RID: 253
		private TCalculador m_calculador;
	}
}
