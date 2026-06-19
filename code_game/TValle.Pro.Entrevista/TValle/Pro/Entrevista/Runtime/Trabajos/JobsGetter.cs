using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005A RID: 90
	public sealed class JobsGetter : AsyncSingleton<JobsGetter>
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x000108D7 File Offset: 0x0000EAD7
		public IReadOnlyDictionary<string, Texture> portraitDeJobs
		{
			get
			{
				return this.m_portraitDeJobsPreloaded;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x000108DF File Offset: 0x0000EADF
		public IReadOnlyDictionary<string, SMAJobMap> jobsDisponibles
		{
			get
			{
				return this.m_jobsDisponible;
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000108E7 File Offset: 0x0000EAE7
		protected override void InitSyncData(bool esEditorTime)
		{
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000108E9 File Offset: 0x0000EAE9
		protected override IEnumerator PreInitData()
		{
			yield return this.LoadMaps(this.m_mapas);
			bool loadMods = this.m_loadMods;
			yield break;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000108F8 File Offset: 0x0000EAF8
		private IEnumerator LoadMaps(IReadOnlyList<SMAJobMap> mapas)
		{
			foreach (SMAJobMap mapa in mapas)
			{
				if (!mapa.TryInitID())
				{
					Debug.LogError("Map Id was invalid, Asset Instance ID: " + mapa.GetInstanceID().ToString(), mapa);
				}
				else if (!mapa.IsSMAJobMapValid())
				{
					Debug.LogError("Map was missing Assets, Map ID: " + mapa.displayId, mapa);
				}
				else if (this.m_jobsDisponible.ContainsKey(mapa.id))
				{
					Debug.LogError("Map id duplicated, Map ID: " + mapa.displayId, mapa);
				}
				else
				{
					this.m_jobsDisponible.Add(mapa.id, mapa);
					AsyncOperationHandle<Texture> operrationPortraitLoading = Addressables.LoadAssetAsync<Texture>(mapa.portrait);
					if (!operrationPortraitLoading.IsDone)
					{
						yield return operrationPortraitLoading;
					}
					if (operrationPortraitLoading.Result == null)
					{
						Debug.LogError("cant load portrait for job : " + mapa.displayId, mapa);
					}
					else
					{
						this.m_portraitDeJobsPreloaded.Add(mapa.id, operrationPortraitLoading.Result);
					}
					operrationPortraitLoading = default(AsyncOperationHandle<Texture>);
					mapa = null;
				}
			}
			IEnumerator<SMAJobMap> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040001C4 RID: 452
		[SerializeField]
		private List<SMAJobMap> m_mapas = new List<SMAJobMap>();

		// Token: 0x040001C5 RID: 453
		[SerializeField]
		[ReadOnlyUI]
		private List<SMAJobMap> m_moddingMapas = new List<SMAJobMap>();

		// Token: 0x040001C6 RID: 454
		[SerializeField]
		private bool m_loadMods = true;

		// Token: 0x040001C7 RID: 455
		private Dictionary<string, SMAJobMap> m_jobsDisponible = new Dictionary<string, SMAJobMap>();

		// Token: 0x040001C8 RID: 456
		[SerializeField]
		private StringKeyTextureValueDictionary m_portraitDeJobsPreloaded = new StringKeyTextureValueDictionary();
	}
}
