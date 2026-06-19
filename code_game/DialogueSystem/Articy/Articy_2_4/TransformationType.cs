using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200015E RID: 350
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class TransformationType
	{
		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x00017C18 File Offset: 0x00015E18
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x00017C20 File Offset: 0x00015E20
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

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00017C2C File Offset: 0x00015E2C
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x00017C34 File Offset: 0x00015E34
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

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x00017C40 File Offset: 0x00015E40
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x00017C48 File Offset: 0x00015E48
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

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x00017C54 File Offset: 0x00015E54
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x00017C5C File Offset: 0x00015E5C
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

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x00017C68 File Offset: 0x00015E68
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00017C70 File Offset: 0x00015E70
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

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00017C7C File Offset: 0x00015E7C
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00017C84 File Offset: 0x00015E84
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

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x00017C90 File Offset: 0x00015E90
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x00017C98 File Offset: 0x00015E98
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

		// Token: 0x04000845 RID: 2117
		private float rotationField;

		// Token: 0x04000846 RID: 2118
		private PointType pivotField;

		// Token: 0x04000847 RID: 2119
		private PointType xAxisField;

		// Token: 0x04000848 RID: 2120
		private PointType yAxisField;

		// Token: 0x04000849 RID: 2121
		private PointType translationField;

		// Token: 0x0400084A RID: 2122
		private string transformMatrixField;

		// Token: 0x0400084B RID: 2123
		private RectangleType boundsField;
	}
}
