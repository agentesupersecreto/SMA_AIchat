using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Skins.PhysicsScripts;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D6 RID: 214
	public class PenisPart : CustomUpdatedMonobehaviour, IPenisPartPenetratiosCallbacks, IPenisPartPenetrationValidator, IHitSkinCollisionListener, IPeneParte
	{
		// Token: 0x17000308 RID: 776
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00018885 File Offset: 0x00016A85
		IPeneParteCollider IPeneParte.mainCollider
		{
			get
			{
				return this.mainCollider;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0001888D File Offset: 0x00016A8D
		IPeneParteCollider IPeneParte.complementoCollider
		{
			get
			{
				return this.complementoCollider;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00018895 File Offset: 0x00016A95
		public IPeneConPartes pene
		{
			get
			{
				return this.m_penis;
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0001889D File Offset: 0x00016A9D
		public Penetrador penis
		{
			get
			{
				return this.m_penis;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x000188A5 File Offset: 0x00016AA5
		public Rigidbody physicBone
		{
			get
			{
				return this.m_Rigidbody;
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x000188AD File Offset: 0x00016AAD
		public Transform charBone
		{
			get
			{
				return this.m_bone;
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x000188B5 File Offset: 0x00016AB5
		public PenisPoint puntoConnectadoAEstaParte
		{
			get
			{
				return this.m_puntoConnectadoAEstaParte;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x000188BD File Offset: 0x00016ABD
		[Obsolete("", true)]
		public PenisPointCollider partCollider
		{
			get
			{
				return this.m_PenisPointCollider;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x000188C5 File Offset: 0x00016AC5
		public PenisPointCollider mainCollider
		{
			get
			{
				return this.m_mainCollider;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x000188CD File Offset: 0x00016ACD
		public PenisPointCollider complementoCollider
		{
			get
			{
				return this.m_complementoCollider;
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x000188D5 File Offset: 0x00016AD5
		public float maxRadius
		{
			get
			{
				return Mathf.Max(this.mainCollider.radius, this.complementoCollider.radius);
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x000188F2 File Offset: 0x00016AF2
		public float maxWorldRadius
		{
			get
			{
				return Mathf.Max(this.mainCollider.worldRadius, this.complementoCollider.worldRadius);
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x0001890F File Offset: 0x00016B0F
		public float minWorldRadius
		{
			get
			{
				return Mathf.Min(this.mainCollider.worldRadius, this.complementoCollider.worldRadius);
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0001892C File Offset: 0x00016B2C
		public float avgWorldRadius
		{
			get
			{
				return (this.mainCollider.worldRadius + this.complementoCollider.worldRadius) / 2f;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0001894B File Offset: 0x00016B4B
		public float maxWorldHeight
		{
			get
			{
				return Mathf.Max(this.mainCollider.worldHeight, this.complementoCollider.worldHeight);
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x00018968 File Offset: 0x00016B68
		public float minWorldHeight
		{
			get
			{
				return Mathf.Min(this.mainCollider.worldHeight, this.complementoCollider.worldHeight);
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00018985 File Offset: 0x00016B85
		public float avgWorldHeight
		{
			get
			{
				return (this.mainCollider.worldHeight + this.complementoCollider.worldHeight) / 2f;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x000189A4 File Offset: 0x00016BA4
		public float maxWorldThickness
		{
			get
			{
				return Mathf.Max(this.maxWorldHeight * 0.666f, this.maxWorldRadius * 2f);
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x000189C3 File Offset: 0x00016BC3
		public bool isLast
		{
			get
			{
				return this.puntoConnectadoAEstaParte.isLast;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x000189D0 File Offset: 0x00016BD0
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x000189D8 File Offset: 0x00016BD8
		public int index
		{
			get
			{
				return this.m_index;
			}
			private set
			{
				this.m_index = value;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x000189E1 File Offset: 0x00016BE1
		public Vector3 localForward
		{
			get
			{
				return this.puntoConnectadoAEstaParte.jointLocalForward;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x000189EE File Offset: 0x00016BEE
		public Vector3 worldForward
		{
			get
			{
				return this.physicBone.transform.TransformDirection(this.localForward);
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x00018A06 File Offset: 0x00016C06
		public Vector3 worldUp
		{
			get
			{
				return this.physicBone.transform.TransformDirection(this.puntoConnectadoAEstaParte.jointLocalUp);
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x00018A23 File Offset: 0x00016C23
		public bool inMiddle
		{
			get
			{
				return this.m_currentHit != null && this.m_currentHit.isValid;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00018A3A File Offset: 0x00016C3A
		public bool inside
		{
			get
			{
				return this.inMiddle || this.m_PenetrationState == PenisPart.PenetrationState.adentroDesactivado || this.m_PenetrationState == PenisPart.PenetrationState.adentro;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00018A58 File Offset: 0x00016C58
		public bool activado
		{
			get
			{
				return this.m_activado;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00018A60 File Offset: 0x00016C60
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x00018A68 File Offset: 0x00016C68
		public BoneStretchedChain currentPenetratingHole
		{
			get
			{
				return this.m_currentPenHole;
			}
			private set
			{
				if (value == null)
				{
					if (this.m_currentPenHole == null)
					{
						return;
					}
					if (this.debugPenChanges)
					{
						MonoBehaviour.print(string.Concat(new string[]
						{
							"parte: ",
							base.name,
							", limpio la referencia del hole q estaba penetrando : ",
							this.m_currentPenHole.name,
							" . PenState: ",
							this.m_PenetrationState.ToString()
						}));
					}
					this.m_currentPenHole = null;
					return;
				}
				else
				{
					if (this.m_currentPenHole != value)
					{
						if (this.debugPenChanges)
						{
							MonoBehaviour.print(string.Concat(new string[]
							{
								"parte: ",
								base.name,
								", cambio la referencia del hole q esta penetrando, antes: ",
								(this.m_currentPenHole == null) ? "NULA" : this.m_currentPenHole.name,
								", ahora: ",
								value.name,
								" . PenState: ",
								this.m_PenetrationState.ToString()
							}));
						}
						this.m_currentPenHole = value;
						return;
					}
					return;
				}
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x00018B8A File Offset: 0x00016D8A
		public PenisPart.PenetrationState penetrationState
		{
			get
			{
				return this.m_PenetrationState;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x00018B92 File Offset: 0x00016D92
		public float worldDistanceToHole
		{
			get
			{
				return this.m_distanceToHole;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x00018B9A File Offset: 0x00016D9A
		public float worldTipPenetrationDistance
		{
			get
			{
				return this.m_tipPenetrationDistance;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x00018BA2 File Offset: 0x00016DA2
		public float worldBasePenetrationDistance
		{
			get
			{
				return this.m_basePenetrationDistance;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00018BAA File Offset: 0x00016DAA
		public float worldDeepDistance
		{
			get
			{
				return this.m_deepDistance;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00018BB2 File Offset: 0x00016DB2
		public float deepMod
		{
			get
			{
				return this.m_deepMod;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x00018BBC File Offset: 0x00016DBC
		public PenisPart nextPart
		{
			get
			{
				if (this.puntoConnectadoAEstaParte.isLast)
				{
					return null;
				}
				PenisPoint penisPoint = this.puntoConnectadoAEstaParte.chain.Next(this.puntoConnectadoAEstaParte);
				PenisPart penisPart = this.penis.ObtenerParte(penisPoint);
				if (penisPart == null)
				{
					throw new InvalidOperationException();
				}
				return penisPart;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00018C0C File Offset: 0x00016E0C
		public PenisPart previusPart
		{
			get
			{
				if (this.puntoConnectadoAEstaParte.isRoot)
				{
					return null;
				}
				PenisPoint penisPoint = this.puntoConnectadoAEstaParte.chain.previus(this.puntoConnectadoAEstaParte);
				PenisPart penisPart = this.penis.ObtenerParte(penisPoint);
				if (penisPart == null)
				{
					throw new InvalidOperationException();
				}
				return penisPart;
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00018C5A File Offset: 0x00016E5A
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_IgnorandoHolesCollisions = new PenisPart.IgnorandoHolesCollisions(this);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00018C6E File Offset: 0x00016E6E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_currentHit = null;
			this.m_PenetrationState = this.GetCurrentState();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00018C8C File Offset: 0x00016E8C
		public virtual void SetParam(Penetrador p, int i, PenisPoint puntoQueSeConnecta, Transform bone)
		{
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			this.m_bone = bone;
			this.m_penis = p;
			this.index = i;
			this.m_puntoConnectadoAEstaParte = puntoQueSeConnecta;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_mainCollider = base.GetComponent<PenisPointCollider>();
			this.m_complementoCollider = base.GetComponentsInChildren<PenisPointCollider>().First((PenisPointCollider c) => c != this.m_mainCollider);
			this.m_scaler = base.gameObject.AddComponent<PenisPointColliderSmoothScaler>();
			this.m_scaler.scaleAltura = false;
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00018D24 File Offset: 0x00016F24
		public PenisPart.PenetrationState GetCurrentState()
		{
			if (this.inMiddle)
			{
				return PenisPart.PenetrationState.adentro;
			}
			int lastInMiddleIndex = this.penis.lastInMiddleIndex;
			if (lastInMiddleIndex < 0)
			{
				return PenisPart.PenetrationState.fuera;
			}
			if (lastInMiddleIndex >= this.index)
			{
				return PenisPart.PenetrationState.fuera;
			}
			if (this.m_currentPenHole.escondePenetradores)
			{
				return PenisPart.PenetrationState.adentroDesactivado;
			}
			return PenisPart.PenetrationState.adentro;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00018D68 File Offset: 0x00016F68
		public void UpdateState()
		{
			this.m_IgnorandoHolesCollisions.debugLogInvokaciones = this.debugPenChanges;
			this.UpdateHiddenState();
			if (this.hidden)
			{
				return;
			}
			try
			{
				this.m_PenetrationState = this.GetCurrentState();
			}
			finally
			{
				this.OnState();
			}
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00018DBC File Offset: 0x00016FBC
		public void UpdateHiddenState()
		{
			if (this.hidden)
			{
				if (this.m_activado)
				{
					this.Desactivar();
					return;
				}
			}
			else if (!this.m_activado)
			{
				this.Acitvar();
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00018DE4 File Offset: 0x00016FE4
		protected virtual void OnState()
		{
			PenisPart.PenetrationState penetrationState = this.m_PenetrationState;
			if (penetrationState > PenisPart.PenetrationState.adentro)
			{
				if (penetrationState == PenisPart.PenetrationState.adentroDesactivado)
				{
					if (this.m_LastPenetrationState == PenisPart.PenetrationState.adentro || this.m_LastPenetrationState == PenisPart.PenetrationState.fuera || (this.hidden && this.m_activado))
					{
						this.Desactivar();
					}
				}
			}
			else if (this.m_LastPenetrationState == PenisPart.PenetrationState.adentroDesactivado || (!this.hidden && !this.m_activado))
			{
				this.Acitvar();
			}
			if (this.m_PenetrationState == PenisPart.PenetrationState.fuera)
			{
				this.currentPenetratingHole = null;
				if (this.m_LastPenetrationState != this.m_PenetrationState)
				{
					this.m_IgnorandoHolesCollisions.LimpiarIgnoracionesDelayed();
					if (this.debugPenChanges)
					{
						MonoBehaviour.print("parte: " + base.name + ", salio de hole : " + ((this.m_currentPenHole == null) ? "NULA" : this.m_currentPenHole.name));
					}
				}
			}
			if (this.m_LastPenetrationState != this.m_PenetrationState)
			{
				this.OnStateChanged(this.m_LastPenetrationState, this.m_PenetrationState);
			}
			this.m_LastPenetrationState = this.m_PenetrationState;
			if (this.debugIgnorandoHoleColliders)
			{
				this.m_IgnorandoHolesCollisions.DebugEstadoDeIgnoracion();
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00018EF3 File Offset: 0x000170F3
		private void OnStateChanged(PenisPart.PenetrationState last, PenisPart.PenetrationState current)
		{
			if (current == PenisPart.PenetrationState.fuera && !this.penis.isPenetrating)
			{
				this.OnPenisExitHole();
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00018F0C File Offset: 0x0001710C
		public bool ChainContiene(Collider col)
		{
			int num = 0;
			int num2 = this.penis.penisLinearChain.cantidadDePuntos * 2;
			PenisPart penisPart = this;
			while (!penisPart.m_mainCollider.collidersSet.Contains(col))
			{
				if (penisPart.m_complementoCollider.collidersSet.Contains(col))
				{
					return true;
				}
				penisPart = penisPart.nextPart;
				num++;
				if (!(penisPart != null) || num >= num2)
				{
					if (num > this.penis.penisLinearChain.cantidadDePuntos)
					{
						Debug.LogError("propiedad nextPoint NO esta funcionando correctamente", this);
					}
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00018F94 File Offset: 0x00017194
		protected void Acitvar()
		{
			if (this.charBone.localScale != Vector3.one)
			{
				this.charBone.localScale = Vector3.one;
			}
			if (this.m_mainCollider.isTrigger)
			{
				this.m_mainCollider.isTrigger = false;
			}
			if (this.m_complementoCollider.isTrigger)
			{
				this.m_complementoCollider.isTrigger = false;
			}
			this.physicBone.ResetInertiaTensor();
			this.m_activado = true;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0001900C File Offset: 0x0001720C
		protected void Desactivar()
		{
			if (!this.m_mainCollider.isTrigger)
			{
				this.m_mainCollider.isTrigger = true;
			}
			if (!this.m_complementoCollider.isTrigger)
			{
				this.m_complementoCollider.isTrigger = true;
			}
			this.physicBone.inertiaTensor = new Vector3(0.001f, 0.001f, 0.001f);
			this.physicBone.velocity = Vector3.zero;
			this.physicBone.angularVelocity = Vector3.zero;
			this.physicBone.Sleep();
			this.m_activado = false;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0001909C File Offset: 0x0001729C
		bool IPenisPartPenetrationValidator.IsValid(PenisPart parte, BoneStretchedChain hole, RaycastHit hit)
		{
			return this.IsValidPenetration(parte, hole, hit);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x000190A7 File Offset: 0x000172A7
		void IPenisPartPenetratiosCallbacks.OnHelperHit(RaycastHit hit, BoneStretchedChain hole, float largoDeRayo)
		{
			this.OnHelperHit(hit, hole, largoDeRayo);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x000190B2 File Offset: 0x000172B2
		void IPenisPartPenetratiosCallbacks.TryingEnter(Penetraciones.TryPenetrationArgs args, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			this.TryingEnterHole(args, hit, penetracionesChecker.currentHits, penetracionesChecker.hole);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x000190C8 File Offset: 0x000172C8
		void IPenisPartPenetratiosCallbacks.OnEnter(PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			this.OnEnterHole(hit, penetracionesChecker.currentHits, penetracionesChecker.hole);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x000190DD File Offset: 0x000172DD
		void IPenisPartPenetratiosCallbacks.OnStay(PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			this.OnStayHole(hit, penetracionesChecker.currentHits, penetracionesChecker.hole);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x000190F2 File Offset: 0x000172F2
		void IPenisPartPenetratiosCallbacks.OnExit(Penetraciones penetracionesChecker)
		{
			this.OnExitHole(penetracionesChecker.hole);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00019100 File Offset: 0x00017300
		void IHitSkinCollisionListener.OnEnter(HitSkinColision collision)
		{
			this.ControllarEscalesSegunCollision(collision);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00019109 File Offset: 0x00017309
		void IHitSkinCollisionListener.OnStay(HitSkinColision collision)
		{
			this.ControllarEscalesSegunCollision(collision);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00019112 File Offset: 0x00017312
		void IHitSkinCollisionListener.OnExit(HitSkinColision lastCollision)
		{
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00019114 File Offset: 0x00017314
		public void UpdateCollider()
		{
			if (this.m_distanceToHole < 0f || this.m_tipoDeHole < 0)
			{
				return;
			}
			float num = this.penis.worldLengthFromUnderSkin - this.penis.penetratingWorldLength;
			if (num <= 0f)
			{
				Debug.LogWarning("LArgo de pene era zero", this);
				return;
			}
			float num2 = this.m_distanceToHole / num;
			float num3;
			switch (this.m_tipoDeHole)
			{
			case 0:
				num3 = this.config.maxColRadiusWhenCloseToHoleVag;
				break;
			case 1:
				num3 = this.config.maxColRadiusWhenCloseToHoleAnus;
				break;
			case 2:
				num3 = this.config.maxColRadiusWhenCloseToHoleFace;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_tipoDeHole.ToString());
			}
			this.m_scaler.forcedMaxScalePosible = Mathf.Lerp(num3, 1f, num2.InPow(2f));
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x000191E4 File Offset: 0x000173E4
		private void ControllarEscalesSegunCollision(HitSkinColision collision)
		{
			float num = PerfilesDeReduccionDePenisParteSegunParteHumana.ModDeMinScalaSegunParteHumana(collision.partesHumanasImpactadas);
			if (num >= 1f)
			{
				return;
			}
			num = Mathf.LerpUnclamped(1f, num, this.config.colRadiusInfluenceOnCollision);
			if (num >= 1f)
			{
				return;
			}
			this.m_scaler.flagAltoInfluenciaWeight = 1f - num.InPow(2f);
			this.m_scaler.flagToDecrease = true;
			this.m_scaler.flagMinScalePosible = num;
			this.m_scaler.flagReduccionPorSegundoMod = PerfilesDeReduccionDePenisParteSegunParteHumana.ModDeVelocidadSegunModDeMinScala(num);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0001926C File Offset: 0x0001746C
		protected bool IsValidPenetration(PenisPart parte, BoneStretchedChain hole, RaycastHit hit)
		{
			if (parte != this)
			{
				throw new InvalidOperationException();
			}
			if (this.inside)
			{
				return !(this.currentPenetratingHole == null) && this.currentPenetratingHole == hole;
			}
			if (this.puntoConnectadoAEstaParte.isLast)
			{
				return true;
			}
			PenisPoint penisPoint = this.puntoConnectadoAEstaParte.chain.Next(this.puntoConnectadoAEstaParte);
			PenisPart penisPart = this.penis.ObtenerParte(penisPoint);
			if (penisPart == null)
			{
				throw new InvalidOperationException();
			}
			return penisPart.inside && penisPart.currentPenetratingHole == hole;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00019308 File Offset: 0x00017508
		protected void OnHelperHit(RaycastHit hit, BoneStretchedChain hole, float largoDeRayo)
		{
			if (this.inside || !hole.canBePenetrated)
			{
				return;
			}
			float num = MathF.Abs(Vector3.Dot(this.worldForward, -hole.worldOutHoleDirection)).InInOutOutPow(2f, 2f, 0.333f);
			float num2 = Mathf.InverseLerp(0f, (float)this.m_penis.countDePartes, (float)(this.index + 1)).OutPow(2f);
			float num3;
			bool flag;
			float num4;
			if (hole is IVagHole)
			{
				num3 = Mathf.Lerp(1f, 0.4f, num2);
				flag = false;
				num4 = this.config.colRadiusInfluenceOnHelperVag;
			}
			else if (hole is IAnusHole)
			{
				num3 = Mathf.Lerp(1f, 0.15f, num2);
				flag = true;
				num4 = this.config.colRadiusInfluenceOnHelperAnus;
			}
			else
			{
				if (!(hole is IBocaHole))
				{
					throw new ArgumentOutOfRangeException();
				}
				num3 = 0.75f;
				flag = false;
				num4 = this.config.colRadiusInfluenceOnHelperFace;
			}
			this.m_scaler.flagToDecrease = true;
			float num5 = Mathf.Max(this.m_scaler.flagAltoInfluenciaWeight, flag ? 0.4f : 0f);
			float num6 = (flag ? 0.333f : 0.2f);
			float num7 = Mathf.Min(Mathf.Lerp(num3, 1f, Mathf.InverseLerp(largoDeRayo * num6, largoDeRayo, hit.distance).InPow(6f)), this.m_scaler.flagMinScalePosible);
			float num8 = (flag ? 1.25f : 1f);
			float num9 = Mathf.Lerp(0.25f, 1f, Mathf.InverseLerp(largoDeRayo, 0f, hit.distance)) * num8;
			this.m_scaler.flagReduccionPorSegundoMod = Mathf.Max(num9, this.m_scaler.flagReduccionPorSegundoMod);
			this.m_scaler.flagMinScalePosible = Mathf.LerpUnclamped(this.m_scaler.flagMinScalePosible, num7, num4 * num);
			this.m_scaler.flagAltoInfluenciaWeight = Mathf.LerpUnclamped(this.m_scaler.flagAltoInfluenciaWeight, num5, num4 * num);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00019503 File Offset: 0x00017703
		protected void TryingEnterHole(Penetraciones.TryPenetrationArgs args, PenisPartHit hit, PenetradorHits hits, BoneStretchedChain hole)
		{
			this.m_scaler.flagToFrezee = true;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00019514 File Offset: 0x00017714
		protected void OnEnterHole(PenisPartHit hit, PenetradorHits hits, BoneStretchedChain hole)
		{
			if (this.inside && this.currentPenetratingHole != hole)
			{
				throw new InvalidOperationException(string.Concat(new string[]
				{
					"la parte ",
					base.name,
					", esta penetrando dos hole al mismo tiempo, estaba penetrando : ",
					this.currentPenetratingHole.name,
					", y ahora quiere cambiar a: ",
					(hole == null) ? "NULA" : hole.name
				}));
			}
			if (this.debugPenChanges)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"parte: ",
					base.name,
					", OnEnterHole : ",
					hole.name,
					" . PenState: ",
					this.m_PenetrationState.ToString()
				}));
			}
			this.currentPenetratingHole = hole;
			this.m_currentHit = hit;
			this.m_IgnorandoHolesCollisions.IgnorarOtrosColliders(hole, true);
			if (this.config.freeAngularMotionsOnPenetracion)
			{
				JointMotionsAdmin motionsAdmin = this.puntoConnectadoAEstaParte.motionsAdmin;
				motionsAdmin.overrides.angularXMotion = new ConfigurableJointMotion?(ConfigurableJointMotion.Free);
				motionsAdmin.overrides.angularYMotion = new ConfigurableJointMotion?(ConfigurableJointMotion.Free);
				motionsAdmin.overrides.angularZMotion = new ConfigurableJointMotion?(ConfigurableJointMotion.Free);
				motionsAdmin.Fix();
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00019654 File Offset: 0x00017854
		protected void OnStayHole(PenisPartHit hit, PenetradorHits hits, BoneStretchedChain hole)
		{
			if (this.inside && this.currentPenetratingHole != hole)
			{
				throw new InvalidOperationException(string.Concat(new string[]
				{
					"la parte ",
					base.name,
					", esta penetrando dos hole al mismo tiempo, estaba penetrando : ",
					this.currentPenetratingHole.name,
					", y ahora quiere cambiar a: ",
					(hole == null) ? "NULA" : hole.name
				}));
			}
			this.currentPenetratingHole = hole;
			this.m_currentHit = hit;
			this.m_IgnorandoHolesCollisions.IgnorarOtrosColliders(hole, false);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x000196EC File Offset: 0x000178EC
		protected void OnExitHole(BoneStretchedChain hole)
		{
			if (this.debugPenChanges)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"parte: ",
					base.name,
					", OnExitHole : ",
					(hole != null) ? hole.name : null,
					" . PenState: ",
					this.m_PenetrationState.ToString()
				}));
			}
			this.m_currentHit = null;
			JointMotionsAdmin motionsAdmin = this.puntoConnectadoAEstaParte.motionsAdmin;
			motionsAdmin.overrides.angularXMotion = null;
			motionsAdmin.overrides.angularYMotion = null;
			motionsAdmin.overrides.angularZMotion = null;
			motionsAdmin.Fix();
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0001979F File Offset: 0x0001799F
		private void OnPenisExitHole()
		{
			if (this.debugPenChanges)
			{
				MonoBehaviour.print("Pene: " + this.pene.name + ", OnPenisExitHole ");
			}
			this.m_IgnorandoHolesCollisions.InvokarDeInmediato();
			this.m_IgnorandoHolesCollisions.LimpiarIgnoraciones();
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000197DE File Offset: 0x000179DE
		public void UpdateDeep(int lastPenetratingIndex, float worldScale, float worldLossyScale)
		{
			this.UpdateDistanceToHole(lastPenetratingIndex);
			this.UpdateDeepDistance(worldScale, worldLossyScale);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000197EF File Offset: 0x000179EF
		public float ObtenerDistanceToHole()
		{
			this.UpdateDistanceToHole(this.penis.firstInsideIndex);
			return this.m_distanceToHole;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00019808 File Offset: 0x00017A08
		public float GetWorldPartLargo(float worldScale, float worldLossyScale)
		{
			return this.m_mainCollider.height * worldScale * worldLossyScale;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001981C File Offset: 0x00017A1C
		public void CalculeDeep(float worldScale, float worldLossyScale, Vector3 holeWorldEntradaPoint, Vector3 holeWorldOutHoleDirection, bool penetracionEsInvertida, out float tipPenetrationDistance, out float basePenetrationDistance, out float deepDistance, out float deepMod)
		{
			float worldPartLargo = this.GetWorldPartLargo(worldScale, worldLossyScale);
			Vector3 vector;
			Vector3 vector2;
			if (!penetracionEsInvertida)
			{
				vector = this.m_mainCollider.GetLastColliderBaseWorldPosition();
				vector2 = this.m_mainCollider.GetLastColliderTipWorldPosition();
			}
			else
			{
				vector = this.m_mainCollider.GetLastColliderTipWorldPosition();
				vector2 = this.m_mainCollider.GetLastColliderBaseWorldPosition();
			}
			Vector3 vector3 = vector - holeWorldEntradaPoint;
			Vector3 vector4 = vector2 - holeWorldEntradaPoint;
			float num = Vector3.Dot(vector3, holeWorldOutHoleDirection);
			float num2 = Vector3.Dot(vector4, holeWorldOutHoleDirection);
			tipPenetrationDistance = ((num2 >= 0f) ? 0f : vector4.magnitude);
			basePenetrationDistance = ((num >= 0f) ? 0f : vector3.magnitude);
			if (num < 0f)
			{
				deepDistance = worldPartLargo;
			}
			else
			{
				deepDistance = Mathf.Clamp(worldPartLargo - vector3.magnitude, 0f, worldPartLargo);
			}
			deepMod = Mathf.InverseLerp(0f, worldPartLargo, deepDistance);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000198FC File Offset: 0x00017AFC
		public void CalculeDeep(bool inside, float worldScale, float worldLossyScale, Vector3 holeWorldEntradaPoint, Vector3 holeWorldOutHoleDirection, bool penetracionEsInvertida, out float tipPenetrationDistance, out float basePenetrationDistance, out float deepDistance, out float deepMod)
		{
			if (!inside)
			{
				tipPenetrationDistance = 0f;
				basePenetrationDistance = 0f;
				deepDistance = 0f;
				deepMod = 0f;
				return;
			}
			this.CalculeDeep(worldScale, worldLossyScale, holeWorldEntradaPoint, holeWorldOutHoleDirection, penetracionEsInvertida, out tipPenetrationDistance, out basePenetrationDistance, out deepDistance, out deepMod);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00019944 File Offset: 0x00017B44
		private void UpdateDeepDistance(float worldScale, float worldLossyScale)
		{
			this.m_deepMod = 0f;
			this.m_deepDistance = 0f;
			this.m_tipPenetrationDistance = 0f;
			this.m_basePenetrationDistance = 0f;
			BoneStretchedChain boneStretchedChain = this.penis.TryGetPenetratingHole();
			if (boneStretchedChain == null)
			{
				return;
			}
			this.CalculeDeep(this.inside, worldScale, worldLossyScale, boneStretchedChain.entrada.position, boneStretchedChain.worldOutHoleDirection, false, out this.m_tipPenetrationDistance, out this.m_basePenetrationDistance, out this.m_deepDistance, out this.m_deepMod);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x000199CC File Offset: 0x00017BCC
		private void UpdateDistanceToHole(int lastPenetratingIndex)
		{
			if (this.m_updatingDistanceToHoleID.IsCurrent())
			{
				return;
			}
			this.m_updatingDistanceToHoleID = ForcedFixedUpdateId.current;
			this.m_distanceToHole = float.MinValue;
			this.m_tipoDeHole = -1;
			if (lastPenetratingIndex < this.index)
			{
				return;
			}
			BoneStretchedChain boneStretchedChain = this.penis.TryGetPenetratingHole();
			if (boneStretchedChain == null)
			{
				return;
			}
			if (boneStretchedChain is IVagHole)
			{
				this.m_tipoDeHole = 0;
			}
			else if (boneStretchedChain is IAnusHole)
			{
				this.m_tipoDeHole = 1;
			}
			else
			{
				if (!(boneStretchedChain is IBocaHole))
				{
					throw new ArgumentOutOfRangeException();
				}
				this.m_tipoDeHole = 2;
			}
			Vector3 lastColliderTipWorldPosition = this.m_complementoCollider.GetLastColliderTipWorldPosition();
			if (lastPenetratingIndex == this.index)
			{
				Vector3 vector = -boneStretchedChain.worldOutHoleDirection;
				if (Vector3.Dot(vector, this.worldForward) < 0f)
				{
					this.m_distanceToHole = 0f;
					return;
				}
				Vector3 vector2 = boneStretchedChain.entrada.position - lastColliderTipWorldPosition;
				this.m_distanceToHole = (boneStretchedChain.entrada.position - lastColliderTipWorldPosition).magnitude;
				if (Vector3.Dot(vector, vector2) < 0f)
				{
					this.m_distanceToHole *= -1f;
					return;
				}
			}
			else
			{
				if (lastPenetratingIndex <= this.index)
				{
					throw new ArgumentOutOfRangeException();
				}
				PenisPart nextPart = this.nextPart;
				if (nextPart != null)
				{
					this.m_distanceToHole = (nextPart.m_complementoCollider.GetLastColliderTipWorldPosition() - lastColliderTipWorldPosition).magnitude;
					this.m_distanceToHole += nextPart.m_distanceToHole;
					return;
				}
			}
		}

		// Token: 0x04000466 RID: 1126
		public PenisPart.Config config = new PenisPart.Config();

		// Token: 0x04000467 RID: 1127
		public bool debugPenChanges;

		// Token: 0x04000468 RID: 1128
		public bool debugIgnorandoHoleColliders;

		// Token: 0x04000469 RID: 1129
		[Obsolete("", true)]
		private PenisPointCollider m_PenisPointCollider;

		// Token: 0x0400046A RID: 1130
		private PenisPointCollider m_mainCollider;

		// Token: 0x0400046B RID: 1131
		private PenisPointCollider m_complementoCollider;

		// Token: 0x0400046C RID: 1132
		[ReadOnlyUI]
		[SerializeField]
		private int m_index;

		// Token: 0x0400046D RID: 1133
		public bool hidden;

		// Token: 0x0400046E RID: 1134
		private bool m_activado = true;

		// Token: 0x0400046F RID: 1135
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_bone;

		// Token: 0x04000470 RID: 1136
		private BoneStretchedChain m_currentPenHole;

		// Token: 0x04000471 RID: 1137
		protected PenisPointColliderSmoothScaler m_scaler;

		// Token: 0x04000472 RID: 1138
		private PenisPart.IgnorandoHolesCollisions m_IgnorandoHolesCollisions;

		// Token: 0x04000473 RID: 1139
		private PenisPoint m_puntoConnectadoAEstaParte;

		// Token: 0x04000474 RID: 1140
		private Penetrador m_penis;

		// Token: 0x04000475 RID: 1141
		[SerializeField]
		[ReadOnlyUI]
		private Rigidbody m_Rigidbody;

		// Token: 0x04000476 RID: 1142
		[SerializeField]
		[ReadOnlyUI]
		private int m_tipoDeHole = -1;

		// Token: 0x04000477 RID: 1143
		[SerializeField]
		[ReadOnlyUI]
		private float m_distanceToHole = -1f;

		// Token: 0x04000478 RID: 1144
		[SerializeField]
		[ReadOnlyUI]
		private float m_tipPenetrationDistance;

		// Token: 0x04000479 RID: 1145
		[SerializeField]
		[ReadOnlyUI]
		private float m_basePenetrationDistance;

		// Token: 0x0400047A RID: 1146
		[SerializeField]
		[ReadOnlyUI]
		private float m_deepDistance;

		// Token: 0x0400047B RID: 1147
		[SerializeField]
		[ReadOnlyUI]
		private float m_deepMod;

		// Token: 0x0400047C RID: 1148
		private PenisPartHit m_currentHit;

		// Token: 0x0400047D RID: 1149
		[SerializeField]
		[ReadOnlyUI]
		private PenisPart.PenetrationState m_PenetrationState;

		// Token: 0x0400047E RID: 1150
		private PenisPart.PenetrationState m_LastPenetrationState;

		// Token: 0x0400047F RID: 1151
		[Obsolete("", true)]
		private CapsuleCollider m_trigger;

		// Token: 0x04000480 RID: 1152
		private ForcedFixedUpdateId m_updatingDistanceToHoleID;

		// Token: 0x020001AC RID: 428
		public class IgnorandoHolesCollisions
		{
			// Token: 0x06000F1D RID: 3869 RVA: 0x00033594 File Offset: 0x00031794
			public IgnorandoHolesCollisions(PenisPart owner)
			{
				if (owner == null)
				{
					throw new ArgumentNullException("owner", "owner null reference.");
				}
				this.m_owner = owner;
				this.limpiarIgnoraciones = new Action<PenisPart.IgnorandoHolesCollisions>(PenisPart.IgnorandoHolesCollisions.LimpiarIgnoraciones);
			}

			// Token: 0x06000F1E RID: 3870 RVA: 0x000335EF File Offset: 0x000317EF
			[Obsolete("cancelar invokaciones buguea la estrada a un segundo hole", true)]
			public void CancelarIgnoracionesDelayed()
			{
				if (GlobalUpdater.instancia.CancelarInvocacionPorDelegado(this.limpiarIgnoraciones) && this.debugLogInvokaciones)
				{
					Debug.Log("Cancelacion de ignoracion a Sido ACEPTADA en: " + this.m_owner.name, this.m_owner);
				}
			}

			// Token: 0x06000F1F RID: 3871 RVA: 0x0003362B File Offset: 0x0003182B
			public void InvokarDeInmediato()
			{
				if (GlobalUpdater.instancia.InvokarDeInmediato(this.limpiarIgnoraciones) && this.debugLogInvokaciones)
				{
					Debug.Log("InvokarDeInmediato de ignoracion a Sido ACEPTADA en: " + this.m_owner.name, this.m_owner);
				}
			}

			// Token: 0x06000F20 RID: 3872 RVA: 0x00033667 File Offset: 0x00031867
			public void LimpiarIgnoracionesDelayed()
			{
				this.InvokarDeInmediato();
				if (this.m_ignorando.Count == 0)
				{
					return;
				}
				GlobalUpdater.instancia.Invokar<PenisPart.IgnorandoHolesCollisions>(this.limpiarIgnoraciones, 0.1f, this);
			}

			// Token: 0x06000F21 RID: 3873 RVA: 0x00033694 File Offset: 0x00031894
			private static void LimpiarIgnoraciones(PenisPart.IgnorandoHolesCollisions ignorandoHolesCollisions)
			{
				if (ignorandoHolesCollisions.debugLogInvokaciones)
				{
					Debug.Log("limpiando Ignoraciones INVOKANDO hacia: " + string.Join("|", ignorandoHolesCollisions.m_ignorando.Select((BoneStretchedChain h) => h.name)), ignorandoHolesCollisions.m_owner);
				}
				if (ignorandoHolesCollisions != null)
				{
					ignorandoHolesCollisions.LimpiarIgnoraciones();
				}
			}

			// Token: 0x06000F22 RID: 3874 RVA: 0x000336FC File Offset: 0x000318FC
			public void LimpiarIgnoraciones()
			{
				if (this.m_ignorando.Count == 0)
				{
					return;
				}
				foreach (BoneStretchedChain boneStretchedChain in this.m_ignorando)
				{
					this.ignorarOtrosColliders(boneStretchedChain, false);
				}
				this.m_ignorando.Clear();
			}

			// Token: 0x06000F23 RID: 3875 RVA: 0x0003376C File Offset: 0x0003196C
			public void IgnorarOtrosColliders(BoneStretchedChain hole, bool isEntering)
			{
				if (isEntering)
				{
					this.InvokarDeInmediato();
				}
				if (this.m_ignorando.Contains(hole))
				{
					return;
				}
				if (this.ignorarOtrosColliders(hole, true))
				{
					this.m_ignorando.Add(hole);
				}
			}

			// Token: 0x06000F24 RID: 3876 RVA: 0x000337A0 File Offset: 0x000319A0
			private bool ignorarOtrosColliders(BoneStretchedChain hole, bool ignorar)
			{
				bool flag;
				try
				{
					if (hole == null)
					{
						Debug.LogError("tratando de ignorar collisiones contra hole que ya fue destruido");
						flag = false;
					}
					else
					{
						IFemaleHole femaleHole = hole as IFemaleHole;
						if (femaleHole == null)
						{
							flag = false;
						}
						else
						{
							IFemaleChar femaleChar = femaleHole.femaleChar;
							if (femaleChar == null)
							{
								flag = false;
							}
							else if (femaleChar as Object == null)
							{
								Debug.LogError("tratando de ignorar collisiones contra female hole que ya fue destruido");
								flag = false;
							}
							else
							{
								femaleChar.IgnoreCollisions(this.m_owner.m_mainCollider.colliders, ignorar);
								femaleChar.IgnoreCollisions(this.m_owner.m_complementoCollider.colliders, ignorar);
								femaleHole.ObtenerHolesCollidersDelCharExcluyendo(this.m_temp, null);
								ExtendedMonoBehaviour.IgnorarCollisiones(this.m_temp, this.m_owner.m_mainCollider.colliders, ignorar);
								ExtendedMonoBehaviour.IgnorarCollisiones(this.m_temp, this.m_owner.m_complementoCollider.colliders, ignorar);
								if (ignorar)
								{
									if (femaleHole is IVagHole)
									{
										femaleChar.IgnoreCollisionsAgaintsVagLabia(this.m_owner.m_mainCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsVag(this.m_owner.m_mainCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsVagLabia(this.m_owner.m_complementoCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsVag(this.m_owner.m_complementoCollider.colliders, false);
									}
									else if (femaleHole is IAnusHole)
									{
										femaleChar.IgnoreCollisionsAgaintsGlutenAperture(this.m_owner.m_mainCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsAnus(this.m_owner.m_mainCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsGlutenAperture(this.m_owner.m_complementoCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsAnus(this.m_owner.m_complementoCollider.colliders, false);
									}
									else if (femaleHole is IBocaHole)
									{
										femaleChar.IgnoreCollisionsAgaintsLabios(this.m_owner.m_mainCollider.collidersV2, false);
										femaleChar.IgnoreCollisionsAgaintsBoca(this.m_owner.m_mainCollider.colliders, false);
										femaleChar.IgnoreCollisionsAgaintsLabios(this.m_owner.m_complementoCollider.collidersV2, false);
										femaleChar.IgnoreCollisionsAgaintsBoca(this.m_owner.m_complementoCollider.colliders, false);
									}
									else
									{
										string text = "No se save q tipo de hole es ";
										Object @object = femaleHole as Object;
										Debug.LogError(text + ((@object != null) ? @object.name : null));
									}
								}
								flag = true;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Error tratando de ignorar collider de hole");
					Debug.LogException(ex);
					flag = false;
				}
				finally
				{
					this.m_temp.Clear();
				}
				return flag;
			}

			// Token: 0x06000F25 RID: 3877 RVA: 0x00033A34 File Offset: 0x00031C34
			public void DebugEstadoDeIgnoracion()
			{
				if (this.m_ignorando.Count == 0)
				{
					Debug.Log(this.m_owner.name + " NO esta ignorando ningun hole.", this.m_owner);
					return;
				}
				List<Collider> list = new List<Collider>();
				foreach (BoneStretchedChain boneStretchedChain in this.m_ignorando)
				{
					foreach (Collider collider in boneStretchedChain.GetComponentsInChildren<Collider>())
					{
						if (Physics.GetIgnoreCollision(this.m_owner.m_mainCollider.mainCollider, collider) || Physics.GetIgnoreCollision(this.m_owner.m_complementoCollider.mainCollider, collider))
						{
							list.Add(collider);
						}
					}
				}
				if (list.Count > 0)
				{
					Debug.Log(this.m_owner.name + " ignorando: " + string.Join(" | ", list.Select((Collider h) => h.name)), this.m_owner);
					return;
				}
				Debug.Log(this.m_owner.name + " ignorando holes, pero ningun collider de estos holes: " + string.Join(" | ", this.m_ignorando.Select((BoneStretchedChain h) => h.name)), this.m_owner);
			}

			// Token: 0x040009A6 RID: 2470
			public bool debugLogInvokaciones;

			// Token: 0x040009A7 RID: 2471
			private Action<PenisPart.IgnorandoHolesCollisions> limpiarIgnoraciones;

			// Token: 0x040009A8 RID: 2472
			private PenisPart m_owner;

			// Token: 0x040009A9 RID: 2473
			private HashSet<BoneStretchedChain> m_ignorando = new HashSet<BoneStretchedChain>();

			// Token: 0x040009AA RID: 2474
			private List<Collider> m_temp = new List<Collider>();
		}

		// Token: 0x020001AD RID: 429
		[Serializable]
		public class Config
		{
			// Token: 0x040009AB RID: 2475
			public bool freeAngularMotionsOnPenetracion;

			// Token: 0x040009AC RID: 2476
			public float maxColRadiusWhenCloseToHoleVag = 0.1f;

			// Token: 0x040009AD RID: 2477
			public float maxColRadiusWhenCloseToHoleAnus = 0.05f;

			// Token: 0x040009AE RID: 2478
			public float maxColRadiusWhenCloseToHoleFace = 1f;

			// Token: 0x040009AF RID: 2479
			public float colRadiusInfluenceOnCollision = 1f;

			// Token: 0x040009B0 RID: 2480
			public float colRadiusInfluenceOnHelperVag = 1f;

			// Token: 0x040009B1 RID: 2481
			public float colRadiusInfluenceOnHelperAnus = 1f;

			// Token: 0x040009B2 RID: 2482
			public float colRadiusInfluenceOnHelperFace = 0.2f;
		}

		// Token: 0x020001AE RID: 430
		public enum PenetrationState
		{
			// Token: 0x040009B4 RID: 2484
			fuera,
			// Token: 0x040009B5 RID: 2485
			adentro,
			// Token: 0x040009B6 RID: 2486
			adentroDesactivado
		}
	}
}
