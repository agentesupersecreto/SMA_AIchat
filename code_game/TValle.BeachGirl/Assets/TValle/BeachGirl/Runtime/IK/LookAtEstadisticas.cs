using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.IK
{
	// Token: 0x020000A3 RID: 163
	[Serializable]
	public struct LookAtEstadisticas
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00010183 File Offset: 0x0000E383
		public float anguloVertical
		{
			get
			{
				return this.m_anguloVertical;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0001018B File Offset: 0x0000E38B
		public float anguloHorizontal
		{
			get
			{
				return this.m_anguloHorizontal;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00010193 File Offset: 0x0000E393
		public float anguloVerticalOnPlane
		{
			get
			{
				return this.m_anguloVerticalOnPlane;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x0001019B File Offset: 0x0000E39B
		public float anguloVerticalOnPlaneAbs
		{
			get
			{
				return Mathf.Abs(this.anguloVerticalOnPlane);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x000101A8 File Offset: 0x0000E3A8
		public float anguloVerticalAbs
		{
			get
			{
				return Mathf.Abs(this.anguloVertical);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000101B5 File Offset: 0x0000E3B5
		public float anguloHorizontalAbs
		{
			get
			{
				return Mathf.Abs(this.anguloHorizontal);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x000101C2 File Offset: 0x0000E3C2
		public bool haciaAtras
		{
			get
			{
				return this.anguloHorizontalAbs >= 90f;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x000101D4 File Offset: 0x0000E3D4
		public bool haciaArriba
		{
			get
			{
				return this.anguloVertical >= 0f;
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000101E6 File Offset: 0x0000E3E6
		public void Actualizar(BoneState estado, Vector3 worldDirection)
		{
			Math3dTvalle.GetDirectionAngle(out this.m_anguloVertical, out this.m_anguloVerticalOnPlane, out this.m_anguloHorizontal, estado.rotation * estado.offSetToForward, worldDirection, true);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00010212 File Offset: 0x0000E412
		public void Actualizar(Vector3 forward, Vector3 up, Vector3 worldDirection)
		{
			Math3dTvalle.GetDirectionAngle(out this.m_anguloVertical, out this.m_anguloVerticalOnPlane, out this.m_anguloHorizontal, Quaternion.LookRotation(forward, up), worldDirection, true);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00010234 File Offset: 0x0000E434
		public void Actualizar(Quaternion rotation, Vector3 worldDirection)
		{
			Math3dTvalle.GetDirectionAngle(out this.m_anguloVertical, out this.m_anguloVerticalOnPlane, out this.m_anguloHorizontal, rotation, worldDirection, true);
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x00010250 File Offset: 0x0000E450
		public float haciaLadosMod
		{
			get
			{
				float anguloHorizontalAbs = this.anguloHorizontalAbs;
				if (anguloHorizontalAbs <= 90f)
				{
					return Mathf.InverseLerp(0f, 90f, anguloHorizontalAbs);
				}
				return Mathf.InverseLerp(180f, 90f, anguloHorizontalAbs);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00010290 File Offset: 0x0000E490
		public float haciaLadosModAprox
		{
			get
			{
				float anguloHorizontalAbs = this.anguloHorizontalAbs;
				if (anguloHorizontalAbs <= 90f)
				{
					return Mathf.InverseLerp(55f, 90f, anguloHorizontalAbs);
				}
				return Mathf.InverseLerp(125f, 90f, anguloHorizontalAbs);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x000102D0 File Offset: 0x0000E4D0
		public float haciaAdelanteModAprox
		{
			get
			{
				float anguloHorizontalAbs = this.anguloHorizontalAbs;
				return Mathf.InverseLerp(135f, 45f, anguloHorizontalAbs);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x000102F4 File Offset: 0x0000E4F4
		public float haciaAtrasModAprox
		{
			get
			{
				float anguloHorizontalAbs = this.anguloHorizontalAbs;
				return Mathf.InverseLerp(45f, 135f, anguloHorizontalAbs);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x00010318 File Offset: 0x0000E518
		public float haciaAtrasMod
		{
			get
			{
				float anguloHorizontalAbs = this.anguloHorizontalAbs;
				return Mathf.InverseLerp(90f, 179f, anguloHorizontalAbs);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0001033C File Offset: 0x0000E53C
		public float haciaArribaMod
		{
			get
			{
				return Mathf.InverseLerp(0f, 90f, this.anguloVertical);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x00010353 File Offset: 0x0000E553
		public float haciaArribaAprox
		{
			get
			{
				return Mathf.InverseLerp(25f, 85f, this.anguloVertical);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0001036A File Offset: 0x0000E56A
		public float haciaAbajoMod
		{
			get
			{
				return Mathf.InverseLerp(0f, -90f, this.anguloVertical);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00010381 File Offset: 0x0000E581
		public float haciaAbajoAprox
		{
			get
			{
				return Mathf.InverseLerp(-25f, -85f, this.anguloVertical);
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x00010398 File Offset: 0x0000E598
		public float verticalOnPlaneModAprox
		{
			get
			{
				return Mathf.InverseLerp(25f, 85f, this.anguloVerticalOnPlaneAbs);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x000103AF File Offset: 0x0000E5AF
		public float verticalMod
		{
			get
			{
				return Mathf.InverseLerp(0f, 90f, this.anguloVerticalAbs);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x000103C6 File Offset: 0x0000E5C6
		public float verticalModAprox
		{
			get
			{
				return Mathf.InverseLerp(25f, 85f, this.anguloVerticalAbs);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x000103E0 File Offset: 0x0000E5E0
		public float extremosModAprox
		{
			get
			{
				float num = (this.haciaAtrasModAprox + this.verticalModAprox) * 0.5f;
				return Mathf.InverseLerp(0f, 0.5f, num);
			}
		}

		// Token: 0x040002F9 RID: 761
		[SerializeField]
		private float m_anguloVertical;

		// Token: 0x040002FA RID: 762
		[SerializeField]
		private float m_anguloHorizontal;

		// Token: 0x040002FB RID: 763
		[SerializeField]
		private float m_anguloVerticalOnPlane;
	}
}
