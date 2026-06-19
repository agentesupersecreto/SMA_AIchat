using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime.Clases.Conjuntos.Version1;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x02000061 RID: 97
	public class ConjuntosDeAparienciaFisica : DiccionarioDeStrings<ConjuntosDeAparienciaFisica>
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00010708 File Offset: 0x0000E908
		public static IReadOnlyDictionary<string, IReadOnlyCollection<object>> conjuntos
		{
			get
			{
				if (ConjuntosDeAparienciaFisica.m_conjuntos == null || ConjuntosDeAparienciaFisica.m_conjuntos.Count == 0)
				{
					ConjuntosDeAparienciaFisica.m_conjuntos = new Dictionary<string, IReadOnlyCollection<object>>
					{
						{
							"height",
							ConjuntosDeAparienciaFisica.height
						},
						{
							"body",
							ConjuntosDeAparienciaFisica.body
						},
						{
							"skin",
							ConjuntosDeAparienciaFisica.skin
						},
						{
							"hair",
							ConjuntosDeAparienciaFisica.hair
						},
						{
							"head",
							ConjuntosDeAparienciaFisica.head
						},
						{
							"face",
							ConjuntosDeAparienciaFisica.face
						},
						{
							"eyes",
							ConjuntosDeAparienciaFisica.eyes
						},
						{
							"nose",
							ConjuntosDeAparienciaFisica.nose
						},
						{
							"mouth",
							ConjuntosDeAparienciaFisica.mouth
						},
						{
							"breast",
							ConjuntosDeAparienciaFisica.breast
						},
						{
							"arms",
							ConjuntosDeAparienciaFisica.arms
						},
						{
							"waist_hip",
							ConjuntosDeAparienciaFisica.waist_hip
						},
						{
							"crotch",
							ConjuntosDeAparienciaFisica.crotch
						},
						{
							"buttocks",
							ConjuntosDeAparienciaFisica.buttocks
						},
						{
							"legs",
							ConjuntosDeAparienciaFisica.legs
						}
					};
				}
				return ConjuntosDeAparienciaFisica.m_conjuntos;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0001082C File Offset: 0x0000EA2C
		public static IConjuntoDeGenes[] conjuntosCopia
		{
			get
			{
				return new IConjuntoDeGenes[]
				{
					new ConjuntoEspecificoGenerico("height"),
					new ConjuntoEspecificoGenerico("body"),
					new ConjuntoEspecificoGenerico("skin"),
					new ConjuntoEspecificoGenerico("hair"),
					new ConjuntoEspecificoGenerico("head"),
					new ConjuntoEspecificoGenerico("face"),
					new ConjuntoEspecificoGenerico("eyes"),
					new ConjuntoEspecificoGenerico("nose"),
					new ConjuntoEspecificoGenerico("mouth"),
					new ConjuntoEspecificoGenerico("breast"),
					new ConjuntoEspecificoGenerico("arms"),
					new ConjuntoEspecificoGenerico("waist_hip"),
					new ConjuntoEspecificoGenerico("crotch"),
					new ConjuntoEspecificoGenerico("buttocks"),
					new ConjuntoEspecificoGenerico("legs")
				};
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00010909 File Offset: 0x0000EB09
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> heightNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoHeight1>.nombresSet;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00010910 File Offset: 0x0000EB10
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> bodyNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoBody1>.nombresSet;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00010917 File Offset: 0x0000EB17
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> skinNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoSkin1>.nombresSet;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x0001091E File Offset: 0x0000EB1E
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> hairNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoHair1>.nombresSet;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00010925 File Offset: 0x0000EB25
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> headNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoHead1>.nombresSet;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0001092C File Offset: 0x0000EB2C
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> faceNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoFace1>.nombresSet;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00010933 File Offset: 0x0000EB33
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> eyesNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoEyes1>.nombresSet;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x0001093A File Offset: 0x0000EB3A
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> noseNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoNose1>.nombresSet;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00010941 File Offset: 0x0000EB41
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> mouthNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoMouth1>.nombresSet;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00010948 File Offset: 0x0000EB48
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> breastNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoBreast1>.nombresSet;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001094F File Offset: 0x0000EB4F
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> armsNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoArms1>.nombresSet;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00010956 File Offset: 0x0000EB56
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> waist_hipNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoWaist_Hip1>.nombresSet;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0001095D File Offset: 0x0000EB5D
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> crotchNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoEntrepierna1>.nombresSet;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00010964 File Offset: 0x0000EB64
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> buttocksNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoNalgas1>.nombresSet;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001096B File Offset: 0x0000EB6B
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> legsNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoLegs1>.nombresSet;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00010972 File Offset: 0x0000EB72
		[AddToDiccionarioDeStrings]
		public static IReadOnlyCollection<string> otherNombres
		{
			get
			{
				return DiccionarioDeStrings<DiccionarioDeConjuntoOther1>.nombresSet;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00010979 File Offset: 0x0000EB79
		public static IReadOnlyCollection<object> height
		{
			get
			{
				return ConjuntosDeAparienciaFisica.heightNombres;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00010980 File Offset: 0x0000EB80
		public static IReadOnlyCollection<object> body
		{
			get
			{
				return ConjuntosDeAparienciaFisica.bodyNombres;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x00010987 File Offset: 0x0000EB87
		public static IReadOnlyCollection<object> skin
		{
			get
			{
				return ConjuntosDeAparienciaFisica.skinNombres;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0001098E File Offset: 0x0000EB8E
		public static IReadOnlyCollection<object> hair
		{
			get
			{
				return ConjuntosDeAparienciaFisica.hairNombres;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x00010995 File Offset: 0x0000EB95
		public static IReadOnlyCollection<object> head
		{
			get
			{
				return ConjuntosDeAparienciaFisica.headNombres;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0001099C File Offset: 0x0000EB9C
		public static IReadOnlyCollection<object> face
		{
			get
			{
				return ConjuntosDeAparienciaFisica.faceNombres;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x000109A3 File Offset: 0x0000EBA3
		public static IReadOnlyCollection<object> eyes
		{
			get
			{
				return ConjuntosDeAparienciaFisica.eyesNombres;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x000109AA File Offset: 0x0000EBAA
		public static IReadOnlyCollection<object> nose
		{
			get
			{
				return ConjuntosDeAparienciaFisica.noseNombres;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x000109B1 File Offset: 0x0000EBB1
		public static IReadOnlyCollection<object> mouth
		{
			get
			{
				return ConjuntosDeAparienciaFisica.mouthNombres;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x000109B8 File Offset: 0x0000EBB8
		public static IReadOnlyCollection<object> breast
		{
			get
			{
				return ConjuntosDeAparienciaFisica.breastNombres;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x000109BF File Offset: 0x0000EBBF
		public static IReadOnlyCollection<object> arms
		{
			get
			{
				return ConjuntosDeAparienciaFisica.armsNombres;
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x000109C6 File Offset: 0x0000EBC6
		public static IReadOnlyCollection<object> waist_hip
		{
			get
			{
				return ConjuntosDeAparienciaFisica.waist_hipNombres;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x000109CD File Offset: 0x0000EBCD
		public static IReadOnlyCollection<object> crotch
		{
			get
			{
				return ConjuntosDeAparienciaFisica.crotchNombres;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x000109D4 File Offset: 0x0000EBD4
		public static IReadOnlyCollection<object> buttocks
		{
			get
			{
				return ConjuntosDeAparienciaFisica.buttocksNombres;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x000109DB File Offset: 0x0000EBDB
		public static IReadOnlyCollection<object> legs
		{
			get
			{
				return ConjuntosDeAparienciaFisica.legsNombres;
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000109E4 File Offset: 0x0000EBE4
		public static IReadOnlyCollection<object> ObtenerConjuntoIdentificadores(string conjuntoName)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(conjuntoName);
			if (num <= 1139653707U)
			{
				if (num <= 424490508U)
				{
					if (num != 88876908U)
					{
						if (num != 292255708U)
						{
							if (num == 424490508U)
							{
								if (conjuntoName == "legs")
								{
									return ConjuntosDeAparienciaFisica.legs;
								}
							}
						}
						else if (conjuntoName == "face")
						{
							return ConjuntosDeAparienciaFisica.face;
						}
					}
					else if (conjuntoName == "breast")
					{
						return ConjuntosDeAparienciaFisica.breast;
					}
				}
				else if (num <= 845761475U)
				{
					if (num != 470722328U)
					{
						if (num == 845761475U)
						{
							if (conjuntoName == "head")
							{
								return ConjuntosDeAparienciaFisica.head;
							}
						}
					}
					else if (conjuntoName == "buttocks")
					{
						return ConjuntosDeAparienciaFisica.buttocks;
					}
				}
				else if (num != 862676408U)
				{
					if (num == 1139653707U)
					{
						if (conjuntoName == "eyes")
						{
							return ConjuntosDeAparienciaFisica.eyes;
						}
					}
				}
				else if (conjuntoName == "skin")
				{
					return ConjuntosDeAparienciaFisica.skin;
				}
			}
			else if (num <= 2633735346U)
			{
				if (num <= 1948615132U)
				{
					if (num != 1541974773U)
					{
						if (num == 1948615132U)
						{
							if (conjuntoName == "mouth")
							{
								return ConjuntosDeAparienciaFisica.mouth;
							}
						}
					}
					else if (conjuntoName == "waist_hip")
					{
						return ConjuntosDeAparienciaFisica.waist_hip;
					}
				}
				else if (num != 2441953354U)
				{
					if (num == 2633735346U)
					{
						if (conjuntoName == "arms")
						{
							return ConjuntosDeAparienciaFisica.arms;
						}
					}
				}
				else if (conjuntoName == "nose")
				{
					return ConjuntosDeAparienciaFisica.nose;
				}
			}
			else if (num <= 3585981250U)
			{
				if (num != 3568727737U)
				{
					if (num == 3585981250U)
					{
						if (conjuntoName == "height")
						{
							return ConjuntosDeAparienciaFisica.height;
						}
					}
				}
				else if (conjuntoName == "hair")
				{
					return ConjuntosDeAparienciaFisica.hair;
				}
			}
			else if (num != 3632816688U)
			{
				if (num == 3685382517U)
				{
					if (conjuntoName == "body")
					{
						return ConjuntosDeAparienciaFisica.body;
					}
				}
			}
			else if (conjuntoName == "crotch")
			{
				return ConjuntosDeAparienciaFisica.crotch;
			}
			throw new ArgumentOutOfRangeException(conjuntoName.ToString());
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00010C74 File Offset: 0x0000EE74
		public static bool ContieneIdentificador(string conjuntoName, object identificador)
		{
			IReadOnlyCollection<object> readOnlyCollection = ConjuntosDeAparienciaFisica.ObtenerConjuntoIdentificadores(conjuntoName);
			return ((readOnlyCollection != null) ? new bool?(readOnlyCollection.Contains(identificador)) : null).GetValueOrDefault();
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x00010CA9 File Offset: 0x0000EEA9
		public static bool integridadChecked
		{
			get
			{
				return ConjuntosDeAparienciaFisica.m_integridadChecked;
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00010CB0 File Offset: 0x0000EEB0
		public static void CheckIntegridad()
		{
			ConjuntosDeAparienciaFisica.m_integridadChecked = true;
			HashSet<string> nombresSet = DiccionarioDeStrings<DiccionarioDeNombresDeAlteradoresFemeninos>.nombresSet;
			string[] nombres = DiccionarioDeStrings<DiccionarioDeNombresDeAlteradoresFemeninos>.nombres;
			string[] nombres2 = DiccionarioDeStrings<ConjuntosDeAparienciaFisica>.nombres;
			HashSet<string> nombresSet2 = DiccionarioDeStrings<ConjuntosDeAparienciaFisica>.nombresSet;
			bool flag = false;
			if (nombres.Length != nombres2.Length)
			{
				Debug.LogError("Alteradores: cantidad no es igual, alteradores son: " + nombres.Length.ToString() + ", pero alteradores en conjuntos son: " + nombres2.Length.ToString());
				flag = true;
			}
			for (int i = 0; i < nombres2.Length; i++)
			{
				if (!nombresSet.Contains(nombres2[i]))
				{
					Debug.LogError("Alterador Missing: " + nombres2[i]);
					flag = true;
				}
			}
			for (int j = 0; j < nombres.Length; j++)
			{
				if (!nombresSet2.Contains(nombres[j]))
				{
					Debug.LogError("Alterador Missing Conjunto: " + nombres[j]);
					flag = true;
				}
			}
			if (!flag)
			{
				Debug.Log("Los alteradores y los conjuntos de modificadores, estan en buen estado");
			}
		}

		// Token: 0x040001FE RID: 510
		[IgnoreDiccionarioDeStrings]
		public const string heightName = "height";

		// Token: 0x040001FF RID: 511
		[IgnoreDiccionarioDeStrings]
		public const string bodyName = "body";

		// Token: 0x04000200 RID: 512
		[IgnoreDiccionarioDeStrings]
		public const string skinName = "skin";

		// Token: 0x04000201 RID: 513
		[IgnoreDiccionarioDeStrings]
		public const string hairName = "hair";

		// Token: 0x04000202 RID: 514
		[IgnoreDiccionarioDeStrings]
		public const string headName = "head";

		// Token: 0x04000203 RID: 515
		[IgnoreDiccionarioDeStrings]
		public const string faceName = "face";

		// Token: 0x04000204 RID: 516
		[IgnoreDiccionarioDeStrings]
		public const string eyesName = "eyes";

		// Token: 0x04000205 RID: 517
		[IgnoreDiccionarioDeStrings]
		public const string noseName = "nose";

		// Token: 0x04000206 RID: 518
		[IgnoreDiccionarioDeStrings]
		public const string mouthName = "mouth";

		// Token: 0x04000207 RID: 519
		[IgnoreDiccionarioDeStrings]
		public const string breastName = "breast";

		// Token: 0x04000208 RID: 520
		[IgnoreDiccionarioDeStrings]
		public const string armsName = "arms";

		// Token: 0x04000209 RID: 521
		[IgnoreDiccionarioDeStrings]
		public const string waist_hipName = "waist_hip";

		// Token: 0x0400020A RID: 522
		[IgnoreDiccionarioDeStrings]
		public const string crotchName = "crotch";

		// Token: 0x0400020B RID: 523
		[IgnoreDiccionarioDeStrings]
		public const string buttocksName = "buttocks";

		// Token: 0x0400020C RID: 524
		[IgnoreDiccionarioDeStrings]
		public const string legsName = "legs";

		// Token: 0x0400020D RID: 525
		[IgnoreDiccionarioDeStrings]
		public const string othersName = "others";

		// Token: 0x0400020E RID: 526
		[NonSerialized]
		private static IReadOnlyDictionary<string, IReadOnlyCollection<object>> m_conjuntos;

		// Token: 0x0400020F RID: 527
		private static bool m_integridadChecked;

		// Token: 0x0200009C RID: 156
		public static class OldVersion0
		{
			// Token: 0x06000608 RID: 1544 RVA: 0x000163F8 File Offset: 0x000145F8
			public static IReadOnlyList<string> ParceName0To1(string oldName)
			{
				uint num = <PrivateImplementationDetails>.ComputeStringHash(oldName);
				if (num <= 1941136613U)
				{
					if (num <= 491859867U)
					{
						if (num != 80308746U)
						{
							if (num == 491859867U)
							{
								if (oldName == "piel")
								{
									return new string[] { "skin" };
								}
							}
						}
						else if (oldName == "rostro")
						{
							return new string[] { "face" };
						}
					}
					else if (num != 1413731598U)
					{
						if (num != 1705433941U)
						{
							if (num == 1941136613U)
							{
								if (oldName == "nariz")
								{
									return new string[] { "nose" };
								}
							}
						}
						else if (oldName == "figura")
						{
							return new string[] { "height", "body", "head", "arms", "waist_hip", "legs" };
						}
					}
					else if (oldName == "ojos")
					{
						return new string[] { "eyes" };
					}
				}
				else if (num <= 2751556369U)
				{
					if (num != 2207120514U)
					{
						if (num == 2751556369U)
						{
							if (oldName == "nalgas")
							{
								return new string[] { "buttocks" };
							}
						}
					}
					else if (oldName == "entrepierna")
					{
						return new string[] { "crotch" };
					}
				}
				else if (num != 3283160946U)
				{
					if (num != 3825527819U)
					{
						if (num == 3893617313U)
						{
							if (oldName == "cabello")
							{
								return new string[] { "hair" };
							}
						}
					}
					else if (oldName == "senos")
					{
						return new string[] { "breast" };
					}
				}
				else if (oldName == "boca")
				{
					return new string[] { "mouth" };
				}
				return new string[] { oldName };
			}

			// Token: 0x04000308 RID: 776
			[IgnoreDiccionarioDeStrings]
			public const string figuraName = "figura";

			// Token: 0x04000309 RID: 777
			[IgnoreDiccionarioDeStrings]
			public const string pielName = "piel";

			// Token: 0x0400030A RID: 778
			[IgnoreDiccionarioDeStrings]
			public const string rostroName = "rostro";

			// Token: 0x0400030B RID: 779
			[IgnoreDiccionarioDeStrings]
			public const string cabelloName = "cabello";

			// Token: 0x0400030C RID: 780
			[IgnoreDiccionarioDeStrings]
			public const string ojosName = "ojos";

			// Token: 0x0400030D RID: 781
			[IgnoreDiccionarioDeStrings]
			public const string narizName = "nariz";

			// Token: 0x0400030E RID: 782
			[IgnoreDiccionarioDeStrings]
			public const string bocaName = "boca";

			// Token: 0x0400030F RID: 783
			[IgnoreDiccionarioDeStrings]
			public const string senosName = "senos";

			// Token: 0x04000310 RID: 784
			[IgnoreDiccionarioDeStrings]
			public const string nalgasName = "nalgas";

			// Token: 0x04000311 RID: 785
			[IgnoreDiccionarioDeStrings]
			public const string entrepiernaName = "entrepierna";
		}
	}
}
