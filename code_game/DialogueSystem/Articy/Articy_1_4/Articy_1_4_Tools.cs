using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000051 RID: 81
	public static class Articy_1_4_Tools
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd");
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000DDFC File Offset: 0x0000BFFC
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding)
		{
			return Articy_1_4_Tools.ConvertExportToArticyData(Articy_1_4_Tools.LoadFromXmlData(xmlData, encoding));
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000DE0C File Offset: 0x0000C00C
		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportType));
			return xmlSerializer.Deserialize(new StringReader(xmlData)) as ExportType;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000DE3C File Offset: 0x0000C03C
		public static bool IsExportValid(ExportType export)
		{
			return export != null && export.Content != null && export.Content.Items != null;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000DE70 File Offset: 0x0000C070
		public static ArticyData ConvertExportToArticyData(ExportType export)
		{
			if (!Articy_1_4_Tools.IsExportValid(export))
			{
				return null;
			}
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			foreach (object obj in export.Content.Items)
			{
				Articy_1_4_Tools.ConvertProject(articyData, obj as ProjectType);
				Articy_1_4_Tools.ConvertEntity(articyData, obj as EntityType, export);
				Articy_1_4_Tools.ConvertLocation(articyData, obj as LocationType);
				Articy_1_4_Tools.ConvertFlowFragment(articyData, obj as FlowFragmentType);
				Articy_1_4_Tools.ConvertDialog(articyData, obj as DialogType);
				Articy_1_4_Tools.ConvertDialogFragment(articyData, obj as DialogFragmentType);
				Articy_1_4_Tools.ConvertHub(articyData, obj as HubType);
				Articy_1_4_Tools.ConvertJump(articyData, obj as JumpType);
				Articy_1_4_Tools.ConvertConnection(articyData, obj as ConnectionType);
			}
			Articy_1_4_Tools.ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000DF6C File Offset: 0x0000C16C
		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000DF88 File Offset: 0x0000C188
		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Guid, new ArticyData.Entity(entity.Guid, entity.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(entity.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(entity.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000DFEC File Offset: 0x0000C1EC
		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Guid, new ArticyData.Location(location.Guid, location.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(location.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(location.Text), new ArticyData.Features(), Vector2.zero));
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000E044 File Offset: 0x0000C244
		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Guid, new ArticyData.FlowFragment(flowFragment.Guid, flowFragment.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(flowFragment.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(flowFragment.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.ConvertPins(flowFragment.Pins)));
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000E0A4 File Offset: 0x0000C2A4
		private static void ConvertDialog(ArticyData articyData, DialogType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Guid, new ArticyData.Dialogue(dialogue.Guid, dialogue.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(dialogue.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(dialogue.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.ConvertPins(dialogue.Pins), Articy_1_4_Tools.ConvertReferences(dialogue.References), false));
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000E110 File Offset: 0x0000C310
		private static void ConvertDialogFragment(ArticyData articyData, DialogFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Guid, new ArticyData.DialogueFragment(dialogueFragment.Guid, dialogueFragment.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(dialogueFragment.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(dialogueFragment.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.ConvertLocalizableText(dialogueFragment.PreviewText), Articy_1_4_Tools.ConvertLocalizableText(dialogueFragment.StageDirections), Articy_1_4_Tools.ConvertIdRef(dialogueFragment.Entity), Articy_1_4_Tools.ConvertPins(dialogueFragment.Pins)));
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000E194 File Offset: 0x0000C394
		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Guid, new ArticyData.Hub(hub.Guid, hub.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(hub.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(hub.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.ConvertPins(hub.Pins)));
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000E1F4 File Offset: 0x0000C3F4
		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Guid, new ArticyData.Jump(jump.Guid, jump.TechnicalName, Articy_1_4_Tools.ConvertLocalizableText(jump.DisplayName), Articy_1_4_Tools.ConvertLocalizableText(jump.Text), new ArticyData.Features(), Vector2.zero, Articy_1_4_Tools.ConvertConnectionRef(jump.Target), Articy_1_4_Tools.ConvertPins(jump.Pins)));
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000E260 File Offset: 0x0000C460
		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Guid, new ArticyData.Connection(connection.Guid, string.Empty, Articy_1_4_Tools.ConvertConnectionRef(connection.Source), Articy_1_4_Tools.ConvertConnectionRef(connection.Target)));
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000E2AC File Offset: 0x0000C4AC
		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			return (connectionRef == null) ? new ArticyData.ConnectionRef() : new ArticyData.ConnectionRef(connectionRef.GuidRef, connectionRef.PinRef);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000E2D0 File Offset: 0x0000C4D0
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

		// Token: 0x060002DD RID: 733 RVA: 0x0000E330 File Offset: 0x0000C530
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

		// Token: 0x060002DE RID: 734 RVA: 0x0000E35C File Offset: 0x0000C55C
		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				foreach (ReferenceType referenceType in references.Reference)
				{
					list.Add(Articy_1_4_Tools.ConvertIdRef(referenceType));
				}
			}
			return list;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000E3AC File Offset: 0x0000C5AC
		private static string ConvertIdRef(ReferenceType reference)
		{
			return (reference == null) ? string.Empty : reference.GuidRef;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000E3C4 File Offset: 0x0000C5C4
		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				foreach (PinType pinType in pins.Pin)
				{
					list.Add(new ArticyData.Pin(pinType.Guid, pinType.Index, Articy_1_4_Tools.ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000E430 File Offset: 0x0000C630
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

		// Token: 0x060002E2 RID: 738 RVA: 0x0000E478 File Offset: 0x0000C678
		private static string GetPictureFilename(ExportType export, PreviewImageType previewImage)
		{
			if (previewImage != null)
			{
				foreach (object obj in export.Content.Items)
				{
					if (obj is AssetType)
					{
						AssetType assetType = obj as AssetType;
						if (string.Equals(assetType.Guid, previewImage.GuidRef))
						{
							return assetType.AssetFilename;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = Articy_1_4_Tools.ConvertNode(hierarchy.Node, "  ");
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000E500 File Offset: 0x0000C700
		private static ArticyData.Node ConvertNode(NodeType node, string indent)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.Guid;
				node2.type = Articy_1_4_Tools.ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					foreach (NodeType nodeType in node.Node)
					{
						node2.nodes.Add(Articy_1_4_Tools.ConvertNode(nodeType, "  " + indent));
					}
				}
			}
			return node2;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000E580 File Offset: 0x0000C780
		private static ArticyData.NodeType ConvertNodeType(string nodeType)
		{
			if (string.Equals(nodeType, "Dialog"))
			{
				return ArticyData.NodeType.Dialogue;
			}
			if (string.Equals(nodeType, "DialogFragment"))
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
			return ArticyData.NodeType.Other;
		}
	}
}
