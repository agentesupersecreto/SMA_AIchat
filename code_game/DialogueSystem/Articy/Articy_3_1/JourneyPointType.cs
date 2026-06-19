using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C7 RID: 455
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyPointType
	{
		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x0600143F RID: 5183 RVA: 0x0001C064 File Offset: 0x0001A264
		// (set) Token: 0x06001440 RID: 5184 RVA: 0x0001C06C File Offset: 0x0001A26C
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

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06001441 RID: 5185 RVA: 0x0001C078 File Offset: 0x0001A278
		// (set) Token: 0x06001442 RID: 5186 RVA: 0x0001C080 File Offset: 0x0001A280
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

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06001443 RID: 5187 RVA: 0x0001C08C File Offset: 0x0001A28C
		// (set) Token: 0x06001444 RID: 5188 RVA: 0x0001C094 File Offset: 0x0001A294
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

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x0001C0A0 File Offset: 0x0001A2A0
		// (set) Token: 0x06001446 RID: 5190 RVA: 0x0001C0A8 File Offset: 0x0001A2A8
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

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
		// (set) Token: 0x06001448 RID: 5192 RVA: 0x0001C0BC File Offset: 0x0001A2BC
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

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06001449 RID: 5193 RVA: 0x0001C0C8 File Offset: 0x0001A2C8
		// (set) Token: 0x0600144A RID: 5194 RVA: 0x0001C0D0 File Offset: 0x0001A2D0
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

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x0001C0DC File Offset: 0x0001A2DC
		// (set) Token: 0x0600144C RID: 5196 RVA: 0x0001C0E4 File Offset: 0x0001A2E4
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

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x0001C0F0 File Offset: 0x0001A2F0
		// (set) Token: 0x0600144E RID: 5198 RVA: 0x0001C0F8 File Offset: 0x0001A2F8
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

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x0001C104 File Offset: 0x0001A304
		// (set) Token: 0x06001450 RID: 5200 RVA: 0x0001C10C File Offset: 0x0001A30C
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

		// Token: 0x04000B11 RID: 2833
		private JourneyRefType targetField;

		// Token: 0x04000B12 RID: 2834
		private LocalizableTextType textField;

		// Token: 0x04000B13 RID: 2835
		private string externalIdField;

		// Token: 0x04000B14 RID: 2836
		private string shortIdField;

		// Token: 0x04000B15 RID: 2837
		private JourneyPointSettingsType settingsField;

		// Token: 0x04000B16 RID: 2838
		private VariableValuesListType changedVariableValuesField;

		// Token: 0x04000B17 RID: 2839
		private JourneyMethodReturnValuesType methodReturnValuesField;

		// Token: 0x04000B18 RID: 2840
		private TypeOfJourneyPointType typeField;

		// Token: 0x04000B19 RID: 2841
		private ReachedByType reachedByField;
	}
}
