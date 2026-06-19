using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x0200041D RID: 1053
	public sealed class Placer : PlacerBase
	{
		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x0005ED2E File Offset: 0x0005CF2E
		public EmocionesFemeninas femaleOwner
		{
			get
			{
				return (EmocionesFemeninas)base.owner;
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x0005ED3B File Offset: 0x0005CF3B
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.placerGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x0005ED48 File Offset: 0x0005CF48
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x0005D06B File Offset: 0x0005B26B
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0005ED50 File Offset: 0x0005CF50
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			aumento *= Singleton<ConfiguracionGeneral>.instance.femaleGamePlay.placerMod;
			aumentoCrudo = aumento;
			float num = base.value.mod;
			num = Mathf.Clamp01(num);
			if (aumento == 0f)
			{
				if (base.value.total < 100f)
				{
					base.DisminuirPorSegundo(ref aumento, this.maxDisminutionPerSeg * 0.001f, this.maxDisminutionPerSeg, num.InPow(2f));
					return;
				}
			}
			else
			{
				aumento *= Mathf.Lerp(1f, this.disminutionReturnsV3, num);
			}
		}

		// Token: 0x04001200 RID: 4608
		public float maxDisminutionPerSeg = 0.05f;

		// Token: 0x04001201 RID: 4609
		public float disminutionReturnsV3 = 0.025f;
	}
}
