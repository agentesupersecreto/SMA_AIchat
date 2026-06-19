using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C9 RID: 457
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneyPointSettingsType
	{
		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x0001C164 File Offset: 0x0001A364
		// (set) Token: 0x0600145A RID: 5210 RVA: 0x0001C16C File Offset: 0x0001A36C
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

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x0001C178 File Offset: 0x0001A378
		// (set) Token: 0x0600145C RID: 5212 RVA: 0x0001C180 File Offset: 0x0001A380
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

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x0001C18C File Offset: 0x0001A38C
		// (set) Token: 0x0600145E RID: 5214 RVA: 0x0001C194 File Offset: 0x0001A394
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

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x0001C1A0 File Offset: 0x0001A3A0
		// (set) Token: 0x06001460 RID: 5216 RVA: 0x0001C1A8 File Offset: 0x0001A3A8
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

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06001461 RID: 5217 RVA: 0x0001C1B4 File Offset: 0x0001A3B4
		// (set) Token: 0x06001462 RID: 5218 RVA: 0x0001C1BC File Offset: 0x0001A3BC
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

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06001463 RID: 5219 RVA: 0x0001C1C8 File Offset: 0x0001A3C8
		// (set) Token: 0x06001464 RID: 5220 RVA: 0x0001C1D0 File Offset: 0x0001A3D0
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

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06001465 RID: 5221 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		// (set) Token: 0x06001466 RID: 5222 RVA: 0x0001C1E4 File Offset: 0x0001A3E4
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

		// Token: 0x04000B1D RID: 2845
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000B1E RID: 2846
		private ReferenceType backgroundImageField;

		// Token: 0x04000B1F RID: 2847
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000B20 RID: 2848
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x04000B21 RID: 2849
		private string backgroundColorField;

		// Token: 0x04000B22 RID: 2850
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x04000B23 RID: 2851
		private int durationField;
	}
}
