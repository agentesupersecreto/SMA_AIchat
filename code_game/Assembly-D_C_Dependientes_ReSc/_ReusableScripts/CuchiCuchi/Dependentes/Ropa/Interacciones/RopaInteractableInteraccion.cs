using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa.Interacciones
{
	// Token: 0x0200010A RID: 266
	[RequireComponent(typeof(Interaccion))]
	public class RopaInteractableInteraccion : CustomMonobehaviour
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0001EF70 File Offset: 0x0001D170
		public float w
		{
			get
			{
				return this.m_w;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001EF78 File Offset: 0x0001D178
		public Vector3 worldPosition
		{
			get
			{
				return this.m_worldPosition;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0001EF80 File Offset: 0x0001D180
		public Vector3 worldNormal
		{
			get
			{
				return this.m_worldNormal;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0001EF88 File Offset: 0x0001D188
		public Vector3 worldUp
		{
			get
			{
				return this.m_worldUp;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0001EF90 File Offset: 0x0001D190
		public GuiaDeRopaInteractable currentGuia
		{
			get
			{
				return this.m_currentGuia;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001EF98 File Offset: 0x0001D198
		public Interaccion interaccion
		{
			get
			{
				return this.m_Interaccion;
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001EFA0 File Offset: 0x0001D1A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_copier == null)
			{
				throw new ArgumentNullException("m_copier", "m_copier null reference.");
			}
			this.m_Interaccion = base.GetComponent<Interaccion>();
			this.m_FollowCoroutine = new CoroutineCapsule(this, new CoroutineCapsuleConfig
			{
				autoRestart = false,
				autoStart = false
			});
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001EFFC File Offset: 0x0001D1FC
		private IEnumerator DoFollowRutine()
		{
			float modPorDistancia = 1f;
			while (this.m_currentGuia != null)
			{
				float num = Mathf.Lerp(1f, 0.05f, Mathf.InverseLerp(0.666f, 1f, this.m_w).InPow(2f));
				this.m_w = Mathf.MoveTowards(this.m_w, 1f, Time.deltaTime * this.config.velocity * num * modPorDistancia);
				float num2;
				this.m_currentGuia.SimularPosicion(this.m_w, out num2, out this.m_worldPosition, out this.m_worldNormal, out this.m_worldUp);
				num2 *= this.m_currentGuia.character.escala;
				modPorDistancia = Mathf.Lerp(1f, 2f, Mathf.InverseLerp(0.05f, 0.15f, num2).InPow(3f));
				this.ActualizarCopier();
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001F00B File Offset: 0x0001D20B
		public void ActualizarCopier()
		{
			this.m_copier.position = this.m_worldPosition;
			this.m_copier.rotation = Quaternion.LookRotation(this.m_worldNormal, this.m_worldUp);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001F03A File Offset: 0x0001D23A
		public void FollowStartPose(GuiaDeRopaInteractable guia)
		{
			this.m_worldPosition = guia.start.position;
			this.m_worldNormal = guia.start.forward;
			this.m_worldUp = guia.start.up;
			this.ActualizarCopier();
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001F078 File Offset: 0x0001D278
		public void StartFollowing(GuiaDeRopaInteractable guia)
		{
			if (this.m_currentGuia != null)
			{
				this.StopFollowing();
			}
			this.m_currentGuia = guia;
			this.m_worldPosition = this.m_currentGuia.start.position;
			this.m_worldNormal = this.m_currentGuia.start.forward;
			this.m_worldUp = this.m_currentGuia.start.up;
			this.ActualizarCopier();
			this.m_FollowCoroutine.Start(this.DoFollowRutine(), null, null);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001F104 File Offset: 0x0001D304
		public void StopFollowing()
		{
			this.m_FollowCoroutine.Stop();
			this.m_w = 0f;
			this.m_currentGuia = null;
		}

		// Token: 0x04000442 RID: 1090
		[SerializeField]
		private Transform m_copier;

		// Token: 0x04000443 RID: 1091
		[SerializeField]
		[ReadOnlyUI]
		private float m_w;

		// Token: 0x04000444 RID: 1092
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_worldPosition;

		// Token: 0x04000445 RID: 1093
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_worldNormal;

		// Token: 0x04000446 RID: 1094
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_worldUp;

		// Token: 0x04000447 RID: 1095
		[SerializeField]
		[ReadOnlyUI]
		private GuiaDeRopaInteractable m_currentGuia;

		// Token: 0x04000448 RID: 1096
		public RopaInteractableInteraccion.Config config = new RopaInteractableInteraccion.Config();

		// Token: 0x04000449 RID: 1097
		private Interaccion m_Interaccion;

		// Token: 0x0400044A RID: 1098
		private CoroutineCapsule m_FollowCoroutine;

		// Token: 0x0200010B RID: 267
		[Serializable]
		public class Config
		{
			// Token: 0x0400044B RID: 1099
			public float velocity = 1f;
		}
	}
}
