using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200011E RID: 286
	public static class TipoDePrendaHelper
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x0001F103 File Offset: 0x0001D303
		public static bool EsEsencialFemenina(this MapaDeRopa.TipoDePrenda tipo)
		{
			return tipo - MapaDeRopa.TipoDePrenda.inferior <= 2 || tipo == MapaDeRopa.TipoDePrenda.swimsuit;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001F112 File Offset: 0x0001D312
		public static bool EsEsencialMasculino(this MapaDeRopa.TipoDePrenda tipo)
		{
			return tipo - MapaDeRopa.TipoDePrenda.inferior <= 2;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001F11D File Offset: 0x0001D31D
		public static bool EsEsencial(this MapaDeRopa.TipoDePrenda tipo, Sexo paraSexo)
		{
			if (paraSexo != Sexo.masculino)
			{
				return paraSexo == Sexo.femenino && tipo.EsEsencialFemenina();
			}
			return tipo.EsEsencialMasculino();
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001F138 File Offset: 0x0001D338
		public static bool CheckTipoDePrendaCollectionEsEsencialValida(this MapaDeRopa.TipoDePrenda tipo, Sexo paraSexo, IReadOnlyList<MapaDeRopa.RopaData> ropaDataDeTipo)
		{
			if (paraSexo != Sexo.masculino)
			{
				if (paraSexo == Sexo.femenino)
				{
					if (tipo.EsEsencialFemenina())
					{
						if (ropaDataDeTipo.FirstOrDefault((MapaDeRopa.RopaData data) => data.probabilidadConfig.chance >= 100f) == null)
						{
							Debug.LogError("Tipo de prenda Esencial Femenina: " + tipo.ToString() + " no contiene ningun chance al 100");
							return false;
						}
					}
				}
			}
			else if (tipo.EsEsencialMasculino())
			{
				if (ropaDataDeTipo.FirstOrDefault((MapaDeRopa.RopaData data) => data.probabilidadConfig.chance >= 100f) == null)
				{
					Debug.LogError("Tipo de prenda Esencial Masculina: " + tipo.ToString() + " no contiene ningun chance al 100");
					return false;
				}
			}
			return true;
		}
	}
}
