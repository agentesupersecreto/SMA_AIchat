using System;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

// Token: 0x02000002 RID: 2
public static class ModdingParser
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static TipoDeEstimulo GetTipoDeEstimuloSimple(this InterationReceivedType inter, out DireccionDeEstimulo direccion)
	{
		direccion = DireccionDeEstimulo.recibida;
		switch (inter)
		{
		case InterationReceivedType.None:
			return TipoDeEstimulo.None;
		case InterationReceivedType.lookAt:
		case InterationReceivedType.photoshoot:
			return TipoDeEstimulo.visual;
		case InterationReceivedType.putInFront:
			direccion = DireccionDeEstimulo.dada;
			return TipoDeEstimulo.visual;
		case InterationReceivedType.caress:
		case InterationReceivedType.kiss:
		case InterationReceivedType.slap:
		case InterationReceivedType.hump:
		case InterationReceivedType.poke:
		case InterationReceivedType.dryhump:
		case InterationReceivedType.lick:
		case InterationReceivedType.pouringOn:
		case InterationReceivedType.pouringIn:
		case InterationReceivedType.punch:
			return TipoDeEstimulo.tactil;
		case InterationReceivedType.penetration:
		case InterationReceivedType.fingering:
		case InterationReceivedType.propped:
			return TipoDeEstimulo.coital;
		case InterationReceivedType.expose:
			return TipoDeEstimulo.desvestidura;
		case InterationReceivedType.askToExpose:
			return TipoDeEstimulo.peticionDesvestidura;
		case InterationReceivedType.forcePose:
			return TipoDeEstimulo.ejecucionDePose;
		case InterationReceivedType.askToPose:
			return TipoDeEstimulo.peticionEjecucionDePose;
		case InterationReceivedType.manipulateBody:
			return TipoDeEstimulo.manipulandoBone;
		case InterationReceivedType.guideBody:
			return TipoDeEstimulo.guiandoBone;
		case InterationReceivedType.handJob:
			return TipoDeEstimulo.tactil;
		default:
			throw new ArgumentOutOfRangeException(inter.ToString());
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020FB File Offset: 0x000002FB
	public static InterationReceivedType GetInterationReceivedType_Recibida(TipoDeEstimuloCoital coital)
	{
		switch (coital)
		{
		case TipoDeEstimuloCoital.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloCoital.conPene:
			return InterationReceivedType.penetration;
		case TipoDeEstimuloCoital.conDedo:
			return InterationReceivedType.fingering;
		case TipoDeEstimuloCoital.otros:
			return InterationReceivedType.propped;
		default:
			throw new ArgumentOutOfRangeException(coital.ToString());
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002132 File Offset: 0x00000332
	public static InterationReceivedType GetInterationReceivedType_Recibida(TipoDeEstimuloVisual visual)
	{
		switch (visual)
		{
		case TipoDeEstimuloVisual.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloVisual.normal:
			return InterationReceivedType.lookAt;
		case TipoDeEstimuloVisual.fotografiada:
			return InterationReceivedType.photoshoot;
		default:
			throw new ArgumentOutOfRangeException(visual.ToString());
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002160 File Offset: 0x00000360
	public static InterationReceivedType GetInterationReceivedType_Recibida(TipoDeEstimuloTactil tactil)
	{
		switch (tactil)
		{
		case TipoDeEstimuloTactil.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloTactil.caricia:
			return InterationReceivedType.caress;
		case TipoDeEstimuloTactil.golpe:
			return InterationReceivedType.punch;
		case TipoDeEstimuloTactil.beso:
			return InterationReceivedType.kiss;
		case TipoDeEstimuloTactil.lambida:
			return InterationReceivedType.lick;
		case TipoDeEstimuloTactil.derramamientoSobre:
			return InterationReceivedType.pouringOn;
		case TipoDeEstimuloTactil.derramamientoDentro:
			return InterationReceivedType.pouringIn;
		case TipoDeEstimuloTactil.poking:
			return InterationReceivedType.poke;
		case TipoDeEstimuloTactil.slapping:
			return InterationReceivedType.slap;
		case TipoDeEstimuloTactil.humping:
			return InterationReceivedType.hump;
		case TipoDeEstimuloTactil.dryHump:
			return InterationReceivedType.dryhump;
		default:
			throw new ArgumentOutOfRangeException(tactil.ToString());
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000021D0 File Offset: 0x000003D0
	public static InterationReceivedType GetInterationReceivedType_Recibida(this TipoDeEstimulo estimulo)
	{
		switch (estimulo)
		{
		case TipoDeEstimulo.None:
			return InterationReceivedType.None;
		case TipoDeEstimulo.tactil:
			return InterationReceivedType.caress;
		case TipoDeEstimulo.visual:
			return InterationReceivedType.lookAt;
		case TipoDeEstimulo.coital:
			return InterationReceivedType.penetration;
		case TipoDeEstimulo.desvestidura:
			return InterationReceivedType.expose;
		case TipoDeEstimulo.peticionDesvestidura:
			return InterationReceivedType.askToExpose;
		case TipoDeEstimulo.ejecucionDePose:
			return InterationReceivedType.forcePose;
		case TipoDeEstimulo.peticionEjecucionDePose:
			return InterationReceivedType.askToPose;
		case TipoDeEstimulo.guiandoBone:
			return InterationReceivedType.guideBody;
		case TipoDeEstimulo.manipulandoBone:
			return InterationReceivedType.manipulateBody;
		}
		throw new ArgumentOutOfRangeException(estimulo.ToString());
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002254 File Offset: 0x00000454
	public static InterationReceivedType GetInterationReceivedType(TipoDeEstimuloVisual visual, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante)
	{
		switch (visual)
		{
		case TipoDeEstimuloVisual.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloVisual.normal:
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return InterationReceivedType.lookAt;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			return InterationReceivedType.putInFront;
		case TipoDeEstimuloVisual.fotografiada:
			return InterationReceivedType.photoshoot;
		default:
			throw new ArgumentOutOfRangeException(visual.ToString());
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000020FB File Offset: 0x000002FB
	public static InterationReceivedType GetInterationReceivedType(TipoDeEstimuloCoital coital, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante)
	{
		switch (coital)
		{
		case TipoDeEstimuloCoital.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloCoital.conPene:
			return InterationReceivedType.penetration;
		case TipoDeEstimuloCoital.conDedo:
			return InterationReceivedType.fingering;
		case TipoDeEstimuloCoital.otros:
			return InterationReceivedType.propped;
		default:
			throw new ArgumentOutOfRangeException(coital.ToString());
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000022AC File Offset: 0x000004AC
	public static InterationReceivedType GetInterationReceivedType(TipoDeEstimuloTactil tactil, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante)
	{
		switch (tactil)
		{
		case TipoDeEstimuloTactil.None:
			return InterationReceivedType.None;
		case TipoDeEstimuloTactil.caricia:
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return InterationReceivedType.caress;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			return InterationReceivedType.caress;
		case TipoDeEstimuloTactil.golpe:
			return InterationReceivedType.punch;
		case TipoDeEstimuloTactil.beso:
			return InterationReceivedType.kiss;
		case TipoDeEstimuloTactil.lambida:
			return InterationReceivedType.lick;
		case TipoDeEstimuloTactil.derramamientoSobre:
			return InterationReceivedType.pouringOn;
		case TipoDeEstimuloTactil.derramamientoDentro:
			return InterationReceivedType.pouringIn;
		case TipoDeEstimuloTactil.poking:
			return InterationReceivedType.poke;
		case TipoDeEstimuloTactil.slapping:
			return InterationReceivedType.slap;
		case TipoDeEstimuloTactil.humping:
			return InterationReceivedType.hump;
		case TipoDeEstimuloTactil.dryHump:
			return InterationReceivedType.dryhump;
		default:
			throw new ArgumentOutOfRangeException(tactil.ToString());
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002338 File Offset: 0x00000538
	public static InterationReceivedType GetInterationReceivedType_Recibida(this TipoDeEstimulo tipoDeEstimulo, int subtipo)
	{
		switch (tipoDeEstimulo)
		{
		case TipoDeEstimulo.None:
			throw new NotSupportedException();
		case TipoDeEstimulo.tactil:
			return ModdingParser.GetInterationReceivedType_Recibida((TipoDeEstimuloTactil)subtipo);
		case TipoDeEstimulo.auditiva:
			break;
		case TipoDeEstimulo.visual:
			return ModdingParser.GetInterationReceivedType_Recibida((TipoDeEstimuloVisual)subtipo);
		default:
			if (tipoDeEstimulo == TipoDeEstimulo.coital)
			{
				return ModdingParser.GetInterationReceivedType_Recibida((TipoDeEstimuloCoital)subtipo);
			}
			break;
		}
		return tipoDeEstimulo.GetInterationReceivedType_Recibida();
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000238C File Offset: 0x0000058C
	public static InterationReceivedType GetInterationReceivedType(this TipoDeEstimulo tipoDeEstimulo, int subtipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante)
	{
		switch (tipoDeEstimulo)
		{
		case TipoDeEstimulo.None:
			throw new NotSupportedException();
		case TipoDeEstimulo.tactil:
			return ModdingParser.GetInterationReceivedType((TipoDeEstimuloTactil)subtipo, direccion, estimulada, estimulante);
		case TipoDeEstimulo.auditiva:
			break;
		case TipoDeEstimulo.visual:
			return ModdingParser.GetInterationReceivedType((TipoDeEstimuloVisual)subtipo, direccion, estimulada, estimulante);
		default:
			if (tipoDeEstimulo == TipoDeEstimulo.coital)
			{
				return ModdingParser.GetInterationReceivedType((TipoDeEstimuloCoital)subtipo, direccion, estimulada, estimulante);
			}
			break;
		}
		return tipoDeEstimulo.GetInterationReceivedType_Recibida();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000023EC File Offset: 0x000005EC
	public static ParteQuePuedeEstimular GetPartSimple(this TriggeringBodyPart parte)
	{
		switch (parte)
		{
		case TriggeringBodyPart.All:
			return (ParteQuePuedeEstimular)(-1);
		case TriggeringBodyPart.None:
			return ParteQuePuedeEstimular.None;
		case TriggeringBodyPart.notSpecified:
			return ParteQuePuedeEstimular.noEspecificada;
		case TriggeringBodyPart.eyes:
			return ParteQuePuedeEstimular.ojos;
		case TriggeringBodyPart.mouth:
			return ParteQuePuedeEstimular.boca;
		case TriggeringBodyPart.torso:
			return ParteQuePuedeEstimular.torzo;
		case TriggeringBodyPart.hand:
			return ParteQuePuedeEstimular.manos;
		case TriggeringBodyPart.finger:
			return ParteQuePuedeEstimular.dedo;
		case TriggeringBodyPart.leg:
			return ParteQuePuedeEstimular.piernas;
		case TriggeringBodyPart.tongue:
			return ParteQuePuedeEstimular.lengua;
		case TriggeringBodyPart.penis:
			return ParteQuePuedeEstimular.pene;
		case TriggeringBodyPart.toy:
		case TriggeringBodyPart.toyApplicator:
		case TriggeringBodyPart.tool:
			return ParteQuePuedeEstimular.propSexToy;
		case TriggeringBodyPart.semen:
		case TriggeringBodyPart.water:
		case TriggeringBodyPart.lubricant:
		case TriggeringBodyPart.orine:
			return ParteQuePuedeEstimular.semen;
		case TriggeringBodyPart.vagina:
			return ParteQuePuedeEstimular.propSexToy;
		case TriggeringBodyPart.anus:
			return ParteQuePuedeEstimular.noEspecificada;
		default:
			throw new ArgumentOutOfRangeException(parte.ToString());
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002498 File Offset: 0x00000698
	public static TriggeringBodyPart GetPartSimple(this ParteQuePuedeEstimular estimulanteParte)
	{
		if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
			{
				switch (estimulanteParte)
				{
				case ParteQuePuedeEstimular.None:
					return TriggeringBodyPart.None;
				case ParteQuePuedeEstimular.noEspecificada:
					return TriggeringBodyPart.notSpecified;
				case ParteQuePuedeEstimular.piernas:
					return TriggeringBodyPart.leg;
				case (ParteQuePuedeEstimular)3:
				case (ParteQuePuedeEstimular)5:
				case (ParteQuePuedeEstimular)6:
				case (ParteQuePuedeEstimular)7:
					break;
				case ParteQuePuedeEstimular.manos:
					return TriggeringBodyPart.hand;
				case ParteQuePuedeEstimular.pene:
					return TriggeringBodyPart.penis;
				default:
					if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
					{
						return TriggeringBodyPart.tool;
					}
					break;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.torzo)
				{
					return TriggeringBodyPart.torso;
				}
				if (estimulanteParte == ParteQuePuedeEstimular.lengua)
				{
					return TriggeringBodyPart.tongue;
				}
			}
		}
		else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
		{
			if (estimulanteParte == ParteQuePuedeEstimular.boca)
			{
				return TriggeringBodyPart.mouth;
			}
			if (estimulanteParte == ParteQuePuedeEstimular.ojos)
			{
				return TriggeringBodyPart.eyes;
			}
		}
		else
		{
			if (estimulanteParte == ParteQuePuedeEstimular.semen)
			{
				return TriggeringBodyPart.semen;
			}
			if (estimulanteParte == ParteQuePuedeEstimular.dedo)
			{
				return TriggeringBodyPart.finger;
			}
		}
		throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002548 File Offset: 0x00000748
	public static TriggeringBodyPart GetPartComplete(this ParteQuePuedeEstimular estimulanteParte, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo, int subTipoDeEstimulo, Component estimulanteReal, bool puedeSErParticulaDeSemen = false)
	{
		if (tipoDeEstimulo == TipoDeEstimulo.coital)
		{
			if (direccion == DireccionDeEstimulo.dada)
			{
				if (estimulanteParte == ParteQuePuedeEstimular.noEspecificada)
				{
					return TriggeringBodyPart.anus;
				}
				if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
				{
					return TriggeringBodyPart.vagina;
				}
				if (estimulanteParte != ParteQuePuedeEstimular.boca)
				{
					throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
				}
				return TriggeringBodyPart.mouth;
			}
			else if (estimulanteParte == ParteQuePuedeEstimular.propSexToy && estimulanteReal != null)
			{
				IPertenecibleDeCharacter componentInParent = estimulanteReal.GetComponentInParent<IPertenecibleDeCharacter>();
				IDefinedProp definedProp;
				if (componentInParent == null)
				{
					definedProp = null;
				}
				else
				{
					ICharacter inmediateOwner = componentInParent.inmediateOwner;
					definedProp = ((inmediateOwner != null) ? inmediateOwner.GetComponent<IDefinedProp>() : null);
				}
				IDefinedProp definedProp2 = definedProp;
				if (definedProp2 != null)
				{
					switch (definedProp2.tipo)
					{
					case TipoDeProp.bulbEnema:
					case TipoDeProp.jeringa:
					case TipoDeProp.lubeTube:
						return TriggeringBodyPart.toyApplicator;
					}
					return TriggeringBodyPart.toy;
				}
			}
		}
		if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
		{
			if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
			{
				switch (estimulanteParte)
				{
				case ParteQuePuedeEstimular.None:
					return TriggeringBodyPart.None;
				case ParteQuePuedeEstimular.noEspecificada:
					return TriggeringBodyPart.notSpecified;
				case ParteQuePuedeEstimular.piernas:
					return TriggeringBodyPart.leg;
				case (ParteQuePuedeEstimular)3:
				case (ParteQuePuedeEstimular)5:
				case (ParteQuePuedeEstimular)6:
				case (ParteQuePuedeEstimular)7:
					break;
				case ParteQuePuedeEstimular.manos:
					return TriggeringBodyPart.hand;
				case ParteQuePuedeEstimular.pene:
					return TriggeringBodyPart.penis;
				default:
					if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
					{
						return TriggeringBodyPart.tool;
					}
					break;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.torzo)
				{
					return TriggeringBodyPart.torso;
				}
				if (estimulanteParte == ParteQuePuedeEstimular.lengua)
				{
					return TriggeringBodyPart.tongue;
				}
			}
		}
		else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
		{
			if (estimulanteParte == ParteQuePuedeEstimular.boca)
			{
				return TriggeringBodyPart.mouth;
			}
			if (estimulanteParte == ParteQuePuedeEstimular.ojos)
			{
				return TriggeringBodyPart.eyes;
			}
		}
		else if (estimulanteParte != ParteQuePuedeEstimular.semen)
		{
			if (estimulanteParte == ParteQuePuedeEstimular.dedo)
			{
				return TriggeringBodyPart.finger;
			}
		}
		else
		{
			if (!puedeSErParticulaDeSemen)
			{
				return TriggeringBodyPart.semen;
			}
			switch (subTipoDeEstimulo)
			{
			case 0:
				return TriggeringBodyPart.semen;
			case 1:
				return TriggeringBodyPart.water;
			case 2:
				return TriggeringBodyPart.lubricant;
			case 3:
				return TriggeringBodyPart.orine;
			default:
			{
				TipoDeSemen tipoDeSemen = (TipoDeSemen)subTipoDeEstimulo;
				throw new ArgumentOutOfRangeException(tipoDeSemen.ToString());
			}
			}
		}
		throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000026D0 File Offset: 0x000008D0
	public static SensitiveBodyPart GetHolePart(ParteDelCuerpoHumano estimuladaParte, SensitiveFemaleHoleType type)
	{
		if (estimuladaParte != ParteDelCuerpoHumano.bocaInterno)
		{
			if (estimuladaParte != ParteDelCuerpoHumano.ano)
			{
				if (estimuladaParte != ParteDelCuerpoHumano.vag)
				{
					throw new ArgumentOutOfRangeException(estimuladaParte.ToString());
				}
				switch (type)
				{
				case SensitiveFemaleHoleType.hole:
					return SensitiveBodyPart.vag;
				case SensitiveFemaleHoleType.walls:
					return SensitiveBodyPart.vagWalls;
				case SensitiveFemaleHoleType.bottom:
					return SensitiveBodyPart.vagBottom;
				default:
					throw new ArgumentOutOfRangeException(type.ToString());
				}
			}
			else
			{
				switch (type)
				{
				case SensitiveFemaleHoleType.hole:
					return SensitiveBodyPart.anus;
				case SensitiveFemaleHoleType.walls:
					return SensitiveBodyPart.anusWalls;
				case SensitiveFemaleHoleType.bottom:
					return SensitiveBodyPart.anusBottom;
				default:
					throw new ArgumentOutOfRangeException(type.ToString());
				}
			}
		}
		else
		{
			switch (type)
			{
			case SensitiveFemaleHoleType.hole:
				return SensitiveBodyPart.throat;
			case SensitiveFemaleHoleType.walls:
				return SensitiveBodyPart.throatWalls;
			case SensitiveFemaleHoleType.bottom:
				return SensitiveBodyPart.throatBottom;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000279C File Offset: 0x0000099C
	public static ParteDelCuerpoHumano GetPart(this SensitiveBodyPart part)
	{
		switch (part)
		{
		case SensitiveBodyPart.head:
			return ParteDelCuerpoHumano.cabeza;
		case SensitiveBodyPart.temples:
			return ParteDelCuerpoHumano.cienes;
		case SensitiveBodyPart.forehead:
			return ParteDelCuerpoHumano.frente;
		case SensitiveBodyPart.nose:
			return ParteDelCuerpoHumano.nariz;
		case SensitiveBodyPart.cheeks:
			return ParteDelCuerpoHumano.mejillas;
		case SensitiveBodyPart.eyes:
			return ParteDelCuerpoHumano.ojos;
		case SensitiveBodyPart.eyeballs:
			return ParteDelCuerpoHumano.globosOculares;
		case SensitiveBodyPart.eyebrows:
			return ParteDelCuerpoHumano.cejas;
		case SensitiveBodyPart.jaw:
			return ParteDelCuerpoHumano.mandibula;
		case SensitiveBodyPart.lips:
			return ParteDelCuerpoHumano.labios;
		case SensitiveBodyPart.tongue:
			return ParteDelCuerpoHumano.lengua;
		case SensitiveBodyPart.ears:
			return ParteDelCuerpoHumano.orejas;
		case SensitiveBodyPart.neck:
			return ParteDelCuerpoHumano.cuello;
		case SensitiveBodyPart.shoulders:
			return ParteDelCuerpoHumano.hombros;
		case SensitiveBodyPart.armpits:
			return ParteDelCuerpoHumano.axilas;
		case SensitiveBodyPart.arms:
			return ParteDelCuerpoHumano.brazos;
		case SensitiveBodyPart.forearms:
			return ParteDelCuerpoHumano.anteBrazos;
		case SensitiveBodyPart.hands:
			return ParteDelCuerpoHumano.manos;
		case SensitiveBodyPart.chest:
			return ParteDelCuerpoHumano.pecho;
		case SensitiveBodyPart.breasts:
			return ParteDelCuerpoHumano.senos;
		case SensitiveBodyPart.nipples:
			return ParteDelCuerpoHumano.pezones;
		case SensitiveBodyPart.back:
			return ParteDelCuerpoHumano.espalda;
		case SensitiveBodyPart.abdomen:
			return ParteDelCuerpoHumano.abdomen;
		case SensitiveBodyPart.waist:
			return ParteDelCuerpoHumano.cintura;
		case SensitiveBodyPart.hips:
			return ParteDelCuerpoHumano.caderas;
		case SensitiveBodyPart.belly:
			return ParteDelCuerpoHumano.vientre;
		case SensitiveBodyPart.navel:
			return ParteDelCuerpoHumano.hombligo;
		case SensitiveBodyPart.coccyx:
			return ParteDelCuerpoHumano.coxis;
		case SensitiveBodyPart.buttocks:
			return ParteDelCuerpoHumano.nalgas;
		case SensitiveBodyPart.crotch:
			return ParteDelCuerpoHumano.vientreBajo;
		case SensitiveBodyPart.vaginalLipsOrBalls:
			return ParteDelCuerpoHumano.labiosVaginales;
		case SensitiveBodyPart.clitorisOrPenis:
			return ParteDelCuerpoHumano.clitoris;
		case SensitiveBodyPart.perineum:
			return ParteDelCuerpoHumano.perineo;
		case SensitiveBodyPart.legs:
			return ParteDelCuerpoHumano.piernas;
		case SensitiveBodyPart.knees:
			return ParteDelCuerpoHumano.rodillas;
		case SensitiveBodyPart.calf:
			return ParteDelCuerpoHumano.canillas;
		case SensitiveBodyPart.feet:
			return ParteDelCuerpoHumano.pies;
		case SensitiveBodyPart.throat:
		case SensitiveBodyPart.throatBottom:
		case SensitiveBodyPart.throatWalls:
			return ParteDelCuerpoHumano.bocaInterno;
		case SensitiveBodyPart.vag:
		case SensitiveBodyPart.vagBottom:
		case SensitiveBodyPart.vagWalls:
			return ParteDelCuerpoHumano.vag;
		case SensitiveBodyPart.anus:
		case SensitiveBodyPart.anusBottom:
		case SensitiveBodyPart.anusWalls:
			return ParteDelCuerpoHumano.ano;
		default:
			throw new ArgumentOutOfRangeException(part.ToString());
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000028EC File Offset: 0x00000AEC
	public static SensitiveBodyPart GetPart(this ParteDelCuerpoHumano estimuladaParte)
	{
		switch (estimuladaParte)
		{
		case ParteDelCuerpoHumano.pecho:
			return SensitiveBodyPart.chest;
		case ParteDelCuerpoHumano.espalda:
			return SensitiveBodyPart.back;
		case ParteDelCuerpoHumano.abdomen:
			return SensitiveBodyPart.abdomen;
		case ParteDelCuerpoHumano.cintura:
			return SensitiveBodyPart.waist;
		case ParteDelCuerpoHumano.caderas:
			return SensitiveBodyPart.hips;
		case ParteDelCuerpoHumano.cabeza:
			return SensitiveBodyPart.head;
		case ParteDelCuerpoHumano.cuello:
			return SensitiveBodyPart.neck;
		case ParteDelCuerpoHumano.mandibula:
			return SensitiveBodyPart.jaw;
		case ParteDelCuerpoHumano.labios:
			return SensitiveBodyPart.lips;
		case ParteDelCuerpoHumano.bocaInterno:
			return SensitiveBodyPart.throat;
		case ParteDelCuerpoHumano.nariz:
			return SensitiveBodyPart.nose;
		case ParteDelCuerpoHumano.mejillas:
			return SensitiveBodyPart.cheeks;
		case ParteDelCuerpoHumano.ojos:
			return SensitiveBodyPart.eyes;
		case ParteDelCuerpoHumano.globosOculares:
			return SensitiveBodyPart.eyeballs;
		case ParteDelCuerpoHumano.cejas:
			return SensitiveBodyPart.eyebrows;
		case ParteDelCuerpoHumano.cienes:
			return SensitiveBodyPart.temples;
		case ParteDelCuerpoHumano.frente:
			return SensitiveBodyPart.forehead;
		case ParteDelCuerpoHumano.hombros:
			return SensitiveBodyPart.shoulders;
		case ParteDelCuerpoHumano.axilas:
			return SensitiveBodyPart.armpits;
		case ParteDelCuerpoHumano.brazos:
			return SensitiveBodyPart.arms;
		case ParteDelCuerpoHumano.anteBrazos:
			return SensitiveBodyPart.forearms;
		case ParteDelCuerpoHumano.manos:
			return SensitiveBodyPart.hands;
		case ParteDelCuerpoHumano.senos:
			return SensitiveBodyPart.breasts;
		case ParteDelCuerpoHumano.pezones:
			return SensitiveBodyPart.nipples;
		case ParteDelCuerpoHumano.coxis:
			return SensitiveBodyPart.coccyx;
		case ParteDelCuerpoHumano.vientre:
			return SensitiveBodyPart.belly;
		case ParteDelCuerpoHumano.nalgas:
			return SensitiveBodyPart.buttocks;
		case ParteDelCuerpoHumano.vientreBajo:
			return SensitiveBodyPart.crotch;
		case ParteDelCuerpoHumano.labiosVaginales:
			return SensitiveBodyPart.vaginalLipsOrBalls;
		case ParteDelCuerpoHumano.clitoris:
			return SensitiveBodyPart.clitorisOrPenis;
		case ParteDelCuerpoHumano.perineo:
			return SensitiveBodyPart.perineum;
		case ParteDelCuerpoHumano.ano:
			return SensitiveBodyPart.anus;
		case ParteDelCuerpoHumano.vag:
			return SensitiveBodyPart.vag;
		case ParteDelCuerpoHumano.hombligo:
			return SensitiveBodyPart.navel;
		case ParteDelCuerpoHumano.piernas:
			return SensitiveBodyPart.legs;
		case ParteDelCuerpoHumano.rodillas:
			return SensitiveBodyPart.knees;
		case ParteDelCuerpoHumano.canillas:
			return SensitiveBodyPart.calf;
		case ParteDelCuerpoHumano.pies:
			return SensitiveBodyPart.feet;
		case ParteDelCuerpoHumano.lengua:
			return SensitiveBodyPart.tongue;
		case ParteDelCuerpoHumano.orejas:
			return SensitiveBodyPart.ears;
		case ParteDelCuerpoHumano.pene:
			return SensitiveBodyPart.clitorisOrPenis;
		case ParteDelCuerpoHumano.testiculos:
			return SensitiveBodyPart.vaginalLipsOrBalls;
		default:
			throw new ArgumentOutOfRangeException(estimuladaParte.ToString());
		}
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002A34 File Offset: 0x00000C34
	public static PersonalidadRasgoCompleto Parse(this PersonalityTraits trait)
	{
		switch (trait)
		{
		case PersonalityTraits.None:
			return PersonalidadRasgoCompleto.None;
		case PersonalityTraits.pragmatism:
			return PersonalidadRasgoCompleto.pragmatismo;
		case PersonalityTraits.Imagination:
			return PersonalidadRasgoCompleto.Imaginacion;
		case PersonalityTraits.secure:
			return PersonalidadRasgoCompleto.seguro;
		case PersonalityTraits.Concerned:
			return PersonalidadRasgoCompleto.Preocupacion;
		case PersonalityTraits.submissive:
			return PersonalidadRasgoCompleto.sumiso;
		case PersonalityTraits.Dominant:
			return PersonalidadRasgoCompleto.Dominante;
		case PersonalityTraits.unstable:
			return PersonalidadRasgoCompleto.inestable;
		case PersonalityTraits.Calm:
			return PersonalidadRasgoCompleto.Calmado;
		case PersonalityTraits.content:
			return PersonalidadRasgoCompleto.contenido;
		case PersonalityTraits.Spontaneous:
			return PersonalidadRasgoCompleto.Espontaneo;
		case PersonalityTraits.attachedToTheFamiliar:
			return PersonalidadRasgoCompleto.apegadoALoFamiliar;
		case PersonalityTraits.Flexible:
			return PersonalidadRasgoCompleto.Flexible;
		case PersonalityTraits.undisciplined:
			return PersonalidadRasgoCompleto.indisciplinado;
		case PersonalityTraits.Controlled:
			return PersonalidadRasgoCompleto.Controlado;
		case PersonalityTraits.open:
			return PersonalidadRasgoCompleto.abierto;
		case PersonalityTraits.Discreet:
			return PersonalidadRasgoCompleto.Discreto;
		case PersonalityTraits.concrete:
			return PersonalidadRasgoCompleto.concreto;
		case PersonalityTraits.Abstract:
			return PersonalidadRasgoCompleto.Abstracto;
		case PersonalityTraits.nonConforming:
			return PersonalidadRasgoCompleto.noConforme;
		case PersonalityTraits.ConformingToStandards:
			return PersonalidadRasgoCompleto.ConformeALasNormas;
		case PersonalityTraits.dependency:
			return PersonalidadRasgoCompleto.dependencia;
		case PersonalityTraits.SelfSufficiency:
			return PersonalidadRasgoCompleto.Autosuficiencia;
		case PersonalityTraits.toughness:
			return PersonalidadRasgoCompleto.dureza;
		case PersonalityTraits.Sweetness:
			return PersonalidadRasgoCompleto.Calidez;
		case PersonalityTraits.shy:
			return PersonalidadRasgoCompleto.timido;
		case PersonalityTraits.Uninhibited:
			return PersonalidadRasgoCompleto.Desinhibido;
		case PersonalityTraits.relaxed:
			return PersonalidadRasgoCompleto.relajado;
		case PersonalityTraits.Impatient:
			return PersonalidadRasgoCompleto.Impaciente;
		case PersonalityTraits.confident:
			return PersonalidadRasgoCompleto.confiado;
		case PersonalityTraits.Distrustful:
			return PersonalidadRasgoCompleto.Desconfiado;
		case PersonalityTraits.reserved:
			return PersonalidadRasgoCompleto.reservado;
		case PersonalityTraits.Outgoing:
			return PersonalidadRasgoCompleto.Extrovertido;
		case PersonalityTraits.sensitive:
			return PersonalidadRasgoCompleto.sensible;
		case PersonalityTraits.Resilient:
			return PersonalidadRasgoCompleto.Resistente;
		default:
			throw new ArgumentOutOfRangeException(trait.ToString());
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002B48 File Offset: 0x00000D48
	public static ReaccionHumana Parse(this Emotion emotion)
	{
		switch (emotion)
		{
		case Emotion.None:
			return ReaccionHumana.None;
		case Emotion.enjoyment:
			return ReaccionHumana.alegria;
		case Emotion.relief:
			return ReaccionHumana.alivio;
		case Emotion.favorability:
			return ReaccionHumana.concentToHero;
		case Emotion.pleasure:
			return ReaccionHumana.placer;
		case Emotion.arousal:
			return ReaccionHumana.arousal;
		case Emotion.disappointment:
			return ReaccionHumana.decepcion;
		case Emotion.rage:
			return ReaccionHumana.rabia;
		case Emotion.pain:
			return ReaccionHumana.dolor;
		case Emotion.fear:
			return ReaccionHumana.miedo;
		case Emotion.disgust:
			return ReaccionHumana.asco;
		default:
			throw new ArgumentOutOfRangeException(emotion.ToString());
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002BC4 File Offset: 0x00000DC4
	public static Language GetLanguage()
	{
		Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
		if (id > Localizacion.US)
		{
			if (id != Localizacion.ES)
			{
			}
			throw new ArgumentOutOfRangeException(id.ToString());
		}
		return Language.en;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002C00 File Offset: 0x00000E00
	public static bool TryParse(this ReaccionHumana reaccion, out Emotion emo)
	{
		emo = Emotion.None;
		if (reaccion <= ReaccionHumana.miedo)
		{
			if (reaccion <= ReaccionHumana.placer)
			{
				switch (reaccion)
				{
				case ReaccionHumana.None:
					emo = Emotion.None;
					return true;
				case ReaccionHumana.concentToHero:
					emo = Emotion.favorability;
					return true;
				case ReaccionHumana.asombro:
				case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
				case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
				case ReaccionHumana.asombro | ReaccionHumana.dolor:
				case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
					break;
				case ReaccionHumana.dolor:
					emo = Emotion.pain;
					return true;
				case ReaccionHumana.rabia:
					emo = Emotion.rage;
					return true;
				default:
					if (reaccion == ReaccionHumana.asco)
					{
						emo = Emotion.disgust;
						return true;
					}
					if (reaccion == ReaccionHumana.placer)
					{
						emo = Emotion.pleasure;
						return true;
					}
					break;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.arousal)
				{
					emo = Emotion.arousal;
					return true;
				}
				if (reaccion != ReaccionHumana.tristeza)
				{
					if (reaccion == ReaccionHumana.miedo)
					{
						emo = Emotion.fear;
						return true;
					}
				}
			}
		}
		else if (reaccion <= ReaccionHumana.decepcion)
		{
			if (reaccion == ReaccionHumana.alegria)
			{
				emo = Emotion.enjoyment;
				return true;
			}
			if (reaccion != ReaccionHumana.felicidad)
			{
				if (reaccion == ReaccionHumana.decepcion)
				{
					emo = Emotion.disappointment;
					return true;
				}
			}
		}
		else
		{
			if (reaccion == ReaccionHumana.alivio)
			{
				emo = Emotion.relief;
				return true;
			}
			if (reaccion != ReaccionHumana.aburrimiento && reaccion != ReaccionHumana.desHielo)
			{
			}
		}
		return false;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002CE8 File Offset: 0x00000EE8
	public static Emotion Parse(this ReaccionHumana reaccion)
	{
		if (reaccion <= ReaccionHumana.miedo)
		{
			if (reaccion <= ReaccionHumana.placer)
			{
				switch (reaccion)
				{
				case ReaccionHumana.None:
					return Emotion.None;
				case ReaccionHumana.concentToHero:
					return Emotion.favorability;
				case ReaccionHumana.asombro:
				case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
				case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
				case ReaccionHumana.asombro | ReaccionHumana.dolor:
				case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
					break;
				case ReaccionHumana.dolor:
					return Emotion.pain;
				case ReaccionHumana.rabia:
					return Emotion.rage;
				default:
					if (reaccion == ReaccionHumana.asco)
					{
						return Emotion.disgust;
					}
					if (reaccion == ReaccionHumana.placer)
					{
						return Emotion.pleasure;
					}
					break;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.arousal)
				{
					return Emotion.arousal;
				}
				if (reaccion != ReaccionHumana.tristeza)
				{
					if (reaccion == ReaccionHumana.miedo)
					{
						return Emotion.fear;
					}
				}
			}
		}
		else if (reaccion <= ReaccionHumana.decepcion)
		{
			if (reaccion == ReaccionHumana.alegria)
			{
				return Emotion.enjoyment;
			}
			if (reaccion != ReaccionHumana.felicidad)
			{
				if (reaccion == ReaccionHumana.decepcion)
				{
					return Emotion.disappointment;
				}
			}
		}
		else
		{
			if (reaccion == ReaccionHumana.alivio)
			{
				return Emotion.relief;
			}
			if (reaccion != ReaccionHumana.aburrimiento && reaccion != ReaccionHumana.desHielo)
			{
			}
		}
		throw new ArgumentOutOfRangeException(reaccion.ToString());
	}
}
