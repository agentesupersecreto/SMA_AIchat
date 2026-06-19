using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts
{
	// Token: 0x020004E6 RID: 1254
	[RequireComponent(typeof(CongeladorDeEmocionEnMaxValue))]
	public class ReductorDeEmocionValueEnMaxEmocionValue : CustomMonobehaviour, IBufferDeMaxValueListiner
	{
		// Token: 0x1400006C RID: 108
		// (add) Token: 0x06001D5C RID: 7516 RVA: 0x00071F94 File Offset: 0x00070194
		// (remove) Token: 0x06001D5D RID: 7517 RVA: 0x00071FCC File Offset: 0x000701CC
		public event Action<object> chekeandoSiPuedeReducir;

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x06001D5E RID: 7518 RVA: 0x00072004 File Offset: 0x00070204
		// (remove) Token: 0x06001D5F RID: 7519 RVA: 0x0007203C File Offset: 0x0007023C
		public event Action<object> congelandoEmocion;

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06001D60 RID: 7520 RVA: 0x00072071 File Offset: 0x00070271
		public ModificableDeBool puedeReducirValue
		{
			get
			{
				return this.m_puedeReducirValue;
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06001D61 RID: 7521 RVA: 0x00072079 File Offset: 0x00070279
		public ModificableDeFloat congelarPorTiempoModificable
		{
			get
			{
				return this.m_congelarPorTiempoModificable;
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06001D62 RID: 7522 RVA: 0x00072081 File Offset: 0x00070281
		public ModificableDeFloat reducirHastaModificable
		{
			get
			{
				return this.m_reducirHastaModificable;
			}
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x0007208C File Offset: 0x0007028C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emocion = base.GetComponentInParent<Emocion>();
			if (this.m_emocion == null)
			{
				throw new ArgumentNullException("m_emocion", "m_emocion null reference.");
			}
			this.m_congelador = base.GetComponent<CongeladorDeEmocionEnMaxValue>();
			this.m_buffer = base.GetComponentInParent<BufferDeMaxEmocion>();
			if (this.m_buffer == null)
			{
				throw new ArgumentNullException("m_buffer", "m_buffer null reference.");
			}
		}

		// Token: 0x06001D64 RID: 7524 RVA: 0x000720FF File Offset: 0x000702FF
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_buffer.Add(this);
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x00072113 File Offset: 0x00070313
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_buffer != null)
			{
				this.m_buffer.Remove(this);
			}
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x00072138 File Offset: 0x00070338
		void IBufferDeMaxValueListiner.OnEnqueue()
		{
			if (this.m_descongelar.isOn)
			{
				Debug.LogError("ReductorDeEmocionValueEnMaxEmocionValue no es compatible con doble Enqueue", this);
			}
			Action<object> action = this.congelandoEmocion;
			if (action != null)
			{
				action(this);
			}
			this.m_congelador.Freeze();
			this.m_descongelar.ApplyNext(this.m_congelarPorTiempoModificable.ModificarValor(this.congelarPorTiempo.Random(0.1f)));
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x000721A0 File Offset: 0x000703A0
		bool IBufferDeMaxValueListiner.OnMaxValue()
		{
			Action<object> action = this.chekeandoSiPuedeReducir;
			if (action != null)
			{
				action(this);
			}
			bool flag = !this.m_descongelar.isOn && base.enabled;
			if (flag)
			{
				flag = this.m_puedeReducirValue.And(flag);
			}
			if (!flag)
			{
				return false;
			}
			this.m_congelador.UnFreeze();
			float num = this.reducirHasta;
			num = this.m_reducirHastaModificable.ModificarValor(num);
			num = Mathf.Clamp(num, 0f, 99f);
			if (this.m_emocion.value.total >= num)
			{
				this.m_emocion.SetValueNextUpdate(num);
			}
			this.m_emocion.flagToOnMaxValue = true;
			return true;
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string IBufferDeMaxValueListiner.get_name()
		{
			return base.name;
		}

		// Token: 0x04001412 RID: 5138
		public float congelarPorTiempo = 5f;

		// Token: 0x04001413 RID: 5139
		public float reducirHasta = 50f;

		// Token: 0x04001414 RID: 5140
		[SerializeField]
		private ModificableDeBool m_puedeReducirValue = new ModificableDeBool(true);

		// Token: 0x04001415 RID: 5141
		[SerializeField]
		private ModificableDeFloat m_congelarPorTiempoModificable = new ModificableDeFloat(1f);

		// Token: 0x04001416 RID: 5142
		[SerializeField]
		private ModificableDeFloat m_reducirHastaModificable = new ModificableDeFloat(1f);

		// Token: 0x04001417 RID: 5143
		private Emocion m_emocion;

		// Token: 0x04001418 RID: 5144
		private CongeladorDeEmocionEnMaxValue m_congelador;

		// Token: 0x04001419 RID: 5145
		private BufferDeMaxEmocion m_buffer;

		// Token: 0x0400141A RID: 5146
		private CoolDown m_descongelar = new CoolDown();
	}
}
