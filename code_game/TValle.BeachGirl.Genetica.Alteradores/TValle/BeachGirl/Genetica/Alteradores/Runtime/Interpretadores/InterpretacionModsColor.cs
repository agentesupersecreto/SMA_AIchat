using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000054 RID: 84
	[Obsolete("dividir En Varios")]
	public struct InterpretacionModsColor
	{
		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000F308 File Offset: 0x0000D508
		public static InterpretacionModsColor @default
		{
			get
			{
				return new InterpretacionModsColor
				{
					hue = 1f,
					saturation = 1f,
					brightness = 1f,
					opacity = 1f
				};
			}
		}

		// Token: 0x04000179 RID: 377
		public float hue;

		// Token: 0x0400017A RID: 378
		public float saturation;

		// Token: 0x0400017B RID: 379
		public float brightness;

		// Token: 0x0400017C RID: 380
		public float opacity;
	}
}
