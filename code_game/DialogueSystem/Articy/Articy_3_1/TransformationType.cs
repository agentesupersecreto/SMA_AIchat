using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001DD RID: 477
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class TransformationType
	{
		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x0600156F RID: 5487 RVA: 0x0001CC40 File Offset: 0x0001AE40
		// (set) Token: 0x06001570 RID: 5488 RVA: 0x0001CC48 File Offset: 0x0001AE48
		public float Rotation
		{
			get
			{
				return this.rotationField;
			}
			set
			{
				this.rotationField = value;
			}
		}

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x06001571 RID: 5489 RVA: 0x0001CC54 File Offset: 0x0001AE54
		// (set) Token: 0x06001572 RID: 5490 RVA: 0x0001CC5C File Offset: 0x0001AE5C
		public PointType Pivot
		{
			get
			{
				return this.pivotField;
			}
			set
			{
				this.pivotField = value;
			}
		}

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x06001573 RID: 5491 RVA: 0x0001CC68 File Offset: 0x0001AE68
		// (set) Token: 0x06001574 RID: 5492 RVA: 0x0001CC70 File Offset: 0x0001AE70
		public PointType XAxis
		{
			get
			{
				return this.xAxisField;
			}
			set
			{
				this.xAxisField = value;
			}
		}

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x06001575 RID: 5493 RVA: 0x0001CC7C File Offset: 0x0001AE7C
		// (set) Token: 0x06001576 RID: 5494 RVA: 0x0001CC84 File Offset: 0x0001AE84
		public PointType YAxis
		{
			get
			{
				return this.yAxisField;
			}
			set
			{
				this.yAxisField = value;
			}
		}

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06001577 RID: 5495 RVA: 0x0001CC90 File Offset: 0x0001AE90
		// (set) Token: 0x06001578 RID: 5496 RVA: 0x0001CC98 File Offset: 0x0001AE98
		public PointType Translation
		{
			get
			{
				return this.translationField;
			}
			set
			{
				this.translationField = value;
			}
		}

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x06001579 RID: 5497 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
		// (set) Token: 0x0600157A RID: 5498 RVA: 0x0001CCAC File Offset: 0x0001AEAC
		public string TransformMatrix
		{
			get
			{
				return this.transformMatrixField;
			}
			set
			{
				this.transformMatrixField = value;
			}
		}

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x0600157B RID: 5499 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		// (set) Token: 0x0600157C RID: 5500 RVA: 0x0001CCC0 File Offset: 0x0001AEC0
		public RectangleType Bounds
		{
			get
			{
				return this.boundsField;
			}
			set
			{
				this.boundsField = value;
			}
		}

		// Token: 0x04000BD1 RID: 3025
		private float rotationField;

		// Token: 0x04000BD2 RID: 3026
		private PointType pivotField;

		// Token: 0x04000BD3 RID: 3027
		private PointType xAxisField;

		// Token: 0x04000BD4 RID: 3028
		private PointType yAxisField;

		// Token: 0x04000BD5 RID: 3029
		private PointType translationField;

		// Token: 0x04000BD6 RID: 3030
		private string transformMatrixField;

		// Token: 0x04000BD7 RID: 3031
		private RectangleType boundsField;
	}
}
