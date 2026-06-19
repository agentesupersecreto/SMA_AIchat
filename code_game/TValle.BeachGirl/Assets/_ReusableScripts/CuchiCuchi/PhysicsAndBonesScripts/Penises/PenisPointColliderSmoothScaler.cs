using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises
{
	// Token: 0x0200010A RID: 266
	[RequireComponent(typeof(PenisPointCollider))]
	public class PenisPointColliderSmoothScaler : ColliderSmoothScaler
	{
		// Token: 0x06000BB4 RID: 2996 RVA: 0x000270DB File Offset: 0x000252DB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PenisPointCollider = base.GetComponent<PenisPointCollider>();
			if (this.m_PenisPointCollider == null)
			{
				throw new ArgumentNullException("m_PenisPointCollider", "m_PenisPointCollider null reference.");
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0002710D File Offset: 0x0002530D
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_modDeAncho = this.m_PenisPointCollider.modificableDeAncho.ObtenerModificadorNotNull(this);
			this.m_modDeAlto = this.m_PenisPointCollider.modificableDeAlto.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00027143 File Offset: 0x00025343
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_currentAltoInfluenciaWeight = 0f;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00027158 File Offset: 0x00025358
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_modDeAncho != null)
			{
				this.m_modDeAncho.valor.valor = 1f;
			}
			if (this.m_modDeAlto != null)
			{
				this.m_modDeAlto.valor.valor = 1f;
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x000271A6 File Offset: 0x000253A6
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat modDeAncho = this.m_modDeAncho;
			if (modDeAncho != null)
			{
				modDeAncho.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modDeAlto = this.m_modDeAlto;
			if (modDeAlto == null)
			{
				return;
			}
			modDeAlto.TryRemoverDeOwner(true);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x000271D4 File Offset: 0x000253D4
		protected override void CurrentScaleCalculed()
		{
			if (this.m_currentAltoInfluenciaWeight != this.flagAltoInfluenciaWeight)
			{
				if (this.flagToDecrease)
				{
					this.m_currentAltoInfluenciaWeight = Mathf.MoveTowards(this.m_currentAltoInfluenciaWeight, this.flagAltoInfluenciaWeight, base.reducionPorFU);
				}
				else
				{
					this.m_currentAltoInfluenciaWeight = Mathf.MoveTowards(this.m_currentAltoInfluenciaWeight, this.flagAltoInfluenciaWeight, base.aumentoPorFU);
				}
				this.AltoInfluenciaChanged = true;
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0002723C File Offset: 0x0002543C
		protected override void ActualizarScala(bool scaleChanged)
		{
			if (!scaleChanged && !this.AltoInfluenciaChanged)
			{
				return;
			}
			if (this.scaleRadius)
			{
				this.m_modDeAncho.valor.valor = this.currentScale;
			}
			else if (this.m_modDeAncho.valor.valor != 1f)
			{
				this.m_modDeAncho.valor.valor = 1f;
			}
			if (this.scaleAltura)
			{
				this.m_modDeAlto.valor.valor = Mathf.Lerp(1f, this.currentScale, this.m_currentAltoInfluenciaWeight);
			}
			else if (this.m_modDeAlto.valor.valor != 1f)
			{
				this.m_modDeAlto.valor.valor = 1f;
			}
			this.AltoInfluenciaChanged = false;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00027304 File Offset: 0x00025504
		protected override void ResertFlags()
		{
			this.flagAltoInfluenciaWeight = 0f;
		}

		// Token: 0x04000645 RID: 1605
		private PenisPointCollider m_PenisPointCollider;

		// Token: 0x04000646 RID: 1606
		public bool scaleRadius = true;

		// Token: 0x04000647 RID: 1607
		public bool scaleAltura = true;

		// Token: 0x04000648 RID: 1608
		[Range(0f, 1f)]
		public float flagAltoInfluenciaWeight;

		// Token: 0x04000649 RID: 1609
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentAltoInfluenciaWeight = 1f;

		// Token: 0x0400064A RID: 1610
		[SerializeField]
		private bool AltoInfluenciaChanged;

		// Token: 0x0400064B RID: 1611
		[SerializeField]
		private ModificadorDeFloat m_modDeAncho;

		// Token: 0x0400064C RID: 1612
		[SerializeField]
		private ModificadorDeFloat m_modDeAlto;
	}
}
