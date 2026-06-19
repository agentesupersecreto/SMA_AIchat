using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x02000097 RID: 151
	public class OxigenDemandByFatigue : CustomMonobehaviour
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00013F4C File Offset: 0x0001214C
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

		// Token: 0x0600032A RID: 810 RVA: 0x00013FC4 File Offset: 0x000121C4
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
			float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, this.m_self.ID_UnicoString, 6f);
			BuffMap buffMap;
			BuffOnOxygenGainArg buffOnOxygenGainArg;
			BuffAndDebuffGeneratorHelper.GenerarBuffMap<BuffOnOxygenGainArg>("Tvalle.Buff.OxygenDemandByFatigue", out buffMap, out buffOnOxygenGainArg);
			buffOnOxygenGainArg.gainMod = Mathf.Lerp(1f, 10f, applyableFatigueMod);
			buffOnOxygenGainArg.justForCansamiento = true;
			BuffAndDebuffGeneratorHelper.AddNoStackBuff<BuffOnOxygenGainArg>(this.m_BuffDeCharacter, buffMap, "DemandByFatigue", buffOnOxygenGainArg, new BuffMap.Duracion
			{
				hours = 3
			});
			yield break;
		}

		// Token: 0x04000321 RID: 801
		private const string buffName = "Tvalle.Buff.OxygenDemandByFatigue";

		// Token: 0x04000322 RID: 802
		private Character m_self;

		// Token: 0x04000323 RID: 803
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
