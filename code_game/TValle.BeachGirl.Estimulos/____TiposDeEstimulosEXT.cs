using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets
{
	// Token: 0x02000004 RID: 4
	public static class ____TiposDeEstimulosEXT
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020CC File Offset: 0x000002CC
		public static TipoDeEstimuloBasico GetTipoBasico(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
				return TipoDeEstimuloBasico.None;
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return TipoDeEstimuloBasico.tactil;
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return TipoDeEstimuloBasico.verbal;
			case TipoDeEstimulo.visual:
				return TipoDeEstimuloBasico.visual;
			case TipoDeEstimulo.coital:
				return TipoDeEstimuloBasico.coital;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002140 File Offset: 0x00000340
		public static DireccionDeEstimulo DeFlag(this DireccionDeEstimuloFlags flags)
		{
			DireccionDeEstimulo direccionDeEstimulo;
			if (flags != DireccionDeEstimuloFlags.recibida)
			{
				if (flags != DireccionDeEstimuloFlags.dada)
				{
					throw new ArgumentOutOfRangeException(flags.ToString());
				}
				direccionDeEstimulo = DireccionDeEstimulo.dada;
			}
			else
			{
				direccionDeEstimulo = DireccionDeEstimulo.recibida;
			}
			return direccionDeEstimulo;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002174 File Offset: 0x00000374
		public static bool HasFlag(this DireccionDeEstimuloFlags flags, DireccionDeEstimulo direccion)
		{
			DireccionDeEstimuloFlags direccionDeEstimuloFlags;
			if (direccion != DireccionDeEstimulo.recibida)
			{
				if (direccion != DireccionDeEstimulo.dada)
				{
					throw new ArgumentOutOfRangeException(direccion.ToString());
				}
				direccionDeEstimuloFlags = DireccionDeEstimuloFlags.dada;
			}
			else
			{
				direccionDeEstimuloFlags = DireccionDeEstimuloFlags.recibida;
			}
			return ((int)flags).HasFlag((int)direccionDeEstimuloFlags);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021AC File Offset: 0x000003AC
		public static bool TipoDeAccionProvenienteDeTipoDeEstimuloEsAutoEjecutadaPorDefecto(this TipoDeEstimulo tipoDeEstimulo)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return false;
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002218 File Offset: 0x00000418
		public static bool TipoDeAccionProvenienteDeTipoDeEstimuloEsAutoEjecutadaPorDefectoVar2(this TipoDeEstimulo tipoDeEstimulo)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return false;
			case TipoDeEstimulo.guiandoBone:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002284 File Offset: 0x00000484
		public static TipoDeEstimuloFlags ParceAFlags(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
				return TipoDeEstimuloFlags.None;
			case TipoDeEstimulo.tactil:
				return TipoDeEstimuloFlags.tactil;
			case TipoDeEstimulo.auditiva:
				return TipoDeEstimuloFlags.auditiva;
			case TipoDeEstimulo.visual:
				return TipoDeEstimuloFlags.visual;
			case TipoDeEstimulo.olfativa:
				return TipoDeEstimuloFlags.olfativa;
			case TipoDeEstimulo.gustativa:
				return TipoDeEstimuloFlags.gustativa;
			case TipoDeEstimulo.energetica:
				return TipoDeEstimuloFlags.energetica;
			case TipoDeEstimulo.agarrante:
				return TipoDeEstimuloFlags.agarrante;
			case TipoDeEstimulo.coital:
				return TipoDeEstimuloFlags.coital;
			case TipoDeEstimulo.desvestidura:
				return TipoDeEstimuloFlags.desvestidura;
			case TipoDeEstimulo.empujante:
				return TipoDeEstimuloFlags.empujante;
			case TipoDeEstimulo.peticionDesvestidura:
				return TipoDeEstimuloFlags.peticionDesvestidura;
			case TipoDeEstimulo.ejecucionDePose:
				return TipoDeEstimuloFlags.ejecucionDePose;
			case TipoDeEstimulo.peticionEjecucionDePose:
				return TipoDeEstimuloFlags.peticionEjecucionDePose;
			case TipoDeEstimulo.guiandoBone:
				return TipoDeEstimuloFlags.peticionMovimientoDeBone;
			case TipoDeEstimulo.manipulandoBone:
				return TipoDeEstimuloFlags.manipulacionDeBone;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002330 File Offset: 0x00000530
		public static TipoDeEstimulo ParceDesdeFlags(this TipoDeEstimuloFlags tipo)
		{
			if (tipo <= TipoDeEstimuloFlags.desvestidura)
			{
				if (tipo <= TipoDeEstimuloFlags.energetica)
				{
					switch (tipo)
					{
					case TipoDeEstimuloFlags.None:
						return TipoDeEstimulo.None;
					case TipoDeEstimuloFlags.tactil:
						return TipoDeEstimulo.tactil;
					case TipoDeEstimuloFlags.auditiva:
						return TipoDeEstimulo.auditiva;
					case TipoDeEstimuloFlags.tactil | TipoDeEstimuloFlags.auditiva:
					case TipoDeEstimuloFlags.tactil | TipoDeEstimuloFlags.visual:
					case TipoDeEstimuloFlags.auditiva | TipoDeEstimuloFlags.visual:
					case TipoDeEstimuloFlags.tactil | TipoDeEstimuloFlags.auditiva | TipoDeEstimuloFlags.visual:
						break;
					case TipoDeEstimuloFlags.visual:
						return TipoDeEstimulo.visual;
					case TipoDeEstimuloFlags.olfativa:
						return TipoDeEstimulo.olfativa;
					default:
						if (tipo == TipoDeEstimuloFlags.gustativa)
						{
							return TipoDeEstimulo.gustativa;
						}
						if (tipo == TipoDeEstimuloFlags.energetica)
						{
							return TipoDeEstimulo.energetica;
						}
						break;
					}
				}
				else
				{
					if (tipo == TipoDeEstimuloFlags.agarrante)
					{
						return TipoDeEstimulo.agarrante;
					}
					if (tipo == TipoDeEstimuloFlags.coital)
					{
						return TipoDeEstimulo.coital;
					}
					if (tipo == TipoDeEstimuloFlags.desvestidura)
					{
						return TipoDeEstimulo.desvestidura;
					}
				}
			}
			else if (tipo <= TipoDeEstimuloFlags.ejecucionDePose)
			{
				if (tipo == TipoDeEstimuloFlags.empujante)
				{
					return TipoDeEstimulo.empujante;
				}
				if (tipo == TipoDeEstimuloFlags.peticionDesvestidura)
				{
					return TipoDeEstimulo.peticionDesvestidura;
				}
				if (tipo == TipoDeEstimuloFlags.ejecucionDePose)
				{
					return TipoDeEstimulo.ejecucionDePose;
				}
			}
			else
			{
				if (tipo == TipoDeEstimuloFlags.peticionEjecucionDePose)
				{
					return TipoDeEstimulo.peticionEjecucionDePose;
				}
				if (tipo == TipoDeEstimuloFlags.manipulacionDeBone)
				{
					return TipoDeEstimulo.manipulandoBone;
				}
				if (tipo == TipoDeEstimuloFlags.peticionMovimientoDeBone)
				{
					return TipoDeEstimulo.guiandoBone;
				}
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000240C File Offset: 0x0000060C
		public static ParteQuePuedeEstimular ObtenerEstimulanteDeTipoDeEstimuloEspecifico(this int TipoDeEstimuloEspecifico, TipoDeEstimulo tipoDeEstimulo)
		{
			if (tipoDeEstimulo == TipoDeEstimulo.tactil)
			{
				return ((TipoDeEstimuloTactil)TipoDeEstimuloEspecifico).ObtenerEstimulanteDeTipoDeEstimuloEspecifico();
			}
			if (tipoDeEstimulo == TipoDeEstimulo.visual)
			{
				return ((TipoDeEstimuloVisual)TipoDeEstimuloEspecifico).ObtenerEstimulanteDeTipoDeEstimuloEspecifico();
			}
			if (tipoDeEstimulo != TipoDeEstimulo.coital)
			{
				throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
			}
			return ((TipoDeEstimuloCoital)TipoDeEstimuloEspecifico).ObtenerEstimulanteDeTipoDeEstimuloEspecifico();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002444 File Offset: 0x00000644
		public static ParteQuePuedeEstimular ObtenerEstimulanteDeTipoDeEstimuloEspecifico(this TipoDeEstimuloTactil TipoDeEstimuloEspecifico)
		{
			switch (TipoDeEstimuloEspecifico)
			{
			case TipoDeEstimuloTactil.None:
				return ParteQuePuedeEstimular.noEspecificada;
			case TipoDeEstimuloTactil.caricia:
				return ParteQuePuedeEstimular.manos;
			case TipoDeEstimuloTactil.golpe:
				return ParteQuePuedeEstimular.manos;
			case TipoDeEstimuloTactil.beso:
				return ParteQuePuedeEstimular.boca;
			case TipoDeEstimuloTactil.lambida:
				return ParteQuePuedeEstimular.lengua;
			case TipoDeEstimuloTactil.derramamientoSobre:
				return ParteQuePuedeEstimular.semen;
			case TipoDeEstimuloTactil.derramamientoDentro:
				return ParteQuePuedeEstimular.semen;
			case TipoDeEstimuloTactil.poking:
				return ParteQuePuedeEstimular.dedo;
			case TipoDeEstimuloTactil.slapping:
				return ParteQuePuedeEstimular.manos;
			case TipoDeEstimuloTactil.humping:
				return ParteQuePuedeEstimular.torzo;
			case TipoDeEstimuloTactil.dryHump:
				return ParteQuePuedeEstimular.pene;
			default:
				throw new ArgumentOutOfRangeException(TipoDeEstimuloEspecifico.ToString());
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024BF File Offset: 0x000006BF
		public static ParteQuePuedeEstimular ObtenerEstimulanteDeTipoDeEstimuloEspecifico(this TipoDeEstimuloVisual TipoDeEstimuloEspecifico)
		{
			switch (TipoDeEstimuloEspecifico)
			{
			case TipoDeEstimuloVisual.None:
				return ParteQuePuedeEstimular.noEspecificada;
			case TipoDeEstimuloVisual.normal:
				return ParteQuePuedeEstimular.ojos;
			case TipoDeEstimuloVisual.fotografiada:
				return ParteQuePuedeEstimular.propSexToy;
			default:
				throw new ArgumentOutOfRangeException(TipoDeEstimuloEspecifico.ToString());
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000024F2 File Offset: 0x000006F2
		public static ParteQuePuedeEstimular ObtenerEstimulanteDeTipoDeEstimuloEspecifico(this TipoDeEstimuloCoital TipoDeEstimuloEspecifico)
		{
			switch (TipoDeEstimuloEspecifico)
			{
			case TipoDeEstimuloCoital.None:
				return ParteQuePuedeEstimular.noEspecificada;
			case TipoDeEstimuloCoital.conPene:
				return ParteQuePuedeEstimular.pene;
			case TipoDeEstimuloCoital.conDedo:
				return ParteQuePuedeEstimular.dedo;
			case TipoDeEstimuloCoital.otros:
				return ParteQuePuedeEstimular.propSexToy;
			default:
				throw new ArgumentOutOfRangeException(TipoDeEstimuloEspecifico.ToString());
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000252B File Offset: 0x0000072B
		public static int ObtenerTipoDeEstimulo(this ParteQuePuedeEstimular estimulanteParte, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, bool esGolpe = false, InteracionEstimulanteBasica estimulo = null)
		{
			if (tipoDeEstimulo != TipoDeEstimulo.tactil)
			{
				if (tipoDeEstimulo == TipoDeEstimulo.visual)
				{
					return (int)estimulanteParte.ObtenerTipoDeEstimuloVisual();
				}
				if (tipoDeEstimulo != TipoDeEstimulo.coital)
				{
					return 1;
				}
				return (int)estimulanteParte.ObtenerTipoDeEstimuloCoital();
			}
			else
			{
				if (estimulo == null)
				{
					return (int)estimulanteParte.ObtenerTipoDeEstimuloTactil(esGolpe, estimulada);
				}
				return (int)estimulo.ObtenerTipoDeEstimuloTactil(estimulada, estimulanteParte, esGolpe);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002564 File Offset: 0x00000764
		public static TipoDeEstimuloVisual ObtenerTipoDeEstimuloVisual(this ParteQuePuedeEstimular estimulanteParte)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.manos:
					case ParteQuePuedeEstimular.pene:
						break;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0075;
					default:
						if (estimulanteParte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0075;
						}
						return TipoDeEstimuloVisual.fotografiada;
					}
				}
				else if (estimulanteParte != ParteQuePuedeEstimular.torzo && estimulanteParte != ParteQuePuedeEstimular.lengua)
				{
					goto IL_0075;
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.boca && estimulanteParte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0075;
				}
			}
			else if (estimulanteParte != ParteQuePuedeEstimular.semen && estimulanteParte != ParteQuePuedeEstimular.dedo)
			{
				goto IL_0075;
			}
			return TipoDeEstimuloVisual.normal;
			IL_0075:
			throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000025F8 File Offset: 0x000007F8
		public static TipoDeEstimuloCoital ObtenerTipoDeEstimuloCoitalInvertido(this ParteDelCuerpoHumano estimulanteParte)
		{
			if (estimulanteParte == ParteDelCuerpoHumano.manos)
			{
				return TipoDeEstimuloCoital.conDedo;
			}
			if (estimulanteParte == ParteDelCuerpoHumano.pene)
			{
				return TipoDeEstimuloCoital.conPene;
			}
			return TipoDeEstimuloCoital.otros;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000260C File Offset: 0x0000080C
		public static TipoDeEstimuloCoital ObtenerTipoDeEstimuloCoital(this ParteQuePuedeEstimular estimulanteParte)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
						return TipoDeEstimuloCoital.None;
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.manos:
						break;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0083;
					case ParteQuePuedeEstimular.pene:
						return TipoDeEstimuloCoital.conPene;
					default:
						if (estimulanteParte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0083;
						}
						break;
					}
				}
				else if (estimulanteParte != ParteQuePuedeEstimular.torzo && estimulanteParte != ParteQuePuedeEstimular.lengua)
				{
					goto IL_0083;
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.boca && estimulanteParte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0083;
				}
			}
			else if (estimulanteParte != ParteQuePuedeEstimular.semen)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0083;
				}
				return TipoDeEstimuloCoital.conDedo;
			}
			return TipoDeEstimuloCoital.otros;
			IL_0083:
			throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026B0 File Offset: 0x000008B0
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDerramamiento(this ParteQuePuedeEstimular estimulanteParte, ParteDelCuerpoHumano estimulada)
		{
			if (estimulanteParte != ParteQuePuedeEstimular.semen)
			{
				throw new InvalidOperationException();
			}
			if (estimulada == ParteDelCuerpoHumano.bocaInterno || estimulada == ParteDelCuerpoHumano.globosOculares || estimulada - ParteDelCuerpoHumano.ano <= 1)
			{
				return TipoDeEstimuloTactil.derramamientoDentro;
			}
			return TipoDeEstimuloTactil.derramamientoSobre;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026D4 File Offset: 0x000008D4
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDerramamiento(this ParteQuePuedeEstimular estimulanteParte)
		{
			if (estimulanteParte != ParteQuePuedeEstimular.semen)
			{
				throw new InvalidOperationException();
			}
			return TipoDeEstimuloTactil.derramamientoSobre;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026E8 File Offset: 0x000008E8
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDeGolpe(this ParteQuePuedeEstimular estimulanteParte, ParteDelCuerpoHumano estimulada)
		{
			if (estimulanteParte == ParteQuePuedeEstimular.semen)
			{
				return estimulanteParte.ObtenerTipoDeEstimuloTactilDerramamiento(estimulada);
			}
			switch (estimulada)
			{
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.mejillas:
				break;
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.ojos:
				goto IL_0077;
			case ParteDelCuerpoHumano.globosOculares:
				if (estimulanteParte <= ParteQuePuedeEstimular.pene)
				{
					if (estimulanteParte - ParteQuePuedeEstimular.noEspecificada > 1 && estimulanteParte != ParteQuePuedeEstimular.manos && estimulanteParte != ParteQuePuedeEstimular.pene)
					{
						goto IL_0077;
					}
				}
				else if (estimulanteParte != ParteQuePuedeEstimular.propSexToy && estimulanteParte != ParteQuePuedeEstimular.torzo && estimulanteParte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0077;
				}
				return TipoDeEstimuloTactil.poking;
			default:
				if (estimulada - ParteDelCuerpoHumano.senos > 1 && estimulada != ParteDelCuerpoHumano.nalgas)
				{
					goto IL_0077;
				}
				break;
			}
			if (estimulanteParte == ParteQuePuedeEstimular.pene || estimulanteParte == ParteQuePuedeEstimular.propSexToy)
			{
				return TipoDeEstimuloTactil.slapping;
			}
			IL_0077:
			return estimulanteParte.ObtenerTipoDeEstimuloTactilDeGolpe();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002774 File Offset: 0x00000974
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDeGolpe(this ParteQuePuedeEstimular estimulanteParte)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
						return TipoDeEstimuloTactil.None;
					case ParteQuePuedeEstimular.piernas:
						return TipoDeEstimuloTactil.golpe;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0082;
					case ParteQuePuedeEstimular.manos:
					case ParteQuePuedeEstimular.pene:
						break;
					default:
						if (estimulanteParte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0082;
						}
						break;
					}
					return TipoDeEstimuloTactil.slapping;
				}
				if (estimulanteParte != ParteQuePuedeEstimular.torzo)
				{
					if (estimulanteParte != ParteQuePuedeEstimular.lengua)
					{
						goto IL_0082;
					}
					return TipoDeEstimuloTactil.poking;
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.boca && estimulanteParte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0082;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.semen)
				{
					return estimulanteParte.ObtenerTipoDeEstimuloTactilDerramamiento();
				}
				if (estimulanteParte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0082;
				}
				return TipoDeEstimuloTactil.poking;
			}
			return TipoDeEstimuloTactil.golpe;
			IL_0082:
			throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002818 File Offset: 0x00000A18
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDeNOGolpe(this ParteQuePuedeEstimular estimulanteParte)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
						return TipoDeEstimuloTactil.None;
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.manos:
						break;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0087;
					case ParteQuePuedeEstimular.pene:
						return TipoDeEstimuloTactil.dryHump;
					default:
						if (estimulanteParte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0087;
						}
						return TipoDeEstimuloTactil.poking;
					}
				}
				else if (estimulanteParte != ParteQuePuedeEstimular.torzo)
				{
					if (estimulanteParte != ParteQuePuedeEstimular.lengua)
					{
						goto IL_0087;
					}
					return TipoDeEstimuloTactil.lambida;
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte == ParteQuePuedeEstimular.boca)
				{
					return TipoDeEstimuloTactil.beso;
				}
				if (estimulanteParte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0087;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.semen)
				{
					return estimulanteParte.ObtenerTipoDeEstimuloTactilDerramamiento();
				}
				if (estimulanteParte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0087;
				}
				return TipoDeEstimuloTactil.poking;
			}
			return TipoDeEstimuloTactil.caricia;
			IL_0087:
			throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000028C0 File Offset: 0x00000AC0
		private static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDeNOGolpe(this ParteQuePuedeEstimular estimulanteParte, ParteDelCuerpoHumano estimulada)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.pene)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.piernas)
				{
					if (estimulanteParte != ParteQuePuedeEstimular.manos)
					{
						if (estimulanteParte != ParteQuePuedeEstimular.pene)
						{
							goto IL_009B;
						}
						if (estimulada != ParteDelCuerpoHumano.globosOculares || estimulada != ParteDelCuerpoHumano.vag || estimulada != ParteDelCuerpoHumano.ano || estimulada != ParteDelCuerpoHumano.bocaInterno)
						{
							return TipoDeEstimuloTactil.dryHump;
						}
						return TipoDeEstimuloTactil.poking;
					}
					else
					{
						if (estimulada == ParteDelCuerpoHumano.nariz || estimulada - ParteDelCuerpoHumano.ojos <= 1 || estimulada == ParteDelCuerpoHumano.ano)
						{
							return TipoDeEstimuloTactil.poking;
						}
						goto IL_009B;
					}
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.torzo)
			{
				if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
				{
					return TipoDeEstimuloTactil.poking;
				}
				if (estimulanteParte != ParteQuePuedeEstimular.torzo)
				{
					goto IL_009B;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.semen)
				{
					return estimulanteParte.ObtenerTipoDeEstimuloTactilDerramamiento(estimulada);
				}
				if (estimulanteParte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_009B;
				}
				if (estimulada <= ParteDelCuerpoHumano.pezones)
				{
					if (estimulada - ParteDelCuerpoHumano.labios > 1 && estimulada != ParteDelCuerpoHumano.pezones)
					{
						goto IL_009B;
					}
				}
				else if (estimulada - ParteDelCuerpoHumano.labiosVaginales > 1 && estimulada != ParteDelCuerpoHumano.vag)
				{
					goto IL_009B;
				}
				return TipoDeEstimuloTactil.caricia;
			}
			if (estimulada != ParteDelCuerpoHumano.globosOculares)
			{
				return TipoDeEstimuloTactil.humping;
			}
			IL_009B:
			if (estimulada == ParteDelCuerpoHumano.globosOculares)
			{
				return TipoDeEstimuloTactil.poking;
			}
			return estimulanteParte.ObtenerTipoDeEstimuloTactilDeNOGolpe();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002978 File Offset: 0x00000B78
		public static TipoDeEstimuloTactilInvertido ObtenerTipoDeEstimuloTactil(this ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada)
		{
			if (estimulante <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulante <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulante)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.pene:
						break;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0080;
					case ParteQuePuedeEstimular.manos:
						if (estimulada == ParteDelCuerpoHumano.pene)
						{
							return TipoDeEstimuloTactilInvertido.handjob;
						}
						return TipoDeEstimuloTactilInvertido.massage;
					default:
						if (estimulante != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0080;
						}
						break;
					}
				}
				else if (estimulante != ParteQuePuedeEstimular.torzo && estimulante != ParteQuePuedeEstimular.lengua)
				{
					goto IL_0080;
				}
			}
			else if (estimulante <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulante != ParteQuePuedeEstimular.boca && estimulante != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0080;
				}
			}
			else if (estimulante != ParteQuePuedeEstimular.semen && estimulante != ParteQuePuedeEstimular.dedo)
			{
				goto IL_0080;
			}
			return TipoDeEstimuloTactilInvertido.None;
			IL_0080:
			throw new ArgumentOutOfRangeException(estimulante.ToString());
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A18 File Offset: 0x00000C18
		public static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactil(this InteracionEstimulanteBasica estimulo, PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteQuePuedeEstimular estimulante, bool esGolpe)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = estimulo.PartePrincipalEstimulada(contexto);
			return estimulo.ObtenerTipoDeEstimuloTactil(parteDelCuerpoHumano, estimulante, esGolpe);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A38 File Offset: 0x00000C38
		public static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactil(this InteracionEstimulanteBasica estimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, bool esGolpe)
		{
			EstimuloTactilDeSemen estimuloTactilDeSemen = estimulo as EstimuloTactilDeSemen;
			if (estimuloTactilDeSemen == null || estimulante != ParteQuePuedeEstimular.semen)
			{
				return estimulante.ObtenerTipoDeEstimuloTactil(esGolpe, estimulada);
			}
			if (estimuloTactilDeSemen.penetrando == null)
			{
				return estimulante.ObtenerTipoDeEstimuloTactilDerramamiento(estimulada);
			}
			return estimulante.ObtenerTipoDeEstimuloTactilDerramamientoEnHole(estimulada, estimuloTactilDeSemen.penetrando.Value);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A90 File Offset: 0x00000C90
		public static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactilDerramamientoEnHole(this ParteQuePuedeEstimular estimulanteParte, ParteDelCuerpoHumano estimulada, ParteDelCuerpoHumano penetrando)
		{
			if (estimulanteParte != ParteQuePuedeEstimular.semen)
			{
				throw new InvalidOperationException();
			}
			if (penetrando != ParteDelCuerpoHumano.bocaInterno)
			{
				if (penetrando != ParteDelCuerpoHumano.ano)
				{
					if (penetrando != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(penetrando.ToString());
					}
					if (estimulada == ParteDelCuerpoHumano.vag)
					{
						return TipoDeEstimuloTactil.derramamientoDentro;
					}
					return TipoDeEstimuloTactil.derramamientoSobre;
				}
				else
				{
					if (estimulada == ParteDelCuerpoHumano.ano)
					{
						return TipoDeEstimuloTactil.derramamientoDentro;
					}
					return TipoDeEstimuloTactil.derramamientoSobre;
				}
			}
			else
			{
				if (estimulada == ParteDelCuerpoHumano.bocaInterno)
				{
					return TipoDeEstimuloTactil.derramamientoDentro;
				}
				return TipoDeEstimuloTactil.derramamientoSobre;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002AE9 File Offset: 0x00000CE9
		public static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactil(this ParteQuePuedeEstimular estimulanteParte, bool esGolpe, ParteDelCuerpoHumano estimulada)
		{
			if (esGolpe)
			{
				return estimulanteParte.ObtenerTipoDeEstimuloTactilDeGolpe(estimulada);
			}
			return estimulanteParte.ObtenerTipoDeEstimuloTactilDeNOGolpe(estimulada);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002AFD File Offset: 0x00000CFD
		public static TipoDeEstimuloTactil ObtenerTipoDeEstimuloTactil(this ParteQuePuedeEstimular estimulanteParte, bool esGolpe)
		{
			if (esGolpe)
			{
				return estimulanteParte.ObtenerTipoDeEstimuloTactilDeGolpe();
			}
			return estimulanteParte.ObtenerTipoDeEstimuloTactilDeNOGolpe();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002B0F File Offset: 0x00000D0F
		public static float Prioridad(this TipoDeEstimuloVisual tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimuloVisual.None:
				return 1f;
			case TipoDeEstimuloVisual.normal:
				return 2f;
			case TipoDeEstimuloVisual.fotografiada:
				return 4f;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002B4C File Offset: 0x00000D4C
		public static float Prioridad(this TipoDeEstimuloTactil tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimuloTactil.None:
				return 1f;
			case TipoDeEstimuloTactil.caricia:
				return 1.11f;
			case TipoDeEstimuloTactil.golpe:
				return 2f;
			case TipoDeEstimuloTactil.beso:
				return 1.14f;
			case TipoDeEstimuloTactil.lambida:
				return 1.15f;
			case TipoDeEstimuloTactil.derramamientoSobre:
				return 1.9f;
			case TipoDeEstimuloTactil.derramamientoDentro:
				return 1.95f;
			case TipoDeEstimuloTactil.poking:
				return 1.16f;
			case TipoDeEstimuloTactil.slapping:
				return 1.17f;
			case TipoDeEstimuloTactil.humping:
				return 1.13f;
			case TipoDeEstimuloTactil.dryHump:
				return 1.8f;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002BE4 File Offset: 0x00000DE4
		public static float Prioridad(this TipoDeEstimuloCoital coital)
		{
			switch (coital)
			{
			case TipoDeEstimuloCoital.None:
				return 1f;
			case TipoDeEstimuloCoital.conPene:
				return 1.9f;
			case TipoDeEstimuloCoital.conDedo:
				return 2f;
			case TipoDeEstimuloCoital.otros:
				return 1.2f;
			default:
				throw new ArgumentOutOfRangeException(coital.ToString());
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C34 File Offset: 0x00000E34
		public static int Prioridad(this TipoDeEstimulo tipo)
		{
			int num = 1;
			switch (tipo)
			{
			case TipoDeEstimulo.None:
				return 0;
			case TipoDeEstimulo.tactil:
				return num * 50;
			case TipoDeEstimulo.visual:
				return num * 10;
			case TipoDeEstimulo.coital:
				return num * 100;
			case TipoDeEstimulo.desvestidura:
				return num * 500;
			case TipoDeEstimulo.peticionDesvestidura:
				return num * 200;
			case TipoDeEstimulo.ejecucionDePose:
				return num * 400;
			case TipoDeEstimulo.peticionEjecucionDePose:
				return num * 250;
			case TipoDeEstimulo.guiandoBone:
				return num * 150;
			case TipoDeEstimulo.manipulandoBone:
				return num * 300;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public static bool EsIntercambioCoital(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return false;
			case TipoDeEstimulo.coital:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002D60 File Offset: 0x00000F60
		public static bool EsIntercambioFisico(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return false;
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002DCC File Offset: 0x00000FCC
		[Obsolete("TODO")]
		public static bool EsIntercambioVisual(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return false;
			case TipoDeEstimulo.visual:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002E38 File Offset: 0x00001038
		public static bool EsIntercambioVerbal(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return false;
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002EA4 File Offset: 0x000010A4
		public static bool EsIntercambioExposicion(this TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.None:
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.olfativa:
			case TipoDeEstimulo.gustativa:
			case TipoDeEstimulo.energetica:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.empujante:
				return false;
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x04000001 RID: 1
		public const int PrioridadDeTipoDeEstimuloMasAlta = 500;
	}
}
