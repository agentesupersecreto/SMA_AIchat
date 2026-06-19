using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x0200041E RID: 1054
	public sealed class Rage : Emocion
	{
		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0005EE02 File Offset: 0x0005D002
		public override float prioridad
		{
			get
			{
				return 4f;
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001723 RID: 5923 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.rabia;
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0005EE09 File Offset: 0x0005D009
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.rageGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x0005EE16 File Offset: 0x0005D016
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Arousal = base.owner.ObtenerEmocion(ReaccionHumana.arousal) as Arousal;
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0005EE38 File Offset: 0x0005D038
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			bool reportToProfiler = base.owner.reportToProfiler;
			float mod = base.owner.placer.value.mod;
			float mod2 = this.m_Arousal.value.mod;
			float num = mod * 0.25f + mod2;
			num = Mathf.Clamp01(num);
			aumento *= Singleton<ConfiguracionGeneralDeCheats>.instance.rageGainMod;
			aumentoCrudo = aumento;
			if (aumento == 0f)
			{
				if (base.value.total < 100f)
				{
					base.DisminuirPorSegundo(ref aumento, this.maxDisminutionPerSeg * 0.1f, this.maxDisminutionPerSeg, num);
				}
			}
			else
			{
				aumento *= Mathf.Lerp(1f, 0.5f, num);
			}
			bool reportToProfiler2 = base.owner.reportToProfiler;
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0005EEFB File Offset: 0x0005D0FB
		protected override void IncreaseValueNextUpdatePostMod(ref float amount)
		{
			amount *= Singleton<ConfiguracionGeneralDeCheats>.instance.rageGainMod;
		}

		// Token: 0x04001202 RID: 4610
		public float maxDisminutionPerSeg;

		// Token: 0x04001203 RID: 4611
		private Arousal m_Arousal;
	}
}
