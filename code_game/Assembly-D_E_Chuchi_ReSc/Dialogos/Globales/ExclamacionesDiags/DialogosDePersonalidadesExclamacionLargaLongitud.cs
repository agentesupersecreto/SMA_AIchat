using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.ExclamacionesDiags
{
	// Token: 0x020001F9 RID: 505
	public class DialogosDePersonalidadesExclamacionLargaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesExclamacionLargaLongitud>
	{
		// Token: 0x06000BC3 RID: 3011 RVA: 0x00034AF6 File Offset: 0x00032CF6
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
