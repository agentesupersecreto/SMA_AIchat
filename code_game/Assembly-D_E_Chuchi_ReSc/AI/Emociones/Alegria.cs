using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000402 RID: 1026
	public sealed class Alegria : Emocion
	{
		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06001664 RID: 5732 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06001665 RID: 5733 RVA: 0x0005CDAF File Offset: 0x0005AFAF
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.alegriaGananciaPorPersonalidad;
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06001666 RID: 5734 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad;
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06001667 RID: 5735 RVA: 0x0002591B File Offset: 0x00023B1B
		public override float prioridad
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06001668 RID: 5736 RVA: 0x0005CDCA File Offset: 0x0005AFCA
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.alegria;
			}
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x0005CDD1 File Offset: 0x0005AFD1
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			aumentoCrudo = aumento;
		}
	}
}
