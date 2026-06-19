using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200018F RID: 399
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class ContentType
	{
		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x060011CF RID: 4559 RVA: 0x0001A85C File Offset: 0x00018A5C
		// (set) Token: 0x060011D0 RID: 4560 RVA: 0x0001A864 File Offset: 0x00018A64
		[XmlElement("QueryReferenceStripPropertyDefinition", typeof(QueryReferenceStripPropertyDefinitionType))]
		[XmlElement("ReferenceSlotPropertyDefinition", typeof(ReferenceSlotPropertyDefinitionType))]
		[XmlElement("ReferenceStripPropertyDefinition", typeof(ReferenceStripPropertyDefinitionType))]
		[XmlElement("Journeys", typeof(SystemFolderType))]
		[XmlElement("LayerFolder", typeof(LayerFolderType))]
		[XmlElement("PropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("Link", typeof(LinkType))]
		[XmlElement("ProjectSettings", typeof(ProjectSettingsType))]
		[XmlElement("ScriptPropertyDefinition", typeof(ScriptPropertyDefinitionType))]
		[XmlElement("Project", typeof(ProjectType))]
		[XmlElement("Journey", typeof(JourneyType))]
		[XmlElement("Connection", typeof(ConnectionType))]
		[XmlElement("Spot", typeof(SpotType))]
		[XmlElement("TextObject", typeof(TextObjectType))]
		[XmlElement("Location", typeof(LocationType))]
		[XmlElement("TextPropertyDefinition", typeof(TextPropertyDefinitionType))]
		[XmlElement("TypedObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedPropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedPropertyTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("LocationImage", typeof(LocationImageType))]
		[XmlElement("Jump", typeof(JumpType))]
		[XmlElement("Hub", typeof(HubType))]
		[XmlElement("GlobalVariables", typeof(SystemFolderType))]
		[XmlElement("VariableSet", typeof(VariableSetType))]
		[XmlElement("Zone", typeof(ZoneType))]
		[XmlChoiceIdentifier("ItemsElementName")]
		[XmlElement("FlowFragment", typeof(FlowFragmentType))]
		[XmlElement("LocationText", typeof(LocationTextType))]
		[XmlElement("Path", typeof(PathType))]
		[XmlElement("DialogueFragment", typeof(DialogueFragmentType))]
		[XmlElement("Flow", typeof(SystemFolderType))]
		[XmlElement("FeaturesUserFolder", typeof(UserFolderType))]
		[XmlElement("Features", typeof(SystemFolderType))]
		[XmlElement("Locations", typeof(SystemFolderType))]
		[XmlElement("FeatureDefinition", typeof(FeatureDefinitionType))]
		[XmlElement("JourneysUserFolder", typeof(UserFolderType))]
		[XmlElement("Comment", typeof(CommentType))]
		[XmlElement("BooleanPropertyDefinition", typeof(BooleanPropertyDefinitionType))]
		[XmlElement("AssetsUserFolder", typeof(UserFolderType))]
		[XmlElement("Assets", typeof(SystemFolderType))]
		[XmlElement("Asset", typeof(AssetType))]
		[XmlElement("LocationsUserFolder", typeof(UserFolderType))]
		[XmlElement("Instruction", typeof(InstructionType))]
		[XmlElement("Condition", typeof(ConditionType))]
		[XmlElement("Document", typeof(DocumentType))]
		[XmlElement("Documents", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("ObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplateDefinition", typeof(ObjectTemplateDefinitionType))]
		[XmlElement("ObjectCustomization", typeof(SystemFolderType))]
		[XmlElement("Dialogue", typeof(DialogueType))]
		[XmlElement("DocumentsUserFolder", typeof(UserFolderType))]
		[XmlElement("EnumerationPropertyDefinition", typeof(EnumerationPropertyDefinitionType))]
		[XmlElement("Entities", typeof(SystemFolderType))]
		[XmlElement("EntitiesUserFolder", typeof(UserFolderType))]
		[XmlElement("Entity", typeof(EntityType))]
		[XmlElement("NumberPropertyDefinition", typeof(NumberPropertyDefinitionType))]
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

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x060011D1 RID: 4561 RVA: 0x0001A870 File Offset: 0x00018A70
		// (set) Token: 0x060011D2 RID: 4562 RVA: 0x0001A878 File Offset: 0x00018A78
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

		// Token: 0x040009D4 RID: 2516
		private object[] itemsField;

		// Token: 0x040009D5 RID: 2517
		private ItemsChoiceType[] itemsElementNameField;
	}
}
