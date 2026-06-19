using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts
{
	// Token: 0x02000067 RID: 103
	public abstract class StartConversacionAtEmocionMaxValue<TEmocion> : StartConversacionPorEmocionBase, IBufferDeMaxValueListiner where TEmocion : Emocion
	{
		// Token: 0x0600030B RID: 779 RVA: 0x00010254 File Offset: 0x0000E454
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_buffer = this.GetComponentEnRoot(false);
			if (this.m_buffer == null)
			{
				throw new ArgumentNullException("m_buffer", "m_buffer null reference.");
			}
			this.m_reductor = this.m_buffer.GetComponentInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
			if (this.m_reductor == null)
			{
				throw new ArgumentNullException("m_reductor", "m_reductor null reference.");
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000102C1 File Offset: 0x0000E4C1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_buffer.Add(this);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000102D5 File Offset: 0x0000E4D5
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_buffer != null)
			{
				this.m_buffer.Remove(this);
			}
			this.Clear();
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000102FE File Offset: 0x0000E4FE
		private void Clear()
		{
			ModificadorDeBool puedeReducirValor = this.m_puedeReducirValor;
			if (puedeReducirValor != null)
			{
				puedeReducirValor.TryRemoverDeOwner(true);
			}
			this.m_puedeReducirValor = null;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001031A File Offset: 0x0000E51A
		void IBufferDeMaxValueListiner.OnEnqueue()
		{
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0001031C File Offset: 0x0000E51C
		bool IBufferDeMaxValueListiner.OnMaxValue()
		{
			if (!base.isActiveAndEnabled)
			{
				this.Clear();
				return true;
			}
			if (this.m_puedeReducirValor == null)
			{
				this.m_puedeReducirValor = this.m_reductor.puedeReducirValue.ObtenerModificadorNotNull(this);
			}
			ICharacterConversador characterPuedeConversar = this.m_CharacterPuedeConversar;
			bool flag = ((characterPuedeConversar != null) ? new bool?(characterPuedeConversar.puedeConversar) : null).GetValueOrDefault(true) && !base.conversando;
			if (flag)
			{
				base.StartConversacion();
				this.Clear();
				return flag;
			}
			this.m_puedeReducirValor.valor.valor = false;
			return flag;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000103AF File Offset: 0x0000E5AF
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Emular Emocion Al Max",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000103C8 File Offset: 0x0000E5C8
		protected override void OnAplicar()
		{
			base.OnAplicar();
			((IBufferDeMaxValueListiner)this).OnMaxValue();
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000103DF File Offset: 0x0000E5DF
		string IBufferDeMaxValueListiner.get_name()
		{
			return base.name;
		}

		// Token: 0x04000143 RID: 323
		private BufferDeMaxEmocion<TEmocion> m_buffer;

		// Token: 0x04000144 RID: 324
		private ReductorDeEmocionValueEnMaxEmocionValue m_reductor;

		// Token: 0x04000145 RID: 325
		private ModificadorDeBool m_puedeReducirValor;
	}
}
