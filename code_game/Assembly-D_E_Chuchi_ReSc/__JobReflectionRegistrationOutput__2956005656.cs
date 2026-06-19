using System;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

// Token: 0x0200056A RID: 1386
[DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2956005656
{
	// Token: 0x06002188 RID: 8584 RVA: 0x0007D3F4 File Offset: 0x0007B5F4
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForTransformExtensions.EarlyJobInit<TransformsData.GetCurrentWorldPosition>();
			IJobParallelForTransformExtensions.EarlyJobInit<TransformsData.SetCurrentWorldPosition>();
			IJobParallelForTransformExtensions.EarlyJobInit<ElasticFromOtherData.CalculateFromMatrixJob>();
			IJobExtensions.EarlyJobInit<SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob>();
			IJobParallelForTransformExtensions.EarlyJobInit<SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob>();
			IJobParallelForExtensions.EarlyJobInit<SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	// Token: 0x06002189 RID: 8585 RVA: 0x0007D444 File Offset: 0x0007B644
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		__JobReflectionRegistrationOutput__2956005656.CreateJobReflectionData();
	}
}
