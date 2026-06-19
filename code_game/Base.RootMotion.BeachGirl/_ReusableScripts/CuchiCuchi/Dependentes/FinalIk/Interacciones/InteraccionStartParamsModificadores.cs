using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200009B RID: 155
	[Serializable]
	public struct InteraccionStartParamsModificadores
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x0001DF74 File Offset: 0x0001C174
		public static InteraccionStartParamsModificadores @default
		{
			get
			{
				return new InteraccionStartParamsModificadores
				{
					duracion = 1f,
					initialVelocidadIn = 1f,
					velocidadIn = 1f,
					velocidadOut = 1f
				};
			}
		}

		// Token: 0x04000442 RID: 1090
		public float duracion;

		// Token: 0x04000443 RID: 1091
		public float initialVelocidadIn;

		// Token: 0x04000444 RID: 1092
		public float velocidadIn;

		// Token: 0x04000445 RID: 1093
		public float velocidadOut;
	}
}
