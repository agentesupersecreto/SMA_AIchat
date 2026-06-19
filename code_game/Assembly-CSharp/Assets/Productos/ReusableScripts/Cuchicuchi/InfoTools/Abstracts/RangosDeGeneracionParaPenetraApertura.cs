using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x02000080 RID: 128
	public abstract class RangosDeGeneracionParaPenetraApertura<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorPenetracionRecibidaAdvance
	{
		// Token: 0x06000256 RID: 598 RVA: 0x0000E717 File Offset: 0x0000C917
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0000E74F File Offset: 0x0000C94F
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetroPorSegundo;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000E752 File Offset: 0x0000C952
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000E764 File Offset: 0x0000C964
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
			RangeValueV2 rangeValueV;
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			this.m_calculador.SimularApertura(estimulante, femalePenetracionTipo, 1f, out rangeValueV, out estado, out estado2);
			rangoMinimo = rangeValueV.min * 100f * base.character.escala;
			rangoMaximo = rangeValueV.max * 100f * base.character.escala;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000E809 File Offset: 0x0000CA09
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000F9 RID: 249
		private TCalculador m_calculador;
	}
}
