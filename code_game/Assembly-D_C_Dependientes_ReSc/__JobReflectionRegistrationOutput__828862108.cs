using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen;
using Unity.Jobs;
using UnityEngine;

// Token: 0x020003AD RID: 941
[DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__828862108
{
	// Token: 0x060017FF RID: 6143 RVA: 0x00070950 File Offset: 0x0006EB50
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<SemenSkinController.JobAddPerSparcedShapeDeltasData>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobAddPerBoneWeightData>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobAddPerTriangleData>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobAddPerVertexData>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobCalculeSemenSkinVertexShaping>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobCalculeSemenSkinVertexAttributes>();
			IJobExtensions.EarlyJobInit<SemenSkinController.JobCalculeSemenSkinVertexSkinning>();
			IJobParallelForExtensions.EarlyJobInit<SemenSkinController.JobCalculeParticleBonesTransforms>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	// Token: 0x06001800 RID: 6144 RVA: 0x000709A8 File Offset: 0x0006EBA8
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		__JobReflectionRegistrationOutput__828862108.CreateJobReflectionData();
	}
}
