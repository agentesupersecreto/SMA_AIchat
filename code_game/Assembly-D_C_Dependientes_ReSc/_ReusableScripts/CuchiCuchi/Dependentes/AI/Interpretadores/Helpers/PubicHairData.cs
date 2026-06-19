using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A6 RID: 934
	[Serializable]
	public class PubicHairData : IPubicHairInterpretadorHelper
	{
		// Token: 0x060017E1 RID: 6113 RVA: 0x00070108 File Offset: 0x0006E308
		public void Generate(HelperDeInterpretadorBase helper)
		{
			MapaSingletonDeFemalePubesTextures.Conjunto currentConjunto = helper.controlladorDeFemalePubesApariencia.currentConjunto;
			this.currentDensity = Mathf.Clamp01(((currentConjunto != null) ? new float?(currentConjunto.densidadSubjetiva) : null).GetValueOrDefault());
			this.color = helper.controlladorDeFemalePubesApariencia.colorDePubesSinModificaciones;
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x060017E2 RID: 6114 RVA: 0x0007015D File Offset: 0x0006E35D
		float IPubicHairInterpretadorHelper.currentDensity
		{
			get
			{
				return this.currentDensity;
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x060017E3 RID: 6115 RVA: 0x00070165 File Offset: 0x0006E365
		Color IPubicHairInterpretadorHelper.colorSinModificaciones
		{
			get
			{
				return this.color;
			}
		}

		// Token: 0x04001199 RID: 4505
		public float currentDensity;

		// Token: 0x0400119A RID: 4506
		public Color color;
	}
}
