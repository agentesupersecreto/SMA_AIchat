using System;
using System.Collections.Generic;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000023 RID: 35
	public static class IFemaleCharInfoEXT
	{
		// Token: 0x060000BD RID: 189 RVA: 0x000027D4 File Offset: 0x000009D4
		public static IFemaleCharInfoPromediable GetPromediableData(this IFemaleCharInfo info)
		{
			FemaleCharInfoPromediable femaleCharInfoPromediable = default(FemaleCharInfoPromediable);
			femaleCharInfoPromediable.age += info.age;
			femaleCharInfoPromediable.height += info.height;
			femaleCharInfoPromediable.chest += info.chest;
			femaleCharInfoPromediable.waist += info.waist;
			femaleCharInfoPromediable.hips += info.hips;
			femaleCharInfoPromediable.breastScaleMod += info.breastScaleMod;
			femaleCharInfoPromediable.glutesScaleMod += info.glutesScaleMod;
			femaleCharInfoPromediable.consentlookAtPrivatesOri += info.consentlookAtPrivatesOri;
			femaleCharInfoPromediable.consentGrabBreastOri += info.consentGrabBreastOri;
			femaleCharInfoPromediable.consentGrabAssOri += info.consentGrabAssOri;
			femaleCharInfoPromediable.consentTouchClitOri += info.consentTouchClitOri;
			femaleCharInfoPromediable.consentOralSexOri += info.consentOralSexOri;
			femaleCharInfoPromediable.consentVagSexOri += info.consentVagSexOri;
			femaleCharInfoPromediable.consentAnalSexOri += info.consentAnalSexOri;
			femaleCharInfoPromediable.consentlookAtPrivates += info.consentlookAtPrivates;
			femaleCharInfoPromediable.consentGrabBreast += info.consentGrabBreast;
			femaleCharInfoPromediable.consentGrabAss += info.consentGrabAss;
			femaleCharInfoPromediable.consentTouchClit += info.consentTouchClit;
			femaleCharInfoPromediable.consentOralSex += info.consentOralSex;
			femaleCharInfoPromediable.consentVagSex += info.consentVagSex;
			femaleCharInfoPromediable.consentAnalSex += info.consentAnalSex;
			femaleCharInfoPromediable.oralExperienceWeight += info.oralExperienceWeight;
			femaleCharInfoPromediable.vaginalExperienceWeight += info.vaginalExperienceWeight;
			femaleCharInfoPromediable.analExperienceWeight += info.analExperienceWeight;
			return femaleCharInfoPromediable;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002988 File Offset: 0x00000B88
		public static IFemaleCharInfoPromediable Promedio(this IReadOnlyList<IFemaleCharInfoPromediable> infos)
		{
			int count = infos.Count;
			FemaleCharInfoPromediable femaleCharInfoPromediable = default(FemaleCharInfoPromediable);
			for (int i = 0; i < infos.Count; i++)
			{
				IFemaleCharInfoPromediable femaleCharInfoPromediable2 = infos[i];
				femaleCharInfoPromediable.age += femaleCharInfoPromediable2.age;
				femaleCharInfoPromediable.height += femaleCharInfoPromediable2.height;
				femaleCharInfoPromediable.chest += femaleCharInfoPromediable2.chest;
				femaleCharInfoPromediable.waist += femaleCharInfoPromediable2.waist;
				femaleCharInfoPromediable.hips += femaleCharInfoPromediable2.hips;
				femaleCharInfoPromediable.breastScaleMod += femaleCharInfoPromediable2.breastScaleMod;
				femaleCharInfoPromediable.glutesScaleMod += femaleCharInfoPromediable2.glutesScaleMod;
				femaleCharInfoPromediable.consentlookAtPrivatesOri += femaleCharInfoPromediable2.consentlookAtPrivatesOri;
				femaleCharInfoPromediable.consentGrabBreastOri += femaleCharInfoPromediable2.consentGrabBreastOri;
				femaleCharInfoPromediable.consentGrabAssOri += femaleCharInfoPromediable2.consentGrabAssOri;
				femaleCharInfoPromediable.consentTouchClitOri += femaleCharInfoPromediable2.consentTouchClitOri;
				femaleCharInfoPromediable.consentOralSexOri += femaleCharInfoPromediable2.consentOralSexOri;
				femaleCharInfoPromediable.consentVagSexOri += femaleCharInfoPromediable2.consentVagSexOri;
				femaleCharInfoPromediable.consentAnalSexOri += femaleCharInfoPromediable2.consentAnalSexOri;
				femaleCharInfoPromediable.consentlookAtPrivates += femaleCharInfoPromediable2.consentlookAtPrivates;
				femaleCharInfoPromediable.consentGrabBreast += femaleCharInfoPromediable2.consentGrabBreast;
				femaleCharInfoPromediable.consentGrabAss += femaleCharInfoPromediable2.consentGrabAss;
				femaleCharInfoPromediable.consentTouchClit += femaleCharInfoPromediable2.consentTouchClit;
				femaleCharInfoPromediable.consentOralSex += femaleCharInfoPromediable2.consentOralSex;
				femaleCharInfoPromediable.consentVagSex += femaleCharInfoPromediable2.consentVagSex;
				femaleCharInfoPromediable.consentAnalSex += femaleCharInfoPromediable2.consentAnalSex;
				femaleCharInfoPromediable.oralExperienceWeight += femaleCharInfoPromediable2.oralExperienceWeight;
				femaleCharInfoPromediable.vaginalExperienceWeight += femaleCharInfoPromediable2.vaginalExperienceWeight;
				femaleCharInfoPromediable.analExperienceWeight += femaleCharInfoPromediable2.analExperienceWeight;
			}
			femaleCharInfoPromediable.age /= count;
			femaleCharInfoPromediable.height /= count;
			femaleCharInfoPromediable.chest /= count;
			femaleCharInfoPromediable.waist /= count;
			femaleCharInfoPromediable.hips /= count;
			femaleCharInfoPromediable.breastScaleMod /= (float)count;
			femaleCharInfoPromediable.glutesScaleMod /= (float)count;
			femaleCharInfoPromediable.consentlookAtPrivatesOri /= (float)count;
			femaleCharInfoPromediable.consentGrabBreastOri /= (float)count;
			femaleCharInfoPromediable.consentGrabAssOri /= (float)count;
			femaleCharInfoPromediable.consentTouchClitOri /= (float)count;
			femaleCharInfoPromediable.consentOralSexOri /= (float)count;
			femaleCharInfoPromediable.consentVagSexOri /= (float)count;
			femaleCharInfoPromediable.consentAnalSexOri /= (float)count;
			femaleCharInfoPromediable.consentlookAtPrivates /= (float)count;
			femaleCharInfoPromediable.consentGrabBreast /= (float)count;
			femaleCharInfoPromediable.consentGrabAss /= (float)count;
			femaleCharInfoPromediable.consentTouchClit /= (float)count;
			femaleCharInfoPromediable.consentOralSex /= (float)count;
			femaleCharInfoPromediable.consentVagSex /= (float)count;
			femaleCharInfoPromediable.consentAnalSex /= (float)count;
			femaleCharInfoPromediable.oralExperienceWeight /= (float)count;
			femaleCharInfoPromediable.vaginalExperienceWeight /= (float)count;
			femaleCharInfoPromediable.analExperienceWeight /= (float)count;
			return femaleCharInfoPromediable;
		}
	}
}
