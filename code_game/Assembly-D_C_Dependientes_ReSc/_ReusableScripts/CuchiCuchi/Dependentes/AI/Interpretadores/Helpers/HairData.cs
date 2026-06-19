using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A0 RID: 928
	[Serializable]
	public class HairData : IHairInterpretadorHelper
	{
		// Token: 0x06001752 RID: 5970 RVA: 0x0006ED24 File Offset: 0x0006CF24
		public void Generate(HelperDeInterpretadorBase helper)
		{
			float num = 0f;
			float num2 = 0.5f;
			EstiloDeCabelloGpu currentStilo = helper.controlladorDeCabelloGpu.currentStilo;
			this.currentLengthWeigth = Mathf.InverseLerp(num, num2, ((currentStilo != null) ? new float?(currentStilo.largo) : null).GetValueOrDefault());
			this.color = helper.controlladorDeCabelloGpu.colorDeGpuHair.colorCalculadoAlphaNormalizado;
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001753 RID: 5971 RVA: 0x0006ED88 File Offset: 0x0006CF88
		float IHairInterpretadorHelper.currentLengthWeigth
		{
			get
			{
				return this.currentLengthWeigth;
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001754 RID: 5972 RVA: 0x0006ED90 File Offset: 0x0006CF90
		Color IHairInterpretadorHelper.colorSinModificaciones
		{
			get
			{
				return this.color;
			}
		}

		// Token: 0x04001108 RID: 4360
		public float currentLengthWeigth;

		// Token: 0x04001109 RID: 4361
		public Color color;
	}
}
