using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007F RID: 127
	public abstract class RangosDeGeneracionParaPenetraAnchura<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorPenetracionRecibidaComplete
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000E600 File Offset: 0x0000C800
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000E638 File Offset: 0x0000C838
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetro;
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000E63B File Offset: 0x0000C83B
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000E64C File Offset: 0x0000C84C
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
			this.m_calculador.SimularAnchura(estimulante, femalePenetracionTipo, 1f, out rangeValueV, out estado, out estado2, ref emocionesFemeninasValues);
			rangoMinimo = rangeValueV.min * 100f * base.character.escala;
			rangoMaximo = rangeValueV.max * 100f * base.character.escala;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000E6FB File Offset: 0x0000C8FB
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000F8 RID: 248
		private TCalculador m_calculador;
	}
}
