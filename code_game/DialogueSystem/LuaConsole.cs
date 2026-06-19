using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000006 RID: 6
	[AddComponentMenu("Dialogue System/Miscellaneous/Lua Console")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/lua_console.html")]
	public class LuaConsole : MonoBehaviour
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002758 File Offset: 0x00000958
		private void Start()
		{
			this.SetVisible(this.visible);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002768 File Offset: 0x00000968
		private void SetVisible(bool newValue)
		{
			this.visible = newValue;
			if (this.pauseGameWhileOpen)
			{
				Time.timeScale = (float)((!this.visible) ? 1 : 0);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000027A0 File Offset: 0x000009A0
		private void OnGUI()
		{
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == this.firstKey)
			{
				this.isFirstKeyDown = true;
			}
			else if (Event.current.type == EventType.KeyUp && Event.current.keyCode == this.firstKey)
			{
				this.isFirstKeyDown = false;
			}
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == this.secondKey && this.isFirstKeyDown)
			{
				Event.current.Use();
				this.SetVisible(!this.visible);
			}
			if (this.visible && this.pauseGameWhileOpen)
			{
				Time.timeScale = 0f;
			}
			if (this.visible)
			{
				this.DrawConsole();
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002884 File Offset: 0x00000A84
		private void DrawConsole()
		{
			if (this.windowRect.width <= 0f)
			{
				this.windowRect = this.DefineWindowRect();
				this.closeButtonRect = new Rect(this.windowRect.width - 30f, 2f, 26f, 16f);
			}
			this.windowRect = GUI.Window(0, this.windowRect, new GUI.WindowFunction(this.DrawConsoleWindow), "Lua Console");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002900 File Offset: 0x00000B00
		private Rect DefineWindowRect()
		{
			float num = Mathf.Max(this.minSize.x, (float)Screen.width / 4f);
			float num2 = Mathf.Max(this.minSize.y, (float)Screen.height / 4f);
			return new Rect((float)Screen.width - num, 0f, num, num2);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000295C File Offset: 0x00000B5C
		private void DrawConsoleWindow(int id)
		{
			if (this.IsKeyEvent(KeyCode.Return))
			{
				this.RunLuaCommand();
			}
			else if (this.IsKeyEvent(KeyCode.UpArrow))
			{
				this.UseHistory(-1);
			}
			else if (this.IsKeyEvent(KeyCode.DownArrow))
			{
				this.UseHistory(1);
			}
			else if (this.IsKeyEvent(KeyCode.Escape) || GUI.Button(this.closeButtonRect, "X"))
			{
				this.SetVisible(false);
				return;
			}
			GUI.SetNextControlName("Input");
			GUI.FocusControl("Input");
			if (string.Equals(this.input, "\n"))
			{
				this.input = string.Empty;
			}
			this.input = GUILayout.TextArea(this.input, new GUILayoutOption[0]);
			this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, new GUILayoutOption[0]);
			GUILayout.Label(this.output, new GUILayoutOption[0]);
			GUILayout.EndScrollView();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A5C File Offset: 0x00000C5C
		private bool IsKeyEvent(KeyCode keyCode)
		{
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == keyCode)
			{
				Event.current.Use();
				return true;
			}
			return false;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A98 File Offset: 0x00000C98
		private void RunLuaCommand()
		{
			if (string.IsNullOrEmpty(this.input))
			{
				return;
			}
			try
			{
				Lua.Result result = Lua.Run(this.input, DialogueDebug.LogInfo);
				this.output = "Output: " + this.GetLuaResultString(result);
			}
			catch (Exception ex)
			{
				this.output = "Output: [Exception] " + ex.Message;
			}
			this.history.Add(this.input);
			if (this.history.Count >= this.maxHistory)
			{
				this.history.RemoveAt(0);
			}
			this.historyPosition = this.history.Count;
			this.input = string.Empty;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B6C File Offset: 0x00000D6C
		private string GetLuaResultString(Lua.Result result)
		{
			if (!result.HasReturnValue)
			{
				return "(no return value)";
			}
			return (!result.IsTable) ? result.AsString : this.FormatTableResult(result);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002BAC File Offset: 0x00000DAC
		private string FormatTableResult(Lua.Result result)
		{
			if (!result.IsTable)
			{
				return result.AsString;
			}
			LuaTableWrapper asTable = result.AsTable;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Table:\n");
			foreach (object obj in asTable.Keys)
			{
				stringBuilder.Append(string.Format("[{0}]: {1}\n", new object[]
				{
					obj.ToString(),
					asTable[obj.ToString()].ToString()
				}));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002C70 File Offset: 0x00000E70
		private void UseHistory(int direction)
		{
			this.historyPosition = Mathf.Clamp(this.historyPosition + direction, 0, this.history.Count);
			this.input = ((this.history.Count <= 0 || this.historyPosition >= this.history.Count) ? string.Empty : this.history[this.historyPosition]);
		}

		// Token: 0x0400000D RID: 13
		[Tooltip("Hold down this key and press Second Key to open console.")]
		public KeyCode firstKey = KeyCode.BackQuote;

		// Token: 0x0400000E RID: 14
		[Tooltip("Hold down First Key and press this key to open console.")]
		public KeyCode secondKey = KeyCode.L;

		// Token: 0x0400000F RID: 15
		[Tooltip("Console is visible.")]
		public bool visible;

		// Token: 0x04000010 RID: 16
		[Tooltip("Minimum size of console window.")]
		public Vector2 minSize = new Vector2(256f, 256f);

		// Token: 0x04000011 RID: 17
		[Tooltip("Max number of previous commands to remember.")]
		public int maxHistory = 20;

		// Token: 0x04000012 RID: 18
		[Tooltip("While open, set Time.timeScale to 0.")]
		public bool pauseGameWhileOpen;

		// Token: 0x04000013 RID: 19
		private List<string> history = new List<string>();

		// Token: 0x04000014 RID: 20
		private int historyPosition;

		// Token: 0x04000015 RID: 21
		private string input = string.Empty;

		// Token: 0x04000016 RID: 22
		private string output = string.Empty;

		// Token: 0x04000017 RID: 23
		private Rect windowRect = new Rect(0f, 0f, 0f, 0f);

		// Token: 0x04000018 RID: 24
		private Rect closeButtonRect = new Rect(0f, 0f, 0f, 0f);

		// Token: 0x04000019 RID: 25
		private Vector2 scrollPosition = new Vector2(0f, 0f);

		// Token: 0x0400001A RID: 26
		private bool isFirstKeyDown;
	}
}
