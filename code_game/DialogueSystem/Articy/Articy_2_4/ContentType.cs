using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000110 RID: 272
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ContentType
	{
		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00015834 File Offset: 0x00013A34
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x0001583C File Offset: 0x00013A3C
		[XmlElement("Journeys", typeof(SystemFolderType))]
		[XmlElement("Asset", typeof(AssetType))]
		[XmlElement("Assets", typeof(SystemFolderType))]
		[XmlElement("AssetsUserFolder", typeof(UserFolderType))]
		[XmlElement("BooleanPropertyDefinition", typeof(BooleanPropertyDefinitionType))]
		[XmlElement("Comment", typeof(CommentType))]
		[XmlElement("Condition", typeof(ConditionType))]
		[XmlElement("Connection", typeof(ConnectionType))]
		[XmlElement("Dialogue", typeof(DialogueType))]
		[XmlElement("DialogueFragment", typeof(DialogueFragmentType))]
		[XmlElement("Document", typeof(DocumentType))]
		[XmlElement("Documents", typeof(SystemFolderType))]
		[XmlElement("DocumentsUserFolder", typeof(UserFolderType))]
		[XmlElement("Entities", typeof(SystemFolderType))]
		[XmlElement("EntitiesUserFolder", typeof(UserFolderType))]
		[XmlElement("Entity", typeof(EntityType))]
		[XmlElement("EnumerationPropertyDefinition", typeof(EnumerationPropertyDefinitionType))]
		[XmlElement("FeatureDefinition", typeof(FeatureDefinitionType))]
		[XmlElement("Features", typeof(SystemFolderType))]
		[XmlElement("FeaturesUserFolder", typeof(UserFolderType))]
		[XmlElement("Flow", typeof(SystemFolderType))]
		[XmlElement("GlobalVariables", typeof(SystemFolderType))]
		[XmlElement("Hub", typeof(HubType))]
		[XmlElement("Instruction", typeof(InstructionType))]
		[XmlElement("FlowFragment", typeof(FlowFragmentType))]
		[XmlElement("JourneysUserFolder", typeof(UserFolderType))]
		[XmlElement("Jump", typeof(JumpType))]
		[XmlElement("LayerFolder", typeof(LayerFolderType))]
		[XmlElement("Link", typeof(LinkType))]
		[XmlElement("Location", typeof(LocationType))]
		[XmlElement("LocationImage", typeof(LocationImageType))]
		[XmlElement("LocationText", typeof(LocationTextType))]
		[XmlElement("Locations", typeof(SystemFolderType))]
		[XmlElement("LocationsUserFolder", typeof(UserFolderType))]
		[XmlElement("NumberPropertyDefinition", typeof(NumberPropertyDefinitionType))]
		[XmlElement("ObjectCustomization", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplateDefinition", typeof(ObjectTemplateDefinitionType))]
		[XmlElement("ObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("Path", typeof(PathType))]
		[XmlElement("Project", typeof(ProjectType))]
		[XmlElement("ProjectSettings", typeof(ProjectSettingsType))]
		[XmlElement("PropertyTemplates", typeof(SystemFolderType))]
		[XmlChoiceIdentifier("ItemsElementName")]
		[XmlElement("Zone", typeof(ZoneType))]
		[XmlElement("VariableSet", typeof(VariableSetType))]
		[XmlElement("TypedPropertyTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("TypedPropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("QueryReferenceStripPropertyDefinition", typeof(QueryReferenceStripPropertyDefinitionType))]
		[XmlElement("ReferenceSlotPropertyDefinition", typeof(ReferenceSlotPropertyDefinitionType))]
		[XmlElement("ReferenceStripPropertyDefinition", typeof(ReferenceStripPropertyDefinitionType))]
		[XmlElement("ScriptPropertyDefinition", typeof(ScriptPropertyDefinitionType))]
		[XmlElement("TypedObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("TextPropertyDefinition", typeof(TextPropertyDefinitionType))]
		[XmlElement("TextObject", typeof(TextObjectType))]
		[XmlElement("Journey", typeof(JourneyType))]
		[XmlElement("Spot", typeof(SpotType))]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00015848 File Offset: 0x00013A48
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x00015850 File Offset: 0x00013A50
		[XmlElement("ItemsElementName")]
		[XmlIgnore]
		public ItemsChoiceType[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		// Token: 0x04000648 RID: 1608
		private object[] itemsField;

		// Token: 0x04000649 RID: 1609
		private ItemsChoiceType[] itemsElementNameField;
	}
}
