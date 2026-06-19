using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime.Clases.Conjuntos.Version1;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x02000062 RID: 98
	public class ConjuntosDePersonalidad : DiccionarioDeStrings<ConjuntosDePersonalidad>
	{
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x00010D94 File Offset: 0x0000EF94
		public static IReadOnlyDictionary<string, IReadOnlyCollection<object>> conjuntos
		{
			get
			{
				if (ConjuntosDePersonalidad.m_conjuntos == null || ConjuntosDePersonalidad.m_conjuntos.Count == 0)
				{
					ConjuntosDePersonalidad.m_conjuntos = new Dictionary<string, IReadOnlyCollection<object>>
					{
						{
							"angerManagement",
							ConjuntosDePersonalidad.angerManagement
						},
						{
							"painTolerance",
							ConjuntosDePersonalidad.painTolerance
						},
						{
							"slutness",
							ConjuntosDePersonalidad.slutness
						},
						{
							"exhibitionism",
							ConjuntosDePersonalidad.exhibitionism
						},
						{
							"servicing",
							ConjuntosDePersonalidad.servicing
						},
						{
							"summarizing",
							ConjuntosDePersonalidad.summarizing
						}
					};
				}
				return ConjuntosDePersonalidad.m_conjuntos;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x00010E24 File Offset: 0x0000F024
		public static IConjuntoDeGenes[] conjuntosCopia
		{
			get
			{
				return new IConjuntoDeGenes[]
				{
					new ConjuntoEspecificoGenerico("angerManagement"),
					new ConjuntoEspecificoGenerico("painTolerance"),
					new ConjuntoEspecificoGenerico("slutness"),
					new ConjuntoEspecificoGenerico("exhibitionism"),
					new ConjuntoEspecificoGenerico("servicing"),
					new ConjuntoEspecificoGenerico("summarizing")
				};
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x00010E85 File Offset: 0x0000F085
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> angerManagementNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosAngerManagement1>.nombresSet;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x00010E8C File Offset: 0x0000F08C
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> painToleranceNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosPainTolerance1>.nombresSet;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x00010E93 File Offset: 0x0000F093
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> slutnessNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosSlutness1>.nombresSet;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00010E9A File Offset: 0x0000F09A
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> exhibitionismNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosExhibitionism1>.nombresSet;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00010EA1 File Offset: 0x0000F0A1
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> servicingNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosServicing1>.nombresSet;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00010EA8 File Offset: 0x0000F0A8
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> summarizingNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntosSummarizing1>.nombresSet;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00010EAF File Offset: 0x0000F0AF
		public static IReadOnlyCollection<object> angerManagement
		{
			get
			{
				return ConjuntosDePersonalidad.angerManagementNombres;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00010EB6 File Offset: 0x0000F0B6
		public static IReadOnlyCollection<object> painTolerance
		{
			get
			{
				return ConjuntosDePersonalidad.painToleranceNombres;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00010EBD File Offset: 0x0000F0BD
		public static IReadOnlyCollection<object> slutness
		{
			get
			{
				return ConjuntosDePersonalidad.slutnessNombres;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00010EC4 File Offset: 0x0000F0C4
		public static IReadOnlyCollection<object> exhibitionism
		{
			get
			{
				return ConjuntosDePersonalidad.exhibitionismNombres;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00010ECB File Offset: 0x0000F0CB
		public static IReadOnlyCollection<object> servicing
		{
			get
			{
				return ConjuntosDePersonalidad.servicingNombres;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00010ED2 File Offset: 0x0000F0D2
		public static IReadOnlyCollection<object> summarizing
		{
			get
			{
				return ConjuntosDePersonalidad.summarizingNombres;
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00010EDC File Offset: 0x0000F0DC
		public static IReadOnlyCollection<object> ObtenerConjuntoIdentificadores(string conjuntoName)
		{
			if (conjuntoName == "angerManagement")
			{
				return ConjuntosDePersonalidad.angerManagement;
			}
			if (conjuntoName == "painTolerance")
			{
				return ConjuntosDePersonalidad.painTolerance;
			}
			if (conjuntoName == "slutness")
			{
				return ConjuntosDePersonalidad.slutness;
			}
			if (conjuntoName == "exhibitionism")
			{
				return ConjuntosDePersonalidad.exhibitionism;
			}
			if (conjuntoName == "servicing")
			{
				return ConjuntosDePersonalidad.servicing;
			}
			if (!(conjuntoName == "summarizing"))
			{
				throw new ArgumentOutOfRangeException(conjuntoName.ToString());
			}
			return ConjuntosDePersonalidad.summarizing;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00010F68 File Offset: 0x0000F168
		public static bool ContieneIdentificador(string conjuntoName, object identificador)
		{
			IReadOnlyCollection<object> readOnlyCollection = ConjuntosDePersonalidad.ObtenerConjuntoIdentificadores(conjuntoName);
			return ((readOnlyCollection != null) ? new bool?(readOnlyCollection.Contains(identificador)) : null).GetValueOrDefault();
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00010F9D File Offset: 0x0000F19D
		public static bool integridadChecked
		{
			get
			{
				return ConjuntosDePersonalidad.m_integridadChecked;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00010FA4 File Offset: 0x0000F1A4
		public static void CheckIntegridad()
		{
			ConjuntosDePersonalidad.m_integridadChecked = true;
			IReadOnlyCollection<string> setDeNombres = MapaSingleton<MapaDeNombresDeAlteradoresPersonalidad>.instance.all.setDeNombres;
			IReadOnlyList<string> listaDeNombres = MapaSingleton<MapaDeNombresDeAlteradoresPersonalidad>.instance.all.listaDeNombres;
			string[] nombres = DiccionarioDeStrings<ConjuntosDePersonalidad>.nombres;
			HashSet<string> nombresSet = DiccionarioDeStrings<ConjuntosDePersonalidad>.nombresSet;
			bool flag = false;
			if (listaDeNombres.Count != nombres.Length)
			{
				Debug.LogError("Alteradores: cantidad no es igual, alteradores son: " + listaDeNombres.Count.ToString() + ", pero alteradores en conjuntos son: " + nombres.Length.ToString());
				flag = true;
			}
			for (int i = 0; i < nombres.Length; i++)
			{
				if (!setDeNombres.Contains(nombres[i]))
				{
					Debug.LogError("Alterador Missing: " + nombres[i]);
					flag = true;
				}
			}
			for (int j = 0; j < listaDeNombres.Count; j++)
			{
				if (!nombresSet.Contains(listaDeNombres[j]))
				{
					Debug.LogError("Alterador Missing Conjunto: " + listaDeNombres[j]);
					flag = true;
				}
			}
			if (!flag)
			{
				Debug.Log("Los alteradores y los conjuntos de modificadores, estan en buen estado");
			}
		}

		// Token: 0x04000210 RID: 528
		[IgnoreDiccionarioDeStrings]
		public const string angerManagementName = "angerManagement";

		// Token: 0x04000211 RID: 529
		[IgnoreDiccionarioDeStrings]
		public const string painToleranceName = "painTolerance";

		// Token: 0x04000212 RID: 530
		[IgnoreDiccionarioDeStrings]
		public const string slutnessName = "slutness";

		// Token: 0x04000213 RID: 531
		[IgnoreDiccionarioDeStrings]
		public const string exhibitionismName = "exhibitionism";

		// Token: 0x04000214 RID: 532
		[IgnoreDiccionarioDeStrings]
		public const string servicingName = "servicing";

		// Token: 0x04000215 RID: 533
		[IgnoreDiccionarioDeStrings]
		public const string summarizingName = "summarizing";

		// Token: 0x04000216 RID: 534
		[NonSerialized]
		private static IReadOnlyDictionary<string, IReadOnlyCollection<object>> m_conjuntos;

		// Token: 0x04000217 RID: 535
		private static bool m_integridadChecked;

		// Token: 0x0200009D RID: 157
		public static class OldVersion0
		{
			// Token: 0x06000609 RID: 1545 RVA: 0x0001663C File Offset: 0x0001483C
			public static IReadOnlyList<string> ParceName0To1(string oldName)
			{
				if (oldName == "general")
				{
					return new string[] { "angerManagement", "painTolerance", "slutness", "exhibitionism", "servicing", "summarizing" };
				}
				return new string[] { oldName };
			}

			// Token: 0x04000312 RID: 786
			[IgnoreDiccionarioDeStrings]
			public const string generalName = "general";
		}
	}
}
