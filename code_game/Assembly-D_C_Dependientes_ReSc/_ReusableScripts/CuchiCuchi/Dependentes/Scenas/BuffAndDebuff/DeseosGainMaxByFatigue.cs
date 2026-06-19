using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x02000092 RID: 146
	public class DeseosGainMaxByFatigue : CustomMonobehaviour
	{
		// Token: 0x06000310 RID: 784 RVA: 0x00013888 File Offset: 0x00011A88
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

		// Token: 0x06000311 RID: 785 RVA: 0x00013900 File Offset: 0x00011B00
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
			float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, this.m_self.ID_UnicoString, 1f);
			using (IEnumerator<Desires> enumerator = typeof(Desires).GetEnumValoresLimpiosObject().Cast<Desires>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Desires desires = enumerator.Current;
					BuffMap buffMap;
					BuffOnDeseoGainAndMaxValueArg buffOnDeseoGainAndMaxValueArg;
					BuffAndDebuffGeneratorHelper.GenerarBuffMap<BuffOnDeseoGainAndMaxValueArg>("Tvalle.Buff.DesiresGainMaxModByFatigue", out buffMap, out buffOnDeseoGainAndMaxValueArg);
					buffOnDeseoGainAndMaxValueArg.des = desires;
					buffOnDeseoGainAndMaxValueArg.mod = Mathf.Lerp(1f, 0.2f, applyableFatigueMod);
					BuffAndDebuffGeneratorHelper.AddNoStackBuff<BuffOnDeseoGainAndMaxValueArg>(this.m_BuffDeCharacter, buffMap, desires.ToString() + "GainMaxByFatigue", buffOnDeseoGainAndMaxValueArg, new BuffMap.Duracion
					{
						hours = 3
					});
				}
				yield break;
			}
			yield break;
		}

		// Token: 0x04000310 RID: 784
		private const string buffName = "Tvalle.Buff.DesiresGainMaxModByFatigue";

		// Token: 0x04000311 RID: 785
		private Character m_self;

		// Token: 0x04000312 RID: 786
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
