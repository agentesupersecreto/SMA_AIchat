using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000034 RID: 52
	[AplicaAConjuntoDeFisico(para = "face")]
	[Serializable]
	public struct InterpretacionDeEyebrows
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00007621 File Offset: 0x00005821
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00007629 File Offset: 0x00005829
		[LabelLocalizado("Height", "US")]
		public Interpretacion.Capacidad height
		{
			get
			{
				return this.m_eyebrowsHeight;
			}
			set
			{
				this.m_eyebrowsHeight = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00007632 File Offset: 0x00005832
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000763A File Offset: 0x0000583A
		[LabelLocalizado("Distance", "US")]
		public Interpretacion.Distance distance
		{
			get
			{
				return this.m_eyebrowsDistance;
			}
			set
			{
				this.m_eyebrowsDistance = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00007643 File Offset: 0x00005843
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000764B File Offset: 0x0000584B
		[LabelLocalizado("Thickness", "US")]
		public Interpretacion.Thickness thickness
		{
			get
			{
				return this.m_eyebrowsThickness;
			}
			set
			{
				this.m_eyebrowsThickness = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00007654 File Offset: 0x00005854
		// (set) Token: 0x06000180 RID: 384 RVA: 0x0000765C File Offset: 0x0000585C
		[LabelLocalizado("Length", "US")]
		public Interpretacion.Length length
		{
			get
			{
				return this.m_eyebrowsLength;
			}
			set
			{
				this.m_eyebrowsLength = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00007665 File Offset: 0x00005865
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000766D File Offset: 0x0000586D
		[LabelLocalizado("Ridge Size", "US")]
		public Interpretacion.Size ridgeSize
		{
			get
			{
				return this.m_browRidgeSize;
			}
			set
			{
				this.m_browRidgeSize = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00007676 File Offset: 0x00005876
		// (set) Token: 0x06000184 RID: 388 RVA: 0x0000767E File Offset: 0x0000587E
		[LabelLocalizado("Angle", "US")]
		public Interpretacion.AngleDirection angle
		{
			get
			{
				return this.m_angle;
			}
			set
			{
				this.m_angle = value;
			}
		}

		// Token: 0x0400007B RID: 123
		[SerializeField]
		private Interpretacion.Capacidad m_eyebrowsHeight;

		// Token: 0x0400007C RID: 124
		[SerializeField]
		private Interpretacion.Distance m_eyebrowsDistance;

		// Token: 0x0400007D RID: 125
		[SerializeField]
		private Interpretacion.Thickness m_eyebrowsThickness;

		// Token: 0x0400007E RID: 126
		[SerializeField]
		private Interpretacion.Length m_eyebrowsLength;

		// Token: 0x0400007F RID: 127
		[SerializeField]
		private Interpretacion.Size m_browRidgeSize;

		// Token: 0x04000080 RID: 128
		[SerializeField]
		private Interpretacion.AngleDirection m_angle;

		// Token: 0x04000081 RID: 129
		[AplicaAConjuntoDeFisico(para = "face", weigth = 3)]
		[DescripcionLocalizado("Ignored when the option to synchronize eyebrow color with hair color is activated.", "US")]
		[LabelLocalizado("Color", "US")]
		public FreeColorAlpha color;
	}
}
