using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000015 RID: 21
	public interface IRangesParaInterpretadores
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000B4 RID: 180
		float painSensibilidad_MinWorldRango_Tactil { get; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000B5 RID: 181
		float pleasureSensibilidad_MinWorldRango_Tactil { get; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000B6 RID: 182
		float pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil { get; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000B7 RID: 183
		float painGain_MaxGeneracion { get; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000B8 RID: 184
		float pleasureGain_MaxGeneracion { get; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000B9 RID: 185
		float rageGain_MaxGeneracion { get; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000BA RID: 186
		float pleasure_MaxValue { get; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000BB RID: 187
		float visualFavoravility { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000BC RID: 188
		float tactilFavoravility { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000BD RID: 189
		float exposureFavoravility { get; }
	}
}
