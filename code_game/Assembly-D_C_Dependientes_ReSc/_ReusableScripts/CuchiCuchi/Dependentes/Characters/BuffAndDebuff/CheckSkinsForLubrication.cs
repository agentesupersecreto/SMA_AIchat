using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.BuffAndDebuff
{
	// Token: 0x02000280 RID: 640
	public class CheckSkinsForLubrication : AplicableBehaviour
	{
		// Token: 0x060010D3 RID: 4307 RVA: 0x0004F668 File Offset: 0x0004D868
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_BuffDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			this.m_FemaleSkins = this.GetComponentEnRoot(false);
			if (this.m_FemaleSkins == null)
			{
				throw new ArgumentNullException("m_FemaleSkins", "m_FemaleSkins null reference.");
			}
			if (this.m_FemaleSkins.isStared)
			{
				throw new InvalidOperationException();
			}
			base.SetManualStart();
			this.m_FemaleSkins.stared += this.M_FemaleSkins_stared;
			this.m_updateCoroutine = new CoroutineCapsule(this.UpdateRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x000434F1 File Offset: 0x000416F1
		private void M_FemaleSkins_stared(object sender)
		{
			base.ManualStart();
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0004F72C File Offset: 0x0004D92C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_FemaleSkins.enableHitSkins)
			{
				this.m_skins = this.m_FemaleSkins.hitSkins.hitSkins.Select((HitSkinBasica x) => x.GetComponent<SkinSensibleASemen>()).Distinct<SkinSensibleASemen>().ToArray<SkinSensibleASemen>();
				for (int i = 0; i < this.m_skins.Length; i++)
				{
					this.m_skins[i].onContactoRegistrado += this.CheckSkinsForLubrication_onContactoRegistrado;
				}
			}
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0004F7BC File Offset: 0x0004D9BC
		private void CheckSkinsForLubrication_onContactoRegistrado(SemenHit obj)
		{
			if (obj.tipo != TipoDeSemen.lubricante)
			{
				return;
			}
			CheckSkinsForLubrication.<CheckSkinsForLubrication_onContactoRegistrado>g__CheckGroup|8_0(ParteDelCuerpoHumanoHelper.partesDeTrozoDelanteroSet, ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero, obj.parteImpactada, this.m_lubricationDePartesW);
			CheckSkinsForLubrication.<CheckSkinsForLubrication_onContactoRegistrado>g__CheckGroup|8_0(ParteDelCuerpoHumanoHelper.partesDeInteraccionSenosSet, ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos, obj.parteImpactada, this.m_lubricationDePartesW);
			CheckSkinsForLubrication.<CheckSkinsForLubrication_onContactoRegistrado>g__CheckGroup|8_0(ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet, ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal, obj.parteImpactada, this.m_lubricationDePartesW);
			CheckSkinsForLubrication.<CheckSkinsForLubrication_onContactoRegistrado>g__CheckGroup|8_0(ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet, ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal, obj.parteImpactada, this.m_lubricationDePartesW);
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0004F83F File Offset: 0x0004DA3F
		private IEnumerator UpdateRutine()
		{
			if (!base.isStared)
			{
				yield return null;
			}
			WaitForSeconds w = new WaitForSeconds(2f.Random(0.1f));
			for (;;)
			{
				yield return w;
				if (this.m_FemaleSkins.enableHitSkins)
				{
					Dictionary<int, float> dictionary = new Dictionary<int, float>(this.m_lubricationDePartesW);
					foreach (KeyValuePair<int, float> keyValuePair in dictionary)
					{
						SensitiveBodyPart part = ((ParteDelCuerpoHumano)keyValuePair.Key).GetPart();
						CheckSkinsForLubrication.UpdateLubricacion(keyValuePair.Value, this.m_BuffDeCharacter, part, this);
						yield return null;
					}
					Dictionary<int, float>.Enumerator enumerator = default(Dictionary<int, float>.Enumerator);
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0004F850 File Offset: 0x0004DA50
		private static void UpdateLubricacion(float w, BuffDeCharacter m_BuffDeCharacter, SensitiveBodyPart parte, CheckSkinsForLubrication context)
		{
			CheckSkinsForLubrication.<>c__DisplayClass10_0 CS$<>8__locals1 = new CheckSkinsForLubrication.<>c__DisplayClass10_0();
			CS$<>8__locals1.parte = parte;
			CS$<>8__locals1.disableMsg = !CS$<>8__locals1.parte.CanBePenetrated();
			CS$<>8__locals1.lubricationW = Mathf.Clamp01(w);
			CS$<>8__locals1.forceShowMsg = false;
			if (CS$<>8__locals1.lubricationW <= 0f)
			{
				BuffAndDebuffGeneratorHelper.RemoveBuffImmediately(m_BuffDeCharacter, "Tvalle.Buff.NoNaturalLubricationInPart", context, CS$<>8__locals1.parte.ToString());
				return;
			}
			BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<DisplayableBuff, BuffOnPartePorLubricacionArg>(m_BuffDeCharacter, "Tvalle.Buff.NoNaturalLubricationInPart", context, new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<BuffOnPartePorLubricacionArg>(CS$<>8__locals1.<UpdateLubricacion>g__UpdateArgumentDataHandler|0), new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<DisplayableBuff>(CS$<>8__locals1.<UpdateLubricacion>g__UpdateBuffConfigHandler|1), CS$<>8__locals1.parte.ToString(), null);
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0004F908 File Offset: 0x0004DB08
		[CompilerGenerated]
		internal static void <CheckSkinsForLubrication_onContactoRegistrado>g__CheckGroup|8_0(IReadOnlyCollection<int> set, IReadOnlyList<ParteDelCuerpoHumano> list, ParteDelCuerpoHumano impactada, Dictionary<int, float> result)
		{
			if (set.Contains((int)impactada))
			{
				for (int i = 0; i < list.Count; i++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = list[i];
					float num;
					if (!result.TryGetValue((int)parteDelCuerpoHumano, out num))
					{
						num = 0f;
						result.Add((int)parteDelCuerpoHumano, num);
					}
					num += 0.333f;
					num = Mathf.Clamp01(num);
					result[(int)parteDelCuerpoHumano] = num;
				}
			}
		}

		// Token: 0x04000C51 RID: 3153
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04000C52 RID: 3154
		private BuffDeCharacter m_BuffDeCharacter;

		// Token: 0x04000C53 RID: 3155
		private SkinSensibleASemen[] m_skins;

		// Token: 0x04000C54 RID: 3156
		private Dictionary<int, float> m_lubricationDePartesW = new Dictionary<int, float>();

		// Token: 0x04000C55 RID: 3157
		private CoroutineCapsule m_updateCoroutine;
	}
}
