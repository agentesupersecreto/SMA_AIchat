using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003B RID: 59
	[AplicaAConjuntoDeFisico(para = "nose")]
	[Serializable]
	public struct InterpretacionDeNose
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00007D2B File Offset: 0x00005F2B
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00007D33 File Offset: 0x00005F33
		[AplicaAConjuntoDeFisico(para = "nose", weigth = 10)]
		[LabelLocalizado("Size", "US")]
		public Interpretacion.Size size
		{
			get
			{
				return this.m_noseSize;
			}
			set
			{
				this.m_noseSize = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00007D3C File Offset: 0x00005F3C
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00007D44 File Offset: 0x00005F44
		[LabelLocalizado("Height", "US")]
		public Interpretacion.Capacidad height
		{
			get
			{
				return this.m_noseHeight;
			}
			set
			{
				this.m_noseHeight = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00007D4D File Offset: 0x00005F4D
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00007D55 File Offset: 0x00005F55
		[LabelLocalizado("Projection", "US")]
		public Interpretacion.Capacidad proyection
		{
			get
			{
				return this.m_noseProyection;
			}
			set
			{
				this.m_noseProyection = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00007D5E File Offset: 0x00005F5E
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00007D66 File Offset: 0x00005F66
		[LabelLocalizado("Pinch", "US")]
		public Interpretacion.Capacidad pinch
		{
			get
			{
				return this.m_nosePinch;
			}
			set
			{
				this.m_nosePinch = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00007D6F File Offset: 0x00005F6F
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00007D77 File Offset: 0x00005F77
		[LabelLocalizado("Chisel", "US")]
		public Interpretacion.Capacidad chisel
		{
			get
			{
				return this.m_chisel;
			}
			set
			{
				this.m_chisel = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00007D80 File Offset: 0x00005F80
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00007D88 File Offset: 0x00005F88
		[LabelLocalizado("Bridge Thickness", "US")]
		public Interpretacion.Thickness bridgeThickness
		{
			get
			{
				return this.m_noseBridgeThickness;
			}
			set
			{
				this.m_noseBridgeThickness = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00007D91 File Offset: 0x00005F91
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00007D99 File Offset: 0x00005F99
		[LabelLocalizado("Bridge Height", "US")]
		public Interpretacion.Capacidad bridgeHeight
		{
			get
			{
				return this.m_noseBridgeHeight;
			}
			set
			{
				this.m_noseBridgeHeight = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00007DA2 File Offset: 0x00005FA2
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00007DAA File Offset: 0x00005FAA
		[LabelLocalizado("Bridge Depth", "US")]
		public Interpretacion.Depth bridgeDepth
		{
			get
			{
				return this.m_noseBridgeDepth;
			}
			set
			{
				this.m_noseBridgeDepth = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00007DB3 File Offset: 0x00005FB3
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00007DBB File Offset: 0x00005FBB
		[LabelLocalizado("Bridge Smoothness", "US")]
		public Interpretacion.Capacidad bridgeSmoothness
		{
			get
			{
				return this.m_bridgeSmoothness;
			}
			set
			{
				this.m_bridgeSmoothness = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00007DC4 File Offset: 0x00005FC4
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00007DCC File Offset: 0x00005FCC
		[LabelLocalizado("Ridge Bump", "US")]
		public Interpretacion.Size ridgeBump
		{
			get
			{
				return this.m_noseRidgeBump;
			}
			set
			{
				this.m_noseRidgeBump = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00007DD5 File Offset: 0x00005FD5
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00007DDD File Offset: 0x00005FDD
		[LabelLocalizado("Ridge Slope", "US")]
		public Interpretacion.CantidadNoContable ridgeSlope
		{
			get
			{
				return this.m_noseRidgeSlope;
			}
			set
			{
				this.m_noseRidgeSlope = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00007DE6 File Offset: 0x00005FE6
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00007DEE File Offset: 0x00005FEE
		[LabelLocalizado("Tip Roundness", "US")]
		public Interpretacion.CantidadNoContable tipRoundness
		{
			get
			{
				return this.m_noseTipRoundness;
			}
			set
			{
				this.m_noseTipRoundness = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00007DF7 File Offset: 0x00005FF7
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00007DFF File Offset: 0x00005FFF
		[LabelLocalizado("Tip Thickness", "US")]
		public Interpretacion.Thickness tipThickness
		{
			get
			{
				return this.m_noseTipThickness;
			}
			set
			{
				this.m_noseTipThickness = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00007E08 File Offset: 0x00006008
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00007E10 File Offset: 0x00006010
		[LabelLocalizado("Tip Depth", "US")]
		public Interpretacion.Depth tipDepth
		{
			get
			{
				return this.m_noseTipDepth;
			}
			set
			{
				this.m_noseTipDepth = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00007E19 File Offset: 0x00006019
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00007E21 File Offset: 0x00006021
		[LabelLocalizado("Tip Height", "US")]
		public Interpretacion.Capacidad tipHeight
		{
			get
			{
				return this.m_noseTipHeight;
			}
			set
			{
				this.m_noseTipHeight = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00007E2A File Offset: 0x0000602A
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00007E32 File Offset: 0x00006032
		[LabelLocalizado("Tip Slope", "US")]
		public Interpretacion.Capacidad tipSlope
		{
			get
			{
				return this.m_tipSlope;
			}
			set
			{
				this.m_tipSlope = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00007E3B File Offset: 0x0000603B
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00007E43 File Offset: 0x00006043
		[LabelLocalizado("Nostril Thickness", "US")]
		public Interpretacion.Thickness nostrilThickness
		{
			get
			{
				return this.m_noseNostrilThickness;
			}
			set
			{
				this.m_noseNostrilThickness = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00007E4C File Offset: 0x0000604C
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00007E54 File Offset: 0x00006054
		[LabelLocalizado("Nostril Depth", "US")]
		public Interpretacion.Depth nostrilDepth
		{
			get
			{
				return this.m_nostrilDepth;
			}
			set
			{
				this.m_nostrilDepth = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00007E5D File Offset: 0x0000605D
		// (set) Token: 0x06000272 RID: 626 RVA: 0x00007E65 File Offset: 0x00006065
		[LabelLocalizado("Nostril Angle", "US")]
		public Interpretacion.AngleDirection nostrilAngle
		{
			get
			{
				return this.m_nostrilAngle;
			}
			set
			{
				this.m_nostrilAngle = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00007E6E File Offset: 0x0000606E
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00007E76 File Offset: 0x00006076
		[LabelLocalizado("Nostril Size", "US")]
		public Interpretacion.Size nostrilSize
		{
			get
			{
				return this.m_nostrilSize;
			}
			set
			{
				this.m_nostrilSize = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00007E7F File Offset: 0x0000607F
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00007E87 File Offset: 0x00006087
		[LabelLocalizado("Nostril Collapse", "US")]
		public Interpretacion.Capacidad nostrilCollapse
		{
			get
			{
				return this.m_nostrilCollapse;
			}
			set
			{
				this.m_nostrilCollapse = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00007E90 File Offset: 0x00006090
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00007E98 File Offset: 0x00006098
		[LabelLocalizado("Nostril Collapse", "US")]
		public Interpretacion.Height nostrilHeight
		{
			get
			{
				return this.m_nostrilHeight;
			}
			set
			{
				this.m_nostrilHeight = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00007EA1 File Offset: 0x000060A1
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00007EA9 File Offset: 0x000060A9
		[LabelLocalizado("Septum Width", "US")]
		public Interpretacion.CantidadNoContable septumWidth
		{
			get
			{
				return this.m_septumWidth;
			}
			set
			{
				this.m_septumWidth = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00007EB2 File Offset: 0x000060B2
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00007EBA File Offset: 0x000060BA
		[LabelLocalizado("Septum Height", "US")]
		public Interpretacion.Capacidad septumHeight
		{
			get
			{
				return this.m_noseSeptumHeight;
			}
			set
			{
				this.m_noseSeptumHeight = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00007EC3 File Offset: 0x000060C3
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00007ECB File Offset: 0x000060CB
		[LabelLocalizado("Philtrum Concave", "US")]
		public Interpretacion.Capacidad philtrumConcave
		{
			get
			{
				return this.m_philtrumConcave;
			}
			set
			{
				this.m_philtrumConcave = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00007ED4 File Offset: 0x000060D4
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00007EDC File Offset: 0x000060DC
		public int sizeValor
		{
			get
			{
				return (int)this.m_noseSize;
			}
			set
			{
				this.m_noseSize = (Interpretacion.Size)value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00007EE5 File Offset: 0x000060E5
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00007EED File Offset: 0x000060ED
		public int heightValor
		{
			get
			{
				return (int)this.m_noseHeight;
			}
			set
			{
				this.m_noseHeight = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00007EF6 File Offset: 0x000060F6
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00007EFE File Offset: 0x000060FE
		public int proyectionValor
		{
			get
			{
				return (int)this.m_noseProyection;
			}
			set
			{
				this.m_noseProyection = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00007F07 File Offset: 0x00006107
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00007F0F File Offset: 0x0000610F
		public int pinchValor
		{
			get
			{
				return (int)this.m_nosePinch;
			}
			set
			{
				this.m_nosePinch = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00007F18 File Offset: 0x00006118
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00007F20 File Offset: 0x00006120
		public int bridgeThicknessValor
		{
			get
			{
				return (int)this.m_noseBridgeThickness;
			}
			set
			{
				this.m_noseBridgeThickness = (Interpretacion.Thickness)value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00007F29 File Offset: 0x00006129
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00007F31 File Offset: 0x00006131
		public int bridgeHeightValor
		{
			get
			{
				return (int)this.m_noseBridgeHeight;
			}
			set
			{
				this.m_noseBridgeHeight = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00007F3A File Offset: 0x0000613A
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00007F42 File Offset: 0x00006142
		public int bridgeDepthValor
		{
			get
			{
				return (int)this.m_noseBridgeDepth;
			}
			set
			{
				this.m_noseBridgeDepth = (Interpretacion.Depth)value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00007F4B File Offset: 0x0000614B
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00007F53 File Offset: 0x00006153
		public int ridgeBumpValor
		{
			get
			{
				return (int)this.m_noseRidgeBump;
			}
			set
			{
				this.m_noseRidgeBump = (Interpretacion.Size)value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00007F5C File Offset: 0x0000615C
		// (set) Token: 0x06000290 RID: 656 RVA: 0x00007F64 File Offset: 0x00006164
		public int ridgeSlopeValor
		{
			get
			{
				return (int)this.m_noseRidgeSlope;
			}
			set
			{
				this.m_noseRidgeSlope = (Interpretacion.CantidadNoContable)value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00007F6D File Offset: 0x0000616D
		// (set) Token: 0x06000292 RID: 658 RVA: 0x00007F75 File Offset: 0x00006175
		public int tipRoundnessValor
		{
			get
			{
				return (int)this.m_noseTipRoundness;
			}
			set
			{
				this.m_noseTipRoundness = (Interpretacion.CantidadNoContable)value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00007F7E File Offset: 0x0000617E
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00007F86 File Offset: 0x00006186
		public int tipThicknessValor
		{
			get
			{
				return (int)this.m_noseTipThickness;
			}
			set
			{
				this.m_noseTipThickness = (Interpretacion.Thickness)value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00007F8F File Offset: 0x0000618F
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00007F97 File Offset: 0x00006197
		public int tipDepthValor
		{
			get
			{
				return (int)this.m_noseTipDepth;
			}
			set
			{
				this.m_noseTipDepth = (Interpretacion.Depth)value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00007FA0 File Offset: 0x000061A0
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00007FA8 File Offset: 0x000061A8
		public int tipHeightValor
		{
			get
			{
				return (int)this.m_noseTipHeight;
			}
			set
			{
				this.m_noseTipHeight = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00007FB1 File Offset: 0x000061B1
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00007FB9 File Offset: 0x000061B9
		public int nostrilThicknessValor
		{
			get
			{
				return (int)this.m_noseNostrilThickness;
			}
			set
			{
				this.m_noseNostrilThickness = (Interpretacion.Thickness)value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00007FC2 File Offset: 0x000061C2
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00007FCA File Offset: 0x000061CA
		public int septumHeightValor
		{
			get
			{
				return (int)this.m_noseSeptumHeight;
			}
			set
			{
				this.m_noseSeptumHeight = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x040000E3 RID: 227
		[SerializeField]
		private Interpretacion.Size m_noseSize;

		// Token: 0x040000E4 RID: 228
		[SerializeField]
		private Interpretacion.Capacidad m_noseHeight;

		// Token: 0x040000E5 RID: 229
		[SerializeField]
		private Interpretacion.Capacidad m_noseProyection;

		// Token: 0x040000E6 RID: 230
		[SerializeField]
		private Interpretacion.Capacidad m_nosePinch;

		// Token: 0x040000E7 RID: 231
		[SerializeField]
		private Interpretacion.Capacidad m_chisel;

		// Token: 0x040000E8 RID: 232
		[SerializeField]
		private Interpretacion.Thickness m_noseBridgeThickness;

		// Token: 0x040000E9 RID: 233
		[SerializeField]
		private Interpretacion.Capacidad m_noseBridgeHeight;

		// Token: 0x040000EA RID: 234
		[SerializeField]
		private Interpretacion.Depth m_noseBridgeDepth;

		// Token: 0x040000EB RID: 235
		[SerializeField]
		private Interpretacion.Capacidad m_bridgeSmoothness;

		// Token: 0x040000EC RID: 236
		[SerializeField]
		private Interpretacion.Size m_noseRidgeBump;

		// Token: 0x040000ED RID: 237
		[SerializeField]
		private Interpretacion.CantidadNoContable m_noseRidgeSlope;

		// Token: 0x040000EE RID: 238
		[SerializeField]
		private Interpretacion.CantidadNoContable m_noseTipRoundness;

		// Token: 0x040000EF RID: 239
		[SerializeField]
		private Interpretacion.Thickness m_noseTipThickness;

		// Token: 0x040000F0 RID: 240
		[SerializeField]
		private Interpretacion.Capacidad m_noseTipHeight;

		// Token: 0x040000F1 RID: 241
		[SerializeField]
		private Interpretacion.Depth m_noseTipDepth;

		// Token: 0x040000F2 RID: 242
		[SerializeField]
		private Interpretacion.Capacidad m_tipSlope;

		// Token: 0x040000F3 RID: 243
		[SerializeField]
		private Interpretacion.Thickness m_noseNostrilThickness;

		// Token: 0x040000F4 RID: 244
		[SerializeField]
		private Interpretacion.Depth m_nostrilDepth;

		// Token: 0x040000F5 RID: 245
		[SerializeField]
		private Interpretacion.AngleDirection m_nostrilAngle;

		// Token: 0x040000F6 RID: 246
		[SerializeField]
		private Interpretacion.Size m_nostrilSize;

		// Token: 0x040000F7 RID: 247
		[SerializeField]
		private Interpretacion.Capacidad m_nostrilCollapse;

		// Token: 0x040000F8 RID: 248
		[SerializeField]
		private Interpretacion.Height m_nostrilHeight;

		// Token: 0x040000F9 RID: 249
		[SerializeField]
		private Interpretacion.CantidadNoContable m_septumWidth;

		// Token: 0x040000FA RID: 250
		[SerializeField]
		private Interpretacion.Capacidad m_noseSeptumHeight;

		// Token: 0x040000FB RID: 251
		[SerializeField]
		private Interpretacion.Capacidad m_philtrumConcave;
	}
}
