using System;
using System.Collections.Generic;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000036 RID: 54
	public interface IPartesExpuestaDeInteraccion
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000251 RID: 593
		// (set) Token: 0x06000252 RID: 594
		bool usarEspuestasCalculadas { get; set; }

		// Token: 0x06000253 RID: 595
		void ObtenerExponiendoPartes(out IReadOnlyList<ParteDelCuerpoHumano> exponiendo, ParteDelCuerpoHumano? defaultParte = null);

		// Token: 0x06000254 RID: 596
		void ObtenerExponiendoPartes(out IReadOnlyList<ParteDelCuerpoHumano> exponiendo, out IReadOnlyCollection<int> exponiendoSet, ParteDelCuerpoHumano? defaultParte = null);

		// Token: 0x06000255 RID: 597
		void ReemplazarPartesExponiendo(IReadOnlyList<ParteDelCuerpoHumano> exponiendoNuevas);
	}
}
