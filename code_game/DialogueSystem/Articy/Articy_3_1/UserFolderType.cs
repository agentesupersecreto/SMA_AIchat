using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A4 RID: 420
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class UserFolderType
	{
		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06001257 RID: 4695 RVA: 0x0001AD8C File Offset: 0x00018F8C
		// (set) Token: 0x06001258 RID: 4696 RVA: 0x0001AD94 File Offset: 0x00018F94
		public LocalizableTextType DisplayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06001259 RID: 4697 RVA: 0x0001ADA0 File Offset: 0x00018FA0
		// (set) Token: 0x0600125A RID: 4698 RVA: 0x0001ADA8 File Offset: 0x00018FA8
		public LocalizableTextType Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x0600125B RID: 4699 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		// (set) Token: 0x0600125C RID: 4700 RVA: 0x0001ADBC File Offset: 0x00018FBC
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x0600125D RID: 4701 RVA: 0x0001ADC8 File Offset: 0x00018FC8
		// (set) Token: 0x0600125E RID: 4702 RVA: 0x0001ADD0 File Offset: 0x00018FD0
		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x0600125F RID: 4703 RVA: 0x0001ADDC File Offset: 0x00018FDC
		// (set) Token: 0x06001260 RID: 4704 RVA: 0x0001ADE4 File Offset: 0x00018FE4
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06001261 RID: 4705 RVA: 0x0001ADF0 File Offset: 0x00018FF0
		// (set) Token: 0x06001262 RID: 4706 RVA: 0x0001ADF8 File Offset: 0x00018FF8
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06001263 RID: 4707 RVA: 0x0001AE04 File Offset: 0x00019004
		// (set) Token: 0x06001264 RID: 4708 RVA: 0x0001AE0C File Offset: 0x0001900C
		public string Url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06001265 RID: 4709 RVA: 0x0001AE18 File Offset: 0x00019018
		// (set) Token: 0x06001266 RID: 4710 RVA: 0x0001AE20 File Offset: 0x00019020
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x04000A12 RID: 2578
		private LocalizableTextType displayNameField;

		// Token: 0x04000A13 RID: 2579
		private LocalizableTextType textField;

		// Token: 0x04000A14 RID: 2580
		private string colorField;

		// Token: 0x04000A15 RID: 2581
		private string technicalNameField;

		// Token: 0x04000A16 RID: 2582
		private string externalIdField;

		// Token: 0x04000A17 RID: 2583
		private string shortIdField;

		// Token: 0x04000A18 RID: 2584
		private string urlField;

		// Token: 0x04000A19 RID: 2585
		private string idField;
	}
}
