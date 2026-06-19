using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas.BuffAndDebuff
{
	// Token: 0x020000CB RID: 203
	public static class DefaultBuffAndDebuffGenerator
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x0001415B File Offset: 0x0001235B
		private static float GetAddByDamageDone(ref Interaction inter, float minValue, float maxValue, float maxDamageDone, float minDamageDone)
		{
			if (!inter.isValid)
			{
				return 0f;
			}
			return DefaultBuffAndDebuffGenerator.GetAddByDamageDone(inter.damagePercentageDone, minValue, maxValue, maxDamageDone, minDamageDone);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001417C File Offset: 0x0001237C
		private static float GetAddByDamageDone(float damageDone, float minValue, float maxValue, float maxDamageDone, float minDamageDone)
		{
			if (minValue == 0f)
			{
				Debug.LogError("usando funcion incorrecta, debe usarse una funcion sin medio");
			}
			float num = Mathf.InverseLerp(minDamageDone, maxDamageDone, damageDone);
			return MathfExtension.LerpConMedio(minValue, 0f, maxValue, num);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000141B4 File Offset: 0x000123B4
		private static float GetAddByDamageDonePositive(float damageDone, float maxValue, float maxDamageDone)
		{
			float num = Mathf.InverseLerp(0f, maxDamageDone, damageDone);
			return Mathf.Lerp(0f, maxValue, num);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000141DC File Offset: 0x000123DC
		private static float GetAddByTimes(int times, float minValue, float maxValue, float maxTimes, float minTimes)
		{
			if (minValue == 0f)
			{
				Debug.LogError("usando funcion incorrecta, debe usarse una funcion sin medio");
			}
			float num = Mathf.InverseLerp(minTimes, maxTimes, (float)times);
			return MathfExtension.LerpConMedio(minValue, 0f, maxValue, num);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00014214 File Offset: 0x00012414
		private static float GetModByTimes(int times, float minPercentage, float maxPercentage, float maxTimes, float minTimes)
		{
			if (minPercentage == 100f)
			{
				Debug.LogError("usando funcion incorrecta, debe usarse una funcion sin medio");
			}
			float num = Mathf.InverseLerp(minTimes, maxTimes, (float)times);
			return MathfExtension.LerpConMedio(minPercentage, 100f, maxPercentage, num) / 100f;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00014251 File Offset: 0x00012451
		private static float GetModByTimes(ref Interaction inter, float minPercentage, float maxPercentage, float maxTimes, float minTimes)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByTimes(inter.times, minPercentage, maxPercentage, maxTimes, minTimes);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00014274 File Offset: 0x00012474
		private static float GetModByTimesPositive(int times, float maxPercentage, float maxTimes)
		{
			float num = Mathf.InverseLerp(0f, maxTimes, (float)times);
			return Mathf.Lerp(100f, maxPercentage, num) / 100f;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000142A1 File Offset: 0x000124A1
		private static float GetModByTimesPositive(ref Interaction inter, float maxPercentage, float maxTimes)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByTimesPositive(inter.times, maxPercentage, maxTimes);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x000142C0 File Offset: 0x000124C0
		private static float GetModByDamageDonePositive(float damageDone, float maxPercentage, float maxDamageDone)
		{
			float num = Mathf.InverseLerp(0f, maxDamageDone, damageDone);
			return Mathf.Lerp(100f, maxPercentage, num) / 100f;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000142EC File Offset: 0x000124EC
		private static float GetModByDamageDonePositive(ref Interaction inter, float maxPercentage, float maxDamageDone, float damagePercentageDoneMod = 1f)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(inter.damagePercentageDone * damagePercentageDoneMod, maxPercentage, maxDamageDone);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0001430C File Offset: 0x0001250C
		private static float GetModByDamageDone(float damageDone, float minPercentage, float maxPercentage, float maxDamageDone, float minDamageDone)
		{
			if (minPercentage == 100f)
			{
				Debug.LogError("usando funcion incorrecta, debe usarse una funcion sin medio");
			}
			float num = Mathf.InverseLerp(minDamageDone, maxDamageDone, damageDone);
			return MathfExtension.LerpConMedio(minPercentage, 100f, maxPercentage, num) / 100f;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00014348 File Offset: 0x00012548
		private static float GetModByDamageDone(ref Interaction inter, float minPercentage, float maxPercentage, float maxDamageDone, float minDamageDone)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByDamageDone(inter.damagePercentageDone, minPercentage, maxPercentage, maxDamageDone, minDamageDone);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00014368 File Offset: 0x00012568
		private static float GetModByDamageDoneAndScorePositive(ref Interaction inter, ICharactersSceneInteractionsArchived archivedInteractions, float maxPercentage, float maxDamageDone, float damagePercentageDoneMod = 1f)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(inter.GetScoredAndAddedDamagePercentageDone(damagePercentageDoneMod, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref inter, archivedInteractions), 2f), maxPercentage, maxDamageDone);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00014393 File Offset: 0x00012593
		private static float GetModByDamageDoneAndScore(ref Interaction inter, ICharactersSceneInteractionsArchived archivedInteractions, float minPercentage, float maxPercentage, float maxDamageDone, float minDamageDone)
		{
			if (!inter.isValid)
			{
				return 1f;
			}
			return DefaultBuffAndDebuffGenerator.GetModByDamageDone(inter.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref inter, archivedInteractions), 2f), minPercentage, maxPercentage, maxDamageDone, minDamageDone);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000143C8 File Offset: 0x000125C8
		private static void GetStackedDamageDoneAnyRange(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out float damageDone)
		{
			int num;
			float num2;
			DefaultBuffAndDebuffGenerator.GetStackedAnyRange(archivedInteractions, main, secondary, secondaryStart, secondaryEnd, out num, out damageDone, out num2);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000143E8 File Offset: 0x000125E8
		private static void GetStackedDamageDoneScoredAnyRange(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out float damageDone, out float damageDoneScore)
		{
			int num;
			DefaultBuffAndDebuffGenerator.GetStackedAnyRange(archivedInteractions, main, secondary, secondaryStart, secondaryEnd, out num, out damageDone, out damageDoneScore);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00014408 File Offset: 0x00012608
		private static void GetStackedTimesAnyRange(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out int times)
		{
			float num;
			float num2;
			DefaultBuffAndDebuffGenerator.GetStackedAnyRange(archivedInteractions, main, secondary, secondaryStart, secondaryEnd, out times, out num, out num2);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00014428 File Offset: 0x00012628
		private static void GetStackedAnyRange(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out int times, out float damageDone, out float damageDoneScore)
		{
			ICollection enumValoresObject = typeof(EmotionPercentageRange).GetEnumValoresObject();
			times = 0;
			damageDone = 0f;
			damageDoneScore = 0f;
			foreach (object obj in enumValoresObject)
			{
				EmotionPercentageRange emotionPercentageRange = (EmotionPercentageRange)obj;
				if (emotionPercentageRange != EmotionPercentageRange.All && emotionPercentageRange >= secondaryStart && emotionPercentageRange <= secondaryEnd)
				{
					foreach (object obj2 in enumValoresObject)
					{
						EmotionPercentageRange emotionPercentageRange2 = (EmotionPercentageRange)obj2;
						if (emotionPercentageRange2 != EmotionPercentageRange.All)
						{
							EmotionDamagePair emotionDamagePair;
							archivedInteractions.PeekEmotionDamagePair(main, emotionPercentageRange2, secondary, emotionPercentageRange, out emotionDamagePair);
							if (emotionDamagePair.isValid)
							{
								times += emotionDamagePair.times;
								damageDone += emotionDamagePair.damagePercentageTotal;
								damageDoneScore += emotionDamagePair.damageScoreTotal;
							}
						}
					}
				}
			}
			if (times != 0)
			{
				damageDoneScore /= (float)times;
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00014548 File Offset: 0x00012748
		private static void GetStackedTimes(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out int times)
		{
			float num;
			float num2;
			DefaultBuffAndDebuffGenerator.GetStacked(archivedInteractions, main, mainRange, secondary, secondaryStart, secondaryEnd, out times, out num, out num2);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00014568 File Offset: 0x00012768
		private static void GetStacked(ICharactersSceneInteractionsArchived archivedInteractions, Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryStart, EmotionPercentageRange secondaryEnd, out int times, out float damageDone, out float damageDoneScore)
		{
			IEnumerable enumValoresObject = typeof(EmotionPercentageRange).GetEnumValoresObject();
			times = 0;
			damageDone = 0f;
			damageDoneScore = 0f;
			foreach (object obj in enumValoresObject)
			{
				EmotionPercentageRange emotionPercentageRange = (EmotionPercentageRange)obj;
				if (emotionPercentageRange >= secondaryStart && emotionPercentageRange <= secondaryEnd)
				{
					EmotionDamagePair emotionDamagePair;
					archivedInteractions.PeekEmotionDamagePair(main, mainRange, secondary, emotionPercentageRange, out emotionDamagePair);
					if (emotionDamagePair.isValid)
					{
						times += emotionDamagePair.times;
						damageDone += emotionDamagePair.damagePercentageTotal;
						damageDoneScore += emotionDamagePair.damageScoreTotal;
					}
				}
			}
			if (times != 0)
			{
				damageDoneScore /= (float)times;
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00014630 File Offset: 0x00012830
		private static void GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted(ISceneInteractions sceneInteractions, Guid male, Guid female, IReadOnlyDictionary<ITuple, BuffOnDesires> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(female, male);
			IEnumerable<TriggeringBodyPart> enumerable = typeof(TriggeringBodyPart).GetEnumValoresLimpiosObject().Cast<TriggeringBodyPart>();
			List<Desires> list = new List<Desires>();
			foreach (TriggeringBodyPart triggeringBodyPart in enumerable)
			{
				try
				{
					float num;
					switch (triggeringBodyPart)
					{
					case TriggeringBodyPart.notSpecified:
					case TriggeringBodyPart.toy:
					case TriggeringBodyPart.tool:
						num = 0.027775f;
						list.Add(Desires.Breast);
						list.Add(Desires.Mouth);
						list.Add(Desires.Ass);
						list.Add(Desires.Crotch);
						goto IL_0155;
					case TriggeringBodyPart.eyes:
						num = 0.08325f;
						list.Add(Desires.Breast);
						list.Add(Desires.Mouth);
						list.Add(Desires.Ass);
						list.Add(Desires.Crotch);
						goto IL_0155;
					case TriggeringBodyPart.mouth:
					case TriggeringBodyPart.tongue:
						num = 1f;
						list.Add(Desires.Mouth);
						goto IL_0155;
					case TriggeringBodyPart.torso:
						num = 0.333f;
						list.Add(Desires.Breast);
						goto IL_0155;
					case TriggeringBodyPart.hand:
					case TriggeringBodyPart.finger:
						num = 0.25f;
						list.Add(Desires.Breast);
						list.Add(Desires.Mouth);
						list.Add(Desires.Ass);
						list.Add(Desires.Crotch);
						goto IL_0155;
					case TriggeringBodyPart.leg:
						num = 0.1665f;
						list.Add(Desires.Ass);
						list.Add(Desires.Crotch);
						goto IL_0155;
					case TriggeringBodyPart.vagina:
						num = 1f;
						list.Add(Desires.Crotch);
						goto IL_0155;
					case TriggeringBodyPart.anus:
						num = 1f;
						list.Add(Desires.Ass);
						goto IL_0155;
					}
					continue;
					IL_0155:
					Interaction interaction;
					mainArchivedInteractions.Peek(triggeringBodyPart, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.All, false, out interaction);
					float num2 = DefaultBuffAndDebuffGenerator.<GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__GetDurationScore|20_0(ref interaction, num);
					float num3 = DefaultBuffAndDebuffGenerator.<GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__GetDamageAdd|20_1(ref interaction, num, mainArchivedInteractions);
					foreach (Desires desires in list)
					{
						DefaultBuffAndDebuffGenerator.<GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__ProdocudeAndAddBuff|20_2(r, desires, num2, num3);
					}
				}
				finally
				{
					list.Clear();
				}
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00014858 File Offset: 0x00012A58
		private static void GenerateBuffOnDesiresBySceneInteractionsOnCharacterTo(Desires desire, IReadOnlyDictionary<ITuple, BuffOnDesires> r, ICharactersSceneInteractionsArchived archivedInteractions, IReadOnlyList<SensitiveBodyPart> partesTarget, IReadOnlyList<TriggeringBodyPart> puedenPenetrar, IReadOnlyList<TriggeringBodyPart> noPuedenPenetrar)
		{
			foreach (SensitiveBodyPart sensitiveBodyPart in partesTarget)
			{
				Interaction interaction;
				archivedInteractions.Peek(TriggeringBodyPart.All, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, true, out interaction);
				Interaction interaction2;
				archivedInteractions.Peek(TriggeringBodyPart.All, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, false, out interaction2);
				Interaction interaction3;
				archivedInteractions.Peek(TriggeringBodyPart.All, sensitiveBodyPart, InterationReceivedType.All, Emotion.pain, false, out interaction3);
				float num = interaction2.GetScoredAndAddedDamagePercentageDone(interaction.isValid ? ((float)(interaction.times + 1)) : 1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction2, archivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure) - interaction3.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain);
				float modByDamageDone = DefaultBuffAndDebuffGenerator.GetModByDamageDone(num, 90f, 110f, 1000f, -1000f);
				BuffOnDesires buffOnDesires = new BuffOnDesires
				{
					desires = desire,
					modifier = EmotionModifier.gain,
					operation = Operation.mult,
					endHour = -1,
					value = modByDamageDone
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires);
				float addByDamageDone = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num, -10f, 10f, 500f, -500f);
				BuffOnDesires buffOnDesires2 = new BuffOnDesires
				{
					desires = desire,
					modifier = EmotionModifier.maxValue,
					operation = Operation.add,
					endHour = -1,
					value = addByDamageDone
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires2);
				if (sensitiveBodyPart.CanBePenetrated())
				{
					foreach (TriggeringBodyPart triggeringBodyPart in puedenPenetrar)
					{
						Interaction interaction4;
						archivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, true, out interaction4);
						Interaction interaction5;
						archivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, false, out interaction5);
						Interaction interaction6;
						archivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, InterationReceivedType.All, Emotion.pain, false, out interaction6);
						float addByDamageDone2 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(interaction5.GetScoredAndAddedDamagePercentageDone(interaction4.isValid ? ((float)(interaction4.times + 1)) : 1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction2, archivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure) - interaction6.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain), -10f, 10f, 5000f, -5000f);
						BuffOnDesires buffOnDesires3 = new BuffOnDesires
						{
							desires = desire,
							modifier = EmotionModifier.defaultValue,
							operation = Operation.add,
							endHour = -1,
							value = addByDamageDone2
						};
						DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires3);
					}
					foreach (TriggeringBodyPart triggeringBodyPart2 in noPuedenPenetrar)
					{
						Interaction interaction7;
						archivedInteractions.Peek(triggeringBodyPart2, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, true, out interaction7);
						Interaction interaction8;
						archivedInteractions.Peek(triggeringBodyPart2, sensitiveBodyPart, InterationReceivedType.All, Emotion.pleasure, false, out interaction8);
						Interaction interaction9;
						archivedInteractions.Peek(triggeringBodyPart2, sensitiveBodyPart, InterationReceivedType.All, Emotion.pain, false, out interaction9);
						float addByDamageDone3 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(interaction8.GetScoredAndAddedDamagePercentageDone(interaction7.isValid ? ((float)(interaction7.times + 1)) : 1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction2, archivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure) - interaction9.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain), -10f, 10f, 10000f, -10000f);
						BuffOnDesires buffOnDesires4 = new BuffOnDesires
						{
							desires = desire,
							modifier = EmotionModifier.defaultValue,
							operation = Operation.add,
							endHour = -1,
							value = addByDamageDone3
						};
						DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires4);
					}
				}
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00014BF0 File Offset: 0x00012DF0
		private static bool SucecionParaFavorabilityReq(InterationReceivedType entrante, out InterationReceivedType saliente, out TriggeringBodyPart estimulante)
		{
			saliente = InterationReceivedType.None;
			estimulante = TriggeringBodyPart.None;
			switch (entrante)
			{
			case InterationReceivedType.lookAt:
			case InterationReceivedType.photoshoot:
			case InterationReceivedType.pouringOn:
				estimulante = TriggeringBodyPart.hand;
				saliente = InterationReceivedType.caress;
				return true;
			case InterationReceivedType.caress:
			case InterationReceivedType.kiss:
			case InterationReceivedType.hump:
			case InterationReceivedType.poke:
			case InterationReceivedType.dryhump:
			case InterationReceivedType.lick:
				estimulante = TriggeringBodyPart.hand;
				saliente = InterationReceivedType.expose;
				return true;
			case InterationReceivedType.fingering:
			case InterationReceivedType.propped:
				estimulante = TriggeringBodyPart.penis;
				saliente = InterationReceivedType.penetration;
				return true;
			case InterationReceivedType.expose:
				estimulante = TriggeringBodyPart.mouth;
				saliente = InterationReceivedType.askToExpose;
				return true;
			case InterationReceivedType.askToExpose:
				estimulante = TriggeringBodyPart.hand;
				saliente = InterationReceivedType.expose;
				return true;
			case InterationReceivedType.forcePose:
				estimulante = TriggeringBodyPart.mouth;
				saliente = InterationReceivedType.askToPose;
				return true;
			case InterationReceivedType.askToPose:
				estimulante = TriggeringBodyPart.hand;
				saliente = InterationReceivedType.forcePose;
				return true;
			case InterationReceivedType.manipulateBody:
				estimulante = TriggeringBodyPart.mouth;
				saliente = InterationReceivedType.guideBody;
				return true;
			case InterationReceivedType.guideBody:
				estimulante = TriggeringBodyPart.hand;
				saliente = InterationReceivedType.manipulateBody;
				return true;
			case InterationReceivedType.handJob:
				estimulante = TriggeringBodyPart.penis;
				saliente = InterationReceivedType.penetration;
				return true;
			}
			return false;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00014CC5 File Offset: 0x00012EC5
		private static float GetEmoDamageMod(Emotion emo)
		{
			switch (emo)
			{
			case Emotion.disappointment:
				return 0.080000006f;
			case Emotion.rage:
				return 0.2f;
			case Emotion.pain:
				return 0.4f;
			case Emotion.fear:
				return 0.008f;
			default:
				return 1f;
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00014D00 File Offset: 0x00012F00
		private static float GetPleasureDamageAddByDurationAndTimes(ref Interaction pleasureInter, ICharactersSceneInteractionsArchived archivedInteractions)
		{
			if (pleasureInter.emotion != Emotion.pleasure)
			{
				return 0f;
			}
			float num = 1f;
			if (pleasureInter.fromPart == TriggeringBodyPart.All)
			{
				num *= (float)archivedInteractions.PeekTriggeringBodyPartCount(pleasureInter.toPart, pleasureInter.interationReceivedType, pleasureInter.emotion, pleasureInter.triggerMaxValue);
			}
			if (pleasureInter.toPart == SensitiveBodyPart.All)
			{
				num *= (float)archivedInteractions.PeekSensitiveBodyPartCount(pleasureInter.fromPart, pleasureInter.interationReceivedType, pleasureInter.emotion, pleasureInter.triggerMaxValue);
			}
			if (pleasureInter.interationReceivedType == InterationReceivedType.All)
			{
				num *= (float)archivedInteractions.PeekInterationReceivedTypeCount(pleasureInter.fromPart, pleasureInter.toPart, pleasureInter.emotion, pleasureInter.triggerMaxValue);
			}
			float num2 = pleasureInter.duration / (10f * num);
			float num3 = (float)pleasureInter.times / (2f * num);
			if (!float.IsFinite(num2))
			{
				num2 = 0f;
			}
			if (!float.IsFinite(num3))
			{
				num3 = 0f;
			}
			return num2 * 10f + num3 * 10f;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00014DF0 File Offset: 0x00012FF0
		private static float GetDamageAddByDurationAndTimes(ref Interaction inter, ICharactersSceneInteractionsArchived archivedInteractions)
		{
			float num = 1f;
			if (inter.fromPart == TriggeringBodyPart.All)
			{
				num *= (float)archivedInteractions.PeekTriggeringBodyPartCount(inter.toPart, inter.interationReceivedType, inter.emotion, inter.triggerMaxValue);
			}
			if (inter.toPart == SensitiveBodyPart.All)
			{
				num *= (float)archivedInteractions.PeekSensitiveBodyPartCount(inter.fromPart, inter.interationReceivedType, inter.emotion, inter.triggerMaxValue);
			}
			if (inter.interationReceivedType == InterationReceivedType.All)
			{
				num *= (float)archivedInteractions.PeekInterationReceivedTypeCount(inter.fromPart, inter.toPart, inter.emotion, inter.triggerMaxValue);
			}
			float num2 = inter.duration / (10f * num);
			float num3 = (float)inter.times / (2f * num);
			if (!float.IsFinite(num2))
			{
				num2 = 0f;
			}
			if (!float.IsFinite(num3))
			{
				num3 = 0f;
			}
			return num2 * 10f + num3 * 10f;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00014ED0 File Offset: 0x000130D0
		public static void GenerateBuffOnOxygenDemandBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnOxygenDemand> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(female, male);
			Interaction interaction;
			mainArchivedInteractions.Peek(TriggeringBodyPart.hand, SensitiveBodyPart.All, InterationReceivedType.caress, Emotion.All, false, out interaction);
			Interaction interaction2;
			mainArchivedInteractions.Peek(TriggeringBodyPart.hand, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.handJob, Emotion.All, false, out interaction2);
			Interaction interaction3;
			mainArchivedInteractions.Peek(TriggeringBodyPart.mouth, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.penetration, Emotion.All, false, out interaction3);
			Interaction interaction4;
			mainArchivedInteractions.Peek(TriggeringBodyPart.vagina, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.penetration, Emotion.All, false, out interaction4);
			Interaction interaction5;
			mainArchivedInteractions.Peek(TriggeringBodyPart.anus, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.penetration, Emotion.All, false, out interaction5);
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(r, DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref interaction, 0.85f));
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(r, DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref interaction2, 0.9f));
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(r, DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref interaction3, 0.95f));
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(r, DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref interaction4, 1f));
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(r, DefaultBuffAndDebuffGenerator.<GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref interaction5, 1f));
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00014F90 File Offset: 0x00013190
		public static void GenerateBuffOnPersonalityTraitBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnPersonalityTrait> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			int num;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.rage, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num);
			int num2;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.rage, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num2);
			float addByTimes = DefaultBuffAndDebuffGenerator.GetAddByTimes(Mathf.FloorToInt((float)num - (float)num2 * 0.25f), -5f, 5f, 100f, -100f);
			BuffOnPersonalityTrait buffOnPersonalityTrait = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.Dominant,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByTimes
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait);
			float num3;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.rage, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num3);
			float num4;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.rage, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num4);
			float addByDamageDone = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num3 - num4 * 0.25f, -5f, 5f, 10000f, -10000f);
			BuffOnPersonalityTrait buffOnPersonalityTrait2 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.Dominant,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByDamageDone
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait2);
			int num5;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.pain, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num5);
			int num6;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.pain, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num6);
			float addByTimes2 = DefaultBuffAndDebuffGenerator.GetAddByTimes(Mathf.FloorToInt((float)num5 - (float)num6 * 0.25f), -5f, 5f, 100f, -100f);
			BuffOnPersonalityTrait buffOnPersonalityTrait3 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.sensitive,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByTimes2
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait3);
			float num7;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.pain, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num7);
			float num8;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.pain, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num8);
			float addByDamageDone2 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num7 - num8 * 0.25f, -5f, 5f, 10000f, -10000f);
			BuffOnPersonalityTrait buffOnPersonalityTrait4 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.sensitive,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByDamageDone2
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait4);
			int num9;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.fear, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num9);
			int num10;
			DefaultBuffAndDebuffGenerator.GetStackedTimes(mainArchivedInteractions, Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.fear, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num10);
			float addByTimes3 = DefaultBuffAndDebuffGenerator.GetAddByTimes(Mathf.FloorToInt((float)num9 - (float)num10 * 0.25f), -5f, 5f, 100f, -100f);
			BuffOnPersonalityTrait buffOnPersonalityTrait5 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.Concerned,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByTimes3
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait5);
			float num11;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.fear, EmotionPercentageRange.fiftyToSixty, EmotionPercentageRange.ninetyToOneHundred, out num11);
			float num12;
			DefaultBuffAndDebuffGenerator.GetStackedDamageDoneAnyRange(mainArchivedInteractions, Emotion.pleasure, Emotion.fear, EmotionPercentageRange.zero, EmotionPercentageRange.fortyToFifty, out num12);
			float addByDamageDone3 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num11 - num12 * 0.25f, -5f, 5f, 10000f, -10000f);
			BuffOnPersonalityTrait buffOnPersonalityTrait6 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.Concerned,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByDamageDone3
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait6);
			Interaction interaction;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.expose, Emotion.pleasure, false, out interaction);
			Interaction interaction2;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.askToExpose, Emotion.pleasure, false, out interaction2);
			float num13 = (float)interaction.times - (float)interaction2.times * 0.25f;
			Interaction interaction3;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.forcePose, Emotion.pleasure, false, out interaction3);
			Interaction interaction4;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.askToPose, Emotion.pleasure, false, out interaction4);
			float num14 = (float)interaction3.times - (float)interaction4.times * 0.25f;
			Interaction interaction5;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.manipulateBody, Emotion.pleasure, false, out interaction5);
			Interaction interaction6;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.guideBody, Emotion.pleasure, false, out interaction6);
			float num15 = (float)interaction5.times - (float)interaction6.times * 0.25f;
			Interaction interaction7;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.pleasure, false, out interaction7);
			Interaction interaction8;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.pouringIn, Emotion.pleasure, false, out interaction8);
			float num16 = (float)interaction7.times - (float)interaction8.times * 0.25f;
			float num17 = num13 * 0.2f + num14 * 0.65f + num15 * 0.1f + num16 * 0.05f;
			Interaction interaction9;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.punch, Emotion.pain, false, out interaction9);
			Interaction interaction10;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.slap, Emotion.pain, false, out interaction10);
			Interaction interaction11;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.caress, Emotion.pleasure, false, out interaction11);
			Interaction interaction12;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.kiss, Emotion.pleasure, false, out interaction12);
			float num18 = interaction9.damagePercentageDone + interaction10.damagePercentageDone - (interaction11.damagePercentageDone + interaction12.damagePercentageDone) * 0.25f;
			Interaction interaction13;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.penetration, Emotion.pleasure, false, out interaction13);
			Interaction interaction14;
			mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.penetration, Emotion.pleasure, false, out interaction14);
			float num19 = interaction13.damagePercentageDone - interaction14.damagePercentageDone * 0.25f;
			float num20 = num18 * 0.6f + num19 * 0.4f;
			float addByTimes4 = DefaultBuffAndDebuffGenerator.GetAddByTimes(Mathf.FloorToInt(num17), -5f, 5f, 100f, -100f);
			BuffOnPersonalityTrait buffOnPersonalityTrait7 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.submissive,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByTimes4
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait7);
			float addByDamageDone4 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num20, -5f, 5f, 10000f, -10000f);
			BuffOnPersonalityTrait buffOnPersonalityTrait8 = new BuffOnPersonalityTrait
			{
				trait = PersonalityTraits.submissive,
				modifier = SimpleModifier.value,
				operation = Operation.add,
				endHour = -1,
				value = addByDamageDone4
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnPersonalityTrait>(r, ref buffOnPersonalityTrait8);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00015508 File Offset: 0x00013708
		public static void GenerateBuffOnDesiresBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnDesires> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			IReadOnlyList<TriggeringBodyPart> canPenetrateParts = TriggeringBodyPartHelper.canPenetrateParts;
			TriggeringBodyPart[] array = (from t in typeof(TriggeringBodyPart).GetEnumValoresLimpiosObject().Cast<TriggeringBodyPart>().Except(canPenetrateParts)
				where t != TriggeringBodyPart.All && t > TriggeringBodyPart.None
				select t).ToArray<TriggeringBodyPart>();
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsOnCharacterTo(Desires.Ass, r, mainArchivedInteractions, SensitiveBodyPartHelper.assParts, canPenetrateParts, array);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsOnCharacterTo(Desires.Crotch, r, mainArchivedInteractions, SensitiveBodyPartHelper.crotchParts, canPenetrateParts, array);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsOnCharacterTo(Desires.Breast, r, mainArchivedInteractions, SensitiveBodyPartHelper.breastParts, canPenetrateParts, array);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsOnCharacterTo(Desires.Mouth, r, mainArchivedInteractions, SensitiveBodyPartHelper.facialParts, canPenetrateParts, array);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted(sceneInteractions, male, female, r);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000155B4 File Offset: 0x000137B4
		public static void GenerateBuffOnFavorabilityReqOfInteractionBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnFavorabilityReqOfInteraction> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			ICollection enumValoresLimpiosObject = typeof(InterationReceivedType).GetEnumValoresLimpiosObject();
			ICollection enumValoresLimpiosObject2 = typeof(TriggeringBodyPart).GetEnumValoresLimpiosObject();
			ICollection enumValoresLimpiosObject3 = typeof(SensitiveBodyPart).GetEnumValoresLimpiosObject();
			foreach (object obj in enumValoresLimpiosObject)
			{
				InterationReceivedType interationReceivedType = (InterationReceivedType)obj;
				foreach (object obj2 in enumValoresLimpiosObject2)
				{
					TriggeringBodyPart triggeringBodyPart = (TriggeringBodyPart)obj2;
					foreach (object obj3 in enumValoresLimpiosObject3)
					{
						SensitiveBodyPart sensitiveBodyPart = (SensitiveBodyPart)obj3;
						Interaction interaction;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.pleasure, false, out interaction);
						float num = interaction.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction, mainArchivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure);
						if (num > 0f)
						{
							float modByDamageDonePositive = DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(num, 110f, 1000f);
							float num2 = 1f / modByDamageDonePositive;
							BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction = new BuffOnFavorabilityReqOfInteraction
							{
								interationReceivedType = interationReceivedType,
								fromPart = triggeringBodyPart,
								toPart = sensitiveBodyPart,
								modifier = SimpleModifier.value,
								operation = Operation.mult,
								endHour = -1,
								value = num2
							};
							DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnFavorabilityReqOfInteraction>(r, ref buffOnFavorabilityReqOfInteraction);
							InterationReceivedType interationReceivedType2;
							TriggeringBodyPart triggeringBodyPart2;
							if (DefaultBuffAndDebuffGenerator.SucecionParaFavorabilityReq(interationReceivedType, out interationReceivedType2, out triggeringBodyPart2))
							{
								BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction2 = new BuffOnFavorabilityReqOfInteraction
								{
									interationReceivedType = interationReceivedType2,
									fromPart = triggeringBodyPart2,
									toPart = sensitiveBodyPart,
									modifier = SimpleModifier.value,
									operation = Operation.mult,
									endHour = -1,
									value = num2
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnFavorabilityReqOfInteraction>(r, ref buffOnFavorabilityReqOfInteraction2);
							}
						}
						Interaction interaction2;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.rage, false, out interaction2);
						if (interaction2.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.rage) > 0f)
						{
							float modByDamageDonePositive2 = DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(interaction2.damagePercentageDone, 110f, 1000f);
							BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction3 = new BuffOnFavorabilityReqOfInteraction
							{
								interationReceivedType = interationReceivedType,
								fromPart = triggeringBodyPart,
								toPart = sensitiveBodyPart,
								modifier = SimpleModifier.value,
								operation = Operation.mult,
								endHour = -1,
								value = modByDamageDonePositive2
							};
							DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnFavorabilityReqOfInteraction>(r, ref buffOnFavorabilityReqOfInteraction3);
						}
					}
				}
			}
			ICharactersSceneInteractionsArchived mainArchivedInteractions2 = sceneInteractions.GetMainArchivedInteractions(female, male);
			foreach (object obj4 in enumValoresLimpiosObject)
			{
				InterationReceivedType interationReceivedType3 = (InterationReceivedType)obj4;
				InterationReceivedType interationReceivedType4;
				if (interationReceivedType3.TryInverse(out interationReceivedType4))
				{
					foreach (object obj5 in enumValoresLimpiosObject2)
					{
						TriggeringBodyPart triggeringBodyPart3 = (TriggeringBodyPart)obj5;
						SensitiveBodyPart sensitiveBodyPart2;
						if (triggeringBodyPart3.TryInverse(out sensitiveBodyPart2))
						{
							foreach (object obj6 in enumValoresLimpiosObject3)
							{
								SensitiveBodyPart sensitiveBodyPart3 = (SensitiveBodyPart)obj6;
								TriggeringBodyPart triggeringBodyPart4;
								if (sensitiveBodyPart3.TryInverse(out triggeringBodyPart4))
								{
									Interaction interaction3;
									mainArchivedInteractions2.Peek(triggeringBodyPart3, sensitiveBodyPart3, interationReceivedType3, Emotion.pleasure, false, out interaction3);
									if (interaction3.times > 0 && interaction3.duration > 0f)
									{
										float modByDamageDoneAndScorePositive = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction3, mainArchivedInteractions2, 101f, 100f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure));
										BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction4 = new BuffOnFavorabilityReqOfInteraction
										{
											interationReceivedType = interationReceivedType4,
											fromPart = triggeringBodyPart4,
											toPart = sensitiveBodyPart2,
											modifier = SimpleModifier.value,
											operation = Operation.mult,
											endHour = -1,
											value = 1f / modByDamageDoneAndScorePositive
										};
										DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnFavorabilityReqOfInteraction>(r, ref buffOnFavorabilityReqOfInteraction4);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00015A6C File Offset: 0x00013C6C
		public static void GenerateBuffOnInteractionBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnInteraction> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			ICollection enumValoresLimpiosObject = typeof(InterationReceivedType).GetEnumValoresLimpiosObject();
			ICollection enumValoresLimpiosObject2 = typeof(TriggeringBodyPart).GetEnumValoresLimpiosObject();
			ICollection enumValoresLimpiosObject3 = typeof(SensitiveBodyPart).GetEnumValoresLimpiosObject();
			foreach (object obj in enumValoresLimpiosObject)
			{
				InterationReceivedType interationReceivedType = (InterationReceivedType)obj;
				foreach (object obj2 in enumValoresLimpiosObject2)
				{
					TriggeringBodyPart triggeringBodyPart = (TriggeringBodyPart)obj2;
					foreach (object obj3 in enumValoresLimpiosObject3)
					{
						SensitiveBodyPart sensitiveBodyPart = (SensitiveBodyPart)obj3;
						Interaction interaction;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.pleasure, false, out interaction);
						if (interaction.isValid)
						{
							float modByDamageDoneAndScorePositive = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction, mainArchivedInteractions, 110f, 500f, 1f);
							if (modByDamageDoneAndScorePositive != 1f)
							{
								BuffOnInteraction buffOnInteraction = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pleasure,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = modByDamageDoneAndScorePositive
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction);
								BuffOnInteraction buffOnInteraction2 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pleasure,
									modifier = InteractionModifier.gainIntervalExpand,
									operation = ProductOperation.mult,
									endHour = -1,
									value = Mathf.Lerp(1f, modByDamageDoneAndScorePositive, 0.5f)
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction2);
							}
						}
						if (interaction.isValid)
						{
							float modByDamageDoneAndScorePositive2 = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction, mainArchivedInteractions, 110f, 500f, 1f);
							float num = 1f / modByDamageDoneAndScorePositive2;
							if (num != 1f)
							{
								BuffOnInteraction buffOnInteraction3 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.fear,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = num
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction3);
							}
						}
						if (interaction.isValid)
						{
							float modByDamageDoneAndScorePositive3 = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction, mainArchivedInteractions, 110f, 500f, 1f);
							float num2 = 1f / modByDamageDoneAndScorePositive3;
							if (num2 != 1f)
							{
								BuffOnInteraction buffOnInteraction4 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.disappointment,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = num2
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction4);
							}
						}
						if (interaction.isValid)
						{
							float modByDamageDoneAndScorePositive4 = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction, mainArchivedInteractions, 110f, 500f, 1f);
							float num3 = 1f / modByDamageDoneAndScorePositive4;
							if (modByDamageDoneAndScorePositive4 != 1f)
							{
								BuffOnInteraction buffOnInteraction5 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pain,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = num3
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction5);
								BuffOnInteraction buffOnInteraction6 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pain,
									modifier = InteractionModifier.gainMaxIntervalPosition,
									operation = ProductOperation.mult,
									endHour = -1,
									value = Mathf.Lerp(1f, modByDamageDoneAndScorePositive4, 0.5f)
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction6);
							}
						}
						Interaction interaction2;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.disappointment, false, out interaction2);
						if (interaction2.isValid)
						{
							float modByDamageDonePositive = DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(ref interaction2, 110f, 500f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disappointment));
							float num4 = 1f / modByDamageDonePositive;
							if (modByDamageDonePositive != 1f)
							{
								BuffOnInteraction buffOnInteraction7 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.disappointment,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = modByDamageDonePositive
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction7);
								BuffOnInteraction buffOnInteraction8 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pleasure,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = num4
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction8);
							}
						}
						Interaction interaction3;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.fear, false, out interaction3);
						if (interaction3.isValid)
						{
							float modByDamageDonePositive2 = DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(ref interaction2, 110f, 500f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.fear));
							if (modByDamageDonePositive2 != 1f)
							{
								BuffOnInteraction buffOnInteraction9 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.fear,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = modByDamageDonePositive2
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction9);
							}
						}
						Interaction interaction4;
						mainArchivedInteractions.Peek(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, Emotion.pain, false, out interaction4);
						if (interaction4.isValid)
						{
							float modByDamageDonePositive3 = DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(ref interaction4, 110f, 500f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain));
							float num5 = 1f / modByDamageDonePositive3;
							if (modByDamageDonePositive3 != 1f)
							{
								BuffOnInteraction buffOnInteraction10 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pain,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = modByDamageDonePositive3
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction10);
								BuffOnInteraction buffOnInteraction11 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pleasure,
									modifier = InteractionModifier.damage,
									operation = ProductOperation.mult,
									endHour = -1,
									value = num5
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction11);
								BuffOnInteraction buffOnInteraction12 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pleasure,
									modifier = InteractionModifier.gainIntervalExpand,
									operation = ProductOperation.mult,
									endHour = -1,
									value = Mathf.Lerp(1f, num5, 0.5f)
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction12);
								BuffOnInteraction buffOnInteraction13 = new BuffOnInteraction
								{
									interationReceivedType = interationReceivedType,
									fromPart = triggeringBodyPart,
									toPart = sensitiveBodyPart,
									emotion = Emotion.pain,
									modifier = InteractionModifier.gainMinIntervalPosition,
									operation = ProductOperation.mult,
									endHour = -1,
									value = Mathf.Lerp(1f, num5, 0.5f)
								};
								DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction13);
							}
						}
					}
				}
			}
			ICharactersSceneInteractionsArchived mainArchivedInteractions2 = sceneInteractions.GetMainArchivedInteractions(female, male);
			foreach (object obj4 in enumValoresLimpiosObject)
			{
				InterationReceivedType interationReceivedType2 = (InterationReceivedType)obj4;
				InterationReceivedType interationReceivedType3;
				if (interationReceivedType2.TryInverse(out interationReceivedType3))
				{
					foreach (object obj5 in enumValoresLimpiosObject2)
					{
						TriggeringBodyPart triggeringBodyPart2 = (TriggeringBodyPart)obj5;
						SensitiveBodyPart sensitiveBodyPart2;
						if (triggeringBodyPart2.TryInverse(out sensitiveBodyPart2))
						{
							foreach (object obj6 in enumValoresLimpiosObject3)
							{
								SensitiveBodyPart sensitiveBodyPart3 = (SensitiveBodyPart)obj6;
								TriggeringBodyPart triggeringBodyPart3;
								if (sensitiveBodyPart3.TryInverse(out triggeringBodyPart3))
								{
									Interaction interaction5;
									mainArchivedInteractions2.Peek(triggeringBodyPart2, sensitiveBodyPart3, interationReceivedType2, Emotion.pleasure, false, out interaction5);
									if (interaction5.times > 0 && interaction5.duration > 0f)
									{
										float modByDamageDoneAndScorePositive5 = DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction5, mainArchivedInteractions2, 101f, 100f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure));
										float num6 = 1f / modByDamageDoneAndScorePositive5;
										BuffOnInteraction buffOnInteraction14 = new BuffOnInteraction
										{
											interationReceivedType = interationReceivedType2,
											fromPart = triggeringBodyPart2,
											toPart = sensitiveBodyPart3,
											emotion = Emotion.fear,
											modifier = InteractionModifier.damage,
											operation = ProductOperation.mult,
											endHour = -1,
											value = num6
										};
										DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction14);
										BuffOnInteraction buffOnInteraction15 = new BuffOnInteraction
										{
											interationReceivedType = interationReceivedType2,
											fromPart = triggeringBodyPart2,
											toPart = sensitiveBodyPart3,
											emotion = Emotion.pain,
											modifier = InteractionModifier.damage,
											operation = ProductOperation.mult,
											endHour = -1,
											value = num6
										};
										DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction15);
										BuffOnInteraction buffOnInteraction16 = new BuffOnInteraction
										{
											interationReceivedType = interationReceivedType2,
											fromPart = triggeringBodyPart2,
											toPart = sensitiveBodyPart3,
											emotion = Emotion.disappointment,
											modifier = InteractionModifier.damage,
											operation = ProductOperation.mult,
											endHour = -1,
											value = num6
										};
										DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction16);
										BuffOnInteraction buffOnInteraction17 = new BuffOnInteraction
										{
											interationReceivedType = interationReceivedType2,
											fromPart = triggeringBodyPart2,
											toPart = sensitiveBodyPart3,
											emotion = Emotion.disappointment,
											modifier = InteractionModifier.damage,
											operation = ProductOperation.mult,
											endHour = -1,
											value = modByDamageDoneAndScorePositive5
										};
										DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnInteraction>(r, ref buffOnInteraction17);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001652C File Offset: 0x0001472C
		public static void GenerateBuffOnEmotionTowardCharacterBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEmotionTowardCharacter> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			float num = 0f;
			foreach (Emotion emotion in EmotionExt.emotionsWithDefaultValueBuff)
			{
				Interaction interaction;
				DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, emotion, false, out interaction);
				float emoDamageMod = DefaultBuffAndDebuffGenerator.GetEmoDamageMod(emotion);
				if (emotion.IsGood())
				{
					if (interaction.isValid)
					{
						num += ((emotion == Emotion.pleasure) ? interaction.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction, mainArchivedInteractions), 2f) : interaction.damagePercentageDone) * emoDamageMod;
					}
				}
				else if (interaction.isValid)
				{
					num -= interaction.damagePercentageDone * emoDamageMod;
				}
				if (!emotion.IsGood())
				{
					BuffOnEmotionTowardCharacter buffOnEmotionTowardCharacter = new BuffOnEmotionTowardCharacter
					{
						towardID = male.ToString(),
						emotion = emotion,
						modifier = EmotionModifier.defaultValue,
						operation = Operation.add,
						endHour = now.DaysToBuffEndHour(1),
						value = interaction.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(emotion)
					};
					DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionTowardCharacter>(r, ref buffOnEmotionTowardCharacter);
				}
			}
			if (num != 0f)
			{
				float addByDamageDone = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(num, -10f, 10f, 1000f, -1000f);
				BuffOnEmotionTowardCharacter buffOnEmotionTowardCharacter2 = new BuffOnEmotionTowardCharacter
				{
					towardID = male.ToString(),
					emotion = Emotion.favorability,
					modifier = EmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = -1,
					value = addByDamageDone
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionTowardCharacter>(r, ref buffOnEmotionTowardCharacter2);
			}
			Interaction interaction2;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.favorability, false, out interaction2);
			Interaction interaction3;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.favorability, true, out interaction3);
			float addByDamageDone2 = DefaultBuffAndDebuffGenerator.GetAddByDamageDone(interaction2.damagePercentageDone + interaction3.damagePercentageDone, -10f, 10f, 100f, -100f);
			if (addByDamageDone2 != 0f)
			{
				BuffOnEmotionTowardCharacter buffOnEmotionTowardCharacter3 = new BuffOnEmotionTowardCharacter
				{
					towardID = male.ToString(),
					emotion = Emotion.favorability,
					modifier = EmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = -1,
					value = addByDamageDone2
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionTowardCharacter>(r, ref buffOnEmotionTowardCharacter3);
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00016754 File Offset: 0x00014954
		public static void GenerateBuffOnHoleWearingWallsBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnHoleWearingWalls> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.vagWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagWalls, 0.1f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls2 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.vagWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagWalls, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls2);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls3 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.vagWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagWalls, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls3);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls4 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.vagWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagWalls, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls4);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls5 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.anusWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusWalls, 0.1f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls5);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls6 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.anusWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusWalls, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls6);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls7 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.anusWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusWalls, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls7);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls8 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.anusWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusWalls, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls8);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls9 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.throatWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatWalls, 0.1f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls9);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls10 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.throatWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatWalls, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls10);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls11 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.throatWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatWalls, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls11);
			BuffOnHoleWearingWalls buffOnHoleWearingWalls12 = new BuffOnHoleWearingWalls
			{
				toPart = SensitiveFemaleHoleWalls.throatWalls,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatWalls, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingWalls>(r, ref buffOnHoleWearingWalls12);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00016B5C File Offset: 0x00014D5C
		public static void GenerateBuffOnHoleWearingBottomBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnHoleWearingBottom> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.vagBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagBottom, 0.1f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom2 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.vagBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagBottom, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom2);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom3 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.vagBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagBottom, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom3);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom4 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.vagBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vagBottom, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom4);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom5 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.anusBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusBottom, 0.1f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom5);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom6 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.anusBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusBottom, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom6);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom7 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.anusBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusBottom, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom7);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom8 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.anusBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anusBottom, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom8);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom9 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.throatBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatBottom, 0.1f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom9);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom10 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.throatBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatBottom, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom10);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom11 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.throatBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatBottom, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom11);
			BuffOnHoleWearingBottom buffOnHoleWearingBottom12 = new BuffOnHoleWearingBottom
			{
				toPart = SensitiveFemaleHoleBottom.throatBottom,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throatBottom, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingBottom>(r, ref buffOnHoleWearingBottom12);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00016F64 File Offset: 0x00015164
		public static void GenerateBuffOnHoleWearingMotionBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnHoleWearingMotion> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.vag,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vag, 0.1f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion2 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.vag,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vag, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion2);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion3 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.vag,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vag, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion3);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion4 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.vag,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.vag, 0.033333335f, 150f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion4);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion5 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.anus,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anus, 0.1f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion5);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion6 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.anus,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anus, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion6);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion7 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.anus,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anus, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion7);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion8 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.anus,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.anus, 0.033333335f, 200f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion8);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion9 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.throat,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(1),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throat, 0.1f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion9);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion10 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.throat,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(3),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throat, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion10);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion11 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.throat,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = now.DaysToBuffEndHour(7),
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throat, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion11);
			BuffOnHoleWearingMotion buffOnHoleWearingMotion12 = new BuffOnHoleWearingMotion
			{
				toPart = SensitiveFemaleHole.throat,
				modifier = SimpleModifier.value,
				operation = AddOperation.add,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetHoleWearing(mainArchivedInteractions, SensitiveBodyPart.throat, 0.033333335f, 25f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnHoleWearingMotion>(r, ref buffOnHoleWearingMotion12);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00003B39 File Offset: 0x00001D39
		public static void GenerateBuffOnKarmaBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnKarma> r)
		{
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001736C File Offset: 0x0001556C
		public static void GenerateBuffOnEmotionAuraBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEmotionAura> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			Interaction interaction;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pleasure, false, out interaction);
			Interaction interaction2;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.enjoyment, false, out interaction2);
			Interaction interaction3;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.relief, false, out interaction3);
			Interaction interaction4;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.favorability, false, out interaction4);
			Interaction interaction5;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.arousal, false, out interaction5);
			Interaction interaction6;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.rage, false, out interaction6);
			Interaction interaction7;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pain, false, out interaction7);
			Interaction interaction8;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disappointment, false, out interaction8);
			Interaction interaction9;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.fear, false, out interaction9);
			Interaction interaction10;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disgust, false, out interaction10);
			float num = interaction.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction, mainArchivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure);
			float num2 = interaction2.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.enjoyment);
			float num3 = interaction3.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.relief);
			float num4 = interaction4.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.favorability);
			float num5 = interaction5.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.arousal);
			float num6 = interaction6.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.rage);
			float num7 = interaction7.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain);
			float num8 = interaction8.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disappointment);
			float num9 = interaction9.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.fear);
			float num10 = interaction10.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disgust);
			float num11 = num + num2 + num3 + num4 + num5;
			float num12 = num6 + num7 + num8 + num9 + num10;
			Interaction interaction11;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringIn, Emotion.pleasure, false, out interaction11);
			Interaction interaction12;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.pleasure, false, out interaction12);
			if (interaction12.isValid)
			{
				BuffOnEmotionAura buffOnEmotionAura = new BuffOnEmotionAura
				{
					emotion = Emotion.pleasure,
					modifier = SimpleEmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = -1,
					value = (float)interaction12.times / 20f
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionAura>(r, ref buffOnEmotionAura);
			}
			if (interaction11.isValid)
			{
				BuffOnEmotionAura buffOnEmotionAura2 = new BuffOnEmotionAura
				{
					emotion = Emotion.pleasure,
					modifier = SimpleEmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = -1,
					value = (float)interaction11.times / 10f
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionAura>(r, ref buffOnEmotionAura2);
			}
			float num13 = num12 - num11;
			float modByDamageDone = DefaultBuffAndDebuffGenerator.GetModByDamageDone(num13, 90f, 110f, 1000f, -1000f);
			if (num13 != 0f)
			{
				BuffOnEmotionAura buffOnEmotionAura3 = new BuffOnEmotionAura
				{
					emotion = Emotion.disgust,
					modifier = SimpleEmotionModifier.gain,
					operation = Operation.mult,
					endHour = -1,
					value = modByDamageDone
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionAura>(r, ref buffOnEmotionAura3);
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x000175E0 File Offset: 0x000157E0
		public static void GenerateBuffOnEmotionBySceneInteractionsForFemales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEmotion> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			foreach (object obj in typeof(Emotion).GetEnumValoresLimpiosObject())
			{
				Emotion emotion = (Emotion)obj;
				Interaction interaction;
				DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, emotion, false, out interaction);
				if (interaction.isValid)
				{
					float num = ((emotion == Emotion.pleasure) ? DefaultBuffAndDebuffGenerator.GetModByDamageDoneAndScorePositive(ref interaction, mainArchivedInteractions, 110f, 2000f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(emotion)) : DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(ref interaction, 110f, 2000f, DefaultBuffAndDebuffGenerator.GetEmoDamageMod(emotion)));
					BuffOnEmotion buffOnEmotion = new BuffOnEmotion
					{
						emotion = emotion,
						modifier = EmotionModifier.gain,
						operation = Operation.mult,
						endHour = -1,
						value = num
					};
					DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion);
				}
			}
			Interaction interaction2;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pleasure, false, out interaction2);
			Interaction interaction3;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.enjoyment, false, out interaction3);
			Interaction interaction4;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.relief, false, out interaction4);
			Interaction interaction5;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.favorability, false, out interaction5);
			Interaction interaction6;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.arousal, false, out interaction6);
			Interaction interaction7;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.rage, false, out interaction7);
			Interaction interaction8;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pain, false, out interaction8);
			Interaction interaction9;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disappointment, false, out interaction9);
			Interaction interaction10;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.fear, false, out interaction10);
			Interaction interaction11;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disgust, false, out interaction11);
			float num2 = interaction2.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction2, mainArchivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure);
			float num3 = interaction3.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.enjoyment);
			float num4 = interaction4.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.relief);
			float num5 = interaction5.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.favorability);
			float num6 = interaction6.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.arousal);
			float num7 = interaction7.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.rage);
			float num8 = interaction8.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain);
			float num9 = interaction9.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disappointment);
			float num10 = interaction10.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.fear);
			float num11 = interaction11.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disgust);
			float num12 = num2 + num3 + num4 + num5 + num6;
			float num13 = num7 + num8 + num9 + num10 + num11;
			float num14 = num2 - num13;
			float num15 = num3 - num13;
			float num16 = num4 - num13;
			float num17 = num5 - num13;
			float num18 = num6 - num13;
			float num19 = num7 - num12;
			float num20 = num8 - num12;
			float num21 = num9 - num12;
			float num22 = num10 - num12;
			float num23 = num11 - num12;
			if (num14 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.pleasure, num14, r);
			}
			if (num15 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.enjoyment, num15, r);
			}
			if (num16 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.relief, num16, r);
			}
			if (num17 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.favorability, num17, r);
			}
			if (num18 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.arousal, num18, r);
			}
			if (num19 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.rage, num19, r);
			}
			if (num20 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.pain, num20, r);
			}
			if (num21 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.disappointment, num21, r);
			}
			if (num22 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.fear, num22, r);
			}
			if (num23 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion.disgust, num23, r);
			}
			foreach (Emotion emotion2 in EmotionExt.emotionsWithDefaultValueBuff)
			{
				if (!emotion2.IsGood())
				{
					Interaction interaction12;
					DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, emotion2, false, out interaction12);
					float emoDamageMod = DefaultBuffAndDebuffGenerator.GetEmoDamageMod(emotion2);
					BuffOnEmotion buffOnEmotion2 = new BuffOnEmotion
					{
						emotion = emotion2,
						modifier = EmotionModifier.defaultValue,
						operation = Operation.add,
						endHour = now.DaysToBuffEndHour(1),
						value = interaction12.damagePercentageDone * emoDamageMod * 0.2f
					};
					DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion2);
					BuffOnEmotion buffOnEmotion3 = new BuffOnEmotion
					{
						emotion = emotion2,
						modifier = EmotionModifier.defaultValue,
						operation = Operation.add,
						endHour = now.DaysToBuffEndHour(3),
						value = interaction12.damagePercentageDone * emoDamageMod * 0.1f
					};
					DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion3);
				}
			}
			Interaction interaction13;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pleasure, true, out interaction13);
			if (interaction13.isValid)
			{
				BuffOnEmotion buffOnEmotion4 = new BuffOnEmotion
				{
					emotion = Emotion.arousal,
					modifier = EmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = -1,
					value = (float)interaction13.times * 0.1f
				};
				BuffOnEmotion buffOnEmotion5 = new BuffOnEmotion
				{
					emotion = Emotion.arousal,
					modifier = EmotionModifier.defaultValue,
					operation = Operation.add,
					endHour = now.DaysToBuffEndHour(1),
					value = (float)interaction13.times * 0.2f
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion4);
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion5);
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00017AB0 File Offset: 0x00015CB0
		public static void GenerateBuffOnEmotionAuraBySceneInteractionsForMales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEmotionAura> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			Interaction interaction;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pleasure, false, out interaction);
			Interaction interaction2;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.enjoyment, false, out interaction2);
			Interaction interaction3;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.relief, false, out interaction3);
			Interaction interaction4;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.favorability, false, out interaction4);
			Interaction interaction5;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.arousal, false, out interaction5);
			Interaction interaction6;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.rage, false, out interaction6);
			Interaction interaction7;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.pain, false, out interaction7);
			Interaction interaction8;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disappointment, false, out interaction8);
			Interaction interaction9;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.fear, false, out interaction9);
			Interaction interaction10;
			DefaultBuffAndDebuffGenerator.EmotionInteraction(mainArchivedInteractions, Emotion.disgust, false, out interaction10);
			float num = interaction.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction, mainArchivedInteractions), 2f) * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure);
			float num2 = interaction2.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.enjoyment);
			float num3 = interaction3.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.relief);
			float num4 = interaction4.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.favorability);
			float num5 = interaction5.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.arousal);
			float num6 = interaction6.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.rage);
			float num7 = interaction7.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pain);
			float num8 = interaction8.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disappointment);
			float num9 = interaction9.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.fear);
			float num10 = interaction10.damagePercentageDone * DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.disgust);
			float num11 = num + num2 + num3 + num4 + num5;
			float num12 = num6 + num7 + num8 + num9 + num10;
			float num13 = num - num12;
			float num14 = num2 - num12;
			float num15 = num3 - num12;
			float num16 = num4 - num12;
			float num17 = num5 - num12;
			float num18 = num6 - num11;
			float num19 = num7 - num11;
			float num20 = num8 - num11;
			float num21 = num9 - num11;
			float num22 = num10 - num11;
			if (num13 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.pleasure, num13, r);
			}
			if (num14 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.enjoyment, num14, r);
			}
			if (num15 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.relief, num15, r);
			}
			if (num16 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.favorability, num16, r);
			}
			if (num17 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.arousal, num17, r);
			}
			if (num18 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.rage, num18, r);
			}
			if (num19 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.pain, num19, r);
			}
			if (num20 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.disappointment, num20, r);
			}
			if (num21 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.fear, num21, r);
			}
			if (num22 != 0f)
			{
				DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion.disgust, num22, r);
			}
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00003B39 File Offset: 0x00001D39
		public static void GenerateBuffOnKarmaBySceneInteractionsForMales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnKarma> r)
		{
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00017D00 File Offset: 0x00015F00
		public static void GenerateBuffOnEmotionBySceneInteractionsForMales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEmotion> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			Interaction interaction;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringIn, Emotion.All, false, out interaction);
			Interaction interaction2;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.All, false, out interaction2);
			int num = interaction.times + interaction2.times;
			if (num > 0)
			{
				float modByTimesPositive = DefaultBuffAndDebuffGenerator.GetModByTimesPositive(num, 125f, 100f);
				BuffOnEmotion buffOnEmotion = new BuffOnEmotion
				{
					emotion = Emotion.disgust,
					modifier = EmotionModifier.gain,
					operation = Operation.mult,
					endHour = -1,
					value = 1f / modByTimesPositive
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(r, ref buffOnEmotion);
			}
			DefaultBuffAndDebuffGenerator.<GenerateBuffOnEmotionBySceneInteractionsForMales>g__GenerateGainBySexOrganAndAdd|40_0(mainArchivedInteractions, TriggeringBodyPart.penis, r);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00017DA4 File Offset: 0x00015FA4
		public static void GenerateBuffOnEyacTimesBySceneInteractionsForMales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEyaculationTimes> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			Interaction interaction;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringIn, Emotion.All, false, out interaction);
			Interaction interaction2;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.All, false, out interaction2);
			int num = interaction.times + interaction2.times;
			if (num > 0)
			{
				float modByTimesPositive = DefaultBuffAndDebuffGenerator.GetModByTimesPositive(num, 125f, 100f);
				BuffOnEyaculationTimes buffOnEyaculationTimes = new BuffOnEyaculationTimes
				{
					modifier = SimpleModifier.value,
					operation = ProductOperation.mult,
					endHour = -1,
					value = modByTimesPositive
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEyaculationTimes>(r, ref buffOnEyaculationTimes);
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00017E30 File Offset: 0x00016030
		public static void GenerateBuffOnEyacAmountBySceneInteractionsForMales(ISceneInteractions sceneInteractions, Guid male, Guid female, bool sceneAborted, DateTime now, IReadOnlyDictionary<ITuple, BuffOnEyaculationAmount> r)
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = sceneInteractions.GetMainArchivedInteractions(male, female);
			Interaction interaction;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringIn, Emotion.All, false, out interaction);
			Interaction interaction2;
			mainArchivedInteractions.Peek(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.All, false, out interaction2);
			int num = interaction.times + interaction2.times;
			if (num > 0)
			{
				float modByTimesPositive = DefaultBuffAndDebuffGenerator.GetModByTimesPositive(num, 125f, 100f);
				BuffOnEyaculationAmount buffOnEyaculationAmount = new BuffOnEyaculationAmount
				{
					modifier = SimpleModifier.value,
					operation = ProductOperation.mult,
					endHour = -1,
					value = modByTimesPositive
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEyaculationAmount>(r, ref buffOnEyaculationAmount);
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00017EBC File Offset: 0x000160BC
		private static float GetHoleWearing(ICharactersSceneInteractionsArchived archivedInteractions, SensitiveBodyPart hole, float maxValue, float maxDamageDone)
		{
			IEnumerable enumValoresLimpiosObject = typeof(IntercouseInterationReceivedType).GetEnumValoresLimpiosObject();
			float num = 0f;
			foreach (object obj in enumValoresLimpiosObject)
			{
				InterationReceivedType interationReceivedType = (InterationReceivedType)obj;
				Interaction interaction;
				archivedInteractions.Peek(TriggeringBodyPart.All, hole, interationReceivedType, Emotion.pain, false, out interaction);
				num += interaction.damagePercentageDone;
			}
			return DefaultBuffAndDebuffGenerator.GetAddByDamageDonePositive(num, maxValue, maxDamageDone);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00017F40 File Offset: 0x00016140
		private static void EmotionInteraction(ICharactersSceneInteractions archivedInteractions, Emotion emo, bool maxValue, out Interaction interaction)
		{
			archivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, emo, maxValue, out interaction);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00017F50 File Offset: 0x00016150
		private static void AddOrStack<TKey, TBuff>(IReadOnlyDictionary<TKey, TBuff> dicc2, ref TBuff other) where TKey : struct, ITuple where TBuff : IIdentifiableBuff<TKey>, IFloatValuableBuff, IStackableBuff<TBuff>, IPrintableBuff, IContextValidableBuff
		{
			Dictionary<TKey, TBuff> dictionary = dicc2 as Dictionary<TKey, TBuff>;
			if (other.buffValue == 0f || !other.isContextValid)
			{
				return;
			}
			TBuff tbuff;
			if (dictionary.TryGetValue(other.valueId, out tbuff))
			{
				tbuff.StackToSelf(ref other);
				dictionary[other.valueId] = tbuff;
				return;
			}
			if (!other.ValueIsValid())
			{
				return;
			}
			dictionary.Add(other.valueId, other);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00017FEC File Offset: 0x000161EC
		[Obsolete("ahora se debe cargar un diccionario , entonces pueden haber collisiones", true)]
		private static void OnlyAdd<TKey, TBuff>(IReadOnlyDictionary<TKey, TBuff> dicc2, ref TBuff other) where TKey : struct, ITuple where TBuff : IIdentifiableBuff<TKey>, IFloatValuableBuff, IStackableBuff<TBuff>
		{
			Dictionary<TKey, TBuff> dictionary = dicc2 as Dictionary<TKey, TBuff>;
			if (other.buffValue == 0f)
			{
				if (dictionary.ContainsKey(other.valueId))
				{
					string text = "Diccionario ya tiene id: ";
					TKey valueId = other.valueId;
					Debug.LogError(text + valueId.ToString());
				}
				return;
			}
			dictionary.Add(other.valueId, other);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0001806C File Offset: 0x0001626C
		private static void AddOrStack<TBuff>(IReadOnlyDictionary<ITuple, TBuff> dicc2, ref TBuff other) where TBuff : IIdentifiableBuff, IFloatValuableBuff, IStackableBuff<TBuff>, IPrintableBuff, IContextValidableBuff
		{
			Dictionary<ITuple, TBuff> dictionary = dicc2 as Dictionary<ITuple, TBuff>;
			if (other.buffValue == 0f || !other.isContextValid)
			{
				return;
			}
			ITuple id = other.id;
			TBuff tbuff;
			if (dictionary.TryGetValue(id, out tbuff))
			{
				tbuff.StackToSelf(ref other);
				dictionary[id] = tbuff;
				return;
			}
			if (!other.ValueIsValid())
			{
				return;
			}
			dictionary.Add(id, other);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000180F4 File Offset: 0x000162F4
		[Obsolete("ahora se debe cargar un diccionario , entonces pueden haber collisiones", true)]
		private static void OnlyAdd<TBuff>(IReadOnlyDictionary<ITuple, TBuff> dicc2, ref TBuff other) where TBuff : IIdentifiableBuff, IFloatValuableBuff, IStackableBuff<TBuff>
		{
			Dictionary<ITuple, TBuff> dictionary = dicc2 as Dictionary<ITuple, TBuff>;
			ITuple id = other.id;
			if (other.buffValue == 0f)
			{
				if (dictionary.ContainsKey(id))
				{
					string text = "Diccionario ya tiene id: ";
					ITuple id2 = other.id;
					Debug.LogError(text + ((id2 != null) ? id2.ToString() : null));
				}
				return;
			}
			dictionary.Add(id, other);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00018166 File Offset: 0x00016366
		[CompilerGenerated]
		internal static float <GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__GetDurationScore|20_0(ref Interaction interaction, float durationMod)
		{
			return Mathf.Clamp(interaction.duration * durationMod, 0f, 90f) / 90f;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00018185 File Offset: 0x00016385
		[CompilerGenerated]
		internal static float <GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__GetDamageAdd|20_1(ref Interaction interaction, float damageMod, ICharactersSceneInteractionsArchived archivedInvertedInteractions)
		{
			return DefaultBuffAndDebuffGenerator.GetAddByDamageDonePositive((interaction.damagePercentageDone + DefaultBuffAndDebuffGenerator.GetDamageAddByDurationAndTimes(ref interaction, archivedInvertedInteractions)) * damageMod, 2f, 100f);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000181A8 File Offset: 0x000163A8
		[CompilerGenerated]
		internal static void <GenerateBuffOnDesiresBySceneInteractionsOnFemaleInverted>g__ProdocudeAndAddBuff|20_2(IReadOnlyDictionary<ITuple, BuffOnDesires> r, Desires desire, float durationScore, float damageAdd)
		{
			BuffOnDesires buffOnDesires = new BuffOnDesires
			{
				desires = desire,
				modifier = EmotionModifier.defaultValue,
				operation = Operation.add,
				endHour = -1,
				value = damageAdd
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires);
			BuffOnDesires buffOnDesires2 = new BuffOnDesires
			{
				desires = desire,
				modifier = EmotionModifier.maxValue,
				operation = Operation.add,
				endHour = -1,
				value = Mathf.Lerp(0f, 2f, durationScore)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnDesires>(r, ref buffOnDesires2);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00018238 File Offset: 0x00016438
		[CompilerGenerated]
		internal static float <GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__GetScore|26_0(ref Interaction interaction, float durationMod)
		{
			return Mathf.Clamp(interaction.duration * durationMod, 0f, 240f) / 240f;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00018258 File Offset: 0x00016458
		[CompilerGenerated]
		internal static void <GenerateBuffOnOxygenDemandBySceneInteractionsForFemales>g__ProdocudeAndAddBuff|26_1(IReadOnlyDictionary<ITuple, BuffOnOxygenDemand> r, float score)
		{
			BuffOnOxygenDemand buffOnOxygenDemand = new BuffOnOxygenDemand
			{
				modifier = SimpleModifier.value,
				operation = ProductOperation.mult,
				endHour = -1,
				value = Mathf.LerpUnclamped(1f, 0.9f, score)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnOxygenDemand>(r, ref buffOnOxygenDemand);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000182A8 File Offset: 0x000164A8
		[CompilerGenerated]
		internal static void <GenerateBuffOnEmotionBySceneInteractionsForFemales>g__GenerateGainBuffandAdd|37_0(Emotion emo, float score, IReadOnlyDictionary<ITuple, BuffOnEmotion> dicc)
		{
			if (!emo.IsFemale())
			{
				return;
			}
			BuffOnEmotion buffOnEmotion = new BuffOnEmotion
			{
				emotion = emo,
				modifier = EmotionModifier.gain,
				operation = Operation.mult,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetModByDamageDone(score, 90f, 110f, 2000f, -2000f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(dicc, ref buffOnEmotion);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00018314 File Offset: 0x00016514
		[CompilerGenerated]
		internal static void <GenerateBuffOnEmotionAuraBySceneInteractionsForMales>g__GenerateGainBuffandAdd|38_0(Emotion emo, float score, IReadOnlyDictionary<ITuple, BuffOnEmotionAura> dicc)
		{
			if (!emo.IsFemale())
			{
				return;
			}
			BuffOnEmotionAura buffOnEmotionAura = new BuffOnEmotionAura
			{
				emotion = emo,
				modifier = SimpleEmotionModifier.gain,
				operation = Operation.mult,
				endHour = -1,
				value = DefaultBuffAndDebuffGenerator.GetModByDamageDone(score, 90f, 110f, 2000f, -2000f)
			};
			DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotionAura>(dicc, ref buffOnEmotionAura);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00018380 File Offset: 0x00016580
		[CompilerGenerated]
		internal static void <GenerateBuffOnEmotionBySceneInteractionsForMales>g__GenerateGainBySexOrganAndAdd|40_0(ICharactersSceneInteractionsArchived archivedInteractions, TriggeringBodyPart organ, IReadOnlyDictionary<ITuple, BuffOnEmotion> dicc)
		{
			Interaction interaction;
			archivedInteractions.Peek(organ, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.All, false, out interaction);
			if (interaction.isValid)
			{
				float num = 1f / (DefaultBuffAndDebuffGenerator.GetEmoDamageMod(Emotion.pleasure) * DefaultBuffAndDebuffGenerator.GetModByDamageDonePositive(interaction.GetScoredAndAddedDamagePercentageDone(1f, DefaultBuffAndDebuffGenerator.GetPleasureDamageAddByDurationAndTimes(ref interaction, archivedInteractions), 2f), 110f, 1000f));
				BuffOnEmotion buffOnEmotion = new BuffOnEmotion
				{
					emotion = Emotion.pleasure,
					modifier = EmotionModifier.gain,
					operation = Operation.mult,
					endHour = -1,
					value = num
				};
				DefaultBuffAndDebuffGenerator.AddOrStack<BuffOnEmotion>(dicc, ref buffOnEmotion);
			}
		}
	}
}
