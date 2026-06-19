using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000033 RID: 51
	[AplicaAConjuntoDeFisico(para = "face")]
	[Serializable]
	public struct InterpretacionDeCheeks
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00007599 File Offset: 0x00005799
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000075A1 File Offset: 0x000057A1
		[LabelLocalizado("Cheek Bone Size", "US")]
		public Interpretacion.Size cheekBonesSize
		{
			get
			{
				return this.m_cheekBonesSize;
			}
			set
			{
				this.m_cheekBonesSize = value;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000075AA File Offset: 0x000057AA
		// (set) Token: 0x0600016C RID: 364 RVA: 0x000075B2 File Offset: 0x000057B2
		[LabelLocalizado("Cheek Bone Height", "US")]
		public Interpretacion.Capacidad cheekBonesHeight
		{
			get
			{
				return this.m_cheekBonesHeight;
			}
			set
			{
				this.m_cheekBonesHeight = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600016D RID: 365 RVA: 0x000075BB File Offset: 0x000057BB
		// (set) Token: 0x0600016E RID: 366 RVA: 0x000075C3 File Offset: 0x000057C3
		[AplicaAConjuntoDeFisico(para = "face", weigth = 2)]
		[LabelLocalizado("Cheeks Fat", "US")]
		public Interpretacion.CantidadNoContable fat
		{
			get
			{
				return this.m_cheesFat;
			}
			set
			{
				this.m_cheesFat = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000075CC File Offset: 0x000057CC
		// (set) Token: 0x06000170 RID: 368 RVA: 0x000075D4 File Offset: 0x000057D4
		[AplicaAConjuntoDeFisico(para = "face", weigth = 2)]
		[LabelLocalizado("Hollow Cheeks", "US")]
		public Interpretacion.Capacidad sink
		{
			get
			{
				return this.m_cheeksSink;
			}
			set
			{
				this.m_cheeksSink = value;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000171 RID: 369 RVA: 0x000075DD File Offset: 0x000057DD
		// (set) Token: 0x06000172 RID: 370 RVA: 0x000075E5 File Offset: 0x000057E5
		public int cheekBonesSizeValor
		{
			get
			{
				return (int)this.m_cheekBonesSize;
			}
			set
			{
				this.m_cheekBonesSize = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000173 RID: 371 RVA: 0x000075EE File Offset: 0x000057EE
		// (set) Token: 0x06000174 RID: 372 RVA: 0x000075F6 File Offset: 0x000057F6
		public int cheekBonesHeightValor
		{
			get
			{
				return (int)this.m_cheekBonesHeight;
			}
			set
			{
				this.m_cheekBonesHeight = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000175 RID: 373 RVA: 0x000075FF File Offset: 0x000057FF
		// (set) Token: 0x06000176 RID: 374 RVA: 0x00007607 File Offset: 0x00005807
		public int fatValor
		{
			get
			{
				return (int)this.m_cheesFat;
			}
			set
			{
				this.m_cheesFat = (Interpretacion.CantidadNoContable)value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00007610 File Offset: 0x00005810
		// (set) Token: 0x06000178 RID: 376 RVA: 0x00007618 File Offset: 0x00005818
		public int sinkValor
		{
			get
			{
				return (int)this.m_cheeksSink;
			}
			set
			{
				this.m_cheeksSink = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x04000077 RID: 119
		[SerializeField]
		private Interpretacion.Size m_cheekBonesSize;

		// Token: 0x04000078 RID: 120
		[SerializeField]
		private Interpretacion.Capacidad m_cheekBonesHeight;

		// Token: 0x04000079 RID: 121
		[SerializeField]
		private Interpretacion.CantidadNoContable m_cheesFat;

		// Token: 0x0400007A RID: 122
		[SerializeField]
		private Interpretacion.Capacidad m_cheeksSink;
	}
}
