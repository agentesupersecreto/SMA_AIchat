using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x02000083 RID: 131
	public abstract class RangosDeGeneracionParaPenetraProfundidad<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorPenetracionRecibidaComplete
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000EA51 File Offset: 0x0000CC51
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000EA89 File Offset: 0x0000CC89
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetro;
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000EA8C File Offset: 0x0000CC8C
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000EAA0 File Offset: 0x0000CCA0
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
			this.m_calculador.SimularProfundidad(estimulante, femalePenetracionTipo, 1f, out rangeValueV, out estado, out estado2, ref emocionesFemeninasValues);
			rangoMinimo = rangeValueV.min * 100f * base.character.escala;
			rangoMaximo = rangeValueV.max * 100f * base.character.escala;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000EB4F File Offset: 0x0000CD4F
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000FC RID: 252
		private TCalculador m_calculador;
	}
}
