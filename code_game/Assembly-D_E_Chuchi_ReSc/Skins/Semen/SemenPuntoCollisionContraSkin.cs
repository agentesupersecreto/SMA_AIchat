using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets.TValle.BeachGirl.Runtime.Skins.Physics;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.Triangles.SkinningShaping;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Skins;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Singletones;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen
{
	// Token: 0x02000085 RID: 133
	[RequireComponent(typeof(SemenPunto))]
	public class SemenPuntoCollisionContraSkin : CustomMonobehaviour, PedidoDePhyscisBakeDeSkin.IUser
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000341 RID: 833 RVA: 0x0000C534 File Offset: 0x0000A734
		// (remove) Token: 0x06000342 RID: 834 RVA: 0x0000C56C File Offset: 0x0000A76C
		public event Action<SemenPuntoCollisionContraSkin> onAttached;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000343 RID: 835 RVA: 0x0000C5A4 File Offset: 0x0000A7A4
		// (remove) Token: 0x06000344 RID: 836 RVA: 0x0000C5DC File Offset: 0x0000A7DC
		public event Action<SemenPuntoCollisionContraSkin> onNextAttached;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000345 RID: 837 RVA: 0x0000C614 File Offset: 0x0000A814
		// (remove) Token: 0x06000346 RID: 838 RVA: 0x0000C64C File Offset: 0x0000A84C
		public event Action<SemenPuntoCollisionContraSkin> onNextBrokenAfterAttached;

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0000C681 File Offset: 0x0000A881
		public bool isAttachedToSkin
		{
			get
			{
				return this.m_TriangleAttachmentUser != null;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0000C68F File Offset: 0x0000A88F
		public bool isBindedToSkin
		{
			get
			{
				return this.m_bindedTo != null;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0000C69D File Offset: 0x0000A89D
		public SemenPunto semenPunto
		{
			get
			{
				return this.m_SemenPunto;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0000C6A5 File Offset: 0x0000A8A5
		public Skin attachedTo
		{
			get
			{
				return this.currentTriangle.skin;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000C6B2 File Offset: 0x0000A8B2
		public HitSkinBasica bindedTo
		{
			get
			{
				return this.m_bindedTo;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000C6BA File Offset: 0x0000A8BA
		public SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser
		{
			get
			{
				return this.m_TriangleAttachmentUser;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000C6C2 File Offset: 0x0000A8C2
		public IReadOnlyList<BodyPartEnum> impactadas
		{
			get
			{
				return this.m_impactadas;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000C6CC File Offset: 0x0000A8CC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SemenPunto = base.GetComponent<SemenPunto>();
			if (!this.m_SemenPunto.isAwaken)
			{
				this.m_SemenPunto.ManualAwake();
			}
			this.m_SonidoProductor = base.GetComponent<SonidoProductor>();
			this.m_SemenPunto.onBinding += this.M_SemenPunto_onBinding;
			this.m_SemenPunto.onUnBinded += this.M_SemenPunto_onUnBinded;
			this.m_SemenPunto.onBreakRested += this.M_SemenPunto_onBreakRested;
			this.m_SemenPunto.collisionBroadCaster.onCollisionEnter += this.CollisionBroadCaster_onCollisionEnter;
			this.m_ReproductorDeSonidos = Singleton<ReproductorDeSonidosDeWaterDrops>.instance.reproductor;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000C780 File Offset: 0x0000A980
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.RegistrarSemen(true);
			this.m_duracionModificador = this.m_SemenPunto.duracionModificador.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000C7A6 File Offset: 0x0000A9A6
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.RegistrarSemen(false);
			ModificadorDeFloat duracionModificador = this.m_duracionModificador;
			if (duracionModificador != null)
			{
				duracionModificador.TryRemoverDeOwner(true);
			}
			this.m_duracionModificador = null;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_SemenPunto.onBinding -= this.M_SemenPunto_onBinding;
			this.m_SemenPunto.onUnBinded -= this.M_SemenPunto_onUnBinded;
			this.m_SemenPunto.onBreakRested -= this.M_SemenPunto_onBreakRested;
			this.m_SemenPunto.collisionBroadCaster.onCollisionEnter -= this.CollisionBroadCaster_onCollisionEnter;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000C848 File Offset: 0x0000AA48
		public bool IsNextNullOrAttachedToSameSkin()
		{
			SemenPuntoCollisionContraSkin semenPuntoCollisionContraSkin;
			return this.m_SemenPunto.next == null || !this.m_SemenPunto.next.TryGetComponent<SemenPuntoCollisionContraSkin>(out semenPuntoCollisionContraSkin) || (semenPuntoCollisionContraSkin.isAttachedToSkin && semenPuntoCollisionContraSkin.attachedTo == this.attachedTo);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000C89C File Offset: 0x0000AA9C
		private void CollisionBroadCaster_onCollisionEnter(Collision arg1, Rigidbody arg2, Collider arg3)
		{
			if (this.m_SemenPunto.isBinded || this.m_SemenPunto.isManualMode)
			{
				return;
			}
			float magnitude = arg1.relativeVelocity.magnitude;
			if (this.m_ReproductorDeSonidos.EnRangoMinimo(magnitude) && arg1.contactCount > 0)
			{
				this.m_ReproductorDeSonidos.RegistrarPedido(this.m_SonidoProductor, arg1.GetContact(0).point, magnitude);
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000C90C File Offset: 0x0000AB0C
		private void M_SemenPunto_onBinding(Collision collision, Collider arg1, SemenPunto.OnBindingEventArgs arg2, SemenPunto arg3)
		{
			if (this.isAttachedToSkin)
			{
				Debug.LogError("no deberia intentar hacer bind, si este semen ya esta atado a triangle skin", this);
				return;
			}
			if (this.isBindedToSkin)
			{
				Debug.LogError("no deberia intentar hacer bind, si este semen ya esta atado a skin", this);
				return;
			}
			if (MaleHitSkinBasica.ObtenerSkinDeCollider(arg1) != null)
			{
				arg2.AbortV2(false, true, 0.05f);
				return;
			}
			if (this.m_failingTime > 1f)
			{
				this.m_failingTime = 0f;
				arg2.AbortV2(false, true, 1f);
				return;
			}
			if (Random.value > this.bindProc)
			{
				arg2.AbortV2(false, false, 1f);
				return;
			}
			HitSkinBasica hitSkinBasica = HitSkinBasica.ObtenerSkinDeCollider(arg1);
			if (hitSkinBasica == null)
			{
				return;
			}
			this.m_impactadas.Clear();
			this.m_VisualSkins.Clear();
			Vector3? vector = new Vector3?(this.m_SemenPunto.stepVelocity.metrosPorSegundo);
			Vector3? vector2 = new Vector3?(this.m_SemenPunto.body.transform.position);
			if (vector.Value.sqrMagnitude < 0.0001f)
			{
				vector = null;
				vector2 = null;
			}
			RaycastHit raycastHit;
			if (!hitSkinBasica.TryCalcularPartesImpactadasDeCollision(collision, arg1, out raycastHit, this.m_impactadas, vector, vector2, false))
			{
				arg2.AbortV2(false, false, 1f);
				return;
			}
			if (this.m_impactadas.Contains(BodyPartEnum.ojoInterno_L) || this.m_impactadas.Contains(BodyPartEnum.ojoInterno_R))
			{
				arg2.AbortV2(false, true, 1f);
				return;
			}
			if (Random.value > 0.1f && this.m_impactadas.ContieneOrganHole())
			{
				arg2.AbortV2(false, true, 1f);
				return;
			}
			if (Random.value > 0.333f && this.m_impactadas.ContieneCloseOrganHole())
			{
				arg2.AbortV2(false, true, 1f);
				return;
			}
			IRopaManager componentEnRoot = hitSkinBasica.GetComponentEnRoot(false);
			if (componentEnRoot != null)
			{
				try
				{
					componentEnRoot.ObtenerPiezasIDs(SemenPuntoCollisionContraSkin.m_piezasCubriendoTEMP, true);
					for (int i = 0; i < SemenPuntoCollisionContraSkin.m_piezasCubriendoTEMP.Count; i++)
					{
						PiezaDeRopaBase piezaDeRopaBase;
						if (componentEnRoot.piezasPuestasPorId.TryGetValue(SemenPuntoCollisionContraSkin.m_piezasCubriendoTEMP[i], out piezaDeRopaBase) && piezaDeRopaBase.isCookable && piezaDeRopaBase.CheckIfIsTriangleAttachable())
						{
							this.m_VisualSkins.Add(piezaDeRopaBase);
						}
					}
				}
				finally
				{
					SemenPuntoCollisionContraSkin.m_piezasCubriendoTEMP.Clear();
				}
			}
			if (hitSkinBasica.visualSkin != null && hitSkinBasica.visualSkin.isActiveAndEnabled && hitSkinBasica.visualSkin.isCookable && hitSkinBasica.visualSkin.CheckIfIsTriangleAttachable() && !this.m_VisualSkins.Contains(hitSkinBasica.visualSkin))
			{
				this.m_VisualSkins.Add(hitSkinBasica.visualSkin);
			}
			if (this.m_VisualSkins.Count == 0)
			{
				arg2.AbortV2(false, true, 1f);
				return;
			}
			if (arg1 is MeshCollider && !((MeshCollider)arg1).convex)
			{
				this.m_HitDirection = -raycastHit.normal;
				this.m_HitPoint = raycastHit.point;
			}
			else
			{
				this.m_HitDirection = ((vector != null) ? vector.Value : (-raycastHit.normal));
				this.m_HitPoint = ((vector2 != null) ? vector2.Value : raycastHit.point);
			}
			arg2.ForceBind();
			this.m_bindedTo = hitSkinBasica;
			this.m_bindedToVelocity = this.m_SemenPunto.stepVelocity.metrosPorSegundo;
			for (int j = 0; j < this.m_VisualSkins.Count; j++)
			{
				this.m_VisualSkins[j].Cook(this, false, j);
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000CC90 File Offset: 0x0000AE90
		void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
		{
			if (!this.m_SemenPunto.isManualMode && !(this == null))
			{
				SemenPunto semenPunto = this.m_SemenPunto;
				if (!(((semenPunto != null) ? semenPunto.bodyTransform : null) == null))
				{
					int num = Convert.ToInt32(extraData, CultureInfo.InvariantCulture);
					PiezaDeRopaBase piezaDeRopaBase = cooked as PiezaDeRopaBase;
					float valueOrDefault = ((piezaDeRopaBase != null) ? new float?(piezaDeRopaBase.dataDeRopa.semenDistanceCastAdd) : null).GetValueOrDefault(0f);
					this.m_cooked.Add(num);
					SemenPuntoCollisionContraSkin.SkinHitResult result = SemenPuntoCollisionContraSkin.SkinHitResult.GetResult(this.m_SemenPunto.bodyTransform.rotation, sender, collider, this.m_HitDirection, this.m_HitPoint, num, this.semenPunto.semenCollider.contactOffset, 0.5f + Mathf.Clamp01(this.m_failingTime), valueOrDefault);
					if (result.data.usable)
					{
						this.m_results.Add(result);
					}
					if (this.m_checkHitsCoroutine == null)
					{
						this.m_checkHitsCoroutine = base.StartCoroutine(this.CheckHitsRoutine());
					}
					return;
				}
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000CD95 File Offset: 0x0000AF95
		private void UnBind()
		{
			this.m_SemenPunto.UnBind();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000CDA2 File Offset: 0x0000AFA2
		private void M_SemenPunto_onUnBinded(SemenPunto obj)
		{
			this.m_bindedTo = null;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000CDAB File Offset: 0x0000AFAB
		private IEnumerator CorregirPuntoInternoEnHoleRutine(IHole hole)
		{
			SemenPunto semenPunto = this.m_SemenPunto;
			if (((semenPunto != null) ? semenPunto.bodyTransform : null) == null || hole.entrada == null)
			{
				yield break;
			}
			this.m_SemenPunto.bodyTransform.position = hole.entrada.position;
			yield break;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000CDC1 File Offset: 0x0000AFC1
		private IEnumerator CheckHitsRoutine()
		{
			while (this.m_cooked.Count < this.m_VisualSkins.Count)
			{
				yield return null;
			}
			if (this.m_results.Count == 0 || this.m_bindedTo == null || this == null)
			{
				HitSkinBasica bindedTo = this.m_bindedTo;
				this.m_failingTime += Time.deltaTime;
				this.UnBind();
				IHoleHitSkin holeHitSkin = bindedTo as IHoleHitSkin;
				if (holeHitSkin != null && holeHitSkin.hole != null)
				{
					GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.afterPhyscisConstraints, this, this.CorregirPuntoInternoEnHoleRutine(holeHitSkin.hole), null);
				}
				this.m_checkHitsCoroutine = null;
				yield break;
			}
			this.m_results.Sort((SemenPuntoCollisionContraSkin.SkinHitResult a, SemenPuntoCollisionContraSkin.SkinHitResult b) => a.data.prioridad.CompareTo(b.data.prioridad));
			this.currentTriangle = this.m_results[0];
			this.m_results.Clear();
			this.m_VisualSkins.Clear();
			this.m_cooked.Clear();
			if (!this.currentTriangle.skin.isTriangleAttachmentSystemInitiated)
			{
				yield return this.currentTriangle.skin.InitTriangleAttachmentSystem();
			}
			if (this.m_bindedTo == null || this == null)
			{
				this.m_failingTime += Time.deltaTime;
				this.UnBind();
				this.m_checkHitsCoroutine = null;
				yield break;
			}
			HitSkinBasica bindedTo2 = this.m_bindedTo;
			this.m_SemenPunto.SetManualMode();
			this.m_bindedTo = bindedTo2;
			if (this.m_bindedTo.gameObject.scene != base.gameObject.scene)
			{
				SceneManager.MoveGameObjectToScene(base.gameObject, this.m_bindedTo.gameObject.scene);
			}
			this.m_TriangleAttachmentUser = base.gameObject.AddComponent<SkinAndShapeTransformToTriangleSurfaceUser>();
			this.m_TriangleAttachmentUser.onSystemaDisabled += this.M_TriangleAttachmentUser_onSystemaDisabled;
			this.m_TriangleAttachmentUser.onSystemaDestroyed += this.M_TriangleAttachmentUser_onSystemaDisabled;
			this.m_TriangleAttachmentUser.barycentricsCoordinates = this.currentTriangle.data.barycentricCoordinate;
			this.m_TriangleAttachmentUser.deltaRotation = this.currentTriangle.data.deltaRotation;
			SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser = this.m_TriangleAttachmentUser;
			float num = 0f;
			float num2 = 0f;
			float num3 = this.currentTriangle.skin.materialZOffset + this.m_SemenPunto.particleWorldRarius * 0.25f;
			HitSkinBasica bindedTo3 = this.m_bindedTo;
			float? num4;
			if (bindedTo3 == null)
			{
				num4 = null;
			}
			else
			{
				ArmatureSkins owner = bindedTo3.owner;
				if (owner == null)
				{
					num4 = null;
				}
				else
				{
					ICharacter character = owner.character;
					num4 = ((character != null) ? new float?(character.escala) : null);
				}
			}
			float? num5 = num4;
			triangleAttachmentUser.deltaPosition = new Vector3(num, num2, num3 / num5.GetValueOrDefault(1f));
			this.m_TriangleAttachmentUser.Init(this.currentTriangle.skin.triangleAttachmentSystem, base.transform, this.currentTriangle.data.triangleIndex);
			Action<SemenPuntoCollisionContraSkin> action = this.onAttached;
			if (action != null)
			{
				action(this);
			}
			SemenPuntoCollisionContraSkin semenPuntoCollisionContraSkin;
			if (this.m_SemenPunto.previus != null && this.m_SemenPunto.previus.TryGetComponent<SemenPuntoCollisionContraSkin>(out semenPuntoCollisionContraSkin))
			{
				Action<SemenPuntoCollisionContraSkin> action2 = semenPuntoCollisionContraSkin.onNextAttached;
				if (action2 != null)
				{
					action2(semenPuntoCollisionContraSkin);
				}
			}
			SkinSensibleASemen component = this.m_bindedTo.GetComponent<SkinSensibleASemen>();
			if (component != null && this.m_SemenPunto.ownerPene != null)
			{
				component.RegistrarContacto(this.m_SemenPunto.ownerPene, this.m_SemenPunto.tipo, this.currentTriangle.data.wPoint, this.currentTriangle.data.wNormal, this.m_bindedToVelocity, this.m_impactadas);
			}
			this.RegistrarSemen(true);
			this.m_duracionModificador.valor.valor = 2f;
			this.m_checkHitsCoroutine = null;
			yield break;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		private void M_SemenPunto_onBreakRested(SemenPunto obj)
		{
			if (this.isAttachedToSkin)
			{
				Action<SemenPuntoCollisionContraSkin> action = this.onNextBrokenAfterAttached;
				if (action == null)
				{
					return;
				}
				action(this);
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000CDEB File Offset: 0x0000AFEB
		private void RegistrarSemen(bool registrar)
		{
			SemenPuntoCollisionContraSkin.RegistrarSemenImpactando(this.m_SemenPunto.tipo, this.m_bindedTo, this.m_impactadas, registrar);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000CE0C File Offset: 0x0000B00C
		public static void LoadPartesImpactadas(SemenPuntoCollisionContraSkin semenPunto, IList<ValueTuple<ParteDelCuerpoHumano, Side>> result)
		{
			if (semenPunto.m_bindedTo == null || semenPunto.m_impactadas.Count == 0)
			{
				return;
			}
			for (int i = 0; i < semenPunto.m_impactadas.Count; i++)
			{
				BodyPartEnum bodyPartEnum = semenPunto.m_impactadas[i];
				Side side = semenPunto.m_bindedTo.side;
				Side side2 = ((side != Side.none) ? side : bodyPartEnum.ParseASide());
				ParteDelCuerpoHumano parteDelCuerpoHumano = bodyPartEnum.ParseAParteHumana();
				result.Add(new ValueTuple<ParteDelCuerpoHumano, Side>(parteDelCuerpoHumano, side2));
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000CE88 File Offset: 0x0000B088
		public static void RegistrarSemenImpactando(TipoDeSemen tipo, HitSkinBasica bindedTo, IReadOnlyList<BodyPartEnum> impactadas, bool regitrarOrUnregistrar)
		{
			if (bindedTo == null || impactadas.Count == 0)
			{
				return;
			}
			CharAi componentEnRoot = bindedTo.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				return;
			}
			for (int i = 0; i < impactadas.Count; i++)
			{
				BodyPartEnum bodyPartEnum = impactadas[i];
				Side side = bindedTo.side;
				Side side2 = ((side != Side.none) ? side : bodyPartEnum.ParseASide());
				ParteDelCuerpoHumano parteDelCuerpoHumano = bodyPartEnum.ParseAParteHumana();
				if (regitrarOrUnregistrar)
				{
					componentEnRoot.RegistrarSemenSobre(parteDelCuerpoHumano, tipo, side2, 1);
				}
				else
				{
					componentEnRoot.UnRegistrarSemenSobre(parteDelCuerpoHumano, tipo, side2, 1);
				}
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000CF0C File Offset: 0x0000B10C
		private void M_TriangleAttachmentUser_onSystemaDisabled(SkinAndShapeTransformToTriangleSurfaceUser obj)
		{
			if (this.m_TriangleAttachmentUser != null)
			{
				Object.Destroy(this.m_TriangleAttachmentUser);
			}
			this.m_TriangleAttachmentUser = null;
			Object.Destroy(this.m_SemenPunto.gameObject);
		}

		// Token: 0x04000241 RID: 577
		public SemenPuntoCollisionContraSkin.SkinHitResult currentTriangle;

		// Token: 0x04000242 RID: 578
		private SemenPunto m_SemenPunto;

		// Token: 0x04000243 RID: 579
		[ReadOnlyUI]
		[SerializeField]
		private HitSkinBasica m_bindedTo;

		// Token: 0x04000244 RID: 580
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_bindedToVelocity;

		// Token: 0x04000245 RID: 581
		[ReadOnlyUI]
		[SerializeField]
		private List<BodyPartEnum> m_impactadas = new List<BodyPartEnum>();

		// Token: 0x04000246 RID: 582
		[Obsolete("", true)]
		private RopaCubre m_cubriendo;

		// Token: 0x04000247 RID: 583
		[ReadOnlyUI]
		[SerializeField]
		private List<Skin> m_VisualSkins = new List<Skin>();

		// Token: 0x04000248 RID: 584
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_HitDirection;

		// Token: 0x04000249 RID: 585
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_HitPoint;

		// Token: 0x0400024A RID: 586
		[Obsolete("", true)]
		private int m_fails;

		// Token: 0x0400024B RID: 587
		[ReadOnlyUI]
		[SerializeField]
		private float m_failingTime;

		// Token: 0x0400024C RID: 588
		private Coroutine m_checkHitsCoroutine;

		// Token: 0x0400024D RID: 589
		[ReadOnlyUI]
		[SerializeField]
		private List<SemenPuntoCollisionContraSkin.SkinHitResult> m_results = new List<SemenPuntoCollisionContraSkin.SkinHitResult>();

		// Token: 0x0400024E RID: 590
		[ReadOnlyUI]
		[SerializeField]
		private HashSet<int> m_cooked = new HashSet<int>();

		// Token: 0x0400024F RID: 591
		[ReadOnlyUI]
		[SerializeField]
		private SkinAndShapeTransformToTriangleSurfaceUser m_TriangleAttachmentUser;

		// Token: 0x04000250 RID: 592
		[SerializeReference]
		private ModificadorDeFloat m_duracionModificador;

		// Token: 0x04000251 RID: 593
		private SonidoProductor m_SonidoProductor;

		// Token: 0x04000252 RID: 594
		private ReproductorDeSonidosUnaVezGenerico m_ReproductorDeSonidos;

		// Token: 0x04000253 RID: 595
		[Range(0f, 1f)]
		public float bindProc = 0.5f;

		// Token: 0x04000254 RID: 596
		private static List<string> m_piezasCubriendoTEMP = new List<string>();

		// Token: 0x02000086 RID: 134
		[Serializable]
		public struct SkinHitResult
		{
			// Token: 0x06000361 RID: 865 RVA: 0x0000CF8C File Offset: 0x0000B18C
			public static SemenPuntoCollisionContraSkin.SkinHitResult GetResult(Quaternion semenWorldRotation, PedidoDePhyscisBakeDeSkin pedido, MeshCollider collider, Vector3 velocity, Vector3 point, int prioridad, float semenColliderOffset, float distanceMod, float distanceAdd)
			{
				RaycastHit raycastHit;
				if (!ExtendedMonoBehaviour.TryGetHitFormCollider(collider, point, velocity.normalized, false, out raycastHit, semenColliderOffset + distanceAdd, distanceMod, false, 0.25f))
				{
					return SemenPuntoCollisionContraSkin.SkinHitResult.m_empty;
				}
				if (!pedido.TriangleIndexIsValid(raycastHit.triangleIndex))
				{
					return SemenPuntoCollisionContraSkin.SkinHitResult.m_empty;
				}
				int num;
				int num2;
				int num3;
				Vector3 vector;
				Vector3 vector2;
				Vector3 vector3;
				Vector3 vector4;
				Vector3 vector5;
				Vector3 vector6;
				Vector3 vector7;
				Vector3 vector8;
				Vector3 vector9;
				Vector3 vector10;
				Vector3 vector11;
				Vector3 vector12;
				Vector3 vector13;
				Vector3 vector14;
				Vector3 vector15;
				Vector3 vector16;
				Vector3 vector17;
				Vector3 vector18;
				pedido.GetWorldVerticesOfTriangle(raycastHit.triangleIndex, out num, out num2, out num3, out vector, out vector2, out vector3, out vector4, out vector5, out vector6, out vector7, out vector8, out vector9, out vector10, out vector11, out vector12, out vector13, out vector14, out vector15, out vector16, out vector17, out vector18);
				Quaternion quaternion = Quaternion.Inverse(pedido.owner.skinnedMeshRenderer.transform.rotation) * semenWorldRotation;
				Vector3 barycentricCoordinate = raycastHit.barycentricCoordinate;
				Vector3 vector19 = vector13 * barycentricCoordinate.x + vector14 * barycentricCoordinate.y + vector15 * barycentricCoordinate.z;
				Vector3 vector20 = vector16 * barycentricCoordinate.x + vector17 * barycentricCoordinate.y + vector18 * barycentricCoordinate.z;
				Quaternion quaternion2 = Quaternion.LookRotation(vector19, vector20);
				float num4 = (vector11 - vector10).magnitude + (vector12 - vector11).magnitude + (vector10 - vector12).magnitude;
				return new SemenPuntoCollisionContraSkin.SkinHitResult
				{
					skin = pedido.owner,
					data = new SemenPuntoCollisionContraSkin.SkinHitResult.Data
					{
						usable = true,
						prioridad = prioridad,
						semenColliderOffset = semenColliderOffset,
						triangleIndex = raycastHit.triangleIndex,
						barycentricCoordinate = barycentricCoordinate,
						initialLocalRotationFromMesh = quaternion,
						wPoint = raycastHit.point,
						wNormal = raycastHit.normal,
						deltaRotation = Quaternion.Inverse(quaternion2) * quaternion,
						wTrianglePerimeter = num4,
						hitBakedTriangleData = new SemenPuntoCollisionContraSkin.SkinHitResult.TriangleData
						{
							vertexIndex0 = num,
							vertexIndex1 = num2,
							vertexIndex2 = num3
						}
					}
				};
			}

			// Token: 0x04000255 RID: 597
			private static SemenPuntoCollisionContraSkin.SkinHitResult m_empty;

			// Token: 0x04000256 RID: 598
			public Skin skin;

			// Token: 0x04000257 RID: 599
			public SemenPuntoCollisionContraSkin.SkinHitResult.Data data;

			// Token: 0x02000087 RID: 135
			public struct Data
			{
				// Token: 0x04000258 RID: 600
				public bool usable;

				// Token: 0x04000259 RID: 601
				public float semenColliderOffset;

				// Token: 0x0400025A RID: 602
				public int prioridad;

				// Token: 0x0400025B RID: 603
				public int triangleIndex;

				// Token: 0x0400025C RID: 604
				public Vector3 barycentricCoordinate;

				// Token: 0x0400025D RID: 605
				public Quaternion initialLocalRotationFromMesh;

				// Token: 0x0400025E RID: 606
				public Vector3 wPoint;

				// Token: 0x0400025F RID: 607
				public Vector3 wNormal;

				// Token: 0x04000260 RID: 608
				public Quaternion deltaRotation;

				// Token: 0x04000261 RID: 609
				public float wTrianglePerimeter;

				// Token: 0x04000262 RID: 610
				public SemenPuntoCollisionContraSkin.SkinHitResult.TriangleData hitBakedTriangleData;
			}

			// Token: 0x02000088 RID: 136
			public struct TriangleData
			{
				// Token: 0x04000263 RID: 611
				public int vertexIndex0;

				// Token: 0x04000264 RID: 612
				public int vertexIndex1;

				// Token: 0x04000265 RID: 613
				public int vertexIndex2;
			}
		}
	}
}
