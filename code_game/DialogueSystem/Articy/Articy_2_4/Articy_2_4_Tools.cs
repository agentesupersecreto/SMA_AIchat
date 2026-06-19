using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000108 RID: 264
	public static class Articy_2_4_Tools
	{
		// Token: 0x06000B29 RID: 2857 RVA: 0x00014360 File Offset: 0x00012560
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd");
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00014370 File Offset: 0x00012570
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding, bool convertDropdownAsString = false, ConverterPrefs prefs = null)
		{
			return Articy_2_4_Tools.ConvertExportToArticyData(Articy_2_4_Tools.LoadFromXmlData(xmlData, encoding), convertDropdownAsString, prefs);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x00014380 File Offset: 0x00012580
		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportType));
			return xmlSerializer.Deserialize(new StringReader(xmlData)) as ExportType;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x000143B0 File Offset: 0x000125B0
		public static bool IsExportValid(ExportType export)
		{
			return export != null && export.Content != null && export.Content.Items != null;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x000143E4 File Offset: 0x000125E4
		public static ArticyData ConvertExportToArticyData(ExportType export, bool convertDropdownAsString = false, ConverterPrefs prefs = null)
		{
			if (!Articy_2_4_Tools.IsExportValid(export))
			{
				return null;
			}
			Articy_2_4_Tools._convertDropdownAsString = convertDropdownAsString;
			Articy_2_4_Tools._convertSlotsAs = ((prefs == null) ? ConverterPrefs.ConvertSlotsModes.DisplayName : prefs.ConvertSlotsAs);
			Articy_2_4_Tools._currentExport = export;
			Articy_2_4_Tools._prefs = prefs;
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			foreach (object obj in export.Content.Items)
			{
				Articy_2_4_Tools.ConvertProject(articyData, obj as ProjectType);
				Articy_2_4_Tools.ConvertAsset(articyData, obj as AssetType);
				Articy_2_4_Tools.ConvertEntity(articyData, obj as EntityType, export);
				Articy_2_4_Tools.ConvertLocation(articyData, obj as LocationType);
				Articy_2_4_Tools.ConvertFlowFragment(articyData, obj as FlowFragmentType);
				Articy_2_4_Tools.ConvertDocument(articyData, obj as DocumentType);
				Articy_2_4_Tools.ConvertDialogue(articyData, obj as DialogueType);
				Articy_2_4_Tools.ConvertDialogueFragment(articyData, obj as DialogueFragmentType);
				Articy_2_4_Tools.ConvertHub(articyData, obj as HubType);
				Articy_2_4_Tools.ConvertJump(articyData, obj as JumpType);
				Articy_2_4_Tools.ConvertConnection(articyData, obj as ConnectionType);
				Articy_2_4_Tools.ConvertCondition(articyData, obj as ConditionType);
				Articy_2_4_Tools.ConvertInstruction(articyData, obj as InstructionType);
				Articy_2_4_Tools.ConvertVariableSet(articyData, obj as VariableSetType);
			}
			Articy_2_4_Tools.ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00014544 File Offset: 0x00012744
		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00014560 File Offset: 0x00012760
		private static void ConvertAsset(ArticyData articyData, AssetType asset)
		{
			if (asset != null)
			{
				articyData.assets.Add(asset.Id, new ArticyData.Asset(asset.Id, asset.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(asset.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(asset.Text), Articy_2_4_Tools.ConvertFeatures(asset.Features), Vector2.zero, asset.AssetFilename));
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x000145C4 File Offset: 0x000127C4
		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Id, new ArticyData.Entity(entity.Id, entity.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(entity.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(entity.Text), Articy_2_4_Tools.ConvertFeatures(entity.Features), Vector2.zero, Articy_2_4_Tools.GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0001462C File Offset: 0x0001282C
		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Id, new ArticyData.Location(location.Id, location.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(location.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(location.Text), Articy_2_4_Tools.ConvertFeatures(location.Features), Vector2.zero));
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x00014688 File Offset: 0x00012888
		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Id, new ArticyData.FlowFragment(flowFragment.Id, flowFragment.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(flowFragment.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(flowFragment.Text), Articy_2_4_Tools.ConvertFeatures(flowFragment.Features), Vector2.zero, Articy_2_4_Tools.ConvertPins(flowFragment.Pins)));
			}
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x000146F0 File Offset: 0x000128F0
		private static void ConvertDocument(ArticyData articyData, DocumentType document)
		{
			if (document != null)
			{
				articyData.dialogues.Add(document.Id, new ArticyData.Dialogue(document.Id, document.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(document.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(document.Text), new ArticyData.Features(new List<ArticyData.Feature>()), Vector2.zero, new List<ArticyData.Pin>(), new List<string>(), true));
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x00014758 File Offset: 0x00012958
		private static void ConvertDialogue(ArticyData articyData, DialogueType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Id, new ArticyData.Dialogue(dialogue.Id, dialogue.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(dialogue.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(dialogue.Text), Articy_2_4_Tools.ConvertFeatures(dialogue.Features), new Vector2(dialogue.Position.X, dialogue.Position.Y), Articy_2_4_Tools.ConvertPins(dialogue.Pins), Articy_2_4_Tools.ConvertReferences(dialogue.References), false));
			}
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x000147E0 File Offset: 0x000129E0
		private static void ConvertDialogueFragment(ArticyData articyData, DialogueFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Id, new ArticyData.DialogueFragment(dialogueFragment.Id, dialogueFragment.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(dialogueFragment.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(dialogueFragment.Text), Articy_2_4_Tools.ConvertFeatures(dialogueFragment.Features), new Vector2(dialogueFragment.Position.X, dialogueFragment.Position.Y), Articy_2_4_Tools.ConvertLocalizableText(dialogueFragment.MenuText), Articy_2_4_Tools.ConvertLocalizableText(dialogueFragment.StageDirections), Articy_2_4_Tools.ConvertIdRef(dialogueFragment.Speaker), Articy_2_4_Tools.ConvertPins(dialogueFragment.Pins)));
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00014880 File Offset: 0x00012A80
		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Id, new ArticyData.Hub(hub.Id, hub.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(hub.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(hub.Text), Articy_2_4_Tools.ConvertFeatures(hub.Features), new Vector2(hub.Position.X, hub.Position.Y), Articy_2_4_Tools.ConvertPins(hub.Pins)));
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x000148FC File Offset: 0x00012AFC
		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Id, new ArticyData.Jump(jump.Id, jump.TechnicalName, Articy_2_4_Tools.ConvertLocalizableText(jump.DisplayName), Articy_2_4_Tools.ConvertLocalizableText(jump.Text), Articy_2_4_Tools.ConvertFeatures(jump.Features), new Vector2(jump.Position.X, jump.Position.Y), Articy_2_4_Tools.ConvertConnectionRef(jump.Target), Articy_2_4_Tools.ConvertPins(jump.Pins)));
			}
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00014984 File Offset: 0x00012B84
		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Id, new ArticyData.Connection(connection.Id, connection.Color, Articy_2_4_Tools.ConvertConnectionRef(connection.Source), Articy_2_4_Tools.ConvertConnectionRef(connection.Target)));
			}
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x000149D0 File Offset: 0x00012BD0
		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			return (connectionRef == null) ? new ArticyData.ConnectionRef() : new ArticyData.ConnectionRef(connectionRef.IdRef, connectionRef.PinRef);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x000149F4 File Offset: 0x00012BF4
		private static void ConvertCondition(ArticyData articyData, ConditionType condition)
		{
			if (condition != null)
			{
				articyData.conditions.Add(condition.Id, new ArticyData.Condition(condition.Id, condition.Expression, Articy_2_4_Tools.ConvertPins(condition.Pins), new Vector2(condition.Position.X, condition.Position.Y)));
			}
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00014A50 File Offset: 0x00012C50
		private static void ConvertInstruction(ArticyData articyData, InstructionType instruction)
		{
			if (instruction != null)
			{
				articyData.instructions.Add(instruction.Id, new ArticyData.Instruction(instruction.Id, instruction.Expression, Articy_2_4_Tools.ConvertPins(instruction.Pins), new Vector2(instruction.Position.X, instruction.Position.Y)));
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x00014AAC File Offset: 0x00012CAC
		private static void ConvertVariableSet(ArticyData articyData, VariableSetType variableSet)
		{
			if (variableSet != null)
			{
				articyData.variableSets.Add(variableSet.Id, new ArticyData.VariableSet(variableSet.Id, variableSet.TechnicalName, Articy_2_4_Tools.ConvertVariables(variableSet.Variables)));
			}
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00014AEC File Offset: 0x00012CEC
		private static List<ArticyData.Variable> ConvertVariables(VariablesType variables)
		{
			List<ArticyData.Variable> list = new List<ArticyData.Variable>();
			if (variables != null && variables.Variable != null)
			{
				foreach (VariableType variableType in variables.Variable)
				{
					list.Add(new ArticyData.Variable(variableType.TechnicalName, variableType.DefaultValue, Articy_2_4_Tools.ConvertDataType(variableType.DataType), Articy_2_4_Tools.GetDefaultLocalizedString(variableType.Description)));
				}
			}
			return list;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00014B60 File Offset: 0x00012D60
		private static ArticyData.VariableDataType ConvertDataType(VariableDataTypeType dataType)
		{
			switch (dataType)
			{
			case VariableDataTypeType.Boolean:
				return ArticyData.VariableDataType.Boolean;
			case VariableDataTypeType.Integer:
				return ArticyData.VariableDataType.Integer;
			case VariableDataTypeType.String:
				return ArticyData.VariableDataType.String;
			default:
				Debug.LogWarning(string.Format("{0}: Unexpected variable data type {1}", "Dialogue System", dataType.ToString()));
				return ArticyData.VariableDataType.Boolean;
			}
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00014BAC File Offset: 0x00012DAC
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

		// Token: 0x06000B40 RID: 2880 RVA: 0x00014C0C File Offset: 0x00012E0C
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

		// Token: 0x06000B41 RID: 2881 RVA: 0x00014C38 File Offset: 0x00012E38
		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				foreach (ReferenceType referenceType in references.Reference)
				{
					list.Add(Articy_2_4_Tools.ConvertIdRef(referenceType));
				}
			}
			return list;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00014C88 File Offset: 0x00012E88
		private static string ConvertIdRef(ReferenceType reference)
		{
			return (reference == null) ? string.Empty : reference.IdRef;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00014CA0 File Offset: 0x00012EA0
		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				foreach (PinType pinType in pins.Pin)
				{
					list.Add(new ArticyData.Pin(pinType.Id, pinType.Index, Articy_2_4_Tools.ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x00014D0C File Offset: 0x00012F0C
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

		// Token: 0x06000B45 RID: 2885 RVA: 0x00014D54 File Offset: 0x00012F54
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
								Articy_2_4_Tools.ConvertItem(obj, list2);
							}
							feature2.properties.Add(new ArticyData.Property(list2));
						}
					}
					list.Add(feature2);
				}
			}
			return new ArticyData.Features(list);
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00014E44 File Offset: 0x00013044
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
					fields.Add(new Field(enumPropertyType.Name, ArticyTools.EnumValueToQuestState(Tools.StringToInt(enumPropertyType.Value), Articy_2_4_Tools.GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value))), FieldType.Text));
				}
				else
				{
					bool flag = Articy_2_4_Tools._convertDropdownAsString;
					if (Articy_2_4_Tools._prefs != null)
					{
						ConversionSettings.DropdownOverrideMode mode = Articy_2_4_Tools._prefs.ConversionSettings.GetDropdownOverrideSetting(enumPropertyType.Name).mode;
						if (mode != ConversionSettings.DropdownOverrideMode.Int)
						{
							if (mode == ConversionSettings.DropdownOverrideMode.String)
							{
								flag = true;
							}
						}
						else
						{
							flag = false;
						}
					}
					if (flag)
					{
						fields.Add(new Field(enumPropertyType.Name, Articy_2_4_Tools.GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value)), FieldType.Text));
					}
					else
					{
						fields.Add(new Field(enumPropertyType.Name, enumPropertyType.Value, FieldType.Number));
					}
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
				if (Articy_2_4_Tools._convertSlotsAs == ConverterPrefs.ConvertSlotsModes.DisplayName)
				{
					fields.Add(new Field(referenceSlotPropertyType.Name, Articy_2_4_Tools.GetDisplayName(referenceSlotPropertyType.IdRef), FieldType.Text));
				}
				else
				{
					fields.Add(new Field(referenceSlotPropertyType.Name, referenceSlotPropertyType.IdRef, FieldType.Text));
				}
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

		// Token: 0x06000B47 RID: 2887 RVA: 0x0001515C File Offset: 0x0001335C
		private static string GetEnumStringValue(string enumName, int enumIndex)
		{
			int num = enumIndex;
			foreach (object obj in Articy_2_4_Tools._currentExport.Content.Items)
			{
				if (obj is EnumerationPropertyDefinitionType)
				{
					EnumerationPropertyDefinitionType enumerationPropertyDefinitionType = obj as EnumerationPropertyDefinitionType;
					if (string.Equals(enumerationPropertyDefinitionType.TechnicalName, enumName) && enumerationPropertyDefinitionType.Values != null && enumerationPropertyDefinitionType.Values.EnumValue != null)
					{
						foreach (EnumValueType enumValueType in enumerationPropertyDefinitionType.Values.EnumValue)
						{
							if (enumValueType.Value == num)
							{
								return enumValueType.TechnicalName;
							}
						}
					}
				}
			}
			return enumIndex.ToString();
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00015220 File Offset: 0x00013420
		private static string GetDisplayName(string idRef)
		{
			foreach (object obj in Articy_2_4_Tools._currentExport.Content.Items)
			{
				if (obj is EntityType && string.Equals((obj as EntityType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as EntityType).DisplayName);
				}
				if (obj is FlowFragmentType && string.Equals((obj as FlowFragmentType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as FlowFragmentType).DisplayName);
				}
				if (obj is DialogueType && string.Equals((obj as DialogueType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as DialogueType).DisplayName);
				}
				if (obj is DialogueFragmentType && string.Equals((obj as DialogueFragmentType).Id, idRef))
				{
					return (obj as DialogueFragmentType).DisplayName;
				}
				if (obj is HubType && string.Equals((obj as HubType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as HubType).DisplayName);
				}
				if (obj is JumpType && string.Equals((obj as JumpType).Id, idRef))
				{
					return (obj as JumpType).DisplayName;
				}
				if (obj is ZoneType && string.Equals((obj as ZoneType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as ZoneType).DisplayName);
				}
				if (obj is LocationType && string.Equals((obj as LocationType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as LocationType).DisplayName);
				}
				if (obj is SpotType && string.Equals((obj as SpotType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as SpotType).DisplayName);
				}
				if (obj is JourneyType && string.Equals((obj as JourneyType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as JourneyType).DisplayName);
				}
				if (obj is AssetType && string.Equals((obj as AssetType).Id, idRef))
				{
					return Articy_2_4_Tools.GetDefaultLocalizedString((obj as AssetType).DisplayName);
				}
			}
			return idRef;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00015474 File Offset: 0x00013674
		private static string GetDefaultLocalizedString(LocalizableTextType localizableText)
		{
			if (localizableText == null || localizableText.LocalizedString == null || localizableText.LocalizedString.Length < 1)
			{
				return string.Empty;
			}
			return localizableText.LocalizedString[0].Value;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x000154B4 File Offset: 0x000136B4
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

		// Token: 0x06000B4B RID: 2891 RVA: 0x0001551C File Offset: 0x0001371C
		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = Articy_2_4_Tools.ConvertNode(hierarchy.Node);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00015534 File Offset: 0x00013734
		private static ArticyData.Node ConvertNode(NodeType node)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.IdRef;
				node2.type = Articy_2_4_Tools.ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					foreach (NodeType nodeType in node.Node)
					{
						node2.nodes.Add(Articy_2_4_Tools.ConvertNode(nodeType));
					}
				}
			}
			return node2;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x000155A8 File Offset: 0x000137A8
		private static ArticyData.NodeType ConvertNodeType(string nodeType)
		{
			if (string.Equals(nodeType, "FlowFragment"))
			{
				return ArticyData.NodeType.FlowFragment;
			}
			if (string.Equals(nodeType, "Dialogue") || string.Equals(nodeType, "Document"))
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

		// Token: 0x0400062D RID: 1581
		private static bool _convertDropdownAsString = true;

		// Token: 0x0400062E RID: 1582
		private static ConverterPrefs.ConvertSlotsModes _convertSlotsAs;

		// Token: 0x0400062F RID: 1583
		private static ExportType _currentExport;

		// Token: 0x04000630 RID: 1584
		private static ConverterPrefs _prefs;
	}
}
