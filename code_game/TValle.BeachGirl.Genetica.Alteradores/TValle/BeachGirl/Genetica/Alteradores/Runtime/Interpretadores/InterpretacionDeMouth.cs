using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003A RID: 58
	[AplicaAConjuntoDeFisico(para = "mouth")]
	[Serializable]
	public struct InterpretacionDeMouth
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00007BE8 File Offset: 0x00005DE8
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00007BF0 File Offset: 0x00005DF0
		[AplicaAConjuntoDeFisico(para = "mouth", weigth = 10)]
		[LabelLocalizado("Width", "US")]
		public Interpretacion.Amplitude width
		{
			get
			{
				return this.m_mouthWidth;
			}
			set
			{
				this.m_mouthWidth = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00007BF9 File Offset: 0x00005DF9
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00007C01 File Offset: 0x00005E01
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

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00007C0A File Offset: 0x00005E0A
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00007C12 File Offset: 0x00005E12
		[LabelLocalizado("Corner Angle", "US")]
		public Interpretacion.AngleDirection cornerAngle
		{
			get
			{
				return this.m_cornerAngleAnchura;
			}
			set
			{
				this.m_cornerAngleAnchura = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00007C1B File Offset: 0x00005E1B
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00007C23 File Offset: 0x00005E23
		[LabelLocalizado("Curves", "US")]
		public Interpretacion.Capacidad curves
		{
			get
			{
				return this.m_curves;
			}
			set
			{
				this.m_curves = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00007C2C File Offset: 0x00005E2C
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00007C34 File Offset: 0x00005E34
		[LabelLocalizado("Heart", "US")]
		public Interpretacion.Capacidad heart
		{
			get
			{
				return this.m_heart;
			}
			set
			{
				this.m_heart = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00007C3D File Offset: 0x00005E3D
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00007C45 File Offset: 0x00005E45
		[LabelLocalizado("Edge Define", "US")]
		public Interpretacion.Capacidad edgeDefine
		{
			get
			{
				return this.m_edgeDefine;
			}
			set
			{
				this.m_edgeDefine = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00007C4E File Offset: 0x00005E4E
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00007C56 File Offset: 0x00005E56
		[LabelLocalizado("Upper Top Peak", "US")]
		public Interpretacion.Capacidad topPeak
		{
			get
			{
				return this.m_topPeak;
			}
			set
			{
				this.m_topPeak = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00007C5F File Offset: 0x00005E5F
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00007C67 File Offset: 0x00005E67
		[LabelLocalizado("Upper Curves", "US")]
		public Interpretacion.Capacidad upperCurves
		{
			get
			{
				return this.m_upperCurves;
			}
			set
			{
				this.m_upperCurves = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00007C70 File Offset: 0x00005E70
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00007C78 File Offset: 0x00005E78
		[LabelLocalizado("Upper Middle Thickness", "US")]
		public Interpretacion.Thickness upperLipMiddleThickness
		{
			get
			{
				return this.m_upperLipMiddleThickness;
			}
			set
			{
				this.m_upperLipMiddleThickness = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00007C81 File Offset: 0x00005E81
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00007C89 File Offset: 0x00005E89
		[AplicaAConjuntoDeFisico(para = "mouth", weigth = 10)]
		[LabelLocalizado("Upper Thickness", "US")]
		public Interpretacion.Thickness upperLipThickness
		{
			get
			{
				return this.m_mouthUpperLipThickness;
			}
			set
			{
				this.m_mouthUpperLipThickness = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00007C92 File Offset: 0x00005E92
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00007C9A File Offset: 0x00005E9A
		[AplicaAConjuntoDeFisico(para = "mouth", weigth = 10)]
		[LabelLocalizado("Lower Thickness", "US")]
		public Interpretacion.Thickness lowerLipThickness
		{
			get
			{
				return this.m_mouthLowerLipThickness;
			}
			set
			{
				this.m_mouthLowerLipThickness = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00007CA3 File Offset: 0x00005EA3
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00007CAB File Offset: 0x00005EAB
		[LabelLocalizado("Lower Thickness", "US")]
		public Interpretacion.CantidadNoContable lowerLipWidth
		{
			get
			{
				return this.m_lowerLipWidth;
			}
			set
			{
				this.m_lowerLipWidth = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00007CB4 File Offset: 0x00005EB4
		// (set) Token: 0x06000240 RID: 576 RVA: 0x00007CBC File Offset: 0x00005EBC
		[LabelLocalizado("Lower Depth", "US")]
		public Interpretacion.Depth lowerDepth
		{
			get
			{
				return this.m_lowerDepth;
			}
			set
			{
				this.m_lowerDepth = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00007CC5 File Offset: 0x00005EC5
		// (set) Token: 0x06000242 RID: 578 RVA: 0x00007CCD File Offset: 0x00005ECD
		[LabelLocalizado("Groove Depth", "US")]
		public Interpretacion.Depth grooveDepth
		{
			get
			{
				return this.m_grooveDepth;
			}
			set
			{
				this.m_grooveDepth = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00007CD6 File Offset: 0x00005ED6
		// (set) Token: 0x06000244 RID: 580 RVA: 0x00007CDE File Offset: 0x00005EDE
		[LabelLocalizado("Groove Angle", "US")]
		public Interpretacion.AngleDirection grooveAngle
		{
			get
			{
				return this.m_grooveAngle;
			}
			set
			{
				this.m_grooveAngle = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00007CE7 File Offset: 0x00005EE7
		// (set) Token: 0x06000246 RID: 582 RVA: 0x00007CEF File Offset: 0x00005EEF
		[LabelLocalizado("Groove Tone", "US")]
		public Interpretacion.Capacidad grooveTone
		{
			get
			{
				return this.m_grooveTone;
			}
			set
			{
				this.m_grooveTone = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00007CF8 File Offset: 0x00005EF8
		// (set) Token: 0x06000248 RID: 584 RVA: 0x00007D00 File Offset: 0x00005F00
		[LabelLocalizado("Groove Width", "US")]
		public Interpretacion.CantidadNoContable grooveWidth
		{
			get
			{
				return this.m_grooveWidth;
			}
			set
			{
				this.m_grooveWidth = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00007D09 File Offset: 0x00005F09
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00007D11 File Offset: 0x00005F11
		[LabelLocalizado("Depth (Sexual)", "US")]
		public Interpretacion.HoleDepth profundidad
		{
			get
			{
				return this.m_oralProfundidad;
			}
			set
			{
				this.m_oralProfundidad = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00007D1A File Offset: 0x00005F1A
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00007D22 File Offset: 0x00005F22
		[LabelLocalizado("Tightness (Sexual)", "US")]
		public Interpretacion.Tightness anchura
		{
			get
			{
				return this.m_oralAnchura;
			}
			set
			{
				this.m_oralAnchura = value;
			}
		}

		// Token: 0x040000CE RID: 206
		[SerializeField]
		private Interpretacion.Amplitude m_mouthWidth;

		// Token: 0x040000CF RID: 207
		[SerializeField]
		private Interpretacion.AngleDirection m_angle;

		// Token: 0x040000D0 RID: 208
		[SerializeField]
		private Interpretacion.AngleDirection m_cornerAngleAnchura;

		// Token: 0x040000D1 RID: 209
		[SerializeField]
		private Interpretacion.Capacidad m_curves;

		// Token: 0x040000D2 RID: 210
		[SerializeField]
		private Interpretacion.Capacidad m_heart;

		// Token: 0x040000D3 RID: 211
		[SerializeField]
		private Interpretacion.Capacidad m_edgeDefine;

		// Token: 0x040000D4 RID: 212
		[SerializeField]
		private Interpretacion.Capacidad m_topPeak;

		// Token: 0x040000D5 RID: 213
		[SerializeField]
		private Interpretacion.Capacidad m_upperCurves;

		// Token: 0x040000D6 RID: 214
		[SerializeField]
		private Interpretacion.Thickness m_upperLipMiddleThickness;

		// Token: 0x040000D7 RID: 215
		[SerializeField]
		private Interpretacion.Thickness m_mouthUpperLipThickness;

		// Token: 0x040000D8 RID: 216
		[SerializeField]
		private Interpretacion.Thickness m_mouthLowerLipThickness;

		// Token: 0x040000D9 RID: 217
		[SerializeField]
		private Interpretacion.CantidadNoContable m_lowerLipWidth;

		// Token: 0x040000DA RID: 218
		[SerializeField]
		private Interpretacion.Depth m_lowerDepth;

		// Token: 0x040000DB RID: 219
		[SerializeField]
		private Interpretacion.Depth m_grooveDepth;

		// Token: 0x040000DC RID: 220
		[SerializeField]
		private Interpretacion.AngleDirection m_grooveAngle;

		// Token: 0x040000DD RID: 221
		[SerializeField]
		private Interpretacion.Capacidad m_grooveTone;

		// Token: 0x040000DE RID: 222
		[SerializeField]
		private Interpretacion.CantidadNoContable m_grooveWidth;

		// Token: 0x040000DF RID: 223
		[SerializeField]
		private Interpretacion.HoleDepth m_oralProfundidad;

		// Token: 0x040000E0 RID: 224
		[SerializeField]
		private Interpretacion.Tightness m_oralAnchura;

		// Token: 0x040000E1 RID: 225
		[AplicaAConjuntoDeFisico(para = "mouth", weigth = 5)]
		[LabelLocalizado("Lipstick", "US")]
		public FreeColorAlpha lipstick;

		// Token: 0x040000E2 RID: 226
		[LabelLocalizado("Difficulty", "US")]
		public HoleDifficulty difficulty;
	}
}
