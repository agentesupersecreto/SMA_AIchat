using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PixelCrushers.DialogueSystem.SequencerCommands;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000234 RID: 564
	public class SequenceParser
	{
		// Token: 0x0600192E RID: 6446 RVA: 0x0002554C File Offset: 0x0002374C
		public List<QueuedSequencerCommand> Parse(string sequence)
		{
			List<QueuedSequencerCommand> list = new List<QueuedSequencerCommand>();
			try
			{
				StringReader stringReader = new StringReader(sequence);
				this.row = 1;
				this.column = 1;
				int num = 0;
				while (stringReader.Peek() != -1 && num < 9999)
				{
					num++;
					QueuedSequencerCommand queuedSequencerCommand = this.ParseCommand(stringReader);
					if (queuedSequencerCommand != null)
					{
						list.Add(queuedSequencerCommand);
					}
				}
			}
			catch (ParserException ex)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Concat(new object[] { "Dialogue System: Syntax error '", ex.Message, "' at column ", this.column, " row ", this.row, " parsing: ", sequence }));
				}
				list.Clear();
			}
			return list;
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x00025640 File Offset: 0x00023840
		private QueuedSequencerCommand ParseCommand(StringReader reader)
		{
			this.ParseOptionalWhitespace(reader);
			bool flag = false;
			string text = this.ParseWord(reader, false);
			if (string.Equals(text, "required", StringComparison.OrdinalIgnoreCase) || string.Equals(text, "require", StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
				this.ParseOptionalWhitespace(reader);
				text = this.ParseWord(reader, false);
			}
			string text2 = text;
			this.ParseOptionalWhitespace(reader);
			if (reader.Peek() == -1)
			{
				return null;
			}
			this.ParseOpenParen(reader);
			this.ParseOptionalWhitespace(reader);
			string[] array = this.ParseParameters(reader);
			this.ParseCloseParen(reader);
			this.ParseOptionalWhitespace(reader);
			float num;
			string text3;
			string text4;
			this.ParsePostParameters(reader, out num, out text3, out text4);
			this.ParseOptionalWhitespace(reader);
			this.ParseSemicolonOrEnd(reader);
			return new QueuedSequencerCommand(text2, array, num, text3, text4, flag);
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x000256F8 File Offset: 0x000238F8
		private string ParseWord(StringReader reader, bool allowWhiteSpace = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (this.HasNextChar(reader) && num < 9999)
			{
				num++;
				char c = (char)reader.Peek();
				if ((char.IsWhiteSpace(c) && !allowWhiteSpace) || c == '(' || c == ')' || c == ';' || c == '-')
				{
					break;
				}
				stringBuilder.Append(this.ReadNextChar(reader));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00025780 File Offset: 0x00023980
		private void ParseOptionalWhitespace(StringReader reader)
		{
			int num = 0;
			while (this.IsNextCharWhiteSpace(reader) && num < 9999)
			{
				num++;
				this.ReadNextChar(reader);
			}
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x000257B8 File Offset: 0x000239B8
		private bool IsNextCharWhiteSpace(StringReader reader)
		{
			return this.HasNextChar(reader) && char.IsWhiteSpace((char)reader.Peek());
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x000257D8 File Offset: 0x000239D8
		private bool IsNextChar(StringReader reader, char requiredChar)
		{
			return this.HasNextChar(reader) && (char)reader.Peek() == requiredChar;
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x000257F4 File Offset: 0x000239F4
		private bool IsNextCharNot(StringReader reader, char requiredChar)
		{
			return this.HasNextChar(reader) && (char)reader.Peek() != requiredChar;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x00025814 File Offset: 0x00023A14
		private bool HasNextChar(StringReader reader)
		{
			return reader != null && reader.Peek() != -1;
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x0002582C File Offset: 0x00023A2C
		private char ReadNextChar(StringReader reader)
		{
			char c = (char)reader.Read();
			if (c == '\n')
			{
				this.row++;
				this.column = 1;
			}
			else
			{
				this.column++;
			}
			return c;
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00025874 File Offset: 0x00023A74
		private void ParseChar(StringReader reader, char requiredChar)
		{
			if (this.IsNextChar(reader, requiredChar))
			{
				this.ReadNextChar(reader);
				return;
			}
			throw new ParserException("Expected '" + requiredChar + "'");
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x000258AC File Offset: 0x00023AAC
		private void ParseOpenParen(StringReader reader)
		{
			this.ParseChar(reader, '(');
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x000258B8 File Offset: 0x00023AB8
		private void ParseCloseParen(StringReader reader)
		{
			this.ParseChar(reader, ')');
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x000258C4 File Offset: 0x00023AC4
		private string[] ParseParameters(StringReader reader)
		{
			List<string> list = new List<string>();
			int num = 0;
			while (this.IsNextCharNot(reader, ')') && num < 9999)
			{
				num++;
				this.ParseOptionalWhitespace(reader);
				list.Add(this.ParseParameter(reader));
				if (this.IsNextChar(reader, ','))
				{
					this.ReadNextChar(reader);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x0002592C File Offset: 0x00023B2C
		private string ParseParameter(StringReader reader)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int num2 = 0;
			while (this.HasNextChar(reader) && num2 < 9999)
			{
				num2++;
				char c = (char)reader.Peek();
				if (num <= 0 && (c == ',' || c == ')'))
				{
					break;
				}
				char c2 = this.ReadNextChar(reader);
				stringBuilder.Append(c2);
				if (c2 == '(')
				{
					num++;
				}
				else if (c2 == ')')
				{
					num--;
				}
			}
			return stringBuilder.ToString().Trim();
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x000259C8 File Offset: 0x00023BC8
		private void ParsePostParameters(StringReader reader, out float atTime, out string atMessage, out string sendMessage)
		{
			atTime = 0f;
			atMessage = string.Empty;
			sendMessage = string.Empty;
			if (this.IsNextChar(reader, '@'))
			{
				this.ParseAtSignModifier(reader, out atTime, out atMessage);
			}
			this.ParseOptionalWhitespace(reader);
			if (this.IsNextChar(reader, '-'))
			{
				this.ParseArrowModifier(reader, out sendMessage);
			}
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00025A20 File Offset: 0x00023C20
		private void ParseAtSignModifier(StringReader reader, out float atTime, out string atMessage)
		{
			atTime = 0f;
			atMessage = string.Empty;
			if (this.IsNextChar(reader, '@'))
			{
				this.ReadNextChar(reader);
				this.ParseOptionalWhitespace(reader);
				string text = this.ParseWord(reader, false);
				if (string.Equals(text, "message", StringComparison.OrdinalIgnoreCase))
				{
					this.ParseOptionalWhitespace(reader);
					this.ParseChar(reader, '(');
					this.ParseOptionalWhitespace(reader);
					text = this.ParseWord(reader, true);
					this.ParseChar(reader, ')');
					atMessage = text;
					atTime = ((!string.IsNullOrEmpty(atMessage)) ? 31536000f : 0f);
				}
				else
				{
					float num;
					if (!float.TryParse(text, out num))
					{
						throw new ParserException("Can't convert " + text + " to a number");
					}
					atTime = num;
				}
			}
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00025AEC File Offset: 0x00023CEC
		private void ParseArrowModifier(StringReader reader, out string sendMessage)
		{
			sendMessage = string.Empty;
			if (this.IsNextChar(reader, '-'))
			{
				this.ReadNextChar(reader);
				if (!this.IsNextChar(reader, '>'))
				{
					throw new ParserException("Invalid modifier after command; expected @time, @Message(x), ->Message(x) or nothing");
				}
				this.ReadNextChar(reader);
				this.ParseOptionalWhitespace(reader);
				string text = this.ParseWord(reader, false);
				if (string.Equals(text, "message", StringComparison.OrdinalIgnoreCase))
				{
					this.ParseOptionalWhitespace(reader);
					this.ParseChar(reader, '(');
					this.ParseOptionalWhitespace(reader);
					text = this.ParseWord(reader, true);
					sendMessage = text.Trim();
					this.ParseChar(reader, ')');
				}
			}
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00025B8C File Offset: 0x00023D8C
		private void ParseSemicolonOrEnd(StringReader reader)
		{
			if (!this.HasNextChar(reader) || (ushort)reader.Peek() == 59)
			{
				this.ReadNextChar(reader);
				return;
			}
			throw new ParserException("Expected semicolon or end of sequence");
		}

		// Token: 0x04000E04 RID: 3588
		private const int MaxSafeguard = 9999;

		// Token: 0x04000E05 RID: 3589
		private int column;

		// Token: 0x04000E06 RID: 3590
		private int row;
	}
}
