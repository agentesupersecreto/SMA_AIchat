using System;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002BE RID: 702
	public class ModificadorDeTouchingSoundSegunContactos : ModificadorDeTouchingSound
	{
		// Token: 0x06000FB8 RID: 4024 RVA: 0x00047D88 File Offset: 0x00045F88
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			this.m_cantidadContactos = (float)toque.cantidadDeContanctos;
			this.m_currentMod = ModificadorDeTouchingSound.Lerp(this.config.cantidadToMinVol, this.config.cantidadToMaxVol, this.config.minVol, this.config.maxVol, this.config.outPowerVol, 1f, this.m_cantidadContactos);
			mods.volumen *= this.m_currentMod;
		}

		// Token: 0x04000CF8 RID: 3320
		[SerializeField]
		private float m_cantidadContactos;

		// Token: 0x04000CF9 RID: 3321
		[SerializeField]
		private float m_currentMod;

		// Token: 0x04000CFA RID: 3322
		public ModificadorDeTouchingSoundSegunContactos.Config config = new ModificadorDeTouchingSoundSegunContactos.Config();

		// Token: 0x020002BF RID: 703
		[Serializable]
		public class Config
		{
			// Token: 0x04000CFB RID: 3323
			public float cantidadToMinVol = 1f;

			// Token: 0x04000CFC RID: 3324
			public float cantidadToMaxVol = 5f;

			// Token: 0x04000CFD RID: 3325
			public float minVol = 0.33f;

			// Token: 0x04000CFE RID: 3326
			public float maxVol = 1f;

			// Token: 0x04000CFF RID: 3327
			public float outPowerVol = 2f;
		}
	}
}
