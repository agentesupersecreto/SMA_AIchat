using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.Genetica;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Clases
{
	// Token: 0x0200007B RID: 123
	public static class DecodificadorDeGenes
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x0001604C File Offset: 0x0001424C
		public static void Codificar(IReadOnlyCollection<ModificadoresDeAlterador> modificadores, IReadOnlyDictionary<object, GeneItem> cadena)
		{
			foreach (KeyValuePair<object, GeneItem> keyValuePair in cadena)
			{
				Tuple<string, int> tuple = keyValuePair.Key as Tuple<string, int>;
				if (tuple != null)
				{
					string alteradorNombre = tuple.Item1;
					int item = tuple.Item2;
					ModificadoresDeAlterador modificadoresDeAlterador = modificadores.FirstOrDefault((ModificadoresDeAlterador m) => m.alteradorName == alteradorNombre);
					if (modificadoresDeAlterador != null && modificadoresDeAlterador.modificadores != null && item < modificadoresDeAlterador.modificadores.Length)
					{
						modificadoresDeAlterador.modificadores[item] = keyValuePair.Value.valor;
					}
				}
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000160FC File Offset: 0x000142FC
		public static void Codificar(IReadOnlyDictionary<string, ModificadoresDeAlterador> modificadores, IReadOnlyDictionary<object, GeneItem> cadena)
		{
			foreach (KeyValuePair<object, GeneItem> keyValuePair in cadena)
			{
				Tuple<string, int> tuple = keyValuePair.Key as Tuple<string, int>;
				if (tuple != null)
				{
					string item = tuple.Item1;
					int item2 = tuple.Item2;
					ModificadoresDeAlterador modificadoresDeAlterador;
					if (modificadores.TryGetValue(item, out modificadoresDeAlterador) && modificadoresDeAlterador.modificadores != null && item2 < modificadoresDeAlterador.modificadores.Length)
					{
						modificadoresDeAlterador.modificadores[item2] = keyValuePair.Value.valor;
					}
				}
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00016194 File Offset: 0x00014394
		public static void Decodificar(IReadOnlyCollection<ModificadoresDeAlterador> modificadores, IDictionary<object, GeneItem> cadenaResultado)
		{
			foreach (ModificadoresDeAlterador modificadoresDeAlterador in modificadores)
			{
				for (int i = 0; i < modificadoresDeAlterador.modificadores.Length; i++)
				{
					float num = modificadoresDeAlterador.modificadores[i];
					GeneItem geneItem = default(GeneItem);
					Tuple<string, int> tuple = new Tuple<string, int>(modificadoresDeAlterador.alteradorName, i);
					geneItem.identificador = tuple;
					geneItem.valor = num;
					geneItem.sensible = modificadoresDeAlterador.sensible;
					geneItem.volatil = modificadoresDeAlterador.volatil;
					cadenaResultado.Add(tuple, geneItem);
				}
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001623C File Offset: 0x0001443C
		public static IReadOnlyDictionary<object, GeneItem> Decodificar(IReadOnlyCollection<ModificadoresDeAlterador> modificadores)
		{
			Dictionary<object, GeneItem> dictionary = new Dictionary<object, GeneItem>();
			DecodificadorDeGenes.Decodificar(modificadores, dictionary);
			return dictionary;
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00016258 File Offset: 0x00014458
		public static IReadOnlyDictionary<string, IReadOnlyDictionary<int, GeneItem>> DecodificarV2(IReadOnlyCollection<ModificadoresDeAlterador> modificadores)
		{
			Dictionary<string, IReadOnlyDictionary<int, GeneItem>> dictionary = new Dictionary<string, IReadOnlyDictionary<int, GeneItem>>(modificadores.Count);
			foreach (ModificadoresDeAlterador modificadoresDeAlterador in modificadores)
			{
				Dictionary<int, GeneItem> dictionary2 = new Dictionary<int, GeneItem>(modificadoresDeAlterador.modificadores.Length);
				for (int i = 0; i < modificadoresDeAlterador.modificadores.Length; i++)
				{
					float num = modificadoresDeAlterador.modificadores[i];
					GeneItem geneItem = default(GeneItem);
					Tuple<string, int> tuple = new Tuple<string, int>(modificadoresDeAlterador.alteradorName, i);
					geneItem.identificador = tuple;
					geneItem.valor = num;
					geneItem.sensible = modificadoresDeAlterador.sensible;
					geneItem.volatil = modificadoresDeAlterador.volatil;
					dictionary2.Add(i, geneItem);
				}
				dictionary.Add(modificadoresDeAlterador.alteradorName, dictionary2);
			}
			return dictionary;
		}
	}
}
