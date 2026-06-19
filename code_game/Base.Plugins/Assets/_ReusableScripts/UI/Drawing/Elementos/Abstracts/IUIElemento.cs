using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x02000178 RID: 376
	public interface IUIElemento
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000B32 RID: 2866
		string name { get; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000B33 RID: 2867
		Transform transform { get; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000B34 RID: 2868
		Transform panelTransform { get; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000B35 RID: 2869
		bool isBinded { get; }

		// Token: 0x06000B36 RID: 2870
		void Bind(string modeloName, Type modeloType, bool isListItem);

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000B37 RID: 2871
		int modelItemIndex { get; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000B38 RID: 2872
		string modelName { get; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000B39 RID: 2873
		Type modelType { get; }

		// Token: 0x06000B3A RID: 2874
		void AddedTo(Transform PanelTransform);
	}
}
