using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A9 RID: 937
	[Serializable]
	public class SenosSkinRangesData : SkinRangesDataBase, ISenosRangesParaInterpretadores, IRangesParaInterpretadores, ISenosInterpretadorHelper
	{
		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x060017F7 RID: 6135 RVA: 0x000708D9 File Offset: 0x0006EAD9
		protected override IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccion
		{
			get
			{
				return ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos;
			}
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x000708E0 File Offset: 0x0006EAE0
		public override void Generate(HelperDeInterpretadorBase helper)
		{
			base.Generate(helper);
			this.colorDePezones = helper.controlladorDeFemalePiel.colorDePezonesSinModificaciones;
			this.currentSubjectiveAureolaSize = helper.controlladorDeFemalePiel.currentConjuntoDePezones.radioAureolaSubjetivo;
			this.currentSubjectiveNippleSize = helper.controlladorDeFemalePiel.currentConjuntoDePezones.sizePezonSubjetivo;
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x00070931 File Offset: 0x0006EB31
		Color ISenosInterpretadorHelper.colorDePezonesSinModificaciones
		{
			get
			{
				return this.colorDePezones;
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x060017FA RID: 6138 RVA: 0x00070939 File Offset: 0x0006EB39
		float ISenosInterpretadorHelper.minBrightness
		{
			get
			{
				return 0.3f;
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x060017FB RID: 6139 RVA: 0x000392AF File Offset: 0x000374AF
		float ISenosInterpretadorHelper.maxBrightness
		{
			get
			{
				return 0.75f;
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x060017FC RID: 6140 RVA: 0x00070940 File Offset: 0x0006EB40
		float ISenosInterpretadorHelper.currentSubjectiveAureolaSize
		{
			get
			{
				return this.currentSubjectiveAureolaSize;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x060017FD RID: 6141 RVA: 0x00070948 File Offset: 0x0006EB48
		float ISenosInterpretadorHelper.currentSubjectiveNippleSize
		{
			get
			{
				return this.currentSubjectiveNippleSize;
			}
		}

		// Token: 0x040011AD RID: 4525
		public Color colorDePezones;

		// Token: 0x040011AE RID: 4526
		public float currentSubjectiveAureolaSize;

		// Token: 0x040011AF RID: 4527
		public float currentSubjectiveNippleSize;
	}
}
