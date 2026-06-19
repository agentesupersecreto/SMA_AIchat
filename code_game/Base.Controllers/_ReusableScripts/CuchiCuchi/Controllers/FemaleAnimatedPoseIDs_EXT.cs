using System;
using System.Linq;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x02000011 RID: 17
	public static class FemaleAnimatedPoseIDs_EXT
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000387E File Offset: 0x00001A7E
		public static bool EsRecostadaAnim(this FemaleAnimatedPoseIDs id)
		{
			return id != FemaleAnimatedPoseIDs.None && typeof(FemaleAnimatedRecostarseIDs).GetEnumValoresIntSet().Contains((int)id);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000389A File Offset: 0x00001A9A
		public static bool EsRecostadaGineAnim(this FemaleAnimatedPoseIDs id)
		{
			return id != FemaleAnimatedPoseIDs.None && (id == FemaleAnimatedPoseIDs.sentarse || id == FemaleAnimatedPoseIDs.acostarseEnGine);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000038B0 File Offset: 0x00001AB0
		public static TipoDePose GetTipoDePoseDeAnimPose(this FemaleAnimatedPoseIDs id)
		{
			switch (id)
			{
			case FemaleAnimatedPoseIDs.None:
				return TipoDePose.dePieRigida;
			case FemaleAnimatedPoseIDs.camillaOralSmall:
				return TipoDePose.doggy_ApoyoManosRodillas;
			case FemaleAnimatedPoseIDs.camillaOralBig:
				return TipoDePose.doggy_ApoyoManosRodillas;
			case FemaleAnimatedPoseIDs.camillaCow:
				return TipoDePose.dePieWallFrontPiernasAbiertas_ApoyoManosPies;
			case FemaleAnimatedPoseIDs.camillaCowInv:
				return TipoDePose.dePieWallBackDoblada_ApoyoManosPies;
			case FemaleAnimatedPoseIDs.sentarse:
				return TipoDePose.Anim_Sentada_ApoyoPelvis;
			case FemaleAnimatedPoseIDs.sentarseEnCamilla:
				return TipoDePose.Anim_Sentada_ApoyoPelvisManos;
			case FemaleAnimatedPoseIDs.acostarseEnCamilla:
				return TipoDePose.Anim_Acostada_ApoyoPelvisHombros;
			case FemaleAnimatedPoseIDs.acostarseBocaAbajoEnCamilla:
				return TipoDePose.Anim_AcostadaBocaAbajo_ApoyoPelvisCodosManos;
			case FemaleAnimatedPoseIDs.doggyEnCamilla:
				return TipoDePose.Anim_Doggy_ApoyoRodillasCodos;
			case FemaleAnimatedPoseIDs.acostarseEnGine:
				return TipoDePose.Anim_Gine;
			default:
				throw new ArgumentOutOfRangeException(id.ToString());
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000393C File Offset: 0x00001B3C
		public static bool PuedeEjecutarseGOTO(this FemaleAnimController controller)
		{
			FemaleAnimatedPoseIDs animatedPoseID = controller.animatedPoseID;
			return animatedPoseID == FemaleAnimatedPoseIDs.None || animatedPoseID == FemaleAnimatedPoseIDs.sentarse;
		}
	}
}
