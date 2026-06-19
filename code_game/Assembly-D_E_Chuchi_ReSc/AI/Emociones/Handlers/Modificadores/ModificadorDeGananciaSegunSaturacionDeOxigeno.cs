using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Modificadores
{
	// Token: 0x020004EB RID: 1259
	public sealed class ModificadorDeGananciaSegunSaturacionDeOxigeno : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06001D78 RID: 7544 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x00072504 File Offset: 0x00070704
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
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x00072566 File Offset: 0x00070766
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_mod = this.m_emocion.multiplicadorDeAumento.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x00072585 File Offset: 0x00070785
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

		// Token: 0x06001D7C RID: 7548 RVA: 0x000725A8 File Offset: 0x000707A8
		public override void OnUpdateEvent1()
		{
			float num = 1f - this.m_ICharacterRespirador.ahogadoWeight.OutPow(this.config.outPowerV2);
			this.m_mod.valor.valor = Mathf.Lerp(this.config.gananciaMinima, this.config.gananciaMaxima, num);
		}

		// Token: 0x04001429 RID: 5161
		public ModificadorDeGananciaSegunSaturacionDeOxigeno.Config config = new ModificadorDeGananciaSegunSaturacionDeOxigeno.Config();

		// Token: 0x0400142A RID: 5162
		private ICharacterRespirador m_ICharacterRespirador;

		// Token: 0x0400142B RID: 5163
		private Emocion m_emocion;

		// Token: 0x0400142C RID: 5164
		[SerializeReference]
		private ModificadorDeFloat m_mod;

		// Token: 0x020004EC RID: 1260
		[Serializable]
		public class Config
		{
			// Token: 0x0400142D RID: 5165
			public float gananciaMinima;

			// Token: 0x0400142E RID: 5166
			public float gananciaMaxima = 1f;

			// Token: 0x0400142F RID: 5167
			public float outPowerV2 = 1f;
		}
	}
}
