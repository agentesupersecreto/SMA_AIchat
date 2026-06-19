using System;
using System.Text;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x0200004B RID: 75
	public class ConverterPrefs
	{
		// Token: 0x060002AB RID: 683 RVA: 0x0000DB14 File Offset: 0x0000BD14
		public ConverterPrefs()
		{
			this.ProjectFilename = string.Empty;
			this.PortraitFolder = string.Empty;
			this.StageDirectionsAreSequences = true;
			this.FlowFragmentMode = ConverterPrefs.FlowFragmentModes.ConversationGroups;
			this.OutputFolder = "Assets";
			this.Overwrite = false;
			this.ConversionSettings = new ConversionSettings();
			this.EncodingType = EncodingType.Default;
			this.RecursionMode = ConverterPrefs.RecursionModes.On;
			this.ConvertDropdownsAs = ConverterPrefs.ConvertDropdownsModes.Ints;
			this.ConvertSlotsAs = ConverterPrefs.ConvertSlotsModes.DisplayName;
			this.DirectConversationLinksToEntry1 = false;
			this.FlowFragmentScript = "OnFlowFragment";
			this.VoiceOverProperty = "VoiceOverFile";
			this.LocalizationXlsx = string.Empty;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0000DBAC File Offset: 0x0000BDAC
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0000DBB4 File Offset: 0x0000BDB4
		public string ProjectFilename { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0000DBC0 File Offset: 0x0000BDC0
		// (set) Token: 0x060002AF RID: 687 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		public string PortraitFolder { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000DBD4 File Offset: 0x0000BDD4
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000DBDC File Offset: 0x0000BDDC
		public bool StageDirectionsAreSequences { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000DBE8 File Offset: 0x0000BDE8
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000DBF0 File Offset: 0x0000BDF0
		public ConverterPrefs.FlowFragmentModes FlowFragmentMode { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x0000DC04 File Offset: 0x0000BE04
		public string OutputFolder { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000DC10 File Offset: 0x0000BE10
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x0000DC18 File Offset: 0x0000BE18
		public bool Overwrite { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0000DC24 File Offset: 0x0000BE24
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x0000DC2C File Offset: 0x0000BE2C
		public ConversionSettings ConversionSettings { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000DC38 File Offset: 0x0000BE38
		// (set) Token: 0x060002BB RID: 699 RVA: 0x0000DC40 File Offset: 0x0000BE40
		public EncodingType EncodingType { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0000DC4C File Offset: 0x0000BE4C
		// (set) Token: 0x060002BD RID: 701 RVA: 0x0000DC54 File Offset: 0x0000BE54
		public ConverterPrefs.RecursionModes RecursionMode { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000DC60 File Offset: 0x0000BE60
		// (set) Token: 0x060002BF RID: 703 RVA: 0x0000DC68 File Offset: 0x0000BE68
		public ConverterPrefs.ConvertDropdownsModes ConvertDropdownsAs { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000DC74 File Offset: 0x0000BE74
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		public ConverterPrefs.ConvertSlotsModes ConvertSlotsAs { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000DC88 File Offset: 0x0000BE88
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x0000DC90 File Offset: 0x0000BE90
		public bool DirectConversationLinksToEntry1 { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000DC9C File Offset: 0x0000BE9C
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x0000DCA4 File Offset: 0x0000BEA4
		public string FlowFragmentScript { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000DCB0 File Offset: 0x0000BEB0
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
		public string VoiceOverProperty { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000DCC4 File Offset: 0x0000BEC4
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0000DCCC File Offset: 0x0000BECC
		public string LocalizationXlsx { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		public Encoding Encoding
		{
			get
			{
				return EncodingTypeTools.GetEncoding(this.EncodingType);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		public bool ConvertDropdownsAsString
		{
			get
			{
				return this.ConvertDropdownsAs == ConverterPrefs.ConvertDropdownsModes.Strings;
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		public void ReviewSpecialProperties(ArticyData articyData)
		{
			foreach (ArticyData.Entity entity in articyData.entities.Values)
			{
				ConversionSetting conversionSetting = this.ConversionSettings.GetConversionSetting(entity.id);
				if (conversionSetting.Include)
				{
					if (ArticyConverter.HasField(entity.features, "IsNPC", false))
					{
						conversionSetting.Category = EntityCategory.NPC;
					}
					if (ArticyConverter.HasField(entity.features, "IsPlayer", true))
					{
						conversionSetting.Category = EntityCategory.Player;
					}
					if (ArticyConverter.HasField(entity.features, "IsItem", true))
					{
						conversionSetting.Category = EntityCategory.Item;
					}
					if (ArticyConverter.HasField(entity.features, "IsQuest", true))
					{
						conversionSetting.Category = EntityCategory.Quest;
					}
				}
			}
		}

		// Token: 0x04000160 RID: 352
		public const string DefaultFlowFragmentScript = "OnFlowFragment";

		// Token: 0x04000161 RID: 353
		public const string DefaultVoiceOverProperty = "VoiceOverFile";

		// Token: 0x0200004C RID: 76
		public enum FlowFragmentModes
		{
			// Token: 0x04000172 RID: 370
			NestedConversationGroups,
			// Token: 0x04000173 RID: 371
			ConversationGroups,
			// Token: 0x04000174 RID: 372
			Quests,
			// Token: 0x04000175 RID: 373
			Ignore
		}

		// Token: 0x0200004D RID: 77
		public enum StageDirModes
		{
			// Token: 0x04000177 RID: 375
			Sequences,
			// Token: 0x04000178 RID: 376
			NotSequences
		}

		// Token: 0x0200004E RID: 78
		public enum ConvertDropdownsModes
		{
			// Token: 0x0400017A RID: 378
			Ints,
			// Token: 0x0400017B RID: 379
			Strings
		}

		// Token: 0x0200004F RID: 79
		public enum ConvertSlotsModes
		{
			// Token: 0x0400017D RID: 381
			DisplayName,
			// Token: 0x0400017E RID: 382
			ID
		}

		// Token: 0x02000050 RID: 80
		public enum RecursionModes
		{
			// Token: 0x04000180 RID: 384
			Off,
			// Token: 0x04000181 RID: 385
			On
		}
	}
}
