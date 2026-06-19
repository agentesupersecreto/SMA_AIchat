using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F7 RID: 503
	public class DiagsPresenteDeMaxEmocionValueMedianaLongitud : DialogosDePersonalidadesBase<DiagsPresenteDeMaxEmocionValueMedianaLongitud>
	{
		// Token: 0x06000BBF RID: 3007 RVA: 0x00034AC4 File Offset: 0x00032CC4
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
