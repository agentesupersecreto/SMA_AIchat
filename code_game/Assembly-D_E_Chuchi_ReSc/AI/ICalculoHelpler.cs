using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002FA RID: 762
	public static class ICalculoHelpler
	{
		// Token: 0x060010AE RID: 4270 RVA: 0x0004995F File Offset: 0x00047B5F
		public static bool EstimuloInvertidoEsValidoOrDefault(this ICalculoDeInteracionEstimulante calc)
		{
			return !calc.estimuloBasico.tieneCopiaInvertida || calc.EstimuloInvertidoEsValido();
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x00049976 File Offset: 0x00047B76
		public static bool EstimuloInvertidoEsValido(this ICalculoDeInteracionEstimulante calc)
		{
			return calc != null && calc.estimuloBasico != null && calc.estimuloInvertidoBasico != null && calc.estimuloBasico.tieneCopiaInvertida && calc.estimuloInvertidoBasico.esCopiaInvertida;
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x000499A7 File Offset: 0x00047BA7
		public static void SortMasFuerteAlMasDebil(this List<ICalculoDeInteracionEstimulanteConEstado> calculos)
		{
			calculos.Sort(ICalculoHelpler.comparison);
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x000499B4 File Offset: 0x00047BB4
		public static TipoDeEstimuloCoitalSegundaria ObtenerTipoDeEstimuloCoitalSegundaria(this ICalculoDeEstimulo calculo, int estadoIndex)
		{
			ICalculoDeEstimuloCoitalHoleConSubTipoSegundario calculoDeEstimuloCoitalHoleConSubTipoSegundario = calculo as ICalculoDeEstimuloCoitalHoleConSubTipoSegundario;
			if (calculoDeEstimuloCoitalHoleConSubTipoSegundario == null)
			{
				return TipoDeEstimuloCoitalSegundaria.None;
			}
			return calculoDeEstimuloCoitalHoleConSubTipoSegundario.GetTipoDeEstimuloCoitalSegundariaDeIndex(estadoIndex);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x000499D4 File Offset: 0x00047BD4
		public static ICharacterUnico GetCharacter(this ICalculoDeInteracionEstimulante calculo)
		{
			if (calculo == null)
			{
				return null;
			}
			IInteracionEstimulanteBasicaPertenecibleDeCharacter estimuloBasico = calculo.estimuloBasico;
			if (estimuloBasico == null)
			{
				return null;
			}
			IPertenecibleDeCharacter pertenecibleDeCharacter = estimuloBasico.GetRealEstimulante as IPertenecibleDeCharacter;
			ICharacterUnico characterUnico;
			if (pertenecibleDeCharacter == null)
			{
				characterUnico = estimuloBasico.GetRealEstimulante as ICharacterUnico;
			}
			else
			{
				try
				{
					characterUnico = (Character)pertenecibleDeCharacter.GetRootOwner();
				}
				catch (Exception ex)
				{
					Debug.LogError("TODO: Para ahorrar tiempo no se implemento icharacter sino character directamente");
					throw ex;
				}
			}
			return characterUnico;
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x00049A3C File Offset: 0x00047C3C
		public static int ObtenerDireccionParaDialogos(this DireccionDeEstimulo direccion)
		{
			if (direccion != DireccionDeEstimulo.recibida)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x00049A44 File Offset: 0x00047C44
		public static int ObtenerDireccionParaDialogos(this ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				return 0;
			}
			if (calculoDeInteracionEstimulante.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x00049A6D File Offset: 0x00047C6D
		public static ParteDelCuerpoHumano PartePrincipalEstimulada(this ICalculoDeInteracionEstimulante calculo, bool usarInvertido)
		{
			if (usarInvertido)
			{
				return calculo.PartePrincipalEstimulada(calculo.estimuloInvertidoBasico);
			}
			return calculo.PartePrincipalEstimulada(calculo.estimuloBasico);
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x00049A8C File Offset: 0x00047C8C
		public static ParteDelCuerpoHumano PartePrincipalEstimulada(this ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.placer)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_0073;
						}
						return estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor);
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						goto IL_0063;
					}
					if (reaccion != ReaccionHumana.placer)
					{
						goto IL_0073;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion != ReaccionHumana.arousal)
				{
					if (reaccion != ReaccionHumana.miedo)
					{
						goto IL_0073;
					}
					goto IL_0063;
				}
			}
			else if (reaccion != ReaccionHumana.decepcion)
			{
				if (reaccion != ReaccionHumana.desHielo)
				{
					goto IL_0073;
				}
				return estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
			}
			return estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor);
			IL_0063:
			return estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor);
			IL_0073:
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x00049B2C File Offset: 0x00047D2C
		public static PrioridadDeParteDelCuerpoHumanoContexto PrioridadContexto(this ICalculoDeEstimulo calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.placer)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_005B;
						}
						return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
					}
					if (reaccion != ReaccionHumana.placer)
					{
						goto IL_005B;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion != ReaccionHumana.arousal)
				{
					if (reaccion != ReaccionHumana.miedo)
					{
						goto IL_005B;
					}
					return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
				}
			}
			else if (reaccion != ReaccionHumana.decepcion)
			{
				if (reaccion != ReaccionHumana.desHielo)
				{
					goto IL_005B;
				}
				return PrioridadDeParteDelCuerpoHumanoContexto.@fixed;
			}
			return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			IL_005B:
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x00049BB4 File Offset: 0x00047DB4
		public static void GetPenetracionEstado(this ICalculoDeEstimuloCoitalHole calculo, out UmbralBasico.Estado penetracion)
		{
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			UmbralBasico.Estado estado3;
			UmbralBasico.Estado estado4;
			calculo.GetEstados(out penetracion, out estado, out estado2, out estado3, out estado4);
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x00049BD0 File Offset: 0x00047DD0
		public static void GetProfundidadEstado(this ICalculoDeEstimuloCoitalHole calculo, out UmbralBasico.Estado profundidad)
		{
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			UmbralBasico.Estado estado3;
			UmbralBasico.Estado estado4;
			calculo.GetEstados(out estado, out estado2, out estado3, out profundidad, out estado4);
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x00049BEC File Offset: 0x00047DEC
		public static void GetAnchuraEstado(this ICalculoDeEstimuloCoitalHole calculo, out UmbralBasico.Estado anchura)
		{
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			UmbralBasico.Estado estado3;
			UmbralBasico.Estado estado4;
			calculo.GetEstados(out estado, out estado2, out estado3, out estado4, out anchura);
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x00049C08 File Offset: 0x00047E08
		[Obsolete("", true)]
		public static UmbralBasico.Estado GetMasFuerte(this ICalculoDeEstimuloCoitalHole calculo)
		{
			UmbralBasico.Estado penetracion = calculo.penetracion;
			UmbralBasico.Estado profundidad = calculo.profundidad;
			UmbralBasico.Estado anchura = calculo.anchura;
			UmbralBasico.Estado apertura = calculo.apertura;
			UmbralBasico.Estado movimiento = calculo.movimiento;
			if (penetracion.estimulacionGeneradaEnFrame >= profundidad.estimulacionGeneradaEnFrame && penetracion.estimulacionGeneradaEnFrame >= anchura.estimulacionGeneradaEnFrame && penetracion.estimulacionGeneradaEnFrame >= apertura.estimulacionGeneradaEnFrame && penetracion.estimulacionGeneradaEnFrame >= movimiento.estimulacionGeneradaEnFrame)
			{
				return penetracion;
			}
			if (profundidad.estimulacionGeneradaEnFrame >= penetracion.estimulacionGeneradaEnFrame && profundidad.estimulacionGeneradaEnFrame >= anchura.estimulacionGeneradaEnFrame && profundidad.estimulacionGeneradaEnFrame >= apertura.estimulacionGeneradaEnFrame && profundidad.estimulacionGeneradaEnFrame >= movimiento.estimulacionGeneradaEnFrame)
			{
				return profundidad;
			}
			if (anchura.estimulacionGeneradaEnFrame >= penetracion.estimulacionGeneradaEnFrame && anchura.estimulacionGeneradaEnFrame >= profundidad.estimulacionGeneradaEnFrame && anchura.estimulacionGeneradaEnFrame >= apertura.estimulacionGeneradaEnFrame && anchura.estimulacionGeneradaEnFrame >= movimiento.estimulacionGeneradaEnFrame)
			{
				return anchura;
			}
			if (apertura.estimulacionGeneradaEnFrame >= penetracion.estimulacionGeneradaEnFrame && apertura.estimulacionGeneradaEnFrame >= profundidad.estimulacionGeneradaEnFrame && apertura.estimulacionGeneradaEnFrame >= anchura.estimulacionGeneradaEnFrame && apertura.estimulacionGeneradaEnFrame >= movimiento.estimulacionGeneradaEnFrame)
			{
				return apertura;
			}
			if (movimiento.estimulacionGeneradaEnFrame >= penetracion.estimulacionGeneradaEnFrame && movimiento.estimulacionGeneradaEnFrame >= profundidad.estimulacionGeneradaEnFrame && movimiento.estimulacionGeneradaEnFrame >= anchura.estimulacionGeneradaEnFrame && movimiento.estimulacionGeneradaEnFrame >= apertura.estimulacionGeneradaEnFrame)
			{
				return movimiento;
			}
			throw new ArgumentOutOfRangeException("???????");
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x00049D90 File Offset: 0x00047F90
		[Obsolete("", true)]
		public static void GetMasFuerte(this ICalculoDeEstimuloCoitalHole calculo, out UmbralBasico.Estado masFuerte)
		{
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado2 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado3 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado4 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado5 = default(UmbralBasico.Estado);
			calculo.GetEstados(out estado, out estado4, out estado5, out estado2, out estado3);
			if (estado.estimulacionGeneradaEnFrame >= estado2.estimulacionGeneradaEnFrame && estado.estimulacionGeneradaEnFrame >= estado3.estimulacionGeneradaEnFrame && estado.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame && estado.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado;
				return;
			}
			if (estado2.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado2.estimulacionGeneradaEnFrame >= estado3.estimulacionGeneradaEnFrame && estado2.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame && estado2.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado2;
				return;
			}
			if (estado3.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado3.estimulacionGeneradaEnFrame >= estado2.estimulacionGeneradaEnFrame && estado3.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame && estado3.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado3;
				return;
			}
			if (estado4.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado4.estimulacionGeneradaEnFrame >= estado2.estimulacionGeneradaEnFrame && estado4.estimulacionGeneradaEnFrame >= estado3.estimulacionGeneradaEnFrame && estado4.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado4;
				return;
			}
			if (estado5.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado5.estimulacionGeneradaEnFrame >= estado2.estimulacionGeneradaEnFrame && estado5.estimulacionGeneradaEnFrame >= estado3.estimulacionGeneradaEnFrame && estado5.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado5;
				return;
			}
			throw new ArgumentOutOfRangeException("???????");
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x00049F48 File Offset: 0x00048148
		[Obsolete("", true)]
		public static void GetMasFuerteSinAnchuraNiProfundidad(this ICalculoDeEstimuloCoitalHole calculo, out UmbralBasico.Estado masFuerte)
		{
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado2 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado3 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado4 = default(UmbralBasico.Estado);
			UmbralBasico.Estado estado5 = default(UmbralBasico.Estado);
			calculo.GetEstados(out estado, out estado4, out estado5, out estado2, out estado3);
			if (estado.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame && estado.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado;
				return;
			}
			if (estado4.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado4.estimulacionGeneradaEnFrame >= estado5.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado4;
				return;
			}
			if (estado5.estimulacionGeneradaEnFrame >= estado.estimulacionGeneradaEnFrame && estado5.estimulacionGeneradaEnFrame >= estado4.estimulacionGeneradaEnFrame)
			{
				masFuerte = estado5;
				return;
			}
			throw new ArgumentOutOfRangeException("???????");
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0004A010 File Offset: 0x00048210
		public static double PrioridadVisual(this ICalculoDeEstimuloVisual calculo, EmocionesHumanasBase emos, EstimuloVisual estimulo, UmbralBasico.Estado? estado, ParteQuePuedeEstimular? estimulanteParte, double mod = 1.0, double adding = 0.0)
		{
			double num = (double)((estimulo == null) ? 1f : estimulo.tipoDeEstimuloVisual.Prioridad());
			mod *= (double)((estimulanteParte != null && estimulo.tipo == DireccionDeEstimulo.dada) ? 1000 : 1);
			return calculo.Prioridad(emos, estimulo, estado, estimulanteParte, num * mod, adding);
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x0004A068 File Offset: 0x00048268
		public static double PrioridadTactil(this ICalculoDeEstimuloTactil calculo, EmocionesHumanasBase emos, EstimuloTactil estimulo, UmbralBasico.Estado? estado, ParteQuePuedeEstimular? estimulanteParte, double mod = 1.0, double adding = 0.0)
		{
			double num = (double)((estimulo == null) ? 1f : estimulo.tipoDeEstimuloTactil.Prioridad());
			return calculo.Prioridad(emos, estimulo, estado, estimulanteParte, num * mod, adding);
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x0004A0A0 File Offset: 0x000482A0
		public static double PrioridadCoital(this ICalculoDeEstimuloCoitalHole calculo, EmocionesHumanasBase emos, EstimuloPenetrante estimulo, UmbralBasico.Estado? penetracion, UmbralBasico.Estado? apertura, UmbralBasico.Estado? movimiento, UmbralBasico.Estado? profundidad, UmbralBasico.Estado? anchura, ParteQuePuedeEstimular? estimulanteParte, double mod = 1.0, double adding = 0.0)
		{
			double num = mod;
			double num4;
			if (!calculo.emocion.reaccion.EsPositiva() && !(emos == null))
			{
				float num2 = 0.1f;
				float num3 = 1f;
				Emocion emocion = emos.ObtenerEmocion(calculo.emocion.reaccion);
				num4 = (double)Mathf.Lerp(num2, num3, ((emocion != null) ? new float?(emocion.value.mod.OutPow(2f)) : null).GetValueOrDefault(1f));
			}
			else
			{
				num4 = (double)1f;
			}
			mod = num * num4;
			double num5 = (double)((estimulo == null) ? 1f : estimulo.tipoDeEstimuloCoital.Prioridad());
			double num6 = ((penetracion == null) ? 1.0 : penetracion.Value.GetPrioridadSinPost());
			double num7 = ((apertura == null) ? 1.0 : apertura.Value.GetPrioridadSinPost());
			double num8 = ((movimiento == null) ? 1.0 : movimiento.Value.GetPrioridadSinPost());
			double num9 = ((profundidad == null) ? 1.0 : profundidad.Value.GetPrioridadSinPost());
			double num10 = ((anchura == null) ? 1.0 : anchura.Value.GetPrioridadSinPost());
			return calculo.Prioridad(estimulo, num6 + num7 + num8 + num9 + num10, estimulanteParte, num5 * mod, adding);
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0004A21C File Offset: 0x0004841C
		public static double Prioridad(this ICalculoDeEstimulo calculo, EmocionesHumanasBase emos, InteracionEstimulanteBasica estimulo, UmbralBasico.Estado? estado, ParteQuePuedeEstimular? estimulanteParte, double mod = 1.0, double adding = 0.0)
		{
			if (emos != null)
			{
				double num = mod;
				float num2 = 1f;
				float num3 = 100f;
				Emocion emocion = emos.ObtenerEmocion(calculo.emocion.reaccion);
				mod = num * (double)Mathf.Lerp(num2, num3, ((emocion != null) ? new float?(emocion.value.mod.InPow(12f)) : null).GetValueOrDefault(0f));
			}
			double num4 = ((estado == null) ? 1.0 : estado.Value.GetPrioridadSinPost());
			return calculo.Prioridad(estimulo, num4, estimulanteParte, mod, adding);
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0004A2C4 File Offset: 0x000484C4
		public static double Prioridad(this ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo, double estadoPrioridadSinPost, ParteQuePuedeEstimular? estimulanteParte, double mod = 1.0, double adding = 0.0)
		{
			double num = ((estimulo == null) ? 1.0 : estimulo.prioridad);
			double num2 = ((estimulanteParte == null) ? 1.0 : estimulanteParte.Value.Prioridad());
			return adding + num * estadoPrioridadSinPost * num2 * mod;
		}

		// Token: 0x04000D7C RID: 3452
		private static Comparison<ICalculoDeInteracionEstimulanteConEstado> comparison = (ICalculoDeInteracionEstimulanteConEstado a, ICalculoDeInteracionEstimulanteConEstado b) => b.estimuloGeneradoEnFrame.CompareTo(a.estimuloGeneradoEnFrame);
	}
}
