using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D0 RID: 208
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneySettingsType
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x00012188 File Offset: 0x00010388
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x00012190 File Offset: 0x00010390
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

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x0001219C File Offset: 0x0001039C
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x000121A4 File Offset: 0x000103A4
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

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000121B0 File Offset: 0x000103B0
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x000121B8 File Offset: 0x000103B8
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

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x000121C4 File Offset: 0x000103C4
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x000121CC File Offset: 0x000103CC
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

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x000121D8 File Offset: 0x000103D8
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x000121E0 File Offset: 0x000103E0
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

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x000121EC File Offset: 0x000103EC
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x000121F4 File Offset: 0x000103F4
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

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00012200 File Offset: 0x00010400
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x00012208 File Offset: 0x00010408
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

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x00012214 File Offset: 0x00010414
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x0001221C File Offset: 0x0001041C
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

		// Token: 0x0400043F RID: 1087
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000440 RID: 1088
		private ReferenceType backgroundImageField;

		// Token: 0x04000441 RID: 1089
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000442 RID: 1090
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x04000443 RID: 1091
		private string backgroundColorField;

		// Token: 0x04000444 RID: 1092
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x04000445 RID: 1093
		private int durationField;

		// Token: 0x04000446 RID: 1094
		private TransitionModeType transitionModeField;
	}
}
