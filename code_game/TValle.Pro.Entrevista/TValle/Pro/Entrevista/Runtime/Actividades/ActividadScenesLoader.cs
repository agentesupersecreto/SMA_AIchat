using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Scenes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000113 RID: 275
	public abstract class ActividadScenesLoader : AplicableCustomMonobehaviour
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600098D RID: 2445
		protected abstract ActividadScenesLoader.SceneLoadOrder initialLoadOrder { get; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600098E RID: 2446
		protected abstract float phoneAndCameraScreenEmissionModifier { get; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x00038137 File Offset: 0x00036337
		public Scene mainScene
		{
			get
			{
				return this.m_mainScene;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x0003813F File Offset: 0x0003633F
		public Scene lightingAndGeometricsScene
		{
			get
			{
				return this.m_lightingAndGeometricsScene;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x00038147 File Offset: 0x00036347
		public IReadOnlyList<Scene> currentLoadedScenes
		{
			get
			{
				return this.m_loadedScenesTraditional;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0003814F File Offset: 0x0003634F
		public IReadOnlyList<SceneInstance> currentLoadedSceneInstance
		{
			get
			{
				return this.m_loadedScenes;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000993 RID: 2451
		protected abstract bool tryToKeepScenesAlive { get; }

		// Token: 0x06000994 RID: 2452 RVA: 0x00038157 File Offset: 0x00036357
		public IEnumerator DoUnLoadLighting()
		{
			int num = this.m_loadedScenesTraditional.IndexOf(this.m_lightingAndGeometricsScene);
			int LightingIndex = -1;
			for (int i = 0; i < this.m_loadedScenes.Count; i++)
			{
				if (this.m_loadedScenes[i].Scene == this.m_lightingAndGeometricsScene)
				{
					LightingIndex = i;
					break;
				}
			}
			bool flag = num > -1;
			bool esAsset = LightingIndex > -1;
			if (!flag && !esAsset)
			{
				Debug.LogError("Cant un load Lighting, it was not found", this);
				yield break;
			}
			if (flag && esAsset)
			{
				Debug.LogError("Cant un load Lighting, error known", this);
				yield break;
			}
			if (flag)
			{
				yield return this.UnLoadBuildIndexScene(this.m_lightingAndGeometricsScene);
			}
			if (esAsset)
			{
				yield return this.UnLoadAssetReferenceScene(this.m_loadedScenes[LightingIndex]);
			}
			this.m_lightingAndGeometricsScene = default(Scene);
			yield break;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00038166 File Offset: 0x00036366
		public IEnumerator DoUnLoad(IActividadLoader next = null)
		{
			int num;
			for (int i = this.m_loadedScenes.Count - 1; i >= 0; i = num - 1)
			{
				SceneInstance sceneInstance = this.m_loadedScenes[i];
				if (next == null || !next.currentLoadedSceneInstance.Contains(sceneInstance))
				{
					yield return this.UnLoadAssetReferenceScene(sceneInstance);
				}
				num = i;
			}
			this.m_loadedScenes.Clear();
			for (int i = this.m_loadedScenesTraditional.Count - 1; i >= 0; i = num - 1)
			{
				Scene scene = this.m_loadedScenesTraditional[i];
				if (next == null || !next.currentLoadedScenes.Contains(scene))
				{
					yield return this.UnLoadBuildIndexScene(scene);
				}
				num = i;
			}
			this.m_loadedScenesTraditional.Clear();
			yield break;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0003817C File Offset: 0x0003637C
		protected IEnumerator UnLoadAllScenes()
		{
			int num;
			for (int i = 0; i < this.m_loadedScenes.Count; i = num + 1)
			{
				SceneInstance sceneInstance = this.m_loadedScenes[i];
				yield return this.UnLoadAssetReferenceScene(sceneInstance);
				num = i;
			}
			this.m_loadedScenes.Clear();
			for (int i = 0; i < this.m_loadedScenesTraditional.Count; i = num + 1)
			{
				ActividadScenesLoader.<>c__DisplayClass21_0 CS$<>8__locals1 = new ActividadScenesLoader.<>c__DisplayClass21_0();
				Scene scene = this.m_loadedScenesTraditional[i];
				CS$<>8__locals1.isDone = false;
				AsyncOperation unloadOper = SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
				unloadOper.completed += delegate(AsyncOperation ap)
				{
					CS$<>8__locals1.isDone = true;
				};
				while (!CS$<>8__locals1.isDone && !unloadOper.isDone)
				{
					yield return null;
				}
				CS$<>8__locals1 = null;
				unloadOper = null;
				num = i;
			}
			this.m_loadedScenesTraditional.Clear();
			yield break;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0003818B File Offset: 0x0003638B
		public IEnumerator DoLoad()
		{
			yield return this.LoadingInitialScences();
			switch (this.initialLoadOrder)
			{
			case ActividadScenesLoader.SceneLoadOrder.Pre_Main_Lighting_Post:
				yield return this.LoadPre();
				yield return this.LoadMain();
				yield return this.LoadLighting();
				yield return this.LoadPost();
				break;
			case ActividadScenesLoader.SceneLoadOrder.Pre_Lighting_Main_Post:
				yield return this.LoadPre();
				yield return this.LoadLighting();
				yield return this.LoadMain();
				yield return this.LoadPost();
				break;
			case ActividadScenesLoader.SceneLoadOrder.Main_Pre_Lighting_Post:
				yield return this.LoadMain();
				yield return this.LoadPre();
				yield return this.LoadLighting();
				yield return this.LoadPost();
				break;
			case ActividadScenesLoader.SceneLoadOrder.Pre_Lighting_Post_Main:
				yield return this.LoadPre();
				yield return this.LoadLighting();
				yield return this.LoadPost();
				yield return this.LoadMain();
				break;
			default:
				throw new ArgumentOutOfRangeException(this.initialLoadOrder.ToString());
			}
			yield return null;
			yield return null;
			if (this.m_lightingAndGeometricsScene.isLoaded)
			{
				SceneManager.SetActiveScene(this.m_lightingAndGeometricsScene);
			}
			else
			{
				SceneManager.SetActiveScene(this.m_mainScene);
			}
			yield return null;
			yield break;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0003819A File Offset: 0x0003639A
		private IEnumerator LoadPre()
		{
			List<AssetReference> scenesToLoad = new List<AssetReference>();
			ActividadScenesLoader.OnSceneLoadedHandler onSceneAssetReferenceLoadedCallback;
			this.GetPreSceneAssetReferencesToLoadOnLoadJob(scenesToLoad, out onSceneAssetReferenceLoadedCallback);
			int num;
			for (int i = 0; i < scenesToLoad.Count; i = num + 1)
			{
				ActividadScenesLoader.<>c__DisplayClass23_0 CS$<>8__locals1 = new ActividadScenesLoader.<>c__DisplayClass23_0();
				AssetReference assetReference = scenesToLoad[i];
				CS$<>8__locals1.scene = default(Scene);
				yield return this.LoadAssetReferenceScene(assetReference, delegate(Scene s)
				{
					CS$<>8__locals1.scene = s;
				});
				ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler = onSceneAssetReferenceLoadedCallback;
				if (onSceneLoadedHandler != null)
				{
					onSceneLoadedHandler(CS$<>8__locals1.scene, CS$<>8__locals1.scene.isLoaded);
				}
				CS$<>8__locals1 = null;
				num = i;
			}
			onSceneAssetReferenceLoadedCallback = null;
			scenesToLoad = null;
			List<int> scenesBuildIndexToLoad = new List<int>();
			this.GetPreSceneBuildIndexToLoadOnLoadJob(scenesBuildIndexToLoad, out onSceneAssetReferenceLoadedCallback);
			for (int i = 0; i < scenesBuildIndexToLoad.Count; i = num + 1)
			{
				ActividadScenesLoader.<>c__DisplayClass23_1 CS$<>8__locals2 = new ActividadScenesLoader.<>c__DisplayClass23_1();
				int num2 = scenesBuildIndexToLoad[i];
				CS$<>8__locals2.scene = default(Scene);
				yield return this.LoadBuildIndexScene(num2, delegate(Scene s)
				{
					CS$<>8__locals2.scene = s;
				});
				ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler2 = onSceneAssetReferenceLoadedCallback;
				if (onSceneLoadedHandler2 != null)
				{
					onSceneLoadedHandler2(CS$<>8__locals2.scene, CS$<>8__locals2.scene.isLoaded);
				}
				CS$<>8__locals2 = null;
				num = i;
			}
			onSceneAssetReferenceLoadedCallback = null;
			scenesBuildIndexToLoad = null;
			yield break;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000381A9 File Offset: 0x000363A9
		private IEnumerator LoadMain()
		{
			Scene scene = default(Scene);
			AssetReference mainSceneAssetReference = this.GetMainSceneAssetReference();
			int mainSceneBuildIndex = this.GetMainSceneBuildIndex();
			if (mainSceneAssetReference != null && mainSceneBuildIndex >= 0)
			{
				throw new InvalidOperationException("Cant Have Two Main Scenes");
			}
			if (mainSceneAssetReference != null)
			{
				yield return this.LoadAssetReferenceScene(mainSceneAssetReference, delegate(Scene s)
				{
					scene = s;
				});
			}
			else
			{
				if (mainSceneBuildIndex < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				yield return this.LoadBuildIndexScene(mainSceneBuildIndex, delegate(Scene s)
				{
					scene = s;
				});
			}
			if (scene.isLoaded)
			{
				this.m_mainScene = scene;
			}
			this.OnMainSceneLoaded(scene, scene.isLoaded);
			yield break;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x000381B8 File Offset: 0x000363B8
		protected void GetLightingAndGeometricsScene(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback, out bool isAsset, out bool isTradicional, out AssetReference ifAssetReference, out int ifTradicionalIndex)
		{
			ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler;
			ifAssetReference = this.GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out onSceneLoadedHandler);
			ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler2;
			ifTradicionalIndex = this.GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out onSceneLoadedHandler2);
			isAsset = ifAssetReference != null;
			isTradicional = ifTradicionalIndex >= 0;
			if (isAsset & isTradicional)
			{
				throw new InvalidOperationException("Cant Have Two lighting And Geometrics Scenes at the same time");
			}
			if (!isAsset && !isTradicional)
			{
				throw new InvalidOperationException("there is no Lighting scene to load");
			}
			onSceneLoadedCallback = null;
			if (onSceneLoadedHandler != null)
			{
				onSceneLoadedCallback = (ActividadScenesLoader.OnSceneLoadedHandler)Delegate.Combine(onSceneLoadedCallback, onSceneLoadedHandler);
			}
			if (onSceneLoadedHandler2 != null)
			{
				onSceneLoadedCallback = (ActividadScenesLoader.OnSceneLoadedHandler)Delegate.Combine(onSceneLoadedCallback, onSceneLoadedHandler2);
			}
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0003823C File Offset: 0x0003643C
		public void GetLightingAndGeometricsData(out bool isAsset, out bool isTradicional, out AssetReference ifAssetReference, out int ifTradicionalIndex)
		{
			ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler;
			this.GetLightingAndGeometricsScene(out onSceneLoadedHandler, out isAsset, out isTradicional, out ifAssetReference, out ifTradicionalIndex);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00038256 File Offset: 0x00036456
		public IEnumerator GetOrLoadLightingAndGeometricsPath(Action<string> result)
		{
			if (this.m_lightingAndGeometricsScene.IsValid() && this.m_lightingAndGeometricsScene.isLoaded)
			{
				result(this.m_lightingAndGeometricsScene.path);
				yield break;
			}
			bool flag;
			bool flag2;
			AssetReference assetReference;
			int num;
			this.GetLightingAndGeometricsData(out flag, out flag2, out assetReference, out num);
			if (flag)
			{
				AsyncOperationHandle<IList<IResourceLocation>> loc = Addressables.LoadResourceLocationsAsync(assetReference, null);
				yield return loc;
				string internalId = loc.Result[0].InternalId;
				result(internalId);
				yield break;
			}
			if (flag2)
			{
				string scenePathByBuildIndex = SceneUtility.GetScenePathByBuildIndex(num);
				result(scenePathByBuildIndex);
				yield break;
			}
			yield break;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0003826C File Offset: 0x0003646C
		private IEnumerator LoadLighting()
		{
			ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback;
			bool flag;
			bool flag2;
			AssetReference assetReference;
			int num;
			this.GetLightingAndGeometricsScene(out onSceneLoadedCallback, out flag, out flag2, out assetReference, out num);
			Scene scene = default(Scene);
			if (flag)
			{
				yield return this.LoadAssetReferenceScene(assetReference, delegate(Scene s)
				{
					scene = s;
				});
			}
			else
			{
				if (!flag2)
				{
					yield break;
				}
				yield return this.LoadBuildIndexScene(num, delegate(Scene s)
				{
					scene = s;
				});
			}
			if (scene.isLoaded)
			{
				this.m_lightingAndGeometricsScene = scene;
			}
			ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler = onSceneLoadedCallback;
			if (onSceneLoadedHandler != null)
			{
				onSceneLoadedHandler(scene, scene.isLoaded);
			}
			yield break;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0003827B File Offset: 0x0003647B
		private IEnumerator LoadPost()
		{
			List<AssetReference> scenesToLoad = new List<AssetReference>();
			ActividadScenesLoader.OnSceneLoadedHandler onSceneAssetReferenceLoadedCallback;
			this.GetPostSceneAssetReferencesToLoadOnLoadJob(scenesToLoad, out onSceneAssetReferenceLoadedCallback);
			int num;
			for (int i = 0; i < scenesToLoad.Count; i = num + 1)
			{
				ActividadScenesLoader.<>c__DisplayClass29_0 CS$<>8__locals1 = new ActividadScenesLoader.<>c__DisplayClass29_0();
				AssetReference assetReference = scenesToLoad[i];
				CS$<>8__locals1.scene = default(Scene);
				yield return this.LoadAssetReferenceScene(assetReference, delegate(Scene s)
				{
					CS$<>8__locals1.scene = s;
				});
				ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler = onSceneAssetReferenceLoadedCallback;
				if (onSceneLoadedHandler != null)
				{
					onSceneLoadedHandler(CS$<>8__locals1.scene, CS$<>8__locals1.scene.isLoaded);
				}
				CS$<>8__locals1 = null;
				num = i;
			}
			onSceneAssetReferenceLoadedCallback = null;
			scenesToLoad = null;
			List<int> scenesBuildIndexToLoad = new List<int>();
			this.GetPostSceneBuildIndexToLoadOnLoadJob(scenesBuildIndexToLoad, out onSceneAssetReferenceLoadedCallback);
			for (int i = 0; i < scenesBuildIndexToLoad.Count; i = num + 1)
			{
				ActividadScenesLoader.<>c__DisplayClass29_1 CS$<>8__locals2 = new ActividadScenesLoader.<>c__DisplayClass29_1();
				int num2 = scenesBuildIndexToLoad[i];
				CS$<>8__locals2.scene = default(Scene);
				yield return this.LoadBuildIndexScene(num2, delegate(Scene s)
				{
					CS$<>8__locals2.scene = s;
				});
				ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedHandler2 = onSceneAssetReferenceLoadedCallback;
				if (onSceneLoadedHandler2 != null)
				{
					onSceneLoadedHandler2(CS$<>8__locals2.scene, CS$<>8__locals2.scene.isLoaded);
				}
				CS$<>8__locals2 = null;
				num = i;
			}
			onSceneAssetReferenceLoadedCallback = null;
			scenesBuildIndexToLoad = null;
			yield break;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0003828A File Offset: 0x0003648A
		protected IEnumerator LoadBuildIndexScene(int buildIndex, Action<Scene> result)
		{
			Scene scene = SceneManager.GetSceneByBuildIndex(buildIndex);
			if (scene.isLoaded)
			{
				if (!this.m_loadedScenesTraditional.Contains(scene))
				{
					this.m_loadedScenesTraditional.Add(scene);
				}
				Singleton<ActividadesManager>.instance.AddAdditinalLogicToScene(scene, this.phoneAndCameraScreenEmissionModifier);
				if (result != null)
				{
					result(scene);
				}
				yield break;
			}
			SceneLoader.Pedido pedido = SceneLoader.Pedido.@default;
			pedido.scene.index = buildIndex;
			pedido.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(pedido);
			while (!pedido.finalizado)
			{
				yield return null;
			}
			scene = SceneManager.GetSceneByBuildIndex(buildIndex);
			if (scene.isLoaded)
			{
				this.m_loadedScenesTraditional.Add(scene);
				Singleton<ActividadesManager>.instance.AddAdditinalLogicToScene(scene, this.phoneAndCameraScreenEmissionModifier);
			}
			if (result != null)
			{
				result(scene);
			}
			yield break;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000382A7 File Offset: 0x000364A7
		protected IEnumerator UnLoadBuildIndexScene(Scene scene)
		{
			if (!scene.isLoaded)
			{
				this.m_loadedScenesTraditional.Remove(scene);
				yield break;
			}
			SceneLoader.Pedido pedido = SceneLoader.Pedido.@default;
			pedido.scene.index = scene.buildIndex;
			pedido.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(pedido);
			while (!pedido.finalizado)
			{
				yield return null;
			}
			this.m_loadedScenesTraditional.Remove(scene);
			yield break;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000382BD File Offset: 0x000364BD
		protected IEnumerator LoadAssetReferenceScene(AssetReference sceneAsset, Action<Scene> result)
		{
			AsyncOperationHandle<IList<IResourceLocation>> loc = Addressables.LoadResourceLocationsAsync(sceneAsset, null);
			yield return loc;
			Scene loadedScene = SceneManager.GetSceneByPath(loc.Result[0].InternalId);
			if (loadedScene.isLoaded)
			{
				if (this.m_loadedScenes.FirstOrDefault((SceneInstance si) => si.Scene == loadedScene).Scene.handle == 0)
				{
					this.m_loadedScenesTraditional.Add(loadedScene);
				}
				Singleton<ActividadesManager>.instance.AddAdditinalLogicToScene(loadedScene, this.phoneAndCameraScreenEmissionModifier);
				if (result != null)
				{
					result(loadedScene);
				}
				yield break;
			}
			if (this.tryToKeepScenesAlive)
			{
				yield return Singleton<SceneLoader>.instance.PreloadScene(sceneAsset);
			}
			AsyncOperationHandle<SceneInstance> oper = Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive, true, 100);
			yield return oper;
			if (oper.Result.Scene.isLoaded)
			{
				this.m_loadedScenes.Add(oper.Result);
				Singleton<ActividadesManager>.instance.AddAdditinalLogicToScene(oper.Result.Scene, this.phoneAndCameraScreenEmissionModifier);
			}
			if (result != null)
			{
				result(oper.Result.Scene);
			}
			yield break;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000382DA File Offset: 0x000364DA
		protected IEnumerator UnLoadAssetReferenceScene(SceneInstance sceneInstance)
		{
			if (!sceneInstance.Scene.isLoaded)
			{
				this.m_loadedScenes.Remove(sceneInstance);
				this.m_loadedScenesTraditional.Remove(sceneInstance.Scene);
				yield break;
			}
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.UnloadSceneAsync(sceneInstance, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects, true);
			yield return asyncOperationHandle;
			this.m_loadedScenes.Remove(sceneInstance);
			this.m_loadedScenesTraditional.Remove(sceneInstance.Scene);
			yield break;
		}

		// Token: 0x060009A3 RID: 2467
		protected abstract IEnumerator LoadingInitialScences();

		// Token: 0x060009A4 RID: 2468
		protected abstract void OnMainSceneLoaded(Scene scene, bool success);

		// Token: 0x060009A5 RID: 2469
		protected abstract AssetReference GetMainSceneAssetReference();

		// Token: 0x060009A6 RID: 2470
		protected abstract int GetMainSceneBuildIndex();

		// Token: 0x060009A7 RID: 2471
		protected abstract AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x060009A8 RID: 2472
		protected abstract int GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x060009A9 RID: 2473
		protected abstract void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> postScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x060009AA RID: 2474
		protected abstract void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x060009AB RID: 2475
		protected abstract void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> preScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x060009AC RID: 2476
		protected abstract void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback);

		// Token: 0x0400053E RID: 1342
		private Scene m_mainScene;

		// Token: 0x0400053F RID: 1343
		private Scene m_lightingAndGeometricsScene;

		// Token: 0x04000540 RID: 1344
		private List<SceneInstance> m_loadedScenes = new List<SceneInstance>();

		// Token: 0x04000541 RID: 1345
		private List<Scene> m_loadedScenesTraditional = new List<Scene>();

		// Token: 0x02000290 RID: 656
		// (Invoke) Token: 0x060011AA RID: 4522
		protected delegate void OnSceneLoadedHandler(Scene scene, bool success);

		// Token: 0x02000291 RID: 657
		public enum SceneLoadOrder
		{
			// Token: 0x04000BF6 RID: 3062
			Pre_Main_Lighting_Post,
			// Token: 0x04000BF7 RID: 3063
			Pre_Lighting_Main_Post,
			// Token: 0x04000BF8 RID: 3064
			Main_Pre_Lighting_Post,
			// Token: 0x04000BF9 RID: 3065
			Pre_Lighting_Post_Main
		}
	}
}
