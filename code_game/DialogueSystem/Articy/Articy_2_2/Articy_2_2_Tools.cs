using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000A5 RID: 165
	public static class Articy_2_2_Tools
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x000109D8 File Offset: 0x0000EBD8
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd");
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x000109E8 File Offset: 0x0000EBE8
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding)
		{
			return Articy_2_2_Tools.ConvertExportToArticyData(Articy_2_2_Tools.LoadFromXmlData(xmlData, encoding));
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x000109F8 File Offset: 0x0000EBF8
		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportType));
			return xmlSerializer.Deserialize(new StringReader(xmlData)) as ExportType;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00010A28 File Offset: 0x0000EC28
		public static bool IsExportValid(ExportType export)
		{
			return export != null && export.Content != null && export.Content.Items != null;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00010A5C File Offset: 0x0000EC5C
		public static ArticyData ConvertExportToArticyData(ExportType export)
		{
			if (!Articy_2_2_Tools.IsExportValid(export))
			{
				return null;
			}
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			foreach (object obj in export.Content.Items)
			{
				Articy_2_2_Tools.ConvertProject(articyData, obj as ProjectType);
				Articy_2_2_Tools.ConvertEntity(articyData, obj as EntityType, export);
				Articy_2_2_Tools.ConvertLocation(articyData, obj as LocationType);
				Articy_2_2_Tools.ConvertFlowFragment(articyData, obj as FlowFragmentType);
				Articy_2_2_Tools.ConvertDialogue(articyData, obj as DialogueType);
				Articy_2_2_Tools.ConvertDialogueFragment(articyData, obj as DialogueFragmentType);
				Articy_2_2_Tools.ConvertHub(articyData, obj as HubType);
				Articy_2_2_Tools.ConvertJump(articyData, obj as JumpType);
				Articy_2_2_Tools.ConvertConnection(articyData, obj as ConnectionType);
				Articy_2_2_Tools.ConvertCondition(articyData, obj as ConditionType);
				Articy_2_2_Tools.ConvertInstruction(articyData, obj as InstructionType);
				Articy_2_2_Tools.ConvertVariableSet(articyData, obj as VariableSetType);
			}
			Articy_2_2_Tools.ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00010B7C File Offset: 0x0000ED7C
		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00010B98 File Offset: 0x0000ED98
		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Id, new ArticyData.Entity(entity.Id, entity.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(entity.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(entity.Text), Articy_2_2_Tools.ConvertFeatures(entity.Features), Vector2.zero, Articy_2_2_Tools.GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00010C00 File Offset: 0x0000EE00
		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Id, new ArticyData.Location(location.Id, location.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(location.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(location.Text), Articy_2_2_Tools.ConvertFeatures(location.Features), Vector2.zero));
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00010C5C File Offset: 0x0000EE5C
		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Id, new ArticyData.FlowFragment(flowFragment.Id, flowFragment.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(flowFragment.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(flowFragment.Text), Articy_2_2_Tools.ConvertFeatures(flowFragment.Features), Vector2.zero, Articy_2_2_Tools.ConvertPins(flowFragment.Pins)));
			}
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00010CC4 File Offset: 0x0000EEC4
		private static void ConvertDialogue(ArticyData articyData, DialogueType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Id, new ArticyData.Dialogue(dialogue.Id, dialogue.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(dialogue.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(dialogue.Text), Articy_2_2_Tools.ConvertFeatures(dialogue.Features), Vector2.zero, Articy_2_2_Tools.ConvertPins(dialogue.Pins), Articy_2_2_Tools.ConvertReferences(dialogue.References), false));
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00010D38 File Offset: 0x0000EF38
		private static void ConvertDialogueFragment(ArticyData articyData, DialogueFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Id, new ArticyData.DialogueFragment(dialogueFragment.Id, dialogueFragment.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(dialogueFragment.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(dialogueFragment.Text), Articy_2_2_Tools.ConvertFeatures(dialogueFragment.Features), Vector2.zero, Articy_2_2_Tools.ConvertLocalizableText(dialogueFragment.MenuText), Articy_2_2_Tools.ConvertLocalizableText(dialogueFragment.StageDirections), Articy_2_2_Tools.ConvertIdRef(dialogueFragment.Speaker), Articy_2_2_Tools.ConvertPins(dialogueFragment.Pins)));
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00010DC0 File Offset: 0x0000EFC0
		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Id, new ArticyData.Hub(hub.Id, hub.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(hub.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(hub.Text), Articy_2_2_Tools.ConvertFeatures(hub.Features), Vector2.zero, Articy_2_2_Tools.ConvertPins(hub.Pins)));
			}
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00010E28 File Offset: 0x0000F028
		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Id, new ArticyData.Jump(jump.Id, jump.TechnicalName, Articy_2_2_Tools.ConvertLocalizableText(jump.DisplayName), Articy_2_2_Tools.ConvertLocalizableText(jump.Text), Articy_2_2_Tools.ConvertFeatures(jump.Features), Vector2.zero, Articy_2_2_Tools.ConvertConnectionRef(jump.Target), Articy_2_2_Tools.ConvertPins(jump.Pins)));
			}
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00010E9C File Offset: 0x0000F09C
		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Id, new ArticyData.Connection(connection.Id, connection.Color, Articy_2_2_Tools.ConvertConnectionRef(connection.Source), Articy_2_2_Tools.ConvertConnectionRef(connection.Target)));
			}
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00010EE8 File Offset: 0x0000F0E8
		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			return (connectionRef == null) ? new ArticyData.ConnectionRef() : new ArticyData.ConnectionRef(connectionRef.IdRef, connectionRef.PinRef);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00010F0C File Offset: 0x0000F10C
		private static void ConvertCondition(ArticyData articyData, ConditionType condition)
		{
			if (condition != null)
			{
				articyData.conditions.Add(condition.Id, new ArticyData.Condition(condition.Id, condition.Expression, Articy_2_2_Tools.ConvertPins(condition.Pins)));
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00010F4C File Offset: 0x0000F14C
		private static void ConvertInstruction(ArticyData articyData, InstructionType instruction)
		{
			if (instruction != null)
			{
				articyData.instructions.Add(instruction.Id, new ArticyData.Instruction(instruction.Id, instruction.Expression, Articy_2_2_Tools.ConvertPins(instruction.Pins)));
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00010F8C File Offset: 0x0000F18C
		private static void ConvertVariableSet(ArticyData articyData, VariableSetType variableSet)
		{
			if (variableSet != null)
			{
				articyData.variableSets.Add(variableSet.Id, new ArticyData.VariableSet(variableSet.Id, variableSet.TechnicalName, Articy_2_2_Tools.ConvertVariables(variableSet.Variables)));
			}
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00010FCC File Offset: 0x0000F1CC
		private static List<ArticyData.Variable> ConvertVariables(VariablesType variables)
		{
			List<ArticyData.Variable> list = new List<ArticyData.Variable>();
			if (variables != null && variables.Variable != null)
			{
				foreach (VariableType variableType in variables.Variable)
				{
					list.Add(new ArticyData.Variable(variableType.TechnicalName, variableType.DefaultValue, Articy_2_2_Tools.ConvertDataType(variableType.DataType)));
				}
			}
			return list;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00011034 File Offset: 0x0000F234
		private static ArticyData.VariableDataType ConvertDataType(VariableDataTypeType dataType)
		{
			if (dataType == VariableDataTypeType.Boolean)
			{
				return ArticyData.VariableDataType.Boolean;
			}
			if (dataType != VariableDataTypeType.Integer)
			{
				Debug.LogWarning(string.Format("{0}: Unexpected variable data type {1}", "Dialogue System", dataType.ToString()));
				return ArticyData.VariableDataType.Boolean;
			}
			return ArticyData.VariableDataType.Integer;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001107C File Offset: 0x0000F27C
		private static ArticyData.LocalizableText ConvertLocalizableText(LocalizableTextType localizableText)
		{
			ArticyData.LocalizableText localizableText2 = new ArticyData.LocalizableText();
			if (localizableText != null && localizableText.LocalizedString != null)
			{
				foreach (LocalizedStringType localizedStringType in localizableText.LocalizedString)
				{
					localizableText2.localizedString.Add(localizedStringType.Lang, ArticyTools.RemoveHtml(localizedStringType.Value));
				}
			}
			return localizableText2;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000110DC File Offset: 0x0000F2DC
		private static ArticyData.LocalizableText ConvertLocalizableText(string s)
		{
			return new ArticyData.LocalizableText
			{
				localizedString = { 
				{
					string.Empty,
					ArticyTools.RemoveHtml(s)
				} }
			};
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00011108 File Offset: 0x0000F308
		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				foreach (ReferenceType referenceType in references.Reference)
				{
					list.Add(Articy_2_2_Tools.ConvertIdRef(referenceType));
				}
			}
			return list;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00011158 File Offset: 0x0000F358
		private static string ConvertIdRef(ReferenceType reference)
		{
			return (reference == null) ? string.Empty : reference.IdRef;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00011170 File Offset: 0x0000F370
		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				foreach (PinType pinType in pins.Pin)
				{
					list.Add(new ArticyData.Pin(pinType.Id, pinType.Index, Articy_2_2_Tools.ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000111DC File Offset: 0x0000F3DC
		private static ArticyData.SemanticType ConvertSemanticType(SemanticType semanticType)
		{
			if (semanticType == SemanticType.Input)
			{
				return ArticyData.SemanticType.Input;
			}
			if (semanticType != SemanticType.Output)
			{
				Debug.LogWarning(string.Format("{0}: Unexpected semantic type {1}", "Dialogue System", semanticType.ToString()));
				return ArticyData.SemanticType.Input;
			}
			return ArticyData.SemanticType.Output;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00011224 File Offset: 0x0000F424
		private static ArticyData.Features ConvertFeatures(FeaturesType features)
		{
			List<ArticyData.Feature> list = new List<ArticyData.Feature>();
			if (features != null && features.Feature != null)
			{
				foreach (FeatureType featureType in features.Feature)
				{
					ArticyData.Feature feature2 = new ArticyData.Feature();
					foreach (PropertiesType propertiesType in featureType.Properties)
					{
						if (propertiesType != null && propertiesType.Items != null && propertiesType.Items.Length > 0)
						{
							List<Field> list2 = new List<Field>();
							foreach (object obj in propertiesType.Items)
							{
								Articy_2_2_Tools.ConvertItem(obj, list2);
							}
							feature2.properties.Add(new ArticyData.Property(list2));
						}
					}
					list.Add(feature2);
				}
			}
			return new ArticyData.Features(list);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00011314 File Offset: 0x0000F514
		private static void ConvertItem(object item, List<Field> fields)
		{
			Type type = item.GetType();
			if (type == typeof(BooleanPropertyType))
			{
				BooleanPropertyType booleanPropertyType = (BooleanPropertyType)item;
				fields.Add(new Field(booleanPropertyType.Name, string.Equals(booleanPropertyType.Value, "1").ToString(), FieldType.Boolean));
			}
			else if (type == typeof(EnumPropertyType))
			{
				EnumPropertyType enumPropertyType = (EnumPropertyType)item;
				if (ArticyTools.IsQuestStateArticyPropertyName(enumPropertyType.Name))
				{
					fields.Add(new Field(enumPropertyType.Name, ArticyTools.EnumValueToQuestState(Tools.StringToInt(enumPropertyType.Value), string.Empty), FieldType.Text));
				}
				else
				{
					fields.Add(new Field(enumPropertyType.Name, enumPropertyType.Value, FieldType.Number));
				}
			}
			else if (type == typeof(LocalizableTextPropertyType))
			{
				LocalizableTextPropertyType localizableTextPropertyType = (LocalizableTextPropertyType)item;
				string name = localizableTextPropertyType.Name;
				if (!string.IsNullOrEmpty(name) && localizableTextPropertyType.LocalizedString != null)
				{
					foreach (LocalizedStringType localizedStringType in localizableTextPropertyType.LocalizedString)
					{
						if (string.IsNullOrEmpty(localizedStringType.Lang))
						{
							fields.Add(new Field(name, localizedStringType.Value, FieldType.Text));
						}
						else
						{
							string text = string.Format("{0} {1}", name, localizedStringType.Lang);
							fields.Add(new Field(text, localizedStringType.Value, FieldType.Localization));
						}
					}
				}
			}
			else if (type == typeof(ReferenceSlotPropertyType))
			{
				ReferenceSlotPropertyType referenceSlotPropertyType = (ReferenceSlotPropertyType)item;
				fields.Add(new Field(referenceSlotPropertyType.Name, referenceSlotPropertyType.IdRef, FieldType.Text));
			}
			else if (type == typeof(NumberPropertyType))
			{
				NumberPropertyType numberPropertyType = (NumberPropertyType)item;
				fields.Add(new Field(numberPropertyType.Name, numberPropertyType.Value, FieldType.Number));
			}
			else if (type == typeof(ReferenceStripPropertyType))
			{
				Debug.LogWarning("Dialogue System: Skipping import of ReferenceStripPropertyType: " + (item as ReferenceStripPropertyType).Name);
			}
			else if (type == typeof(StringPropertyType))
			{
				StringPropertyType stringPropertyType = (StringPropertyType)item;
				fields.Add(new Field(stringPropertyType.Name, stringPropertyType.Value, FieldType.Text));
			}
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00011568 File Offset: 0x0000F768
		private static string GetPictureFilename(ExportType export, PreviewImageType previewImage)
		{
			if (previewImage != null)
			{
				foreach (object obj in export.Content.Items)
				{
					if (obj is AssetType)
					{
						AssetType assetType = obj as AssetType;
						if (string.Equals(assetType.Id, previewImage.IdRef))
						{
							return assetType.OriginalSource;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x000115D0 File Offset: 0x0000F7D0
		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = Articy_2_2_Tools.ConvertNode(hierarchy.Node);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000115E8 File Offset: 0x0000F7E8
		private static ArticyData.Node ConvertNode(NodeType node)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.Id;
				node2.type = Articy_2_2_Tools.ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					foreach (NodeType nodeType in node.Node)
					{
						node2.nodes.Add(Articy_2_2_Tools.ConvertNode(nodeType));
					}
				}
			}
			return node2;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001165C File Offset: 0x0000F85C
		private static ArticyData.NodeType ConvertNodeType(string nodeType)
		{
			if (string.Equals(nodeType, "FlowFragment"))
			{
				return ArticyData.NodeType.FlowFragment;
			}
			if (string.Equals(nodeType, "Dialogue"))
			{
				return ArticyData.NodeType.Dialogue;
			}
			if (string.Equals(nodeType, "DialogueFragment"))
			{
				return ArticyData.NodeType.DialogueFragment;
			}
			if (string.Equals(nodeType, "Hub"))
			{
				return ArticyData.NodeType.Hub;
			}
			if (string.Equals(nodeType, "Jump"))
			{
				return ArticyData.NodeType.Jump;
			}
			if (string.Equals(nodeType, "Connection"))
			{
				return ArticyData.NodeType.Connection;
			}
			if (string.Equals(nodeType, "Condition"))
			{
				return ArticyData.NodeType.Condition;
			}
			if (string.Equals(nodeType, "Instruction"))
			{
				return ArticyData.NodeType.Instruction;
			}
			return ArticyData.NodeType.Other;
		}
	}
}
