using System;
using System.IO;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000F2 RID: 242
	public static class GameFolders
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x00018522 File Offset: 0x00016722
		public static GameFolders.Tipo latestSave
		{
			get
			{
				return GameFolders.Tipo.saveV2;
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00018528 File Offset: 0x00016728
		public static string Obtener(GameFolders.Tipo tipo)
		{
			if (tipo <= GameFolders.Tipo.moddingRopa)
			{
				switch (tipo)
				{
				case GameFolders.Tipo.general:
					return GameFolders.General();
				case GameFolders.Tipo.save:
				case GameFolders.Tipo.saveV1:
				case GameFolders.Tipo.autoRatingPortraits:
					break;
				case GameFolders.Tipo.config:
					return GameFolders.ToConfigs();
				case GameFolders.Tipo.characters:
					return GameFolders.ToCharactersV3();
				case GameFolders.Tipo.saveV2:
					return GameFolders.ToSavesV3();
				case GameFolders.Tipo.charactersV2:
					return GameFolders.ToCharactersV3();
				case GameFolders.Tipo.autoRatingPortraitsV2:
					return GameFolders.ToAutoRatingProfilesV3();
				case GameFolders.Tipo.poses:
					return GameFolders.ToPoses3();
				case GameFolders.Tipo.ropa:
					return GameFolders.ToOutfit3();
				case GameFolders.Tipo.gestos:
					return GameFolders.ToGestos();
				case GameFolders.Tipo.makeover:
					return GameFolders.ToMakeover();
				default:
					if (tipo == GameFolders.Tipo.moddingRopa)
					{
						return GameFolders.ToModding(GameFolders.TipoMod.ropa);
					}
					break;
				}
			}
			else
			{
				if (tipo == GameFolders.Tipo.moddingScripts)
				{
					return GameFolders.ToModding(GameFolders.TipoMod.scripts);
				}
				if (tipo == GameFolders.Tipo.testing)
				{
					return GameFolders.ToTesting();
				}
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000185EC File Offset: 0x000167EC
		public static string General()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (!string.IsNullOrWhiteSpace(GameFolders.companyName))
			{
				text = Path.Combine(text, GameFolders.companyName);
				DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
			}
			if (!string.IsNullOrWhiteSpace(GameFolders.productName))
			{
				text = Path.Combine(text, GameFolders.productName);
				DirectoryInfo directoryInfo2 = Directory.CreateDirectory(text);
				if (!directoryInfo2.Exists)
				{
					directoryInfo2.Create();
				}
			}
			return text;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001865C File Offset: 0x0001685C
		public static string ToDebugPrints()
		{
			string text = Path.Combine(GameFolders.General(), "DEBUG_PRINT");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00018690 File Offset: 0x00016890
		[Obsolete("", true)]
		public static string ToSaves()
		{
			string text = Path.Combine(GameFolders.General(), "Save", "v0.003");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x000186C8 File Offset: 0x000168C8
		[Obsolete("", true)]
		public static string ToSavesV1()
		{
			string text = Path.Combine(GameFolders.General(), "Save", "v0.01");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00018700 File Offset: 0x00016900
		[Obsolete("", true)]
		public static string ToSavesV2()
		{
			string text = Path.Combine(GameFolders.General(), "Save", "v08");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00018738 File Offset: 0x00016938
		public static string ToSavesV3()
		{
			string text = Path.Combine(GameFolders.General(), "Save", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00018770 File Offset: 0x00016970
		[Obsolete("", true)]
		public static string ToCharactersV1()
		{
			string text = Path.Combine(GameFolders.General(), "Characters", "v0.01");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x000187A8 File Offset: 0x000169A8
		[Obsolete("", true)]
		public static string ToAutoRatingProfilesV1()
		{
			string text = Path.Combine(GameFolders.General(), "Profiles", "v0.01");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x000187E0 File Offset: 0x000169E0
		[Obsolete("", true)]
		public static string ToCharactersV2()
		{
			string text = Path.Combine(GameFolders.General(), "Characters", "v08");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00018818 File Offset: 0x00016A18
		public static string ToCharactersV3()
		{
			string text = Path.Combine(GameFolders.General(), "Characters", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00018850 File Offset: 0x00016A50
		[Obsolete("", true)]
		public static string ToOutfit()
		{
			string text = Path.Combine(GameFolders.General(), "Outfits", "v08");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00018888 File Offset: 0x00016A88
		public static string ToOutfit3()
		{
			string text = Path.Combine(GameFolders.General(), "Outfits", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000188C0 File Offset: 0x00016AC0
		public static string ToGestos()
		{
			string text = Path.Combine(GameFolders.General(), "Gestures", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000188F8 File Offset: 0x00016AF8
		public static string ToMakeover()
		{
			string text = Path.Combine(GameFolders.General(), "Makeover", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00018930 File Offset: 0x00016B30
		[Obsolete("", true)]
		public static string ToPoses()
		{
			string text = Path.Combine(GameFolders.General(), "Poses", "v08");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00018968 File Offset: 0x00016B68
		public static string ToPoses3()
		{
			string text = Path.Combine(GameFolders.General(), "Poses", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000189A0 File Offset: 0x00016BA0
		[Obsolete("", true)]
		public static string ToAutoRatingProfilesV2()
		{
			string text = Path.Combine(GameFolders.General(), "Profiles", "v08");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000189D8 File Offset: 0x00016BD8
		public static string ToAutoRatingProfilesV3()
		{
			string text = Path.Combine(GameFolders.General(), "Profiles", "v1");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00018A10 File Offset: 0x00016C10
		public static string ToModding(GameFolders.TipoMod tipo)
		{
			string text;
			if (tipo != GameFolders.TipoMod.ropa)
			{
				if (tipo != GameFolders.TipoMod.scripts)
				{
					throw new ArgumentOutOfRangeException(tipo.ToString());
				}
				text = "Scripts";
			}
			else
			{
				text = "Clothing";
			}
			string text2 = Path.Combine(GameFolders.General(), "Mods", text);
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text2);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text2;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00018A70 File Offset: 0x00016C70
		public static string ToTesting()
		{
			string text = Path.Combine(GameFolders.General(), "TESTING");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00018AA4 File Offset: 0x00016CA4
		public static string ToConfigs()
		{
			string text = Path.Combine(GameFolders.General(), "Config");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			return text;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00018AD5 File Offset: 0x00016CD5
		public static string GameDebugPrintPath(string fileName)
		{
			return Path.Combine(GameFolders.ToDebugPrints(), fileName + ".txt");
		}

		// Token: 0x040001ED RID: 493
		public static readonly string companyName = Application.companyName;

		// Token: 0x040001EE RID: 494
		public static readonly string productName = "Some Modeling Agency";

		// Token: 0x040001EF RID: 495
		[Obsolete("", true)]
		public const string saveVersion = "v0.003";

		// Token: 0x040001F0 RID: 496
		[Obsolete("", true)]
		public const string saveVersion1 = "v0.01";

		// Token: 0x040001F1 RID: 497
		public const string saveVersion2 = "v08";

		// Token: 0x040001F2 RID: 498
		public const string saveVersion3 = "v1";

		// Token: 0x020001D1 RID: 465
		public enum TipoMod
		{
			// Token: 0x0400044B RID: 1099
			ropa,
			// Token: 0x0400044C RID: 1100
			scripts
		}

		// Token: 0x020001D2 RID: 466
		public enum Tipo
		{
			// Token: 0x0400044E RID: 1102
			general,
			// Token: 0x0400044F RID: 1103
			[Obsolete("OLD", true)]
			save,
			// Token: 0x04000450 RID: 1104
			config,
			// Token: 0x04000451 RID: 1105
			[Obsolete("OLD", true)]
			saveV1,
			// Token: 0x04000452 RID: 1106
			saveV2 = 6,
			// Token: 0x04000453 RID: 1107
			characters = 4,
			// Token: 0x04000454 RID: 1108
			charactersV2 = 7,
			// Token: 0x04000455 RID: 1109
			[Obsolete("", true)]
			autoRatingPortraits = 5,
			// Token: 0x04000456 RID: 1110
			autoRatingPortraitsV2 = 8,
			// Token: 0x04000457 RID: 1111
			poses,
			// Token: 0x04000458 RID: 1112
			ropa,
			// Token: 0x04000459 RID: 1113
			gestos,
			// Token: 0x0400045A RID: 1114
			makeover,
			// Token: 0x0400045B RID: 1115
			moddingRopa = 50,
			// Token: 0x0400045C RID: 1116
			moddingScripts,
			// Token: 0x0400045D RID: 1117
			saveLatestVersion = 99,
			// Token: 0x0400045E RID: 1118
			testing
		}
	}
}
