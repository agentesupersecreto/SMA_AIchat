using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000031 RID: 49
	[AplicaAConjuntoDeFisico(para = "skin")]
	[Serializable]
	public struct InterpretacionDeBodySkin
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00007423 File Offset: 0x00005623
		// (set) Token: 0x0600013E RID: 318 RVA: 0x0000742B File Offset: 0x0000562B
		[AplicaAConjuntoDeFisico(para = "skin", weigth = 100)]
		[LabelLocalizado("Skin Tone", "US")]
		public Interpretacion.SkinTone skinTone
		{
			get
			{
				return this.m_skinTone;
			}
			set
			{
				this.m_skinTone = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00007434 File Offset: 0x00005634
		// (set) Token: 0x06000140 RID: 320 RVA: 0x0000743C File Offset: 0x0000563C
		[AplicaAConjuntoDeFisico(para = "skin", weigth = 2)]
		[LabelLocalizado("Tan Lines", "US")]
		public Interpretacion.Capacidad tanLines
		{
			get
			{
				return this.m_tanLines;
			}
			set
			{
				this.m_tanLines = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00007445 File Offset: 0x00005645
		// (set) Token: 0x06000142 RID: 322 RVA: 0x0000744D File Offset: 0x0000564D
		[LabelLocalizado("Skin Uniformity", "US")]
		public Interpretacion.Capacidad uniformity
		{
			get
			{
				return this.m_uniformity;
			}
			set
			{
				this.m_uniformity = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00007456 File Offset: 0x00005656
		// (set) Token: 0x06000144 RID: 324 RVA: 0x0000745E File Offset: 0x0000565E
		public int skinToneValor
		{
			get
			{
				return (int)this.m_skinTone;
			}
			set
			{
				this.m_skinTone = (Interpretacion.SkinTone)value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00007467 File Offset: 0x00005667
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000746F File Offset: 0x0000566F
		public int tanLinesValor
		{
			get
			{
				return (int)this.m_tanLines;
			}
			set
			{
				this.m_tanLines = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00007478 File Offset: 0x00005678
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00007480 File Offset: 0x00005680
		public int uniformityValor
		{
			get
			{
				return (int)this.m_uniformity;
			}
			set
			{
				this.m_uniformity = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x04000061 RID: 97
		[SerializeField]
		private Interpretacion.SkinTone m_skinTone;

		// Token: 0x04000062 RID: 98
		[SerializeField]
		private Interpretacion.Capacidad m_tanLines;

		// Token: 0x04000063 RID: 99
		[SerializeField]
		private Interpretacion.Capacidad m_uniformity;

		// Token: 0x04000064 RID: 100
		[LabelLocalizado("Difficulty", "US")]
		public SkinDifficulty difficulty;

		// Token: 0x04000065 RID: 101
		[LabelLocalizado("Finger Nail Color", "US")]
		public FreeColor fingerNailColor;

		// Token: 0x04000066 RID: 102
		[LabelLocalizado("Toe Nail Color", "US")]
		public FreeColor toeNailColor;
	}
}
