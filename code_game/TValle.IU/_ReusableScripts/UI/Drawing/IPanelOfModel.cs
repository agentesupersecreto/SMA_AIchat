using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000030 RID: 48
	public interface IPanelOfModel
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600014F RID: 335
		bool isShowing { get; }

		// Token: 0x06000150 RID: 336
		void Clear();

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000151 RID: 337
		bool isBinded { get; }

		// Token: 0x06000152 RID: 338
		void Show();

		// Token: 0x06000153 RID: 339
		void Hide();

		// Token: 0x06000154 RID: 340
		void CrearYDibujar(DibujadorDynamico.ExtraData extraData = null);

		// Token: 0x06000155 RID: 341
		bool CanShow();

		// Token: 0x06000156 RID: 342
		object CurrentModelObjectAndState(out bool changed);

		// Token: 0x06000157 RID: 343
		object GetLastDrawModel();

		// Token: 0x06000158 RID: 344
		void ActualizarValoresDeModelo();

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000159 RID: 345
		[Obsolete("Mal hecho", true)]
		GenericUserPanelBase genericUserPanel { get; }
	}
}
