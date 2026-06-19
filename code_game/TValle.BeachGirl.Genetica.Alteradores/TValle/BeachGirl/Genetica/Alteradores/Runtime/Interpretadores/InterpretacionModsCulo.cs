using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000055 RID: 85
	[Obsolete("dividir En Varios")]
	public struct InterpretacionModsCulo
	{
		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000F350 File Offset: 0x0000D550
		public static InterpretacionModsCulo @default
		{
			get
			{
				return new InterpretacionModsCulo
				{
					culoGeneral = 1f,
					culoX = 1f,
					culoY = 1f,
					culoZ = 1f
				};
			}
		}

		// Token: 0x0400017D RID: 381
		public float culoGeneral;

		// Token: 0x0400017E RID: 382
		public float culoX;

		// Token: 0x0400017F RID: 383
		public float culoY;

		// Token: 0x04000180 RID: 384
		public float culoZ;
	}
}
