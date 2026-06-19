using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Oficinas;
using Assets.TValle.Pro.Entrevista.Runtime.Tiempo;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders
{
	// Token: 0x0200013A RID: 314
	public abstract class TValleActividadEnOfficeJustGeometryLoader<T_Actividad> : TValleActividadSavedWihtinTheSceneLoader<T_Actividad> where T_Actividad : TValleActividadSavedWithinTheScene
	{
		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x0003A2F0 File Offset: 0x000384F0
		public override bool noReciclarScenas
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000B07 RID: 2823
		protected abstract int officeLvl { get; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000B08 RID: 2824
		protected abstract EscenaDeRecepcionJuego mainSceneDeRecepcionJuego { get; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0003A2F3 File Offset: 0x000384F3
		protected override ActividadScenesLoader.SceneLoadOrder initialLoadOrder
		{
			get
			{
				return ActividadScenesLoader.SceneLoadOrder.Pre_Lighting_Post_Main;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0003A2F6 File Offset: 0x000384F6
		protected virtual EscenaDeRecepcionJuego[] preExtraScenes
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0003A2F9 File Offset: 0x000384F9
		protected virtual EscenaDeRecepcionJuego[] postExtraScenes
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0003A2FC File Offset: 0x000384FC
		private void LoadOfficeData()
		{
			if (this.m_officeScene == null)
			{
				this.m_officeScene = Singleton<OficinaManager>.instance.GetOficinaData(this.officeLvl);
			}
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0003A31C File Offset: 0x0003851C
		protected override IEnumerator LoadingInitialScences()
		{
			this.LoadOfficeData();
			yield break;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0003A32B File Offset: 0x0003852B
		protected override void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> preScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0003A330 File Offset: 0x00038530
		protected override void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			this.LoadOfficeData();
			onSceneLoadedCallback = null;
			if (this.preExtraScenes != null)
			{
				foreach (EscenaDeRecepcionJuego escenaDeRecepcionJuego in this.preExtraScenes)
				{
					BuildIndex.Add((int)escenaDeRecepcionJuego);
				}
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0003A36E File Offset: 0x0003856E
		protected override AssetReference GetMainSceneAssetReference()
		{
			return null;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0003A371 File Offset: 0x00038571
		protected override int GetMainSceneBuildIndex()
		{
			return (int)this.mainSceneDeRecepcionJuego;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003A379 File Offset: 0x00038579
		protected override void OnMainSceneLoaded(Scene scene, bool success)
		{
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0003A37B File Offset: 0x0003857B
		protected override AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
			return null;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0003A384 File Offset: 0x00038584
		protected override int GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			this.LoadOfficeData();
			onSceneLoadedCallback = null;
			ScenaTiempoDelDia tiempo = this.GetActividadTiempoDelDia();
			OficinaManager.LightingAndGeometricsScenes lightingAndGeometricsScenes = this.m_officeScene.lightingAndGeometricsScenes.FirstOrDefault((OficinaManager.LightingAndGeometricsScenes par) => par.tiempoDelDia == tiempo);
			EscenaDeRecepcionJuego? escenaDeRecepcionJuego = ((lightingAndGeometricsScenes != null) ? new EscenaDeRecepcionJuego?(lightingAndGeometricsScenes.lightingAndGeometrics) : null);
			if (escenaDeRecepcionJuego == null)
			{
				return -1;
			}
			return (int)escenaDeRecepcionJuego.Value;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0003A3F4 File Offset: 0x000385F4
		protected virtual ScenaTiempoDelDia GetActividadTiempoDelDia()
		{
			return Singleton<SMAGameController>.instance.GetTiempoDelDia();
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0003A400 File Offset: 0x00038600
		protected override void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> postScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0003A408 File Offset: 0x00038608
		protected override void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			this.LoadOfficeData();
			onSceneLoadedCallback = null;
			if (this.postExtraScenes != null)
			{
				foreach (EscenaDeRecepcionJuego escenaDeRecepcionJuego in this.postExtraScenes)
				{
					BuildIndex.Add((int)escenaDeRecepcionJuego);
				}
			}
		}

		// Token: 0x04000573 RID: 1395
		[SerializeReference]
		private OficinaManager.OficinaScenes m_officeScene;
	}
}
