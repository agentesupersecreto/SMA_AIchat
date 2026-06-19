using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200021E RID: 542
	public class FormattedText
	{
		// Token: 0x06001884 RID: 6276 RVA: 0x000231D0 File Offset: 0x000213D0
		public FormattedText(string text = null, Emphasis[] emphases = null, bool italic = false, int position = -1, bool forceMenu = true, int pic = 0, int picActor = 0, int picConversant = 0, string variableInputPrompt = null)
		{
			this.text = text ?? string.Empty;
			this.emphases = emphases ?? FormattedText.noEmphases;
			this.italic = italic;
			this.position = position;
			this.forceMenu = forceMenu;
			this.pic = pic;
			this.picActor = picActor;
			this.picConversant = picConversant;
			this.variableInputPrompt = variableInputPrompt;
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06001886 RID: 6278 RVA: 0x0002326C File Offset: 0x0002146C
		// (set) Token: 0x06001887 RID: 6279 RVA: 0x00023274 File Offset: 0x00021474
		public string text { get; set; }

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x06001888 RID: 6280 RVA: 0x00023280 File Offset: 0x00021480
		// (set) Token: 0x06001889 RID: 6281 RVA: 0x00023288 File Offset: 0x00021488
		public Emphasis[] emphases { get; set; }

		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x0600188A RID: 6282 RVA: 0x00023294 File Offset: 0x00021494
		// (set) Token: 0x0600188B RID: 6283 RVA: 0x0002329C File Offset: 0x0002149C
		public bool italic { get; set; }

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x0600188C RID: 6284 RVA: 0x000232A8 File Offset: 0x000214A8
		// (set) Token: 0x0600188D RID: 6285 RVA: 0x000232B0 File Offset: 0x000214B0
		public int position { get; set; }

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x0600188E RID: 6286 RVA: 0x000232BC File Offset: 0x000214BC
		// (set) Token: 0x0600188F RID: 6287 RVA: 0x000232C4 File Offset: 0x000214C4
		public bool forceMenu { get; set; }

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06001890 RID: 6288 RVA: 0x000232D0 File Offset: 0x000214D0
		// (set) Token: 0x06001891 RID: 6289 RVA: 0x000232D8 File Offset: 0x000214D8
		public int pic { get; set; }

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06001892 RID: 6290 RVA: 0x000232E4 File Offset: 0x000214E4
		// (set) Token: 0x06001893 RID: 6291 RVA: 0x000232EC File Offset: 0x000214EC
		public int picActor { get; set; }

		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x06001894 RID: 6292 RVA: 0x000232F8 File Offset: 0x000214F8
		// (set) Token: 0x06001895 RID: 6293 RVA: 0x00023300 File Offset: 0x00021500
		public int picConversant { get; set; }

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x06001896 RID: 6294 RVA: 0x0002330C File Offset: 0x0002150C
		// (set) Token: 0x06001897 RID: 6295 RVA: 0x00023314 File Offset: 0x00021514
		public string variableInputPrompt { get; set; }

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06001898 RID: 6296 RVA: 0x00023320 File Offset: 0x00021520
		public bool hasVariableInputPrompt
		{
			get
			{
				return !string.IsNullOrEmpty(this.variableInputPrompt);
			}
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00023330 File Offset: 0x00021530
		public static FormattedText Parse(string rawText, EmphasisSetting[] emphasisSettings)
		{
			string text = rawText ?? string.Empty;
			FormattedText.ReplaceLuaTags(ref text);
			string text2 = FormattedText.ExtractVariableInputPrompt(ref text);
			FormattedText.ReplaceVarTags(ref text);
			FormattedText.ReplacePipes(ref text);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (text.Contains("[pic"))
			{
				num = FormattedText.ExtractPicTag("\\[pic=[0-9a-zA-z_]+\\]", ref text);
				num2 = FormattedText.ExtractPicTag("\\[pica=[0-9a-zA-z_]+\\]", ref text);
				num3 = FormattedText.ExtractPicTag("\\[picc=[0-9a-zA-z_]+\\]", ref text);
			}
			bool flag = FormattedText.ExtractTag("[a]", ref text);
			bool flag2 = FormattedText.ExtractTag("[f]", ref text);
			int num4 = FormattedText.ExtractPositionTag(ref text);
			Emphasis[] array = ((!DialogueManager.Instance.displaySettings.subtitleSettings.richTextEmphases) ? FormattedText.ExtractEmphasisTags(ref text, emphasisSettings) : FormattedText.ReplaceEmphasisTagsWithRichText(ref text, emphasisSettings));
			return new FormattedText(text, array, flag, num4, flag2, num, num2, num3, text2);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00023410 File Offset: 0x00021610
		public static string ParseCode(string rawText)
		{
			string text = rawText ?? string.Empty;
			if (text.Contains("["))
			{
				FormattedText.ReplaceLuaTags(ref text);
				FormattedText.ReplaceVarTags(ref text);
			}
			return text;
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x0002344C File Offset: 0x0002164C
		private static void ReplacePipes(ref string text)
		{
			if (text.Contains("|"))
			{
				text = text.Replace("|", "\n");
			}
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00023480 File Offset: 0x00021680
		private static void ReplaceLuaTags(ref string text)
		{
			if (text.Contains("[lua("))
			{
				Regex regex = new Regex("\\[lua\\((?!lua).*\\)\\]");
				int num = text.Length - 1;
				int num2 = 0;
				while (num >= 0 && num2 < 100)
				{
					num2++;
					int num3 = text.LastIndexOf("[lua(", num, StringComparison.OrdinalIgnoreCase);
					num = num3 - 1;
					if (num3 >= 0)
					{
						string text2 = text.Substring(0, num3);
						string text3 = text.Substring(num3);
						string text4 = regex.Replace(text3, delegate(Match match)
						{
							string text5 = match.Value.Substring(5, match.Value.Length - 7).Trim();
							if (!text5.StartsWith("return "))
							{
								text5 = "return " + text5;
							}
							string asString;
							try
							{
								asString = Lua.Run(text5, DialogueDebug.LogInfo).AsString;
							}
							catch (Exception)
							{
								if (DialogueDebug.LogWarnings)
								{
									Debug.LogWarning(string.Format("{0}: Lua failed: '{1}'", new object[] { "Dialogue System", text5 }));
								}
								asString = string.Empty;
							}
							return asString;
						});
						text = text2 + text4;
					}
				}
			}
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00023538 File Offset: 0x00021738
		private static void ReplaceVarTags(ref string text)
		{
			if (text.Contains("[var="))
			{
				Regex regex = new Regex("\\[var=[^\\]]*\\]");
				int num = text.Length - 1;
				int num2 = 0;
				while (num >= 0 && num2 < 100)
				{
					num2++;
					int num3 = text.LastIndexOf("[var=", num, StringComparison.OrdinalIgnoreCase);
					num = num3 - 1;
					if (num3 >= 0)
					{
						string text2 = text.Substring(0, num3);
						string text3 = text.Substring(num3);
						string text4 = regex.Replace(text3, delegate(Match match)
						{
							string text5 = match.Value.Substring(5, match.Value.Length - 6).Trim();
							string asString;
							try
							{
								asString = DialogueLua.GetVariable(text5).AsString;
							}
							catch (Exception)
							{
								if (DialogueDebug.LogWarnings)
								{
									Debug.LogWarning(string.Format("{0}: Failed to get variable: '{1}'", new object[] { "Dialogue System", text5 }));
								}
								asString = string.Empty;
							}
							return asString;
						});
						text = text2 + text4;
					}
				}
			}
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x000235F0 File Offset: 0x000217F0
		private static string ExtractVariableInputPrompt(ref string text)
		{
			string varName = string.Empty;
			if (text.Contains("[var=?"))
			{
				Regex regex = new Regex("\\[var=\\?.*\\]");
				int num = text.Length - 1;
				int num2 = 0;
				while (num >= 0 && num2 < 100)
				{
					num2++;
					int num3 = text.LastIndexOf("[var=?", num, StringComparison.OrdinalIgnoreCase);
					num = num3 - 1;
					if (num3 >= 0)
					{
						string text2 = text.Substring(0, num3);
						string text3 = text.Substring(num3);
						string text4 = regex.Replace(text3, delegate(Match match)
						{
							varName = match.Value.Substring(6, match.Value.Length - 7).Trim();
							return string.Empty;
						});
						text = text2 + text4;
					}
				}
			}
			return varName;
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x000236B4 File Offset: 0x000218B4
		private static bool ExtractTag(string tag, ref string text)
		{
			bool flag = text.Contains(tag);
			if (flag)
			{
				text = text.Replace(tag, string.Empty);
			}
			return flag;
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x000236E0 File Offset: 0x000218E0
		private static int ExtractPositionTag(ref string text)
		{
			int position = -1;
			if (text.Contains("[position "))
			{
				Regex regex = new Regex("\\[position\\s+[0-9]+\\]");
				text = regex.Replace(text, delegate(Match match)
				{
					string text2 = match.Value.Substring(10, 1);
					int.TryParse(text2, out position);
					return string.Empty;
				});
			}
			return position;
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00023734 File Offset: 0x00021934
		private static int ExtractPicTag(string tagRegex, ref string text)
		{
			int index = 0;
			Regex regex = new Regex(tagRegex);
			text = regex.Replace(text, delegate(Match match)
			{
				int num = match.Value.IndexOf('=') + 1;
				string text2 = match.Value.Substring(num, match.Value.Length - (num + 1));
				if (!int.TryParse(text2, out index))
				{
					index = DialogueLua.GetVariable(text2).AsInt;
				}
				return string.Empty;
			});
			return index;
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00023774 File Offset: 0x00021974
		private static Emphasis[] ExtractEmphasisTags(ref string text, EmphasisSetting[] emphasisSettings)
		{
			List<Emphasis> emphases = new List<Emphasis>();
			if (text.Contains("[em"))
			{
				Regex regex = new Regex("\\[\\/?em[1-4]\\]");
				text = regex.Replace(text, delegate(Match match)
				{
					string text2 = match.Value.Substring(match.Value.Length - 2, 1);
					int num = 1;
					int.TryParse(text2, out num);
					num--;
					if (emphasisSettings != null && 0 <= num && num < emphasisSettings.Length)
					{
						Emphasis emphasis = new Emphasis(0, int.MaxValue, emphasisSettings[num].color, emphasisSettings[num].bold, emphasisSettings[num].italic, emphasisSettings[num].underline);
						emphases.Clear();
						emphases.Add(emphasis);
					}
					return string.Empty;
				});
			}
			return emphases.ToArray();
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x000237D8 File Offset: 0x000219D8
		private static Emphasis[] ReplaceEmphasisTagsWithRichText(ref string text, EmphasisSetting[] emphasisSettings)
		{
			if (text.Contains("[em"))
			{
				for (int i = 0; i < 4; i++)
				{
					string text2 = string.Format("[em{0}]", new object[] { i + 1 });
					string text3 = string.Format("[/em{0}]", new object[] { i + 1 });
					if (text.Contains(text2))
					{
						string text4 = string.Format("{0}{1}<color={2}>", new object[]
						{
							(!emphasisSettings[i].bold) ? string.Empty : "<b>",
							(!emphasisSettings[i].italic) ? string.Empty : "<i>",
							Tools.ToWebColor(emphasisSettings[i].color)
						});
						string text5 = string.Format("</color>{0}{1}", new object[]
						{
							(!emphasisSettings[i].italic) ? string.Empty : "</i>",
							(!emphasisSettings[i].bold) ? string.Empty : "</b>"
						});
						text = text.Replace(text2, text4).Replace(text3, text5);
					}
				}
			}
			return new Emphasis[0];
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00023918 File Offset: 0x00021B18
		public static FontStyle GetFontStyle(Emphasis emphasis)
		{
			if (emphasis.bold && emphasis.italic)
			{
				return FontStyle.BoldAndItalic;
			}
			if (emphasis.bold)
			{
				return FontStyle.Bold;
			}
			if (emphasis.italic)
			{
				return FontStyle.Italic;
			}
			return FontStyle.Normal;
		}

		// Token: 0x04000DB5 RID: 3509
		public const int NoAssignedPosition = -1;

		// Token: 0x04000DB6 RID: 3510
		public const int NoPicOverride = 0;

		// Token: 0x04000DB7 RID: 3511
		public static readonly FormattedText empty = new FormattedText(null, null, false, -1, true, 0, 0, 0, null);

		// Token: 0x04000DB8 RID: 3512
		public static readonly Emphasis[] noEmphases = new Emphasis[0];
	}
}
