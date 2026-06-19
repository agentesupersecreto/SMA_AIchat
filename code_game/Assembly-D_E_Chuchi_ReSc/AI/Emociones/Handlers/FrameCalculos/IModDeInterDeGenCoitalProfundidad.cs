using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FA RID: 1274
	[Obsolete("reemplazado por internals y hard  points")]
	public interface IModDeInterDeGenCoitalProfundidad
	{
		// Token: 0x06001E32 RID: 7730
		[Obsolete("no se usan ya", true)]
		void Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E33 RID: 7731
		[Obsolete("reemplazado por internals y hard  points", true)]
		void Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);

		// Token: 0x06001E34 RID: 7732
		[Obsolete("reemplazado por internals y hard  points", true)]
		void StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo);
	}
}
