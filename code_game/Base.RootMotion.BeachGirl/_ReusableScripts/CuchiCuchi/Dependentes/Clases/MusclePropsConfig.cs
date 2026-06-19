using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x0200005C RID: 92
	[Serializable]
	public class MusclePropsConfig : ConfiguracionParaTarget<Muscle.Props>
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x000132C6 File Offset: 0x000114C6
		protected override void OnAplicarOnFemale(Muscle.Props target, FemaleAnimController controller)
		{
			target.mappingWeight = this.mappingWeight;
			target.pinWeight = this.pinWeight;
			target.muscleWeight = this.muscleWeight;
			target.muscleDamper = this.muscleDamper;
			target.mapPosition = this.mapPosition;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00013304 File Offset: 0x00011504
		public void CopiarDesde(MusclePropsConfig other)
		{
			this.mappingWeight = other.mappingWeight;
			this.pinWeight = other.pinWeight;
			this.muscleWeight = other.muscleWeight;
			this.muscleDamper = other.muscleDamper;
			this.mapPosition = other.mapPosition;
		}

		// Token: 0x040002A1 RID: 673
		[Tooltip("The weight (multiplier) of mapping this muscle's target to the muscle.")]
		[Range(0f, 1f)]
		public float mappingWeight = 1f;

		// Token: 0x040002A2 RID: 674
		[Tooltip("The weight (multiplier) of pinning this muscle to it's target's position using a simple AddForce command.")]
		[Range(0f, 1f)]
		public float pinWeight = 1f;

		// Token: 0x040002A3 RID: 675
		[Tooltip("The muscle strength (multiplier).")]
		[Range(0f, 5f)]
		public float muscleWeight = 1f;

		// Token: 0x040002A4 RID: 676
		[Tooltip("Multiplier of the positionDamper of the ConfigurableJoints' Slerp Drive.")]
		[Range(0f, 5f)]
		public float muscleDamper = 1f;

		// Token: 0x040002A5 RID: 677
		[Header("OJO puede causar problemas, es mejor q las extremidades NO lo tengan activado")]
		[Tooltip("If true, will map the target to the world space position of the muscle. Normally this should be true for only the root muscle (the hips).")]
		public bool mapPosition = true;
	}
}
