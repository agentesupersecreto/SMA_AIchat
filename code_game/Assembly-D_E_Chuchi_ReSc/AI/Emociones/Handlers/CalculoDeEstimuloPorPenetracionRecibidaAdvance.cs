using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000486 RID: 1158
	public abstract class CalculoDeEstimuloPorPenetracionRecibidaAdvance : CalculoDeEstimuloPorPenetracionRecibida
	{
		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06001A51 RID: 6737
		protected abstract DatosDeUmbral datosDeUmbralApertura { get; }

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06001A52 RID: 6738
		protected abstract DatosDeUmbral datosDeUmbralMovimiento { get; }

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001A53 RID: 6739
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Movimiento { get; }

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001A54 RID: 6740
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Movimiento { get; }

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06001A55 RID: 6741
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Apertura { get; }

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x06001A56 RID: 6742
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Apertura { get; }

		// Token: 0x06001A57 RID: 6743 RVA: 0x00069DCC File Offset: 0x00067FCC
		protected override bool PoblarConData(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, CalculoDeEstimuloPorPenetracionHoleResultado resultado)
		{
			bool flag = base.PoblarConData(grupoDeParte, grupoDeParteEstimulante, deltaTime, penetracion, resultado);
			bool flag2 = false;
			bool flag3 = false;
			if (this.generarPorApertura)
			{
				RangeValueV2 rangeValueV;
				flag2 = this.PoblarAperturaData(grupoDeParte, grupoDeParteEstimulante, deltaTime, penetracion, ref resultado.data.apertura, out rangeValueV, this.datosDeUmbralApertura, true);
			}
			return flag || flag2 || flag3;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00069E17 File Offset: 0x00068017
		protected override float CalcularSubResultado(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, CalculoDeEstimuloPorPenetracionHoleResultado d)
		{
			return base.CalcularSubResultado(grupoDeParte, grupoDeParteEstimulante, d) + base.CalcularDeEstado(grupoDeParte, grupoDeParteEstimulante, ref d.data.apertura) + base.CalcularDeEstado(grupoDeParte, grupoDeParteEstimulante, ref d.data.movimiento);
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x00069E4C File Offset: 0x0006804C
		public void SimularApertura(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulante);
			}
			PenetracionesByMainInFrame.Penetracion penetracion = new PenetracionesByMainInFrame.Penetracion(true);
			penetracion.tipo = tipo;
			EstimuloPenetrante estimuloPenetrante = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante.velocidadDeCambios = new PenetrationInfoLocal
			{
				aperturaLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarAperturaData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref estado, out intervalo, this.datosDeUmbralApertura, false);
			EstimuloPenetrante estimuloPenetrante2 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante2, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante2.velocidadDeCambios = new PenetrationInfoLocal
			{
				aperturaLocal = intervalo.min + 1E-05f
			};
			minGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV;
			this.PoblarAperturaData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref minGenerado, out rangeValueV, this.datosDeUmbralApertura, false);
			base.AplicarModificadoresDeGeneracion(ref minGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante3, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante3.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante3.velocidadDeCambios = new PenetrationInfoLocal
			{
				aperturaLocal = Mathf.Lerp(intervalo.min, intervalo.max, this.datosDeUmbralApertura.promedioMod)
			};
			maxGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV2;
			this.PoblarAperturaData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref maxGenerado, out rangeValueV2, this.datosDeUmbralApertura, false);
			base.AplicarModificadoresDeGeneracion(ref maxGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x0006A048 File Offset: 0x00068248
		public void SimularMovimiento(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulante);
			}
			PenetracionesByMainInFrame.Penetracion penetracion = new PenetracionesByMainInFrame.Penetracion(true);
			penetracion.tipo = tipo;
			EstimuloPenetrante estimuloPenetrante = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante.velocidadDeCambios = new PenetrationInfoLocal
			{
				centroDePuntosLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarMovimientoData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref estado, out intervalo, this.datosDeUmbralMovimiento, false);
			EstimuloPenetrante estimuloPenetrante2 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante2, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante2.velocidadDeCambios = new PenetrationInfoLocal
			{
				centroDePuntosLocal = intervalo.min + 1E-05f
			};
			minGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV;
			this.PoblarMovimientoData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref minGenerado, out rangeValueV, this.datosDeUmbralMovimiento, false);
			base.AplicarModificadoresDeGeneracion(ref minGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante3, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante3.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante3.velocidadDeCambios = new PenetrationInfoLocal
			{
				centroDePuntosLocal = Mathf.Lerp(intervalo.min, intervalo.max, this.datosDeUmbralMovimiento.promedioMod)
			};
			maxGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV2;
			this.PoblarMovimientoData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, ref maxGenerado, out rangeValueV2, this.datosDeUmbralMovimiento, false);
			base.AplicarModificadoresDeGeneracion(ref maxGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x0006A244 File Offset: 0x00068444
		private bool PoblarAperturaData(GrupoQueCompartenValores estimuladoGrupo, GrupoQueCompartenValores estimulanteGrupo, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, ref UmbralBasico.Estado resultado, out RangeValueV2 intervalo, DatosDeUmbral datos, bool suavizar = true)
		{
			float num = penetracion.estimulo.velocidadDeCambios.aperturaLocal;
			if (num < 0f)
			{
				num = 0f;
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			ParteQuePuedeEstimular estimulanteParte = penetracion.estimulanteParte;
			float num2;
			if (suavizar)
			{
				SmoothFloatsV2 semiSmoothDeId = base.GetSemiSmoothDeId((int)(estimulanteParte * ParteQuePuedeEstimular.piernas * (ParteQuePuedeEstimular)(penetracion.tipo + 1)));
				semiSmoothDeId.Add(num);
				num2 = semiSmoothDeId.suavizado;
			}
			else
			{
				num2 = num;
			}
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			if (this.aplicarModsDeIntervalos)
			{
				if (this.modsDeIntervaloPorGrupoEstimulado_Incremento_Apertura)
				{
					intervalo.Increase(this.modsDeIntervaloPorGrupoEstimulado_Incremento_Apertura[estimuladoGrupo].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulado_Expancion_Apertura)
				{
					intervalo.Expandir(this.modsDeIntervaloPorGrupoEstimulado_Expancion_Apertura[estimuladoGrupo].valor, 0.0001f);
				}
			}
			this.OnPreUmbralCalculoApertura(penetracion, ref num2, ref intervalo, ref estimulacionQueGenera);
			try
			{
				resultado = UmbralBasico.Calcular(num2, deltaTime, UmbralBasico.TipoDeCambio.porSegundo, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de penetracion apertura  de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			float estimulacionGeneradaEnFrame = resultado.estimulacionGeneradaEnFrame;
			this.OnPostUmbralCalculoApertura(penetracion, ref estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			if (this.config.debugPrint && this.config.debugPrintPenetracion && (!this.config.debugPrintSoloGenerada || (this.config.debugPrintSoloGenerada && estimulacionGeneradaEnFrame > 0f)))
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"vel:",
					num.ToString("0.0000"),
					" su:",
					num2.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" ",
					resultado.PrintStr()
				}));
			}
			return resultado.estimulacionGeneradaEnFrame > 0f;
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x0006A4B8 File Offset: 0x000686B8
		private bool PoblarMovimientoData(GrupoQueCompartenValores estimuladoGrupo, GrupoQueCompartenValores estimulanteGrupo, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, ref UmbralBasico.Estado resultado, out RangeValueV2 intervalo, DatosDeUmbral datos, bool suavizar = true)
		{
			float num = penetracion.estimulo.velocidadDeCambios.centroDePuntosLocal;
			if (num < 0f)
			{
				num = 0f;
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			ParteQuePuedeEstimular estimulanteParte = penetracion.estimulanteParte;
			float num2;
			if (suavizar)
			{
				SmoothFloatsV2 semiSmoothDeId = base.GetSemiSmoothDeId((int)(estimulanteParte * (ParteQuePuedeEstimular)3 * (ParteQuePuedeEstimular)(penetracion.tipo + 1)));
				semiSmoothDeId.Add(num);
				num2 = semiSmoothDeId.suavizado;
			}
			else
			{
				num2 = num;
			}
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			if (this.aplicarModsDeIntervalos)
			{
				if (this.modsDeIntervaloPorGrupoEstimulado_Incremento_Movimiento)
				{
					intervalo.Increase(this.modsDeIntervaloPorGrupoEstimulado_Incremento_Movimiento[estimuladoGrupo].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulado_Expancion_Movimiento)
				{
					intervalo.Expandir(this.modsDeIntervaloPorGrupoEstimulado_Expancion_Movimiento[estimuladoGrupo].valor, 0.0001f);
				}
			}
			this.OnPreUmbralCalculoMovimiento(penetracion, ref num2, ref intervalo, ref estimulacionQueGenera);
			try
			{
				resultado = UmbralBasico.Calcular(num2, deltaTime, UmbralBasico.TipoDeCambio.porSegundo, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de penetracion movimiento  de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			float estimulacionGeneradaEnFrame = resultado.estimulacionGeneradaEnFrame;
			this.OnPostUmbralCalculoMovimiento(penetracion, ref estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			if (this.config.debugPrint && this.config.debugPrintPenetracion && (!this.config.debugPrintSoloGenerada || (this.config.debugPrintSoloGenerada && estimulacionGeneradaEnFrame > 0f)))
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"vel:",
					num.ToString("0.0000"),
					" su:",
					num2.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" ",
					resultado.PrintStr()
				}));
			}
			return resultado.estimulacionGeneradaEnFrame > 0f;
		}

		// Token: 0x06001A5D RID: 6749
		protected abstract void OnPreUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06001A5E RID: 6750
		protected abstract void OnPostUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada);

		// Token: 0x06001A5F RID: 6751
		protected abstract void OnPreUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06001A60 RID: 6752
		protected abstract void OnPostUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada);

		// Token: 0x04001360 RID: 4960
		private const int apertureIndex = 2;

		// Token: 0x04001361 RID: 4961
		private const int movimientoIndex = 3;

		// Token: 0x04001362 RID: 4962
		[NonSerialized]
		private bool generarPorMovimientoDEPRECATED;

		// Token: 0x04001363 RID: 4963
		[Header("Advance")]
		public bool generarPorApertura = true;
	}
}
