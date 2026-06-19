using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	public class MusclescConfigPinChangeSegunDistanceOffsets : ConfiguracionParaTarget<MusclescConfigPinChangeSegunDistanceOffsets>
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00006060 File Offset: 0x00004260
		protected override void OnAplicarOnFemale(MusclescConfigPinChangeSegunDistanceOffsets target, FemaleAnimController controller)
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00006100 File Offset: 0x00004300
		public static MusclescConfigPinChangeSegunDistanceOffsets defaultDesactivado
		{
			get
			{
				return new MusclescConfigPinChangeSegunDistanceOffsets
				{
					hips = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					spine1 = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					spine2 = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					neck = MusclePinChangeSegunDistanceOffsets.softDesactivado,
					head = MusclePinChangeSegunDistanceOffsets.softDesactivado,
					thighs = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					calfs = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					feets = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					shoulders = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					upperarms = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					forearms = MusclePinChangeSegunDistanceOffsets.defaultDesactivado,
					hands = MusclePinChangeSegunDistanceOffsets.defaultDesactivado
				};
			}
		}

		// Token: 0x04000062 RID: 98
		[Header("Spine")]
		public MusclePinChangeSegunDistanceOffsets hips = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x04000063 RID: 99
		public MusclePinChangeSegunDistanceOffsets spine1 = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x04000064 RID: 100
		public MusclePinChangeSegunDistanceOffsets spine2 = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x04000065 RID: 101
		public MusclePinChangeSegunDistanceOffsets neck = MusclePinChangeSegunDistanceOffsets.softActivado;

		// Token: 0x04000066 RID: 102
		public MusclePinChangeSegunDistanceOffsets head = MusclePinChangeSegunDistanceOffsets.softActivado;

		// Token: 0x04000067 RID: 103
		[Header("Legs")]
		public MusclePinChangeSegunDistanceOffsets thighs = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x04000068 RID: 104
		public MusclePinChangeSegunDistanceOffsets calfs = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x04000069 RID: 105
		public MusclePinChangeSegunDistanceOffsets feets = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x0400006A RID: 106
		[Header("Arms")]
		public MusclePinChangeSegunDistanceOffsets shoulders = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x0400006B RID: 107
		public MusclePinChangeSegunDistanceOffsets upperarms = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x0400006C RID: 108
		public MusclePinChangeSegunDistanceOffsets forearms = MusclePinChangeSegunDistanceOffsets.defaultActivado;

		// Token: 0x0400006D RID: 109
		public MusclePinChangeSegunDistanceOffsets hands = MusclePinChangeSegunDistanceOffsets.defaultActivado;
	}
}
