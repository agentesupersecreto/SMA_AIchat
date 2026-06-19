using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000148 RID: 328
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyPointType
	{
		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x0001703C File Offset: 0x0001523C
		// (set) Token: 0x06000DEE RID: 3566 RVA: 0x00017044 File Offset: 0x00015244
		public JourneyRefType Target
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

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00017050 File Offset: 0x00015250
		// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00017058 File Offset: 0x00015258
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

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00017064 File Offset: 0x00015264
		// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x0001706C File Offset: 0x0001526C
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

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00017078 File Offset: 0x00015278
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00017080 File Offset: 0x00015280
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

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x0001708C File Offset: 0x0001528C
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x00017094 File Offset: 0x00015294
		public JourneyPointSettingsType Settings
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

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x000170A0 File Offset: 0x000152A0
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x000170A8 File Offset: 0x000152A8
		public VariableValuesListType ChangedVariableValues
		{
			get
			{
				return this.changedVariableValuesField;
			}
			set
			{
				this.changedVariableValuesField = value;
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x000170B4 File Offset: 0x000152B4
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x000170BC File Offset: 0x000152BC
		public JourneyMethodReturnValuesType MethodReturnValues
		{
			get
			{
				return this.methodReturnValuesField;
			}
			set
			{
				this.methodReturnValuesField = value;
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x000170C8 File Offset: 0x000152C8
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x000170D0 File Offset: 0x000152D0
		[XmlAttribute]
		public TypeOfJourneyPointType Type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06000DFD RID: 3581 RVA: 0x000170DC File Offset: 0x000152DC
		// (set) Token: 0x06000DFE RID: 3582 RVA: 0x000170E4 File Offset: 0x000152E4
		[XmlAttribute]
		public ReachedByType ReachedBy
		{
			get
			{
				return this.reachedByField;
			}
			set
			{
				this.reachedByField = value;
			}
		}

		// Token: 0x04000785 RID: 1925
		private JourneyRefType targetField;

		// Token: 0x04000786 RID: 1926
		private LocalizableTextType textField;

		// Token: 0x04000787 RID: 1927
		private string externalIdField;

		// Token: 0x04000788 RID: 1928
		private string shortIdField;

		// Token: 0x04000789 RID: 1929
		private JourneyPointSettingsType settingsField;

		// Token: 0x0400078A RID: 1930
		private VariableValuesListType changedVariableValuesField;

		// Token: 0x0400078B RID: 1931
		private JourneyMethodReturnValuesType methodReturnValuesField;

		// Token: 0x0400078C RID: 1932
		private TypeOfJourneyPointType typeField;

		// Token: 0x0400078D RID: 1933
		private ReachedByType reachedByField;
	}
}
