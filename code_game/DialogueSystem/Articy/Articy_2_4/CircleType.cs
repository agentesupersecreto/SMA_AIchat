using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000184 RID: 388
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class CircleType
	{
		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06001171 RID: 4465 RVA: 0x00019328 File Offset: 0x00017528
		// (set) Token: 0x06001172 RID: 4466 RVA: 0x00019330 File Offset: 0x00017530
		[XmlAttribute]
		public float CenterX
		{
			get
			{
				return this.centerXField;
			}
			set
			{
				this.centerXField = value;
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x0001933C File Offset: 0x0001753C
		// (set) Token: 0x06001174 RID: 4468 RVA: 0x00019344 File Offset: 0x00017544
		[XmlAttribute]
		public float CenterY
		{
			get
			{
				return this.centerYField;
			}
			set
			{
				this.centerYField = value;
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06001175 RID: 4469 RVA: 0x00019350 File Offset: 0x00017550
		// (set) Token: 0x06001176 RID: 4470 RVA: 0x00019358 File Offset: 0x00017558
		[XmlAttribute]
		public float Radius
		{
			get
			{
				return this.radiusField;
			}
			set
			{
				this.radiusField = value;
			}
		}

		// Token: 0x0400097C RID: 2428
		private float centerXField;

		// Token: 0x0400097D RID: 2429
		private float centerYField;

		// Token: 0x0400097E RID: 2430
		private float radiusField;
	}
}
