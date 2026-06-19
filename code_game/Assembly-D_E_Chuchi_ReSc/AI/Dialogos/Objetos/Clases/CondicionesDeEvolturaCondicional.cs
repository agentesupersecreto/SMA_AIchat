using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000544 RID: 1348
	[Serializable]
	public class CondicionesDeEvolturaCondicional
	{
		// Token: 0x0600211B RID: 8475 RVA: 0x0007B6C0 File Offset: 0x000798C0
		public float Puntaje(ICalculoDeEstimulo calculo)
		{
			if (calculo == null)
			{
				return 0f;
			}
			float num = CondicionesDeEvolturaCondicional.PuntajeDeReaccion(calculo, this.reaccion);
			if (num <= 0f)
			{
				return 0f;
			}
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			float num2 = CondicionesDeEvolturaCondicional.PuntajeDeTipoEstimulo(calculoDeInteracionEstimulante, this.tipoDeEstimulo);
			if (num2 <= 0f)
			{
				return 0f;
			}
			float num3 = CondicionesDeEvolturaCondicional.PuntajeDeDireccionEstimulo(calculoDeInteracionEstimulante, this.direccionDeEstimulo);
			if (num3 <= 0f)
			{
				return 0f;
			}
			float num4 = CondicionesDeEvolturaCondicional.PuntajeDeEstimulante(calculo as ICalculoDeEstimuloDeParteEstimulante, this.estimulante);
			if (num4 <= 0f)
			{
				return 0f;
			}
			float num5 = CondicionesDeEvolturaCondicional.PuntajeDeEstimulada(calculoDeInteracionEstimulante, this.estimulada);
			if (num5 <= 0f)
			{
				return 0f;
			}
			float num6 = CondicionesDeEvolturaCondicional.PuntajeDeTipoDeCalculo(calculo, this.tipoDeCalculo);
			if (num6 <= 0f)
			{
				return 0f;
			}
			return Mathf.Pow(num * num2 * num3 * num4 * num5 * num6, 0.16666667f);
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x0007B7A8 File Offset: 0x000799A8
		private static float PuntajeDeReaccion(ICalculoDeEstimulo calculo, ParesDeReaccion pares)
		{
			if (calculo == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeReaccion, ReaccionHumana>(pares);
			}
			Emocion emocion = calculo.emocion;
			if (emocion == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeReaccion, ReaccionHumana>(pares);
			}
			ParDeReaccion parDeReaccion;
			bool flag = pares.ContieneFlag(emocion.reaccion, out parDeReaccion);
			if (pares.invertirFlags)
			{
				if (flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeReaccion, ReaccionHumana>(pares);
				}
				return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
			}
			else
			{
				if (!flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeReaccion, ReaccionHumana>(pares);
				}
				return Mathf.Clamp(parDeReaccion.puntaje, 0f, 100f) / 100f * pares.modDePuntaje;
			}
		}

		// Token: 0x0600211D RID: 8477 RVA: 0x0007B84C File Offset: 0x00079A4C
		private static float PuntajeDeTipoEstimulo(ICalculoDeInteracionEstimulante calculo, ParesTipoDeEstimulo pares)
		{
			if (calculo == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeTipoDeEstimulo, TipoDeEstimulo>(pares);
			}
			InteracionEstimulanteBasica estimuloBasico = calculo.estimuloBasico;
			if (estimuloBasico == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeTipoDeEstimulo, TipoDeEstimulo>(pares);
			}
			ParDeTipoDeEstimulo parDeTipoDeEstimulo;
			bool flag = pares.ContieneFlag(estimuloBasico.tipoDeEstimulo, out parDeTipoDeEstimulo);
			if (pares.invertirFlags)
			{
				if (flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeTipoDeEstimulo, TipoDeEstimulo>(pares);
				}
				return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
			}
			else
			{
				if (!flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeTipoDeEstimulo, TipoDeEstimulo>(pares);
				}
				return Mathf.Clamp(parDeTipoDeEstimulo.puntaje, 0f, 100f) / 100f * pares.modDePuntaje;
			}
		}

		// Token: 0x0600211E RID: 8478 RVA: 0x0007B8EC File Offset: 0x00079AEC
		private static float PuntajeDeDireccionEstimulo(ICalculoDeInteracionEstimulante calculo, ParesDireccionDeEstimulo pares)
		{
			if (calculo == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeDirrecionDeEstimulo, DireccionDeEstimulo>(pares);
			}
			InteracionEstimulanteBasica estimuloBasico = calculo.estimuloBasico;
			if (estimuloBasico == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeDirrecionDeEstimulo, DireccionDeEstimulo>(pares);
			}
			ParDeDirrecionDeEstimulo parDeDirrecionDeEstimulo;
			bool flag = pares.ContieneFlag(estimuloBasico.tipo, out parDeDirrecionDeEstimulo);
			if (pares.invertirFlags)
			{
				if (flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeDirrecionDeEstimulo, DireccionDeEstimulo>(pares);
				}
				return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
			}
			else
			{
				if (!flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDeDirrecionDeEstimulo, DireccionDeEstimulo>(pares);
				}
				return Mathf.Clamp(parDeDirrecionDeEstimulo.puntaje, 0f, 100f) / 100f * pares.modDePuntaje;
			}
		}

		// Token: 0x0600211F RID: 8479 RVA: 0x0007B98C File Offset: 0x00079B8C
		private static float PuntajeDeEstimulante(ICalculoDeEstimuloDeParteEstimulante calculo, ParesPartesEstimulantes pares)
		{
			if (calculo == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesEstimulantes, ParteQuePuedeEstimular>(pares);
			}
			ParteQuePuedeEstimular estimulanteParte = calculo.estimulanteParte;
			if (estimulanteParte == ParteQuePuedeEstimular.None)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesEstimulantes, ParteQuePuedeEstimular>(pares);
			}
			ParDePartesEstimulantes parDePartesEstimulantes;
			bool flag = pares.ContieneFlag(estimulanteParte, out parDePartesEstimulantes);
			if (pares.invertirFlags)
			{
				if (flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesEstimulantes, ParteQuePuedeEstimular>(pares);
				}
				return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
			}
			else
			{
				if (!flag)
				{
					return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesEstimulantes, ParteQuePuedeEstimular>(pares);
				}
				return Mathf.Clamp(parDePartesEstimulantes.puntaje, 0f, 100f) / 100f * pares.modDePuntaje;
			}
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x0007BA24 File Offset: 0x00079C24
		private static float PuntajeDeEstimulada(ICalculoDeInteracionEstimulante calculo, ParesPartesHumanas pares)
		{
			if (calculo == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesHumanas, ParteDelCuerpoHumano>(pares);
			}
			InteracionEstimulanteBasica estimuloBasico = calculo.estimuloBasico;
			if (estimuloBasico == null)
			{
				return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesHumanas, ParteDelCuerpoHumano>(pares);
			}
			int i = 0;
			while (i < estimuloBasico.partesDelCuerpoHumanoEstimuladas.Count)
			{
				ParDePartesHumanas parDePartesHumanas;
				bool flag = pares.ContieneFlag(estimuloBasico.partesDelCuerpoHumanoEstimuladas[i], out parDePartesHumanas);
				if (pares.invertirFlags)
				{
					if (flag)
					{
						return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesHumanas, ParteDelCuerpoHumano>(pares);
					}
					return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
				}
				else
				{
					if (flag)
					{
						return Mathf.Clamp(parDePartesHumanas.puntaje, 0f, 100f) / 100f * pares.modDePuntaje;
					}
					i++;
				}
			}
			return CondicionesDeEvolturaCondicional.DevolverMinimoDe<ParDePartesHumanas, ParteDelCuerpoHumano>(pares);
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0007BAE0 File Offset: 0x00079CE0
		private static float PuntajeDeTipoDeCalculo(ICalculoDeEstimulo calculo, TipoDeCalculoYTipoDeCalculador par)
		{
			if (calculo == null)
			{
				return 0f;
			}
			int tipo = (int)calculo.tipo;
			int num;
			if (calculo.producidoPor == null)
			{
				num = 0;
			}
			else
			{
				num = (int)calculo.producidoPor.tipo;
			}
			if (!((int)par.calculador).HasFlag(num))
			{
				return 0f;
			}
			if (!((int)par.calculo).HasFlag(tipo))
			{
				return 0f;
			}
			float num2 = 1f;
			switch (calculo.tipo)
			{
			case TipoDeCalculoDeEstimulo.None:
				num2 *= 0.1f;
				goto IL_00D6;
			case TipoDeCalculoDeEstimulo.frame:
				num2 *= 0.5f;
				goto IL_00D6;
			case TipoDeCalculoDeEstimulo.sesionComienza:
				num2 *= 0.95f;
				goto IL_00D6;
			case TipoDeCalculoDeEstimulo.sesionEnCurso:
				num2 *= 0.75f;
				goto IL_00D6;
			case TipoDeCalculoDeEstimulo.sesionTermina:
				num2 *= 1f;
				goto IL_00D6;
			}
			throw new ArgumentOutOfRangeException(calculo.tipo.ToString());
			IL_00D6:
			if (calculo.producidoPor != null)
			{
				TipoDeCalculadorDeEstimulo tipo2 = calculo.producidoPor.tipo;
				switch (tipo2)
				{
				case TipoDeCalculadorDeEstimulo.None:
					return num2 * 0.1f;
				case TipoDeCalculadorDeEstimulo.frame:
					return num2 * 0.6f;
				case TipoDeCalculadorDeEstimulo.sesionEspecifica:
					return num2 * 0.9f;
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					break;
				case TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					return num2 * 1f;
				case TipoDeCalculadorDeEstimulo.sesionGeneral:
					return num2 * 0.7f;
				default:
					if (tipo2 == TipoDeCalculadorDeEstimulo.sesionGeneralDe)
					{
						return num2 * 0.8f;
					}
					if (tipo2 == TipoDeCalculadorDeEstimulo.sesionGeneralDeTipoDeCualquierEmocion)
					{
						return num2 * 0.65f;
					}
					break;
				}
				throw new ArgumentOutOfRangeException(calculo.producidoPor.tipo.ToString());
			}
			return num2;
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x0007BC7B File Offset: 0x00079E7B
		private static float DevolverMinimoDe<T_Par, T_Flag>(BaseParesInt<T_Par, T_Flag> pares) where T_Par : BaseParInt<T_Flag>
		{
			if (pares.cualquieraConfig.cualquieraFlag)
			{
				return Mathf.Clamp(pares.cualquieraConfig.puntajeParaCualquiera, 0f, 100f) / 100f * pares.modDePuntaje;
			}
			return 0f;
		}

		// Token: 0x0400157E RID: 5502
		public const float puntajeMinimo = 0f;

		// Token: 0x0400157F RID: 5503
		[Space]
		public ParesDeReaccion reaccion = new ParesDeReaccion();

		// Token: 0x04001580 RID: 5504
		[Space]
		public TipoDeCalculoYTipoDeCalculador tipoDeCalculo = new TipoDeCalculoYTipoDeCalculador();

		// Token: 0x04001581 RID: 5505
		[Space]
		public ParesTipoDeEstimulo tipoDeEstimulo = new ParesTipoDeEstimulo();

		// Token: 0x04001582 RID: 5506
		[Space]
		public ParesDireccionDeEstimulo direccionDeEstimulo = new ParesDireccionDeEstimulo();

		// Token: 0x04001583 RID: 5507
		[Space]
		public ParesPartesEstimulantes estimulante = new ParesPartesEstimulantes();

		// Token: 0x04001584 RID: 5508
		[Space]
		public ParesPartesHumanas estimulada = new ParesPartesHumanas();
	}
}
