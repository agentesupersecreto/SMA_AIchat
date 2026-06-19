using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets.Base.Controllers.Runtime
{
	// Token: 0x02000004 RID: 4
	public interface IRecostableConFemaleAnimPose : IRecostable
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600001D RID: 29
		// (remove) Token: 0x0600001E RID: 30
		event IRecostableConFemaleAnimPose.ValidadorHandler getNextPostValidator;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600001F RID: 31
		// (remove) Token: 0x06000020 RID: 32
		event IRecostableConFemaleAnimPose.ValidadorHandler getPreviusPostValidator;

		// Token: 0x06000021 RID: 33
		void GetNext(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> next);

		// Token: 0x06000022 RID: 34
		void GetPrevius(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> previus);

		// Token: 0x0200001F RID: 31
		// (Invoke) Token: 0x060000DE RID: 222
		public delegate void ValidadorHandler(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> result);
	}
}
