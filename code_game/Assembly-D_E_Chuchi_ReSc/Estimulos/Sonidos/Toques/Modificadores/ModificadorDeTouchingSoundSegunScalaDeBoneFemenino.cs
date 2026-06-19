using System;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002C2 RID: 706
	public class ModificadorDeTouchingSoundSegunScalaDeBoneFemenino : ModificadorDeTouchingSound
	{
		// Token: 0x06000FBE RID: 4030 RVA: 0x00047FC2 File Offset: 0x000461C2
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_FemaleCharacterBones = this.GetComponentEnRoot(false);
			this.m_existenBones = this.m_FemaleCharacterBones != null;
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00047FEC File Offset: 0x000461EC
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			Transform transform;
			if (this.m_existenBones)
			{
				transform = this.m_FemaleCharacterBones.ObtenerScaleBone(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), toque.side);
			}
			else
			{
				transform = base.transform;
			}
			this.m_Scale = transform.lossyScale.Escala();
			this.m_currentVolMod = ModificadorDeTouchingSound.LerpAlMedio(this.config.scaleToMinVol, 1f, this.config.scaleToMaxVol, this.config.minVol, 1f, this.config.maxVol, this.config.outPowerVol, this.config.inPowerVol, this.m_Scale);
			mods.volumen *= this.m_currentVolMod;
			if (this.config.modificarPitch)
			{
				this.m_currentPitchMod = ModificadorDeTouchingSound.LerpAlMedio(this.config.scaleToMinPitch, 1f, this.config.scaleToMaxPitch, this.config.minPitch, 1f, this.config.maxPitch, this.config.outPowerPitch, this.config.inPowerPitch, this.m_Scale);
				mods.pitch *= this.m_currentPitchMod;
			}
		}

		// Token: 0x04000D11 RID: 3345
		[SerializeField]
		private float m_Scale;

		// Token: 0x04000D12 RID: 3346
		[SerializeField]
		private float m_currentVolMod;

		// Token: 0x04000D13 RID: 3347
		[SerializeField]
		private float m_currentPitchMod;

		// Token: 0x04000D14 RID: 3348
		private FemaleCharacterBones m_FemaleCharacterBones;

		// Token: 0x04000D15 RID: 3349
		private bool m_existenBones;

		// Token: 0x04000D16 RID: 3350
		public ModificadorDeTouchingSoundSegunScalaDeBoneFemenino.Config config = new ModificadorDeTouchingSoundSegunScalaDeBoneFemenino.Config();

		// Token: 0x020002C3 RID: 707
		[Serializable]
		public class Config
		{
			// Token: 0x04000D17 RID: 3351
			public float scaleToMinVol;

			// Token: 0x04000D18 RID: 3352
			public float scaleToMaxVol;

			// Token: 0x04000D19 RID: 3353
			public float minVol;

			// Token: 0x04000D1A RID: 3354
			public float maxVol;

			// Token: 0x04000D1B RID: 3355
			public float outPowerVol = 1f;

			// Token: 0x04000D1C RID: 3356
			public float inPowerVol = 1f;

			// Token: 0x04000D1D RID: 3357
			public bool modificarPitch = true;

			// Token: 0x04000D1E RID: 3358
			public float scaleToMinPitch;

			// Token: 0x04000D1F RID: 3359
			public float scaleToMaxPitch;

			// Token: 0x04000D20 RID: 3360
			public float minPitch;

			// Token: 0x04000D21 RID: 3361
			public float maxPitch;

			// Token: 0x04000D22 RID: 3362
			public float outPowerPitch = 1f;

			// Token: 0x04000D23 RID: 3363
			public float inPowerPitch = 1f;
		}
	}
}
