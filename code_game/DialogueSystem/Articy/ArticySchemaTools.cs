using System;
using System.Text;
using PixelCrushers.DialogueSystem.Articy.Articy_1_4;
using PixelCrushers.DialogueSystem.Articy.Articy_2_2;
using PixelCrushers.DialogueSystem.Articy.Articy_2_4;
using PixelCrushers.DialogueSystem.Articy.Articy_3_1;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000044 RID: 68
	public static class ArticySchemaTools
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000D320 File Offset: 0x0000B520
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding, bool convertDropdownAsString = false)
		{
			if (Articy_3_1_Tools.IsSchema(xmlData))
			{
				return Articy_3_1_Tools.LoadArticyDataFromXmlData(xmlData, encoding, convertDropdownAsString, null);
			}
			if (Articy_2_4_Tools.IsSchema(xmlData))
			{
				return Articy_2_4_Tools.LoadArticyDataFromXmlData(xmlData, encoding, convertDropdownAsString, null);
			}
			if (Articy_2_2_Tools.IsSchema(xmlData))
			{
				return Articy_2_2_Tools.LoadArticyDataFromXmlData(xmlData, encoding);
			}
			if (Articy_1_4_Tools.IsSchema(xmlData))
			{
				return Articy_1_4_Tools.LoadArticyDataFromXmlData(xmlData, encoding);
			}
			return null;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000D380 File Offset: 0x0000B580
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, ConverterPrefs prefs)
		{
			if (Articy_3_1_Tools.IsSchema(xmlData))
			{
				return Articy_3_1_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding, prefs.ConvertDropdownsAsString, prefs);
			}
			if (Articy_2_4_Tools.IsSchema(xmlData))
			{
				return Articy_2_4_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding, prefs.ConvertDropdownsAsString, prefs);
			}
			if (Articy_2_2_Tools.IsSchema(xmlData))
			{
				return Articy_2_2_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding);
			}
			if (Articy_1_4_Tools.IsSchema(xmlData))
			{
				return Articy_1_4_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding);
			}
			return null;
		}
	}
}
