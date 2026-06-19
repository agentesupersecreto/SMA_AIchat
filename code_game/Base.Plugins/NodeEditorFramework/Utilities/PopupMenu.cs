using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009C RID: 156
	public class PopupMenu
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x00014B35 File Offset: 0x00012D35
		public PopupMenu()
		{
			this.SetupGUI();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00014B5C File Offset: 0x00012D5C
		public void SetupGUI()
		{
			PopupMenu.backgroundStyle = new GUIStyle(GUI.skin.box);
			PopupMenu.backgroundStyle.contentOffset = new Vector2(2f, 2f);
			PopupMenu.expandRight = ResourceManager.LoadTexture("Textures/expandRight.png");
			PopupMenu.itemHeight = GUI.skin.label.CalcHeight(new GUIContent("text"), 100f);
			PopupMenu.selectedLabel = new GUIStyle(GUI.skin.label);
			PopupMenu.selectedLabel.normal.background = RTEditorGUI.ColorToTex(1, new Color(0.4f, 0.4f, 0.4f));
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00014C05 File Offset: 0x00012E05
		public void Show(Rect pos)
		{
			this.position = pos;
			this.selectedPath = "";
			OverlayGUI.currentPopup = this;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00014C20 File Offset: 0x00012E20
		public void AddItem(GUIContent content, bool on, PopupMenu.MenuFunctionData func, object userData)
		{
			string text;
			PopupMenu.MenuItem menuItem = this.AddHierarchy(ref content, out text);
			if (menuItem != null)
			{
				menuItem.subItems.Add(new PopupMenu.MenuItem(text, content, func, userData));
				return;
			}
			this.menuItems.Add(new PopupMenu.MenuItem(text, content, func, userData));
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00014C68 File Offset: 0x00012E68
		public void AddItem(GUIContent content, bool on, PopupMenu.MenuFunction func)
		{
			string text;
			PopupMenu.MenuItem menuItem = this.AddHierarchy(ref content, out text);
			if (menuItem != null)
			{
				menuItem.subItems.Add(new PopupMenu.MenuItem(text, content, func));
				return;
			}
			this.menuItems.Add(new PopupMenu.MenuItem(text, content, func));
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00014CAC File Offset: 0x00012EAC
		public void AddSeparator(string path)
		{
			GUIContent guicontent = new GUIContent(path);
			PopupMenu.MenuItem menuItem = this.AddHierarchy(ref guicontent, out path);
			if (menuItem != null)
			{
				menuItem.subItems.Add(new PopupMenu.MenuItem());
				return;
			}
			this.menuItems.Add(new PopupMenu.MenuItem());
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00014CF0 File Offset: 0x00012EF0
		private PopupMenu.MenuItem AddHierarchy(ref GUIContent content, out string path)
		{
			path = content.text;
			if (path.Contains("/"))
			{
				string[] array = path.Split('/', StringSplitOptions.None);
				string folderPath = array[0];
				PopupMenu.MenuItem menuItem = this.menuItems.Find((PopupMenu.MenuItem item) => item.content != null && item.content.text == folderPath);
				if (menuItem == null)
				{
					this.menuItems.Add(menuItem = new PopupMenu.MenuItem(folderPath, new GUIContent(folderPath), true));
				}
				for (int i = 1; i < array.Length - 1; i++)
				{
					string folder = array[i];
					folderPath = folderPath + "/" + folder;
					PopupMenu.MenuItem menuItem2 = menuItem.subItems.Find((PopupMenu.MenuItem item) => item.content != null && item.content.text == folder);
					if (menuItem2 == null)
					{
						menuItem.subItems.Add(menuItem2 = new PopupMenu.MenuItem(folderPath, new GUIContent(folder), true));
					}
					menuItem = menuItem2;
				}
				path = content.text;
				content = new GUIContent(array[array.Length - 1], content.tooltip);
				return menuItem;
			}
			return null;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00014E1C File Offset: 0x0001301C
		public void Draw()
		{
			bool flag = this.DrawGroup(this.position, this.menuItems);
			while (this.groupToDraw != null && !this.close)
			{
				PopupMenu.MenuItem menuItem = this.groupToDraw;
				this.groupToDraw = null;
				if (menuItem.group && this.DrawGroup(menuItem.groupPos, menuItem.subItems))
				{
					flag = true;
				}
			}
			if (!flag || this.close)
			{
				OverlayGUI.currentPopup = null;
			}
			NodeEditor.RepaintClients();
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00014E90 File Offset: 0x00013090
		private bool DrawGroup(Rect pos, List<PopupMenu.MenuItem> menuItems)
		{
			Rect rect = PopupMenu.calculateRect(pos.position, menuItems);
			Rect rect2 = new Rect(rect);
			rect2.xMax += 20f;
			rect2.xMin -= 20f;
			rect2.yMax += 20f;
			rect2.yMin -= 20f;
			bool flag = rect2.Contains(Event.current.mousePosition);
			this.currentItemHeight = PopupMenu.backgroundStyle.contentOffset.y;
			GUI.BeginGroup(PopupMenu.extendRect(rect, PopupMenu.backgroundStyle.contentOffset), GUIContent.none, PopupMenu.backgroundStyle);
			for (int i = 0; i < menuItems.Count; i++)
			{
				this.DrawItem(menuItems[i], rect);
				if (this.close)
				{
					break;
				}
			}
			GUI.EndGroup();
			return flag;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00014F74 File Offset: 0x00013174
		private void DrawItem(PopupMenu.MenuItem item, Rect groupRect)
		{
			if (item.separator)
			{
				if (Event.current.type == EventType.Repaint)
				{
					RTEditorGUI.Seperator(new Rect(PopupMenu.backgroundStyle.contentOffset.x + 1f, this.currentItemHeight + 1f, groupRect.width - 2f, 1f));
				}
				this.currentItemHeight += 3f;
				return;
			}
			Rect rect = new Rect(PopupMenu.backgroundStyle.contentOffset.x, this.currentItemHeight, groupRect.width, PopupMenu.itemHeight);
			bool flag = this.selectedPath.Contains(item.path);
			if (rect.Contains(Event.current.mousePosition))
			{
				this.selectedPath = item.path;
				flag = true;
			}
			GUI.Label(rect, item.content, flag ? PopupMenu.selectedLabel : GUI.skin.label);
			if (item.group)
			{
				GUI.DrawTexture(new Rect(rect.x + rect.width - 12f, rect.y + (rect.height - 12f) / 2f, 12f, 12f), PopupMenu.expandRight);
				if (flag)
				{
					item.groupPos = new Rect(groupRect.x + groupRect.width + 4f, groupRect.y + this.currentItemHeight - 2f, 0f, 0f);
					this.groupToDraw = item;
				}
			}
			else if (flag && (Event.current.type == EventType.MouseDown || (Event.current.button != 1 && Event.current.type == EventType.MouseUp)) && this.selectedPath == item.path)
			{
				item.Execute();
				this.close = true;
				Event.current.Use();
			}
			this.currentItemHeight += PopupMenu.itemHeight;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00015168 File Offset: 0x00013368
		private static Rect extendRect(Rect rect, Vector2 extendValue)
		{
			rect.x -= extendValue.x;
			rect.y -= extendValue.y;
			rect.width += extendValue.x + extendValue.x;
			rect.height += extendValue.y + extendValue.y;
			return rect;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x000151D4 File Offset: 0x000133D4
		private static Rect calculateRect(Vector2 position, List<PopupMenu.MenuItem> menuItems)
		{
			float num = 40f;
			float num2 = 0f;
			for (int i = 0; i < menuItems.Count; i++)
			{
				PopupMenu.MenuItem menuItem = menuItems[i];
				if (menuItem.separator)
				{
					num2 += 3f;
				}
				else
				{
					num = Mathf.Max(num, GUI.skin.label.CalcSize(menuItem.content).x + (float)(menuItem.group ? 22 : 10));
					num2 += PopupMenu.itemHeight;
				}
			}
			Vector2 vector = new Vector2(num, num2);
			bool flag = position.y + vector.y <= (float)Screen.height;
			return new Rect(position.x, position.y - (flag ? 0f : vector.y), vector.x, vector.y);
		}

		// Token: 0x0400013B RID: 315
		public List<PopupMenu.MenuItem> menuItems = new List<PopupMenu.MenuItem>();

		// Token: 0x0400013C RID: 316
		private Rect position;

		// Token: 0x0400013D RID: 317
		private string selectedPath = "";

		// Token: 0x0400013E RID: 318
		private PopupMenu.MenuItem groupToDraw;

		// Token: 0x0400013F RID: 319
		private float currentItemHeight;

		// Token: 0x04000140 RID: 320
		private bool close;

		// Token: 0x04000141 RID: 321
		public static GUIStyle backgroundStyle;

		// Token: 0x04000142 RID: 322
		public static Texture2D expandRight;

		// Token: 0x04000143 RID: 323
		public static float itemHeight;

		// Token: 0x04000144 RID: 324
		public static GUIStyle selectedLabel;

		// Token: 0x020001BB RID: 443
		// (Invoke) Token: 0x06000C32 RID: 3122
		public delegate void MenuFunction();

		// Token: 0x020001BC RID: 444
		// (Invoke) Token: 0x06000C36 RID: 3126
		public delegate void MenuFunctionData(object userData);

		// Token: 0x020001BD RID: 445
		public class MenuItem
		{
			// Token: 0x06000C39 RID: 3129 RVA: 0x000268C2 File Offset: 0x00024AC2
			public MenuItem()
			{
				this.separator = true;
			}

			// Token: 0x06000C3A RID: 3130 RVA: 0x000268D1 File Offset: 0x00024AD1
			public MenuItem(string _path, GUIContent _content, bool _group)
			{
				this.path = _path;
				this.content = _content;
				this.group = _group;
				if (this.group)
				{
					this.subItems = new List<PopupMenu.MenuItem>();
				}
			}

			// Token: 0x06000C3B RID: 3131 RVA: 0x00026901 File Offset: 0x00024B01
			public MenuItem(string _path, GUIContent _content, PopupMenu.MenuFunction _func)
			{
				this.path = _path;
				this.content = _content;
				this.func = _func;
			}

			// Token: 0x06000C3C RID: 3132 RVA: 0x0002691E File Offset: 0x00024B1E
			public MenuItem(string _path, GUIContent _content, PopupMenu.MenuFunctionData _func, object _userData)
			{
				this.path = _path;
				this.content = _content;
				this.funcData = _func;
				this.userData = _userData;
			}

			// Token: 0x06000C3D RID: 3133 RVA: 0x00026943 File Offset: 0x00024B43
			public void Execute()
			{
				if (this.funcData != null)
				{
					this.funcData(this.userData);
					return;
				}
				if (this.func != null)
				{
					this.func();
				}
			}

			// Token: 0x04000421 RID: 1057
			public string path;

			// Token: 0x04000422 RID: 1058
			public GUIContent content;

			// Token: 0x04000423 RID: 1059
			public PopupMenu.MenuFunction func;

			// Token: 0x04000424 RID: 1060
			public PopupMenu.MenuFunctionData funcData;

			// Token: 0x04000425 RID: 1061
			public object userData;

			// Token: 0x04000426 RID: 1062
			public bool separator;

			// Token: 0x04000427 RID: 1063
			public bool group;

			// Token: 0x04000428 RID: 1064
			public Rect groupPos;

			// Token: 0x04000429 RID: 1065
			public List<PopupMenu.MenuItem> subItems;
		}
	}
}
