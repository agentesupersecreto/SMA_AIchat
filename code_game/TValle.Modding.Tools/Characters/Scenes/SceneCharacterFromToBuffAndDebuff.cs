using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public class SceneCharacterFromToBuffAndDebuff
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00003928 File Offset: 0x00001B28
		public static SceneCharacterFromToBuffAndDebuff Combine(IReadOnlyList<SceneCharacterFromToBuffAndDebuff> items)
		{
			if (items == null || items.Count == 0)
			{
				return null;
			}
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff = items[0];
			if (items.Count == 1)
			{
				return sceneCharacterFromToBuffAndDebuff;
			}
			for (int i = 1; i < items.Count; i++)
			{
				SceneCharacterFromToBuffAndDebuff.Combine(sceneCharacterFromToBuffAndDebuff, items[i]);
			}
			return sceneCharacterFromToBuffAndDebuff;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00003974 File Offset: 0x00001B74
		private static void Combine(SceneCharacterFromToBuffAndDebuff main, SceneCharacterFromToBuffAndDebuff other)
		{
			if (main.character != other.character)
			{
				Debug.LogError("Trying to Combine Buff data from different characters");
			}
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnKarma>(ref main.BuffOnKarma, other.BuffOnKarma);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnPersonalityTrait>(ref main.BuffOnPersonalityTrait, other.BuffOnPersonalityTrait);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnDesires>(ref main.BuffOnDesires, other.BuffOnDesires);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnFavorabilityReqOfInteraction>(ref main.BuffOnFavorabilityReqOfInteraction, other.BuffOnFavorabilityReqOfInteraction);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnInteraction>(ref main.BuffOnInteraction, other.BuffOnInteraction);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnEmotionAura>(ref main.BuffOnEmotionAura, other.BuffOnEmotionAura);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnEmotionTowardCharacter>(ref main.BuffOnEmotionTowardCharacter, other.BuffOnEmotionTowardCharacter);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnEmotion>(ref main.BuffOnEmotion, other.BuffOnEmotion);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnHoleWearingWalls>(ref main.BuffOnHoleWearingWalls, other.BuffOnHoleWearingWalls);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnHoleWearingBottom>(ref main.BuffOnHoleWearingBottom, other.BuffOnHoleWearingBottom);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnHoleWearingMotion>(ref main.BuffOnHoleWearingMotion, other.BuffOnHoleWearingMotion);
			SceneCharacterFromToBuffAndDebuff.Combine<BuffOnOxygenDemand>(ref main.BuffOnOxygenDemand, other.BuffOnOxygenDemand);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00003A6C File Offset: 0x00001C6C
		private static void Combine<TBuff>(ref Dictionary<ITuple, TBuff> main, Dictionary<ITuple, TBuff> other) where TBuff : IStackableBuff<TBuff>, IIdentifiableBuff
		{
			if (other == null || other.Count == 0)
			{
				return;
			}
			if (main == null)
			{
				main = new Dictionary<ITuple, TBuff>();
			}
			foreach (KeyValuePair<ITuple, TBuff> keyValuePair in other)
			{
				if (!main.TryAdd(keyValuePair.Key, keyValuePair.Value))
				{
					TBuff tbuff = main[keyValuePair.Key];
					TBuff value = keyValuePair.Value;
					if (!tbuff.IsStackableWith(ref value))
					{
						Debug.LogError("cant stack buff: " + keyValuePair.Key.ToString());
					}
					else
					{
						tbuff.StackToSelf(ref value);
						main[keyValuePair.Key] = tbuff;
					}
				}
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00003B4C File Offset: 0x00001D4C
		public SceneCharacterFromToBuffAndDebuff(SceneCharacter Character)
		{
			if (Character == null)
			{
				throw new ArgumentNullException("Character", "Character null reference.");
			}
			this.m_character = Character;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00003B74 File Offset: 0x00001D74
		public SceneCharacter character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00003B7C File Offset: 0x00001D7C
		public void Apply()
		{
			SceneCharacter character = this.m_character;
			if (character == null)
			{
				return;
			}
			IBuffableBySceneInteractionsCharacter componentInChildren = character.GetComponentInChildren<IBuffableBySceneInteractionsCharacter>();
			if (componentInChildren == null)
			{
				return;
			}
			componentInChildren.Apply(this);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00003B9C File Offset: 0x00001D9C
		public List<IPrintableBuff> GetAllPrintables()
		{
			return SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnKarma>(this.BuffOnKarma).Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnPersonalityTrait>(this.BuffOnPersonalityTrait)).Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnDesires>(this.BuffOnDesires))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnFavorabilityReqOfInteraction>(this.BuffOnFavorabilityReqOfInteraction))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnInteraction>(this.BuffOnInteraction))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnEmotionAura>(this.BuffOnEmotionAura))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnEmotionTowardCharacter>(this.BuffOnEmotionTowardCharacter))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnEmotion>(this.BuffOnEmotion))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnHoleWearingWalls>(this.BuffOnHoleWearingWalls))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnHoleWearingBottom>(this.BuffOnHoleWearingBottom))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnHoleWearingMotion>(this.BuffOnHoleWearingMotion))
				.Concat(SceneCharacterFromToBuffAndDebuff.GetPrintables<ITuple, BuffOnOxygenDemand>(this.BuffOnOxygenDemand))
				.ToList<IPrintableBuff>();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00003C69 File Offset: 0x00001E69
		private static IEnumerable<IPrintableBuff> GetPrintables<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dicc) where TValue : IPrintableBuff, IValidableBuff, IFloatValuableBuff
		{
			return (((dicc != null) ? dicc.Values : null) ?? Array.Empty<TValue>()).Where((TValue buff) => buff.isValid && buff.buffValue != 0f).Cast<IPrintableBuff>();
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00003CAC File Offset: 0x00001EAC
		public void DebugPrint()
		{
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnKarma>(this.m_character, this.BuffOnKarma);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnPersonalityTrait>(this.m_character, this.BuffOnPersonalityTrait);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnDesires>(this.m_character, this.BuffOnDesires);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnFavorabilityReqOfInteraction>(this.m_character, this.BuffOnFavorabilityReqOfInteraction);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnInteraction>(this.m_character, this.BuffOnInteraction);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnEmotionAura>(this.m_character, this.BuffOnEmotionAura);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnEmotionTowardCharacter>(this.m_character, this.BuffOnEmotionTowardCharacter);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnEmotion>(this.m_character, this.BuffOnEmotion);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnHoleWearingWalls>(this.m_character, this.BuffOnHoleWearingWalls);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnHoleWearingBottom>(this.m_character, this.BuffOnHoleWearingBottom);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnHoleWearingMotion>(this.m_character, this.BuffOnHoleWearingMotion);
			SceneCharacterFromToBuffAndDebuff.DebugPrint<ITuple, BuffOnOxygenDemand>(this.m_character, this.BuffOnOxygenDemand);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00003D88 File Offset: 0x00001F88
		private static void DebugPrint<TKey, TValue>(SceneCharacter character, Dictionary<TKey, TValue> dicc) where TValue : IPrintableBuff
		{
			if (dicc != null)
			{
				foreach (KeyValuePair<TKey, TValue> keyValuePair in dicc)
				{
					string[] array = new string[5];
					array[0] = character.fullName;
					array[1] = " ";
					array[2] = typeof(TValue).Name;
					array[3] = " ";
					int num = 4;
					TValue value = keyValuePair.Value;
					array[num] = value.DebugPrint();
					Debug.LogWarning(string.Concat(array));
				}
			}
		}

		// Token: 0x0400008E RID: 142
		[SerializeField]
		[JustToReadUI]
		private SceneCharacter m_character;

		// Token: 0x0400008F RID: 143
		public Dictionary<ITuple, BuffOnKarma> BuffOnKarma;

		// Token: 0x04000090 RID: 144
		public Dictionary<ITuple, BuffOnPersonalityTrait> BuffOnPersonalityTrait;

		// Token: 0x04000091 RID: 145
		public Dictionary<ITuple, BuffOnDesires> BuffOnDesires;

		// Token: 0x04000092 RID: 146
		public Dictionary<ITuple, BuffOnFavorabilityReqOfInteraction> BuffOnFavorabilityReqOfInteraction;

		// Token: 0x04000093 RID: 147
		public Dictionary<ITuple, BuffOnInteraction> BuffOnInteraction;

		// Token: 0x04000094 RID: 148
		public Dictionary<ITuple, BuffOnEmotionAura> BuffOnEmotionAura;

		// Token: 0x04000095 RID: 149
		public Dictionary<ITuple, BuffOnEmotionTowardCharacter> BuffOnEmotionTowardCharacter;

		// Token: 0x04000096 RID: 150
		public Dictionary<ITuple, BuffOnEmotion> BuffOnEmotion;

		// Token: 0x04000097 RID: 151
		public Dictionary<ITuple, BuffOnHoleWearingWalls> BuffOnHoleWearingWalls;

		// Token: 0x04000098 RID: 152
		public Dictionary<ITuple, BuffOnHoleWearingBottom> BuffOnHoleWearingBottom;

		// Token: 0x04000099 RID: 153
		public Dictionary<ITuple, BuffOnHoleWearingMotion> BuffOnHoleWearingMotion;

		// Token: 0x0400009A RID: 154
		public Dictionary<ITuple, BuffOnOxygenDemand> BuffOnOxygenDemand;

		// Token: 0x0400009B RID: 155
		public Dictionary<ITuple, BuffOnEyaculationTimes> BuffOnEyaculationTimes;

		// Token: 0x0400009C RID: 156
		public Dictionary<ITuple, BuffOnEyaculationAmount> BuffOnEyaculationAmount;
	}
}
