using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FB RID: 1275
	public interface IModDeInterDeGenCoitalAnchura
	{
		// Token: 0x06001E35 RID: 7733
		[Obsolete("no se usan ya", true)]
		void Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E36 RID: 7734
		void Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E37 RID: 7735
		void StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);
	}
}
