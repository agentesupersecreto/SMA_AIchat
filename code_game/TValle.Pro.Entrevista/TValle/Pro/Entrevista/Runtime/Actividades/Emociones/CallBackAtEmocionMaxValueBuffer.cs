using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Emociones
{
	// Token: 0x02000140 RID: 320
	public abstract class CallBackAtEmocionMaxValueBuffer<TEmocion> : CustomMonobehaviour, IBufferDeMaxValueListiner where TEmocion : Emocion
	{
		// Token: 0x06000B36 RID: 2870 RVA: 0x0003A7EC File Offset: 0x000389EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_buffer = this.GetComponentEnRoot(false);
			if (this.m_buffer == null)
			{
				throw new ArgumentNullException("m_buffer", "m_buffer null reference. emo: " + typeof(TEmocion).Name + " char: " + this.m_character.name);
			}
			this.m_reductor = this.m_buffer.GetComponentInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
			if (this.m_reductor == null)
			{
				throw new ArgumentNullException("m_reductor", "m_reductor null reference.");
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0003A8A7 File Offset: 0x00038AA7
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_buffer.Add(this);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0003A8BB File Offset: 0x00038ABB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_buffer != null)
			{
				this.m_buffer.Remove(this);
			}
			this.Clear();
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0003A8E4 File Offset: 0x00038AE4
		private void Clear()
		{
			ModificadorDeBool puedeReducirValor = this.m_puedeReducirValor;
			if (puedeReducirValor != null)
			{
				puedeReducirValor.TryRemoverDeOwner(true);
			}
			this.m_puedeReducirValor = null;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0003A900 File Offset: 0x00038B00
		void IBufferDeMaxValueListiner.OnEnqueue()
		{
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0003A904 File Offset: 0x00038B04
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
			if (Singleton<ActividadesManager>.instance.OnEmotionMaxValueBuffer(this.m_character, this.m_buffer.emocion))
			{
				this.Clear();
				return true;
			}
			this.m_puedeReducirValor.valor.valor = false;
			return false;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0003A97F File Offset: 0x00038B7F
		string IBufferDeMaxValueListiner.get_name()
		{
			return base.name;
		}

		// Token: 0x04000578 RID: 1400
		private BufferDeMaxEmocion<TEmocion> m_buffer;

		// Token: 0x04000579 RID: 1401
		private ReductorDeEmocionValueEnMaxEmocionValue m_reductor;

		// Token: 0x0400057A RID: 1402
		private ModificadorDeBool m_puedeReducirValor;

		// Token: 0x0400057B RID: 1403
		private Character m_character;
	}
}
