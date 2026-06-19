using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Modificadores
{
	// Token: 0x020004E9 RID: 1257
	public sealed class ModificadorDeGananciaSegunCansamiento : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06001D71 RID: 7537 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x000723D8 File Offset: 0x000705D8
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

		// Token: 0x06001D73 RID: 7539 RVA: 0x0007243A File Offset: 0x0007063A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_mod = this.m_emocion.multiplicadorDeAumento.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x00072459 File Offset: 0x00070659
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

		// Token: 0x06001D75 RID: 7541 RVA: 0x0007247C File Offset: 0x0007067C
		public override void OnUpdateEvent1()
		{
			float num = this.m_ICharacterRespirador.cansamientoWeight.InPow(this.config.outPowerV2);
			this.m_mod.valor.valor = Mathf.Lerp(this.config.gananciaMaxima, this.config.gananciaMinima, num);
		}

		// Token: 0x04001422 RID: 5154
		public ModificadorDeGananciaSegunCansamiento.Config config = new ModificadorDeGananciaSegunCansamiento.Config();

		// Token: 0x04001423 RID: 5155
		private ICharacterRespirador m_ICharacterRespirador;

		// Token: 0x04001424 RID: 5156
		private Emocion m_emocion;

		// Token: 0x04001425 RID: 5157
		[SerializeReference]
		private ModificadorDeFloat m_mod;

		// Token: 0x020004EA RID: 1258
		[Serializable]
		public class Config
		{
			// Token: 0x04001426 RID: 5158
			public float gananciaMinima;

			// Token: 0x04001427 RID: 5159
			public float gananciaMaxima = 1f;

			// Token: 0x04001428 RID: 5160
			public float outPowerV2 = 1f;
		}
	}
}
