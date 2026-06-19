using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000186 RID: 390
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd", IncludeInSchema = false)]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ItemsChoiceType
	{
		// Token: 0x04000981 RID: 2433
		Asset,
		// Token: 0x04000982 RID: 2434
		Assets,
		// Token: 0x04000983 RID: 2435
		AssetsUserFolder,
		// Token: 0x04000984 RID: 2436
		BooleanPropertyDefinition,
		// Token: 0x04000985 RID: 2437
		Comment,
		// Token: 0x04000986 RID: 2438
		Condition,
		// Token: 0x04000987 RID: 2439
		Connection,
		// Token: 0x04000988 RID: 2440
		Dialogue,
		// Token: 0x04000989 RID: 2441
		DialogueFragment,
		// Token: 0x0400098A RID: 2442
		Document,
		// Token: 0x0400098B RID: 2443
		Documents,
		// Token: 0x0400098C RID: 2444
		DocumentsUserFolder,
		// Token: 0x0400098D RID: 2445
		Entities,
		// Token: 0x0400098E RID: 2446
		EntitiesUserFolder,
		// Token: 0x0400098F RID: 2447
		Entity,
		// Token: 0x04000990 RID: 2448
		EnumerationPropertyDefinition,
		// Token: 0x04000991 RID: 2449
		FeatureDefinition,
		// Token: 0x04000992 RID: 2450
		Features,
		// Token: 0x04000993 RID: 2451
		FeaturesUserFolder,
		// Token: 0x04000994 RID: 2452
		Flow,
		// Token: 0x04000995 RID: 2453
		FlowFragment,
		// Token: 0x04000996 RID: 2454
		GlobalVariables,
		// Token: 0x04000997 RID: 2455
		Hub,
		// Token: 0x04000998 RID: 2456
		Instruction,
		// Token: 0x04000999 RID: 2457
		Journey,
		// Token: 0x0400099A RID: 2458
		Journeys,
		// Token: 0x0400099B RID: 2459
		JourneysUserFolder,
		// Token: 0x0400099C RID: 2460
		Jump,
		// Token: 0x0400099D RID: 2461
		LayerFolder,
		// Token: 0x0400099E RID: 2462
		Link,
		// Token: 0x0400099F RID: 2463
		Location,
		// Token: 0x040009A0 RID: 2464
		LocationImage,
		// Token: 0x040009A1 RID: 2465
		LocationText,
		// Token: 0x040009A2 RID: 2466
		Locations,
		// Token: 0x040009A3 RID: 2467
		LocationsUserFolder,
		// Token: 0x040009A4 RID: 2468
		NumberPropertyDefinition,
		// Token: 0x040009A5 RID: 2469
		ObjectCustomization,
		// Token: 0x040009A6 RID: 2470
		ObjectTemplateDefinition,
		// Token: 0x040009A7 RID: 2471
		ObjectTemplates,
		// Token: 0x040009A8 RID: 2472
		ObjectTemplatesUserFolder,
		// Token: 0x040009A9 RID: 2473
		Path,
		// Token: 0x040009AA RID: 2474
		Project,
		// Token: 0x040009AB RID: 2475
		ProjectSettings,
		// Token: 0x040009AC RID: 2476
		PropertyTemplates,
		// Token: 0x040009AD RID: 2477
		QueryReferenceStripPropertyDefinition,
		// Token: 0x040009AE RID: 2478
		ReferenceSlotPropertyDefinition,
		// Token: 0x040009AF RID: 2479
		ReferenceStripPropertyDefinition,
		// Token: 0x040009B0 RID: 2480
		ScriptPropertyDefinition,
		// Token: 0x040009B1 RID: 2481
		Spot,
		// Token: 0x040009B2 RID: 2482
		TextObject,
		// Token: 0x040009B3 RID: 2483
		TextPropertyDefinition,
		// Token: 0x040009B4 RID: 2484
		TypedObjectTemplates,
		// Token: 0x040009B5 RID: 2485
		TypedPropertyTemplates,
		// Token: 0x040009B6 RID: 2486
		TypedPropertyTemplatesUserFolder,
		// Token: 0x040009B7 RID: 2487
		VariableSet,
		// Token: 0x040009B8 RID: 2488
		Zone
	}
}
