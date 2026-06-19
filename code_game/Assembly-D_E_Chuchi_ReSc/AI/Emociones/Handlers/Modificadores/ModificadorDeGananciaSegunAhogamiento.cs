using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Modificadores
{
	// Token: 0x020004E7 RID: 1255
	public sealed class ModificadorDeGananciaSegunAhogamiento : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06001D6A RID: 7530 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x000722AC File Offset: 0x000704AC
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

		// Token: 0x06001D6C RID: 7532 RVA: 0x0007230E File Offset: 0x0007050E
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_mod = this.m_emocion.multiplicadorDeAumento.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x0007232D File Offset: 0x0007052D
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

		// Token: 0x06001D6E RID: 7534 RVA: 0x00072350 File Offset: 0x00070550
		public override void OnUpdateEvent1()
		{
			float num = this.m_ICharacterRespirador.ahogadoWeight.InPow(this.config.outPowerV2);
			this.m_mod.valor.valor = Mathf.Lerp(this.config.gananciaMaxima, this.config.gananciaMinima, num);
		}

		// Token: 0x0400141B RID: 5147
		public ModificadorDeGananciaSegunAhogamiento.Config config = new ModificadorDeGananciaSegunAhogamiento.Config();

		// Token: 0x0400141C RID: 5148
		private ICharacterRespirador m_ICharacterRespirador;

		// Token: 0x0400141D RID: 5149
		private Emocion m_emocion;

		// Token: 0x0400141E RID: 5150
		[SerializeReference]
		private ModificadorDeFloat m_mod;

		// Token: 0x020004E8 RID: 1256
		[Serializable]
		public class Config
		{
			// Token: 0x0400141F RID: 5151
			public float gananciaMinima;

			// Token: 0x04001420 RID: 5152
			public float gananciaMaxima = 1f;

			// Token: 0x04001421 RID: 5153
			public float outPowerV2 = 1f;
		}
	}
}
