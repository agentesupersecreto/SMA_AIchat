using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Modificadores
{
	// Token: 0x020004ED RID: 1261
	public sealed class ModificadorDeValorSegunSaturacionDeOxigeno : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06001D7F RID: 7551 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x00072634 File Offset: 0x00070834
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ICharacterRespirador = this.GetComponentEnRoot(false);
			if (this.m_ICharacterRespirador == null)
			{
				throw new ArgumentNullException("m_ICharacterRespirador", "m_ICharacterRespirador null reference.");
			}
			this.m_emocion = base.GetComponentInParent<Emocion>();
			if (this.m_emocion == null)
			{
				throw new ArgumentNullException("m_emocion", "m_emocion null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0007269C File Offset: 0x0007089C
		protected override IEnumerator YieldStartUnityEvent()
		{
			for (;;)
			{
				Emocion emocion = this.m_emocion;
				bool flag;
				if (emocion == null)
				{
					flag = null != null;
				}
				else
				{
					EmocionesHumanasBase owner = emocion.owner;
					flag = ((owner != null) ? owner.owner : null) != null;
				}
				if (flag)
				{
					break;
				}
				yield return null;
			}
			ICharacter ch = this.m_emocion.owner.owner;
			while (!ch.isStared && !ch.loaded)
			{
				yield return null;
			}
			ICharacterIdentificable asBindable = this.m_emocion.owner.owner as ICharacterIdentificable;
			while (!asBindable.isBinded)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x000726AB File Offset: 0x000708AB
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_mod = this.m_emocion.sumadorDeValor.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x000726CA File Offset: 0x000708CA
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat mod = this.m_mod;
			if (mod != null)
			{
				mod.TryRemoverDeOwner(true);
			}
			this.m_mod = null;
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x000726F0 File Offset: 0x000708F0
		public override void OnUpdateEvent1()
		{
			float num = 1f - this.m_currentFatigue;
			if (this.config.affectedByFatigue)
			{
				if (!this.m_updateFatigueCooldDown.isOn)
				{
					if (this.m_emocion.owner.owner is ICharacterUnico)
					{
						this.m_currentFatigue = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, ((ICharacterUnico)this.m_emocion.owner.owner).ID_UnicoString, 0.5f);
					}
					this.m_updateFatigueCooldDown.ApplyNext(10f);
				}
				num = 1f - this.m_currentFatigue;
			}
			else
			{
				num = 1f;
			}
			float num2 = this.config.valorAlZeroDeSaturacion * num;
			float num3 = this.m_ICharacterRespirador.saturacionDeOxigenoWeigth.OutPow(this.config.outPower);
			this.m_mod.valor.valor = Mathf.Lerp(num2, this.config.valorAl100DeSaturacion, num3);
		}

		// Token: 0x04001430 RID: 5168
		public ModificadorDeValorSegunSaturacionDeOxigeno.Config config = new ModificadorDeValorSegunSaturacionDeOxigeno.Config();

		// Token: 0x04001431 RID: 5169
		private ICharacterRespirador m_ICharacterRespirador;

		// Token: 0x04001432 RID: 5170
		private Emocion m_emocion;

		// Token: 0x04001433 RID: 5171
		[SerializeReference]
		private ModificadorDeFloat m_mod;

		// Token: 0x04001434 RID: 5172
		[SerializeField]
		private float m_currentFatigue;

		// Token: 0x04001435 RID: 5173
		private CoolDown m_updateFatigueCooldDown = new CoolDown();

		// Token: 0x020004EE RID: 1262
		[Serializable]
		public class Config
		{
			// Token: 0x04001436 RID: 5174
			public bool affectedByFatigue = true;

			// Token: 0x04001437 RID: 5175
			public float valorAlZeroDeSaturacion = 100f;

			// Token: 0x04001438 RID: 5176
			public float valorAl100DeSaturacion;

			// Token: 0x04001439 RID: 5177
			public float outPower = 3f;
		}
	}
}
