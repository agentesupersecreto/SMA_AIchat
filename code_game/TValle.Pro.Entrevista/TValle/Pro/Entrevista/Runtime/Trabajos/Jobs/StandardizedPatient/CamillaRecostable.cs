using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime.Anims;
using Assets.Base.Controllers.Runtime;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000067 RID: 103
	public class CamillaRecostable : SillaGenerica, IRecostableConFemaleAnimPose, IRecostable
	{
		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060004B1 RID: 1201 RVA: 0x0001BEE8 File Offset: 0x0001A0E8
		// (remove) Token: 0x060004B2 RID: 1202 RVA: 0x0001BF20 File Offset: 0x0001A120
		public event IRecostableConFemaleAnimPose.ValidadorHandler getNextPostValidator;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060004B3 RID: 1203 RVA: 0x0001BF58 File Offset: 0x0001A158
		// (remove) Token: 0x060004B4 RID: 1204 RVA: 0x0001BF90 File Offset: 0x0001A190
		public event IRecostableConFemaleAnimPose.ValidadorHandler getPreviusPostValidator;

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001BFC8 File Offset: 0x0001A1C8
		public void GetNext(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> next)
		{
			try
			{
				if (!current.EsRecostadaAnim())
				{
					next.Add(FemaleAnimatedRecostarseIDs.sentarseEnCamilla);
				}
				else
				{
					switch (current)
					{
					case FemaleAnimatedPoseIDs.sentarse:
					case FemaleAnimatedPoseIDs.sentarseEnCamilla:
						next.Add(FemaleAnimatedRecostarseIDs.acostarseEnCamilla);
						break;
					case FemaleAnimatedPoseIDs.acostarseEnCamilla:
						next.Add(FemaleAnimatedRecostarseIDs.acostarseBocaAbajoEnCamilla);
						break;
					case FemaleAnimatedPoseIDs.acostarseBocaAbajoEnCamilla:
						next.Add(FemaleAnimatedRecostarseIDs.doggyEnCamilla);
						break;
					case FemaleAnimatedPoseIDs.doggyEnCamilla:
						break;
					default:
						throw new ArgumentOutOfRangeException(current.ToString());
					}
				}
			}
			finally
			{
				IRecostableConFemaleAnimPose.ValidadorHandler validadorHandler = this.getNextPostValidator;
				if (validadorHandler != null)
				{
					validadorHandler(current, ref next);
				}
			}
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001C05C File Offset: 0x0001A25C
		public void GetPrevius(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> previus)
		{
			try
			{
				if (current.EsRecostadaAnim())
				{
					if (current.EsRecostadaAnim())
					{
						previus.Add(FemaleAnimatedRecostarseIDs.None);
					}
					switch (current)
					{
					case FemaleAnimatedPoseIDs.sentarse:
					case FemaleAnimatedPoseIDs.sentarseEnCamilla:
						break;
					case FemaleAnimatedPoseIDs.acostarseEnCamilla:
						previus.Add(FemaleAnimatedRecostarseIDs.sentarseEnCamilla);
						break;
					case FemaleAnimatedPoseIDs.acostarseBocaAbajoEnCamilla:
						previus.Add(FemaleAnimatedRecostarseIDs.acostarseEnCamilla);
						break;
					case FemaleAnimatedPoseIDs.doggyEnCamilla:
						previus.Add(FemaleAnimatedRecostarseIDs.acostarseBocaAbajoEnCamilla);
						break;
					default:
						throw new ArgumentOutOfRangeException(current.ToString());
					}
				}
			}
			finally
			{
				IRecostableConFemaleAnimPose.ValidadorHandler validadorHandler = this.getPreviusPostValidator;
				if (validadorHandler != null)
				{
					validadorHandler(current, ref previus);
				}
			}
		}
	}
}
