using System;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009D RID: 157
	public class GenericMenu
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x000152AA File Offset: 0x000134AA
		public GenericMenu()
		{
			GenericMenu.popup = new PopupMenu();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000152BC File Offset: 0x000134BC
		public void ShowAsContext()
		{
			GenericMenu.popup.Show(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 0f, 0f));
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000152F5 File Offset: 0x000134F5
		public void AddItem(GUIContent content, bool on, PopupMenu.MenuFunctionData func, object userData)
		{
			GenericMenu.popup.AddItem(content, on, func, userData);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00015306 File Offset: 0x00013506
		public void AddItem(GUIContent content, bool on, PopupMenu.MenuFunction func)
		{
			GenericMenu.popup.AddItem(content, on, func);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00015315 File Offset: 0x00013515
		public void AddSeparator(string path)
		{
			GenericMenu.popup.AddSeparator(path);
		}

		// Token: 0x04000145 RID: 325
		private static PopupMenu popup;
	}
}
