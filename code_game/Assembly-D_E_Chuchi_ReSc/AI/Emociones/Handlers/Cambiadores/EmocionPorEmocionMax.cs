using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Buffers;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000533 RID: 1331
	public abstract class EmocionPorEmocionMax : CustomMonobehaviour, IBufferDeMaxValueListiner
	{
		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x060020B9 RID: 8377
		protected abstract Emocion atMax { get; }

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x060020BA RID: 8378
		protected abstract Emocion target { get; }

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x060020BB RID: 8379
		protected abstract float aumentoMod { get; }

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x060020BC RID: 8380
		protected abstract float aumentoTemporalMod { get; }

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x060020BD RID: 8381
		protected abstract float tiempoParaReducirAumentoTemporalAproxMod { get; }

		// Token: 0x060020BE RID: 8382 RVA: 0x0007AB0C File Offset: 0x00078D0C
		protected override void AwakeUnityEvent()
		{
			if (this.target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			base.SetManualStart();
			if (this.target.isStared)
			{
				base.ManualStart();
				return;
			}
			this.target.stared += this.Target_stared;
		}

		// Token: 0x060020BF RID: 8383 RVA: 0x00050244 File Offset: 0x0004E444
		private void Target_stared(object sender)
		{
			base.ManualStart();
		}

		// Token: 0x060020C0 RID: 8384 RVA: 0x0007AB68 File Offset: 0x00078D68
		protected override void StartUnityEvent()
		{
			if (this.atMax == null)
			{
				throw new ArgumentNullException("atMax", "atMax null reference.");
			}
			this.m_buffer = this.atMax.GetComponent<BufferDeMaxEmocion>();
			if (this.m_buffer == null)
			{
				throw new ArgumentNullException("m_buffer", "m_buffer null reference.");
			}
			this.m_buffer.Add(this);
			this.target.beforeUpdate += this.Target_updating;
			this.m_addingValueTemporal = this.target.sumadorDeValor.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x0007ABFC File Offset: 0x00078DFC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			if (this.m_buffer != null)
			{
				this.m_buffer.Remove(this);
			}
			if (this.target != null)
			{
				this.target.beforeUpdate -= this.Target_updating;
			}
			ModificadorDeFloat addingValueTemporal = this.m_addingValueTemporal;
			if (addingValueTemporal == null)
			{
				return;
			}
			addingValueTemporal.TryRemoverDeOwner(true);
		}

		// Token: 0x060020C2 RID: 8386 RVA: 0x0007AC5A File Offset: 0x00078E5A
		private void Target_updating(Emocion obj)
		{
			this.LerpAdding();
			this.LerpTemporalAddingToZero();
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x0007AC68 File Offset: 0x00078E68
		private void LerpAdding()
		{
			if (this.m_addingValue >= this.m_targetAddingValue)
			{
				this.m_addingValue = 0f;
				this.m_targetAddingValue = 0f;
				return;
			}
			float num = Mathf.MoveTowards(this.m_addingValue, this.m_targetAddingValue, Time.deltaTime * this.config.aumentoVelocidad);
			this.target.ChangeValueNextUpdateModified(num - this.m_addingValue);
			this.m_addingValue = num;
		}

		// Token: 0x060020C4 RID: 8388 RVA: 0x0007ACD8 File Offset: 0x00078ED8
		private void LerpTemporalAddingToZero()
		{
			float valor = this.m_addingValueTemporal.valor.valor;
			if (valor == 0f)
			{
				return;
			}
			if (valor < 0f)
			{
				return;
			}
			float num = this.config.tiempoParaReducirAumentoTemporalAprox * this.tiempoParaReducirAumentoTemporalAproxMod;
			num *= 0.19f;
			num = ((num <= 0f) ? 1E-07f : num);
			float num2 = Mathf.InverseLerp(0f, this.m_reduciendoDesde, valor);
			num2 = num2.OutPow(this.config.tiempoParaReducirAumentoTemporalOutPower);
			num2 = Mathf.Lerp(1f, 0.1f, num2);
			this.m_addingValueTemporal.valor.valor = Mathf.MoveTowards(valor, 0f, this.m_reduciendoDesde * num2 * (Time.deltaTime / num));
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete("usar buffer", true)]
		private void AtMax_onMaxValue(Emocion obj)
		{
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x00003B39 File Offset: 0x00001D39
		void IBufferDeMaxValueListiner.OnEnqueue()
		{
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x0007AD9C File Offset: 0x00078F9C
		bool IBufferDeMaxValueListiner.OnMaxValue()
		{
			if (this.m_CoolDown.isOn)
			{
				return false;
			}
			this.m_CoolDown.ApplyNext(this.config.coolDownTime);
			this.m_addingValue = 0f;
			float num = this.config.aumento * this.aumentoMod;
			this.m_targetAddingValue += num;
			float num2 = num * this.config.modAumentoTemporal * this.aumentoTemporalMod;
			this.m_reduciendoDesde = (this.m_addingValueTemporal.valor.valor = num2);
			return true;
		}

		// Token: 0x060020C9 RID: 8393 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string IBufferDeMaxValueListiner.get_name()
		{
			return base.name;
		}

		// Token: 0x04001555 RID: 5461
		public EmocionPorEmocionMax.Config config = new EmocionPorEmocionMax.Config();

		// Token: 0x04001556 RID: 5462
		private CoolDown m_CoolDown = new CoolDown();

		// Token: 0x04001557 RID: 5463
		[ReadOnlyUI]
		[SerializeField]
		private float m_targetAddingValue;

		// Token: 0x04001558 RID: 5464
		[ReadOnlyUI]
		[SerializeField]
		private float m_addingValue;

		// Token: 0x04001559 RID: 5465
		[SerializeField]
		private ModificadorDeFloat m_addingValueTemporal;

		// Token: 0x0400155A RID: 5466
		[SerializeField]
		[ReadOnlyUI]
		private float m_reduciendoDesde;

		// Token: 0x0400155B RID: 5467
		private BufferDeMaxEmocion m_buffer;

		// Token: 0x02000534 RID: 1332
		[Serializable]
		public class Config
		{
			// Token: 0x0400155C RID: 5468
			public float coolDownTime = 1f;

			// Token: 0x0400155D RID: 5469
			public float aumento;

			// Token: 0x0400155E RID: 5470
			public float aumentoVelocidad = 10f;

			// Token: 0x0400155F RID: 5471
			public float modAumentoTemporal = 10f;

			// Token: 0x04001560 RID: 5472
			public float tiempoParaReducirAumentoTemporalAprox = 15f;

			// Token: 0x04001561 RID: 5473
			public float tiempoParaReducirAumentoTemporalOutPower = 3f;
		}
	}
}
