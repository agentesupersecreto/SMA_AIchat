using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000188 RID: 392
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[XmlRoot("Export", Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd", IsNullable = false)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[Serializable]
	public class ExportType
	{
		// Token: 0x060011A0 RID: 4512 RVA: 0x0001A680 File Offset: 0x00018880
		public ExportType()
		{
			this.versionField = "3.0";
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x060011A1 RID: 4513 RVA: 0x0001A694 File Offset: 0x00018894
		// (set) Token: 0x060011A2 RID: 4514 RVA: 0x0001A69C File Offset: 0x0001889C
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

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x060011A3 RID: 4515 RVA: 0x0001A6A8 File Offset: 0x000188A8
		// (set) Token: 0x060011A4 RID: 4516 RVA: 0x0001A6B0 File Offset: 0x000188B0
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

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x060011A5 RID: 4517 RVA: 0x0001A6BC File Offset: 0x000188BC
		// (set) Token: 0x060011A6 RID: 4518 RVA: 0x0001A6C4 File Offset: 0x000188C4
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

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x0001A6D0 File Offset: 0x000188D0
		// (set) Token: 0x060011A8 RID: 4520 RVA: 0x0001A6D8 File Offset: 0x000188D8
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

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x0001A6E4 File Offset: 0x000188E4
		// (set) Token: 0x060011AA RID: 4522 RVA: 0x0001A6EC File Offset: 0x000188EC
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

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x0001A6F8 File Offset: 0x000188F8
		// (set) Token: 0x060011AC RID: 4524 RVA: 0x0001A700 File Offset: 0x00018900
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

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x0001A70C File Offset: 0x0001890C
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x0001A714 File Offset: 0x00018914
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

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x0001A720 File Offset: 0x00018920
		// (set) Token: 0x060011B0 RID: 4528 RVA: 0x0001A728 File Offset: 0x00018928
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

		// Token: 0x040009BD RID: 2493
		private SettingsType settingsField;

		// Token: 0x040009BE RID: 2494
		private ContentType contentField;

		// Token: 0x040009BF RID: 2495
		private HierarchyType hierarchyField;

		// Token: 0x040009C0 RID: 2496
		private ExportErrorsType exportErrorsField;

		// Token: 0x040009C1 RID: 2497
		private string versionField;

		// Token: 0x040009C2 RID: 2498
		private string creatorToolField;

		// Token: 0x040009C3 RID: 2499
		private string creatorVersionField;

		// Token: 0x040009C4 RID: 2500
		private DateTime createdOnField;
	}
}
