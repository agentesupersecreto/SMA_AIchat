using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001ED RID: 493
	public sealed class DialogosDePersonalidadesCortaLongitudConHielo : DialogosDePersonalidadesBase<DialogosDePersonalidadesCortaLongitudConHielo>
	{
		// Token: 0x06000BAB RID: 2987 RVA: 0x000349CA File Offset: 0x00032BCA
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
