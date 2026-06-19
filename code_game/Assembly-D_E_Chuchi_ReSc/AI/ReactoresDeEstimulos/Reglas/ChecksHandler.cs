using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B1 RID: 945
	public static class ChecksHandler
	{
		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060014B2 RID: 5298 RVA: 0x00058D0C File Offset: 0x00056F0C
		public static bool isEditorDrawing
		{
			get
			{
				return ChecksHandler.isDrawingModificable.Or(false);
			}
		}

		// Token: 0x040010DF RID: 4319
		public static ModificableDeBool isDrawingModificable = new ModificableDeBool(false);
	}
}
