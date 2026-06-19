using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000335 RID: 821
	public static class PartesHumanasParaAiExt
	{
		// Token: 0x060011B4 RID: 4532 RVA: 0x0004BB48 File Offset: 0x00049D48
		public static PartesHumanasParaAi Parse(this BodyPartEnum parte)
		{
			switch (parte)
			{
			case BodyPartEnum.cabeza:
				return PartesHumanasParaAi.cabeza;
			case BodyPartEnum.cuello:
				return PartesHumanasParaAi.cuello;
			case BodyPartEnum.mandibula:
				return PartesHumanasParaAi.mandibula;
			case BodyPartEnum.boca:
				return PartesHumanasParaAi.labiosDeBoca;
			case BodyPartEnum.bocaInterno:
				return PartesHumanasParaAi.boca;
			case BodyPartEnum.nariz:
				return PartesHumanasParaAi.nariz;
			case BodyPartEnum.mejilla_L:
				return PartesHumanasParaAi.mejilla_l;
			case BodyPartEnum.mejilla_R:
				return PartesHumanasParaAi.mejilla_r;
			case BodyPartEnum.ojo_L:
				return PartesHumanasParaAi.ojo_l;
			case BodyPartEnum.ojo_R:
				return PartesHumanasParaAi.ojo_r;
			case BodyPartEnum.ojoInterno_L:
				return PartesHumanasParaAi.ojo_l;
			case BodyPartEnum.ojoInterno_R:
				return PartesHumanasParaAi.ojo_r;
			case BodyPartEnum.ceja_L:
				return PartesHumanasParaAi.ojo_l;
			case BodyPartEnum.ceja_R:
				return PartesHumanasParaAi.ojo_r;
			case BodyPartEnum.ciene_L:
				return PartesHumanasParaAi.cabeza_l;
			case BodyPartEnum.ciene_R:
				return PartesHumanasParaAi.cabeza_r;
			case BodyPartEnum.frente:
				return PartesHumanasParaAi.cara;
			case BodyPartEnum.pecho:
				return PartesHumanasParaAi.pecho;
			case BodyPartEnum.espalda:
				return PartesHumanasParaAi.espalda_alta;
			case BodyPartEnum.hombro_L:
				return PartesHumanasParaAi.hombro_l;
			case BodyPartEnum.hombro_R:
				return PartesHumanasParaAi.hombro_r;
			case BodyPartEnum.axila_L:
				return PartesHumanasParaAi.axila_l;
			case BodyPartEnum.axila_R:
				return PartesHumanasParaAi.axila_r;
			case BodyPartEnum.brazo_L:
				return PartesHumanasParaAi.brazo_l;
			case BodyPartEnum.brazo_R:
				return PartesHumanasParaAi.brazo_r;
			case BodyPartEnum.anteBrazo_L:
				return PartesHumanasParaAi.antebrazo_l;
			case BodyPartEnum.anteBrazo_R:
				return PartesHumanasParaAi.antebrazo_r;
			case BodyPartEnum.mano_L:
				return PartesHumanasParaAi.mano_l;
			case BodyPartEnum.mano_R:
				return PartesHumanasParaAi.mano_r;
			case BodyPartEnum.seno_L:
				return PartesHumanasParaAi.seno_l;
			case BodyPartEnum.seno_R:
				return PartesHumanasParaAi.seno_r;
			case BodyPartEnum.pezon_L:
				return PartesHumanasParaAi.pezon_l;
			case BodyPartEnum.pezon_R:
				return PartesHumanasParaAi.pezon_r;
			case BodyPartEnum.abdomen:
				return PartesHumanasParaAi.estomago;
			case BodyPartEnum.cintura:
				return PartesHumanasParaAi.cintura;
			case BodyPartEnum.cadera_L:
				return PartesHumanasParaAi.cintura_l;
			case BodyPartEnum.cadera_R:
				return PartesHumanasParaAi.cintura_r;
			case BodyPartEnum.coxis:
				return PartesHumanasParaAi.espalda_baja;
			case BodyPartEnum.vientre:
				return PartesHumanasParaAi.vientre;
			case BodyPartEnum.nalga_L:
				return PartesHumanasParaAi.gluteo_l;
			case BodyPartEnum.nalga_R:
				return PartesHumanasParaAi.gluteo_r;
			case BodyPartEnum.vagina:
				return PartesHumanasParaAi.vagina_cerca_clitoris;
			case BodyPartEnum.perineo:
				return PartesHumanasParaAi.ano;
			case BodyPartEnum.anoHole:
				return PartesHumanasParaAi.ano_hole;
			case BodyPartEnum.vagHole:
				return PartesHumanasParaAi.vag_hole;
			case BodyPartEnum.hombligo:
				return PartesHumanasParaAi.hombligo;
			case BodyPartEnum.pierna_L:
				return PartesHumanasParaAi.pierna_externa_l;
			case BodyPartEnum.pierna_R:
				return PartesHumanasParaAi.pierna_externa_r;
			case BodyPartEnum.rodilla_L:
				return PartesHumanasParaAi.rodilla_l;
			case BodyPartEnum.rodilla_R:
				return PartesHumanasParaAi.rodilla_r;
			case BodyPartEnum.canilla_L:
				return PartesHumanasParaAi.canilla_l;
			case BodyPartEnum.canilla_R:
				return PartesHumanasParaAi.canilla_r;
			case BodyPartEnum.pie_L:
				return PartesHumanasParaAi.pie_l;
			case BodyPartEnum.pie_R:
				return PartesHumanasParaAi.pie_r;
			case BodyPartEnum.lengua:
				return PartesHumanasParaAi.lengua;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x0004BCF0 File Offset: 0x00049EF0
		[Obsolete]
		public static PartesHumanasParaAi Parse(this CharTouchEnum parte, EstimuloTactilData data)
		{
			switch (data.side)
			{
			case Side.none:
			case Side.F:
			case Side.B:
				return parte.Parse();
			case Side.L:
				return parte.ParseToL();
			case Side.R:
				return parte.ParseToR();
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0004BD3C File Offset: 0x00049F3C
		[Obsolete]
		public static PartesHumanasParaAi ParseToL(this CharTouchEnum parte)
		{
			switch (parte)
			{
			case CharTouchEnum.anus:
				return PartesHumanasParaAi.ano;
			case CharTouchEnum.vag:
				return PartesHumanasParaAi.vag_entrada;
			case CharTouchEnum.facial:
				return PartesHumanasParaAi.cara_l;
			case CharTouchEnum.boob:
				return PartesHumanasParaAi.seno_l;
			case CharTouchEnum.ass:
				return PartesHumanasParaAi.gluteo_l;
			case CharTouchEnum.hand:
				return PartesHumanasParaAi.mano_l;
			case CharTouchEnum.head:
				return PartesHumanasParaAi.cabeza_l;
			case CharTouchEnum.chest:
				return PartesHumanasParaAi.pecho_r;
			case CharTouchEnum.waist:
				return PartesHumanasParaAi.cintura_l;
			case CharTouchEnum.hips:
				return PartesHumanasParaAi.cadera_l;
			case CharTouchEnum.upperLegs:
				return PartesHumanasParaAi.pierna_externa_l;
			case CharTouchEnum.others:
				return PartesHumanasParaAi.extremidades_l;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0004BDA8 File Offset: 0x00049FA8
		[Obsolete]
		public static PartesHumanasParaAi ParseToR(this CharTouchEnum parte)
		{
			switch (parte)
			{
			case CharTouchEnum.anus:
				return PartesHumanasParaAi.ano;
			case CharTouchEnum.vag:
				return PartesHumanasParaAi.vag_entrada;
			case CharTouchEnum.facial:
				return PartesHumanasParaAi.cara_r;
			case CharTouchEnum.boob:
				return PartesHumanasParaAi.seno_r;
			case CharTouchEnum.ass:
				return PartesHumanasParaAi.gluteo_r;
			case CharTouchEnum.hand:
				return PartesHumanasParaAi.mano_r;
			case CharTouchEnum.head:
				return PartesHumanasParaAi.cabeza_r;
			case CharTouchEnum.chest:
				return PartesHumanasParaAi.pecho_r;
			case CharTouchEnum.waist:
				return PartesHumanasParaAi.cintura_r;
			case CharTouchEnum.hips:
				return PartesHumanasParaAi.cadera_r;
			case CharTouchEnum.upperLegs:
				return PartesHumanasParaAi.pierna_externa_r;
			case CharTouchEnum.others:
				return PartesHumanasParaAi.extremidades_r;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x0004BE14 File Offset: 0x0004A014
		[Obsolete]
		public static PartesHumanasParaAi Parse(this CharTouchEnum parte)
		{
			switch (parte)
			{
			case CharTouchEnum.anus:
				return PartesHumanasParaAi.ano;
			case CharTouchEnum.vag:
				return PartesHumanasParaAi.vag_entrada;
			case CharTouchEnum.facial:
				return PartesHumanasParaAi.cara;
			case CharTouchEnum.boob:
				return PartesHumanasParaAi.senos;
			case CharTouchEnum.ass:
				return PartesHumanasParaAi.gluteos;
			case CharTouchEnum.hand:
				return PartesHumanasParaAi.manos;
			case CharTouchEnum.head:
				return PartesHumanasParaAi.cabeza;
			case CharTouchEnum.chest:
				return PartesHumanasParaAi.pecho;
			case CharTouchEnum.waist:
				return PartesHumanasParaAi.cintura;
			case CharTouchEnum.hips:
				return PartesHumanasParaAi.cadera;
			case CharTouchEnum.upperLegs:
				return PartesHumanasParaAi.piernas;
			case CharTouchEnum.others:
				return PartesHumanasParaAi.extremidades;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x0004BE80 File Offset: 0x0004A080
		public static PartesHumanasParaAi Parse(this FemalePenetracionTipo parte)
		{
			switch (parte)
			{
			case FemalePenetracionTipo.anus:
				return PartesHumanasParaAi.ano_hole;
			case FemalePenetracionTipo.vag:
				return PartesHumanasParaAi.vag_hole;
			case FemalePenetracionTipo.facial:
				return PartesHumanasParaAi.boca;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0004BEA4 File Offset: 0x0004A0A4
		[Obsolete]
		public static PartesHumanasParaAi Parse(this EstimuloTipo estimulo)
		{
			if (estimulo <= EstimuloTipo.penetracionAnus)
			{
				if (estimulo <= EstimuloTipo.clutch)
				{
					switch (estimulo)
					{
					case EstimuloTipo.None:
					case EstimuloTipo.noDefinido:
						return PartesHumanasParaAi.cuerpo;
					case EstimuloTipo.cariciaManos:
						return PartesHumanasParaAi.manos;
					case EstimuloTipo.noDefinido | EstimuloTipo.cariciaManos:
					case EstimuloTipo.noDefinido | EstimuloTipo.cariciaPiernas:
					case EstimuloTipo.cariciaManos | EstimuloTipo.cariciaPiernas:
					case EstimuloTipo.noDefinido | EstimuloTipo.cariciaManos | EstimuloTipo.cariciaPiernas:
						break;
					case EstimuloTipo.cariciaPiernas:
						return PartesHumanasParaAi.piernas;
					case EstimuloTipo.cariciaTorzo:
						return PartesHumanasParaAi.cuerpo;
					default:
						if (estimulo == EstimuloTipo.cariciaNoDefinido)
						{
							return PartesHumanasParaAi.cuerpo;
						}
						if (estimulo == EstimuloTipo.clutch)
						{
							return PartesHumanasParaAi.cuerpo;
						}
						break;
					}
				}
				else
				{
					if (estimulo == EstimuloTipo.penetracionNoDefinida)
					{
						return PartesHumanasParaAi.cuerpo;
					}
					if (estimulo == EstimuloTipo.penetracionVag)
					{
						return PartesHumanasParaAi.vag_hole;
					}
					if (estimulo == EstimuloTipo.penetracionAnus)
					{
						return PartesHumanasParaAi.ano_hole;
					}
				}
			}
			else if (estimulo <= EstimuloTipo.golpeNoDefinido)
			{
				if (estimulo == EstimuloTipo.penetracionFacial)
				{
					return PartesHumanasParaAi.boca;
				}
				if (estimulo == EstimuloTipo.beso)
				{
					return PartesHumanasParaAi.labiosDeBoca;
				}
				if (estimulo == EstimuloTipo.golpeNoDefinido)
				{
					return PartesHumanasParaAi.cuerpo;
				}
			}
			else
			{
				if (estimulo == EstimuloTipo.golpeManos)
				{
					return PartesHumanasParaAi.cuerpo;
				}
				if (estimulo == EstimuloTipo.golpePiernas)
				{
					return PartesHumanasParaAi.cuerpo;
				}
				if (estimulo == EstimuloTipo.golpeTorzo)
				{
					return PartesHumanasParaAi.cuerpo;
				}
			}
			throw new ArgumentOutOfRangeException(estimulo.ToString());
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0004BF7B File Offset: 0x0004A17B
		public static PartesHumanasParaAi Parse(this ZonaErogenaUbicacion parte)
		{
			switch (parte)
			{
			case ZonaErogenaUbicacion.cabeza:
				return PartesHumanasParaAi.cabeza;
			case ZonaErogenaUbicacion.pecho:
				return PartesHumanasParaAi.pecho;
			case ZonaErogenaUbicacion.cintura:
				return PartesHumanasParaAi.cintura;
			case ZonaErogenaUbicacion.cadera:
				return PartesHumanasParaAi.cadera;
			case ZonaErogenaUbicacion.entrepierna:
				return PartesHumanasParaAi.entrepierna;
			case ZonaErogenaUbicacion.brazos:
				return PartesHumanasParaAi.brazos;
			case ZonaErogenaUbicacion.piernas:
				return PartesHumanasParaAi.piernas;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
