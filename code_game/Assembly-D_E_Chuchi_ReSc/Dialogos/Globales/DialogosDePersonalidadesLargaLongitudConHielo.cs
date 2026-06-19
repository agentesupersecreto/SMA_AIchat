using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001EF RID: 495
	public sealed class DialogosDePersonalidadesLargaLongitudConHielo : DialogosDePersonalidadesBase<DialogosDePersonalidadesLargaLongitudConHielo>
	{
		// Token: 0x06000BAF RID: 2991 RVA: 0x000349FC File Offset: 0x00032BFC
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
