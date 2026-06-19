using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000406 RID: 1030
	public sealed class Boredom : Emocion
	{
		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06001681 RID: 5761 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06001682 RID: 5762 RVA: 0x00030684 File Offset: 0x0002E884
		public override float prioridad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06001683 RID: 5763 RVA: 0x0005D0B0 File Offset: 0x0005B2B0
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.aburrimiento;
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06001684 RID: 5764 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06001685 RID: 5765 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
		}
	}
}
