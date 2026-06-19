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
	// Token: 0x0200013B RID: 315
	public abstract class TValleActividadEnOfficeLoader<T_Actividad> : TValleActividadSavedWihtinTheSceneLoader<T_Actividad> where T_Actividad : TValleActividadSavedWithinTheScene
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x0003A44E File Offset: 0x0003864E
		public override bool noReciclarScenas
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000B1A RID: 2842
		protected abstract int officeLvl { get; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000B1B RID: 2843
		protected abstract EscenaDeRecepcionJuego mainSceneDeRecepcionJuego { get; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0003A451 File Offset: 0x00038651
		protected override ActividadScenesLoader.SceneLoadOrder initialLoadOrder
		{
			get
			{
				return ActividadScenesLoader.SceneLoadOrder.Pre_Lighting_Post_Main;
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0003A454 File Offset: 0x00038654
		private void LoadOfficeData()
		{
			if (this.m_officeScene == null)
			{
				this.m_officeScene = Singleton<OficinaManager>.instance.GetOficinaData(this.officeLvl);
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0003A474 File Offset: 0x00038674
		protected override IEnumerator LoadingInitialScences()
		{
			this.LoadOfficeData();
			yield break;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0003A483 File Offset: 0x00038683
		protected override void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> preScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0003A488 File Offset: 0x00038688
		protected override void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			this.LoadOfficeData();
			onSceneLoadedCallback = null;
			if (this.m_officeScene.pre != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.pre);
			}
			if (this.m_officeScene.pre2 != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.pre2);
			}
			if (this.m_officeScene.pre3 != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.pre3);
			}
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0003A4FB File Offset: 0x000386FB
		protected override AssetReference GetMainSceneAssetReference()
		{
			return null;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0003A4FE File Offset: 0x000386FE
		protected override int GetMainSceneBuildIndex()
		{
			return (int)this.mainSceneDeRecepcionJuego;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0003A506 File Offset: 0x00038706
		protected override void OnMainSceneLoaded(Scene scene, bool success)
		{
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0003A508 File Offset: 0x00038708
		protected override AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
			return null;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0003A510 File Offset: 0x00038710
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

		// Token: 0x06000B26 RID: 2854 RVA: 0x0003A580 File Offset: 0x00038780
		protected virtual ScenaTiempoDelDia GetActividadTiempoDelDia()
		{
			return Singleton<SMAGameController>.instance.GetTiempoDelDia();
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0003A58C File Offset: 0x0003878C
		protected override void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> postScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0003A594 File Offset: 0x00038794
		protected override void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			this.LoadOfficeData();
			onSceneLoadedCallback = null;
			if (this.m_officeScene.post != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.post);
			}
			if (this.m_officeScene.post2 != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.post2);
			}
			if (this.m_officeScene.post3 != EscenaDeRecepcionJuego.None)
			{
				BuildIndex.Add((int)this.m_officeScene.post3);
			}
			BuildIndex.Add(3);
		}

		// Token: 0x04000574 RID: 1396
		[SerializeReference]
		private OficinaManager.OficinaScenes m_officeScene;
	}
}
