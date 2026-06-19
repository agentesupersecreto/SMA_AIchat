using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000064 RID: 100
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneySettingsType
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600035D RID: 861 RVA: 0x0000EA80 File Offset: 0x0000CC80
		// (set) Token: 0x0600035E RID: 862 RVA: 0x0000EA88 File Offset: 0x0000CC88
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

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600035F RID: 863 RVA: 0x0000EA94 File Offset: 0x0000CC94
		// (set) Token: 0x06000360 RID: 864 RVA: 0x0000EA9C File Offset: 0x0000CC9C
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

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
		// (set) Token: 0x06000362 RID: 866 RVA: 0x0000EAB0 File Offset: 0x0000CCB0
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

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000EABC File Offset: 0x0000CCBC
		// (set) Token: 0x06000364 RID: 868 RVA: 0x0000EAC4 File Offset: 0x0000CCC4
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000EAD0 File Offset: 0x0000CCD0
		// (set) Token: 0x06000366 RID: 870 RVA: 0x0000EAD8 File Offset: 0x0000CCD8
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

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000EAE4 File Offset: 0x0000CCE4
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0000EAEC File Offset: 0x0000CCEC
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

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0000EAF8 File Offset: 0x0000CCF8
		// (set) Token: 0x0600036A RID: 874 RVA: 0x0000EB00 File Offset: 0x0000CD00
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

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000EB0C File Offset: 0x0000CD0C
		// (set) Token: 0x0600036C RID: 876 RVA: 0x0000EB14 File Offset: 0x0000CD14
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

		// Token: 0x040001DB RID: 475
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x040001DC RID: 476
		private ReferenceType backgroundImageField;

		// Token: 0x040001DD RID: 477
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x040001DE RID: 478
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x040001DF RID: 479
		private string backgroundColorField;

		// Token: 0x040001E0 RID: 480
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x040001E1 RID: 481
		private int durationField;

		// Token: 0x040001E2 RID: 482
		private TransitionModeType transitionModeField;
	}
}
