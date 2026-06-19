using System;
using System.Collections;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x0200006E RID: 110
	public class CamillaBigGotosPositionsToClientBody : CustomMonobehaviour
	{
		// Token: 0x060004D1 RID: 1233 RVA: 0x0001C41C File Offset: 0x0001A61C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_onTop.Init(this, this.onTopGOTO);
			this.m_onTopInv.Init(this, this.onTopInvGOTO);
			this.m_onTopOral.Init(this, this.onTopOralGOTO);
			this.m_corutina = new CoroutineCapsule(this.UpdateGOTOsRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0001C48A File Offset: 0x0001A68A
		private IEnumerator UpdateGOTOsRutine()
		{
			WaitForSeconds w = new WaitForSeconds(0.666f.Random(0.2f));
			for (;;)
			{
				yield return w;
				this.UpdateGOTOs();
			}
			yield break;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001C499 File Offset: 0x0001A699
		public void UpdateGOTOs()
		{
			this.m_onTop.Update();
			this.m_onTopInv.Update();
			this.m_onTopOral.Update();
		}

		// Token: 0x040002C0 RID: 704
		public Transform plane;

		// Token: 0x040002C1 RID: 705
		public InteraccionMalePrimariaBase closedLegsInter;

		// Token: 0x040002C2 RID: 706
		public InteraccionMalePrimariaBase openLegsInter;

		// Token: 0x040002C3 RID: 707
		[Header("Gotos")]
		public Transform onTopGOTO;

		// Token: 0x040002C4 RID: 708
		public Transform onTopInvGOTO;

		// Token: 0x040002C5 RID: 709
		public Transform onTopOralGOTO;

		// Token: 0x040002C6 RID: 710
		private CoroutineCapsule m_corutina;

		// Token: 0x040002C7 RID: 711
		[SerializeField]
		[ReadOnlyUI]
		private CamillaBigGotosPositionsToClientBody.GOTOData m_onTop = new CamillaBigGotosPositionsToClientBody.GOTOData();

		// Token: 0x040002C8 RID: 712
		[SerializeField]
		[ReadOnlyUI]
		private CamillaBigGotosPositionsToClientBody.GOTOData m_onTopInv = new CamillaBigGotosPositionsToClientBody.GOTOData();

		// Token: 0x040002C9 RID: 713
		[SerializeField]
		[ReadOnlyUI]
		private CamillaBigGotosPositionsToClientBody.GOTOData m_onTopOral = new CamillaBigGotosPositionsToClientBody.GOTOData();

		// Token: 0x02000200 RID: 512
		[Serializable]
		public class GOTOData
		{
			// Token: 0x06000F85 RID: 3973 RVA: 0x0004C628 File Offset: 0x0004A828
			public void Init(CamillaBigGotosPositionsToClientBody Owner, Transform GOTO)
			{
				if (GOTO == null)
				{
					throw new ArgumentNullException("GOTO", "GOTO null reference.");
				}
				this.owner = Owner;
				this.goTo = GOTO;
				this.localPositionFromClosedLegsInterPivot = Owner.closedLegsInter.interactionRootBone.InverseTransformPoint(this.goTo.position);
				this.localPositionFromOpenedLegsInterPivot = Owner.openLegsInter.interactionRootBone.InverseTransformPoint(this.goTo.position);
			}

			// Token: 0x06000F86 RID: 3974 RVA: 0x0004C6A0 File Offset: 0x0004A8A0
			public void Update()
			{
				if (this.owner.closedLegsInter.ejecutandose)
				{
					Vector3 vector = this.owner.closedLegsInter.interactionRootBone.TransformPoint(this.localPositionFromClosedLegsInterPivot);
					Math3d.ProjectPointOnPlane(this.owner.plane.forward, this.owner.plane.position, vector);
					this.goTo.position = vector;
				}
				if (this.owner.openLegsInter.ejecutandose)
				{
					Vector3 vector2 = this.owner.openLegsInter.interactionRootBone.TransformPoint(this.localPositionFromOpenedLegsInterPivot);
					Math3d.ProjectPointOnPlane(this.owner.plane.forward, this.owner.plane.position, vector2);
					this.goTo.position = vector2;
				}
			}

			// Token: 0x040009B7 RID: 2487
			public CamillaBigGotosPositionsToClientBody owner;

			// Token: 0x040009B8 RID: 2488
			public Transform goTo;

			// Token: 0x040009B9 RID: 2489
			public Vector3 localPositionFromClosedLegsInterPivot;

			// Token: 0x040009BA RID: 2490
			public Vector3 localPositionFromOpenedLegsInterPivot;
		}
	}
}
