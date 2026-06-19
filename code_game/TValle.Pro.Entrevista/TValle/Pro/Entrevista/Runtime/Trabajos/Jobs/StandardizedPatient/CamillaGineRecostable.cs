using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime.Anims;
using Assets.Base.Controllers.Runtime;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000064 RID: 100
	public class CamillaGineRecostable : SillaGenerica, IRecostableConFemaleAnimPose, IRecostable
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0001BB70 File Offset: 0x00019D70
		public override Vector3 dinamicOffset
		{
			get
			{
				return new Vector3(0f, this.alturaOffset, 0f);
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060004A4 RID: 1188 RVA: 0x0001BB88 File Offset: 0x00019D88
		// (remove) Token: 0x060004A5 RID: 1189 RVA: 0x0001BBC0 File Offset: 0x00019DC0
		public event IRecostableConFemaleAnimPose.ValidadorHandler getNextPostValidator;

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060004A6 RID: 1190 RVA: 0x0001BBF8 File Offset: 0x00019DF8
		// (remove) Token: 0x060004A7 RID: 1191 RVA: 0x0001BC30 File Offset: 0x00019E30
		public event IRecostableConFemaleAnimPose.ValidadorHandler getPreviusPostValidator;

		// Token: 0x060004A8 RID: 1192 RVA: 0x0001BC68 File Offset: 0x00019E68
		public void GetNext(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> next)
		{
			try
			{
				if (!current.EsRecostadaGineAnim())
				{
					next.Add(FemaleAnimatedRecostarseIDs.sentarse);
				}
				else if (current != FemaleAnimatedPoseIDs.sentarse)
				{
					if (current != FemaleAnimatedPoseIDs.acostarseEnGine)
					{
						throw new ArgumentOutOfRangeException(current.ToString());
					}
				}
				else
				{
					next.Add(FemaleAnimatedRecostarseIDs.acostarseEnGine);
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

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001BCD4 File Offset: 0x00019ED4
		public void GetPrevius(FemaleAnimatedPoseIDs current, ref List<FemaleAnimatedRecostarseIDs> previus)
		{
			try
			{
				if (current.EsRecostadaGineAnim())
				{
					if (current.EsRecostadaGineAnim())
					{
						previus.Add(FemaleAnimatedRecostarseIDs.None);
					}
					if (current != FemaleAnimatedPoseIDs.sentarse)
					{
						if (current != FemaleAnimatedPoseIDs.acostarseEnGine)
						{
							throw new ArgumentOutOfRangeException(current.ToString());
						}
						previus.Add(FemaleAnimatedRecostarseIDs.sentarse);
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

		// Token: 0x04000290 RID: 656
		[Header("Gine")]
		public float alturaOffset;
	}
}
