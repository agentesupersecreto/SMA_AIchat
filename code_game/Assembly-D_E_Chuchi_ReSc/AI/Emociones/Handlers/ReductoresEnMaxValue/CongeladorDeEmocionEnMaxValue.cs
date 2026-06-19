using System;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue
{
	// Token: 0x020004E5 RID: 1253
	public class CongeladorDeEmocionEnMaxValue : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06001D55 RID: 7509 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06001D56 RID: 7510 RVA: 0x00071F0B File Offset: 0x0007010B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emocion = base.GetComponentInParent<Emocion>();
			if (this.m_emocion == null)
			{
				throw new ArgumentNullException("m_emocion", "m_emocion null reference.");
			}
			base.enabled = false;
		}

		// Token: 0x06001D57 RID: 7511 RVA: 0x00026EF4 File Offset: 0x000250F4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06001D58 RID: 7512 RVA: 0x00071F44 File Offset: 0x00070144
		public void Freeze()
		{
			this.congelando = true;
			this.m_emocion.activado = false;
			base.enabled = true;
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x00071F60 File Offset: 0x00070160
		public void UnFreeze()
		{
			this.congelando = false;
			this.m_emocion.activado = true;
			base.enabled = false;
		}

		// Token: 0x06001D5A RID: 7514 RVA: 0x00071F7C File Offset: 0x0007017C
		public override void OnUpdateEvent1()
		{
			if (this.congelando)
			{
				this.m_emocion.activado = false;
			}
		}

		// Token: 0x0400140E RID: 5134
		public bool congelando;

		// Token: 0x0400140F RID: 5135
		private Emocion m_emocion;
	}
}
