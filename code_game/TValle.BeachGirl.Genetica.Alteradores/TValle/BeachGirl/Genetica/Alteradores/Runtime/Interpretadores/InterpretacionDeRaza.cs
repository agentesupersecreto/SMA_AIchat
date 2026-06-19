using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003E RID: 62
	[Serializable]
	public struct InterpretacionDeRaza
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00008039 File Offset: 0x00006239
		// (set) Token: 0x060002AA RID: 682 RVA: 0x00008041 File Offset: 0x00006241
		[LabelLocalizado("African Descent", "US")]
		public Interpretacion.CantidadNoContable african
		{
			get
			{
				return this.m_african;
			}
			set
			{
				this.m_african = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000804A File Offset: 0x0000624A
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00008052 File Offset: 0x00006252
		[LabelLocalizado("Nordic Descent", "US")]
		public Interpretacion.CantidadNoContable nordic
		{
			get
			{
				return this.m_nordic;
			}
			set
			{
				this.m_nordic = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0000805B File Offset: 0x0000625B
		// (set) Token: 0x060002AE RID: 686 RVA: 0x00008063 File Offset: 0x00006263
		[LabelLocalizado("Asian Descent", "US")]
		public Interpretacion.CantidadNoContable asian
		{
			get
			{
				return this.m_asian;
			}
			set
			{
				this.m_asian = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000806C File Offset: 0x0000626C
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x00008074 File Offset: 0x00006274
		[LabelLocalizado("Hispanic Descent", "US")]
		public Interpretacion.CantidadNoContable hispanic
		{
			get
			{
				return this.m_hispanic;
			}
			set
			{
				this.m_hispanic = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000807D File Offset: 0x0000627D
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00008085 File Offset: 0x00006285
		[LabelLocalizado("Elvish Descent", "US")]
		public Interpretacion.CantidadNoContable elf
		{
			get
			{
				return this.m_elf;
			}
			set
			{
				this.m_elf = value;
			}
		}

		// Token: 0x04000104 RID: 260
		[SerializeField]
		private Interpretacion.CantidadNoContable m_african;

		// Token: 0x04000105 RID: 261
		[SerializeField]
		private Interpretacion.CantidadNoContable m_nordic;

		// Token: 0x04000106 RID: 262
		[SerializeField]
		private Interpretacion.CantidadNoContable m_asian;

		// Token: 0x04000107 RID: 263
		[SerializeField]
		private Interpretacion.CantidadNoContable m_hispanic;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		private Interpretacion.CantidadNoContable m_elf;
	}
}
