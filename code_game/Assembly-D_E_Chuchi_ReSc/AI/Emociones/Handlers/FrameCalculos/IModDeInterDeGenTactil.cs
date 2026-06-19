using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FD RID: 1277
	public interface IModDeInterDeGenTactil
	{
		// Token: 0x06001E3B RID: 7739
		[Obsolete("no se usan ya", true)]
		void Modificar(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ref RangeValueV2 intervalo);

		// Token: 0x06001E3C RID: 7740
		void Max(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ParteQuePuedeEstimular estimulante, ref RangeValueV2 intervalo);

		// Token: 0x06001E3D RID: 7741
		void StackIfGreater(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ParteQuePuedeEstimular estimulante, ref RangeValueV2 intervalo);
	}
}
