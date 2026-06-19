using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x020000FD RID: 253
	[Serializable]
	public class GamePlayObjectiveModel
	{
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0001AC91 File Offset: 0x00018E91
		public static GamePlayObjectiveModel empty
		{
			get
			{
				return GamePlayObjectiveModel.m_empty;
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000789 RID: 1929 RVA: 0x0001AC98 File Offset: 0x00018E98
		// (remove) Token: 0x0600078A RID: 1930 RVA: 0x0001ACD0 File Offset: 0x00018ED0
		public event Action<int, GamePlayObjectiveModel> onClicked;

		// Token: 0x0600078B RID: 1931 RVA: 0x0001AD05 File Offset: 0x00018F05
		internal void OnClicked(IUIElementoClickable elemento, int index)
		{
			Action<int, GamePlayObjectiveModel> action = this.onClicked;
			if (action == null)
			{
				return;
			}
			action(index, this);
		}

		// Token: 0x040002F3 RID: 755
		private static GamePlayObjectiveModel m_empty = new GamePlayObjectiveModel
		{
			id = "None",
			completed = true,
			description = string.Empty,
			progress = string.Empty,
			subObjetives = new List<ValueTuple<string, bool>>(),
			tooltip = string.Empty
		};

		// Token: 0x040002F5 RID: 757
		public string id;

		// Token: 0x040002F6 RID: 758
		public bool completed;

		// Token: 0x040002F7 RID: 759
		public string description;

		// Token: 0x040002F8 RID: 760
		public string progress;

		// Token: 0x040002F9 RID: 761
		public List<ValueTuple<string, bool>> subObjetives = new List<ValueTuple<string, bool>>();

		// Token: 0x040002FA RID: 762
		public string tooltip;
	}
}
