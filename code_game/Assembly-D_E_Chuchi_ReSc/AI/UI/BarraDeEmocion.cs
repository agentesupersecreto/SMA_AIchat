using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000367 RID: 871
	[RequireComponent(typeof(Image))]
	public class BarraDeEmocion : CharacterUI
	{
		// Token: 0x06001304 RID: 4868 RVA: 0x000523A8 File Offset: 0x000505A8
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

		// Token: 0x06001305 RID: 4869 RVA: 0x000523FB File Offset: 0x000505FB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Image)
			{
				this.m_Image.enabled = false;
			}
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x00052420 File Offset: 0x00050620
		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (this.m_emo == null)
			{
				this.altura = 0f;
				this.m_Image.enabled = false;
				return;
			}
			switch (this.tipo)
			{
			case BarraDeEmocion.TipoDeInfo.valorTotal:
				this.altura = Mathf.Clamp(this.m_emo.value.total, 0f, 100f);
				break;
			case BarraDeEmocion.TipoDeInfo.valorNoLimitado:
				this.altura = Mathf.Clamp(this.m_emo.valorNoLimitado, 0f, 100f);
				break;
			case BarraDeEmocion.TipoDeInfo.limiteMinimo:
				this.altura = Mathf.Clamp(this.m_emo.limiteMinimo1 + this.m_emo.limiteMinimo2, 0f, 100f);
				break;
			case BarraDeEmocion.TipoDeInfo.valorTotalInvertido:
				this.altura = 100f - Mathf.Clamp(this.m_emo.value.total, 0f, 100f);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.tipo.ToString());
			}
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

		// Token: 0x06001307 RID: 4871 RVA: 0x000525AC File Offset: 0x000507AC
		protected override void OnChanged()
		{
			base.OnChanged();
			EmocionesHumanasBase componentInChildren = base.current.GetComponentInChildren<EmocionesHumanasBase>();
			this.m_emo = ((componentInChildren != null) ? componentInChildren.ObtenerEmocion(this.reaccion) : null);
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x000525E4 File Offset: 0x000507E4
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
			this.m_emo = null;
		}

		// Token: 0x04000FD3 RID: 4051
		public float altura = 100f;

		// Token: 0x04000FD4 RID: 4052
		public ReaccionHumana reaccion;

		// Token: 0x04000FD5 RID: 4053
		public BarraDeEmocion.TipoDeInfo tipo;

		// Token: 0x04000FD6 RID: 4054
		protected Emocion m_emo;

		// Token: 0x04000FD7 RID: 4055
		protected Image m_Image;

		// Token: 0x04000FD8 RID: 4056
		private Vector2 m_currentSizeDelta;

		// Token: 0x02000368 RID: 872
		public enum TipoDeInfo
		{
			// Token: 0x04000FDA RID: 4058
			valorTotal,
			// Token: 0x04000FDB RID: 4059
			valorNoLimitado,
			// Token: 0x04000FDC RID: 4060
			limiteMinimo,
			// Token: 0x04000FDD RID: 4061
			valorTotalInvertido
		}
	}
}
