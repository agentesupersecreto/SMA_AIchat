using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004B2 RID: 1202
	public abstract class SessionDeEstimulo : CustomUpdatedMonobehaviourBase, IActivable
	{
		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06001CA3 RID: 7331 RVA: 0x00071985 File Offset: 0x0006FB85
		public virtual Emocion emocion
		{
			get
			{
				return this.m_emo;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06001CA4 RID: 7332 RVA: 0x0007198D File Offset: 0x0006FB8D
		public SessionDeEstimulo.Config baseConfig
		{
			get
			{
				return this.m_baseConfig;
			}
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06001CA5 RID: 7333 RVA: 0x0005848D File Offset: 0x0005668D
		// (set) Token: 0x06001CA6 RID: 7334 RVA: 0x00005AAA File Offset: 0x00003CAA
		bool IActivable.activado
		{
			get
			{
				return base.isActiveAndEnabled;
			}
			set
			{
				base.enabled = value;
			}
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00071998 File Offset: 0x0006FB98
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emo = base.GetComponentInParent<Emocion>();
			if (this.m_emo == null)
			{
				throw new ArgumentNullException("m_emo", "m_emo null reference.");
			}
			this.m_emos = this.m_emo.GetComponentInParent<EmocionesFemeninas>();
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x00071A04 File Offset: 0x0006FC04
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.SubscribeToUpdateEmociones();
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x00071A12 File Offset: 0x0006FC12
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnsubscribeToUpdateEmociones();
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x00071A21 File Offset: 0x0006FC21
		protected virtual void SubscribeToUpdateEmociones()
		{
			this.m_emos.updateEmociones1 += this.UpdateEmociones;
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x00071A3A File Offset: 0x0006FC3A
		protected virtual void UnsubscribeToUpdateEmociones()
		{
			if (this.m_emos != null)
			{
				this.m_emos.updateEmociones1 -= this.UpdateEmociones;
			}
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x00071A61 File Offset: 0x0006FC61
		protected void UpdateEmociones(EmocionesFemeninas obj)
		{
			this.OnEmocionesUpdating();
		}

		// Token: 0x06001CAD RID: 7341
		protected abstract void OnEmocionesUpdating();

		// Token: 0x040013F6 RID: 5110
		[SerializeField]
		[ReadOnlyUI]
		private Emocion m_emo;

		// Token: 0x040013F7 RID: 5111
		[SerializeField]
		private SessionDeEstimulo.Config m_baseConfig = new SessionDeEstimulo.Config();

		// Token: 0x040013F8 RID: 5112
		[SerializeField]
		[Range(0f, 1000f)]
		protected double m_prioridad = 1.0;

		// Token: 0x040013F9 RID: 5113
		private EmocionesFemeninas m_emos;

		// Token: 0x020004B3 RID: 1203
		[Serializable]
		public class Config
		{
			// Token: 0x040013FA RID: 5114
			public float maximoTiempoDeDuracion = float.MaxValue;

			// Token: 0x040013FB RID: 5115
			public float tiempoNecesarioParaComenzarSession = 0.75f;

			// Token: 0x040013FC RID: 5116
			public float maximoTiempoDeInactividadParaTerminarSesion = 2.5f;

			// Token: 0x040013FD RID: 5117
			public float tickCoolDown = 0.1f;
		}
	}
}
