using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000048 RID: 72
	public class ConversionSettings
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x0000D71C File Offset: 0x0000B91C
		public static ConversionSettings FromXml(string xml)
		{
			ConversionSettings conversionSettings;
			if (string.IsNullOrEmpty(xml))
			{
				conversionSettings = new ConversionSettings();
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConversionSettings));
				conversionSettings = xmlSerializer.Deserialize(new StringReader(xml)) as ConversionSettings;
				if (conversionSettings != null)
				{
					conversionSettings.AfterDeserialization();
				}
			}
			return conversionSettings;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000D770 File Offset: 0x0000B970
		public string ToXml()
		{
			this.BeforeSerialization();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConversionSettings));
			StringWriter stringWriter = new StringWriter();
			xmlSerializer.Serialize(stringWriter, this);
			return stringWriter.ToString();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000D7A8 File Offset: 0x0000B9A8
		private void BeforeSerialization()
		{
			this.list.Clear();
			foreach (KeyValuePair<string, ConversionSetting> keyValuePair in this.dict)
			{
				this.list.Add(keyValuePair.Value);
			}
			this.dropdownOverrideList.Clear();
			foreach (KeyValuePair<string, ConversionSettings.DropdownOverrideSetting> keyValuePair2 in this.dropdownOverrideDict)
			{
				this.dropdownOverrideList.Add(keyValuePair2.Value);
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000D890 File Offset: 0x0000BA90
		private void AfterDeserialization()
		{
			this.dict.Clear();
			foreach (ConversionSetting conversionSetting in this.list)
			{
				this.dict.Add(conversionSetting.Id, conversionSetting);
			}
			this.dropdownOverrideDict.Clear();
			foreach (ConversionSettings.DropdownOverrideSetting dropdownOverrideSetting in this.dropdownOverrideList)
			{
				this.dropdownOverrideDict.Add(dropdownOverrideSetting.id, dropdownOverrideSetting);
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000D978 File Offset: 0x0000BB78
		public void Clear()
		{
			this.dict.Clear();
			this.list.Clear();
			this.dropdownOverrideDict.Clear();
			this.dropdownOverrideList.Clear();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000D9B4 File Offset: 0x0000BBB4
		public ConversionSetting GetConversionSetting(string Id)
		{
			if (string.IsNullOrEmpty(Id))
			{
				return null;
			}
			if (!this.dict.ContainsKey(Id))
			{
				this.dict[Id] = new ConversionSetting(Id);
			}
			return this.dict[Id];
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000DA00 File Offset: 0x0000BC00
		public bool ConversionSettingExists(string Id)
		{
			return !string.IsNullOrEmpty(Id) && this.dict.ContainsKey(Id);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000DA1C File Offset: 0x0000BC1C
		public ConversionSettings.DropdownOverrideSetting GetDropdownOverrideSetting(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return null;
			}
			if (!this.dropdownOverrideDict.ContainsKey(id))
			{
				ConversionSettings.DropdownOverrideSetting dropdownOverrideSetting = new ConversionSettings.DropdownOverrideSetting(id, ConversionSettings.DropdownOverrideMode.UseGlobalSetting);
				this.dropdownOverrideDict.Add(id, dropdownOverrideSetting);
				this.dropdownOverrideList.Add(dropdownOverrideSetting);
			}
			return this.dropdownOverrideDict[id];
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000DA74 File Offset: 0x0000BC74
		public void AllDropdownOverrides(ConversionSettings.DropdownOverrideMode mode)
		{
			foreach (ConversionSettings.DropdownOverrideSetting dropdownOverrideSetting in this.dropdownOverrideList)
			{
				dropdownOverrideSetting.mode = mode;
			}
		}

		// Token: 0x04000156 RID: 342
		private Dictionary<string, ConversionSetting> dict = new Dictionary<string, ConversionSetting>();

		// Token: 0x04000157 RID: 343
		public List<ConversionSetting> list = new List<ConversionSetting>();

		// Token: 0x04000158 RID: 344
		private Dictionary<string, ConversionSettings.DropdownOverrideSetting> dropdownOverrideDict = new Dictionary<string, ConversionSettings.DropdownOverrideSetting>();

		// Token: 0x04000159 RID: 345
		public List<ConversionSettings.DropdownOverrideSetting> dropdownOverrideList = new List<ConversionSettings.DropdownOverrideSetting>();

		// Token: 0x02000049 RID: 73
		public enum DropdownOverrideMode
		{
			// Token: 0x0400015B RID: 347
			UseGlobalSetting,
			// Token: 0x0400015C RID: 348
			Int,
			// Token: 0x0400015D RID: 349
			String
		}

		// Token: 0x0200004A RID: 74
		[Serializable]
		public class DropdownOverrideSetting
		{
			// Token: 0x060002A9 RID: 681 RVA: 0x0000DADC File Offset: 0x0000BCDC
			public DropdownOverrideSetting()
			{
			}

			// Token: 0x060002AA RID: 682 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
			public DropdownOverrideSetting(string id, ConversionSettings.DropdownOverrideMode mode = ConversionSettings.DropdownOverrideMode.UseGlobalSetting)
			{
				this.id = id;
				this.mode = mode;
			}

			// Token: 0x0400015E RID: 350
			public string id = string.Empty;

			// Token: 0x0400015F RID: 351
			public ConversionSettings.DropdownOverrideMode mode;
		}
	}
}
