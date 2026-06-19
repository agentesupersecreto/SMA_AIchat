using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000052 RID: 82
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlRoot("Export", Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd", IsNullable = false)]
	[Serializable]
	public class ExportType
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x0000E5E8 File Offset: 0x0000C7E8
		public ExportType()
		{
			this.versionField = "1.4";
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000E5FC File Offset: 0x0000C7FC
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x0000E604 File Offset: 0x0000C804
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

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x0000E610 File Offset: 0x0000C810
		// (set) Token: 0x060002EA RID: 746 RVA: 0x0000E618 File Offset: 0x0000C818
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

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002EB RID: 747 RVA: 0x0000E624 File Offset: 0x0000C824
		// (set) Token: 0x060002EC RID: 748 RVA: 0x0000E62C File Offset: 0x0000C82C
		[XmlArrayItem("Error", IsNullable = false)]
		public string[] ExportErrors
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

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000E638 File Offset: 0x0000C838
		// (set) Token: 0x060002EE RID: 750 RVA: 0x0000E640 File Offset: 0x0000C840
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

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000E64C File Offset: 0x0000C84C
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000E654 File Offset: 0x0000C854
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

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000E660 File Offset: 0x0000C860
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000E668 File Offset: 0x0000C868
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

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000E674 File Offset: 0x0000C874
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000E67C File Offset: 0x0000C87C
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

		// Token: 0x04000182 RID: 386
		private ContentType contentField;

		// Token: 0x04000183 RID: 387
		private HierarchyType hierarchyField;

		// Token: 0x04000184 RID: 388
		private string[] exportErrorsField;

		// Token: 0x04000185 RID: 389
		private string versionField;

		// Token: 0x04000186 RID: 390
		private string creatorToolField;

		// Token: 0x04000187 RID: 391
		private string creatorVersionField;

		// Token: 0x04000188 RID: 392
		private DateTime createdOnField;
	}
}
