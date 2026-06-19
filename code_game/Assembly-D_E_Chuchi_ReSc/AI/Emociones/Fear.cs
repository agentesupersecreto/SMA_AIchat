using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000413 RID: 1043
	public sealed class Fear : Emocion
	{
		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x060016EE RID: 5870 RVA: 0x00030684 File Offset: 0x0002E884
		public override float prioridad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x060016EF RID: 5871 RVA: 0x0005E5EA File Offset: 0x0005C7EA
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.miedo;
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x0005E5F1 File Offset: 0x0005C7F1
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.miedoGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x060016F1 RID: 5873 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x0005E5FE File Offset: 0x0005C7FE
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Arousal = base.owner.ObtenerEmocion(ReaccionHumana.arousal) as Arousal;
		}

		// Token: 0x060016F3 RID: 5875 RVA: 0x0005E620 File Offset: 0x0005C820
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			float mod = base.owner.placer.value.mod;
			float mod2 = this.m_Arousal.value.mod;
			float num = mod * 0.25f + mod2;
			num = Mathf.Clamp01(num);
			aumento *= Singleton<ConfiguracionGeneralDeCheats>.instance.fearGainMod;
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
				aumento *= Mathf.Lerp(1f, 0.5f, num);
			}
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x0005E6CA File Offset: 0x0005C8CA
		protected override void IncreaseValueNextUpdatePostMod(ref float amount)
		{
			amount *= Singleton<ConfiguracionGeneralDeCheats>.instance.fearGainMod;
		}

		// Token: 0x040011D6 RID: 4566
		public float maxDisminutionPerSeg = 120f;

		// Token: 0x040011D7 RID: 4567
		private Arousal m_Arousal;
	}
}
