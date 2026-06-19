using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000053 RID: 83
	[Obsolete("dividir En Varios")]
	public struct InterpretacionMods
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
		public static InterpretacionMods @default
		{
			get
			{
				return new InterpretacionMods
				{
					general = 1f
				};
			}
		}

		// Token: 0x04000178 RID: 376
		public float general;
	}
}
