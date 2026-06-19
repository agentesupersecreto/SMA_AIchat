using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.HighHeelScripts
{
	// Token: 0x0200002D RID: 45
	public class FemaleCharacterHighHeelable : CustomMonobehaviour, ICharacterHighHeelable
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000199 RID: 409 RVA: 0x000095D8 File Offset: 0x000077D8
		private FemaleHighHeelSystem m_FemaleHighHeelSystem
		{
			get
			{
				return this.m_IFemaleFullBodyBipedIKs.ObtenerCurrentFullBodyBipedIKDeLayer(0).GetComponent<FemaleHighHeelSystem>();
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000095EB File Offset: 0x000077EB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IFemaleFullBodyBipedIKs = this.GetComponentEnRoot(false);
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00009600 File Offset: 0x00007800
		public float currentHeelLocalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentHeelLocalHeight;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000960D File Offset: 0x0000780D
		public float currentToeLocalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentToeLocalHeight;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000961A File Offset: 0x0000781A
		public float currentHeelWorldHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentHeelWorldHeight;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00009627 File Offset: 0x00007827
		public float currentToeWorldHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentToeWorldHeight;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00009634 File Offset: 0x00007834
		public float currentRealHeelLocalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealHeelLocalHeight;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00009641 File Offset: 0x00007841
		public float currentRealToeLocalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealToeLocalHeight;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000964E File Offset: 0x0000784E
		public float currentHeelWorldTotalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentHeelWorldTotalHeight;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000965B File Offset: 0x0000785B
		public float currentToeWorldTotalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentToeWorldTotalHeight;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00009668 File Offset: 0x00007868
		public float currentRealHeelWorldHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealHeelWorldHeight;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00009675 File Offset: 0x00007875
		public float currentRealToeWorldHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealToeWorldHeight;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00009682 File Offset: 0x00007882
		public float currentRealHeelWorldTotalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealHeelWorldTotalHeight;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000968F File Offset: 0x0000788F
		public float currentRealToeWorldTotalHeight
		{
			get
			{
				return this.m_FemaleHighHeelSystem.currentRealToeWorldTotalHeight;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000969C File Offset: 0x0000789C
		public ModificableDeFloat grounderIkWeigthModificable
		{
			get
			{
				return this.m_FemaleHighHeelSystem.grounderIkWeigthModificable;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000096A9 File Offset: 0x000078A9
		public Vector3 GetDownDirectionFromHeelsL()
		{
			return this.m_FemaleHighHeelSystem.GetDownDirectionFromHeelsL();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000096B6 File Offset: 0x000078B6
		public Vector3 GetDownDirectionFromHeelsR()
		{
			return this.m_FemaleHighHeelSystem.GetDownDirectionFromHeelsR();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000096C3 File Offset: 0x000078C3
		public Vector3 GetDownDirectionFromToesL()
		{
			return this.m_FemaleHighHeelSystem.GetDownDirectionFromToesL();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000096D0 File Offset: 0x000078D0
		public Vector3 GetDownDirectionFromToesR()
		{
			return this.m_FemaleHighHeelSystem.GetDownDirectionFromToesR();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000096DD File Offset: 0x000078DD
		public Vector3 GetVirtualDownDirectionFromHeelL()
		{
			return this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromHeelL();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000096EA File Offset: 0x000078EA
		public Vector3 GetVirtualDownDirectionFromHeelR()
		{
			return this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromHeelR();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000096F7 File Offset: 0x000078F7
		public Vector3 GetVirtualDownDirectionFromToeL()
		{
			return this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromToeL();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00009704 File Offset: 0x00007904
		public Vector3 GetVirtualDownDirectionFromToeR()
		{
			return this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromToeR();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00009714 File Offset: 0x00007914
		public void ResetHeight()
		{
			for (int i = 0; i < this.m_IFemaleFullBodyBipedIKs.primarios.Count; i++)
			{
				this.m_IFemaleFullBodyBipedIKs.primarios[i].GetComponent<FemaleHighHeelSystem>().ResetHeight();
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00009758 File Offset: 0x00007958
		public void SetHeight(float toeLocalHeight, float heelLocalHeight, float toePoseWeight, float heelPoseWeight)
		{
			for (int i = 0; i < this.m_IFemaleFullBodyBipedIKs.primarios.Count; i++)
			{
				this.m_IFemaleFullBodyBipedIKs.primarios[i].GetComponent<FemaleHighHeelSystem>().SetHeight(toeLocalHeight, heelLocalHeight, toePoseWeight, heelPoseWeight);
			}
		}

		// Token: 0x04000116 RID: 278
		private IFemaleFullBodyBipedIKs m_IFemaleFullBodyBipedIKs;
	}
}
