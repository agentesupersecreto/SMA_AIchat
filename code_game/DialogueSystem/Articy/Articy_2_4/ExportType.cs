using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000109 RID: 265
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[XmlRoot("Export", Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd", IsNullable = false)]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ExportType
	{
		// Token: 0x06000B4E RID: 2894 RVA: 0x00015658 File Offset: 0x00013858
		public ExportType()
		{
			this.versionField = "2.4";
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0001566C File Offset: 0x0001386C
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x00015674 File Offset: 0x00013874
		public SettingsType Settings
		{
			get
			{
				return this.settingsField;
			}
			set
			{
				this.settingsField = value;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00015680 File Offset: 0x00013880
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x00015688 File Offset: 0x00013888
		public ContentType Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00015694 File Offset: 0x00013894
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x0001569C File Offset: 0x0001389C
		public HierarchyType Hierarchy
		{
			get
			{
				return this.hierarchyField;
			}
			set
			{
				this.hierarchyField = value;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x000156A8 File Offset: 0x000138A8
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000156B0 File Offset: 0x000138B0
		public ExportErrorsType ExportErrors
		{
			get
			{
				return this.exportErrorsField;
			}
			set
			{
				this.exportErrorsField = value;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000156BC File Offset: 0x000138BC
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x000156C4 File Offset: 0x000138C4
		[XmlAttribute]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x000156D0 File Offset: 0x000138D0
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x000156D8 File Offset: 0x000138D8
		[XmlAttribute]
		public string CreatorTool
		{
			get
			{
				return this.creatorToolField;
			}
			set
			{
				this.creatorToolField = value;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x000156E4 File Offset: 0x000138E4
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x000156EC File Offset: 0x000138EC
		[XmlAttribute]
		public string CreatorVersion
		{
			get
			{
				return this.creatorVersionField;
			}
			set
			{
				this.creatorVersionField = value;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x000156F8 File Offset: 0x000138F8
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00015700 File Offset: 0x00013900
		[XmlAttribute]
		public DateTime CreatedOn
		{
			get
			{
				return this.createdOnField;
			}
			set
			{
				this.createdOnField = value;
			}
		}

		// Token: 0x04000631 RID: 1585
		private SettingsType settingsField;

		// Token: 0x04000632 RID: 1586
		private ContentType contentField;

		// Token: 0x04000633 RID: 1587
		private HierarchyType hierarchyField;

		// Token: 0x04000634 RID: 1588
		private ExportErrorsType exportErrorsField;

		// Token: 0x04000635 RID: 1589
		private string versionField;

		// Token: 0x04000636 RID: 1590
		private string creatorToolField;

		// Token: 0x04000637 RID: 1591
		private string creatorVersionField;

		// Token: 0x04000638 RID: 1592
		private DateTime createdOnField;
	}
}
