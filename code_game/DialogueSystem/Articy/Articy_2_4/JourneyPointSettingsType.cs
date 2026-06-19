using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014A RID: 330
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyPointSettingsType
	{
		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06000E07 RID: 3591 RVA: 0x0001713C File Offset: 0x0001533C
		// (set) Token: 0x06000E08 RID: 3592 RVA: 0x00017144 File Offset: 0x00015344
		public BackgroundImageModeType BackgroundImageMode
		{
			get
			{
				return this.backgroundImageModeField;
			}
			set
			{
				this.backgroundImageModeField = value;
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x00017150 File Offset: 0x00015350
		// (set) Token: 0x06000E0A RID: 3594 RVA: 0x00017158 File Offset: 0x00015358
		public ReferenceType BackgroundImage
		{
			get
			{
				return this.backgroundImageField;
			}
			set
			{
				this.backgroundImageField = value;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x00017164 File Offset: 0x00015364
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x0001716C File Offset: 0x0001536C
		public BackgroundImagePositioningModeType BackgroundImagePositioningMode
		{
			get
			{
				return this.backgroundImagePositioningModeField;
			}
			set
			{
				this.backgroundImagePositioningModeField = value;
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00017178 File Offset: 0x00015378
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00017180 File Offset: 0x00015380
		public BackgroundColorModeType BackgroundColorMode
		{
			get
			{
				return this.backgroundColorModeField;
			}
			set
			{
				this.backgroundColorModeField = value;
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0001718C File Offset: 0x0001538C
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00017194 File Offset: 0x00015394
		public string BackgroundColor
		{
			get
			{
				return this.backgroundColorField;
			}
			set
			{
				this.backgroundColorField = value;
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x000171A0 File Offset: 0x000153A0
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x000171A8 File Offset: 0x000153A8
		public BackgroundColorGradientModeType BackgroundColorGradientMode
		{
			get
			{
				return this.backgroundColorGradientModeField;
			}
			set
			{
				this.backgroundColorGradientModeField = value;
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x000171B4 File Offset: 0x000153B4
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x000171BC File Offset: 0x000153BC
		public int Duration
		{
			get
			{
				return this.durationField;
			}
			set
			{
				this.durationField = value;
			}
		}

		// Token: 0x04000791 RID: 1937
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000792 RID: 1938
		private ReferenceType backgroundImageField;

		// Token: 0x04000793 RID: 1939
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000794 RID: 1940
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x04000795 RID: 1941
		private string backgroundColorField;

		// Token: 0x04000796 RID: 1942
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x04000797 RID: 1943
		private int durationField;
	}
}
