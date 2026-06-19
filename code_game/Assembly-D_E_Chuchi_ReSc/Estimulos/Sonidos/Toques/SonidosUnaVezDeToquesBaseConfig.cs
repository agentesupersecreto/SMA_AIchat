using System;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AF RID: 687
	[Serializable]
	public class SonidosUnaVezDeToquesBaseConfig
	{
		// Token: 0x04000CCD RID: 3277
		public bool reproducirSoloEnterToques = true;

		// Token: 0x04000CCE RID: 3278
		public float minVelocidadParaReproducirNoEnterToques = 3f;

		// Token: 0x04000CCF RID: 3279
		public bool debugDrawMaxAngle;

		// Token: 0x04000CD0 RID: 3280
		public float maxAngleParaReproducirNoEnterToques = 60f;

		// Token: 0x04000CD1 RID: 3281
		public float volModOnNoEnterToques = 1f;

		// Token: 0x04000CD2 RID: 3282
		public float pitchModOnNoEnterToques = 1f;
	}
}
