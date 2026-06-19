using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x02000179 RID: 377
	public interface IUIElementoSecondaryBindable
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000B3B RID: 2875
		bool isSecondaryBinded { get; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000B3C RID: 2876
		Type secondaryModelType { get; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000B3D RID: 2877
		string secondaryModelName { get; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000B3E RID: 2878
		int secondaryModelIndex { get; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000B3F RID: 2879
		Func<object> secondaryModeloValueGetter { get; }

		// Token: 0x06000B40 RID: 2880
		void SecondaryBind(string ModeloName, Type ModeloType, int Index, Func<object> ModeloValueGetter);
	}
}
