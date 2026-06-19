using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x0200036D RID: 877
	[RequireComponent(typeof(Image))]
	public class ConsentPorPlacerMaxIcon : CharacterUI
	{
		// Token: 0x06001315 RID: 4885 RVA: 0x00052E48 File Offset: 0x00051048
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Image = base.GetComponent<Image>();
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x00052E5C File Offset: 0x0005105C
		protected override void LateUpdate()
		{
			base.LateUpdate();
			ConsentPorInteraciones iconsentPorSessionesChanger = this.m_IConsentPorSessionesChanger;
			bool flag;
			if (!((iconsentPorSessionesChanger != null) ? new bool?(iconsentPorSessionesChanger.alMaximo) : null).GetValueOrDefault())
			{
				ConsentToHero consentToHero = this.m_ConsentToHero;
				flag = ((consentToHero != null) ? new bool?(consentToHero.valueAtMax) : null).GetValueOrDefault();
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			if (this.m_Image.enabled != flag2)
			{
				this.m_Image.enabled = flag2;
			}
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x00052EDD File Offset: 0x000510DD
		protected override void OnCleared()
		{
			base.OnCleared();
			this.m_IConsentPorSessionesChanger = null;
			this.m_ConsentToHero = null;
			this.m_Image.enabled = false;
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x00052EFF File Offset: 0x000510FF
		protected override void OnChanged()
		{
			base.OnChanged();
			this.m_IConsentPorSessionesChanger = base.current.GetComponentInChildren<ConsentPorInteraciones>();
			this.m_ConsentToHero = base.current.GetComponentInChildren<ConsentToHero>();
		}

		// Token: 0x04000FFF RID: 4095
		private Image m_Image;

		// Token: 0x04001000 RID: 4096
		private ConsentPorInteraciones m_IConsentPorSessionesChanger;

		// Token: 0x04001001 RID: 4097
		private ConsentToHero m_ConsentToHero;
	}
}
