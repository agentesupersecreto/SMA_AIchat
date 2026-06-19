using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases.Genericos;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair.Alteradores
{
	// Token: 0x0200016F RID: 367
	public class AlteradoresDeCabelloFemenino : HolderTrialDeAlteradores<AlteradorGenericoDeIndex, AlteradorGenericoDirectoSingleConInicial, AlteradorGenericoDirectoTripleConInicial>
	{
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0002956C File Offset: 0x0002776C
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate1;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x00023F85 File Offset: 0x00022185
		protected override GlobalUpdater.UpdateType? updateTypeC
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x00023F85 File Offset: 0x00022185
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002956F File Offset: 0x0002776F
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeCabelloGpu = this.GetComponentEnCharacter(false);
			if (this.m_ControlladorDeCabelloGpu == null)
			{
				throw new ArgumentNullException("m_ControlladorDeCabelloGpu", "m_ControlladorDeCabelloGpu null reference.");
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void InstanciarAlteradores(List<AlteradorGenericoDeIndex> resultado)
		{
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void InstanciarAlteradoresB(List<AlteradorGenericoDirectoSingleConInicial> resultado)
		{
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void InstanciarAlteradoresC(List<AlteradorGenericoDirectoTripleConInicial> resultado)
		{
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x000295A4 File Offset: 0x000277A4
		private void GetterColor(out float a, out float b, out float c)
		{
			a = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.hue.@base;
			b = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.saturation.@base;
			c = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.value.@base;
		}

		// Token: 0x0400063B RID: 1595
		public AlteradoresDeCabelloFemenino.Rangos rangos = new AlteradoresDeCabelloFemenino.Rangos();

		// Token: 0x0400063C RID: 1596
		private ControlladorDeCabelloGpu m_ControlladorDeCabelloGpu;

		// Token: 0x02000170 RID: 368
		[Serializable]
		public class Rangos
		{
			// Token: 0x0400063D RID: 1597
			[Range(0f, 1f)]
			public float minLargoDeCerdas = 0.5f;

			// Token: 0x0400063E RID: 1598
			public AlteradoresDeCabelloFemenino.Rangos.RangosDecolor color = new AlteradoresDeCabelloFemenino.Rangos.RangosDecolor();

			// Token: 0x02000171 RID: 369
			[Serializable]
			public class RangosDecolor
			{
				// Token: 0x0400063F RID: 1599
				[Range(-360f, 360f)]
				public float minHue;

				// Token: 0x04000640 RID: 1600
				[Range(-360f, 360f)]
				public float maxHue = 360f;

				// Token: 0x04000641 RID: 1601
				[Range(0f, 100f)]
				public float minSaturation;

				// Token: 0x04000642 RID: 1602
				[Range(0f, 100f)]
				public float maxSaturation = 100f;

				// Token: 0x04000643 RID: 1603
				[Range(0f, 100f)]
				public float minBrightness;

				// Token: 0x04000644 RID: 1604
				[Range(0f, 100f)]
				public float maxBrightness = 100f;

				// Token: 0x04000645 RID: 1605
				[Range(0f, 100f)]
				public float minAlpha;

				// Token: 0x04000646 RID: 1606
				[Range(0f, 100f)]
				public float maxAlpha = 100f;
			}
		}
	}
}
