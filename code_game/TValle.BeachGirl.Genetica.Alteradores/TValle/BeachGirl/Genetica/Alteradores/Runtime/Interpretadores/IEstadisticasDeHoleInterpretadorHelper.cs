using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000009 RID: 9
	public interface IEstadisticasDeHoleInterpretadorHelper
	{
		// Token: 0x06000061 RID: 97
		void VaginalProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x06000062 RID: 98
		void AnalProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x06000063 RID: 99
		void OralProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x06000064 RID: 100
		void VaginalAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x06000065 RID: 101
		void AnalAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x06000066 RID: 102
		void OralAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale);

		// Token: 0x02000082 RID: 130
		// (Invoke) Token: 0x060005F7 RID: 1527
		public delegate float OffsetGetterHandler(float input, RangeValueV2 rangoLocal);
	}
}
