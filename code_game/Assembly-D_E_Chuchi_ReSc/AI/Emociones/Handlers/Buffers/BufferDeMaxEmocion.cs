using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers
{
	// Token: 0x02000539 RID: 1337
	public abstract class BufferDeMaxEmocion<TEmocion> : BufferDeMaxEmocion where TEmocion : Emocion
	{
		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x060020FB RID: 8443 RVA: 0x0007B418 File Offset: 0x00079618
		public Emocion emocion
		{
			get
			{
				return this.m_emocion;
			}
		}

		// Token: 0x060020FC RID: 8444 RVA: 0x0007B420 File Offset: 0x00079620
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emocion = base.GetComponent<TEmocion>();
			if (this.m_emocion == null)
			{
				throw new ArgumentNullException("m_emocion", "m_emocion null reference.");
			}
		}

		// Token: 0x04001572 RID: 5490
		private Emocion m_emocion;
	}
}
