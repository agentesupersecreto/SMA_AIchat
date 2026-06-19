using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F2 RID: 498
	public class DiagsPasadoDeMaxEmocionValueCortaLongitud : DialogosDePersonalidadesBase<DiagsPasadoDeMaxEmocionValueCortaLongitud>
	{
		// Token: 0x06000BB5 RID: 2997 RVA: 0x00034A47 File Offset: 0x00032C47
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
