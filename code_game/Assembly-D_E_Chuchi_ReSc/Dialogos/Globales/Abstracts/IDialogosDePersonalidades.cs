using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts
{
	// Token: 0x020001FC RID: 508
	public interface IDialogosDePersonalidades
	{
		// Token: 0x06000BC8 RID: 3016
		void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null);
	}
}
