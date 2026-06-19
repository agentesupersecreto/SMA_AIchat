using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005E RID: 94
	public class JobActivityLoader : CustomMonobehaviour, IActividadLoader
	{
		// Token: 0x06000346 RID: 838 RVA: 0x000119AB File Offset: 0x0000FBAB
		public void SetData(SMAJobMap JobMap, int Lvl, Guid Male, Guid Female, Action<ISMAJob> onJobInit)
		{
			if (this.m_JobActivity != null)
			{
				throw new InvalidOperationException();
			}
			this.m_jobMap = JobMap;
			this.m_male = Male;
			this.m_female = Female;
			this.m_onJobInit = onJobInit;
			this.m_Lvl = Lvl;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000347 RID: 839 RVA: 0x000119E6 File Offset: 0x0000FBE6
		public ISMAJob job
		{
			get
			{
				return this.m_job;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000348 RID: 840 RVA: 0x000119EE File Offset: 0x0000FBEE
		public SMAJobMap jobMap
		{
			get
			{
				return this.m_jobMap;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000349 RID: 841 RVA: 0x000119F6 File Offset: 0x0000FBF6
		public Guid male
		{
			get
			{
				return this.m_male;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600034A RID: 842 RVA: 0x000119FE File Offset: 0x0000FBFE
		public Guid female
		{
			get
			{
				return this.m_female;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00011A06 File Offset: 0x0000FC06
		public Scene mainScene
		{
			get
			{
				return this.m_job.mainScene;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00011A13 File Offset: 0x0000FC13
		public Scene lightingAndGeometricsScene
		{
			get
			{
				return this.m_job.lightingAndGeometricsScene;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00011A20 File Offset: 0x0000FC20
		public IReadOnlyList<Scene> currentLoadedScenes
		{
			get
			{
				if (!this.lightingAndGeometricsScene.isLoaded)
				{
					return new Scene[] { this.mainScene };
				}
				return new Scene[] { this.mainScene, this.lightingAndGeometricsScene };
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00011A71 File Offset: 0x0000FC71
		public IReadOnlyList<SceneInstance> currentLoadedSceneInstance
		{
			get
			{
				return Array.Empty<SceneInstance>();
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00011A78 File Offset: 0x0000FC78
		public bool noReciclarScenas
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00011A7B File Offset: 0x0000FC7B
		public IEnumerator DoLoad()
		{
			Type type = Type.GetType(this.jobMap.mainLogic);
			if (type == null)
			{
				Singleton<ModalWindow>.instance.AcumularErrores("Could not load custom modding script of type " + this.jobMap.mainLogic, null);
				Debug.LogError("No se pudo cargar script de tipo: " + this.jobMap.mainLogic);
				throw new InvalidOperationException("Could not load custom modding script of type " + this.jobMap.mainLogic);
			}
			if (!typeof(ISMAJob).IsAssignableFrom(type))
			{
				Debug.LogError("Type : " + type.Name + " no implementa " + typeof(ISMAJob).Name);
				throw new InvalidOperationException("Type : " + type.Name + " does not implement " + typeof(ISMAJob).Name);
			}
			this.m_job = base.gameObject.AddComponent(type) as ISMAJob;
			if (this.m_job == null)
			{
				throw new ArgumentNullException("mainLogic", "mainLogic null reference.");
			}
			this.m_job.Init(AsyncSingleton<JobsManager>.instance, this.jobMap, this.m_Lvl, this.male, this.female, Singleton<TiempoDeJuego>.instance.now);
			yield return this.m_job.Load();
			yield break;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00011A8C File Offset: 0x0000FC8C
		public Actividad ProduceActividad()
		{
			this.m_JobActivity = base.gameObject.GetComponentNotNull<JobActivity>();
			this.m_JobActivity.SetData(this.m_jobMap, this.m_job, this.m_male, this.m_female, this.m_onJobInit);
			this.m_JobActivity.OnLoadedByLoader();
			return this.m_JobActivity;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		public IEnumerator DoUnLoad(IActividadLoader next = null)
		{
			yield return this.m_job.UnLoad();
			yield break;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00011AF3 File Offset: 0x0000FCF3
		public IEnumerator DoUnLoadLighting()
		{
			throw new NotSupportedException("Job Scenes Must Completely unload");
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00011AFF File Offset: 0x0000FCFF
		public void GetLightingAndGeometricsData(out bool isAsset, out bool isTradicional, out AssetReference ifAssetReference, out int ifTradicionalIndex)
		{
			throw new NotSupportedException("Job Scenes Must Completely unload");
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00011B0B File Offset: 0x0000FD0B
		public IEnumerator GetOrLoadLightingAndGeometricsPath(Action<string> result)
		{
			throw new NotSupportedException("Job Scenes Must Completely unload");
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00011B1F File Offset: 0x0000FD1F
		GameObject IActividadLoader.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040001E0 RID: 480
		[ReadOnlyUI]
		[SerializeField]
		private SMAJobMap m_jobMap;

		// Token: 0x040001E1 RID: 481
		private ISMAJob m_job;

		// Token: 0x040001E2 RID: 482
		private Guid m_male;

		// Token: 0x040001E3 RID: 483
		private Guid m_female;

		// Token: 0x040001E4 RID: 484
		private int m_Lvl;

		// Token: 0x040001E5 RID: 485
		private Action<ISMAJob> m_onJobInit;

		// Token: 0x040001E6 RID: 486
		[ReadOnlyUI]
		[SerializeField]
		private JobActivity m_JobActivity;
	}
}
