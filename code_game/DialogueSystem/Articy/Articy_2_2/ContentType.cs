using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000A7 RID: 167
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ContentType
	{
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000117A4 File Offset: 0x0000F9A4
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000117AC File Offset: 0x0000F9AC
		[XmlElement("Project", typeof(ProjectType))]
		[XmlElement("QueryReferenceStripPropertyDefinition", typeof(QueryReferenceStripPropertyDefinitionType))]
		[XmlElement("ReferenceSlotPropertyDefinition", typeof(ReferenceSlotPropertyDefinitionType))]
		[XmlElement("ReferenceStripPropertyDefinition", typeof(ReferenceStripPropertyDefinitionType))]
		[XmlElement("Path", typeof(PathType))]
		[XmlElement("ObjectTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("ObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplateDefinition", typeof(ObjectTemplateDefinitionType))]
		[XmlElement("ObjectCustomization", typeof(SystemFolderType))]
		[XmlElement("NumberPropertyDefinition", typeof(NumberPropertyDefinitionType))]
		[XmlElement("ScriptPropertyDefinition", typeof(ScriptPropertyDefinitionType))]
		[XmlElement("Spot", typeof(SpotType))]
		[XmlElement("TextObject", typeof(TextObjectType))]
		[XmlElement("LocationsUserFolder", typeof(UserFolderType))]
		[XmlElement("TextPropertyDefinition", typeof(TextPropertyDefinitionType))]
		[XmlElement("TypedObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedPropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("Locations", typeof(SystemFolderType))]
		[XmlElement("LocationGroup", typeof(LocationGroupType))]
		[XmlElement("Location", typeof(LocationType))]
		[XmlElement("TypedPropertyTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("VariableSet", typeof(VariableSetType))]
		[XmlElement("Zone", typeof(ZoneType))]
		[XmlElement("Entity", typeof(EntityType))]
		[XmlElement("EntitiesUserFolder", typeof(UserFolderType))]
		[XmlChoiceIdentifier("ItemsElementName")]
		[XmlElement("DocumentsUserFolder", typeof(UserFolderType))]
		[XmlElement("Link", typeof(LinkType))]
		[XmlElement("Asset", typeof(AssetType))]
		[XmlElement("Jump", typeof(JumpType))]
		[XmlElement("JourneysUserFolder", typeof(UserFolderType))]
		[XmlElement("Journeys", typeof(SystemFolderType))]
		[XmlElement("Assets", typeof(SystemFolderType))]
		[XmlElement("Entities", typeof(SystemFolderType))]
		[XmlElement("Journey", typeof(JourneyType))]
		[XmlElement("Instruction", typeof(InstructionType))]
		[XmlElement("Hub", typeof(HubType))]
		[XmlElement("AssetsUserFolder", typeof(UserFolderType))]
		[XmlElement("BooleanPropertyDefinition", typeof(BooleanPropertyDefinitionType))]
		[XmlElement("Documents", typeof(SystemFolderType))]
		[XmlElement("Comment", typeof(CommentType))]
		[XmlElement("GlobalVariables", typeof(SystemFolderType))]
		[XmlElement("EnumerationPropertyDefinition", typeof(EnumerationPropertyDefinitionType))]
		[XmlElement("Flow", typeof(SystemFolderType))]
		[XmlElement("Condition", typeof(ConditionType))]
		[XmlElement("Connection", typeof(ConnectionType))]
		[XmlElement("Document", typeof(DocumentType))]
		[XmlElement("DialogueFragment", typeof(DialogueFragmentType))]
		[XmlElement("FeaturesUserFolder", typeof(UserFolderType))]
		[XmlElement("FeatureDefinition", typeof(FeatureDefinitionType))]
		[XmlElement("Features", typeof(SystemFolderType))]
		[XmlElement("Dialogue", typeof(DialogueType))]
		[XmlElement("PropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("FlowFragment", typeof(FlowFragmentType))]
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

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000117B8 File Offset: 0x0000F9B8
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x000117C0 File Offset: 0x0000F9C0
		[XmlIgnore]
		[XmlElement("ItemsElementName")]
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

		// Token: 0x0400039E RID: 926
		private object[] itemsField;

		// Token: 0x0400039F RID: 927
		private ItemsChoiceType[] itemsElementNameField;
	}
}
