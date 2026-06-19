using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x02000082 RID: 130
	public abstract class RangosDeGeneracionParaPenetraMovimiento<TCalculador> : RangosDeGeneracionPara where TCalculador : CalculoDeEstimuloPorPenetracionRecibidaAdvance
	{
		// Token: 0x06000262 RID: 610 RVA: 0x0000E941 File Offset: 0x0000CB41
		public override void Actualizar()
		{
			this.m_calculador = this.GetComponentEnRoot(false);
			if (this.m_calculador == null)
			{
				throw new ArgumentNullException("m_calculador", "m_calculador null reference.");
			}
			base.Actualizar();
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000E979 File Offset: 0x0000CB79
		protected override RangosDeGeneracionPara.UnidadDeRango display
		{
			get
			{
				return RangosDeGeneracionPara.UnidadDeRango.centimetroPorSegundo;
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000E97C File Offset: 0x0000CB7C
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return estimulada != ParteDelCuerpoHumano.bocaInterno && estimulada - ParteDelCuerpoHumano.ano > 1;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000E990 File Offset: 0x0000CB90
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
			this.m_calculador.SimularMovimiento(estimulante, femalePenetracionTipo, 1f, out rangeValueV, out estado, out estado2);
			rangoMinimo = rangeValueV.min * 100f * base.character.escala;
			rangoMaximo = rangeValueV.max * 100f * base.character.escala;
			generacionMinima = estado.estimulacionGeneradaEnFrame;
			generacionMaxima = estado2.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000EA35 File Offset: 0x0000CC35
		public override void Clear()
		{
			base.Clear();
			this.m_calculador = default(TCalculador);
		}

		// Token: 0x040000FB RID: 251
		private TCalculador m_calculador;
	}
}
