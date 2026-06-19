using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001BD RID: 445
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class JourneySettingsType
	{
		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x0600141D RID: 5149 RVA: 0x0001BF18 File Offset: 0x0001A118
		// (set) Token: 0x0600141E RID: 5150 RVA: 0x0001BF20 File Offset: 0x0001A120
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

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x0600141F RID: 5151 RVA: 0x0001BF2C File Offset: 0x0001A12C
		// (set) Token: 0x06001420 RID: 5152 RVA: 0x0001BF34 File Offset: 0x0001A134
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

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06001421 RID: 5153 RVA: 0x0001BF40 File Offset: 0x0001A140
		// (set) Token: 0x06001422 RID: 5154 RVA: 0x0001BF48 File Offset: 0x0001A148
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

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x0001BF54 File Offset: 0x0001A154
		// (set) Token: 0x06001424 RID: 5156 RVA: 0x0001BF5C File Offset: 0x0001A15C
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

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x0001BF68 File Offset: 0x0001A168
		// (set) Token: 0x06001426 RID: 5158 RVA: 0x0001BF70 File Offset: 0x0001A170
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

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x0001BF7C File Offset: 0x0001A17C
		// (set) Token: 0x06001428 RID: 5160 RVA: 0x0001BF84 File Offset: 0x0001A184
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

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06001429 RID: 5161 RVA: 0x0001BF90 File Offset: 0x0001A190
		// (set) Token: 0x0600142A RID: 5162 RVA: 0x0001BF98 File Offset: 0x0001A198
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

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x0600142B RID: 5163 RVA: 0x0001BFA4 File Offset: 0x0001A1A4
		// (set) Token: 0x0600142C RID: 5164 RVA: 0x0001BFAC File Offset: 0x0001A1AC
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

		// Token: 0x04000AEC RID: 2796
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000AED RID: 2797
		private ReferenceType backgroundImageField;

		// Token: 0x04000AEE RID: 2798
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000AEF RID: 2799
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x04000AF0 RID: 2800
		private string backgroundColorField;

		// Token: 0x04000AF1 RID: 2801
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x04000AF2 RID: 2802
		private int durationField;

		// Token: 0x04000AF3 RID: 2803
		private TransitionModeType transitionModeField;
	}
}
