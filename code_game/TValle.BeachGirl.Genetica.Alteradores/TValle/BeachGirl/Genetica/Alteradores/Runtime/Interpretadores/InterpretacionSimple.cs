using System;
using Assets.Base.Plugins.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000049 RID: 73
	[UnTittle]
	[Serializable]
	public struct InterpretacionSimple
	{
		// Token: 0x0600034A RID: 842 RVA: 0x000085D0 File Offset: 0x000067D0
		public void ConvertirA(ref InterpretacionCompletaDeFemale completa)
		{
			completa.interpretacionDeBodySuperficial.altura = this.height;
			switch (this.bodyType)
			{
			case Interpretacion.BodyType.normal:
				completa.interpretacionDeAss.size = Interpretacion.Size.normal;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.normal;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.normal;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.size = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.normal;
				break;
			case Interpretacion.BodyType.slender:
				completa.interpretacionDeAss.size = Interpretacion.Size.small;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.normal;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.veryLong;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.small;
				completa.interpretacionDeSenos.size = Interpretacion.Size.small;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.close;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.small;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.small;
				break;
			case Interpretacion.BodyType.curvy:
				completa.interpretacionDeAss.size = Interpretacion.Size.large;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.small;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.normal;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.veryLarge;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.small;
				completa.interpretacionDeSenos.size = Interpretacion.Size.large;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.large;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.large;
				break;
			case Interpretacion.BodyType.chubby:
				completa.interpretacionDeAss.size = Interpretacion.Size.large;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.high;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.small;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.normal;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.small;
				completa.interpretacionDeSenos.size = Interpretacion.Size.large;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.large;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.large;
				break;
			case Interpretacion.BodyType.fat:
				completa.interpretacionDeAss.size = Interpretacion.Size.normal;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.verySmall;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.normal;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.size = Interpretacion.Size.large;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.distant;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.large;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.large;
				break;
			case Interpretacion.BodyType.athletic:
				completa.interpretacionDeAss.size = Interpretacion.Size.normal;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.veryLarge;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@long;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.large;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.size = Interpretacion.Size.small;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.close;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.verySmall;
				break;
			case Interpretacion.BodyType.voluptuous:
				completa.interpretacionDeAss.size = Interpretacion.Size.large;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.high;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.normal;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.medium;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@long;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.large;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.size = Interpretacion.Size.large;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.close;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.normal;
				break;
			case Interpretacion.BodyType.pear:
				completa.interpretacionDeAss.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.verySmall;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@short;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.veryLarge;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.size = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.close;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.verySmall;
				break;
			case Interpretacion.BodyType.milker:
				completa.interpretacionDeAss.size = Interpretacion.Size.small;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.normal;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@long;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.small;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.distant;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.veryLarge;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.veryLarge;
				break;
			case Interpretacion.BodyType.milkyPear:
				completa.interpretacionDeAss.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.verySmall;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.low;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@short;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.veryLarge;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeSenos.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.distant;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.veryLarge;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.veryLarge;
				break;
			case Interpretacion.BodyType.strong:
				completa.interpretacionDeAss.size = Interpretacion.Size.large;
				completa.interpretacionDeAss.projection = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeAss.anusGap = Interpretacion.Size.normal;
				completa.interpretacionDeAss.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.bodyfat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeBodySuperficial.ribcageThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.headsize = Interpretacion.Size.verySmall;
				completa.interpretacionDeBodySuperficial.neckThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.neckLength = Interpretacion.Length.@short;
				completa.interpretacionDeBodySuperficial.armsThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.forearmsThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.handsSize = Interpretacion.Size.normal;
				completa.interpretacionDeBodySuperficial.cinturaThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeBodySuperficial.caderaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeBodySuperficial.caderaAltura = Interpretacion.Capacidad.high;
				completa.interpretacionDeBodySuperficial.thighgap = Interpretacion.Size.large;
				completa.interpretacionDeBodySuperficial.thighThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.calfThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeBodySuperficial.feetSize = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.size = Interpretacion.Size.normal;
				completa.interpretacionDeSenos.projection = Interpretacion.Capacidad.low;
				completa.interpretacionDeSenos.distance = Interpretacion.Distance.close;
				completa.interpretacionDeSenos.sagginess = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.nippleSize = Interpretacion.Size.small;
				completa.interpretacionDeSenos.areolaSize = Interpretacion.Size.small;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.bodyType.ToString());
			}
			completa.interpretacionDeBodySkin.skinTone = this.skinTone;
			completa.interpretacionDeSenos.nippleColor = this.nippleColor;
			completa.interpretacionDeHair.color = this.hairColor;
			completa.interpretacionDeHair.curls = this.hairCurls;
			completa.interpretacionDeHair.length = this.hairLength;
			completa.interpretacionDeEyebrows.color = this.hairColor.ConvertToAlpha();
			completa.interpretacionDePubicHair.color = this.hairColor;
			switch (this.faceTypeV2)
			{
			case Interpretacion.FaceTypeV2.caucasian:
				completa.interpretacionDeRaza.african = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.nordic = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeRaza.asian = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.hispanic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.elf = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRostro.collapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.aging = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.thickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeRostro.square = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.heart = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.round = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.foreHeadWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeRostro.foreHeadProjection = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeEyebrows.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyebrows.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyebrows.thickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeEyebrows.length = Interpretacion.Length.normal;
				completa.interpretacionDeEyebrows.ridgeSize = Interpretacion.Size.normal;
				completa.interpretacionDeEyebrows.angle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeEyes.size = Interpretacion.Size.normal;
				completa.interpretacionDeEyes.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.depth = Interpretacion.Depth.normal;
				completa.interpretacionDeEyes.amplitude = Interpretacion.Amplitude.normal;
				completa.interpretacionDeEyes.angle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeEyes.irisSize = Interpretacion.Size.normal;
				completa.interpretacionDeEyes.eyelidHeavy = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeEyes.eyelidDistance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.eyelidDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeEyes.upperEyelidSmooth = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.upperEyelidHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelidTopFlat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopInHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.lowerEyelidHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelidBottomDefine = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidBottomOutHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.wrinkleInner = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelashesLength = Interpretacion.Length.normal;
				completa.interpretacionDeEyes.lacrimalDistance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.lacrimalExposure = Interpretacion.Capacidad.medium;
				completa.interpretacionDeCheeks.cheekBonesSize = Interpretacion.Size.large;
				completa.interpretacionDeCheeks.cheekBonesHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeCheeks.fat = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeCheeks.sink = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.size = Interpretacion.Size.normal;
				completa.interpretacionDeNose.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.proyection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.pinch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.chisel = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.bridgeHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeNose.bridgeSmoothness = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.ridgeBump = Interpretacion.Size.normal;
				completa.interpretacionDeNose.ridgeSlope = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.tipRoundness = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeNose.tipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.tipDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeNose.tipHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.tipSlope = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.nostrilThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.nostrilDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeNose.nostrilAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeNose.nostrilSize = Interpretacion.Size.normal;
				completa.interpretacionDeNose.nostrilCollapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.nostrilHeight = Interpretacion.Height.normal;
				completa.interpretacionDeNose.septumWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.septumHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.philtrumConcave = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.normal;
				completa.interpretacionDeMouth.angle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.cornerAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.curves = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.heart = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeMouth.edgeDefine = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.topPeak = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.upperCurves = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.upperLipMiddleThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.lowerLipWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeMouth.lowerDepth = Interpretacion.Depth.veryDeep;
				completa.interpretacionDeMouth.grooveDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeMouth.grooveAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.grooveTone = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.grooveWidth = Interpretacion.CantidadNoContable.some;
				break;
			case Interpretacion.FaceTypeV2.afreican:
				completa.interpretacionDeRaza.african = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeRaza.nordic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.asian = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.hispanic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.elf = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRostro.collapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.aging = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.thickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeRostro.square = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.heart = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.round = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.foreHeadWidth = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeRostro.foreHeadProjection = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeEyebrows.height = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyebrows.distance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyebrows.thickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeEyebrows.length = Interpretacion.Length.normal;
				completa.interpretacionDeEyebrows.ridgeSize = Interpretacion.Size.large;
				completa.interpretacionDeEyebrows.angle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeEyes.size = Interpretacion.Size.large;
				completa.interpretacionDeEyes.height = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.depth = Interpretacion.Depth.normal;
				completa.interpretacionDeEyes.amplitude = Interpretacion.Amplitude.normal;
				completa.interpretacionDeEyes.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.irisSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeEyes.eyelidHeavy = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeEyes.eyelidDistance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.eyelidDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeEyes.upperEyelidSmooth = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.upperEyelidHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.eyelidTopFlat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopInHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.lowerEyelidHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelidBottomDefine = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidBottomOutHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.wrinkleInner = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelashesLength = Interpretacion.Length.normal;
				completa.interpretacionDeEyes.lacrimalDistance = Interpretacion.Distance.close;
				completa.interpretacionDeEyes.lacrimalExposure = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.cheekBonesSize = Interpretacion.Size.large;
				completa.interpretacionDeCheeks.cheekBonesHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeCheeks.fat = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeCheeks.sink = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.size = Interpretacion.Size.large;
				completa.interpretacionDeNose.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.proyection = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.pinch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.chisel = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.bridgeThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeNose.bridgeHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.bridgeDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeNose.bridgeSmoothness = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.ridgeBump = Interpretacion.Size.normal;
				completa.interpretacionDeNose.ridgeSlope = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.tipRoundness = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeNose.tipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeNose.tipDepth = Interpretacion.Depth.deep;
				completa.interpretacionDeNose.tipHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.tipSlope = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeNose.nostrilThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeNose.nostrilDepth = Interpretacion.Depth.shallow;
				completa.interpretacionDeNose.nostrilAngle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeNose.nostrilSize = Interpretacion.Size.large;
				completa.interpretacionDeNose.nostrilCollapse = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.nostrilHeight = Interpretacion.Height.tall;
				completa.interpretacionDeNose.septumWidth = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeNose.septumHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.philtrumConcave = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.wide;
				completa.interpretacionDeMouth.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeMouth.cornerAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.curves = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.heart = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.edgeDefine = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.topPeak = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.upperCurves = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.upperLipMiddleThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeMouth.lowerLipWidth = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeMouth.lowerDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeMouth.grooveDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeMouth.grooveAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.grooveTone = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.grooveWidth = Interpretacion.CantidadNoContable.some;
				break;
			case Interpretacion.FaceTypeV2.asian:
				completa.interpretacionDeRaza.african = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.nordic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.asian = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeRaza.hispanic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.elf = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRostro.collapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.aging = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.thickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeRostro.square = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.heart = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.round = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.foreHeadWidth = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeRostro.foreHeadProjection = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeEyebrows.height = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyebrows.distance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyebrows.thickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeEyebrows.length = Interpretacion.Length.normal;
				completa.interpretacionDeEyebrows.ridgeSize = Interpretacion.Size.small;
				completa.interpretacionDeEyebrows.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.size = Interpretacion.Size.large;
				completa.interpretacionDeEyes.height = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.distance = Interpretacion.Distance.close;
				completa.interpretacionDeEyes.depth = Interpretacion.Depth.shallow;
				completa.interpretacionDeEyes.amplitude = Interpretacion.Amplitude.normal;
				completa.interpretacionDeEyes.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.irisSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeEyes.eyelidHeavy = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeEyes.eyelidDistance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyes.eyelidDepth = Interpretacion.Depth.shallow;
				completa.interpretacionDeEyes.upperEyelidSmooth = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.upperEyelidHeight = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopFlat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopInHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.lowerEyelidHeight = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeEyes.eyelidBottomDefine = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeEyes.eyelidBottomOutHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.wrinkleInner = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.eyelashesLength = Interpretacion.Length.@short;
				completa.interpretacionDeEyes.lacrimalDistance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyes.lacrimalExposure = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.cheekBonesSize = Interpretacion.Size.small;
				completa.interpretacionDeCheeks.cheekBonesHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.fat = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeCheeks.sink = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeNose.size = Interpretacion.Size.normal;
				completa.interpretacionDeNose.height = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.proyection = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.pinch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.chisel = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeNose.bridgeHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.bridgeDepth = Interpretacion.Depth.deep;
				completa.interpretacionDeNose.bridgeSmoothness = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.ridgeBump = Interpretacion.Size.small;
				completa.interpretacionDeNose.ridgeSlope = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.tipRoundness = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeNose.tipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.tipDepth = Interpretacion.Depth.deep;
				completa.interpretacionDeNose.tipHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.tipSlope = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeNose.nostrilThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeNose.nostrilDepth = Interpretacion.Depth.shallow;
				completa.interpretacionDeNose.nostrilAngle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeNose.nostrilSize = Interpretacion.Size.large;
				completa.interpretacionDeNose.nostrilCollapse = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.nostrilHeight = Interpretacion.Height.normal;
				completa.interpretacionDeNose.septumWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.septumHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.philtrumConcave = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.normal;
				completa.interpretacionDeMouth.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeMouth.cornerAngle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeMouth.curves = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeMouth.heart = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeMouth.edgeDefine = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.topPeak = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.upperCurves = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.upperLipMiddleThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipWidth = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeMouth.lowerDepth = Interpretacion.Depth.veryDeep;
				completa.interpretacionDeMouth.grooveDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeMouth.grooveAngle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeMouth.grooveTone = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.grooveWidth = Interpretacion.CantidadNoContable.little;
				break;
			case Interpretacion.FaceTypeV2.latina:
				completa.interpretacionDeRaza.african = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.nordic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.asian = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.hispanic = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeRaza.elf = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRostro.collapse = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.aging = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.thickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeRostro.square = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.heart = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.round = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.foreHeadWidth = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeRostro.foreHeadProjection = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeEyebrows.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyebrows.distance = Interpretacion.Distance.close;
				completa.interpretacionDeEyebrows.thickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeEyebrows.length = Interpretacion.Length.@short;
				completa.interpretacionDeEyebrows.ridgeSize = Interpretacion.Size.large;
				completa.interpretacionDeEyebrows.angle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeEyes.size = Interpretacion.Size.large;
				completa.interpretacionDeEyes.height = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyes.depth = Interpretacion.Depth.shallow;
				completa.interpretacionDeEyes.amplitude = Interpretacion.Amplitude.normal;
				completa.interpretacionDeEyes.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.irisSize = Interpretacion.Size.verySmall;
				completa.interpretacionDeEyes.eyelidHeavy = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeEyes.eyelidDistance = Interpretacion.Distance.close;
				completa.interpretacionDeEyes.eyelidDepth = Interpretacion.Depth.shallow;
				completa.interpretacionDeEyes.upperEyelidSmooth = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.upperEyelidHeight = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopFlat = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.eyelidTopInHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.lowerEyelidHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelidBottomDefine = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.eyelidBottomOutHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.wrinkleInner = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelashesLength = Interpretacion.Length.normal;
				completa.interpretacionDeEyes.lacrimalDistance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyes.lacrimalExposure = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.cheekBonesSize = Interpretacion.Size.large;
				completa.interpretacionDeCheeks.cheekBonesHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.fat = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeCheeks.sink = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeNose.size = Interpretacion.Size.normal;
				completa.interpretacionDeNose.height = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.proyection = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.pinch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.chisel = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeNose.bridgeHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeNose.bridgeSmoothness = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.ridgeBump = Interpretacion.Size.small;
				completa.interpretacionDeNose.ridgeSlope = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeNose.tipRoundness = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeNose.tipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeNose.tipDepth = Interpretacion.Depth.deep;
				completa.interpretacionDeNose.tipHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.tipSlope = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.nostrilThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.nostrilDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeNose.nostrilAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeNose.nostrilSize = Interpretacion.Size.large;
				completa.interpretacionDeNose.nostrilCollapse = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.nostrilHeight = Interpretacion.Height.normal;
				completa.interpretacionDeNose.septumWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.septumHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.philtrumConcave = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.normal;
				completa.interpretacionDeMouth.angle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.cornerAngle = Interpretacion.AngleDirection.upwards;
				completa.interpretacionDeMouth.curves = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.heart = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.edgeDefine = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.topPeak = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.upperCurves = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.upperLipMiddleThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipWidth = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeMouth.lowerDepth = Interpretacion.Depth.veryDeep;
				completa.interpretacionDeMouth.grooveDepth = Interpretacion.Depth.shallow;
				completa.interpretacionDeMouth.grooveAngle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeMouth.grooveTone = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.grooveWidth = Interpretacion.CantidadNoContable.some;
				break;
			case Interpretacion.FaceTypeV2.toon:
				completa.interpretacionDeRaza.african = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.nordic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.asian = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.hispanic = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeRaza.elf = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeRostro.collapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.aging = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.thickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeRostro.square = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.heart = Interpretacion.Capacidad.high;
				completa.interpretacionDeRostro.round = Interpretacion.Capacidad.medium;
				completa.interpretacionDeRostro.foreHeadWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeRostro.foreHeadProjection = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeEyebrows.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyebrows.distance = Interpretacion.Distance.normal;
				completa.interpretacionDeEyebrows.thickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeEyebrows.length = Interpretacion.Length.veryLong;
				completa.interpretacionDeEyebrows.ridgeSize = Interpretacion.Size.normal;
				completa.interpretacionDeEyebrows.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeEyes.height = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.distance = Interpretacion.Distance.veryDistant;
				completa.interpretacionDeEyes.depth = Interpretacion.Depth.veryDeep;
				completa.interpretacionDeEyes.amplitude = Interpretacion.Amplitude.normal;
				completa.interpretacionDeEyes.angle = Interpretacion.AngleDirection.downwards;
				completa.interpretacionDeEyes.irisSize = Interpretacion.Size.normal;
				completa.interpretacionDeEyes.eyelidHeavy = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeEyes.eyelidDistance = Interpretacion.Distance.distant;
				completa.interpretacionDeEyes.eyelidDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeEyes.upperEyelidSmooth = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.upperEyelidHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.eyelidTopFlat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidTopInHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.lowerEyelidHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeEyes.eyelidBottomDefine = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeEyes.eyelidBottomOutHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeEyes.wrinkleInner = Interpretacion.Capacidad.medium;
				completa.interpretacionDeEyes.eyelashesLength = Interpretacion.Length.normal;
				completa.interpretacionDeEyes.lacrimalDistance = Interpretacion.Distance.close;
				completa.interpretacionDeEyes.lacrimalExposure = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.cheekBonesSize = Interpretacion.Size.normal;
				completa.interpretacionDeCheeks.cheekBonesHeight = Interpretacion.Capacidad.low;
				completa.interpretacionDeCheeks.fat = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeCheeks.sink = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeNose.size = Interpretacion.Size.small;
				completa.interpretacionDeNose.height = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.proyection = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.pinch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.chisel = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.bridgeThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeNose.bridgeHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.bridgeDepth = Interpretacion.Depth.deep;
				completa.interpretacionDeNose.bridgeSmoothness = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.ridgeBump = Interpretacion.Size.normal;
				completa.interpretacionDeNose.ridgeSlope = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.tipRoundness = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeNose.tipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.tipDepth = Interpretacion.Depth.normal;
				completa.interpretacionDeNose.tipHeight = Interpretacion.Capacidad.high;
				completa.interpretacionDeNose.tipSlope = Interpretacion.Capacidad.low;
				completa.interpretacionDeNose.nostrilThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeNose.nostrilDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeNose.nostrilAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeNose.nostrilSize = Interpretacion.Size.normal;
				completa.interpretacionDeNose.nostrilCollapse = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.nostrilHeight = Interpretacion.Height.normal;
				completa.interpretacionDeNose.septumWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeNose.septumHeight = Interpretacion.Capacidad.medium;
				completa.interpretacionDeNose.philtrumConcave = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.thin;
				completa.interpretacionDeMouth.angle = Interpretacion.AngleDirection.veryDownwards;
				completa.interpretacionDeMouth.cornerAngle = Interpretacion.AngleDirection.veryUpwards;
				completa.interpretacionDeMouth.curves = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.heart = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeMouth.edgeDefine = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.topPeak = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.upperCurves = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.upperLipMiddleThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipWidth = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeMouth.lowerDepth = Interpretacion.Depth.veryDeep;
				completa.interpretacionDeMouth.grooveDepth = Interpretacion.Depth.veryShallow;
				completa.interpretacionDeMouth.grooveAngle = Interpretacion.AngleDirection.medium;
				completa.interpretacionDeMouth.grooveTone = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.grooveWidth = Interpretacion.CantidadNoContable.some;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.faceTypeV2.ToString());
			}
			switch (this.makeUpAmount)
			{
			case Interpretacion.CantidadNoContable.veryLittle:
				completa.interpretacionDeFacialSkin.makeUpMaxAmount = this.makeUpAmount;
				completa.interpretacionDeFacialSkin.makeUpOnCheeks = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeFacialSkin.makeUpEyeshadow = Interpretacion.Capacidad.veryLow;
				break;
			case Interpretacion.CantidadNoContable.little:
				completa.interpretacionDeFacialSkin.makeUpMaxAmount = this.makeUpAmount;
				completa.interpretacionDeFacialSkin.makeUpOnCheeks = Interpretacion.Capacidad.low;
				completa.interpretacionDeFacialSkin.makeUpEyeshadow = Interpretacion.Capacidad.low;
				break;
			case Interpretacion.CantidadNoContable.some:
				completa.interpretacionDeFacialSkin.makeUpMaxAmount = this.makeUpAmount;
				completa.interpretacionDeFacialSkin.makeUpOnCheeks = Interpretacion.Capacidad.medium;
				completa.interpretacionDeFacialSkin.makeUpEyeshadow = Interpretacion.Capacidad.medium;
				break;
			case Interpretacion.CantidadNoContable.aLot:
				completa.interpretacionDeFacialSkin.makeUpMaxAmount = this.makeUpAmount;
				completa.interpretacionDeFacialSkin.makeUpOnCheeks = Interpretacion.Capacidad.high;
				completa.interpretacionDeFacialSkin.makeUpEyeshadow = Interpretacion.Capacidad.high;
				break;
			case Interpretacion.CantidadNoContable.tooMuch:
				completa.interpretacionDeFacialSkin.makeUpMaxAmount = this.makeUpAmount;
				completa.interpretacionDeFacialSkin.makeUpOnCheeks = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeFacialSkin.makeUpEyeshadow = Interpretacion.Capacidad.veryHigh;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.makeUpAmount.ToString());
			}
			completa.interpretacionDeEyes.irisColor = this.eyeColor;
			switch (this.difficulty)
			{
			case Interpretacion.Capacidad.veryLow:
				completa.interpretacionDeGustos.deseoByVisual = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseoByVerbal = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseoByTouch = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseoByExposure = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseoByCoital = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseoGainIndirecto = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.corruptionByDesires = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.deseosResiliance = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorPervertidos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorTimidos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorAutistas = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorHumildad = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorGordos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorViejos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorDelgados = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorConfiados = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorPatanes = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorIntelectuales = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorDinero = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorMusculosos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.gustoPorJovenes = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.patience = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.estandaresAltos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.honest = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.exhibitionist = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.optimistic = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.submissive = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.passive = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.masochist = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeSenos.difficulty.painSensitivity = (completa.interpretacionDeFacialSkin.difficulty.painSensitivity = (completa.interpretacionDeBodySkin.difficulty.painSensitivity = (completa.interpretacionDeAss.difficulty.painSensitivity = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.pleasureSensitivity = (completa.interpretacionDeFacialSkin.difficulty.pleasureSensitivity = (completa.interpretacionDeBodySkin.difficulty.pleasureSensitivity = (completa.interpretacionDeAss.difficulty.pleasureSensitivity = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.painGain = (completa.interpretacionDeFacialSkin.difficulty.painGain = (completa.interpretacionDeBodySkin.difficulty.painGain = (completa.interpretacionDeAss.difficulty.painGain = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.pleasureGain = (completa.interpretacionDeFacialSkin.difficulty.pleasureGain = (completa.interpretacionDeBodySkin.difficulty.pleasureGain = (completa.interpretacionDeAss.difficulty.pleasureGain = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.anoyanceGain = (completa.interpretacionDeFacialSkin.difficulty.anoyanceGain = (completa.interpretacionDeBodySkin.difficulty.anoyanceGain = (completa.interpretacionDeAss.difficulty.anoyanceGain = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.maxPleasure = (completa.interpretacionDeAss.difficulty.maxPleasure = Interpretacion.Capacidad.veryHigh);
				completa.interpretacionDeFacialSkin.difficulty.maxPleasure = (completa.interpretacionDeBodySkin.difficulty.maxPleasure = Interpretacion.Capacidad.high);
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAss.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAss.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAss.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeMouth.difficulty.painSensitivity = (completa.interpretacionDeVag.difficulty.painSensitivity = (completa.interpretacionDeAnus.difficulty.painSensitivity = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.pleasureSensitivity = (completa.interpretacionDeVag.difficulty.pleasureSensitivity = (completa.interpretacionDeAnus.difficulty.pleasureSensitivity = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.painGain = (completa.interpretacionDeVag.difficulty.painGain = (completa.interpretacionDeAnus.difficulty.painGain = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.pleasureGain = (completa.interpretacionDeVag.difficulty.pleasureGain = (completa.interpretacionDeAnus.difficulty.pleasureGain = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.anoyanceGain = (completa.interpretacionDeVag.difficulty.anoyanceGain = (completa.interpretacionDeAnus.difficulty.anoyanceGain = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.maxPleasure = (completa.interpretacionDeVag.difficulty.maxPleasure = (completa.interpretacionDeAnus.difficulty.maxPleasure = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeVag.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeVag.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeVag.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeVag.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementCoital = Interpretacion.Capacidad.veryLow));
				break;
			case Interpretacion.Capacidad.low:
				completa.interpretacionDeGustos.deseoByVisual = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseoByVerbal = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseoByTouch = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseoByExposure = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseoByCoital = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseoGainIndirecto = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.corruptionByDesires = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.deseosResiliance = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorPervertidos = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorTimidos = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorAutistas = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorHumildad = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorGordos = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorViejos = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorDelgados = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorConfiados = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorPatanes = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorIntelectuales = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorDinero = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorMusculosos = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.gustoPorJovenes = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.patience = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.estandaresAltos = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.honest = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.exhibitionist = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.optimistic = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.submissive = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.passive = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.masochist = Interpretacion.Capacidad.high;
				completa.interpretacionDeSenos.difficulty.painSensitivity = (completa.interpretacionDeFacialSkin.difficulty.painSensitivity = (completa.interpretacionDeBodySkin.difficulty.painSensitivity = (completa.interpretacionDeAss.difficulty.painSensitivity = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.pleasureSensitivity = (completa.interpretacionDeFacialSkin.difficulty.pleasureSensitivity = (completa.interpretacionDeBodySkin.difficulty.pleasureSensitivity = (completa.interpretacionDeAss.difficulty.pleasureSensitivity = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.painGain = (completa.interpretacionDeFacialSkin.difficulty.painGain = (completa.interpretacionDeBodySkin.difficulty.painGain = (completa.interpretacionDeAss.difficulty.painGain = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.pleasureGain = (completa.interpretacionDeFacialSkin.difficulty.pleasureGain = (completa.interpretacionDeBodySkin.difficulty.pleasureGain = (completa.interpretacionDeAss.difficulty.pleasureGain = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.anoyanceGain = (completa.interpretacionDeFacialSkin.difficulty.anoyanceGain = (completa.interpretacionDeBodySkin.difficulty.anoyanceGain = (completa.interpretacionDeAss.difficulty.anoyanceGain = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.maxPleasure = (completa.interpretacionDeAss.difficulty.maxPleasure = Interpretacion.Capacidad.high);
				completa.interpretacionDeFacialSkin.difficulty.maxPleasure = (completa.interpretacionDeBodySkin.difficulty.maxPleasure = Interpretacion.Capacidad.high);
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAss.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAss.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAss.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.low)));
				completa.interpretacionDeMouth.difficulty.painSensitivity = (completa.interpretacionDeVag.difficulty.painSensitivity = (completa.interpretacionDeAnus.difficulty.painSensitivity = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.pleasureSensitivity = (completa.interpretacionDeVag.difficulty.pleasureSensitivity = (completa.interpretacionDeAnus.difficulty.pleasureSensitivity = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.painGain = (completa.interpretacionDeVag.difficulty.painGain = (completa.interpretacionDeAnus.difficulty.painGain = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.pleasureGain = (completa.interpretacionDeVag.difficulty.pleasureGain = (completa.interpretacionDeAnus.difficulty.pleasureGain = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.anoyanceGain = (completa.interpretacionDeVag.difficulty.anoyanceGain = (completa.interpretacionDeAnus.difficulty.anoyanceGain = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.maxPleasure = (completa.interpretacionDeVag.difficulty.maxPleasure = (completa.interpretacionDeAnus.difficulty.maxPleasure = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeVag.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeVag.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeVag.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeVag.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementCoital = Interpretacion.Capacidad.low));
				break;
			case Interpretacion.Capacidad.medium:
				completa.interpretacionDeGustos.deseoByVisual = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseoByVerbal = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseoByTouch = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseoByExposure = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseoByCoital = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseoGainIndirecto = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.corruptionByDesires = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.deseosResiliance = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorPervertidos = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorTimidos = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorAutistas = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorHumildad = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorGordos = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorViejos = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorDelgados = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorConfiados = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorPatanes = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorIntelectuales = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorDinero = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorMusculosos = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.gustoPorJovenes = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.patience = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.estandaresAltos = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.honest = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.exhibitionist = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.optimistic = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.submissive = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.passive = Interpretacion.Capacidad.medium;
				completa.interpretacionDePersonalidad.traits.masochist = Interpretacion.Capacidad.medium;
				completa.interpretacionDeSenos.difficulty.painSensitivity = (completa.interpretacionDeFacialSkin.difficulty.painSensitivity = (completa.interpretacionDeBodySkin.difficulty.painSensitivity = (completa.interpretacionDeAss.difficulty.painSensitivity = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.pleasureSensitivity = (completa.interpretacionDeFacialSkin.difficulty.pleasureSensitivity = (completa.interpretacionDeBodySkin.difficulty.pleasureSensitivity = (completa.interpretacionDeAss.difficulty.pleasureSensitivity = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.painGain = (completa.interpretacionDeFacialSkin.difficulty.painGain = (completa.interpretacionDeBodySkin.difficulty.painGain = (completa.interpretacionDeAss.difficulty.painGain = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.pleasureGain = (completa.interpretacionDeFacialSkin.difficulty.pleasureGain = (completa.interpretacionDeBodySkin.difficulty.pleasureGain = (completa.interpretacionDeAss.difficulty.pleasureGain = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.anoyanceGain = (completa.interpretacionDeFacialSkin.difficulty.anoyanceGain = (completa.interpretacionDeBodySkin.difficulty.anoyanceGain = (completa.interpretacionDeAss.difficulty.anoyanceGain = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.maxPleasure = (completa.interpretacionDeAss.difficulty.maxPleasure = Interpretacion.Capacidad.medium);
				completa.interpretacionDeFacialSkin.difficulty.maxPleasure = (completa.interpretacionDeBodySkin.difficulty.maxPleasure = Interpretacion.Capacidad.medium);
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAss.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAss.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAss.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.medium)));
				completa.interpretacionDeMouth.difficulty.painSensitivity = (completa.interpretacionDeVag.difficulty.painSensitivity = (completa.interpretacionDeAnus.difficulty.painSensitivity = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.pleasureSensitivity = (completa.interpretacionDeVag.difficulty.pleasureSensitivity = (completa.interpretacionDeAnus.difficulty.pleasureSensitivity = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.painGain = (completa.interpretacionDeVag.difficulty.painGain = (completa.interpretacionDeAnus.difficulty.painGain = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.pleasureGain = (completa.interpretacionDeVag.difficulty.pleasureGain = (completa.interpretacionDeAnus.difficulty.pleasureGain = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.anoyanceGain = (completa.interpretacionDeVag.difficulty.anoyanceGain = (completa.interpretacionDeAnus.difficulty.anoyanceGain = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.maxPleasure = (completa.interpretacionDeVag.difficulty.maxPleasure = (completa.interpretacionDeAnus.difficulty.maxPleasure = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeVag.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeVag.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeVag.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeVag.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementCoital = Interpretacion.Capacidad.medium));
				break;
			case Interpretacion.Capacidad.high:
				completa.interpretacionDeGustos.deseoByVisual = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseoByVerbal = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseoByTouch = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseoByExposure = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseoByCoital = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseoGainIndirecto = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.corruptionByDesires = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.deseosResiliance = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorPervertidos = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorTimidos = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorAutistas = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorHumildad = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorGordos = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorViejos = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorDelgados = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorConfiados = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorPatanes = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorIntelectuales = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorDinero = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorMusculosos = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.gustoPorJovenes = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.patience = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.estandaresAltos = Interpretacion.Capacidad.high;
				completa.interpretacionDePersonalidad.traits.honest = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.exhibitionist = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.optimistic = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.submissive = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.passive = Interpretacion.Capacidad.low;
				completa.interpretacionDePersonalidad.traits.masochist = Interpretacion.Capacidad.low;
				completa.interpretacionDeSenos.difficulty.painSensitivity = (completa.interpretacionDeFacialSkin.difficulty.painSensitivity = (completa.interpretacionDeBodySkin.difficulty.painSensitivity = (completa.interpretacionDeAss.difficulty.painSensitivity = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.pleasureSensitivity = (completa.interpretacionDeFacialSkin.difficulty.pleasureSensitivity = (completa.interpretacionDeBodySkin.difficulty.pleasureSensitivity = (completa.interpretacionDeAss.difficulty.pleasureSensitivity = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.painGain = (completa.interpretacionDeFacialSkin.difficulty.painGain = (completa.interpretacionDeBodySkin.difficulty.painGain = (completa.interpretacionDeAss.difficulty.painGain = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.pleasureGain = (completa.interpretacionDeFacialSkin.difficulty.pleasureGain = (completa.interpretacionDeBodySkin.difficulty.pleasureGain = (completa.interpretacionDeAss.difficulty.pleasureGain = Interpretacion.Capacidad.low)));
				completa.interpretacionDeSenos.difficulty.anoyanceGain = (completa.interpretacionDeFacialSkin.difficulty.anoyanceGain = (completa.interpretacionDeBodySkin.difficulty.anoyanceGain = (completa.interpretacionDeAss.difficulty.anoyanceGain = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.maxPleasure = (completa.interpretacionDeAss.difficulty.maxPleasure = Interpretacion.Capacidad.medium);
				completa.interpretacionDeFacialSkin.difficulty.maxPleasure = (completa.interpretacionDeBodySkin.difficulty.maxPleasure = Interpretacion.Capacidad.low);
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAss.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAss.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.high)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAss.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.high)));
				completa.interpretacionDeMouth.difficulty.painSensitivity = (completa.interpretacionDeVag.difficulty.painSensitivity = (completa.interpretacionDeAnus.difficulty.painSensitivity = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.pleasureSensitivity = (completa.interpretacionDeVag.difficulty.pleasureSensitivity = (completa.interpretacionDeAnus.difficulty.pleasureSensitivity = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.painGain = (completa.interpretacionDeVag.difficulty.painGain = (completa.interpretacionDeAnus.difficulty.painGain = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.pleasureGain = (completa.interpretacionDeVag.difficulty.pleasureGain = (completa.interpretacionDeAnus.difficulty.pleasureGain = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.anoyanceGain = (completa.interpretacionDeVag.difficulty.anoyanceGain = (completa.interpretacionDeAnus.difficulty.anoyanceGain = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.maxPleasure = (completa.interpretacionDeVag.difficulty.maxPleasure = (completa.interpretacionDeAnus.difficulty.maxPleasure = Interpretacion.Capacidad.medium));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeVag.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeVag.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeVag.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.high));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeVag.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementCoital = Interpretacion.Capacidad.high));
				break;
			case Interpretacion.Capacidad.veryHigh:
				completa.interpretacionDeGustos.deseoByVisual = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseoByVerbal = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseoByTouch = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseoByExposure = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseoByCoital = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseoGainIndirecto = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.corruptionByDesires = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.deseosResiliance = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorPervertidos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorTimidos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorAutistas = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorHumildad = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorGordos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorViejos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorDelgados = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorConfiados = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorPatanes = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorIntelectuales = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorDinero = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorMusculosos = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.gustoPorJovenes = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.patience = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.estandaresAltos = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDePersonalidad.traits.honest = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.exhibitionist = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.optimistic = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.submissive = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.passive = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDePersonalidad.traits.masochist = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeSenos.difficulty.painSensitivity = (completa.interpretacionDeFacialSkin.difficulty.painSensitivity = (completa.interpretacionDeBodySkin.difficulty.painSensitivity = (completa.interpretacionDeAss.difficulty.painSensitivity = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.pleasureSensitivity = (completa.interpretacionDeFacialSkin.difficulty.pleasureSensitivity = (completa.interpretacionDeBodySkin.difficulty.pleasureSensitivity = (completa.interpretacionDeAss.difficulty.pleasureSensitivity = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.painGain = (completa.interpretacionDeFacialSkin.difficulty.painGain = (completa.interpretacionDeBodySkin.difficulty.painGain = (completa.interpretacionDeAss.difficulty.painGain = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.pleasureGain = (completa.interpretacionDeFacialSkin.difficulty.pleasureGain = (completa.interpretacionDeBodySkin.difficulty.pleasureGain = (completa.interpretacionDeAss.difficulty.pleasureGain = Interpretacion.Capacidad.veryLow)));
				completa.interpretacionDeSenos.difficulty.anoyanceGain = (completa.interpretacionDeFacialSkin.difficulty.anoyanceGain = (completa.interpretacionDeBodySkin.difficulty.anoyanceGain = (completa.interpretacionDeAss.difficulty.anoyanceGain = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.maxPleasure = (completa.interpretacionDeAss.difficulty.maxPleasure = Interpretacion.Capacidad.low);
				completa.interpretacionDeFacialSkin.difficulty.maxPleasure = (completa.interpretacionDeBodySkin.difficulty.maxPleasure = Interpretacion.Capacidad.veryLow);
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAss.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAss.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeSenos.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeFacialSkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeBodySkin.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAss.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.veryHigh)));
				completa.interpretacionDeMouth.difficulty.painSensitivity = (completa.interpretacionDeVag.difficulty.painSensitivity = (completa.interpretacionDeAnus.difficulty.painSensitivity = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.pleasureSensitivity = (completa.interpretacionDeVag.difficulty.pleasureSensitivity = (completa.interpretacionDeAnus.difficulty.pleasureSensitivity = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.painGain = (completa.interpretacionDeVag.difficulty.painGain = (completa.interpretacionDeAnus.difficulty.painGain = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.pleasureGain = (completa.interpretacionDeVag.difficulty.pleasureGain = (completa.interpretacionDeAnus.difficulty.pleasureGain = Interpretacion.Capacidad.veryLow));
				completa.interpretacionDeMouth.difficulty.anoyanceGain = (completa.interpretacionDeVag.difficulty.anoyanceGain = (completa.interpretacionDeAnus.difficulty.anoyanceGain = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.maxPleasure = (completa.interpretacionDeVag.difficulty.maxPleasure = (completa.interpretacionDeAnus.difficulty.maxPleasure = Interpretacion.Capacidad.low));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeVag.difficulty.favorabilityRequirementVisual = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementVisual = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeVag.difficulty.favorabilityRequirementTactile = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementTactile = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeVag.difficulty.favorabilityRequirementExposure = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementExposure = Interpretacion.Capacidad.veryHigh));
				completa.interpretacionDeMouth.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeVag.difficulty.favorabilityRequirementCoital = (completa.interpretacionDeAnus.difficulty.favorabilityRequirementCoital = Interpretacion.Capacidad.veryHigh));
				break;
			default:
				throw new ArgumentOutOfRangeException(this.difficulty.ToString());
			}
			Interpretacion.PersonalidadType personalidadType = this.personalityType;
			switch (personalidadType)
			{
			case Interpretacion.PersonalidadType.respectful:
				completa.interpretacionDePersonalidad.traits.respectful = Interpretacion.Capacidad.veryHigh;
				break;
			case Interpretacion.PersonalidadType.perverted:
				completa.interpretacionDePersonalidad.traits.perverted = Interpretacion.Capacidad.veryHigh;
				break;
			case Interpretacion.PersonalidadType.shy:
				completa.interpretacionDePersonalidad.traits.shy = Interpretacion.Capacidad.veryHigh;
				break;
			case Interpretacion.PersonalidadType.rude:
				completa.interpretacionDePersonalidad.traits.rude = Interpretacion.Capacidad.veryHigh;
				break;
			case Interpretacion.PersonalidadType.extroverted:
				completa.interpretacionDePersonalidad.traits.extroverted = Interpretacion.Capacidad.veryHigh;
				break;
			default:
				if (personalidadType != Interpretacion.PersonalidadType.none)
				{
					throw new ArgumentOutOfRangeException(this.personalityType.ToString());
				}
				break;
			}
			switch (this.vagExperience)
			{
			case Interpretacion.Capacidad.veryLow:
				completa.interpretacionDeGustos.crotchInitial = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeGustos.crotchGain = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.dispuestaARiding = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeVag.anchura = Interpretacion.Tightness.veryTight;
				completa.interpretacionDeVag.profundidad = Interpretacion.HoleDepth.veryNarrow;
				completa.interpretacionDeVag.lipsOpening = Interpretacion.Opening.veryClosed;
				completa.interpretacionDeVag.outerLabiaThickness = Interpretacion.Thickness.veryNarrow;
				completa.interpretacionDeVag.outerLabiaFat = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeVag.clitLength = Interpretacion.Length.veryShort;
				completa.interpretacionDeVag.clitExtrude = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeVag.innerLabiaThickness = Interpretacion.Thickness.veryNarrow;
				break;
			case Interpretacion.Capacidad.low:
				completa.interpretacionDeGustos.crotchInitial = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeGustos.crotchGain = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.dispuestaARiding = Interpretacion.Capacidad.low;
				completa.interpretacionDeVag.anchura = Interpretacion.Tightness.tight;
				completa.interpretacionDeVag.profundidad = Interpretacion.HoleDepth.narrow;
				completa.interpretacionDeVag.lipsOpening = Interpretacion.Opening.closed;
				completa.interpretacionDeVag.outerLabiaThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeVag.outerLabiaFat = Interpretacion.Capacidad.low;
				completa.interpretacionDeVag.clitLength = Interpretacion.Length.@short;
				completa.interpretacionDeVag.clitExtrude = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeVag.innerLabiaThickness = Interpretacion.Thickness.narrow;
				break;
			case Interpretacion.Capacidad.medium:
				completa.interpretacionDeGustos.crotchInitial = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeGustos.crotchGain = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.dispuestaARiding = Interpretacion.Capacidad.medium;
				completa.interpretacionDeVag.anchura = Interpretacion.Tightness.normal;
				completa.interpretacionDeVag.profundidad = Interpretacion.HoleDepth.normal;
				completa.interpretacionDeVag.lipsOpening = Interpretacion.Opening.normal;
				completa.interpretacionDeVag.outerLabiaThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeVag.outerLabiaFat = Interpretacion.Capacidad.medium;
				completa.interpretacionDeVag.clitLength = Interpretacion.Length.normal;
				completa.interpretacionDeVag.clitExtrude = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeVag.innerLabiaThickness = Interpretacion.Thickness.normal;
				break;
			case Interpretacion.Capacidad.high:
				completa.interpretacionDeGustos.crotchInitial = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeGustos.crotchGain = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.dispuestaARiding = Interpretacion.Capacidad.high;
				completa.interpretacionDeVag.anchura = Interpretacion.Tightness.loose;
				completa.interpretacionDeVag.profundidad = Interpretacion.HoleDepth.deep;
				completa.interpretacionDeVag.lipsOpening = Interpretacion.Opening.open;
				completa.interpretacionDeVag.outerLabiaThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeVag.outerLabiaFat = Interpretacion.Capacidad.high;
				completa.interpretacionDeVag.clitLength = Interpretacion.Length.@long;
				completa.interpretacionDeVag.clitExtrude = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeVag.innerLabiaThickness = Interpretacion.Thickness.thick;
				break;
			case Interpretacion.Capacidad.veryHigh:
				completa.interpretacionDeGustos.crotchInitial = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeGustos.crotchGain = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.dispuestaARiding = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeVag.anchura = Interpretacion.Tightness.veryLoose;
				completa.interpretacionDeVag.profundidad = Interpretacion.HoleDepth.veryDeep;
				completa.interpretacionDeVag.lipsOpening = Interpretacion.Opening.veryOpen;
				completa.interpretacionDeVag.outerLabiaThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeVag.outerLabiaFat = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeVag.clitLength = Interpretacion.Length.veryLong;
				completa.interpretacionDeVag.clitExtrude = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeVag.innerLabiaThickness = Interpretacion.Thickness.veryThick;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.vagExperience.ToString());
			}
			switch (this.anusExperience)
			{
			case Interpretacion.Capacidad.veryLow:
				completa.interpretacionDeGustos.assInitial = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeGustos.assGain = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.dispuestaARidingAnal = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeAnus.size = Interpretacion.Size.verySmall;
				completa.interpretacionDeAnus.opening = Interpretacion.Opening.veryClosed;
				completa.interpretacionDeAnus.profundidad = Interpretacion.HoleDepth.veryNarrow;
				completa.interpretacionDeAnus.anchura = Interpretacion.Tightness.veryTight;
				break;
			case Interpretacion.Capacidad.low:
				completa.interpretacionDeGustos.assInitial = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeGustos.assGain = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.dispuestaARidingAnal = Interpretacion.Capacidad.low;
				completa.interpretacionDeAnus.size = Interpretacion.Size.small;
				completa.interpretacionDeAnus.opening = Interpretacion.Opening.closed;
				completa.interpretacionDeAnus.profundidad = Interpretacion.HoleDepth.narrow;
				completa.interpretacionDeAnus.anchura = Interpretacion.Tightness.tight;
				break;
			case Interpretacion.Capacidad.medium:
				completa.interpretacionDeGustos.assInitial = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeGustos.assGain = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.dispuestaARidingAnal = Interpretacion.Capacidad.medium;
				completa.interpretacionDeAnus.size = Interpretacion.Size.normal;
				completa.interpretacionDeAnus.opening = Interpretacion.Opening.normal;
				completa.interpretacionDeAnus.profundidad = Interpretacion.HoleDepth.normal;
				completa.interpretacionDeAnus.anchura = Interpretacion.Tightness.normal;
				break;
			case Interpretacion.Capacidad.high:
				completa.interpretacionDeGustos.assInitial = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeGustos.assGain = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.dispuestaARidingAnal = Interpretacion.Capacidad.high;
				completa.interpretacionDeAnus.size = Interpretacion.Size.large;
				completa.interpretacionDeAnus.opening = Interpretacion.Opening.open;
				completa.interpretacionDeAnus.profundidad = Interpretacion.HoleDepth.deep;
				completa.interpretacionDeAnus.anchura = Interpretacion.Tightness.loose;
				break;
			case Interpretacion.Capacidad.veryHigh:
				completa.interpretacionDeGustos.assInitial = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeGustos.assGain = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.dispuestaARidingAnal = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeAnus.size = Interpretacion.Size.veryLarge;
				completa.interpretacionDeAnus.opening = Interpretacion.Opening.veryOpen;
				completa.interpretacionDeAnus.profundidad = Interpretacion.HoleDepth.veryDeep;
				completa.interpretacionDeAnus.anchura = Interpretacion.Tightness.veryLoose;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.anusExperience.ToString());
			}
			switch (this.mouthExperience)
			{
			case Interpretacion.Capacidad.veryLow:
				completa.interpretacionDeGustos.facialInitial = Interpretacion.CantidadNoContable.veryLittle;
				completa.interpretacionDeGustos.facialGain = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeGustos.dispuestaAChupar = Interpretacion.Capacidad.veryLow;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.thin;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.narrow;
				completa.interpretacionDeMouth.profundidad = Interpretacion.HoleDepth.veryNarrow;
				completa.interpretacionDeMouth.anchura = Interpretacion.Tightness.veryTight;
				return;
			case Interpretacion.Capacidad.low:
				completa.interpretacionDeGustos.facialInitial = Interpretacion.CantidadNoContable.little;
				completa.interpretacionDeGustos.facialGain = Interpretacion.Capacidad.low;
				completa.interpretacionDeGustos.dispuestaAChupar = Interpretacion.Capacidad.low;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.normal;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.profundidad = Interpretacion.HoleDepth.narrow;
				completa.interpretacionDeMouth.anchura = Interpretacion.Tightness.tight;
				return;
			case Interpretacion.Capacidad.medium:
				completa.interpretacionDeGustos.facialInitial = Interpretacion.CantidadNoContable.some;
				completa.interpretacionDeGustos.facialGain = Interpretacion.Capacidad.medium;
				completa.interpretacionDeGustos.dispuestaAChupar = Interpretacion.Capacidad.medium;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.normal;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.normal;
				completa.interpretacionDeMouth.profundidad = Interpretacion.HoleDepth.normal;
				completa.interpretacionDeMouth.anchura = Interpretacion.Tightness.normal;
				return;
			case Interpretacion.Capacidad.high:
				completa.interpretacionDeGustos.facialInitial = Interpretacion.CantidadNoContable.aLot;
				completa.interpretacionDeGustos.facialGain = Interpretacion.Capacidad.high;
				completa.interpretacionDeGustos.dispuestaAChupar = Interpretacion.Capacidad.high;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.wide;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.thick;
				completa.interpretacionDeMouth.profundidad = Interpretacion.HoleDepth.deep;
				completa.interpretacionDeMouth.anchura = Interpretacion.Tightness.loose;
				return;
			case Interpretacion.Capacidad.veryHigh:
				completa.interpretacionDeGustos.facialInitial = Interpretacion.CantidadNoContable.tooMuch;
				completa.interpretacionDeGustos.facialGain = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeGustos.dispuestaAChupar = Interpretacion.Capacidad.veryHigh;
				completa.interpretacionDeMouth.width = Interpretacion.Amplitude.veryWide;
				completa.interpretacionDeMouth.upperLipThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeMouth.lowerLipThickness = Interpretacion.Thickness.veryThick;
				completa.interpretacionDeMouth.profundidad = Interpretacion.HoleDepth.veryDeep;
				completa.interpretacionDeMouth.anchura = Interpretacion.Tightness.veryLoose;
				return;
			default:
				throw new ArgumentOutOfRangeException(this.mouthExperience.ToString());
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000D31C File Offset: 0x0000B51C
		public static InterpretacionCompletaDeFemale defaultCompleta
		{
			get
			{
				InterpretacionSimple @default = InterpretacionSimple.@default;
				InterpretacionCompletaDeFemale interpretacionCompletaDeFemale = default(InterpretacionCompletaDeFemale);
				@default.ConvertirA(ref interpretacionCompletaDeFemale);
				return interpretacionCompletaDeFemale;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000D344 File Offset: 0x0000B544
		public static InterpretacionSimple @default
		{
			get
			{
				return new InterpretacionSimple
				{
					difficulty = Interpretacion.Capacidad.medium,
					personalityType = Interpretacion.PersonalidadType.none,
					height = Interpretacion.Height.normal,
					bodyType = Interpretacion.BodyType.normal,
					skinTone = Interpretacion.SkinTone.pale,
					nippleColor = new FreeColor
					{
						hue = Hue.rojo,
						saturation = Interpretacion.Capacidad.high,
						brightness = Interpretacion.Capacidad.high
					},
					hairLength = Interpretacion.Length.veryLong,
					hairCurls = Interpretacion.Capacidad.veryLow,
					hairColor = new FreeColor
					{
						hue = Hue.naranja,
						saturation = Interpretacion.Capacidad.veryHigh,
						brightness = Interpretacion.Capacidad.veryLow
					},
					faceTypeV2 = Interpretacion.FaceTypeV2.caucasian,
					makeUpAmount = Interpretacion.CantidadNoContable.some,
					eyeColor = new FreeColor
					{
						hue = Hue.naranja,
						saturation = Interpretacion.Capacidad.medium,
						brightness = Interpretacion.Capacidad.low
					},
					vagExperience = Interpretacion.Capacidad.low,
					anusExperience = Interpretacion.Capacidad.veryLow,
					mouthExperience = Interpretacion.Capacidad.medium
				};
			}
		}

		// Token: 0x04000147 RID: 327
		[DescripcionLocalizado("Many individuals believe that models at a medium difficulty level is already extremely difficult.")]
		[LabelLocalizado("Difficulty", "US")]
		public Interpretacion.Capacidad difficulty;

		// Token: 0x04000148 RID: 328
		[LabelLocalizado("Personality Type", "US")]
		public Interpretacion.PersonalidadType personalityType;

		// Token: 0x04000149 RID: 329
		[LabelLocalizado("Height", "US")]
		public Interpretacion.Height height;

		// Token: 0x0400014A RID: 330
		[LabelLocalizado("Body Type", "US")]
		public Interpretacion.BodyType bodyType;

		// Token: 0x0400014B RID: 331
		[LabelLocalizado("Skin Tone", "US")]
		public Interpretacion.SkinTone skinTone;

		// Token: 0x0400014C RID: 332
		[LabelLocalizado("Face Type", "US")]
		public Interpretacion.FaceTypeV2 faceTypeV2;

		// Token: 0x0400014D RID: 333
		[LabelLocalizado("Makeup Amount", "US")]
		public Interpretacion.CantidadNoContable makeUpAmount;

		// Token: 0x0400014E RID: 334
		[PanelLayout(alturaMinima = 130f, alturaPreferida = 130f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
		[LayoutConfigUI(height = 20)]
		[LabelLocalizado("Eye Color", "US")]
		public FreeColor eyeColor;

		// Token: 0x0400014F RID: 335
		[PanelLayout(alturaMinima = 130f, alturaPreferida = 130f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
		[LayoutConfigUI(height = 20)]
		[LabelLocalizado("Nipple Color", "US")]
		public FreeColor nippleColor;

		// Token: 0x04000150 RID: 336
		[LabelLocalizado("Hair Length", "US")]
		public Interpretacion.Length hairLength;

		// Token: 0x04000151 RID: 337
		[LabelLocalizado("Hair Curls", "US")]
		public Interpretacion.Capacidad hairCurls;

		// Token: 0x04000152 RID: 338
		[PanelLayout(alturaMinima = 130f, alturaPreferida = 130f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
		[LayoutConfigUI(height = 20)]
		[LabelLocalizado("Hair Color", "US")]
		public FreeColor hairColor;

		// Token: 0x04000153 RID: 339
		[Ignore]
		[LabelLocalizado("Vag Experience", "US")]
		public Interpretacion.Capacidad vagExperience;

		// Token: 0x04000154 RID: 340
		[Ignore]
		[LabelLocalizado("Anus Experience", "US")]
		public Interpretacion.Capacidad anusExperience;

		// Token: 0x04000155 RID: 341
		[Ignore]
		[LabelLocalizado("Mouth Experience", "US")]
		public Interpretacion.Capacidad mouthExperience;
	}
}
