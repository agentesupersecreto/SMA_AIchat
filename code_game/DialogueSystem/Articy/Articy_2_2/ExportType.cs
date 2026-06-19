using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000A6 RID: 166
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlRoot("Export", Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd", IsNullable = false)]
	[DebuggerStepThrough]
	[Serializable]
	public class ExportType
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x000116FC File Offset: 0x0000F8FC
		public ExportType()
		{
			this.versionField = "2.2";
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x00011710 File Offset: 0x0000F910
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x00011718 File Offset: 0x0000F918
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

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x00011724 File Offset: 0x0000F924
		// (set) Token: 0x060006AF RID: 1711 RVA: 0x0001172C File Offset: 0x0000F92C
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

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x00011738 File Offset: 0x0000F938
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x00011740 File Offset: 0x0000F940
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

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0001174C File Offset: 0x0000F94C
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x00011754 File Offset: 0x0000F954
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

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x00011760 File Offset: 0x0000F960
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x00011768 File Offset: 0x0000F968
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

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00011774 File Offset: 0x0000F974
		// (set) Token: 0x060006B7 RID: 1719 RVA: 0x0001177C File Offset: 0x0000F97C
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

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00011788 File Offset: 0x0000F988
		// (set) Token: 0x060006B9 RID: 1721 RVA: 0x00011790 File Offset: 0x0000F990
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

		// Token: 0x04000397 RID: 919
		private ContentType contentField;

		// Token: 0x04000398 RID: 920
		private HierarchyType hierarchyField;

		// Token: 0x04000399 RID: 921
		private ExportErrorsType exportErrorsField;

		// Token: 0x0400039A RID: 922
		private string versionField;

		// Token: 0x0400039B RID: 923
		private string creatorToolField;

		// Token: 0x0400039C RID: 924
		private string creatorVersionField;

		// Token: 0x0400039D RID: 925
		private DateTime createdOnField;
	}
}
