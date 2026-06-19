using System;
using System.Collections;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x0200001A RID: 26
	public class Log : MonoBehaviour
	{
		// Token: 0x06000153 RID: 339 RVA: 0x00009AC2 File Offset: 0x00007CC2
		public IEnumerator Start()
		{
			Log.FilePath = this._FilePath;
			Log.FontSize = this._ScreenFontSize;
			Log.ForeColor = this._ScreenForeColor;
			Log.LineCount = this._LineCount;
			Log.LineHeight = this._ScreenFontSize + 6;
			Log.ClearScreenEachFrame = this._ClearScreenEachFrame;
			Log.PrefixTime = this._PrefixTime;
			Log.IsFileEnabled = this._IsFileEnabled;
			Log.IsScreenEnabled = this._IsScreenEnabled;
			Log.IsConsoleEnabled = this._IsConsoleEnabled;
			Log.FileFlushPerWrite = this._FileFlushPerWrite;
			WaitForEndOfFrame lWaitForEndOfFrame = new WaitForEndOfFrame();
			for (;;)
			{
				yield return lWaitForEndOfFrame;
				if (Log.mClearScreenEachFrame)
				{
					Log.Clear();
				}
			}
			yield break;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00009AD1 File Offset: 0x00007CD1
		public void OnDestroy()
		{
			Log.Close();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00009AD8 File Offset: 0x00007CD8
		private void OnGUI()
		{
			Log.Render();
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00009ADF File Offset: 0x00007CDF
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00009AE6 File Offset: 0x00007CE6
		public static string FilePath
		{
			get
			{
				return Log.mFilePath;
			}
			set
			{
				Log.mFilePath = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00009AEE File Offset: 0x00007CEE
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00009AF5 File Offset: 0x00007CF5
		public static bool PrefixTime
		{
			get
			{
				return Log.mPrefixTime;
			}
			set
			{
				Log.mPrefixTime = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00009AFD File Offset: 0x00007CFD
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00009B04 File Offset: 0x00007D04
		public static int LineHeight
		{
			get
			{
				return Log.mLineHeight;
			}
			set
			{
				Log.mLineHeight = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00009B0C File Offset: 0x00007D0C
		// (set) Token: 0x0600015D RID: 349 RVA: 0x00009B13 File Offset: 0x00007D13
		public static bool ClearScreenEachFrame
		{
			get
			{
				return Log.mClearScreenEachFrame;
			}
			set
			{
				Log.mClearScreenEachFrame = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00009B1B File Offset: 0x00007D1B
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00009B22 File Offset: 0x00007D22
		public static bool IsEnabled
		{
			get
			{
				return Log.mIsEnabled;
			}
			set
			{
				Log.mIsEnabled = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00009B2A File Offset: 0x00007D2A
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00009B31 File Offset: 0x00007D31
		public static bool IsFileEnabled
		{
			get
			{
				return Log.mIsFileEnabled;
			}
			set
			{
				Log.mIsFileEnabled = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00009B39 File Offset: 0x00007D39
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00009B40 File Offset: 0x00007D40
		public static bool IsScreenEnabled
		{
			get
			{
				return Log.mIsScreenEnabled;
			}
			set
			{
				Log.mIsScreenEnabled = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00009B48 File Offset: 0x00007D48
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00009B4F File Offset: 0x00007D4F
		public static bool IsConsoleEnabled
		{
			get
			{
				return Log.mIsConsoleEnabled;
			}
			set
			{
				Log.mIsConsoleEnabled = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00009B57 File Offset: 0x00007D57
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00009B5E File Offset: 0x00007D5E
		public static bool FileFlushPerWrite
		{
			get
			{
				return Log.mFileFlushPerWrite;
			}
			set
			{
				Log.mFileFlushPerWrite = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00009B66 File Offset: 0x00007D66
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00009B70 File Offset: 0x00007D70
		public static int LineCount
		{
			get
			{
				return Log.mLineCount;
			}
			set
			{
				if (Log.mLineCount != value)
				{
					Log.mLineCount = value;
					Log.mLines = new LogText[Log.mLineCount];
					for (int i = 0; i < Log.mLines.Length; i++)
					{
						LogText logText = new LogText();
						logText.X = 10;
						logText.Y = i * Log.mLineHeight;
						logText.Text = "";
						Log.mLines[i] = logText;
					}
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00009BDA File Offset: 0x00007DDA
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00009BE1 File Offset: 0x00007DE1
		public static int FontSize
		{
			get
			{
				return Log.mFontSize;
			}
			set
			{
				Log.mFontSize = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00009BE9 File Offset: 0x00007DE9
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00009BF0 File Offset: 0x00007DF0
		public static Color ForeColor
		{
			get
			{
				return Log.mForeColor;
			}
			set
			{
				Log.mForeColor = value;
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00009BF8 File Offset: 0x00007DF8
		static Log()
		{
			if (Log.mLines == null)
			{
				Log.mLines = new LogText[Log.mLineCount];
			}
			for (int i = 0; i < Log.mLines.Length; i++)
			{
				LogText logText = new LogText();
				logText.X = 10;
				logText.Y = i * Log.mLineHeight;
				logText.Text = "";
				Log.mLines[i] = logText;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00009CC5 File Offset: 0x00007EC5
		public static void Write(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mIsFileEnabled)
			{
				Log.FileWrite(rText);
			}
			if (Log.mIsScreenEnabled)
			{
				Log.ScreenWrite(rText);
			}
			if (Log.mIsConsoleEnabled)
			{
				Log.ConsoleWrite(rText);
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00009CF6 File Offset: 0x00007EF6
		public static void FileScreenWrite(string rText, int rLine)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mIsScreenEnabled)
			{
				Log.ScreenWrite(rText, rLine);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00009D0E File Offset: 0x00007F0E
		public static void FileWrite(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00009D36 File Offset: 0x00007F36
		public static void FileWrite(string rText, bool rPrefixTime)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime && rPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00009D60 File Offset: 0x00007F60
		public static void ConsoleScreenWrite(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			Log.ConsoleWrite(rText);
			Log.ScreenWrite(rText);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00009D76 File Offset: 0x00007F76
		public static void ConsoleScreenWrite(string rText, int rLine)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			Log.ConsoleWrite(rText);
			Log.ScreenWrite(rText, rLine);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00009D8D File Offset: 0x00007F8D
		public static void ConsoleWrite(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			Debug.Log(rText);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00009DBB File Offset: 0x00007FBB
		public static void ConsoleWrite(string rText, bool rPrefixTime)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime && rPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			Debug.Log(rText);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00009DEB File Offset: 0x00007FEB
		public static void ConsoleWriteWarning(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			Debug.LogWarning(rText);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00009E19 File Offset: 0x00008019
		public static void ConsoleWriteError(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			Debug.LogError(rText);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00009E47 File Offset: 0x00008047
		public static void ScreenWrite(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			Log.ScreenWrite(rText, 10, Log.mLineIndex * Log.mLineHeight);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00009E64 File Offset: 0x00008064
		public static void ScreenWrite(int rLine, params string[] rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			Log.ScreenWrite(string.Join(" ", rText), 10, rLine * Log.mLineHeight);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00009E87 File Offset: 0x00008087
		public static void ScreenWrite(string rText, int rLine)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			Log.ScreenWrite(rText, 10, rLine * Log.mLineHeight);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00009EA0 File Offset: 0x000080A0
		public static void ScreenWrite(string rText, int rX, int rY)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			int num = rY / Log.mLineHeight;
			if (num < Log.mLines.Length)
			{
				if (Log.mLines[num] == null)
				{
					LogText logText = new LogText();
					logText.X = rX;
					logText.Y = num * Log.mLineHeight;
					logText.Text = rText;
					Log.mLines[num] = logText;
				}
				else
				{
					Log.mLines[num].Text = rText;
				}
			}
			Log.mLineIndex++;
			if (Log.mLineIndex >= Log.mLineCount)
			{
				Log.mLineIndex = Log.mLineCount - 1;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00009F4C File Offset: 0x0000814C
		public static void ScreenWriteTop(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			for (int i = Log.mLines.Length - 1; i > 0; i--)
			{
				Log.mLines[i].Text = Log.mLines[i - 1].Text;
			}
			Log.mLines[0].Text = rText;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00009FBC File Offset: 0x000081BC
		public static void ScreenWriteBottom(string rText)
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mPrefixTime)
			{
				rText = string.Format("[{0:f4}] {1}", Time.realtimeSinceStartup, rText);
			}
			for (int i = 0; i < Log.mLines.Length - 1; i++)
			{
				Log.mLines[i].Text = Log.mLines[i + 1].Text;
			}
			Log.mLines[Log.mLines.Length - 1].Text = rText;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000A034 File Offset: 0x00008234
		public static void Render()
		{
			if (!Log.mIsEnabled)
			{
				return;
			}
			if (Log.mLines.Length == 0)
			{
				return;
			}
			GUIStyle guistyle = new GUIStyle();
			guistyle.alignment = TextAnchor.UpperLeft;
			guistyle.normal.textColor = Color.white;
			guistyle.fontSize = Log.mFontSize;
			GUI.contentColor = Log.mForeColor;
			GUI.backgroundColor = Color.green;
			for (int i = 0; i < Log.mLines.Length; i++)
			{
				LogText logText = Log.mLines[i];
				if (logText.Text.Length != 0)
				{
					Log.mLineRect.x = (float)logText.X;
					Log.mLineRect.y = (float)logText.Y;
					Log.mLineRect.width = 900f;
					Log.mLineRect.height = (float)Log.mLineHeight;
					GUI.Label(Log.mLineRect, logText.Text, guistyle);
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000A108 File Offset: 0x00008308
		public static void Clear()
		{
			for (int i = 0; i < Log.mLines.Length; i++)
			{
				Log.mLines[i].Text = "";
			}
			Log.mLineIndex = 0;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000A13E File Offset: 0x0000833E
		public static void Close()
		{
		}

		// Token: 0x040000DA RID: 218
		public bool _PrefixTime = true;

		// Token: 0x040000DB RID: 219
		public bool _IsConsoleEnabled = true;

		// Token: 0x040000DC RID: 220
		public bool _IsScreenEnabled = true;

		// Token: 0x040000DD RID: 221
		public int _LineCount = 30;

		// Token: 0x040000DE RID: 222
		public int _ScreenFontSize = 12;

		// Token: 0x040000DF RID: 223
		public Color _ScreenForeColor = Color.black;

		// Token: 0x040000E0 RID: 224
		public bool _ClearScreenEachFrame = true;

		// Token: 0x040000E1 RID: 225
		public bool _IsFileEnabled;

		// Token: 0x040000E2 RID: 226
		public string _FilePath = ".\\Log.txt";

		// Token: 0x040000E3 RID: 227
		public bool _FileFlushPerWrite;

		// Token: 0x040000E4 RID: 228
		private static string mFilePath = ".\\Log.txt";

		// Token: 0x040000E5 RID: 229
		private static bool mPrefixTime = true;

		// Token: 0x040000E6 RID: 230
		private static int mLineHeight = 18;

		// Token: 0x040000E7 RID: 231
		private static bool mClearScreenEachFrame = true;

		// Token: 0x040000E8 RID: 232
		private static bool mIsEnabled = true;

		// Token: 0x040000E9 RID: 233
		private static bool mIsFileEnabled = false;

		// Token: 0x040000EA RID: 234
		private static bool mIsScreenEnabled = true;

		// Token: 0x040000EB RID: 235
		private static bool mIsConsoleEnabled = true;

		// Token: 0x040000EC RID: 236
		private static bool mFileFlushPerWrite = true;

		// Token: 0x040000ED RID: 237
		private static int mLineCount = 30;

		// Token: 0x040000EE RID: 238
		private static int mFontSize = 12;

		// Token: 0x040000EF RID: 239
		private static Color mForeColor = Color.black;

		// Token: 0x040000F0 RID: 240
		private static LogText[] mLines = null;

		// Token: 0x040000F1 RID: 241
		private static int mLineIndex = 0;

		// Token: 0x040000F2 RID: 242
		private static Rect mLineRect = default(Rect);
	}
}
