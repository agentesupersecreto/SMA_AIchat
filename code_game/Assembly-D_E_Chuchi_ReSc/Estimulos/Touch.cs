using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x020002A5 RID: 677
	public abstract class Touch : EstimuloTactil
	{
		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool allowDownCopy
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x00045ED2 File Offset: 0x000440D2
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x00045EDA File Offset: 0x000440DA
		public List<Collider> colliders { get; protected set; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00045EE3 File Offset: 0x000440E3
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x00045EEB File Offset: 0x000440EB
		public List<Rigidbody> rigids { get; protected set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x00045EF4 File Offset: 0x000440F4
		public Vector3 promedioPuntos
		{
			get
			{
				return base.posicionGlobalDelEstimulo;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x00045EFC File Offset: 0x000440FC
		public Vector3 promedioNormales
		{
			get
			{
				return base.normalGlobalDelEstimulo;
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x00045F04 File Offset: 0x00044104
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x00045F0C File Offset: 0x0004410C
		[Obsolete("", true)]
		public float maxMaxRelativeVelocity { get; protected set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x00045F15 File Offset: 0x00044115
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00045F1D File Offset: 0x0004411D
		[Obsolete("", true)]
		public float maxTotalRelativeVelocity { get; protected set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00045F26 File Offset: 0x00044126
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00045F2E File Offset: 0x0004412E
		[Obsolete("", true)]
		public float maxMaxImpulse { get; protected set; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x00045F37 File Offset: 0x00044137
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x00045F3F File Offset: 0x0004413F
		[Obsolete("", true)]
		public float maxTotalImpulse { get; protected set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x00045F48 File Offset: 0x00044148
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x00045F50 File Offset: 0x00044150
		public float maxMaxEmulatedRelativeStepVelocity
		{
			get
			{
				return base.velocidadRelativaEmuladaMaxima;
			}
			protected set
			{
				base.velocidadRelativaEmuladaMaxima = value;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000F2D RID: 3885 RVA: 0x00045F59 File Offset: 0x00044159
		// (set) Token: 0x06000F2E RID: 3886 RVA: 0x00045F61 File Offset: 0x00044161
		public float maxTotalEmulatedRelativeStepVelocity
		{
			get
			{
				return base.velocidadRelativaEmuladaTotal;
			}
			protected set
			{
				base.velocidadRelativaEmuladaTotal = value;
			}
		}
	}
}
