using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000362 RID: 866
	public abstract class BarraDeDeseo : CharacterUI
	{
		// Token: 0x060012EF RID: 4847
		protected abstract float GetDeseoValor();

		// Token: 0x060012F0 RID: 4848 RVA: 0x000520E0 File Offset: 0x000502E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Image = base.GetComponent<Image>();
			if (this.m_Image == null)
			{
				throw new ArgumentNullException("m_Image", "m_Image null reference.");
			}
			this.m_currentSizeDelta = this.m_Image.rectTransform.sizeDelta;
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x00052133 File Offset: 0x00050333
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Image)
			{
				this.m_Image.enabled = false;
			}
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00052158 File Offset: 0x00050358
		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (this.m_deseos == null)
			{
				this.altura = 0f;
				this.m_Image.enabled = false;
				return;
			}
			float deseoValor = this.GetDeseoValor();
			float num = MathfExtension.InverseLerpConMedio(-1f, 0f, 1f, deseoValor);
			this.altura = MathfExtension.LerpConMedio(0f, 25f, 50f, num);
			this.m_currentSizeDelta.y = this.altura;
			if (this.m_Image.rectTransform.sizeDelta != this.m_currentSizeDelta)
			{
				this.m_Image.rectTransform.sizeDelta = this.m_currentSizeDelta;
			}
			if (this.altura <= 0f)
			{
				this.m_Image.enabled = false;
				return;
			}
			this.m_Image.enabled = true;
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x00052233 File Offset: 0x00050433
		protected override void OnChanged()
		{
			base.OnChanged();
			this.m_deseos = base.current.GetComponentInChildren<Deseos>();
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x0005224C File Offset: 0x0005044C
		protected override void OnCleared()
		{
			base.OnCleared();
			this.altura = 0f;
			if (this.m_Image.enabled)
			{
				this.m_Image.enabled = false;
			}
			this.m_currentSizeDelta.y = 0f;
			if (this.m_Image.rectTransform.sizeDelta != this.m_currentSizeDelta)
			{
				this.m_Image.rectTransform.sizeDelta = this.m_currentSizeDelta;
			}
			this.m_deseos = null;
		}

		// Token: 0x04000FCC RID: 4044
		public float altura = 50f;

		// Token: 0x04000FCD RID: 4045
		protected Deseos m_deseos;

		// Token: 0x04000FCE RID: 4046
		protected Image m_Image;

		// Token: 0x04000FCF RID: 4047
		private Vector2 m_currentSizeDelta;
	}
}
