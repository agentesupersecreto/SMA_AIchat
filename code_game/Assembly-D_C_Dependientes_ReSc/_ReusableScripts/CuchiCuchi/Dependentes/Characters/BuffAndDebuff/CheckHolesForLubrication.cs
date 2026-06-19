using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.BuffAndDebuff
{
	// Token: 0x0200027E RID: 638
	public sealed class CheckHolesForLubrication : AplicableBehaviour
	{
		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x060010C9 RID: 4297 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0004F300 File Offset: 0x0004D500
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
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x000434F1 File Offset: 0x000416F1
		private void M_FemaleSkins_stared(object sender)
		{
			base.ManualStart();
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0004F3A0 File Offset: 0x0004D5A0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_SemenParaAnus = this.GetComponentEnRoot(false);
			this.m_SemenParaVag = this.GetComponentEnRoot(false);
			if (this.m_SemenParaVag == null)
			{
				throw new ArgumentNullException("m_SemenParaVag", "m_SemenParaVag null reference.");
			}
			if (this.m_SemenParaAnus == null)
			{
				throw new ArgumentNullException("m_SemenParaAnus", "m_SemenParaAnus null reference.");
			}
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0004F40C File Offset: 0x0004D60C
		public override void OnUpdateEvent1()
		{
			if (this.m_updateCoolDown.isOn)
			{
				return;
			}
			this.m_updateCoolDown.ApplyNext(2f.Random(0.5f));
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaVag, this.m_BuffDeCharacter, SensitiveBodyPart.vag, this);
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaVag, this.m_BuffDeCharacter, SensitiveBodyPart.vagWalls, this);
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaVag, this.m_BuffDeCharacter, SensitiveBodyPart.vagBottom, this);
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaAnus, this.m_BuffDeCharacter, SensitiveBodyPart.anus, this);
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaAnus, this.m_BuffDeCharacter, SensitiveBodyPart.anusWalls, this);
			CheckHolesForLubrication.UpdateLubricacion(this.m_SemenParaAnus, this.m_BuffDeCharacter, SensitiveBodyPart.anusBottom, this);
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0004F4BC File Offset: 0x0004D6BC
		private static void UpdateLubricacion(SemenParaHole semenInHole, BuffDeCharacter m_BuffDeCharacter, SensitiveBodyPart hole, CheckHolesForLubrication context)
		{
			CheckHolesForLubrication.<>c__DisplayClass11_0 CS$<>8__locals1 = new CheckHolesForLubrication.<>c__DisplayClass11_0();
			CS$<>8__locals1.hole = hole;
			float num;
			float num2;
			semenInHole.MililitrosAcumulados(TipoDeSemen.lubricante, out num, out num2);
			CS$<>8__locals1.lubeForPeasureReductionW = Mathf.Clamp01(num2);
			CS$<>8__locals1.lubricationW = Mathf.Clamp01(num2);
			CS$<>8__locals1.forceShowMsg = false;
			if (CS$<>8__locals1.lubricationW <= 0f)
			{
				BuffAndDebuffGeneratorHelper.RemoveBuffImmediately(m_BuffDeCharacter, "Tvalle.Buff.NoNaturalLubricationInPart", context, CS$<>8__locals1.hole.ToString() + ".Hole");
				return;
			}
			BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<DisplayableBuff, BuffOnPartePorLubricacionArg>(m_BuffDeCharacter, "Tvalle.Buff.NoNaturalLubricationInPart", context, new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<BuffOnPartePorLubricacionArg>(CS$<>8__locals1.<UpdateLubricacion>g__UpdateArgumentDataHandler|0), new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<DisplayableBuff>(CS$<>8__locals1.<UpdateLubricacion>g__UpdateBuffConfigHandler|1), CS$<>8__locals1.hole.ToString() + ".Hole", null);
		}

		// Token: 0x04000C48 RID: 3144
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04000C49 RID: 3145
		private SemenParaAnus m_SemenParaAnus;

		// Token: 0x04000C4A RID: 3146
		private SemenParaVag m_SemenParaVag;

		// Token: 0x04000C4B RID: 3147
		private BuffDeCharacter m_BuffDeCharacter;

		// Token: 0x04000C4C RID: 3148
		private CoolDown m_updateCoolDown = new CoolDown();
	}
}
