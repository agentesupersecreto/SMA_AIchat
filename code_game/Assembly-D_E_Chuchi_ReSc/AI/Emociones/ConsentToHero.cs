using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000407 RID: 1031
	public sealed class ConsentToHero : Emocion
	{
		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001688 RID: 5768 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06001689 RID: 5769 RVA: 0x0005D053 File Offset: 0x0005B253
		public override float prioridad
		{
			get
			{
				return 100f;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x0600168A RID: 5770 RVA: 0x00005F51 File Offset: 0x00004151
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.concentToHero;
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x0600168B RID: 5771 RVA: 0x0005D0B8 File Offset: 0x0005B2B8
		public override float? minValue
		{
			get
			{
				float num;
				if (MainChar.instance)
				{
					num = MainChar.instance.concentAura;
				}
				else
				{
					num = 0f;
				}
				return new float?(num);
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x0600168C RID: 5772 RVA: 0x0005D0EA File Offset: 0x0005B2EA
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.consentGananciaPorPersonalidad;
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x0600168D RID: 5773 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x0005D06B File Offset: 0x0005B26B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x0005CDD1 File Offset: 0x0005AFD1
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			aumentoCrudo = aumento;
		}
	}
}
