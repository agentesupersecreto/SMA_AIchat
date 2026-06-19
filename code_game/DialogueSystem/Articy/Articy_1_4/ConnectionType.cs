using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008B RID: 139
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ConnectionType
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x0000FD18 File Offset: 0x0000DF18
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x0000FD20 File Offset: 0x0000DF20
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

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000FD2C File Offset: 0x0000DF2C
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0000FD34 File Offset: 0x0000DF34
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

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0000FD40 File Offset: 0x0000DF40
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x0000FD48 File Offset: 0x0000DF48
		public LocalizableTextType Label
		{
			get
			{
				return this.labelField;
			}
			set
			{
				this.labelField = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0000FD54 File Offset: 0x0000DF54
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		public ConnectionRefType Source
		{
			get
			{
				return this.sourceField;
			}
			set
			{
				this.sourceField = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000FD68 File Offset: 0x0000DF68
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x0000FD70 File Offset: 0x0000DF70
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000FD7C File Offset: 0x0000DF7C
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x0000FD84 File Offset: 0x0000DF84
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x040002C9 RID: 713
		private string colorField;

		// Token: 0x040002CA RID: 714
		private string technicalNameField;

		// Token: 0x040002CB RID: 715
		private LocalizableTextType labelField;

		// Token: 0x040002CC RID: 716
		private ConnectionRefType sourceField;

		// Token: 0x040002CD RID: 717
		private ConnectionRefType targetField;

		// Token: 0x040002CE RID: 718
		private string guidField;
	}
}
