using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000045 RID: 69
	public static class ArticyTools
	{
		// Token: 0x06000292 RID: 658 RVA: 0x0000D49C File Offset: 0x0000B69C
		public static bool DataContainsSchemaId(string xmlData, string schemaId)
		{
			StringReader stringReader = new StringReader(xmlData);
			if (stringReader != null)
			{
				for (int i = 0; i < 5; i++)
				{
					string text = stringReader.ReadLine();
					if (text.Contains(schemaId))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000D4E0 File Offset: 0x0000B6E0
		public static string RemoveHtml(string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				foreach (string text in ArticyTools.htmlTags)
				{
					s = s.Replace(text, string.Empty);
				}
				s = s.Replace("&#39;", "'");
				s = s.Replace("&quot;", "\"");
				s = s.Replace("&amp;", "&");
				s = s.Trim();
			}
			return s;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000D564 File Offset: 0x0000B764
		public static bool IsQuestStateArticyPropertyName(string propertyName)
		{
			return string.Equals(propertyName, "State") || Regex.Match(propertyName, "^Entry_[0-9]+_State").Success;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000D58C File Offset: 0x0000B78C
		public static string EnumValueToQuestState(int enumValue, string stringValue)
		{
			if (string.Equals("unassigned", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Unassigned);
			}
			if (string.Equals("active", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Active);
			}
			if (string.Equals("success", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Success);
			}
			if (string.Equals("failure", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Failure);
			}
			if (string.Equals("abandoned", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Abandoned);
			}
			switch (enumValue)
			{
			case 1:
				return QuestLog.StateToString(QuestState.Unassigned);
			case 2:
				return QuestLog.StateToString(QuestState.Active);
			case 3:
				return QuestLog.StateToString(QuestState.Success);
			case 4:
				return QuestLog.StateToString(QuestState.Failure);
			case 5:
				return QuestLog.StateToString(QuestState.Abandoned);
			default:
				return QuestLog.StateToString(QuestState.Unassigned);
			}
		}

		// Token: 0x0400014D RID: 333
		private static string[] htmlTags = new string[]
		{
			"<html>", "<head>", "<style>", "#s0", "{text-align:left;}", "#s1", "{font-size:11pt;}", "</style>", "</head>", "<body>",
			"<p id=\"s0\">", "<span id=\"s1\">", "</span>", "</p>", "</body>", "</html>"
		};
	}
}
