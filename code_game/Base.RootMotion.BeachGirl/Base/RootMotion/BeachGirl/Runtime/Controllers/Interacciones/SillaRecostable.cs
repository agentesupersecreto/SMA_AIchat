using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime.Anims;
using Assets.Base.Controllers.Runtime;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x0200003C RID: 60
	public class SillaRecostable : SillaGenerica, IRecostableConFemaleAnimPose, IRecostable
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000292 RID: 658 RVA: 0x0000D9E4 File Offset: 0x0000BBE4
		// (remove) Token: 0x06000293 RID: 659 RVA: 0x0000DA1C File Offset: 0x0000BC1C
		public event IRecostableConFemaleAnimPose.ValidadorHandler getNextPostValidator;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000294 RID: 660 RVA: 0x0000DA54 File Offset: 0x0000BC54
		// (remove) Token: 0x06000295 RID: 661 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		public event IRecostableConFemaleAnimPose.ValidadorHandler getPreviusPostValidator;

		// Token: 0x06000296 RID: 662 RVA: 0x0000DAC1 File Offset: 0x0000BCC1
		public void GetNext(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> next)
		{
			if (current != FemaleAnimatedPoseIDs.sentarse)
			{
				next.Add(FemaleAnimatedRecostarseIDs.sentarse);
			}
			IRecostableConFemaleAnimPose.ValidadorHandler validadorHandler = this.getNextPostValidator;
			if (validadorHandler == null)
			{
				return;
			}
			validadorHandler(current, ref next);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000DAE1 File Offset: 0x0000BCE1
		public void GetPrevius(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> previus)
		{
			if (current.EsRecostadaAnim())
			{
				previus.Add(FemaleAnimatedRecostarseIDs.None);
			}
			IRecostableConFemaleAnimPose.ValidadorHandler validadorHandler = this.getPreviusPostValidator;
			if (validadorHandler == null)
			{
				return;
			}
			validadorHandler(current, ref previus);
		}
	}
}
