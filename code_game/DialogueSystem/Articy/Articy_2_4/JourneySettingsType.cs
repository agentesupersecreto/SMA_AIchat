using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200013E RID: 318
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneySettingsType
	{
		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00016EF0 File Offset: 0x000150F0
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x00016EF8 File Offset: 0x000150F8
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

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00016F04 File Offset: 0x00015104
		// (set) Token: 0x06000DCE RID: 3534 RVA: 0x00016F0C File Offset: 0x0001510C
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

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00016F18 File Offset: 0x00015118
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x00016F20 File Offset: 0x00015120
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

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00016F2C File Offset: 0x0001512C
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00016F34 File Offset: 0x00015134
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

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00016F40 File Offset: 0x00015140
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x00016F48 File Offset: 0x00015148
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

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00016F54 File Offset: 0x00015154
		// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x00016F5C File Offset: 0x0001515C
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

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00016F68 File Offset: 0x00015168
		// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x00016F70 File Offset: 0x00015170
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

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00016F7C File Offset: 0x0001517C
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x00016F84 File Offset: 0x00015184
		public TransitionModeType TransitionMode
		{
			get
			{
				return this.transitionModeField;
			}
			set
			{
				this.transitionModeField = value;
			}
		}

		// Token: 0x04000760 RID: 1888
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000761 RID: 1889
		private ReferenceType backgroundImageField;

		// Token: 0x04000762 RID: 1890
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000763 RID: 1891
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x04000764 RID: 1892
		private string backgroundColorField;

		// Token: 0x04000765 RID: 1893
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x04000766 RID: 1894
		private int durationField;

		// Token: 0x04000767 RID: 1895
		private TransitionModeType transitionModeField;
	}
}
