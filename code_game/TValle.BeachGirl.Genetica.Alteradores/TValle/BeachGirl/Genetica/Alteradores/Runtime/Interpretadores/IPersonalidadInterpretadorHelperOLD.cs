using System;
using System.Collections.Generic;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004C RID: 76
	[Obsolete("devidir en varios", true)]
	public interface IPersonalidadInterpretadorHelperOLD
	{
		// Token: 0x06000383 RID: 899
		void VaginalProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000384 RID: 900
		void AnalProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000385 RID: 901
		void OralProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000386 RID: 902
		void VaginalAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000387 RID: 903
		void AnalAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000388 RID: 904
		void OralAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult);

		// Token: 0x06000389 RID: 905
		float VaginalConsentOffset(float aceptanceMod);

		// Token: 0x0600038A RID: 906
		float AnalConsentOffset(float aceptanceMod);

		// Token: 0x0600038B RID: 907
		float OralConsentOffset(float aceptanceMod);

		// Token: 0x0600038C RID: 908
		float BeingWatchedConsentOffset(float aceptanceMod);

		// Token: 0x0600038D RID: 909
		float BeingWatchedInPrivatesConsentOffset(float aceptanceMod);

		// Token: 0x0600038E RID: 910
		float BeingTouchedConsentOffset(float aceptanceMod);

		// Token: 0x0600038F RID: 911
		float BeingTouchedInPrivatesConsentOffset(float aceptanceMod);

		// Token: 0x06000390 RID: 912
		float UndressConsentOffset(float aceptanceMod);

		// Token: 0x06000391 RID: 913
		float UndressPrivatesConsentOffset(float aceptanceMod);
	}
}
