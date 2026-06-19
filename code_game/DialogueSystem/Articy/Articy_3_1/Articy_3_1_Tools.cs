using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000187 RID: 391
	public static class Articy_3_1_Tools
	{
		// Token: 0x0600117B RID: 4475 RVA: 0x00019388 File Offset: 0x00017588
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd");
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x00019398 File Offset: 0x00017598
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding, bool convertDropdownAsString = false, ConverterPrefs prefs = null)
		{
			return Articy_3_1_Tools.ConvertExportToArticyData(Articy_3_1_Tools.LoadFromXmlData(xmlData, encoding), convertDropdownAsString, prefs);
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x000193A8 File Offset: 0x000175A8
		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportType));
			return xmlSerializer.Deserialize(new StringReader(xmlData)) as ExportType;
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x000193D8 File Offset: 0x000175D8
		public static bool IsExportValid(ExportType export)
		{
			return export != null && export.Content != null && export.Content.Items != null;
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x0001940C File Offset: 0x0001760C
		public static ArticyData ConvertExportToArticyData(ExportType export, bool convertDropdownAsString = false, ConverterPrefs prefs = null)
		{
			if (!Articy_3_1_Tools.IsExportValid(export))
			{
				return null;
			}
			Articy_3_1_Tools._convertDropdownAsString = convertDropdownAsString;
			Articy_3_1_Tools._convertSlotsAs = ((prefs == null) ? ConverterPrefs.ConvertSlotsModes.DisplayName : prefs.ConvertSlotsAs);
			Articy_3_1_Tools._currentExport = export;
			Articy_3_1_Tools._prefs = prefs;
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			foreach (object obj in export.Content.Items)
			{
				Articy_3_1_Tools.ConvertProject(articyData, obj as ProjectType);
				Articy_3_1_Tools.ConvertAsset(articyData, obj as AssetType);
				Articy_3_1_Tools.ConvertEntity(articyData, obj as EntityType, export);
				Articy_3_1_Tools.ConvertLocation(articyData, obj as LocationType);
				Articy_3_1_Tools.ConvertFlowFragment(articyData, obj as FlowFragmentType);
				Articy_3_1_Tools.ConvertDocument(articyData, obj as DocumentType);
				Articy_3_1_Tools.ConvertDialogue(articyData, obj as DialogueType);
				Articy_3_1_Tools.ConvertDialogueFragment(articyData, obj as DialogueFragmentType);
				Articy_3_1_Tools.ConvertHub(articyData, obj as HubType);
				Articy_3_1_Tools.ConvertJump(articyData, obj as JumpType);
				Articy_3_1_Tools.ConvertConnection(articyData, obj as ConnectionType);
				Articy_3_1_Tools.ConvertCondition(articyData, obj as ConditionType);
				Articy_3_1_Tools.ConvertInstruction(articyData, obj as InstructionType);
				Articy_3_1_Tools.ConvertVariableSet(articyData, obj as VariableSetType);
			}
			Articy_3_1_Tools.ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x0001956C File Offset: 0x0001776C
		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x00019588 File Offset: 0x00017788
		private static void ConvertAsset(ArticyData articyData, AssetType asset)
		{
			if (asset != null)
			{
				articyData.assets.Add(asset.Id, new ArticyData.Asset(asset.Id, asset.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(asset.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(asset.Text), Articy_3_1_Tools.ConvertFeatures(asset.Features), Vector2.zero, asset.AssetFilename));
			}
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x000195EC File Offset: 0x000177EC
		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Id, new ArticyData.Entity(entity.Id, entity.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(entity.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(entity.Text), Articy_3_1_Tools.ConvertFeatures(entity.Features), Vector2.zero, Articy_3_1_Tools.GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x00019654 File Offset: 0x00017854
		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Id, new ArticyData.Location(location.Id, location.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(location.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(location.Text), Articy_3_1_Tools.ConvertFeatures(location.Features), Vector2.zero));
			}
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x000196B0 File Offset: 0x000178B0
		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Id, new ArticyData.FlowFragment(flowFragment.Id, flowFragment.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(flowFragment.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(flowFragment.Text), Articy_3_1_Tools.ConvertFeatures(flowFragment.Features), Vector2.zero, Articy_3_1_Tools.ConvertPins(flowFragment.Pins)));
			}
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x00019718 File Offset: 0x00017918
		private static void ConvertDocument(ArticyData articyData, DocumentType document)
		{
			if (document != null)
			{
				articyData.dialogues.Add(document.Id, new ArticyData.Dialogue(document.Id, document.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(document.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(document.Text), new ArticyData.Features(new List<ArticyData.Feature>()), Vector2.zero, new List<ArticyData.Pin>(), new List<string>(), true));
			}
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x00019780 File Offset: 0x00017980
		private static void ConvertDialogue(ArticyData articyData, DialogueType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Id, new ArticyData.Dialogue(dialogue.Id, dialogue.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(dialogue.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(dialogue.Text), Articy_3_1_Tools.ConvertFeatures(dialogue.Features), new Vector2(dialogue.Position.X, dialogue.Position.Y), Articy_3_1_Tools.ConvertPins(dialogue.Pins), Articy_3_1_Tools.ConvertReferences(dialogue.References), false));
			}
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x00019808 File Offset: 0x00017A08
		private static void ConvertDialogueFragment(ArticyData articyData, DialogueFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Id, new ArticyData.DialogueFragment(dialogueFragment.Id, dialogueFragment.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(dialogueFragment.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(dialogueFragment.Text), Articy_3_1_Tools.ConvertFeatures(dialogueFragment.Features), new Vector2(dialogueFragment.Position.X, dialogueFragment.Position.Y), Articy_3_1_Tools.ConvertLocalizableText(dialogueFragment.MenuText), Articy_3_1_Tools.ConvertLocalizableText(dialogueFragment.StageDirections), Articy_3_1_Tools.ConvertIdRef(dialogueFragment.Speaker), Articy_3_1_Tools.ConvertPins(dialogueFragment.Pins)));
			}
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x000198A8 File Offset: 0x00017AA8
		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Id, new ArticyData.Hub(hub.Id, hub.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(hub.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(hub.Text), Articy_3_1_Tools.ConvertFeatures(hub.Features), new Vector2(hub.Position.X, hub.Position.Y), Articy_3_1_Tools.ConvertPins(hub.Pins)));
			}
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x00019924 File Offset: 0x00017B24
		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Id, new ArticyData.Jump(jump.Id, jump.TechnicalName, Articy_3_1_Tools.ConvertLocalizableText(jump.DisplayName), Articy_3_1_Tools.ConvertLocalizableText(jump.Text), Articy_3_1_Tools.ConvertFeatures(jump.Features), new Vector2(jump.Position.X, jump.Position.Y), Articy_3_1_Tools.ConvertConnectionRef(jump.Target), Articy_3_1_Tools.ConvertPins(jump.Pins)));
			}
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x000199AC File Offset: 0x00017BAC
		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Id, new ArticyData.Connection(connection.Id, connection.Color, Articy_3_1_Tools.ConvertConnectionRef(connection.Source), Articy_3_1_Tools.ConvertConnectionRef(connection.Target)));
			}
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x000199F8 File Offset: 0x00017BF8
		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			return (connectionRef == null) ? new ArticyData.ConnectionRef() : new ArticyData.ConnectionRef(connectionRef.IdRef, connectionRef.PinRef);
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x00019A1C File Offset: 0x00017C1C
		private static void ConvertCondition(ArticyData articyData, ConditionType condition)
		{
			if (condition != null)
			{
				articyData.conditions.Add(condition.Id, new ArticyData.Condition(condition.Id, condition.Expression, Articy_3_1_Tools.ConvertPins(condition.Pins), new Vector2(condition.Position.X, condition.Position.Y)));
			}
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00019A78 File Offset: 0x00017C78
		private static void ConvertInstruction(ArticyData articyData, InstructionType instruction)
		{
			if (instruction != null)
			{
				articyData.instructions.Add(instruction.Id, new ArticyData.Instruction(instruction.Id, instruction.Expression, Articy_3_1_Tools.ConvertPins(instruction.Pins), new Vector2(instruction.Position.X, instruction.Position.Y)));
			}
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x00019AD4 File Offset: 0x00017CD4
		private static void ConvertVariableSet(ArticyData articyData, VariableSetType variableSet)
		{
			if (variableSet != null)
			{
				articyData.variableSets.Add(variableSet.Id, new ArticyData.VariableSet(variableSet.Id, variableSet.TechnicalName, Articy_3_1_Tools.ConvertVariables(variableSet.Variables)));
			}
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x00019B14 File Offset: 0x00017D14
		private static List<ArticyData.Variable> ConvertVariables(VariablesType variables)
		{
			List<ArticyData.Variable> list = new List<ArticyData.Variable>();
			if (variables != null && variables.Variable != null)
			{
				foreach (VariableType variableType in variables.Variable)
				{
					list.Add(new ArticyData.Variable(variableType.TechnicalName, variableType.DefaultValue, Articy_3_1_Tools.ConvertDataType(variableType.DataType), Articy_3_1_Tools.GetDefaultLocalizedString(variableType.Description)));
				}
			}
			return list;
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x00019B88 File Offset: 0x00017D88
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

		// Token: 0x06001191 RID: 4497 RVA: 0x00019BD4 File Offset: 0x00017DD4
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

		// Token: 0x06001192 RID: 4498 RVA: 0x00019C34 File Offset: 0x00017E34
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

		// Token: 0x06001193 RID: 4499 RVA: 0x00019C60 File Offset: 0x00017E60
		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				foreach (ReferenceType referenceType in references.Reference)
				{
					list.Add(Articy_3_1_Tools.ConvertIdRef(referenceType));
				}
			}
			return list;
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x00019CB0 File Offset: 0x00017EB0
		private static string ConvertIdRef(ReferenceType reference)
		{
			return (reference == null) ? string.Empty : reference.IdRef;
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x00019CC8 File Offset: 0x00017EC8
		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				foreach (PinType pinType in pins.Pin)
				{
					list.Add(new ArticyData.Pin(pinType.Id, pinType.Index, Articy_3_1_Tools.ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		// Token: 0x06001196 RID: 4502 RVA: 0x00019D34 File Offset: 0x00017F34
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

		// Token: 0x06001197 RID: 4503 RVA: 0x00019D7C File Offset: 0x00017F7C
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
								Articy_3_1_Tools.ConvertItem(obj, list2);
							}
							feature2.properties.Add(new ArticyData.Property(list2));
						}
					}
					list.Add(feature2);
				}
			}
			return new ArticyData.Features(list);
		}

		// Token: 0x06001198 RID: 4504 RVA: 0x00019E6C File Offset: 0x0001806C
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
					fields.Add(new Field(enumPropertyType.Name, ArticyTools.EnumValueToQuestState(Tools.StringToInt(enumPropertyType.Value), Articy_3_1_Tools.GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value))), FieldType.Text));
				}
				else
				{
					bool flag = Articy_3_1_Tools._convertDropdownAsString;
					if (Articy_3_1_Tools._prefs != null)
					{
						ConversionSettings.DropdownOverrideMode mode = Articy_3_1_Tools._prefs.ConversionSettings.GetDropdownOverrideSetting(enumPropertyType.Name).mode;
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
						fields.Add(new Field(enumPropertyType.Name, Articy_3_1_Tools.GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value)), FieldType.Text));
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
				if (Articy_3_1_Tools._convertSlotsAs == ConverterPrefs.ConvertSlotsModes.DisplayName)
				{
					fields.Add(new Field(referenceSlotPropertyType.Name, Articy_3_1_Tools.GetDisplayName(referenceSlotPropertyType.IdRef), FieldType.Text));
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

		// Token: 0x06001199 RID: 4505 RVA: 0x0001A184 File Offset: 0x00018384
		private static string GetEnumStringValue(string enumName, int enumIndex)
		{
			int num = enumIndex;
			foreach (object obj in Articy_3_1_Tools._currentExport.Content.Items)
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

		// Token: 0x0600119A RID: 4506 RVA: 0x0001A248 File Offset: 0x00018448
		private static string GetDisplayName(string idRef)
		{
			foreach (object obj in Articy_3_1_Tools._currentExport.Content.Items)
			{
				if (obj is EntityType && string.Equals((obj as EntityType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as EntityType).DisplayName);
				}
				if (obj is FlowFragmentType && string.Equals((obj as FlowFragmentType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as FlowFragmentType).DisplayName);
				}
				if (obj is DialogueType && string.Equals((obj as DialogueType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as DialogueType).DisplayName);
				}
				if (obj is DialogueFragmentType && string.Equals((obj as DialogueFragmentType).Id, idRef))
				{
					return (obj as DialogueFragmentType).DisplayName;
				}
				if (obj is HubType && string.Equals((obj as HubType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as HubType).DisplayName);
				}
				if (obj is JumpType && string.Equals((obj as JumpType).Id, idRef))
				{
					return (obj as JumpType).DisplayName;
				}
				if (obj is ZoneType && string.Equals((obj as ZoneType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as ZoneType).DisplayName);
				}
				if (obj is LocationType && string.Equals((obj as LocationType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as LocationType).DisplayName);
				}
				if (obj is SpotType && string.Equals((obj as SpotType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as SpotType).DisplayName);
				}
				if (obj is JourneyType && string.Equals((obj as JourneyType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as JourneyType).DisplayName);
				}
				if (obj is AssetType && string.Equals((obj as AssetType).Id, idRef))
				{
					return Articy_3_1_Tools.GetDefaultLocalizedString((obj as AssetType).DisplayName);
				}
			}
			return idRef;
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0001A49C File Offset: 0x0001869C
		private static string GetDefaultLocalizedString(LocalizableTextType localizableText)
		{
			if (localizableText == null || localizableText.LocalizedString == null || localizableText.LocalizedString.Length < 1)
			{
				return string.Empty;
			}
			return localizableText.LocalizedString[0].Value;
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0001A4DC File Offset: 0x000186DC
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

		// Token: 0x0600119D RID: 4509 RVA: 0x0001A544 File Offset: 0x00018744
		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = Articy_3_1_Tools.ConvertNode(hierarchy.Node);
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0001A55C File Offset: 0x0001875C
		private static ArticyData.Node ConvertNode(NodeType node)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.IdRef;
				node2.type = Articy_3_1_Tools.ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					foreach (NodeType nodeType in node.Node)
					{
						node2.nodes.Add(Articy_3_1_Tools.ConvertNode(nodeType));
					}
				}
			}
			return node2;
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0001A5D0 File Offset: 0x000187D0
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

		// Token: 0x040009B9 RID: 2489
		private static bool _convertDropdownAsString = true;

		// Token: 0x040009BA RID: 2490
		private static ConverterPrefs.ConvertSlotsModes _convertSlotsAs;

		// Token: 0x040009BB RID: 2491
		private static ExportType _currentExport;

		// Token: 0x040009BC RID: 2492
		private static ConverterPrefs _prefs;
	}
}
