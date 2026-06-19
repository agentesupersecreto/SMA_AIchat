using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C6 RID: 198
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyPointSettingsType
	{
		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00011FEC File Offset: 0x000101EC
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x00011FF4 File Offset: 0x000101F4
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

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00012000 File Offset: 0x00010200
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00012008 File Offset: 0x00010208
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

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x00012014 File Offset: 0x00010214
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x0001201C File Offset: 0x0001021C
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

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00012028 File Offset: 0x00010228
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00012030 File Offset: 0x00010230
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

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0001203C File Offset: 0x0001023C
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x00012044 File Offset: 0x00010244
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

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00012050 File Offset: 0x00010250
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00012058 File Offset: 0x00010258
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

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00012064 File Offset: 0x00010264
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x0001206C File Offset: 0x0001026C
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

		// Token: 0x04000406 RID: 1030
		private BackgroundImageModeType backgroundImageModeField;

		// Token: 0x04000407 RID: 1031
		private ReferenceType backgroundImageField;

		// Token: 0x04000408 RID: 1032
		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		// Token: 0x04000409 RID: 1033
		private BackgroundColorModeType backgroundColorModeField;

		// Token: 0x0400040A RID: 1034
		private string backgroundColorField;

		// Token: 0x0400040B RID: 1035
		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		// Token: 0x0400040C RID: 1036
		private int durationField;
	}
}
