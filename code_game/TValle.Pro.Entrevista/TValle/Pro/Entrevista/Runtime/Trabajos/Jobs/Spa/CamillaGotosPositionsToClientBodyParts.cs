using System;
using System.Collections;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x0200006F RID: 111
	public class CamillaGotosPositionsToClientBodyParts : CustomMonobehaviour
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x0001C4E8 File Offset: 0x0001A6E8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_calf.Init(this, this.calfGOTO);
			this.m_leg.Init(this, this.legGOTO);
			this.m_groin.Init(this, this.groinGOTO);
			this.m_abdomen.Init(this, this.abdomenGOTO);
			this.m_chest.Init(this, this.chestGOTO);
			this.m_shoulder.Init(this, this.shulderGOTO);
			this.m_handJob.Init(this, this.handJobGOTO);
			this.m_corutina = new CoroutineCapsule(this.UpdateGOTOsRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0001C59E File Offset: 0x0001A79E
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

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
		public void UpdateGOTOs()
		{
			this.m_calf.Update(this);
			this.m_leg.Update(this);
			this.m_groin.Update(this);
			this.m_abdomen.Update(this);
			this.m_chest.Update(this);
			this.m_shoulder.Update(this);
			this.m_handJob.Update(this);
		}

		// Token: 0x040002CA RID: 714
		public Transform groundPlane;

		// Token: 0x040002CB RID: 715
		public Transform sidePlane;

		// Token: 0x040002CC RID: 716
		public Transform posePivot;

		// Token: 0x040002CD RID: 717
		[Header("Gotos")]
		public Transform calfGOTO;

		// Token: 0x040002CE RID: 718
		public Transform legGOTO;

		// Token: 0x040002CF RID: 719
		public Transform groinGOTO;

		// Token: 0x040002D0 RID: 720
		public Transform abdomenGOTO;

		// Token: 0x040002D1 RID: 721
		public Transform chestGOTO;

		// Token: 0x040002D2 RID: 722
		public Transform shulderGOTO;

		// Token: 0x040002D3 RID: 723
		public Transform handJobGOTO;

		// Token: 0x040002D4 RID: 724
		private CoroutineCapsule m_corutina;

		// Token: 0x040002D5 RID: 725
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_calf = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002D6 RID: 726
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_leg = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002D7 RID: 727
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_groin = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002D8 RID: 728
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_abdomen = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002D9 RID: 729
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_chest = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002DA RID: 730
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_shoulder = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x040002DB RID: 731
		[SerializeField]
		[ReadOnlyUI]
		private CamillaGotosPositionsToClientBodyParts.GOTOData m_handJob = new CamillaGotosPositionsToClientBodyParts.GOTOData();

		// Token: 0x02000202 RID: 514
		[Serializable]
		public class GOTOData
		{
			// Token: 0x06000F8E RID: 3982 RVA: 0x0004C808 File Offset: 0x0004AA08
			public void Init(CamillaGotosPositionsToClientBodyParts owner, Transform GOTO)
			{
				if (GOTO == null)
				{
					throw new ArgumentNullException("GOTO", "GOTO null reference.");
				}
				this.goTo = GOTO;
				this.localPositionFromPosePivot = owner.posePivot.InverseTransformPoint(this.goTo.position);
				this.distanceToGroundPlane = Vector3.Distance(this.goTo.position, Math3d.ProjectPointOnPlane(owner.groundPlane.forward, owner.groundPlane.position, this.goTo.position));
				this.distanceToSidePlane = Vector3.Distance(this.goTo.position, Math3d.ProjectPointOnPlane(owner.sidePlane.forward, owner.sidePlane.position, this.goTo.position));
			}

			// Token: 0x06000F8F RID: 3983 RVA: 0x0004C8CC File Offset: 0x0004AACC
			public void Update(CamillaGotosPositionsToClientBodyParts owner)
			{
				Vector3 vector = owner.posePivot.TransformPoint(this.localPositionFromPosePivot);
				vector = Math3d.ProjectPointOnPlane(owner.groundPlane.forward, owner.groundPlane.position, vector) + owner.groundPlane.forward.SetMagnitud(this.distanceToGroundPlane);
				vector = Math3d.ProjectPointOnPlane(owner.sidePlane.forward, owner.sidePlane.position, vector) + owner.sidePlane.forward.SetMagnitud(this.distanceToSidePlane);
				this.goTo.position = vector;
			}

			// Token: 0x040009BF RID: 2495
			public Transform goTo;

			// Token: 0x040009C0 RID: 2496
			public Vector3 localPositionFromPosePivot;

			// Token: 0x040009C1 RID: 2497
			public float distanceToGroundPlane;

			// Token: 0x040009C2 RID: 2498
			public float distanceToSidePlane;
		}
	}
}
