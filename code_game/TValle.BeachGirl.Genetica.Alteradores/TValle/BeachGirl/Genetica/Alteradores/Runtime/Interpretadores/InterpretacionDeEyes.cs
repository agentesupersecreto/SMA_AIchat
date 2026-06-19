using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000035 RID: 53
	[AplicaAConjuntoDeFisico(para = "eyes")]
	[Serializable]
	public struct InterpretacionDeEyes
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00007687 File Offset: 0x00005887
		// (set) Token: 0x06000186 RID: 390 RVA: 0x0000768F File Offset: 0x0000588F
		[AplicaAConjuntoDeFisico(para = "eyes", weigth = 20)]
		[LabelLocalizado("Size", "US")]
		public Interpretacion.Size size
		{
			get
			{
				return this.m_eyeSize;
			}
			set
			{
				this.m_eyeSize = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00007698 File Offset: 0x00005898
		// (set) Token: 0x06000188 RID: 392 RVA: 0x000076A0 File Offset: 0x000058A0
		[LabelLocalizado("Height", "US")]
		public Interpretacion.Capacidad height
		{
			get
			{
				return this.m_eyeHeight;
			}
			set
			{
				this.m_eyeHeight = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000189 RID: 393 RVA: 0x000076A9 File Offset: 0x000058A9
		// (set) Token: 0x0600018A RID: 394 RVA: 0x000076B1 File Offset: 0x000058B1
		[AplicaAConjuntoDeFisico(para = "eyes", weigth = 20)]
		[LabelLocalizado("Distance", "US")]
		public Interpretacion.Distance distance
		{
			get
			{
				return this.m_eyeDistance;
			}
			set
			{
				this.m_eyeDistance = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600018B RID: 395 RVA: 0x000076BA File Offset: 0x000058BA
		// (set) Token: 0x0600018C RID: 396 RVA: 0x000076C2 File Offset: 0x000058C2
		[LabelLocalizado("Depth", "US")]
		public Interpretacion.Depth depth
		{
			get
			{
				return this.m_eyeDepth;
			}
			set
			{
				this.m_eyeDepth = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000076CB File Offset: 0x000058CB
		// (set) Token: 0x0600018E RID: 398 RVA: 0x000076D3 File Offset: 0x000058D3
		[LabelLocalizado("Amplitude", "US")]
		public Interpretacion.Amplitude amplitude
		{
			get
			{
				return this.m_eyeAmplitude;
			}
			set
			{
				this.m_eyeAmplitude = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600018F RID: 399 RVA: 0x000076DC File Offset: 0x000058DC
		// (set) Token: 0x06000190 RID: 400 RVA: 0x000076E4 File Offset: 0x000058E4
		[LabelLocalizado("Angle", "US")]
		public Interpretacion.AngleDirection angle
		{
			get
			{
				return this.m_angle;
			}
			set
			{
				this.m_angle = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000191 RID: 401 RVA: 0x000076ED File Offset: 0x000058ED
		// (set) Token: 0x06000192 RID: 402 RVA: 0x000076F5 File Offset: 0x000058F5
		[LabelLocalizado("Iris Size", "US")]
		public Interpretacion.Size irisSize
		{
			get
			{
				return this.m_irisSize;
			}
			set
			{
				this.m_irisSize = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000076FE File Offset: 0x000058FE
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00007706 File Offset: 0x00005906
		[LabelLocalizado("EyelidHeavy", "US")]
		public Interpretacion.CantidadNoContable eyelidHeavy
		{
			get
			{
				return this.m_eyelidHeavy;
			}
			set
			{
				this.m_eyelidHeavy = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000770F File Offset: 0x0000590F
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00007717 File Offset: 0x00005917
		[LabelLocalizado("Eyelid Distance", "US")]
		public Interpretacion.Distance eyelidDistance
		{
			get
			{
				return this.m_eyelidDistance;
			}
			set
			{
				this.m_eyelidDistance = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00007720 File Offset: 0x00005920
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00007728 File Offset: 0x00005928
		[LabelLocalizado("Eyelid Depth", "US")]
		public Interpretacion.Depth eyelidDepth
		{
			get
			{
				return this.m_eyelidDepth;
			}
			set
			{
				this.m_eyelidDepth = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00007731 File Offset: 0x00005931
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00007739 File Offset: 0x00005939
		[LabelLocalizado("Upper Eyelid Smooth", "US")]
		public Interpretacion.Capacidad upperEyelidSmooth
		{
			get
			{
				return this.m_upperEyelidSmooth;
			}
			set
			{
				this.m_upperEyelidSmooth = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00007742 File Offset: 0x00005942
		// (set) Token: 0x0600019C RID: 412 RVA: 0x0000774A File Offset: 0x0000594A
		[LabelLocalizado("Upper Eyelid Height", "US")]
		public Interpretacion.Capacidad upperEyelidHeight
		{
			get
			{
				return this.m_upperEyelidHeight;
			}
			set
			{
				this.m_upperEyelidHeight = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00007753 File Offset: 0x00005953
		// (set) Token: 0x0600019E RID: 414 RVA: 0x0000775B File Offset: 0x0000595B
		[LabelLocalizado("Eyelid Top Flat", "US")]
		public Interpretacion.Capacidad eyelidTopFlat
		{
			get
			{
				return this.m_eyelidTopFlat;
			}
			set
			{
				this.m_eyelidTopFlat = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00007764 File Offset: 0x00005964
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000776C File Offset: 0x0000596C
		[LabelLocalizado(" Eyelid Top In Height", "US")]
		public Interpretacion.Capacidad eyelidTopInHeight
		{
			get
			{
				return this.m_eyelidTopInHeight;
			}
			set
			{
				this.m_eyelidTopInHeight = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00007775 File Offset: 0x00005975
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000777D File Offset: 0x0000597D
		[LabelLocalizado("Lower Eyelid Height", "US")]
		public Interpretacion.Capacidad lowerEyelidHeight
		{
			get
			{
				return this.m_lowerEyelidHeight;
			}
			set
			{
				this.m_lowerEyelidHeight = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00007786 File Offset: 0x00005986
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0000778E File Offset: 0x0000598E
		[LabelLocalizado("Eyelid Bottom Define", "US")]
		public Interpretacion.Capacidad eyelidBottomDefine
		{
			get
			{
				return this.m_eyelidBottomDefine;
			}
			set
			{
				this.m_eyelidBottomDefine = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00007797 File Offset: 0x00005997
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x0000779F File Offset: 0x0000599F
		[LabelLocalizado("Eyelid Bottom Out Height", "US")]
		public Interpretacion.Capacidad eyelidBottomOutHeight
		{
			get
			{
				return this.m_eyelidBottomOutHeight;
			}
			set
			{
				this.m_eyelidBottomOutHeight = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x000077A8 File Offset: 0x000059A8
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x000077B0 File Offset: 0x000059B0
		[LabelLocalizado("Wrinkle Inner", "US")]
		public Interpretacion.Capacidad wrinkleInner
		{
			get
			{
				return this.m_wrinkleInner;
			}
			set
			{
				this.m_wrinkleInner = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x000077B9 File Offset: 0x000059B9
		// (set) Token: 0x060001AA RID: 426 RVA: 0x000077C1 File Offset: 0x000059C1
		[LabelLocalizado("Eyelashes Length", "US")]
		public Interpretacion.Length eyelashesLength
		{
			get
			{
				return this.m_eyelashesLength;
			}
			set
			{
				this.m_eyelashesLength = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000077CA File Offset: 0x000059CA
		// (set) Token: 0x060001AC RID: 428 RVA: 0x000077D2 File Offset: 0x000059D2
		[LabelLocalizado("lacrimal Distance", "US")]
		public Interpretacion.Distance lacrimalDistance
		{
			get
			{
				return this.m_lacrimalDistance;
			}
			set
			{
				this.m_lacrimalDistance = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000077DB File Offset: 0x000059DB
		// (set) Token: 0x060001AE RID: 430 RVA: 0x000077E3 File Offset: 0x000059E3
		[LabelLocalizado("lacrimal Exposure", "US")]
		public Interpretacion.Capacidad lacrimalExposure
		{
			get
			{
				return this.m_lacrimalExposure;
			}
			set
			{
				this.m_lacrimalExposure = value;
			}
		}

		// Token: 0x04000082 RID: 130
		[SerializeField]
		private Interpretacion.Size m_eyeSize;

		// Token: 0x04000083 RID: 131
		[SerializeField]
		private Interpretacion.Capacidad m_eyeHeight;

		// Token: 0x04000084 RID: 132
		[SerializeField]
		private Interpretacion.Distance m_eyeDistance;

		// Token: 0x04000085 RID: 133
		[SerializeField]
		private Interpretacion.Depth m_eyeDepth;

		// Token: 0x04000086 RID: 134
		[SerializeField]
		private Interpretacion.Amplitude m_eyeAmplitude;

		// Token: 0x04000087 RID: 135
		[SerializeField]
		private Interpretacion.AngleDirection m_angle;

		// Token: 0x04000088 RID: 136
		[SerializeField]
		private Interpretacion.Size m_irisSize;

		// Token: 0x04000089 RID: 137
		[SerializeField]
		private Interpretacion.CantidadNoContable m_eyelidHeavy;

		// Token: 0x0400008A RID: 138
		[SerializeField]
		private Interpretacion.Distance m_eyelidDistance;

		// Token: 0x0400008B RID: 139
		[SerializeField]
		private Interpretacion.Depth m_eyelidDepth;

		// Token: 0x0400008C RID: 140
		[SerializeField]
		private Interpretacion.Capacidad m_upperEyelidSmooth;

		// Token: 0x0400008D RID: 141
		[SerializeField]
		private Interpretacion.Capacidad m_upperEyelidHeight;

		// Token: 0x0400008E RID: 142
		[SerializeField]
		private Interpretacion.Capacidad m_eyelidTopFlat;

		// Token: 0x0400008F RID: 143
		[SerializeField]
		private Interpretacion.Capacidad m_eyelidTopInHeight;

		// Token: 0x04000090 RID: 144
		[SerializeField]
		private Interpretacion.Capacidad m_lowerEyelidHeight;

		// Token: 0x04000091 RID: 145
		[SerializeField]
		private Interpretacion.Capacidad m_eyelidBottomDefine;

		// Token: 0x04000092 RID: 146
		[SerializeField]
		private Interpretacion.Capacidad m_eyelidBottomOutHeight;

		// Token: 0x04000093 RID: 147
		[SerializeField]
		private Interpretacion.Capacidad m_wrinkleInner;

		// Token: 0x04000094 RID: 148
		[SerializeField]
		private Interpretacion.Length m_eyelashesLength;

		// Token: 0x04000095 RID: 149
		[SerializeField]
		private Interpretacion.Distance m_lacrimalDistance;

		// Token: 0x04000096 RID: 150
		[SerializeField]
		private Interpretacion.Capacidad m_lacrimalExposure;

		// Token: 0x04000097 RID: 151
		[AplicaAConjuntoDeFisico(para = "eyes", weigth = 5)]
		[LabelLocalizado("Color", "US")]
		public FreeColor irisColor;
	}
}
