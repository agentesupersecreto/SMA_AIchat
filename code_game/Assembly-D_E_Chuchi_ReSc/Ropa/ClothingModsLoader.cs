using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Moddding;
using Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D7 RID: 215
	public static class ClothingModsLoader
	{
		// Token: 0x06000548 RID: 1352 RVA: 0x0001888D File Offset: 0x00016A8D
		public static IEnumerator LoadModsRutine(Action<ClothingItemMap[], MaterialMap[], MapaDeRopa, MapaDeMaterialesParaRopa> onCompleted)
		{
			string[] catalogosExitentesPaths = ArchivosEnDisco.GetCatalogosExitentesPaths(GameFolders.Tipo.moddingRopa);
			IEnumerator[] array = new IEnumerator[catalogosExitentesPaths.Length];
			List<IResourceLocator> locatorsResult = new List<IResourceLocator>();
			for (int i = 0; i < catalogosExitentesPaths.Length; i++)
			{
				array[i] = ClothingModsLoader.LoadCatalogRutine(catalogosExitentesPaths[i], new Action<string, object>(ClothingModsLoader.OnFailCatalog), null, locatorsResult);
			}
			yield return ArchivosEnDisco.AsyncLoader(new ArchivosEnDisco.AsyncLoaderOnErrorHandler(ClothingModsLoader.OnCatalogError), new ArchivosEnDisco.AsyncLoaderOnCompletedHandler(ClothingModsLoader.OnCatalogComplete), catalogosExitentesPaths, array);
			HashSet<IResourceLocation> hashSet = new HashSet<IResourceLocation>(new ClothingModsLoader.ResourceLocationComparer());
			HashSet<IResourceLocation> hashSet2 = new HashSet<IResourceLocation>(new ClothingModsLoader.ResourceLocationComparer());
			foreach (IResourceLocator resourceLocator in locatorsResult)
			{
				foreach (object obj in resourceLocator.Keys)
				{
					IList<IResourceLocation> list;
					if (resourceLocator.Locate(obj, typeof(ClothingItemMap), out list))
					{
						hashSet.UnionWith(list);
					}
					IList<IResourceLocation> list2;
					if (resourceLocator.Locate(obj, typeof(MaterialMap), out list2))
					{
						hashSet2.UnionWith(list2);
					}
				}
			}
			IResourceLocation[] locationsClothingItemMaps = hashSet.ToArray<IResourceLocation>();
			IResourceLocation[] locationsMaterialMaps = hashSet2.ToArray<IResourceLocation>();
			ClothingItemMap[] ClothingItemMaps = new ClothingItemMap[locationsClothingItemMaps.Length];
			MaterialMap[] MaterialMaps = new MaterialMap[locationsMaterialMaps.Length];
			IEnumerator[] array2 = new IEnumerator[locationsClothingItemMaps.Length];
			for (int j = 0; j < locationsClothingItemMaps.Length; j++)
			{
				array2[j] = ClothingModsLoader.LoadMapRutine<ClothingItemMap>(locationsClothingItemMaps[j], new Action<IResourceLocation>(ClothingModsLoader.OnFailMap), j, ClothingItemMaps);
			}
			IEnumerator[] locationsMaterialMapsLoaders = new IEnumerator[locationsMaterialMaps.Length];
			for (int k = 0; k < locationsMaterialMaps.Length; k++)
			{
				locationsMaterialMapsLoaders[k] = ClothingModsLoader.LoadMapRutine<MaterialMap>(locationsMaterialMaps[k], new Action<IResourceLocation>(ClothingModsLoader.OnFailMap), k, MaterialMaps);
			}
			yield return ArchivosEnDisco.AsyncLoader(new ArchivosEnDisco.AsyncLoaderOnErrorHandler(ClothingModsLoader.OnMapError), new ArchivosEnDisco.AsyncLoaderOnCompletedHandler(ClothingModsLoader.OnMapComplete), locationsClothingItemMaps, array2);
			yield return ArchivosEnDisco.AsyncLoader(new ArchivosEnDisco.AsyncLoaderOnErrorHandler(ClothingModsLoader.OnMapError), new ArchivosEnDisco.AsyncLoaderOnCompletedHandler(ClothingModsLoader.OnMapComplete), locationsMaterialMaps, locationsMaterialMapsLoaders);
			IEnumerable<ClothingItemMap> enumerable = ClothingItemMaps.Where(delegate(ClothingItemMap m)
			{
				if (!m.TryInitID())
				{
					int num = ClothingItemMaps.IndexOf(m);
					Singleton<ModalWindow>.instance.AcumularErrores("ClothingItem: " + locationsClothingItemMaps[num].InternalId + ", does not have a valid id", null);
					Debug.LogError(string.Concat(new string[]
					{
						"material in index ",
						num.ToString(),
						" of garment id: ",
						locationsClothingItemMaps[num].InternalId,
						", does not have a valid id"
					}));
					return false;
				}
				return true;
			});
			MaterialMaps.ForEach(delegate(MaterialMap m)
			{
				m.TryInitID();
			});
			IEnumerable<IGrouping<string, ClothingItemMap>> enumerable2 = from m in enumerable
				group m by m.id;
			enumerable2.ForEach(delegate(IGrouping<string, ClothingItemMap> g)
			{
				if (g.Count<ClothingItemMap>() > 1)
				{
					Singleton<ModalWindow>.instance.AcumularErrores("ClothingItems contains duplicated IDs: " + g.First<ClothingItemMap>().id, null);
					Debug.LogError("ClothingItems contains duplicated IDs: " + g.First<ClothingItemMap>().id);
				}
			});
			(from m in MaterialMaps
				group m by m.id).ForEach(delegate(IGrouping<string, MaterialMap> g)
			{
				if (!string.IsNullOrWhiteSpace(g.First<MaterialMap>().id) && g.Count<MaterialMap>() > 1)
				{
					Singleton<ModalWindow>.instance.AcumularErrores("MaterialMaps contains duplicated IDs: " + g.First<MaterialMap>().id, null);
					Debug.LogError("MaterialMaps contains duplicated IDs: " + g.First<MaterialMap>().id);
				}
			});
			List<ClothingItemMap> list3 = enumerable2.Select((IGrouping<string, ClothingItemMap> g) => g.First<ClothingItemMap>()).ToList<ClothingItemMap>();
			List<ClothingItemMap> list4;
			ClothingModsLoader.OrganizarDePadresAHijos(ref list3, out list4);
			Dictionary<string, MapaDeRopa.RopaData> dictionary = new Dictionary<string, MapaDeRopa.RopaData>();
			Dictionary<string, MaterialParaRopaData> dictionary2 = new Dictionary<string, MaterialParaRopaData>();
			for (int l = 0; l < list3.Count; l++)
			{
				ClothingItemMap clothingItemMap = list3[l];
				ClothingItemMap clothingItemMap2 = list4[l];
				MapaDeRopa.RopaData ropaData = ((clothingItemMap2 != null) ? dictionary.GetValueOrDefault(clothingItemMap2.id) : null);
				ClothingModsLoader.Parce(clothingItemMap, ropaData, dictionary2, dictionary);
			}
			MapaDeRopa mapaDeRopa = ScriptableObject.CreateInstance<MapaDeRopa>();
			mapaDeRopa.piezas.AddRange(dictionary.Values);
			MapaDeMaterialesParaRopa mapaDeMaterialesParaRopa = ScriptableObject.CreateInstance<MapaDeMaterialesParaRopa>();
			mapaDeMaterialesParaRopa.materiales.AddRange(dictionary2.Values);
			if (onCompleted != null)
			{
				onCompleted(ClothingItemMaps, MaterialMaps, mapaDeRopa, mapaDeMaterialesParaRopa);
			}
			yield break;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001889C File Offset: 0x00016A9C
		private static IEnumerator LoadMapRutine<TMap>(IResourceLocation location, Action<IResourceLocation> onFaild, int index, IList<TMap> locatorsResult)
		{
			AsyncOperationHandle<TMap> oper = Addressables.LoadAssetAsync<TMap>(location);
			yield return oper;
			if (oper.Result == null)
			{
				if (onFaild != null)
				{
					onFaild(location);
				}
				yield break;
			}
			locatorsResult[index] = oper.Result;
			yield break;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000188C0 File Offset: 0x00016AC0
		private static IEnumerator LoadCatalogRutine(string catalogPath, Action<string, object> onFaild, object context, List<IResourceLocator> locatorsResult)
		{
			AsyncOperationHandle<IResourceLocator> handle = Addressables.LoadContentCatalogAsync(catalogPath, false, null);
			yield return handle;
			if (handle.Result == null)
			{
				Addressables.Release<IResourceLocator>(handle);
				if (onFaild != null)
				{
					onFaild(catalogPath, context);
				}
				yield break;
			}
			Addressables.AddResourceLocator(handle.Result, null, null);
			locatorsResult.Add(handle.Result);
			Addressables.Release<IResourceLocator>(handle);
			yield break;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x000188E4 File Offset: 0x00016AE4
		private static void OnFailMap(IResourceLocation location)
		{
			Debug.LogError("Failed to modding Map : " + location.InternalId);
			Singleton<ModalWindow>.instance.AcumularErrores("Failed to modding Map : " + location.InternalId, null);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00018918 File Offset: 0x00016B18
		private static void OnMapError(object context, int index, Exception e)
		{
			IList<IResourceLocation> list = (IList<IResourceLocation>)context;
			Debug.LogError("Error loadding modding Map: " + list[index].InternalId + " -> " + e.Message);
			Singleton<ModalWindow>.instance.AcumularErrores("Error loadding modding Map: " + list[index].InternalId + " -> " + e.Message, null);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00018980 File Offset: 0x00016B80
		private static void OnMapComplete(object context, int index, Exception e)
		{
			IList<IResourceLocation> list = (IList<IResourceLocation>)context;
			Debug.Log("Mod map: " + list[index].InternalId + " was loaded");
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000189B4 File Offset: 0x00016BB4
		private static void OnFailCatalog(string path, object context)
		{
			Debug.LogError("Failed to load modding catalog: " + path);
			Singleton<ModalWindow>.instance.AcumularErrores("Failed to load modding catalog: " + path, null);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000189DC File Offset: 0x00016BDC
		private static void OnCatalogError(object context, int index, Exception e)
		{
			string[] array = (string[])context;
			Debug.LogError("Error loadding modding catalog: " + array[index] + " -> " + e.Message);
			Singleton<ModalWindow>.instance.AcumularErrores("Error loadding modding catalog: " + array[index] + " -> " + e.Message, null);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00018A30 File Offset: 0x00016C30
		private static void OnCatalogComplete(object context, int index, Exception e)
		{
			string[] array = (string[])context;
			Debug.Log("Mod: " + array[index] + " was loaded");
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00018A5C File Offset: 0x00016C5C
		private static void OrganizarDePadresAHijos(ref List<ClothingItemMap> desordenados, out List<ClothingItemMap> padresDeIndex)
		{
			IEnumerable<ClothingItemMap> hijos = (from inte in desordenados.SelectMany((ClothingItemMap m) => m.interactionsToSubClothingItems)
				select inte.subClothingItemMap).Distinct<ClothingItemMap>();
			IEnumerable<ClothingItemMap> enumerable = desordenados.Where((ClothingItemMap m) => !hijos.Contains(m));
			HashSet<ClothingItemMap> hashSet = new HashSet<ClothingItemMap>(desordenados.Count);
			Dictionary<ClothingItemMap, ClothingItemMap> dictionary = new Dictionary<ClothingItemMap, ClothingItemMap>(desordenados.Count);
			foreach (ClothingItemMap clothingItemMap in enumerable)
			{
				if (hashSet.Add(clothingItemMap))
				{
					dictionary.Add(clothingItemMap, null);
				}
			}
			foreach (ClothingItemMap clothingItemMap2 in enumerable)
			{
				ClothingModsLoader.AddChildren(clothingItemMap2, hashSet, dictionary);
			}
			desordenados = new List<ClothingItemMap>();
			padresDeIndex = new List<ClothingItemMap>();
			foreach (KeyValuePair<ClothingItemMap, ClothingItemMap> keyValuePair in dictionary)
			{
				desordenados.Add(keyValuePair.Key);
				padresDeIndex.Add(keyValuePair.Value);
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00018BDC File Offset: 0x00016DDC
		private static void AddChildren(ClothingItemMap map, ISet<ClothingItemMap> children, IDictionary<ClothingItemMap, ClothingItemMap> padreDechildren)
		{
			if (map.interactionsToSubClothingItems != null)
			{
				for (int i = 0; i < map.interactionsToSubClothingItems.Count; i++)
				{
					ClothingItemMap subClothingItemMap = map.interactionsToSubClothingItems[i].subClothingItemMap;
					if (!(subClothingItemMap == null))
					{
						if (children.Add(subClothingItemMap))
						{
							padreDechildren.Add(subClothingItemMap, map);
						}
						ClothingModsLoader.AddChildren(subClothingItemMap, children, padreDechildren);
					}
				}
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00018C3C File Offset: 0x00016E3C
		private static void Parce(ClothingItemMap map, MapaDeRopa.RopaData padre, Dictionary<string, MaterialParaRopaData> matsDataCreados, Dictionary<string, MapaDeRopa.RopaData> ropaDataCreados)
		{
			map.TryInitID();
			if (ropaDataCreados.ContainsKey(map.id))
			{
				Singleton<ModalWindow>.instance.AcumularErrores("Clothing mods contains duplicate ids: " + map.id, null);
				Debug.LogError("Clothing mods contains duplicate ids: " + map.id);
				return;
			}
			if (padre != null)
			{
				padre.TryInitID();
			}
			MapaDeRopa.RopaData ropaData = new MapaDeRopa.RopaData();
			ropaData.organizacion = map.organization;
			ropaData.categoria = map.category;
			ropaData.nombreCompleto = map.fullName;
			InGameName inGameName = map.inGameNames.FirstOrDefault((InGameName n) => n.language == Language.en);
			ropaData.nombreCorto = ((inGameName != null) ? inGameName.name : null) ?? ropaData.nombreCompleto;
			ropaData.version = map.version;
			ropaData.displayAutorsOnUsed = map.displayAuthorsOnUsed;
			ropaData.autores = map.authors.Select((Autor a) => new BaseGlobalUserData.Autor
			{
				name = a.name,
				URL = a.URL
			}).ToList<BaseGlobalUserData.Autor>();
			ropaData.nombreEsSingular = inGameName == null || !inGameName.isPlural;
			ropaData.nombreEsPlural = inGameName != null && inGameName.isPlural;
			ropaData.cantidadDeMateriales = map.materialsPerIndex.Count;
			ropaData.comoInstanciar = MapaDeRopa.RopaData.InstanceOptions.todoElPrefab;
			ropaData.tipo = null;
			ropaData.customScripts = (from c in map.customScripts
				where !string.IsNullOrEmpty(c.assemblyQualifiedName)
				select new MapaDeRopa.RopaData.CustomScript
				{
					assemblyQualifiedName = c.assemblyQualifiedName
				}).ToList<MapaDeRopa.RopaData.CustomScript>();
			ropaData.idParaMaterialesString = ((map.materialsPerIndex.Count > 0) ? null : ((padre != null) ? padre.stringId : null));
			ropaData.semenDistanceCastAdd = map.semenDistanceCastAdd;
			ropaData.prefabAddress = map.address;
			ropaData.armatureAddress = map.customArmatureAddress;
			ropaData.skinsToColliders = map.customColliders.Select((ClothingItemMap.CustomCollider c) => new MapaDeRopa.RopaData.SkinCollider
			{
				tipoDeMontura = (MapaDeRopa.RopaData.SkinCollider.TipoDeMontura)c.animationArmature,
				rendererAddress = c.address
			}).ToList<MapaDeRopa.RopaData.SkinCollider>();
			ropaData.layer = (RopaLayer)map.layer;
			ropaData.itemQuality = (Assets.Base.Plugins.Runtime.ItemQuality)map.itemQuality;
			ropaData.itemQuality = ((ropaData.itemQuality == Assets.Base.Plugins.Runtime.ItemQuality.None) ? Assets.Base.Plugins.Runtime.ItemQuality.Epic : ropaData.itemQuality);
			ropaData.posicion = (RopaPosicion)map.selfUndressingPosition;
			ropaData.cubreFlag = (RopaCubre)map.covers;
			ropaData.paraSexo = (Sexo)map.sex;
			ropaData.tipoDePrenda = (MapaDeRopa.TipoDePrenda)map.type;
			ropaData.interacciones = map.interactionsToSubClothingItems.Select(delegate(ClothingItemMap.Interaction sub)
			{
				sub.subClothingItemMap.TryInitID();
				MapaDeRopa.RopaData.Interacciones interacciones = new MapaDeRopa.RopaData.Interacciones();
				interacciones.id = (MapaDeRopa.Interaciones)sub.animation;
				interacciones.shapeName = sub.toSubClothingItemShapeName;
				interacciones.subPrendaIDString = sub.subClothingItemMap.id;
				interacciones.fixes = sub.corrections.Select((ClothingItemMap.Interaction.CorrectiveShapes c) => new MapaDeRopa.RopaData.Interacciones.FixShapes
				{
					inOut1x1Curve = c.inOut1x1Curve,
					shapeName = c.correctiveShapeName
				}).ToList<MapaDeRopa.RopaData.Interacciones.FixShapes>();
				return interacciones;
			}).ToList<MapaDeRopa.RopaData.Interacciones>();
			ropaData.probabilidadConfig = new MapaDeRopa.RopaData.ProbabilidadConfig
			{
				chance = map.chance
			};
			ropaData.skinConfig = new SkinConfig
			{
				canBeBakedIntoACollider = map.canCollideAgainstSemen,
				canTriangleSurfaceAttachment = map.canCollideAgainstSemen,
				clonarMateriales = false,
				copiaShapesDe = new List<string> { MapaSingleton<MapaSingletonDeMainSkins>.instance.body },
				forceNoNormalRecalculation = map.forceNoNormalRecalculation,
				recalculadores = Enum.GetValues(typeof(NormalRecalculadorBoneMap.Tipo)).Cast<NormalRecalculadorBoneMap.Tipo>().Where(delegate(NormalRecalculadorBoneMap.Tipo e)
				{
					switch (e)
					{
					case NormalRecalculadorBoneMap.Tipo.None:
						return false;
					case NormalRecalculadorBoneMap.Tipo.senoR:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.rightBreast);
					case NormalRecalculadorBoneMap.Tipo.senoL:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.leftBreast);
					case NormalRecalculadorBoneMap.Tipo.anusApertureR:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.rightAnusOpening);
					case NormalRecalculadorBoneMap.Tipo.anusApertureL:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.leftAnusOpening);
					case NormalRecalculadorBoneMap.Tipo.nalgaR:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.rightGluteus);
					case NormalRecalculadorBoneMap.Tipo.nalgaL:
						return map.normalRecalculators.HasFlag(ClothingItemMap.NormalRecalculators.leftGluteus);
					default:
						throw new ArgumentOutOfRangeException(e.ToString());
					}
				})
					.ToList<NormalRecalculadorBoneMap.Tipo>(),
				usarTessellation = map.gameConfigsTessellation,
				usarVertExmotion = true,
				usarVertExmotionVB = true
			};
			ropaData.shoesConfig = new MapaDeRopa.RopaData.ShoesConfig
			{
				puedeTenerMedias = map.canWearStockings,
				heelHeigth = map.heelConfig.heelHeigth / 100f,
				toeHeigth = map.heelConfig.toeHeigth / 100f,
				heelPoseWeigth = map.heelConfig.heelPoseWeigth,
				toePoseWeigth = map.heelConfig.toePoseWeigth
			};
			ropaData.senosConfig = new MapaDeRopa.RopaData.SenosConfig
			{
				distanciar = map.breastConfig.distanceBetweenModifier,
				modificadorDeFirmeza = map.breastConfig.siffnessModifier,
				modificadorDeLargoDePunta = map.breastConfig.nippleProjectionModifier,
				modificadorDeShapeDePezonV2 = map.breastConfig.nippleShapeModifier
			};
			ropaData.nalgasConfig = new MapaDeRopa.RopaData.NalgasConfig
			{
				modificadorDeFirmeza = map.assConfig.siffnessModifier
			};
			ropaData.vagConfig = new MapaDeRopa.RopaData.VagConfig
			{
				estrechuraHorizontal = map.vaginaConfig.shrinker,
				estrechuraVertical = map.vaginaConfig.labiaShrinker,
				modificadorDeDesgaste = map.vaginaConfig.wearModifier
			};
			ropaData.anusConfig = new MapaDeRopa.RopaData.AnusConfig
			{
				modificadorDeDesgaste = map.anusConfig.wearModifier
			};
			ropaDataCreados.Add(map.id, ropaData);
			ClothingModsLoader.ParceMats(map, matsDataCreados);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x000191EC File Offset: 0x000173EC
		private static void ParceMats(ClothingItemMap clothingMap, Dictionary<string, MaterialParaRopaData> matsDataCreados)
		{
			foreach (ClothingItemMap.MaterialData materialData in clothingMap.materialsPerIndex)
			{
				int materialIndex = materialData.materialIndex;
				foreach (MaterialMap materialMap in materialData.materials)
				{
					if (!materialMap.TryInitID() || string.IsNullOrWhiteSpace(materialMap.id))
					{
						Singleton<ModalWindow>.instance.AcumularErrores(string.Concat(new string[]
						{
							"material in index ",
							materialIndex.ToString(),
							" of ClothingItem id: ",
							clothingMap.id,
							", does not have a valid id"
						}), null);
						Debug.LogError(string.Concat(new string[]
						{
							"material in index ",
							materialIndex.ToString(),
							" of ClothingItem id: ",
							clothingMap.id,
							", does not have a valid id"
						}));
					}
					else
					{
						MaterialParaRopaData materialParaRopaData;
						if (!matsDataCreados.TryGetValue(materialMap.id, out materialParaRopaData))
						{
							materialParaRopaData = new MaterialParaRopaData();
							materialParaRopaData.organizacion = materialMap.organization;
							materialParaRopaData.categoria = materialMap.category;
							materialParaRopaData.nombreCompleto = materialMap.fullName;
							InGameName inGameName = materialMap.inGameNames.FirstOrDefault((InGameName n) => n.language == Language.en);
							materialParaRopaData.nombreCorto = ((inGameName != null) ? inGameName.name : null) ?? materialParaRopaData.nombreCompleto;
							materialParaRopaData.version = materialMap.version;
							materialParaRopaData.displayAutorsOnUsed = materialMap.displayAuthorsOnUsed;
							materialParaRopaData.autores = materialMap.authors.Select((Autor a) => new BaseGlobalUserData.Autor
							{
								name = a.name,
								URL = a.URL
							}).ToList<BaseGlobalUserData.Autor>();
							materialParaRopaData.address = materialMap.materialAddress;
							materialParaRopaData.diffusionProfile = materialMap.diffusionProfilesAddress;
							materialParaRopaData.puedeTenerCustomColor = materialMap.canBeCustomColor;
							materialParaRopaData.esTransparente = materialMap.canBeCustomOpacity;
							materialParaRopaData.itemQuality = (Assets.Base.Plugins.Runtime.ItemQuality)materialMap.itemQuality;
							materialParaRopaData.itemQuality = ((materialParaRopaData.itemQuality == Assets.Base.Plugins.Runtime.ItemQuality.None) ? Assets.Base.Plugins.Runtime.ItemQuality.Rare : materialParaRopaData.itemQuality);
							materialParaRopaData.chanceMaterial = materialMap.chance;
							materialParaRopaData.indexes.Clear();
							matsDataCreados.Add(materialMap.id, materialParaRopaData);
						}
						if (!materialParaRopaData.indexes.Contains(materialIndex))
						{
							materialParaRopaData.indexes.Add(materialIndex);
						}
						if (!string.IsNullOrWhiteSpace(clothingMap.id) && !materialParaRopaData.paraPrendasID.Contains(clothingMap.id))
						{
							materialParaRopaData.paraPrendasID.Add(clothingMap.id);
						}
					}
				}
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x000194E4 File Offset: 0x000176E4
		public static void DestroyModdingMap(ref MapaDeRopa map)
		{
			if (map == null)
			{
				return;
			}
			Object.Destroy(map);
			map = null;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x000194E4 File Offset: 0x000176E4
		public static void DestroyModdingMap(ref MapaDeMaterialesParaRopa map)
		{
			if (map == null)
			{
				return;
			}
			Object.Destroy(map);
			map = null;
		}

		// Token: 0x020000D8 RID: 216
		private class ResourceLocationComparer : IEqualityComparer<IResourceLocation>
		{
			// Token: 0x06000557 RID: 1367 RVA: 0x000194FB File Offset: 0x000176FB
			public bool Equals(IResourceLocation x, IResourceLocation y)
			{
				return x.InternalId == y.InternalId;
			}

			// Token: 0x06000558 RID: 1368 RVA: 0x0001950E File Offset: 0x0001770E
			public int GetHashCode(IResourceLocation obj)
			{
				return obj.InternalId.GetHashCode();
			}
		}
	}
}
