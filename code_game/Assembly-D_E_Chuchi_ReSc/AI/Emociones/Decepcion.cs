using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000408 RID: 1032
	public sealed class Decepcion : Emocion
	{
		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06001691 RID: 5777 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06001692 RID: 5778 RVA: 0x0005D0F7 File Offset: 0x0005B2F7
		public override float prioridad
		{
			get
			{
				return 0.666f;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06001693 RID: 5779 RVA: 0x0005D0FE File Offset: 0x0005B2FE
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.decepcion;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06001694 RID: 5780 RVA: 0x0005D105 File Offset: 0x0005B305
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.decepcionGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x06001696 RID: 5782 RVA: 0x0005D112 File Offset: 0x0005B312
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Arousal = base.owner.ObtenerEmocion(ReaccionHumana.arousal) as Arousal;
		}

		// Token: 0x06001697 RID: 5783 RVA: 0x0005D134 File Offset: 0x0005B334
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			float mod = base.owner.placer.value.mod;
			float mod2 = this.m_Arousal.value.mod;
			float num = mod * 0.25f + mod2;
			num = Mathf.Clamp01(num);
			aumento *= Singleton<ConfiguracionGeneral>.instance.femaleGamePlay.decepcionMod;
			aumentoCrudo = aumento;
			if (aumento == 0f)
			{
				if (base.value.total < 100f)
				{
					base.DisminuirPorSegundo(ref aumento, this.maxDisminutionPerSeg * 0.1f, this.maxDisminutionPerSeg, num);
					return;
				}
			}
			else
			{
				aumento *= Mathf.Lerp(1f, 0.333f, num);
			}
		}

		// Token: 0x040011B9 RID: 4537
		public float maxDisminutionPerSeg;

		// Token: 0x040011BA RID: 4538
		private Arousal m_Arousal;
	}
}
