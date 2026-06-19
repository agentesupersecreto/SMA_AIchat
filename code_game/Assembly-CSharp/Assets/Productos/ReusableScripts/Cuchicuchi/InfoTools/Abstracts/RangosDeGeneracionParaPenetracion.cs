using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x02000081 RID: 129
	public abstract class RangosDeGeneracionParaPenetracion<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorPenetracionRecibida
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0000E825 File Offset: 0x0000CA25
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000E85D File Offset: 0x0000CA5D
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetroPorSegundo;
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000E860 File Offset: 0x0000CA60
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000E874 File Offset: 0x0000CA74
		protected override void Simular(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, out float rangoMinimo, out float rangoMaximo, out float generacionMinima, out float generacionMaxima)
		{
			FemalePenetracionTipo femalePenetracionTipo;
			if (estimulada != ParteDelCuerpoHumano.bocaInterno)
			{
				if (estimulada != ParteDelCuerpoHumano.ano)
				{
					if (estimulada != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(estimulada.ToString());
					}
					femalePenetracionTipo = FemalePenetracionTipo.vag;
				}
				else
				{
					femalePenetracionTipo = FemalePenetracionTipo.anus;
				}
			}
			else
			{
				femalePenetracionTipo = FemalePenetracionTipo.facial;
			}
			EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
			RangeValueV2 rangeValueV;
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			float num;
			this.m_calculador.SimularPenetracion(estimulante, femalePenetracionTipo, 1f, out rangeValueV, out estado, out estado2, out num, ref emocionesFemeninasValues);
			rangoMinimo = rangeValueV.min * 100f * base.character.escala;
			rangoMaximo = rangeValueV.max * 100f * base.character.escala;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000E925 File Offset: 0x0000CB25
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000FA RID: 250
		private TCalculador m_calculador;
	}
}
