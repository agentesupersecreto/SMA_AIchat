using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers
{
	// Token: 0x0200053E RID: 1342
	public class MaxPlacerBuffer : BufferDeMaxEmocion<PlacerBase>, IOrgasmoBuffer
	{
		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x0600210B RID: 8459 RVA: 0x0007B55C File Offset: 0x0007975C
		public bool enOrgasmo
		{
			get
			{
				return base.emocion.valueAtMax;
			}
		}

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x0600210C RID: 8460 RVA: 0x0007B569 File Offset: 0x00079769
		// (remove) Token: 0x0600210D RID: 8461 RVA: 0x0007B577 File Offset: 0x00079777
		public event Action<object> onOrgasmoTick
		{
			add
			{
				this.m_ReductorDeEmocionValueEnMaxEmocionValue.chekeandoSiPuedeReducir += value;
			}
			remove
			{
				this.m_ReductorDeEmocionValueEnMaxEmocionValue.chekeandoSiPuedeReducir -= value;
			}
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x0007B585 File Offset: 0x00079785
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ReductorDeEmocionValueEnMaxEmocionValue = base.GetComponentInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
			if (this.m_ReductorDeEmocionValueEnMaxEmocionValue == null)
			{
				throw new ArgumentNullException("m_ReductorDeEmocionValueEnMaxEmocionValue", "m_ReductorDeEmocionValueEnMaxEmocionValue null reference.");
			}
		}

		// Token: 0x04001576 RID: 5494
		private ReductorDeEmocionValueEnMaxEmocionValue m_ReductorDeEmocionValueEnMaxEmocionValue;
	}
}
