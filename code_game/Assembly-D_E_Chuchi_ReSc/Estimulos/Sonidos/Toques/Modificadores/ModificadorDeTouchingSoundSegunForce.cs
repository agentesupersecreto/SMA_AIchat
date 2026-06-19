using System;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002C0 RID: 704
	public class ModificadorDeTouchingSoundSegunForce : ModificadorDeTouchingSound
	{
		// Token: 0x06000FBB RID: 4027 RVA: 0x00047E54 File Offset: 0x00046054
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			if (!toque.esDePhysicsEngine)
			{
				mods.pitch *= this.config.noPhysicsPitch;
				mods.volumen *= this.config.noPhysicsVol;
				return;
			}
			bool flag = this.debugDraw;
			this.m_velocidadRelativaEmuladaMaxima = toque.velocidadRelativaEmuladaMaxima;
			this.m_force = toque.impulsoPhysics.magnitude / Time.fixedDeltaTime;
			float num = ModificadorDeTouchingSound.Lerp(this.config.forceToMinVol, this.config.forceToMaxVol, this.config.minVol, this.config.maxVol, this.config.outPowerVol, 1f, this.m_force);
			mods.volumen *= num;
			if (this.config.modificarPitch)
			{
				float num2 = ModificadorDeTouchingSound.Lerp(this.config.forceToMinPitch, this.config.forceToMaxPitch, this.config.minPitch, this.config.maxPitch, this.config.outPowerPitch, 1f, this.m_force);
				mods.pitch *= num2;
			}
		}

		// Token: 0x04000D00 RID: 3328
		[SerializeField]
		private float m_force;

		// Token: 0x04000D01 RID: 3329
		[SerializeField]
		private float m_velocidadRelativaEmuladaMaxima;

		// Token: 0x04000D02 RID: 3330
		public bool debugDraw;

		// Token: 0x04000D03 RID: 3331
		public ModificadorDeTouchingSoundSegunForce.Config config = new ModificadorDeTouchingSoundSegunForce.Config();

		// Token: 0x020002C1 RID: 705
		[Serializable]
		public class Config
		{
			// Token: 0x04000D04 RID: 3332
			public float noPhysicsVol = 1f;

			// Token: 0x04000D05 RID: 3333
			public float noPhysicsPitch = 1f;

			// Token: 0x04000D06 RID: 3334
			public float forceToMinVol;

			// Token: 0x04000D07 RID: 3335
			public float forceToMaxVol;

			// Token: 0x04000D08 RID: 3336
			public float minVol;

			// Token: 0x04000D09 RID: 3337
			public float maxVol;

			// Token: 0x04000D0A RID: 3338
			public float outPowerVol = 1f;

			// Token: 0x04000D0B RID: 3339
			public bool modificarPitch = true;

			// Token: 0x04000D0C RID: 3340
			public float forceToMinPitch;

			// Token: 0x04000D0D RID: 3341
			public float forceToMaxPitch;

			// Token: 0x04000D0E RID: 3342
			public float minPitch;

			// Token: 0x04000D0F RID: 3343
			public float maxPitch;

			// Token: 0x04000D10 RID: 3344
			public float outPowerPitch = 1f;
		}
	}
}
