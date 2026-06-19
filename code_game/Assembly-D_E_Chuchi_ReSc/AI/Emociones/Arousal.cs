using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000405 RID: 1029
	public sealed class Arousal : Emocion
	{
		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001679 RID: 5753 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x0600167A RID: 5754 RVA: 0x0005D053 File Offset: 0x0005B253
		public override float prioridad
		{
			get
			{
				return 100f;
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x0600167B RID: 5755 RVA: 0x0005D05A File Offset: 0x0005B25A
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.arousal;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x0600167C RID: 5756 RVA: 0x0005D05E File Offset: 0x0005B25E
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.arousalGananciaPorPersonalidad;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x0600167D RID: 5757 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0005D06B File Offset: 0x0005B26B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x0005D074 File Offset: 0x0005B274
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			if (aumento == 0f && base.value.total < 100f)
			{
				base.DisminuirPorSegundo(ref aumento, this.disminucionPorSegundo);
			}
			aumentoCrudo = aumento;
		}

		// Token: 0x040011B8 RID: 4536
		public float disminucionPorSegundo;
	}
}
