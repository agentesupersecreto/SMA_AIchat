using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000059 RID: 89
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyPointSettingsType
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000E8B4 File Offset: 0x0000CAB4
		// (set) Token: 0x0600032F RID: 815 RVA: 0x0000E8BC File Offset: 0x0000CABC
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

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000E8C8 File Offset: 0x0000CAC8
		// (set) Token: 0x06000331 RID: 817 RVA: 0x0000E8D0 File Offset: 0x0000CAD0
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

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000E8DC File Offset: 0x0000CADC
		// (set) Token: 0x06000333 RID: 819 RVA: 0x0000E8E4 File Offset: 0x0000CAE4
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

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000E8F0 File Offset: 0x0000CAF0
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0000E8F8 File Offset: 0x0000CAF8
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

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000E904 File Offset: 0x0000CB04
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0000E90C File Offset: 0x0000CB0C
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

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000E918 File Offset: 0x0000CB18
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0000E920 File Offset: 0x0000CB20
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

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0000E92C File Offset: 0x0000CB2C
		// (set) Token: 0x0600033B RID: 827 RVA: 0x0000E934 File Offset: 0x0000CB34
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

		// Token: 0x040001A2 RID: 418
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x040001A3 RID: 419
		private ReferenceType backgroundImageField;

		// Token: 0x040001A4 RID: 420
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x040001A5 RID: 421
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x040001A6 RID: 422
		private string backgroundColorField;

		// Token: 0x040001A7 RID: 423
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x040001A8 RID: 424
		private int durationField;
	}
}
