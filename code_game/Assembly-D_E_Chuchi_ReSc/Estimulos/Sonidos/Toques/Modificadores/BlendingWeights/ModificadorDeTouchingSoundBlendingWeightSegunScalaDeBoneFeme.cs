using System;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores.BlendingWeights
{
	// Token: 0x020002C4 RID: 708
	public class ModificadorDeTouchingSoundBlendingWeightSegunScalaDeBoneFemenino : ModificadorDeTouchingBlendingSound
	{
		// Token: 0x06000FC2 RID: 4034 RVA: 0x00048169 File Offset: 0x00046369
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_FemaleCharacterBones = this.GetComponentEnRoot(false);
			this.m_existenBones = this.m_FemaleCharacterBones != null;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00048190 File Offset: 0x00046390
		protected override void OnRegistrandoExtraData(EstimuloTactil toque, SonidoProductor other, SonidoBlendingExtraData extraData, object sender)
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
			this.m_currentMod = ModificadorDeTouchingSound.Lerp(this.config.scaleToMinWeight, this.config.scaleToMaxWeight, this.config.minWeight, this.config.maxWeight, this.config.outPowerVol, this.config.inPowerVol, this.m_Scale);
			if (extraData.wasSet)
			{
				extraData.SetValue(this.m_currentMod * extraData.blendWeight.Value);
				return;
			}
			extraData.SetValue(this.m_currentMod);
		}

		// Token: 0x04000D24 RID: 3364
		[SerializeField]
		private float m_Scale;

		// Token: 0x04000D25 RID: 3365
		[SerializeField]
		private float m_currentMod;

		// Token: 0x04000D26 RID: 3366
		private FemaleCharacterBones m_FemaleCharacterBones;

		// Token: 0x04000D27 RID: 3367
		private bool m_existenBones;

		// Token: 0x04000D28 RID: 3368
		public ModificadorDeTouchingSoundBlendingWeightSegunScalaDeBoneFemenino.Config config = new ModificadorDeTouchingSoundBlendingWeightSegunScalaDeBoneFemenino.Config();

		// Token: 0x020002C5 RID: 709
		[Serializable]
		public class Config
		{
			// Token: 0x04000D29 RID: 3369
			public float scaleToMinWeight;

			// Token: 0x04000D2A RID: 3370
			public float scaleToMaxWeight;

			// Token: 0x04000D2B RID: 3371
			public float minWeight;

			// Token: 0x04000D2C RID: 3372
			public float maxWeight;

			// Token: 0x04000D2D RID: 3373
			public float outPowerVol = 1f;

			// Token: 0x04000D2E RID: 3374
			public float inPowerVol = 1f;
		}
	}
}
