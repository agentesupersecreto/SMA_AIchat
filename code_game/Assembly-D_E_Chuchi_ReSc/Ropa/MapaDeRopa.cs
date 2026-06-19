using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200010C RID: 268
	[CreateAssetMenu(fileName = "MapaDeRopa", menuName = "Objetos/Ropa/MapaDeRopa")]
	public class MapaDeRopa : AplicableScriptable
	{
		// Token: 0x0600067E RID: 1662 RVA: 0x0001EE60 File Offset: 0x0001D060
		private void OnValidate()
		{
			for (int i = 0; i < this.m_piezas.Count; i++)
			{
				MapaDeRopa.RopaData ropaData = this.m_piezas[i];
				if (ropaData != null)
				{
					ropaData.TryInitID();
				}
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0001EE9B File Offset: 0x0001D09B
		public List<MapaDeRopa.RopaData> piezas
		{
			get
			{
				return this.m_piezas;
			}
		}

		// Token: 0x0400048B RID: 1163
		[SerializeField]
		private List<MapaDeRopa.RopaData> m_piezas = new List<MapaDeRopa.RopaData>();

		// Token: 0x0200010D RID: 269
		[Serializable]
		public class RopaData : GlobalUserData
		{
			// Token: 0x17000162 RID: 354
			// (get) Token: 0x06000681 RID: 1665 RVA: 0x0001EEB6 File Offset: 0x0001D0B6
			[Obsolete("", true)]
			public sealed override int id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x17000163 RID: 355
			// (get) Token: 0x06000682 RID: 1666 RVA: 0x0001EEBE File Offset: 0x0001D0BE
			public int idParaMateriales
			{
				get
				{
					return this.m_idParaMateriales;
				}
			}

			// Token: 0x17000164 RID: 356
			// (get) Token: 0x06000683 RID: 1667 RVA: 0x0001EEB6 File Offset: 0x0001D0B6
			[Obsolete("", true)]
			public MapaDeRopa.RopaPreSetId enumID
			{
				get
				{
					return (MapaDeRopa.RopaPreSetId)this.m_id;
				}
			}

			// Token: 0x17000165 RID: 357
			// (get) Token: 0x06000684 RID: 1668 RVA: 0x0001EEC6 File Offset: 0x0001D0C6
			// (set) Token: 0x06000685 RID: 1669 RVA: 0x0001EECE File Offset: 0x0001D0CE
			public GameObject inGamePrefab
			{
				get
				{
					return this.m_inGamePrefab;
				}
				set
				{
					this.m_inGamePrefab = value;
				}
			}

			// Token: 0x17000166 RID: 358
			// (get) Token: 0x06000686 RID: 1670 RVA: 0x0001EED7 File Offset: 0x0001D0D7
			public bool usaTessellation
			{
				get
				{
					return this.skinConfig.usarTessellation;
				}
			}

			// Token: 0x17000167 RID: 359
			// (get) Token: 0x06000687 RID: 1671 RVA: 0x0001EEE4 File Offset: 0x0001D0E4
			public List<NormalRecalculadorBoneMap.Tipo> recalculadores
			{
				get
				{
					return this.skinConfig.recalculadores;
				}
			}

			// Token: 0x17000168 RID: 360
			// (get) Token: 0x06000688 RID: 1672 RVA: 0x0001EEF1 File Offset: 0x0001D0F1
			public string skinName
			{
				get
				{
					return this.m_skinName;
				}
			}

			// Token: 0x06000689 RID: 1673 RVA: 0x0001EEF9 File Offset: 0x0001D0F9
			public bool Cubre(RopaCubre cubre)
			{
				return ((int)this.cubreFlag).HasFlag((int)cubre);
			}

			// Token: 0x0600068A RID: 1674 RVA: 0x0001EF08 File Offset: 0x0001D108
			protected sealed override void OnInit()
			{
				AssetReference assetReference = this.prefabAddress;
				if (string.IsNullOrEmpty((assetReference != null) ? assetReference.AssetGUID : null) && this.m_inGamePrefab == null)
				{
					throw new ArgumentNullException("prefab", "prefab null reference.");
				}
				if (!this.nombreEsSingular && !this.nombreEsPlural)
				{
					Debug.LogError("DialogoInfoParteDelCuerpo no es para plurar ni singular: " + this.nombreCompleto);
				}
			}

			// Token: 0x0600068B RID: 1675 RVA: 0x0001EF71 File Offset: 0x0001D171
			public void SetSkinName(GameObject instance)
			{
				this.m_skinName = instance.name + "[" + base.stringId + "]";
			}

			// Token: 0x0600068C RID: 1676 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnInitiatedID()
			{
			}

			// Token: 0x0600068D RID: 1677 RVA: 0x0001EF94 File Offset: 0x0001D194
			protected sealed override bool OnIsPreInitValid()
			{
				return !string.IsNullOrEmpty(this.prefabAddress.AssetGUID) || this.m_inGamePrefab != null;
			}

			// Token: 0x0600068E RID: 1678 RVA: 0x00005F51 File Offset: 0x00004151
			protected sealed override bool OnIsPostInitValid()
			{
				return true;
			}

			// Token: 0x0400048C RID: 1164
			public bool nombreEsSingular;

			// Token: 0x0400048D RID: 1165
			public bool nombreEsPlural;

			// Token: 0x0400048E RID: 1166
			public int cantidadDeMateriales = 1;

			// Token: 0x0400048F RID: 1167
			public MapaDeRopa.RopaData.InstanceOptions comoInstanciar;

			// Token: 0x04000490 RID: 1168
			[ClassExtends(typeof(PiezaDeRopaBase))]
			public SerializableType tipo;

			// Token: 0x04000491 RID: 1169
			public List<MapaDeRopa.RopaData.CustomScript> customScripts;

			// Token: 0x04000492 RID: 1170
			[Obsolete("", true)]
			[HideInInspector]
			[EnumID(typeof(MapaDeRopa.RopaPreSetId))]
			private int m_id;

			// Token: 0x04000493 RID: 1171
			[HideInInspector]
			[EnumID(typeof(MapaDeRopa.RopaPreSetId))]
			private int m_idParaMateriales;

			// Token: 0x04000494 RID: 1172
			[ComboBox(typeof(ProveedorPiezasDeRopaIDAttribute))]
			public string idParaMaterialesString;

			// Token: 0x04000495 RID: 1173
			public AssetReference prefabAddress;

			// Token: 0x04000496 RID: 1174
			[SerializeField]
			private GameObject m_inGamePrefab;

			// Token: 0x04000497 RID: 1175
			public AssetReference armatureAddress;

			// Token: 0x04000498 RID: 1176
			public List<MapaDeRopa.RopaData.SkinCollider> skinsToColliders = new List<MapaDeRopa.RopaData.SkinCollider>();

			// Token: 0x04000499 RID: 1177
			public RopaLayer layer = RopaLayer.ropa;

			// Token: 0x0400049A RID: 1178
			public RopaPosicion posicion;

			// Token: 0x0400049B RID: 1179
			public RopaCubre cubreFlag;

			// Token: 0x0400049C RID: 1180
			public Sexo paraSexo;

			// Token: 0x0400049D RID: 1181
			public MapaDeRopa.TipoDePrenda tipoDePrenda;

			// Token: 0x0400049E RID: 1182
			public ItemQuality itemQuality = ItemQuality.Common;

			// Token: 0x0400049F RID: 1183
			public float semenDistanceCastAdd;

			// Token: 0x040004A0 RID: 1184
			public List<MapaDeRopa.RopaData.Interacciones> interacciones = new List<MapaDeRopa.RopaData.Interacciones>();

			// Token: 0x040004A1 RID: 1185
			[NonSerialized]
			private string m_skinName;

			// Token: 0x040004A2 RID: 1186
			public MapaDeRopa.RopaData.ProbabilidadConfig probabilidadConfig = new MapaDeRopa.RopaData.ProbabilidadConfig();

			// Token: 0x040004A3 RID: 1187
			public SkinConfig skinConfig = new SkinConfig();

			// Token: 0x040004A4 RID: 1188
			public MapaDeRopa.RopaData.ShoesConfig shoesConfig = new MapaDeRopa.RopaData.ShoesConfig();

			// Token: 0x040004A5 RID: 1189
			public MapaDeRopa.RopaData.SenosConfig senosConfig = new MapaDeRopa.RopaData.SenosConfig();

			// Token: 0x040004A6 RID: 1190
			public MapaDeRopa.RopaData.NalgasConfig nalgasConfig = new MapaDeRopa.RopaData.NalgasConfig();

			// Token: 0x040004A7 RID: 1191
			public MapaDeRopa.RopaData.VagConfig vagConfig = new MapaDeRopa.RopaData.VagConfig();

			// Token: 0x040004A8 RID: 1192
			public MapaDeRopa.RopaData.AnusConfig anusConfig = new MapaDeRopa.RopaData.AnusConfig();

			// Token: 0x0200010E RID: 270
			public enum InstanceOptions
			{
				// Token: 0x040004AA RID: 1194
				todoElPrefab,
				// Token: 0x040004AB RID: 1195
				[Obsolete]
				soloSkinnedMeshRenderer,
				// Token: 0x040004AC RID: 1196
				[Obsolete]
				soloSkinnedMeshRendererGameObject
			}

			// Token: 0x0200010F RID: 271
			[Serializable]
			public class SkinCollider
			{
				// Token: 0x040004AD RID: 1197
				public AssetReference rendererAddress;

				// Token: 0x040004AE RID: 1198
				public MapaDeRopa.RopaData.SkinCollider.TipoDeMontura tipoDeMontura;

				// Token: 0x02000110 RID: 272
				public enum TipoDeMontura
				{
					// Token: 0x040004B0 RID: 1200
					femaleSkeleton,
					// Token: 0x040004B1 RID: 1201
					skinSkeleton
				}
			}

			// Token: 0x02000111 RID: 273
			[Serializable]
			public class MaterialSlotPar
			{
				// Token: 0x040004B2 RID: 1202
				public int slot;
			}

			// Token: 0x02000112 RID: 274
			[Serializable]
			public class ShoesConfig
			{
				// Token: 0x040004B3 RID: 1203
				public bool puedeTenerMedias = true;

				// Token: 0x040004B4 RID: 1204
				public float toeHeigth;

				// Token: 0x040004B5 RID: 1205
				public float heelHeigth;

				// Token: 0x040004B6 RID: 1206
				public float toePoseWeigth = 1f;

				// Token: 0x040004B7 RID: 1207
				public float heelPoseWeigth = 1f;
			}

			// Token: 0x02000113 RID: 275
			[Serializable]
			public class ProbabilidadConfig
			{
				// Token: 0x040004B8 RID: 1208
				[Range(0f, 100f)]
				public float chance = 100f;
			}

			// Token: 0x02000114 RID: 276
			[Serializable]
			public class SenosConfig
			{
				// Token: 0x040004B9 RID: 1209
				[Range(0.9f, 4f)]
				public float modificadorDeFirmeza = 1f;

				// Token: 0x040004BA RID: 1210
				[Range(0.25f, 2f)]
				public float modificadorDeLargoDePunta = 1f;

				// Token: 0x040004BB RID: 1211
				[Tooltip("menores a zero para aplanar el pezon, mayores a zero para dar forma de pezon custom")]
				[Range(-1f, 1f)]
				public float modificadorDeShapeDePezonV2 = 1f;

				// Token: 0x040004BC RID: 1212
				[Tooltip("segun el tamaño de los senos, puede q el efecto de juntar se disminuya")]
				[Range(0f, 1f)]
				public float distanciar = 1f;
			}

			// Token: 0x02000115 RID: 277
			[Serializable]
			public class NalgasConfig
			{
				// Token: 0x040004BD RID: 1213
				[Range(0.9f, 4f)]
				public float modificadorDeFirmeza = 1f;
			}

			// Token: 0x02000116 RID: 278
			[Serializable]
			public class VagConfig
			{
				// Token: 0x040004BE RID: 1214
				[Tooltip("Achica verticalmente la vag")]
				[Range(0f, 1f)]
				public float estrechuraVertical;

				// Token: 0x040004BF RID: 1215
				[Tooltip("Achica horizontalmente la vag")]
				[Range(0f, 1f)]
				public float estrechuraHorizontal;

				// Token: 0x040004C0 RID: 1216
				[Range(0f, 2f)]
				public float modificadorDeDesgaste = 1f;
			}

			// Token: 0x02000117 RID: 279
			[Serializable]
			public class AnusConfig
			{
				// Token: 0x040004C1 RID: 1217
				[Range(0f, 2f)]
				public float modificadorDeDesgaste = 1f;
			}

			// Token: 0x02000118 RID: 280
			[Serializable]
			public class CustomScript
			{
				// Token: 0x040004C2 RID: 1218
				[AssemblyQualifiedName]
				public string assemblyQualifiedName;
			}

			// Token: 0x02000119 RID: 281
			[Serializable]
			public class Interacciones
			{
				// Token: 0x17000169 RID: 361
				// (get) Token: 0x06000699 RID: 1689 RVA: 0x0001F0E8 File Offset: 0x0001D2E8
				[Obsolete("", true)]
				public int subPrendaID
				{
					get
					{
						return this.m_subPrendaID;
					}
				}

				// Token: 0x040004C3 RID: 1219
				public MapaDeRopa.Interaciones id;

				// Token: 0x040004C4 RID: 1220
				[Obsolete("", true)]
				[HideInInspector]
				[EnumID(typeof(MapaDeRopa.RopaPreSetId))]
				private int m_subPrendaID;

				// Token: 0x040004C5 RID: 1221
				[ComboBox(typeof(ProveedorPiezasDeRopaIDAttribute))]
				public string subPrendaIDString;

				// Token: 0x040004C6 RID: 1222
				public string shapeName;

				// Token: 0x040004C7 RID: 1223
				public List<MapaDeRopa.RopaData.Interacciones.FixShapes> fixes = new List<MapaDeRopa.RopaData.Interacciones.FixShapes>();

				// Token: 0x0200011A RID: 282
				[Serializable]
				public class FixShapes
				{
					// Token: 0x040004C8 RID: 1224
					public AnimationCurve inOut1x1Curve;

					// Token: 0x040004C9 RID: 1225
					public string shapeName;
				}
			}
		}

		// Token: 0x0200011B RID: 283
		public enum TipoDePrenda
		{
			// Token: 0x040004CB RID: 1227
			None,
			// Token: 0x040004CC RID: 1228
			underwearInferior,
			// Token: 0x040004CD RID: 1229
			underwearSuperior,
			// Token: 0x040004CE RID: 1230
			underwearSuperiorAccessories = 11,
			// Token: 0x040004CF RID: 1231
			underwearInferiorAccessories,
			// Token: 0x040004D0 RID: 1232
			inferior = 3,
			// Token: 0x040004D1 RID: 1233
			superior,
			// Token: 0x040004D2 RID: 1234
			shoes,
			// Token: 0x040004D3 RID: 1235
			superiorExterior,
			// Token: 0x040004D4 RID: 1236
			swimsuit,
			// Token: 0x040004D5 RID: 1237
			accessories = 9,
			// Token: 0x040004D6 RID: 1238
			glases,
			// Token: 0x040004D7 RID: 1239
			socks = 8,
			// Token: 0x040004D8 RID: 1240
			gloves = 13,
			// Token: 0x040004D9 RID: 1241
			hat
		}

		// Token: 0x0200011C RID: 284
		public enum RopaPreSetId
		{
			// Token: 0x040004DB RID: 1243
			None,
			// Token: 0x040004DC RID: 1244
			boxers_Old,
			// Token: 0x040004DD RID: 1245
			camisote_Old,
			// Token: 0x040004DE RID: 1246
			skirt_Old,
			// Token: 0x040004DF RID: 1247
			camisa_Old,
			// Token: 0x040004E0 RID: 1248
			pantalonFlojoConCorrea_Old,
			// Token: 0x040004E1 RID: 1249
			slip_ons_Old,
			// Token: 0x040004E2 RID: 1250
			tennis_Old,
			// Token: 0x040004E3 RID: 1251
			boyshorts = 9911,
			// Token: 0x040004E4 RID: 1252
			boyshorts_Thong,
			// Token: 0x040004E5 RID: 1253
			g_String,
			// Token: 0x040004E6 RID: 1254
			thong,
			// Token: 0x040004E7 RID: 1255
			underwearClassic,
			// Token: 0x040004E8 RID: 1256
			bra = 99011,
			// Token: 0x040004E9 RID: 1257
			braSinTiras,
			// Token: 0x040004EA RID: 1258
			braMediaCopa,
			// Token: 0x040004EB RID: 1259
			minFaldaAjustada = 99101,
			// Token: 0x040004EC RID: 1260
			faldaAjustada,
			// Token: 0x040004ED RID: 1261
			pantalones,
			// Token: 0x040004EE RID: 1262
			pantalonesAjustados,
			// Token: 0x040004EF RID: 1263
			shorts,
			// Token: 0x040004F0 RID: 1264
			camisa = 99201,
			// Token: 0x040004F1 RID: 1265
			camisole,
			// Token: 0x040004F2 RID: 1266
			camisoleSinTiras,
			// Token: 0x040004F3 RID: 1267
			HenleyLongsleeveCorto,
			// Token: 0x040004F4 RID: 1268
			HenleyLongsleeveLargo,
			// Token: 0x040004F5 RID: 1269
			blazer = 99301,
			// Token: 0x040004F6 RID: 1270
			cardigan,
			// Token: 0x040004F7 RID: 1271
			botas = 990001,
			// Token: 0x040004F8 RID: 1272
			flipFlops,
			// Token: 0x040004F9 RID: 1273
			loafers,
			// Token: 0x040004FA RID: 1274
			sandals,
			// Token: 0x040004FB RID: 1275
			slipOns,
			// Token: 0x040004FC RID: 1276
			sneakers,
			// Token: 0x040004FD RID: 1277
			swimsuit1 = 991001,
			// Token: 0x040004FE RID: 1278
			socks = 992001,
			// Token: 0x040004FF RID: 1279
			veiledStockings,
			// Token: 0x04000500 RID: 1280
			sexyBra1 = 991003,
			// Token: 0x04000501 RID: 1281
			sexyPanties1,
			// Token: 0x04000502 RID: 1282
			sexyGloves1,
			// Token: 0x04000503 RID: 1283
			glasesCatEye = 993001,
			// Token: 0x04000504 RID: 1284
			glasesSquare,
			// Token: 0x04000505 RID: 1285
			glasesRound,
			// Token: 0x04000506 RID: 1286
			bracelet1 = 994001,
			// Token: 0x04000507 RID: 1287
			necklace1,
			// Token: 0x04000508 RID: 1288
			boyshorts_ExposeAss = 991101,
			// Token: 0x04000509 RID: 1289
			boyshorts_ExposeVagAnus,
			// Token: 0x0400050A RID: 1290
			boyshorts_ExposeAss_ExposeVagAnus,
			// Token: 0x0400050B RID: 1291
			boyshorts_Thong_ExposeVagAnus = 991201,
			// Token: 0x0400050C RID: 1292
			g_String_ExposeVagAnus = 991301,
			// Token: 0x0400050D RID: 1293
			g_String_ExposeAss_ExposeVagAnus,
			// Token: 0x0400050E RID: 1294
			thong_ExposeVagAnus = 991401,
			// Token: 0x0400050F RID: 1295
			thong_ExposeAss_ExposeVagAnus,
			// Token: 0x04000510 RID: 1296
			underwearClassic_ExposeAss = 991501,
			// Token: 0x04000511 RID: 1297
			underwearClassic_ExposeVagAnus,
			// Token: 0x04000512 RID: 1298
			underwearClassic_ExposeAss_ExposeVagAnus,
			// Token: 0x04000513 RID: 1299
			bra_ExposeNipples = 9901101,
			// Token: 0x04000514 RID: 1300
			bra_ExposeNipples_ExposeShoulders,
			// Token: 0x04000515 RID: 1301
			braSinTiras_ExposeNipples = 9901201,
			// Token: 0x04000516 RID: 1302
			shorts_ExposeAss = 9910501,
			// Token: 0x04000517 RID: 1303
			shorts_PullDownHalf,
			// Token: 0x04000518 RID: 1304
			shorts_ExposeAss_ExposeVagAnus,
			// Token: 0x04000519 RID: 1305
			shorts_PullDown,
			// Token: 0x0400051A RID: 1306
			pantalonesAjustados_PullDownHalf = 9910401,
			// Token: 0x0400051B RID: 1307
			pantalonesAjustados_PullDown,
			// Token: 0x0400051C RID: 1308
			pantalones_Open = 9910301,
			// Token: 0x0400051D RID: 1309
			pantalones_PullDown,
			// Token: 0x0400051E RID: 1310
			minFaldaAjustada_PulledUpHalf = 9910101,
			// Token: 0x0400051F RID: 1311
			minFaldaAjustada_PulledUp,
			// Token: 0x04000520 RID: 1312
			faldaAjustada_PulledUpHalf = 9910201,
			// Token: 0x04000521 RID: 1313
			faldaAjustada_PulledUp,
			// Token: 0x04000522 RID: 1314
			camisa_OpenHalf = 9920101,
			// Token: 0x04000523 RID: 1315
			camisa_Open,
			// Token: 0x04000524 RID: 1316
			camisole_PullDown = 9920201,
			// Token: 0x04000525 RID: 1317
			camisoleSinTiras_PullDown = 9920301,
			// Token: 0x04000526 RID: 1318
			HenleyLongsleeveCorto_PulledUpHalf = 9920401,
			// Token: 0x04000527 RID: 1319
			HenleyLongsleeveCorto_PulledUp,
			// Token: 0x04000528 RID: 1320
			HenleyLongsleeveLargo_PulledUpHalf = 9920501,
			// Token: 0x04000529 RID: 1321
			HenleyLongsleeveLargo_PulledUp
		}

		// Token: 0x0200011D RID: 285
		public enum Interaciones
		{
			// Token: 0x0400052B RID: 1323
			None,
			// Token: 0x0400052C RID: 1324
			exposeLegL,
			// Token: 0x0400052D RID: 1325
			exposeLegR,
			// Token: 0x0400052E RID: 1326
			exposeAssL,
			// Token: 0x0400052F RID: 1327
			exposeAssR,
			// Token: 0x04000530 RID: 1328
			exposeAssSideL,
			// Token: 0x04000531 RID: 1329
			exposeAssSideR,
			// Token: 0x04000532 RID: 1330
			exposeVagAnusL,
			// Token: 0x04000533 RID: 1331
			exposeVagAnusR,
			// Token: 0x04000534 RID: 1332
			exposeNipplesL,
			// Token: 0x04000535 RID: 1333
			exposeNipplesR,
			// Token: 0x04000536 RID: 1334
			exposeShouldersL,
			// Token: 0x04000537 RID: 1335
			exposeShouldersR,
			// Token: 0x04000538 RID: 1336
			exposeAssHalf1L,
			// Token: 0x04000539 RID: 1337
			exposeAssHalf1R,
			// Token: 0x0400053A RID: 1338
			exposeAssHalf2L,
			// Token: 0x0400053B RID: 1339
			exposeAssHalf2R,
			// Token: 0x0400053C RID: 1340
			pullDownAssHalf1L,
			// Token: 0x0400053D RID: 1341
			pullDownAssHalf1R,
			// Token: 0x0400053E RID: 1342
			pullDownAssHalf2L,
			// Token: 0x0400053F RID: 1343
			pullDownAssHalf2R,
			// Token: 0x04000540 RID: 1344
			exposeCrotchF,
			// Token: 0x04000541 RID: 1345
			pullDownAssL,
			// Token: 0x04000542 RID: 1346
			pullDownAssR,
			// Token: 0x04000543 RID: 1347
			exposeTorzoHalf1F,
			// Token: 0x04000544 RID: 1348
			exposeTorzoHalf2F,
			// Token: 0x04000545 RID: 1349
			exposeTorzoHalf1B,
			// Token: 0x04000546 RID: 1350
			exposeTorzoHalf2B,
			// Token: 0x04000547 RID: 1351
			exposeChestLateralHalf1L,
			// Token: 0x04000548 RID: 1352
			exposeChestLateralHalf1R,
			// Token: 0x04000549 RID: 1353
			exposeChestLateralHalf2L,
			// Token: 0x0400054A RID: 1354
			exposeChestLateralHalf2R,
			// Token: 0x0400054B RID: 1355
			exposeHipsHalf1L,
			// Token: 0x0400054C RID: 1356
			exposeHipsHalf1R,
			// Token: 0x0400054D RID: 1357
			exposeHipsHalf2L,
			// Token: 0x0400054E RID: 1358
			exposeHipsHalf2R
		}
	}
}
