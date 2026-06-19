using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones
{
	// Token: 0x02000017 RID: 23
	[Serializable]
	public class MusclesConfigPropModsSegunRotationOffsets : ConfiguracionParaTarget<MusclesConfigPropModsSegunRotationOffsets>
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00006230 File Offset: 0x00004430
		protected override void OnAplicarOnFemale(MusclesConfigPropModsSegunRotationOffsets target, FemaleAnimController controller)
		{
			target.hips = this.hips;
			target.spine1 = this.spine1;
			target.spine2 = this.spine2;
			target.neck = this.neck;
			target.head = this.head;
			target.thighs = this.thighs;
			target.calfs = this.calfs;
			target.feets = this.feets;
			target.shoulders = this.shoulders;
			target.upperarms = this.upperarms;
			target.forearms = this.forearms;
			target.hands = this.hands;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x000062D0 File Offset: 0x000044D0
		public static MusclesConfigPropModsSegunRotationOffsets defaultDesactivado
		{
			get
			{
				return new MusclesConfigPropModsSegunRotationOffsets
				{
					hips = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					spine1 = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					spine2 = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					neck = MusclePropModsSegunRotationOffsets.softDesactivado,
					head = MusclePropModsSegunRotationOffsets.softDesactivado,
					thighs = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					calfs = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					feets = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					shoulders = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					upperarms = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					forearms = MusclePropModsSegunRotationOffsets.defaultDesactivado,
					hands = MusclePropModsSegunRotationOffsets.defaultDesactivado
				};
			}
		}

		// Token: 0x0400006E RID: 110
		[Header("Spine")]
		public MusclePropModsSegunRotationOffsets hips = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x0400006F RID: 111
		public MusclePropModsSegunRotationOffsets spine1 = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000070 RID: 112
		public MusclePropModsSegunRotationOffsets spine2 = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000071 RID: 113
		public MusclePropModsSegunRotationOffsets neck = MusclePropModsSegunRotationOffsets.softActivado;

		// Token: 0x04000072 RID: 114
		public MusclePropModsSegunRotationOffsets head = MusclePropModsSegunRotationOffsets.softActivado;

		// Token: 0x04000073 RID: 115
		[Header("Legs")]
		public MusclePropModsSegunRotationOffsets thighs = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000074 RID: 116
		public MusclePropModsSegunRotationOffsets calfs = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000075 RID: 117
		public MusclePropModsSegunRotationOffsets feets = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000076 RID: 118
		[Header("Arms")]
		public MusclePropModsSegunRotationOffsets shoulders = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000077 RID: 119
		public MusclePropModsSegunRotationOffsets upperarms = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000078 RID: 120
		public MusclePropModsSegunRotationOffsets forearms = MusclePropModsSegunRotationOffsets.defaultActivado;

		// Token: 0x04000079 RID: 121
		public MusclePropModsSegunRotationOffsets hands = MusclePropModsSegunRotationOffsets.defaultActivado;
	}
}
