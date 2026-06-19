using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers
{
	// Token: 0x0200053A RID: 1338
	[RequireComponent(typeof(Emocion))]
	public abstract class BufferDeMaxEmocion : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x060020FE RID: 8446 RVA: 0x0007B45F File Offset: 0x0007965F
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.m_updateEvent);
			}
		}

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x060020FF RID: 8447 RVA: 0x0007B46C File Offset: 0x0007966C
		public Emocion baseEmocion
		{
			get
			{
				return this.m_baseEmocion;
			}
		}

		// Token: 0x06002100 RID: 8448 RVA: 0x0007B474 File Offset: 0x00079674
		public void Add(IBufferDeMaxValueListiner listiner)
		{
			this.m_BufferDeMaxValue.Add(listiner);
		}

		// Token: 0x06002101 RID: 8449 RVA: 0x0007B482 File Offset: 0x00079682
		public void Remove(IBufferDeMaxValueListiner listiner)
		{
			this.m_BufferDeMaxValue.Remove(listiner);
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x0007B490 File Offset: 0x00079690
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_baseEmocion = base.GetComponent<Emocion>();
			if (this.m_baseEmocion == null)
			{
				throw new ArgumentNullException("m_emocion", "m_emocion null reference.");
			}
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x0007B4C2 File Offset: 0x000796C2
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_baseEmocion.onMaxValue += this.M_emocion_onMaxValue;
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x0007B4E1 File Offset: 0x000796E1
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_baseEmocion != null)
			{
				this.m_baseEmocion.onMaxValue -= this.M_emocion_onMaxValue;
			}
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x0007B50F File Offset: 0x0007970F
		private void M_emocion_onMaxValue(Emocion obj)
		{
			this.m_BufferDeMaxValue.OnMaxValue();
		}

		// Token: 0x06002106 RID: 8454 RVA: 0x0007B51C File Offset: 0x0007971C
		public override void OnUpdateEvent1()
		{
			this.m_BufferDeMaxValue.DoUpdate();
		}

		// Token: 0x04001573 RID: 5491
		[SerializeField]
		private GlobalUpdater.UpdateType m_updateEvent = GlobalUpdater.UpdateType.onAI4;

		// Token: 0x04001574 RID: 5492
		private Emocion m_baseEmocion;

		// Token: 0x04001575 RID: 5493
		[SerializeField]
		private BufferDeMaxValue m_BufferDeMaxValue = new BufferDeMaxValue();
	}
}
