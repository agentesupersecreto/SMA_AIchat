using System;
using System.Collections;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x02000094 RID: 148
	public class EmocionesGainByFatigue : CustomMonobehaviour
	{
		// Token: 0x06000319 RID: 793 RVA: 0x00013A70 File Offset: 0x00011C70
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_self = this.GetComponentEnRoot(false);
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			this.m_BuffDeCharacter = this.m_self.GetComponentEnRoot<BuffDeCharacter>();
			if (this.m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			base.SetYieldStart();
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00013AE8 File Offset: 0x00011CE8
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!this.m_self.isMemoryLoaded)
			{
				yield return null;
			}
			while (!this.m_BuffDeCharacter.isStared)
			{
				yield return null;
			}
			float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, this.m_self.ID_UnicoString, 2f);
			foreach (Emotion emotion in EmotionExt.femaleEmotions)
			{
				bool flag = emotion.IsGood();
				BuffMap buffMap;
				BuffOnEmocionGainArg buffOnEmocionGainArg;
				BuffAndDebuffGeneratorHelper.GenerarBuffMap<BuffOnEmocionGainArg>("Tvalle.Buff.EmotionGainModByFatigue", out buffMap, out buffOnEmocionGainArg);
				buffOnEmocionGainArg.emo = emotion;
				buffOnEmocionGainArg.gainMod = Mathf.Lerp(1f, 3f, applyableFatigueMod);
				if (flag)
				{
					buffOnEmocionGainArg.gainMod = 1f / buffOnEmocionGainArg.gainMod;
				}
				BuffAndDebuffGeneratorHelper.AddNoStackBuff<BuffOnEmocionGainArg>(this.m_BuffDeCharacter, buffMap, emotion.ToString() + "GainByFatigue", buffOnEmocionGainArg, new BuffMap.Duracion
				{
					hours = 3
				});
			}
			yield break;
		}

		// Token: 0x04000316 RID: 790
		private const string buffName = "Tvalle.Buff.EmotionGainModByFatigue";

		// Token: 0x04000317 RID: 791
		private Character m_self;

		// Token: 0x04000318 RID: 792
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
