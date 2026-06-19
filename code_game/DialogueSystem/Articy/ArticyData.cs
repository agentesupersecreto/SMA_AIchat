using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000029 RID: 41
	public class ArticyData
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000CB74 File Offset: 0x0000AD74
		public string ProjectTitle
		{
			get
			{
				return this.project.displayName;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000CB84 File Offset: 0x0000AD84
		public string ProjectVersion
		{
			get
			{
				return this.project.createdOn;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0000CB94 File Offset: 0x0000AD94
		public string ProjectAuthor
		{
			get
			{
				return string.Format("{0} {1}", this.project.creatorTool, this.project.creatorVersion);
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
		public static string FullVariableName(ArticyData.VariableSet variableSet, ArticyData.Variable variable)
		{
			return (variableSet == null || variable == null) ? string.Empty : string.Format("{0}.{1}", variableSet.technicalName, variable.technicalName);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000CC00 File Offset: 0x0000AE00
		public static ConditionPriority ColorToPriority(string color)
		{
			if (string.Equals(color, "#FF0000"))
			{
				return ConditionPriority.High;
			}
			if (string.Equals(color, "#FFC000"))
			{
				return ConditionPriority.AboveNormal;
			}
			if (string.Equals(color, "#FFFF00"))
			{
				return ConditionPriority.BelowNormal;
			}
			if (string.Equals(color, "#92D050"))
			{
				return ConditionPriority.Low;
			}
			return ConditionPriority.Normal;
		}

		// Token: 0x040000F2 RID: 242
		public const string HighPriorityColor = "#FF0000";

		// Token: 0x040000F3 RID: 243
		public const string AboveNormalPriorityColor = "#FFC000";

		// Token: 0x040000F4 RID: 244
		public const string BelowNormalPriorityColor = "#FFFF00";

		// Token: 0x040000F5 RID: 245
		public const string LowPriorityColor = "#92D050";

		// Token: 0x040000F6 RID: 246
		public ArticyData.Project project = new ArticyData.Project();

		// Token: 0x040000F7 RID: 247
		public Dictionary<string, ArticyData.Asset> assets = new Dictionary<string, ArticyData.Asset>();

		// Token: 0x040000F8 RID: 248
		public Dictionary<string, ArticyData.Entity> entities = new Dictionary<string, ArticyData.Entity>();

		// Token: 0x040000F9 RID: 249
		public Dictionary<string, ArticyData.Location> locations = new Dictionary<string, ArticyData.Location>();

		// Token: 0x040000FA RID: 250
		public Dictionary<string, ArticyData.FlowFragment> flowFragments = new Dictionary<string, ArticyData.FlowFragment>();

		// Token: 0x040000FB RID: 251
		public Dictionary<string, ArticyData.Dialogue> dialogues = new Dictionary<string, ArticyData.Dialogue>();

		// Token: 0x040000FC RID: 252
		public Dictionary<string, ArticyData.DialogueFragment> dialogueFragments = new Dictionary<string, ArticyData.DialogueFragment>();

		// Token: 0x040000FD RID: 253
		public Dictionary<string, ArticyData.Hub> hubs = new Dictionary<string, ArticyData.Hub>();

		// Token: 0x040000FE RID: 254
		public Dictionary<string, ArticyData.Jump> jumps = new Dictionary<string, ArticyData.Jump>();

		// Token: 0x040000FF RID: 255
		public Dictionary<string, ArticyData.Connection> connections = new Dictionary<string, ArticyData.Connection>();

		// Token: 0x04000100 RID: 256
		public Dictionary<string, ArticyData.Condition> conditions = new Dictionary<string, ArticyData.Condition>();

		// Token: 0x04000101 RID: 257
		public Dictionary<string, ArticyData.Instruction> instructions = new Dictionary<string, ArticyData.Instruction>();

		// Token: 0x04000102 RID: 258
		public Dictionary<string, ArticyData.VariableSet> variableSets = new Dictionary<string, ArticyData.VariableSet>();

		// Token: 0x04000103 RID: 259
		public ArticyData.Hierarchy hierarchy = new ArticyData.Hierarchy();

		// Token: 0x0200002A RID: 42
		public class LocalizableText
		{
			// Token: 0x17000071 RID: 113
			// (get) Token: 0x06000260 RID: 608 RVA: 0x0000CC6C File Offset: 0x0000AE6C
			public string DefaultText
			{
				get
				{
					return (!this.localizedString.ContainsKey(string.Empty)) ? string.Empty : this.localizedString[string.Empty];
				}
			}

			// Token: 0x04000104 RID: 260
			public Dictionary<string, string> localizedString = new Dictionary<string, string>();
		}

		// Token: 0x0200002B RID: 43
		public class Element
		{
			// Token: 0x06000261 RID: 609 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
			public Element()
			{
				this.id = string.Empty;
				this.technicalName = string.Empty;
				this.displayName = new ArticyData.LocalizableText();
				this.text = new ArticyData.LocalizableText();
				this.features = new ArticyData.Features();
				this.position = Vector2.zero;
			}

			// Token: 0x06000262 RID: 610 RVA: 0x0000CCF8 File Offset: 0x0000AEF8
			public Element(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position)
			{
				this.id = id;
				this.technicalName = technicalName;
				this.displayName = displayName;
				this.text = text;
				this.features = features;
				this.position = position;
			}

			// Token: 0x04000105 RID: 261
			public string id;

			// Token: 0x04000106 RID: 262
			public string technicalName;

			// Token: 0x04000107 RID: 263
			public ArticyData.LocalizableText displayName;

			// Token: 0x04000108 RID: 264
			public ArticyData.LocalizableText text;

			// Token: 0x04000109 RID: 265
			public ArticyData.Features features;

			// Token: 0x0400010A RID: 266
			public Vector2 position;
		}

		// Token: 0x0200002C RID: 44
		public class Project
		{
			// Token: 0x0400010B RID: 267
			public string displayName = string.Empty;

			// Token: 0x0400010C RID: 268
			public string createdOn = string.Empty;

			// Token: 0x0400010D RID: 269
			public string creatorTool = string.Empty;

			// Token: 0x0400010E RID: 270
			public string creatorVersion = string.Empty;
		}

		// Token: 0x0200002D RID: 45
		public class Asset : ArticyData.Element
		{
			// Token: 0x06000264 RID: 612 RVA: 0x0000CD70 File Offset: 0x0000AF70
			public Asset()
			{
				this.assetFilename = string.Empty;
			}

			// Token: 0x06000265 RID: 613 RVA: 0x0000CD84 File Offset: 0x0000AF84
			public Asset(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, string assetFilename)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.assetFilename = assetFilename;
			}

			// Token: 0x0400010F RID: 271
			public string assetFilename;
		}

		// Token: 0x0200002E RID: 46
		public class Entity : ArticyData.Element
		{
			// Token: 0x06000266 RID: 614 RVA: 0x0000CDA0 File Offset: 0x0000AFA0
			public Entity()
			{
				this.previewImage = string.Empty;
			}

			// Token: 0x06000267 RID: 615 RVA: 0x0000CDB4 File Offset: 0x0000AFB4
			public Entity(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, string previewImage)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.previewImage = previewImage;
			}

			// Token: 0x04000110 RID: 272
			public string previewImage;
		}

		// Token: 0x0200002F RID: 47
		public class Location : ArticyData.Element
		{
			// Token: 0x06000268 RID: 616 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
			public Location()
			{
			}

			// Token: 0x06000269 RID: 617 RVA: 0x0000CDD8 File Offset: 0x0000AFD8
			public Location(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position)
				: base(id, technicalName, displayName, text, features, position)
			{
			}
		}

		// Token: 0x02000030 RID: 48
		public class FlowFragment : ArticyData.Element
		{
			// Token: 0x0600026A RID: 618 RVA: 0x0000CDEC File Offset: 0x0000AFEC
			public FlowFragment()
			{
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x0600026B RID: 619 RVA: 0x0000CE00 File Offset: 0x0000B000
			public FlowFragment(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, List<ArticyData.Pin> pins)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.pins = pins;
			}

			// Token: 0x04000111 RID: 273
			public List<ArticyData.Pin> pins;
		}

		// Token: 0x02000031 RID: 49
		public class Dialogue : ArticyData.Element
		{
			// Token: 0x0600026C RID: 620 RVA: 0x0000CE1C File Offset: 0x0000B01C
			public Dialogue()
			{
				this.pins = new List<ArticyData.Pin>();
				this.references = new List<string>();
				this.isDocument = false;
			}

			// Token: 0x0600026D RID: 621 RVA: 0x0000CE44 File Offset: 0x0000B044
			public Dialogue(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, List<ArticyData.Pin> pins, List<string> references, bool isDocument = false)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.pins = pins;
				this.references = references;
				this.isDocument = isDocument;
			}

			// Token: 0x04000112 RID: 274
			public List<ArticyData.Pin> pins;

			// Token: 0x04000113 RID: 275
			public List<string> references;

			// Token: 0x04000114 RID: 276
			public bool isDocument;
		}

		// Token: 0x02000032 RID: 50
		public class DialogueFragment : ArticyData.Element
		{
			// Token: 0x0600026E RID: 622 RVA: 0x0000CE70 File Offset: 0x0000B070
			public DialogueFragment()
			{
				this.menuText = new ArticyData.LocalizableText();
				this.stageDirections = new ArticyData.LocalizableText();
				this.speakerIdRef = string.Empty;
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x0600026F RID: 623 RVA: 0x0000CEB0 File Offset: 0x0000B0B0
			public DialogueFragment(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, ArticyData.LocalizableText menuText, ArticyData.LocalizableText stageDirections, string speakerIdRef, List<ArticyData.Pin> pins)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.menuText = menuText;
				this.stageDirections = stageDirections;
				this.speakerIdRef = speakerIdRef;
				this.pins = pins;
			}

			// Token: 0x04000115 RID: 277
			public ArticyData.LocalizableText menuText;

			// Token: 0x04000116 RID: 278
			public ArticyData.LocalizableText stageDirections;

			// Token: 0x04000117 RID: 279
			public string speakerIdRef;

			// Token: 0x04000118 RID: 280
			public List<ArticyData.Pin> pins;
		}

		// Token: 0x02000033 RID: 51
		public class Hub : ArticyData.Element
		{
			// Token: 0x06000270 RID: 624 RVA: 0x0000CEE4 File Offset: 0x0000B0E4
			public Hub()
			{
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x06000271 RID: 625 RVA: 0x0000CEF8 File Offset: 0x0000B0F8
			public Hub(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, List<ArticyData.Pin> pins)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.pins = pins;
			}

			// Token: 0x04000119 RID: 281
			public List<ArticyData.Pin> pins;
		}

		// Token: 0x02000034 RID: 52
		public class Jump : ArticyData.Element
		{
			// Token: 0x06000272 RID: 626 RVA: 0x0000CF14 File Offset: 0x0000B114
			public Jump()
			{
				this.target = new ArticyData.ConnectionRef();
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x06000273 RID: 627 RVA: 0x0000CF34 File Offset: 0x0000B134
			public Jump(string id, string technicalName, ArticyData.LocalizableText displayName, ArticyData.LocalizableText text, ArticyData.Features features, Vector2 position, ArticyData.ConnectionRef target, List<ArticyData.Pin> pins)
				: base(id, technicalName, displayName, text, features, position)
			{
				this.target = target;
				this.pins = pins;
			}

			// Token: 0x0400011A RID: 282
			public ArticyData.ConnectionRef target;

			// Token: 0x0400011B RID: 283
			public List<ArticyData.Pin> pins;
		}

		// Token: 0x02000035 RID: 53
		public class ConnectionRef
		{
			// Token: 0x06000274 RID: 628 RVA: 0x0000CF58 File Offset: 0x0000B158
			public ConnectionRef()
			{
				this.idRef = string.Empty;
				this.pinRef = string.Empty;
			}

			// Token: 0x06000275 RID: 629 RVA: 0x0000CF78 File Offset: 0x0000B178
			public ConnectionRef(string idRef, string pinRef)
			{
				this.idRef = idRef;
				this.pinRef = pinRef;
			}

			// Token: 0x0400011C RID: 284
			public string idRef;

			// Token: 0x0400011D RID: 285
			public string pinRef;
		}

		// Token: 0x02000036 RID: 54
		public class Connection
		{
			// Token: 0x06000276 RID: 630 RVA: 0x0000CF90 File Offset: 0x0000B190
			public Connection()
			{
				this.id = string.Empty;
				this.color = string.Empty;
				this.source = new ArticyData.ConnectionRef();
				this.target = new ArticyData.ConnectionRef();
			}

			// Token: 0x06000277 RID: 631 RVA: 0x0000CFD0 File Offset: 0x0000B1D0
			public Connection(string id, string color, ArticyData.ConnectionRef source, ArticyData.ConnectionRef target)
			{
				this.id = id;
				this.color = color;
				this.source = source;
				this.target = target;
			}

			// Token: 0x0400011E RID: 286
			public string id;

			// Token: 0x0400011F RID: 287
			public string color;

			// Token: 0x04000120 RID: 288
			public ArticyData.ConnectionRef source;

			// Token: 0x04000121 RID: 289
			public ArticyData.ConnectionRef target;
		}

		// Token: 0x02000037 RID: 55
		public class Condition
		{
			// Token: 0x06000278 RID: 632 RVA: 0x0000CFF8 File Offset: 0x0000B1F8
			public Condition()
			{
				this.id = string.Empty;
				this.expression = string.Empty;
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x06000279 RID: 633 RVA: 0x0000D024 File Offset: 0x0000B224
			public Condition(string id, string expression, List<ArticyData.Pin> pins, Vector2 position)
			{
				this.id = id;
				this.expression = expression;
				this.pins = pins;
				this.position = position;
			}

			// Token: 0x0600027A RID: 634 RVA: 0x0000D04C File Offset: 0x0000B24C
			public Condition(string id, string expression, List<ArticyData.Pin> pins)
			{
				this.id = id;
				this.expression = expression;
				this.pins = pins;
				this.position = Vector2.zero;
			}

			// Token: 0x04000122 RID: 290
			public string id;

			// Token: 0x04000123 RID: 291
			public string expression;

			// Token: 0x04000124 RID: 292
			public List<ArticyData.Pin> pins;

			// Token: 0x04000125 RID: 293
			public Vector2 position;
		}

		// Token: 0x02000038 RID: 56
		public class Instruction
		{
			// Token: 0x0600027B RID: 635 RVA: 0x0000D080 File Offset: 0x0000B280
			public Instruction()
			{
				this.id = string.Empty;
				this.expression = string.Empty;
				this.pins = new List<ArticyData.Pin>();
			}

			// Token: 0x0600027C RID: 636 RVA: 0x0000D0AC File Offset: 0x0000B2AC
			public Instruction(string id, string expression, List<ArticyData.Pin> pins, Vector2 position)
			{
				this.id = id;
				this.expression = expression;
				this.pins = pins;
				this.position = position;
			}

			// Token: 0x0600027D RID: 637 RVA: 0x0000D0D4 File Offset: 0x0000B2D4
			public Instruction(string id, string expression, List<ArticyData.Pin> pins)
			{
				this.id = id;
				this.expression = expression;
				this.pins = pins;
				this.position = Vector2.zero;
			}

			// Token: 0x04000126 RID: 294
			public string id;

			// Token: 0x04000127 RID: 295
			public string expression;

			// Token: 0x04000128 RID: 296
			public List<ArticyData.Pin> pins;

			// Token: 0x04000129 RID: 297
			public Vector2 position;
		}

		// Token: 0x02000039 RID: 57
		public enum SemanticType
		{
			// Token: 0x0400012B RID: 299
			Input,
			// Token: 0x0400012C RID: 300
			Output
		}

		// Token: 0x0200003A RID: 58
		public class Pin
		{
			// Token: 0x0600027E RID: 638 RVA: 0x0000D108 File Offset: 0x0000B308
			public Pin()
			{
				this.id = string.Empty;
				this.index = 0;
				this.semantic = ArticyData.SemanticType.Input;
				this.expression = string.Empty;
			}

			// Token: 0x0600027F RID: 639 RVA: 0x0000D140 File Offset: 0x0000B340
			public Pin(string id, int index, ArticyData.SemanticType semantic, string expression)
			{
				this.id = id;
				this.index = index;
				this.semantic = semantic;
				this.expression = expression;
			}

			// Token: 0x0400012D RID: 301
			public string id;

			// Token: 0x0400012E RID: 302
			public int index;

			// Token: 0x0400012F RID: 303
			public ArticyData.SemanticType semantic;

			// Token: 0x04000130 RID: 304
			public string expression;
		}

		// Token: 0x0200003B RID: 59
		public enum VariableDataType
		{
			// Token: 0x04000132 RID: 306
			Boolean,
			// Token: 0x04000133 RID: 307
			Integer,
			// Token: 0x04000134 RID: 308
			String
		}

		// Token: 0x0200003C RID: 60
		public class Variable
		{
			// Token: 0x06000280 RID: 640 RVA: 0x0000D168 File Offset: 0x0000B368
			public Variable()
			{
				this.technicalName = string.Empty;
				this.defaultValue = string.Empty;
				this.dataType = ArticyData.VariableDataType.Boolean;
				this.description = string.Empty;
			}

			// Token: 0x06000281 RID: 641 RVA: 0x0000D1A4 File Offset: 0x0000B3A4
			public Variable(string technicalName, string defaultValue, ArticyData.VariableDataType dataType)
			{
				this.technicalName = technicalName;
				this.defaultValue = defaultValue;
				this.dataType = dataType;
				this.description = string.Empty;
			}

			// Token: 0x06000282 RID: 642 RVA: 0x0000D1D8 File Offset: 0x0000B3D8
			public Variable(string technicalName, string defaultValue, ArticyData.VariableDataType dataType, string description)
			{
				this.technicalName = technicalName;
				this.defaultValue = defaultValue;
				this.dataType = dataType;
				this.description = description;
			}

			// Token: 0x04000135 RID: 309
			public string technicalName;

			// Token: 0x04000136 RID: 310
			public string defaultValue;

			// Token: 0x04000137 RID: 311
			public ArticyData.VariableDataType dataType;

			// Token: 0x04000138 RID: 312
			public string description;
		}

		// Token: 0x0200003D RID: 61
		public class VariableSet
		{
			// Token: 0x06000283 RID: 643 RVA: 0x0000D200 File Offset: 0x0000B400
			public VariableSet()
			{
				this.id = string.Empty;
				this.technicalName = string.Empty;
				this.variables = new List<ArticyData.Variable>();
			}

			// Token: 0x06000284 RID: 644 RVA: 0x0000D22C File Offset: 0x0000B42C
			public VariableSet(string id, string technicalName, List<ArticyData.Variable> variables)
			{
				this.id = id;
				this.technicalName = technicalName;
				this.variables = variables;
			}

			// Token: 0x04000139 RID: 313
			public string id;

			// Token: 0x0400013A RID: 314
			public string technicalName;

			// Token: 0x0400013B RID: 315
			public List<ArticyData.Variable> variables;
		}

		// Token: 0x0200003E RID: 62
		public class Features
		{
			// Token: 0x06000285 RID: 645 RVA: 0x0000D24C File Offset: 0x0000B44C
			public Features()
			{
				this.features = new List<ArticyData.Feature>();
			}

			// Token: 0x06000286 RID: 646 RVA: 0x0000D260 File Offset: 0x0000B460
			public Features(List<ArticyData.Feature> features)
			{
				this.features = features;
			}

			// Token: 0x0400013C RID: 316
			public List<ArticyData.Feature> features;
		}

		// Token: 0x0200003F RID: 63
		public class Feature
		{
			// Token: 0x06000287 RID: 647 RVA: 0x0000D270 File Offset: 0x0000B470
			public Feature()
			{
				this.properties = new List<ArticyData.Property>();
			}

			// Token: 0x06000288 RID: 648 RVA: 0x0000D284 File Offset: 0x0000B484
			public Feature(List<ArticyData.Property> properties)
			{
				this.properties = properties;
			}

			// Token: 0x0400013D RID: 317
			public List<ArticyData.Property> properties;
		}

		// Token: 0x02000040 RID: 64
		public class Property
		{
			// Token: 0x06000289 RID: 649 RVA: 0x0000D294 File Offset: 0x0000B494
			public Property()
			{
				this.fields = new List<Field>();
			}

			// Token: 0x0600028A RID: 650 RVA: 0x0000D2A8 File Offset: 0x0000B4A8
			public Property(List<Field> fields)
			{
				this.fields = fields;
			}

			// Token: 0x0400013E RID: 318
			public List<Field> fields;
		}

		// Token: 0x02000041 RID: 65
		public enum NodeType
		{
			// Token: 0x04000140 RID: 320
			FlowFragment,
			// Token: 0x04000141 RID: 321
			Dialogue,
			// Token: 0x04000142 RID: 322
			DialogueFragment,
			// Token: 0x04000143 RID: 323
			Hub,
			// Token: 0x04000144 RID: 324
			Jump,
			// Token: 0x04000145 RID: 325
			Connection,
			// Token: 0x04000146 RID: 326
			Condition,
			// Token: 0x04000147 RID: 327
			Instruction,
			// Token: 0x04000148 RID: 328
			Other
		}

		// Token: 0x02000042 RID: 66
		public class Node
		{
			// Token: 0x0600028B RID: 651 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
			public Node()
			{
				this.id = string.Empty;
				this.type = ArticyData.NodeType.Other;
				this.nodes = new List<ArticyData.Node>();
			}

			// Token: 0x0600028C RID: 652 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
			public Node(string id, ArticyData.NodeType nodeType, List<ArticyData.Node> nodes)
			{
				this.id = id;
				this.type = nodeType;
				this.nodes = nodes;
			}

			// Token: 0x04000149 RID: 329
			public string id;

			// Token: 0x0400014A RID: 330
			public ArticyData.NodeType type;

			// Token: 0x0400014B RID: 331
			public List<ArticyData.Node> nodes;
		}

		// Token: 0x02000043 RID: 67
		public class Hierarchy
		{
			// Token: 0x0600028D RID: 653 RVA: 0x0000D300 File Offset: 0x0000B500
			public Hierarchy()
			{
				this.node = null;
			}

			// Token: 0x0600028E RID: 654 RVA: 0x0000D310 File Offset: 0x0000B510
			public Hierarchy(ArticyData.Node node)
			{
				this.node = node;
			}

			// Token: 0x0400014C RID: 332
			public ArticyData.Node node;
		}
	}
}
