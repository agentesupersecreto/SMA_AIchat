using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000119 RID: 281
	public interface IActividadLoader
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060009ED RID: 2541
		GameObject gameObject { get; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060009EE RID: 2542
		Scene mainScene { get; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060009EF RID: 2543
		Scene lightingAndGeometricsScene { get; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060009F0 RID: 2544
		IReadOnlyList<Scene> currentLoadedScenes { get; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060009F1 RID: 2545
		IReadOnlyList<SceneInstance> currentLoadedSceneInstance { get; }

		// Token: 0x060009F2 RID: 2546
		Actividad ProduceActividad();

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060009F3 RID: 2547
		bool noReciclarScenas { get; }

		// Token: 0x060009F4 RID: 2548
		IEnumerator DoLoad();

		// Token: 0x060009F5 RID: 2549
		IEnumerator DoUnLoad(IActividadLoader next = null);

		// Token: 0x060009F6 RID: 2550
		IEnumerator DoUnLoadLighting();

		// Token: 0x060009F7 RID: 2551
		void GetLightingAndGeometricsData(out bool isAsset, out bool isTradicional, out AssetReference ifAssetReference, out int ifTradicionalIndex);

		// Token: 0x060009F8 RID: 2552
		IEnumerator GetOrLoadLightingAndGeometricsPath(Action<string> result);
	}
}
