using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000053 RID: 83
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ContentType
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000E690 File Offset: 0x0000C890
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x0000E698 File Offset: 0x0000C898
		[XmlElement("BooleanPropertyDefinition", typeof(BooleanPropertyDefinitionType))]
		[XmlElement("Comment", typeof(CommentType))]
		[XmlElement("Connection", typeof(ConnectionType))]
		[XmlElement("Dialog", typeof(DialogType))]
		[XmlElement("AssetsUserFolder", typeof(UserFolderType))]
		[XmlElement("Entities", typeof(SystemFolderType))]
		[XmlElement("EntitiesUserFolder", typeof(UserFolderType))]
		[XmlElement("Entity", typeof(EntityType))]
		[XmlElement("EnumerationPropertyDefinition", typeof(EnumerationPropertyDefinitionType))]
		[XmlElement("FeatureDefinition", typeof(FeatureDefinitionType))]
		[XmlElement("Assets", typeof(SystemFolderType))]
		[XmlElement("FeaturesUserFolder", typeof(UserFolderType))]
		[XmlElement("FlowFragment", typeof(FlowFragmentType))]
		[XmlElement("Hub", typeof(HubType))]
		[XmlElement("Asset", typeof(AssetType))]
		[XmlElement("Journeys", typeof(SystemFolderType))]
		[XmlElement("JourneysUserFolder", typeof(UserFolderType))]
		[XmlElement("Jump", typeof(JumpType))]
		[XmlElement("Link", typeof(LinkType))]
		[XmlElement("Location", typeof(LocationType))]
		[XmlElement("Locations", typeof(SystemFolderType))]
		[XmlElement("LocationsUserFolder", typeof(UserFolderType))]
		[XmlElement("Note", typeof(NoteType))]
		[XmlElement("Features", typeof(SystemFolderType))]
		[XmlElement("NotesUserFolder", typeof(UserFolderType))]
		[XmlElement("NumberPropertyDefinition", typeof(NumberPropertyDefinitionType))]
		[XmlElement("ObjectCustomization", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplateDefinition", typeof(ObjectTemplateDefinitionType))]
		[XmlElement("ObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("Path", typeof(PathType))]
		[XmlElement("Project", typeof(ProjectType))]
		[XmlElement("PropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("ReferenceSlotPropertyDefinition", typeof(ReferenceSlotPropertyDefinitionType))]
		[XmlElement("ReferenceStripPropertyDefinition", typeof(ReferenceStripPropertyDefinitionType))]
		[XmlElement("Spot", typeof(SpotType))]
		[XmlElement("Stories", typeof(SystemFolderType))]
		[XmlElement("TextPropertyDefinition", typeof(TextPropertyDefinitionType))]
		[XmlElement("TypedObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedObjectTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("TypedPropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedPropertyTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("Zone", typeof(ZoneType))]
		[XmlChoiceIdentifier("ItemsElementName")]
		[XmlElement("Journey", typeof(JourneyType))]
		[XmlElement("DialogFragment", typeof(DialogFragmentType))]
		[XmlElement("Notes", typeof(SystemFolderType))]
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

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000E6A4 File Offset: 0x0000C8A4
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000E6AC File Offset: 0x0000C8AC
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

		// Token: 0x04000189 RID: 393
		private object[] itemsField;

		// Token: 0x0400018A RID: 394
		private ItemsChoiceType[] itemsElementNameField;
	}
}
