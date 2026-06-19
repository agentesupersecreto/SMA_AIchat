using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	public struct MusclePinChangeSegunDistanceOffsets : IConfiguracionParaTarget<MusclePinChangeSegunDistanceOffsets>
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x00005D24 File Offset: 0x00003F24
		public void Aplicar(ref MusclePinChangeSegunDistanceOffsets target)
		{
			target.activated = this.activated;
			target.maxPin = this.maxPin;
			target.distanceToMaxPinChange = this.distanceToMaxPinChange;
			target.distanceInPower = this.distanceInPower;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00005D56 File Offset: 0x00003F56
		public bool Validar()
		{
			return this.maxPin >= 0f && this.maxPin <= 1f && this.distanceInPower >= 0f && this.distanceToMaxPinChange >= 0f;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00005D94 File Offset: 0x00003F94
		public static MusclePinChangeSegunDistanceOffsets defaultActivado
		{
			get
			{
				return new MusclePinChangeSegunDistanceOffsets
				{
					activated = true,
					maxPin = 1f,
					distanceToMaxPinChange = 0.35f,
					distanceInPower = 2f
				};
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00005DD8 File Offset: 0x00003FD8
		public static MusclePinChangeSegunDistanceOffsets defaultDesactivado
		{
			get
			{
				return new MusclePinChangeSegunDistanceOffsets
				{
					activated = false,
					maxPin = 1f,
					distanceToMaxPinChange = 0.35f,
					distanceInPower = 2f
				};
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00005E1C File Offset: 0x0000401C
		public static MusclePinChangeSegunDistanceOffsets softActivado
		{
			get
			{
				return new MusclePinChangeSegunDistanceOffsets
				{
					activated = true,
					maxPin = 1f,
					distanceToMaxPinChange = 0.35f,
					distanceInPower = 3f
				};
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00005E60 File Offset: 0x00004060
		public static MusclePinChangeSegunDistanceOffsets softDesactivado
		{
			get
			{
				return new MusclePinChangeSegunDistanceOffsets
				{
					activated = false,
					maxPin = 1f,
					distanceToMaxPinChange = 0.35f,
					distanceInPower = 3f
				};
			}
		}

		// Token: 0x04000059 RID: 89
		public bool activated;

		// Token: 0x0400005A RID: 90
		[Range(0f, 0.75f)]
		public float distanceToMaxPinChange;

		// Token: 0x0400005B RID: 91
		[Range(0f, 1f)]
		public float maxPin;

		// Token: 0x0400005C RID: 92
		public float distanceInPower;
	}
}
