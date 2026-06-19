using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.Globales
{
	// Token: 0x02000146 RID: 326
	public class GeneradorDeConjuntosDeRopaAleatoriosMasculinos : Singleton<GeneradorDeConjuntosDeRopaAleatoriosMasculinos>
	{
		// Token: 0x06000764 RID: 1892 RVA: 0x000227A8 File Offset: 0x000209A8
		public void GenerarRandom(List<Pieza> resultado, bool incluirShoes, ItemQuality lookingFor, float lookingForPrecisionPercentage)
		{
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.GenerarRandom(Sexo.masculino, this.m_TiposDePrendaDeConjunto, resultado, incluirShoes, lookingFor, lookingForPrecisionPercentage);
		}

		// Token: 0x040005D6 RID: 1494
		[NonSerialized]
		private DiccionaryEnum<GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto, List<MapaDeRopa.TipoDePrenda>> m_TiposDePrendaDeConjunto = new DiccionaryEnum<GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto, List<MapaDeRopa.TipoDePrenda>>((GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto x) => (int)x) { 
		{
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto.normal,
			new List<MapaDeRopa.TipoDePrenda>
			{
				MapaDeRopa.TipoDePrenda.inferior,
				MapaDeRopa.TipoDePrenda.shoes,
				MapaDeRopa.TipoDePrenda.superior,
				MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories,
				MapaDeRopa.TipoDePrenda.underwearInferiorAccessories,
				MapaDeRopa.TipoDePrenda.glases,
				MapaDeRopa.TipoDePrenda.accessories,
				MapaDeRopa.TipoDePrenda.gloves,
				MapaDeRopa.TipoDePrenda.hat,
				MapaDeRopa.TipoDePrenda.socks
			}
		} };
	}
}
