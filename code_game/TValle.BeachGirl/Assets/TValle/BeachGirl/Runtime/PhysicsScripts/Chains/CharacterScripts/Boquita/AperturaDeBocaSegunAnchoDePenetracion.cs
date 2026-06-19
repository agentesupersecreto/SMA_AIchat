using System;
using Assets._ReusableScripts.Controllers;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000083 RID: 131
	public class AperturaDeBocaSegunAnchoDePenetracion : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0000A8BE File Offset: 0x00008ABE
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000A8C7 File Offset: 0x00008AC7
		public IControladorDeJaw controladorDeJaw
		{
			get
			{
				return this.m_controladorDeJaw;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000A8CF File Offset: 0x00008ACF
		public Vector3 current12_virtuaPosition
		{
			get
			{
				return this.m_current12_virtuaPosition;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0000A8D7 File Offset: 0x00008AD7
		public Vector3 current6_virtuaPosition
		{
			get
			{
				return this.m_current6_virtuaPosition;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000A8DF File Offset: 0x00008ADF
		public Vector3 currentRectAngleIntersection
		{
			get
			{
				return this.m_currentRectAngleIntersection;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000A8E7 File Offset: 0x00008AE7
		public float currentJawAngleFromWalls
		{
			get
			{
				return this.m_modAperturaJaw.valor.valor;
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000389 RID: 905 RVA: 0x0000A8FC File Offset: 0x00008AFC
		// (remove) Token: 0x0600038A RID: 906 RVA: 0x0000A934 File Offset: 0x00008B34
		public event Action<AperturaDeBocaSegunAnchoDePenetracion> updated;

		// Token: 0x0600038B RID: 907 RVA: 0x0000A96C File Offset: 0x00008B6C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_hole = base.GetComponentInChildren<BocaHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			this.m_controladorDeJaw = this.GetComponentEnRoot(false);
			if (this.m_controladorDeJaw == null)
			{
				throw new ArgumentNullException("m_controladorDeJaw", "m_controladorDeJaw null reference.");
			}
			if (this.m_controladorDeJaw.isStared)
			{
				this.JawControStared(this.m_hole);
			}
			else
			{
				this.m_controladorDeJaw.stared += this.JawControStared;
			}
			if (this.m_hole.isStared)
			{
				this.HoleStared(this.m_hole);
				return;
			}
			this.m_hole.stared += this.HoleStared;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000AA31 File Offset: 0x00008C31
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_modAperturaJaw.TryRemoverDeOwner(true);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000AA48 File Offset: 0x00008C48
		private void HoleStared(object hole)
		{
			this.m_root = base.transform.FindDeepChild(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabiosRoot, true);
			Transform transform = this.m_hole._12.otherBody.transform;
			this.m_initialLocalRectDirection = this.m_root.InverseTransformPoint(transform.position);
			this.m_initialLocalRectDirectionMag = this.m_initialLocalRectDirection.magnitude;
			this.m_initialLocalRectDirection = this.m_initialLocalRectDirection.normalized;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000AAC0 File Offset: 0x00008CC0
		private void JawControStared(object hole)
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controladorDeJaw.ObtenerOrdenesDeID("x", ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto);
			this.m_modAperturaJaw = ordenesDeID.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000AAF4 File Offset: 0x00008CF4
		public override void OnUpdateEvent1()
		{
			if (!this.m_controladorDeJaw.isStared || !this.m_hole.isStared)
			{
				return;
			}
			this.m_modAperturaJaw.valor.valor = 0f;
			float maxLimpiaLocalHole = this.m_hole.estadoDePuntos.actualLocal.maxLimpiaLocalHole;
			try
			{
				if ((double)maxLimpiaLocalHole > 0.0001)
				{
					this.m_current12_virtuaPosition = this.m_initialLocalRectDirection * this.m_initialLocalRectDirectionMag;
					Quaternion quaternion = Quaternion.Inverse(this.m_root.rotation) * this.m_hole.entradaTransform.rotation;
					this.m_current6_virtuaPosition = this.m_current12_virtuaPosition + quaternion * this.config.entradaDownward * maxLimpiaLocalHole;
					if (!Math3d.LinePlaneIntersection(out this.m_currentRectAngleIntersection, Vector3.zero, this.m_current6_virtuaPosition.normalized, this.m_initialLocalRectDirection, this.m_current12_virtuaPosition))
					{
						throw new InvalidOperationException("No se pudo calcular la Intersection");
					}
					float num = Mathf.Acos(this.m_current12_virtuaPosition.magnitude / this.m_currentRectAngleIntersection.magnitude);
					num *= 57.29578f;
					this.m_modAperturaJaw.valor.valor = num;
				}
			}
			finally
			{
				Action<AperturaDeBocaSegunAnchoDePenetracion> action = this.updated;
				if (action != null)
				{
					action(this);
				}
			}
		}

		// Token: 0x0400020A RID: 522
		public AperturaDeBocaSegunAnchoDePenetracion.Config config = new AperturaDeBocaSegunAnchoDePenetracion.Config();

		// Token: 0x0400020B RID: 523
		private Transform m_root;

		// Token: 0x0400020C RID: 524
		private BocaHole m_hole;

		// Token: 0x0400020D RID: 525
		private Vector3 m_initialLocalRectDirection;

		// Token: 0x0400020E RID: 526
		private float m_initialLocalRectDirectionMag;

		// Token: 0x0400020F RID: 527
		private IControladorDeJaw m_controladorDeJaw;

		// Token: 0x04000210 RID: 528
		[SerializeField]
		private ModificadorDeFloat m_modAperturaJaw;

		// Token: 0x04000211 RID: 529
		private Vector3 m_current12_virtuaPosition;

		// Token: 0x04000212 RID: 530
		private Vector3 m_current6_virtuaPosition;

		// Token: 0x04000213 RID: 531
		private Vector3 m_currentRectAngleIntersection;

		// Token: 0x02000178 RID: 376
		[Serializable]
		public class Config
		{
			// Token: 0x04000891 RID: 2193
			public Vector3 entradaDownward = Vector3.down;
		}
	}
}
