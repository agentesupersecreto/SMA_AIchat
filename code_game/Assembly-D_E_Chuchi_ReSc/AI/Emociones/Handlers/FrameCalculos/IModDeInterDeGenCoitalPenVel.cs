using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FC RID: 1276
	public interface IModDeInterDeGenCoitalPenVel
	{
		// Token: 0x06001E38 RID: 7736
		[Obsolete("no se usan ya", true)]
		void Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E39 RID: 7737
		void Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E3A RID: 7738
		void StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);
	}
}
