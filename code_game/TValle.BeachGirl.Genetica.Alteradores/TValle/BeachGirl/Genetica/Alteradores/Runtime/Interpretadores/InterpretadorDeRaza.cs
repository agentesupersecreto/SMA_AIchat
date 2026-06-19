using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200002A RID: 42
	public static class InterpretadorDeRaza
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00006850 File Offset: 0x00004A50
		public static InterpretacionDeRaza Interpretar(IRazaInterpretadorHelper helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			return new InterpretacionDeRaza
			{
				african = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(MathfExtension.InverseLerpConMedio(0.7f, 0.85f, 1f, helper.african)),
				nordic = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(MathfExtension.InverseLerpConMedio(0.7f, 0.85f, 1f, helper.cau)),
				asian = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(MathfExtension.InverseLerpConMedio(0.7f, 0.85f, 1f, helper.asian)),
				hispanic = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(MathfExtension.InverseLerpConMedio(0.7f, 0.85f, 1f, helper.latina)),
				elf = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(MathfExtension.InverseLerpConMedio(0.7f, 0.85f, 1f, helper.anime))
			};
		}
	}
}
