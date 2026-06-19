using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts
{
	// Token: 0x02000068 RID: 104
	public abstract class StartConversacionPorBufferOnMax : StartConversacionPorEmocionBase, IBufferDeMaxValueListiner
	{
		// Token: 0x06000315 RID: 789 RVA: 0x000103E7 File Offset: 0x0000E5E7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_buffer = this.InitBuffer();
			if (this.m_buffer == null)
			{
				throw new ArgumentNullException("m_buffer", "m_buffer null reference.");
			}
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00010413 File Offset: 0x0000E613
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_buffer.Add(this);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00010427 File Offset: 0x0000E627
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_buffer != null)
			{
				this.m_buffer.Remove(this);
			}
		}

		// Token: 0x06000318 RID: 792
		protected abstract BufferDeMaxValue InitBuffer();

		// Token: 0x06000319 RID: 793 RVA: 0x00010444 File Offset: 0x0000E644
		void IBufferDeMaxValueListiner.OnEnqueue()
		{
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00010448 File Offset: 0x0000E648
		bool IBufferDeMaxValueListiner.OnMaxValue()
		{
			if (!base.isActiveAndEnabled)
			{
				return true;
			}
			ICharacterConversador characterPuedeConversar = this.m_CharacterPuedeConversar;
			bool flag = ((characterPuedeConversar != null) ? new bool?(characterPuedeConversar.puedeConversar) : null).GetValueOrDefault(true) && !base.conversando;
			if (flag)
			{
				base.StartConversacion();
			}
			return flag;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000104A6 File Offset: 0x0000E6A6
		string IBufferDeMaxValueListiner.get_name()
		{
			return base.name;
		}

		// Token: 0x04000146 RID: 326
		[NonSerialized]
		private BufferDeMaxValue m_buffer;
	}
}
