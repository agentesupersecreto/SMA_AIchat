using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000032 RID: 50
	[Serializable]
	public struct InterpretacionDeBodySuperficial
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00007489 File Offset: 0x00005689
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00007491 File Offset: 0x00005691
		[AplicaAConjuntoDeFisico(para = "height")]
		[LabelLocalizado("Height", "US")]
		public Interpretacion.Height altura
		{
			get
			{
				return this.m_altura;
			}
			set
			{
				this.m_altura = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000749A File Offset: 0x0000569A
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000074A2 File Offset: 0x000056A2
		[AplicaAConjuntoDeFisico(para = "body", weigth = 10)]
		[LabelLocalizado("Body Fat", "US")]
		public Interpretacion.Capacidad bodyfat
		{
			get
			{
				return this.m_bodyfat;
			}
			set
			{
				this.m_bodyfat = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600014D RID: 333 RVA: 0x000074AB File Offset: 0x000056AB
		// (set) Token: 0x0600014E RID: 334 RVA: 0x000074B3 File Offset: 0x000056B3
		[AplicaAConjuntoDeFisico(para = "body")]
		[LabelLocalizado("Rib cage Thickness", "US")]
		public Interpretacion.Thickness ribcageThickness
		{
			get
			{
				return this.m_ribcageThickness;
			}
			set
			{
				this.m_ribcageThickness = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000074BC File Offset: 0x000056BC
		// (set) Token: 0x06000150 RID: 336 RVA: 0x000074C4 File Offset: 0x000056C4
		[AplicaAConjuntoDeFisico(para = "head")]
		[LabelLocalizado("Head Size", "US")]
		public Interpretacion.Size headsize
		{
			get
			{
				return this.m_headsize;
			}
			set
			{
				this.m_headsize = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000151 RID: 337 RVA: 0x000074CD File Offset: 0x000056CD
		// (set) Token: 0x06000152 RID: 338 RVA: 0x000074D5 File Offset: 0x000056D5
		[AplicaAConjuntoDeFisico(para = "head")]
		[LabelLocalizado("Neck Thickness", "US")]
		public Interpretacion.Thickness neckThickness
		{
			get
			{
				return this.m_neckThickness;
			}
			set
			{
				this.m_neckThickness = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000153 RID: 339 RVA: 0x000074DE File Offset: 0x000056DE
		// (set) Token: 0x06000154 RID: 340 RVA: 0x000074E6 File Offset: 0x000056E6
		[AplicaAConjuntoDeFisico(para = "head")]
		[LabelLocalizado("Neck Length", "US")]
		public Interpretacion.Length neckLength
		{
			get
			{
				return this.m_neckLength;
			}
			set
			{
				this.m_neckLength = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000074EF File Offset: 0x000056EF
		// (set) Token: 0x06000156 RID: 342 RVA: 0x000074F7 File Offset: 0x000056F7
		[AplicaAConjuntoDeFisico(para = "arms")]
		[LabelLocalizado("Arms Thickness", "US")]
		public Interpretacion.Thickness armsThickness
		{
			get
			{
				return this.m_armsThickness;
			}
			set
			{
				this.m_armsThickness = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00007500 File Offset: 0x00005700
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00007508 File Offset: 0x00005708
		[AplicaAConjuntoDeFisico(para = "arms")]
		[LabelLocalizado("Forearms Thickness", "US")]
		public Interpretacion.Thickness forearmsThickness
		{
			get
			{
				return this.m_forearmsThickness;
			}
			set
			{
				this.m_forearmsThickness = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00007511 File Offset: 0x00005711
		// (set) Token: 0x0600015A RID: 346 RVA: 0x00007519 File Offset: 0x00005719
		[AplicaAConjuntoDeFisico(para = "arms")]
		[LabelLocalizado("Hands Size", "US")]
		public Interpretacion.Size handsSize
		{
			get
			{
				return this.m_handsSize;
			}
			set
			{
				this.m_handsSize = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00007522 File Offset: 0x00005722
		// (set) Token: 0x0600015C RID: 348 RVA: 0x0000752A File Offset: 0x0000572A
		[AplicaAConjuntoDeFisico(para = "waist_hip")]
		[LabelLocalizado("Waist Thickness", "US")]
		public Interpretacion.Thickness cinturaThickness
		{
			get
			{
				return this.m_cinturaThickness;
			}
			set
			{
				this.m_cinturaThickness = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00007533 File Offset: 0x00005733
		// (set) Token: 0x0600015E RID: 350 RVA: 0x0000753B File Offset: 0x0000573B
		[AplicaAConjuntoDeFisico(para = "waist_hip")]
		[LabelLocalizado("Hips Thickness", "US")]
		public Interpretacion.Thickness caderaThickness
		{
			get
			{
				return this.m_caderaThickness;
			}
			set
			{
				this.m_caderaThickness = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00007544 File Offset: 0x00005744
		// (set) Token: 0x06000160 RID: 352 RVA: 0x0000754C File Offset: 0x0000574C
		[AplicaAConjuntoDeFisico(para = "waist_hip")]
		[LabelLocalizado("Hips Height", "US")]
		public Interpretacion.Capacidad caderaAltura
		{
			get
			{
				return this.m_caderaAltura;
			}
			set
			{
				this.m_caderaAltura = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00007555 File Offset: 0x00005755
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0000755D File Offset: 0x0000575D
		[AplicaAConjuntoDeFisico(para = "crotch", weigth = 10)]
		[LabelLocalizado("Thigh Gap", "US")]
		public Interpretacion.Size thighgap
		{
			get
			{
				return this.m_thighgap;
			}
			set
			{
				this.m_thighgap = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00007566 File Offset: 0x00005766
		// (set) Token: 0x06000164 RID: 356 RVA: 0x0000756E File Offset: 0x0000576E
		[AplicaAConjuntoDeFisico(para = "legs")]
		[LabelLocalizado("Legs Thickness", "US")]
		public Interpretacion.Thickness thighThickness
		{
			get
			{
				return this.m_thighThickness;
			}
			set
			{
				this.m_thighThickness = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00007577 File Offset: 0x00005777
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000757F File Offset: 0x0000577F
		[AplicaAConjuntoDeFisico(para = "legs")]
		[LabelLocalizado("Calves Thickness", "US")]
		public Interpretacion.Thickness calfThickness
		{
			get
			{
				return this.m_calfThickness;
			}
			set
			{
				this.m_calfThickness = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00007588 File Offset: 0x00005788
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00007590 File Offset: 0x00005790
		[AplicaAConjuntoDeFisico(para = "legs")]
		[LabelLocalizado("Feet Size", "US")]
		public Interpretacion.Size feetSize
		{
			get
			{
				return this.m_feetSize;
			}
			set
			{
				this.m_feetSize = value;
			}
		}

		// Token: 0x04000067 RID: 103
		[SerializeField]
		private Interpretacion.Height m_altura;

		// Token: 0x04000068 RID: 104
		[SerializeField]
		private Interpretacion.Capacidad m_bodyfat;

		// Token: 0x04000069 RID: 105
		[SerializeField]
		private Interpretacion.Thickness m_ribcageThickness;

		// Token: 0x0400006A RID: 106
		[SerializeField]
		private Interpretacion.Size m_headsize;

		// Token: 0x0400006B RID: 107
		[SerializeField]
		private Interpretacion.Thickness m_neckThickness;

		// Token: 0x0400006C RID: 108
		[SerializeField]
		private Interpretacion.Length m_neckLength;

		// Token: 0x0400006D RID: 109
		[SerializeField]
		private Interpretacion.Thickness m_armsThickness;

		// Token: 0x0400006E RID: 110
		[SerializeField]
		private Interpretacion.Thickness m_forearmsThickness;

		// Token: 0x0400006F RID: 111
		[SerializeField]
		private Interpretacion.Size m_handsSize;

		// Token: 0x04000070 RID: 112
		[SerializeField]
		private Interpretacion.Thickness m_cinturaThickness;

		// Token: 0x04000071 RID: 113
		[SerializeField]
		private Interpretacion.Thickness m_caderaThickness;

		// Token: 0x04000072 RID: 114
		[SerializeField]
		private Interpretacion.Capacidad m_caderaAltura;

		// Token: 0x04000073 RID: 115
		[SerializeField]
		private Interpretacion.Size m_thighgap;

		// Token: 0x04000074 RID: 116
		[SerializeField]
		private Interpretacion.Thickness m_thighThickness;

		// Token: 0x04000075 RID: 117
		[SerializeField]
		private Interpretacion.Thickness m_calfThickness;

		// Token: 0x04000076 RID: 118
		[SerializeField]
		private Interpretacion.Size m_feetSize;
	}
}
