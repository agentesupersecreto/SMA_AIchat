using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000412 RID: 1042
	public sealed class Dolor : Emocion
	{
		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x060016E3 RID: 5859 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x060016E4 RID: 5860 RVA: 0x0005E464 File Offset: 0x0005C664
		public override float prioridad
		{
			get
			{
				return 10f;
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x060016E5 RID: 5861 RVA: 0x0004369C File Offset: 0x0004189C
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.dolor;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x060016E6 RID: 5862 RVA: 0x0005E46B File Offset: 0x0005C66B
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.dolorGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x060016E7 RID: 5863 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0005E478 File Offset: 0x0005C678
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Arousal = base.owner.ObtenerEmocion(ReaccionHumana.arousal) as Arousal;
			this.m_alivio = base.owner.ObtenerEmocion(ReaccionHumana.alivio) as Alivio;
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x0005E4B4 File Offset: 0x0005C6B4
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			float mod = base.owner.placer.value.mod;
			float mod2 = this.m_Arousal.value.mod;
			float num = mod * 0.25f + mod2;
			num = Mathf.Clamp01(num);
			aumento *= Singleton<ConfiguracionGeneralDeCheats>.instance.painGainMod;
			aumentoCrudo = aumento;
			if (aumento == 0f)
			{
				if (base.value.total < 100f && this.maxDisminutionPerSeg != 0f)
				{
					base.DisminuirPorSegundo(ref aumento, this.maxDisminutionPerSeg * 0.1f, this.maxDisminutionPerSeg, num);
					return;
				}
			}
			else
			{
				float total = this.m_alivio.value.total;
				float num2 = aumento;
				if (total > 0f && num2 > 0f)
				{
					if (total <= 100f)
					{
						this.m_alivio.ChangeValueNextUpdateModified(-num2);
					}
					if (total < num2)
					{
						aumento -= num2 - total;
						this.ModAumentoSegunPlacerArousal(ref aumento, num);
						return;
					}
					aumento = 0f;
					return;
				}
				else
				{
					this.ModAumentoSegunPlacerArousal(ref aumento, num);
				}
			}
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x0005E5C2 File Offset: 0x0005C7C2
		private void ModAumentoSegunPlacerArousal(ref float aumento, float modPlacerVsArousal)
		{
			aumento *= Mathf.Lerp(1f, 0.25f, modPlacerVsArousal);
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0005E5D9 File Offset: 0x0005C7D9
		protected override void IncreaseValueNextUpdatePostMod(ref float amount)
		{
			amount *= Singleton<ConfiguracionGeneralDeCheats>.instance.painGainMod;
		}

		// Token: 0x040011D3 RID: 4563
		public float maxDisminutionPerSeg;

		// Token: 0x040011D4 RID: 4564
		private Arousal m_Arousal;

		// Token: 0x040011D5 RID: 4565
		private Alivio m_alivio;
	}
}
