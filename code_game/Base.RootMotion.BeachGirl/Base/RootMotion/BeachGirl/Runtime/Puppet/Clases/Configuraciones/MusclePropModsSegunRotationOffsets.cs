using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	public struct MusclePropModsSegunRotationOffsets : IConfiguracionParaTarget<MusclePropModsSegunRotationOffsets>
	{
		// Token: 0x060000BD RID: 189 RVA: 0x00005EA2 File Offset: 0x000040A2
		public void Aplicar(ref MusclePropModsSegunRotationOffsets target)
		{
			target.activated = this.activated;
			target.maxSpringMod = this.maxSpringMod;
			target.maxDamperMod = this.maxDamperMod;
			target.angleToMaxModChange = this.angleToMaxModChange;
			target.angleInPower = this.angleInPower;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00005EE0 File Offset: 0x000040E0
		public bool Validar()
		{
			return this.maxSpringMod >= 0f && this.maxDamperMod >= 0f && this.angleInPower >= 0f && this.angleToMaxModChange >= 0f;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00005F20 File Offset: 0x00004120
		public static MusclePropModsSegunRotationOffsets defaultActivado
		{
			get
			{
				return new MusclePropModsSegunRotationOffsets
				{
					activated = true,
					maxSpringMod = 2f,
					maxDamperMod = 6f,
					angleToMaxModChange = 25f,
					angleInPower = 2f
				};
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00005F70 File Offset: 0x00004170
		public static MusclePropModsSegunRotationOffsets defaultDesactivado
		{
			get
			{
				return new MusclePropModsSegunRotationOffsets
				{
					activated = false,
					maxSpringMod = 2f,
					maxDamperMod = 6f,
					angleToMaxModChange = 25f,
					angleInPower = 2f
				};
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00005FC0 File Offset: 0x000041C0
		public static MusclePropModsSegunRotationOffsets softActivado
		{
			get
			{
				return new MusclePropModsSegunRotationOffsets
				{
					activated = true,
					maxSpringMod = 2f,
					maxDamperMod = 6f,
					angleToMaxModChange = 25f,
					angleInPower = 3f
				};
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00006010 File Offset: 0x00004210
		public static MusclePropModsSegunRotationOffsets softDesactivado
		{
			get
			{
				return new MusclePropModsSegunRotationOffsets
				{
					activated = false,
					maxSpringMod = 2f,
					maxDamperMod = 6f,
					angleToMaxModChange = 25f,
					angleInPower = 3f
				};
			}
		}

		// Token: 0x0400005D RID: 93
		public bool activated;

		// Token: 0x0400005E RID: 94
		[Range(0f, 180f)]
		public float angleToMaxModChange;

		// Token: 0x0400005F RID: 95
		[Range(1f, 10f)]
		public float maxSpringMod;

		// Token: 0x04000060 RID: 96
		[Range(1f, 10f)]
		public float maxDamperMod;

		// Token: 0x04000061 RID: 97
		public float angleInPower;
	}
}
