using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000487 RID: 1159
	public abstract class CalculoDeEstimuloPorPenetracionRecibidaComplete : CalculoDeEstimuloPorPenetracionRecibidaAdvance
	{
		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06001A62 RID: 6754
		protected abstract float bufferParaGenerarEstimuloPorProfundidad { get; }

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06001A63 RID: 6755
		protected abstract float bufferParaGenerarEstimuloPorAnchura { get; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06001A64 RID: 6756 RVA: 0x0006A73B File Offset: 0x0006893B
		[Obsolete("", true)]
		protected DatosDeUmbral datosDeUmbralProfundidad_VagAnal { get; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06001A65 RID: 6757 RVA: 0x0006A743 File Offset: 0x00068943
		[Obsolete("", true)]
		protected DatosDeUmbral datosDeUmbralAnchura_VagAnal { get; }

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001A66 RID: 6758
		protected abstract DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Vaginal { get; }

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06001A67 RID: 6759
		protected abstract RangeValueV2 intervaloProfundidad_Vaginal { get; }

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06001A68 RID: 6760
		protected abstract RangeValueV2 intervaloProfundidad_VaginalSinHardPoints { get; }

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06001A69 RID: 6761
		protected abstract DatosDeUmbral datosDeUmbralAnchura_Vaginal { get; }

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06001A6A RID: 6762
		protected abstract DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Anal { get; }

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06001A6B RID: 6763
		protected abstract RangeValueV2 intervaloProfundidad_Anal { get; }

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06001A6C RID: 6764
		protected abstract RangeValueV2 intervaloProfundidad_AnalSinHardPoints { get; }

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06001A6D RID: 6765
		protected abstract DatosDeUmbral datosDeUmbralAnchura_Anal { get; }

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001A6E RID: 6766
		protected abstract DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Facial { get; }

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06001A6F RID: 6767
		protected abstract RangeValueV2 intervaloProfundidad_Facial { get; }

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06001A70 RID: 6768
		protected abstract RangeValueV2 intervaloProfundidad_FacialSinHardPoints { get; }

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x06001A71 RID: 6769
		protected abstract DatosDeUmbral datosDeUmbralAnchura_Facial { get; }

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06001A72 RID: 6770 RVA: 0x0006A74B File Offset: 0x0006894B
		[Obsolete("la ai, ya no afecta la profundiad de los holes, solo es physics", true)]
		protected FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Profundidad { get; }

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06001A73 RID: 6771 RVA: 0x0006A753 File Offset: 0x00068953
		[Obsolete("la ai, ya no afecta la profundiad de los holes, solo es physics", true)]
		protected FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Profundidad { get; }

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001A74 RID: 6772
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Anchura { get; }

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001A75 RID: 6773
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Anchura { get; }

		// Token: 0x06001A76 RID: 6774 RVA: 0x0006A75C File Offset: 0x0006895C
		protected sealed override bool PoblarConData(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, CalculoDeEstimuloPorPenetracionHoleResultado resultado)
		{
			bool flag = base.PoblarConData(grupoDeParte, grupoDeParteEstimulante, deltaTime, penetracion, resultado);
			bool flag2 = false;
			bool flag3 = false;
			if (this.generarPorProfundidad || this.generarPorAnchura)
			{
				DatosDeUmbralSinIntervalo datosDeUmbralSinIntervalo;
				DatosDeUmbral datosDeUmbral;
				RangeValueV2 rangeValueV;
				switch (penetracion.tipo)
				{
				case FemalePenetracionTipo.anus:
					datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Anal;
					datosDeUmbral = this.datosDeUmbralAnchura_Anal;
					rangeValueV = this.intervaloProfundidad_Anal;
					break;
				case FemalePenetracionTipo.vag:
					datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Vaginal;
					datosDeUmbral = this.datosDeUmbralAnchura_Vaginal;
					rangeValueV = this.intervaloProfundidad_Vaginal;
					break;
				case FemalePenetracionTipo.facial:
					datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Facial;
					datosDeUmbral = this.datosDeUmbralAnchura_Facial;
					rangeValueV = this.intervaloProfundidad_Facial;
					break;
				default:
					throw new ArgumentOutOfRangeException(penetracion.tipo.ToString());
				}
				EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
				if (this.generarPorProfundidad)
				{
					RangeValueV2 rangeValueV2;
					flag2 = this.PoblarProfundidadData(grupoDeParte, deltaTime, penetracion, ref resultado.data.profundidad, out rangeValueV2, datosDeUmbralSinIntervalo, rangeValueV, ref emocionesFemeninasValues);
					float num = this.bufferParaGenerarEstimuloPorProfundidad * 2f;
					if (num > 0f)
					{
						CalculoDeEstimuloEnFrame.ApplyBufferToEstimulado(ref flag2, num, this.m_BufferedCoolDownDeProfundidad, ref resultado.data.profundidad);
					}
				}
				if (this.generarPorAnchura)
				{
					RangeValueV2 rangeValueV3;
					flag3 = this.PoblarAnchuraData(grupoDeParte, deltaTime, penetracion, ref resultado.data.anchura, out rangeValueV3, datosDeUmbral, ref emocionesFemeninasValues);
					float num2 = this.bufferParaGenerarEstimuloPorAnchura * 2f;
					if (num2 > 0f)
					{
						CalculoDeEstimuloEnFrame.ApplyBufferToEstimulado(ref flag3, num2, this.m_BufferedCoolDownDeAnchura, ref resultado.data.anchura);
					}
				}
			}
			return flag || flag2 || flag3;
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x0006A8CB File Offset: 0x00068ACB
		protected sealed override float CalcularSubResultado(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, CalculoDeEstimuloPorPenetracionHoleResultado d)
		{
			return base.CalcularSubResultado(grupoDeParte, grupoDeParteEstimulante, d) + base.CalcularDeEstado(grupoDeParte, grupoDeParteEstimulante, ref d.data.profundidad) + base.CalcularDeEstado(grupoDeParte, grupoDeParteEstimulante, ref d.data.anchura);
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x0006A900 File Offset: 0x00068B00
		public void SimularProfundidad(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			DatosDeUmbralSinIntervalo datosDeUmbralSinIntervalo;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			RangeValueV2 rangeValueV;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Anal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				rangeValueV = this.intervaloProfundidad_Anal;
				break;
			case FemalePenetracionTipo.vag:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Vaginal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				rangeValueV = this.intervaloProfundidad_Vaginal;
				break;
			case FemalePenetracionTipo.facial:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Facial;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				rangeValueV = this.intervaloProfundidad_Facial;
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
			estimuloPenetrante.estadoActual = new PenetrationInfoLocal
			{
				profundidadHoleLocal = 1f,
				profundidadPeneLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarProfundidadData(grupoQueCompartenValores, deltaTime, penetracion, ref estado, out intervalo, datosDeUmbralSinIntervalo, rangeValueV, ref emocionesValoresMods);
			EstimuloPenetrante estimuloPenetrante2 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante2, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano);
			float num = intervalo.min + 1E-05f;
			estimuloPenetrante2.estadoActual = new PenetrationInfoLocal
			{
				profundidadHoleLocal = num,
				profundidadPeneLocal = num
			};
			minGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV2;
			this.PoblarProfundidadData(grupoQueCompartenValores, deltaTime, penetracion, ref minGenerado, out rangeValueV2, datosDeUmbralSinIntervalo, rangeValueV, ref emocionesValoresMods);
			base.AplicarModificadoresDeGeneracion(ref minGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante3, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante3.AddParteEstimulada(parteDelCuerpoHumano);
			float num2 = Mathf.Lerp(intervalo.min, intervalo.max, datosDeUmbralSinIntervalo.promedioMod);
			estimuloPenetrante3.estadoActual = new PenetrationInfoLocal
			{
				profundidadHoleLocal = num2,
				profundidadPeneLocal = num2
			};
			maxGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV3;
			this.PoblarProfundidadData(grupoQueCompartenValores, deltaTime, penetracion, ref maxGenerado, out rangeValueV3, datosDeUmbralSinIntervalo, rangeValueV, ref emocionesValoresMods);
			base.AplicarModificadoresDeGeneracion(ref maxGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x0006AB44 File Offset: 0x00068D44
		public void SimularAnchura(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			DatosDeUmbral datosDeUmbral;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				datosDeUmbral = this.datosDeUmbralAnchura_Anal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				datosDeUmbral = this.datosDeUmbralAnchura_Vaginal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				datosDeUmbral = this.datosDeUmbralAnchura_Facial;
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
			estimuloPenetrante.estadoActual = new PenetrationInfoLocal
			{
				aperturaLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarAnchuraData(grupoQueCompartenValores, deltaTime, penetracion, ref estado, out intervalo, datosDeUmbral, ref emocionesValoresMods);
			EstimuloPenetrante estimuloPenetrante2 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante2, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante2.estadoActual = new PenetrationInfoLocal
			{
				aperturaLocal = intervalo.min + 1E-05f
			};
			minGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV;
			this.PoblarAnchuraData(grupoQueCompartenValores, deltaTime, penetracion, ref minGenerado, out rangeValueV, datosDeUmbral, ref emocionesValoresMods);
			base.AplicarModificadoresDeGeneracion(ref minGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
			penetracion.SetEstimuloInstance(estimuloPenetrante3, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante3.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante3.estadoActual = new PenetrationInfoLocal
			{
				aperturaLocal = Mathf.Lerp(intervalo.min, intervalo.max, datosDeUmbral.promedioMod)
			};
			maxGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV2;
			this.PoblarAnchuraData(grupoQueCompartenValores, deltaTime, penetracion, ref maxGenerado, out rangeValueV2, datosDeUmbral, ref emocionesValoresMods);
			base.AplicarModificadoresDeGeneracion(ref maxGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x0006AD44 File Offset: 0x00068F44
		public RangeValueV2 ObtenerRangoDeProfundidad(FemalePenetracionTipo tipo, ref EmocionesFemeninasValues emocionesValoresMods, bool incluirHardPoints)
		{
			DatosDeUmbralSinIntervalo datosDeUmbralSinIntervalo;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			RangeValueV2 rangeValueV;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Anal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				rangeValueV = (incluirHardPoints ? this.intervaloProfundidad_Anal : this.intervaloProfundidad_AnalSinHardPoints);
				break;
			case FemalePenetracionTipo.vag:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Vaginal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				rangeValueV = (incluirHardPoints ? this.intervaloProfundidad_Vaginal : this.intervaloProfundidad_VaginalSinHardPoints);
				break;
			case FemalePenetracionTipo.facial:
				datosDeUmbralSinIntervalo = this.datosDeUmbralProfundidad_Facial;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				rangeValueV = (incluirHardPoints ? this.intervaloProfundidad_Facial : this.intervaloProfundidad_FacialSinHardPoints);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			return this.ObtenerRangoDeProfundidad(tipo, grupoQueCompartenValores, datosDeUmbralSinIntervalo, rangeValueV, ref emocionesValoresMods);
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0006ADF9 File Offset: 0x00068FF9
		public RangeValueV2 ObtenerRangoDeProfundidad(FemalePenetracionTipo tipo, GrupoQueCompartenValores estimuladoGrupo, DatosDeUmbralSinIntervalo datos, RangeValueV2 currentIntervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			RangeValueV2 rangeValueV = currentIntervalo;
			this.OnPreUmbralCalculoProfundidad_ModificarIntervalo(tipo, ref currentIntervalo, ref emocionesValoresMods);
			return rangeValueV;
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x0006AE24 File Offset: 0x00069024
		public RangeValueV2 ObtenerRangoDeAnchura(FemalePenetracionTipo tipo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			DatosDeUmbral datosDeUmbral;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				datosDeUmbral = this.datosDeUmbralAnchura_Anal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				datosDeUmbral = this.datosDeUmbralAnchura_Vaginal;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				datosDeUmbral = this.datosDeUmbralAnchura_Facial;
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			return this.ObtenerRangoDeAnchura(tipo, grupoQueCompartenValores, datosDeUmbral, ref emocionesValoresMods);
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x0006AEA4 File Offset: 0x000690A4
		public RangeValueV2 ObtenerRangoDeAnchura(FemalePenetracionTipo tipo, GrupoQueCompartenValores estimuladoGrupo, DatosDeUmbral datos, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			RangeValueV2 intervaloDeGeneracion = datos.intervaloDeGeneracion;
			if (this.aplicarModsDeIntervalos)
			{
				if (this.modsDeIntervaloPorGrupoEstimulado_Incremento_Anchura)
				{
					intervaloDeGeneracion.Increase(this.modsDeIntervaloPorGrupoEstimulado_Incremento_Anchura[estimuladoGrupo].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulado_Expancion_Anchura)
				{
					intervaloDeGeneracion.Expandir(this.modsDeIntervaloPorGrupoEstimulado_Expancion_Anchura[estimuladoGrupo].valor, 0.0001f);
				}
			}
			this.OnPreUmbralCalculoAnchura_ModificarIntervalo(tipo, ref intervaloDeGeneracion, ref emocionesValoresMods);
			return intervaloDeGeneracion;
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x0006AF3C File Offset: 0x0006913C
		private bool PoblarProfundidadData(GrupoQueCompartenValores estimuladoGrupo, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, ref UmbralBasico.Estado resultado, out RangeValueV2 intervalo, DatosDeUmbralSinIntervalo datos, RangeValueV2 currentIntervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			float profundidadHoleLocal = penetracion.estimulo.estadoActual.profundidadHoleLocal;
			float num = profundidadHoleLocal;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			intervalo = this.ObtenerRangoDeProfundidad(penetracion.tipo, estimuladoGrupo, datos, currentIntervalo, ref emocionesValoresMods);
			this.OnPreUmbralCalculoProfundidad(penetracion, ref num, ref intervalo, ref estimulacionQueGenera);
			try
			{
				resultado = UmbralBasico.Calcular(num, deltaTime, UmbralBasico.TipoDeCambio.unico, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
				resultado.SetEstimulacionGeneradaEnFrame(resultado.estimulacionGeneradaEnFrame);
				resultado.SetEstimulacionGeneradaTotal(resultado.estimulacionGeneradaEnFrame);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de penetracion Profundidad de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			float estimulacionGeneradaEnFrame = resultado.estimulacionGeneradaEnFrame;
			this.OnPostUmbralCalculoProfundidad(penetracion, ref estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			if (this.config.debugPrint && this.config.debugPrintProfundidad && (!this.config.debugPrintSoloGenerada || (this.config.debugPrintSoloGenerada && estimulacionGeneradaEnFrame > 0f)))
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"Profundidad:",
					profundidadHoleLocal.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" ",
					resultado.PrintStr()
				}));
			}
			return estimulacionGeneradaEnFrame > 0f;
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x0006B118 File Offset: 0x00069318
		private bool PoblarAnchuraData(GrupoQueCompartenValores estimuladoGrupo, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, ref UmbralBasico.Estado resultado, out RangeValueV2 intervalo, DatosDeUmbral datos, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			float aperturaLocal = penetracion.estimulo.estadoActual.aperturaLocal;
			float num = aperturaLocal;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			intervalo = this.ObtenerRangoDeAnchura(penetracion.tipo, estimuladoGrupo, datos, ref emocionesValoresMods);
			this.OnPreUmbralCalculoAnchura(penetracion, ref num, ref intervalo, ref estimulacionQueGenera);
			try
			{
				resultado = UmbralBasico.Calcular(num, deltaTime, UmbralBasico.TipoDeCambio.unico, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
				resultado.SetEstimulacionGeneradaEnFrame(resultado.estimulacionGeneradaEnFrame);
				resultado.SetEstimulacionGeneradaTotal(resultado.estimulacionGeneradaEnFrame);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de penetracion Anchura de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			float estimulacionGeneradaEnFrame = resultado.estimulacionGeneradaEnFrame;
			this.OnPostUmbralCalculoAnchura(penetracion, ref estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
			resultado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			if (this.config.debugPrint && this.config.debugPrintAnchura && (!this.config.debugPrintSoloGenerada || (this.config.debugPrintSoloGenerada && estimulacionGeneradaEnFrame > 0f)))
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"Anchura:",
					aperturaLocal.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" ",
					resultado.PrintStr()
				}));
			}
			return estimulacionGeneradaEnFrame > 0f;
		}

		// Token: 0x06001A80 RID: 6784
		protected abstract void OnPreUmbralCalculoProfundidad_ModificarIntervalo(FemalePenetracionTipo tipo, ref RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods);

		// Token: 0x06001A81 RID: 6785
		protected abstract void OnPreUmbralCalculoAnchura_ModificarIntervalo(FemalePenetracionTipo tipo, ref RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods);

		// Token: 0x06001A82 RID: 6786
		protected abstract void OnPreUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06001A83 RID: 6787
		protected abstract void OnPostUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada);

		// Token: 0x06001A84 RID: 6788
		protected abstract void OnPreUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06001A85 RID: 6789
		protected abstract void OnPostUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada);

		// Token: 0x04001364 RID: 4964
		[Header("Complete")]
		public bool generarPorProfundidad = true;

		// Token: 0x04001365 RID: 4965
		public bool generarPorAnchura = true;

		// Token: 0x04001366 RID: 4966
		[SerializeField]
		private BufferedCoolDown m_BufferedCoolDownDeProfundidad = new BufferedCoolDown();

		// Token: 0x04001367 RID: 4967
		[SerializeField]
		private BufferedCoolDown m_BufferedCoolDownDeAnchura = new BufferedCoolDown();
	}
}
