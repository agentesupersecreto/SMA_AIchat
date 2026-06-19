using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x02000169 RID: 361
	public abstract class GuiaVisualInteractable : CustomUpdatedMonobehaviourBase, ISostenibleObjetoEvents, ISostenibleObjeto
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0002600B File Offset: 0x0002420B
		public bool siendoSostenido
		{
			get
			{
				return this.m_sostenidoPor != null;
			}
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00026019 File Offset: 0x00024219
		void ISostenibleObjetoEvents.OnSostenido(AgarranteObjeto por)
		{
			this.m_sostenidoPor = por;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00026022 File Offset: 0x00024222
		void ISostenibleObjetoEvents.OnSoltado(AgarranteObjeto por)
		{
			if (this.m_sostenidoPor == por)
			{
				this.m_sostenidoPor = null;
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600083E RID: 2110 RVA: 0x0002603C File Offset: 0x0002423C
		// (remove) Token: 0x0600083F RID: 2111 RVA: 0x00026074 File Offset: 0x00024274
		public event GuiaVisualInteractable.OnWeigthChangedHandler weigthChanged;

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x00006047 File Offset: 0x00004247
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates1);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x000260A9 File Offset: 0x000242A9
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000842 RID: 2114
		public abstract bool interactable { get; }

		// Token: 0x06000843 RID: 2115 RVA: 0x00005F51 File Offset: 0x00004151
		public virtual bool PuedeEfectuarInteraccionPara(AgarranteObjeto agarrante)
		{
			return true;
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x000260B2 File Offset: 0x000242B2
		public bool isBinded
		{
			get
			{
				return this.m_currentAgarradoPor != null;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x000260C0 File Offset: 0x000242C0
		public float currentRecorridoWeigth
		{
			get
			{
				return this.m_currentRecorridoWeigth;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x000260C8 File Offset: 0x000242C8
		public bool siendoAgarrada
		{
			get
			{
				return this.m_siendoAgarrada;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000847 RID: 2119
		protected abstract bool interactuarDespuesDeSoltar { get; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000848 RID: 2120
		protected abstract float recorridoWeigthToInteract { get; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000849 RID: 2121
		protected abstract float agarradoWeigthToInteract { get; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600084A RID: 2122
		protected abstract bool agarrarObjetoPhysicoToInteract { get; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x000260D0 File Offset: 0x000242D0
		public AgarranteObjeto currentAgarradoPor
		{
			get
			{
				return this.m_currentAgarradoPor;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x000260D8 File Offset: 0x000242D8
		public ICharacter character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x00005A42 File Offset: 0x00003C42
		bool ISostenibleObjeto.siendoSostenido
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000260E0 File Offset: 0x000242E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x000260F0 File Offset: 0x000242F0
		public void Init(Renderer guiaVisualPrefab, GuiaVisualInteractable.Config Config, ModificadorDeBool drawGuiaVisualOnTop, Vector3 triggerCenter, params Transform[] ExtraPuntos)
		{
			if (guiaVisualPrefab == null)
			{
				throw new ArgumentNullException("guiaVisualPrefab", "guiaVisualPrefab null reference.");
			}
			if (drawGuiaVisualOnTop == null)
			{
				throw new ArgumentNullException("drawGuiaVisualOnTop", "drawGuiaVisualOnTop null reference.");
			}
			if (ExtraPuntos == null || ExtraPuntos.Length <= 1)
			{
				throw new InvalidOperationException();
			}
			this.m_DrawGuiaVisualOnTop = drawGuiaVisualOnTop;
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_guiaVisual = Object.Instantiate<Renderer>(guiaVisualPrefab, base.transform);
			this.m_guiaVisual.gameObject.SetActive(false);
			this.m_guiaVisual.gameObject.layer = ConfiguracionGlobal.layersStatic.transparentFX;
			this.m_guiaVisual.transform.localPosition = Vector3.zero;
			this.m_guiaVisual.transform.localRotation = Quaternion.identity;
			this.m_guiaVisual.transform.localScale = Vector3.one;
			this.m_guiaVisualMat = this.m_guiaVisual.material;
			this.m_guiaVisual.material = this.m_guiaVisualMat;
			this.m_guiaVisualMat.color = Color.red;
			this.config = Config;
			this.start = ExtraPuntos.First<Transform>();
			this.end = ExtraPuntos.Last<Transform>();
			this.puntos.AddRange(ExtraPuntos);
			this.m_trigger = this.GetComponentNotNull<SphereCollider>();
			this.m_triggerCenter = triggerCenter;
			base.transform.SetPositionAndRotation(this.start.position, this.start.rotation);
			this.ClearAgarrando();
			base.ManualStart();
			this.UpdateTrigger();
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00026272 File Offset: 0x00024472
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00024829 File Offset: 0x00022A29
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00026287 File Offset: 0x00024487
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ClearAgarrando();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00026298 File Offset: 0x00024498
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool drawGuiaVisualOnTop = this.m_DrawGuiaVisualOnTop;
			if (drawGuiaVisualOnTop != null)
			{
				drawGuiaVisualOnTop.TryRemoverDeOwner(true);
			}
			this.m_DrawGuiaVisualOnTop = null;
			if (this.m_guiaVisual != null)
			{
				Object.Destroy(this.m_guiaVisual);
			}
			if (this.m_guiaVisualMat != null)
			{
				Object.Destroy(this.m_guiaVisualMat);
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x000262F8 File Offset: 0x000244F8
		public void UpdateTrigger()
		{
			this.m_trigger.isTrigger = true;
			this.m_trigger.radius = this.config.triggerRaidus * this.m_character.escala;
			this.m_trigger.center = this.m_triggerCenter;
			this.m_trigger.gameObject.layer = ConfiguracionGlobal.layersStatic.holeExtras;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00026360 File Offset: 0x00024560
		protected virtual void ClearAgarrando()
		{
			ModificadorDeBool puedeAgarrarObjetoPhysico = this.m_puedeAgarrarObjetoPhysico;
			if (puedeAgarrarObjetoPhysico != null)
			{
				puedeAgarrarObjetoPhysico.TryRemoverDeOwner(true);
			}
			this.m_currentAgarradoPor = null;
			if (this.start == null)
			{
				this.m_currentProyectedPoint = Vector3.zero;
			}
			else
			{
				this.m_currentProyectedPoint = this.start.position;
			}
			this.m_currentRecorridoWeigth = 0f;
			this.m_lastWeigth = 0f;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x000263C9 File Offset: 0x000245C9
		private void OnTriggerEnter(Collider other)
		{
			this.OnTrigger(other);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x000263C9 File Offset: 0x000245C9
		private void OnTriggerStay(Collider other)
		{
			this.OnTrigger(other);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x000263D4 File Offset: 0x000245D4
		private void OnTrigger(Collider other)
		{
			if (this.isBinded || !this.interactable)
			{
				return;
			}
			if (other.gameObject.layer != ConfiguracionGlobal.layersStatic.touchingHand)
			{
				return;
			}
			if (this.siendoSostenido)
			{
				return;
			}
			this.m_guiaVisualMat.color = Color.green;
			Rigidbody attachedRigidbody = other.attachedRigidbody;
			AgarranteObjeto agarranteObjeto = ((attachedRigidbody != null) ? attachedRigidbody.GetComponent<AgarranteObjeto>() : null);
			if (agarranteObjeto == null || agarranteObjeto.owner == null)
			{
				return;
			}
			IAgarranteCharacter owner = agarranteObjeto.owner;
			if (!owner.listoParaAgarrar || !owner.ListoParaAgarrarCon(agarranteObjeto))
			{
				return;
			}
			if (agarranteObjeto.sosteniendo)
			{
				return;
			}
			if (!agarranteObjeto.EstaAgarrando(this.agarrarObjetoPhysicoToInteract, false, new float?(this.agarradoWeigthToInteract)))
			{
				return;
			}
			if (Vector3.Distance(agarranteObjeto.startAgarrandoPosicion, base.transform.position) > this.config.guiaRadius * this.m_character.escala)
			{
				return;
			}
			this.m_currentAgarradoPor = agarranteObjeto;
			this.m_puedeAgarrarObjetoPhysico = this.m_currentAgarradoPor.puedeAgarrandoPhysicsAND.ObtenerModificadorNotNull(this);
			this.m_puedeAgarrarObjetoPhysico.valor.valor = false;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x000264E4 File Offset: 0x000246E4
		public void ForzarAgarrante(AgarranteObjeto forzado)
		{
			if (this.isBinded)
			{
				this.ClearAgarrando();
			}
			this.m_currentAgarradoPor = forzado;
			this.m_puedeAgarrarObjetoPhysico = this.m_currentAgarradoPor.puedeAgarrandoPhysicsAND.ObtenerModificadorNotNull(this);
			this.m_puedeAgarrarObjetoPhysico.valor.valor = false;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00026523 File Offset: 0x00024723
		public override void OnUpdateEvent1()
		{
			if (this.interactable)
			{
				this.m_guiaVisualMat.color = Color.red;
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00026540 File Offset: 0x00024740
		public override void OnUpdateEvent2()
		{
			bool flag = false;
			AgarranteObjeto currentAgarradoPor = this.m_currentAgarradoPor;
			try
			{
				base.transform.SetPositionAndRotation(this.start.position, this.start.rotation);
				if (!this.m_updateGuiaStateCoolDown.isOn)
				{
					MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
					IAgarranteCharacter agarranteCharacter;
					if (current == null)
					{
						agarranteCharacter = null;
					}
					else
					{
						Character character = current.character;
						agarranteCharacter = ((character != null) ? character.GetComponent<IAgarranteCharacter>() : null);
					}
					IAgarranteCharacter agarranteCharacter2 = agarranteCharacter;
					bool valueOrDefault = ((currentAgarradoPor != null) ? new bool?(currentAgarradoPor.sosteniendo) : null).GetValueOrDefault();
					if (!this.siendoSostenido && !valueOrDefault && ((agarranteCharacter2 != null) ? new bool?(agarranteCharacter2.listoParaAgarrar) : null).GetValueOrDefault() && this.interactable)
					{
						if (!this.m_guiaVisual.gameObject.activeSelf)
						{
							this.m_guiaVisual.gameObject.SetActive(true);
						}
						this.m_DrawGuiaVisualOnTop.valor.valor = true;
						if (!this.m_trigger.enabled)
						{
							this.m_trigger.enabled = true;
						}
					}
					else
					{
						if (this.m_guiaVisual.gameObject.activeSelf)
						{
							this.m_guiaVisual.gameObject.SetActive(false);
						}
						this.m_DrawGuiaVisualOnTop.valor.valor = false;
						if (this.m_trigger.enabled)
						{
							this.m_trigger.enabled = false;
						}
					}
					this.m_updateGuiaStateCoolDown.ApplyNext(0.333f.Random(0.25f));
				}
				if (!this.isBinded || !this.m_currentAgarradoPor.EstaAgarrando(this.agarrarObjetoPhysicoToInteract, false, new float?(this.agarradoWeigthToInteract)))
				{
					if (this.m_currentRecorridoWeigth >= this.recorridoWeigthToInteract)
					{
						flag = true;
					}
					ModificadorDeBool puedeAgarrarObjetoPhysico = this.m_puedeAgarrarObjetoPhysico;
					if (puedeAgarrarObjetoPhysico != null)
					{
						puedeAgarrarObjetoPhysico.TryRemoverDeOwner(true);
					}
					this.m_currentAgarradoPor = null;
					this.m_currentRecorridoWeigth = Mathf.MoveTowards(this.m_currentRecorridoWeigth, 0f, Time.deltaTime * 2f);
					this.m_currentProyectedPoint = Vector3.MoveTowards(this.m_currentProyectedPoint, this.start.position, Time.deltaTime * 2f);
					this.UpdateInteraction();
					if (this.m_currentRecorridoWeigth <= 0f)
					{
						this.m_siendoAgarrada = false;
					}
				}
				else
				{
					this.m_guiaVisualMat.color = Color.cyan;
					float chainLargo = GuiaVisualInteractable.GetChainLargo(this.puntos);
					float num;
					Vector3 vector;
					GuiaVisualInteractable.GetTrayecto(chainLargo, this.start, this.end, this.m_currentAgarradoPor.currentAgarrandoPosicionCentral, this.puntos, out num, out vector);
					this.m_currentRecorridoWeigth = ((chainLargo == 0f) ? 1f : Mathf.InverseLerp(0f, chainLargo, num));
					this.m_currentProyectedPoint = vector;
					this.m_siendoAgarrada = true;
					this.UpdateInteraction();
					if (this.m_currentRecorridoWeigth >= this.recorridoWeigthToInteract && !this.interactuarDespuesDeSoltar)
					{
						flag = true;
					}
				}
				this.m_guiaVisual.transform.position = this.m_currentProyectedPoint;
				this.m_guiaVisual.transform.localScale = Vector3.one * this.config.guiaVisualRadius * (this.config.ignoreCharacterScale ? 1f : this.m_character.escala);
				if (flag && this.m_interactuando == null && this.PuedeEfectuarInteraccionPara(currentAgarradoPor))
				{
					this.m_interactuando = base.StartCoroutine(this.efectuarInteraccion(currentAgarradoPor));
				}
			}
			finally
			{
				if (this.m_lastWeigth != this.m_currentRecorridoWeigth)
				{
					this.OnWeigthChanged(this.m_lastWeigth, this.m_currentRecorridoWeigth);
				}
				this.m_lastWeigth = this.m_currentRecorridoWeigth;
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x000268DC File Offset: 0x00024ADC
		public IEnumerator EfectuarInteraccion()
		{
			while (this.m_interactuando != null)
			{
				yield return null;
			}
			yield return this.efectuarInteraccion(this.m_currentAgarradoPor);
			yield break;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x000268EB File Offset: 0x00024AEB
		private IEnumerator efectuarInteraccion(AgarranteObjeto agarrante)
		{
			yield return this.EfectuarInteraccion(agarrante);
			this.m_interactuando = null;
			yield break;
		}

		// Token: 0x0600085E RID: 2142
		protected abstract IEnumerator EfectuarInteraccion(AgarranteObjeto agarrante);

		// Token: 0x0600085F RID: 2143 RVA: 0x00026904 File Offset: 0x00024B04
		public void SimularPosicion(float weigth, out float totalDistance, out Vector3 posicion, out Vector3 normal, out Vector3 up)
		{
			weigth = Mathf.Clamp01(weigth);
			totalDistance = GuiaVisualInteractable.GetChainLargo(this.puntos);
			if (weigth == 0f)
			{
				posicion = this.start.position;
				normal = this.start.forward;
				up = this.start.up;
				return;
			}
			if (weigth == 1f)
			{
				posicion = this.end.position;
				normal = this.end.forward;
				up = this.start.up;
				return;
			}
			float num = totalDistance * weigth;
			Transform transform = this.puntos[0];
			for (int i = 1; i < this.puntos.Count; i++)
			{
				Transform transform2 = this.puntos[i];
				float num2 = Vector3.Distance(transform.position, transform2.position);
				if (num2 >= num)
				{
					float num3 = Mathf.Clamp01(num / num2);
					posicion = Vector3.Lerp(transform.position, transform2.position, num3);
					normal = Vector3.Lerp(transform.forward, transform2.forward, num3);
					up = Vector3.Lerp(transform.up, transform2.up, num3);
					return;
				}
				num -= num2;
				transform = transform2;
			}
			posicion = this.end.position;
			normal = this.end.forward;
			up = this.end.up;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00026A8A File Offset: 0x00024C8A
		private void OnWeigthChanged(float last, float current)
		{
			GuiaVisualInteractable.OnWeigthChangedHandler onWeigthChangedHandler = this.weigthChanged;
			if (onWeigthChangedHandler == null)
			{
				return;
			}
			onWeigthChangedHandler(last, current, this.isBinded && this.m_currentAgarradoPor.EstaAgarrando(this.agarrarObjetoPhysicoToInteract, false, new float?(this.agarradoWeigthToInteract)), this);
		}

		// Token: 0x06000861 RID: 2145
		public abstract void UpdateInteraction();

		// Token: 0x06000862 RID: 2146 RVA: 0x00026AC8 File Offset: 0x00024CC8
		private static void GetTrayecto(float distanciaTotal, Transform start, Transform end, Vector3 currentPosicionAgarrada, IReadOnlyList<Transform> puntos, out float distanciaRecorrida, out Vector3 proyectedRecorridoPoint)
		{
			proyectedRecorridoPoint = Vector3.zero;
			distanciaRecorrida = 0f;
			int num = Math3d.PointOnWhichSideOfLineSegmentProyected(start.position, end.position, currentPosicionAgarrada);
			switch (num)
			{
			case 0:
			{
				Transform transform = puntos[0];
				for (int i = 1; i < puntos.Count; i++)
				{
					Transform transform2 = puntos[i];
					int num2 = Math3d.PointOnWhichSideOfLineSegmentProyected(transform.position, transform2.position, currentPosicionAgarrada);
					if (num2 == 0 || num2 == 1)
					{
						proyectedRecorridoPoint = Math3d.ProjectPointOnLineSegment(transform.position, transform2.position, currentPosicionAgarrada);
						distanciaRecorrida += Vector3.Distance(transform.position, proyectedRecorridoPoint);
						return;
					}
					distanciaRecorrida += Vector3.Distance(transform.position, transform2.position);
					transform = transform2;
				}
				return;
			}
			case 1:
				distanciaRecorrida = 0f;
				proyectedRecorridoPoint = start.position;
				return;
			case 2:
				distanciaRecorrida = distanciaTotal;
				proyectedRecorridoPoint = end.position;
				return;
			default:
				throw new ArgumentOutOfRangeException(num.ToString());
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00026BDC File Offset: 0x00024DDC
		private static float GetChainLargo(IReadOnlyList<Transform> puntos)
		{
			float num = 0f;
			Transform transform = puntos[0];
			for (int i = 1; i < puntos.Count; i++)
			{
				Transform transform2 = puntos[i];
				num += Vector3.Distance(transform.position, transform2.position);
				transform = transform2;
			}
			return num;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00026C28 File Offset: 0x00024E28
		private void OnDrawGizmosSelected()
		{
			if (this.isBinded)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(this.m_currentAgarradoPor.currentAgarrandoPosicionCentral, this.m_currentProyectedPoint);
				Gizmos.color = Color.yellow;
				Transform transform = this.puntos[0];
				for (int i = 1; i < this.puntos.Count; i++)
				{
					Transform transform2 = this.puntos[i];
					Gizmos.DrawLine(transform.position, transform2.position);
					transform = transform2;
				}
			}
		}

		// Token: 0x04000672 RID: 1650
		[ReadOnlyUI]
		[SerializeField]
		private AgarranteObjeto m_sostenidoPor;

		// Token: 0x04000674 RID: 1652
		public GuiaVisualInteractable.Config config = new GuiaVisualInteractable.Config();

		// Token: 0x04000675 RID: 1653
		public Transform start;

		// Token: 0x04000676 RID: 1654
		public Transform end;

		// Token: 0x04000677 RID: 1655
		public List<Transform> puntos = new List<Transform>();

		// Token: 0x04000678 RID: 1656
		private SphereCollider m_trigger;

		// Token: 0x04000679 RID: 1657
		private Vector3 m_triggerCenter;

		// Token: 0x0400067A RID: 1658
		private float m_lastWeigth;

		// Token: 0x0400067B RID: 1659
		private CoolDown m_updateGuiaStateCoolDown = new CoolDown();

		// Token: 0x0400067C RID: 1660
		[ReadOnlyUI]
		[SerializeField]
		private bool m_siendoAgarrada;

		// Token: 0x0400067D RID: 1661
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentRecorridoWeigth;

		// Token: 0x0400067E RID: 1662
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentProyectedPoint;

		// Token: 0x0400067F RID: 1663
		[ReadOnlyUI]
		[SerializeField]
		private AgarranteObjeto m_currentAgarradoPor;

		// Token: 0x04000680 RID: 1664
		[ReadOnlyUI]
		[SerializeField]
		private Renderer m_guiaVisual;

		// Token: 0x04000681 RID: 1665
		[ReadOnlyUI]
		[SerializeField]
		private Material m_guiaVisualMat;

		// Token: 0x04000682 RID: 1666
		[SerializeReference]
		private ModificadorDeBool m_DrawGuiaVisualOnTop;

		// Token: 0x04000683 RID: 1667
		private Coroutine m_interactuando;

		// Token: 0x04000684 RID: 1668
		private ICharacter m_character;

		// Token: 0x04000685 RID: 1669
		[SerializeField]
		private ModificadorDeBool m_puedeAgarrarObjetoPhysico;

		// Token: 0x0200016A RID: 362
		// (Invoke) Token: 0x06000867 RID: 2151
		public delegate void OnWeigthChangedHandler(float last, float current, bool siendoAgarrada, GuiaVisualInteractable sender);

		// Token: 0x0200016B RID: 363
		[Serializable]
		public class Config
		{
			// Token: 0x04000686 RID: 1670
			public bool ignoreCharacterScale;

			// Token: 0x04000687 RID: 1671
			public float triggerRaidus = 0.0666f;

			// Token: 0x04000688 RID: 1672
			public float guiaRadius = 0.0666f;

			// Token: 0x04000689 RID: 1673
			public float guiaVisualRadius = 0.015f;
		}
	}
}
