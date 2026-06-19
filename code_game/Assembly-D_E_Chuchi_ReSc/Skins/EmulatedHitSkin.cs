using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200001B RID: 27
	public abstract class EmulatedHitSkin : HitSkinBasica, IUserDeCollisionesEmuladas<EmulatedHitSkin.Colision>, IBasicUser<EmulatedHitSkin.Colision, IColisionEmuladaData>, IEmualtedColisionable, IColisionableContraColliders, ICollisionable, IColisionableContraColliders<EmulatedHitSkin.Colision>, IEmulatedHitSkinEstimulablePorToques, IEstimulablePorToques, IComponentStartable
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00004252 File Offset: 0x00002452
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return false;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004255 File Offset: 0x00002455
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedOnUpdateEmulacionDeEventosDeColision);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000425E File Offset: 0x0000245E
		public sealed override EstimuledBy touchedBy
		{
			get
			{
				return this.m_TouchedBy;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000096 RID: 150 RVA: 0x00004268 File Offset: 0x00002468
		// (remove) Token: 0x06000097 RID: 151 RVA: 0x000042A0 File Offset: 0x000024A0
		public event Action<IColisionEmuladaData> onContact;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000098 RID: 152 RVA: 0x000042D5 File Offset: 0x000024D5
		// (remove) Token: 0x06000099 RID: 153 RVA: 0x000042E3 File Offset: 0x000024E3
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionEnterBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionEnterBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionEnterBase -= value;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600009A RID: 154 RVA: 0x000042F1 File Offset: 0x000024F1
		// (remove) Token: 0x0600009B RID: 155 RVA: 0x000042FF File Offset: 0x000024FF
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionStayBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionStayBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionStayBase -= value;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600009C RID: 156 RVA: 0x0000430D File Offset: 0x0000250D
		// (remove) Token: 0x0600009D RID: 157 RVA: 0x0000431B File Offset: 0x0000251B
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionExitBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionExitBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionExitBase -= value;
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600009E RID: 158 RVA: 0x00004329 File Offset: 0x00002529
		// (remove) Token: 0x0600009F RID: 159 RVA: 0x00004337 File Offset: 0x00002537
		event Action<EmulatedHitSkin.Colision> IColisionableContraColliders<EmulatedHitSkin.Colision>.collisionEnter
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionEnter += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionEnter -= value;
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000A0 RID: 160 RVA: 0x00004345 File Offset: 0x00002545
		// (remove) Token: 0x060000A1 RID: 161 RVA: 0x00004353 File Offset: 0x00002553
		event Action<EmulatedHitSkin.Colision> IColisionableContraColliders<EmulatedHitSkin.Colision>.collisionStay
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionStay += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionStay -= value;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000A2 RID: 162 RVA: 0x00004361 File Offset: 0x00002561
		// (remove) Token: 0x060000A3 RID: 163 RVA: 0x0000436F File Offset: 0x0000256F
		event Action<EmulatedHitSkin.Colision> IColisionableContraColliders<EmulatedHitSkin.Colision>.collisionExit
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionExit += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionExit -= value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000437D File Offset: 0x0000257D
		public BodyPartEnum parte
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00004385 File Offset: 0x00002585
		public sealed override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return new BodyPartEnum?(this.m_parte);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000437D File Offset: 0x0000257D
		public BodyPartEnum bodyPart
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004394 File Offset: 0x00002594
		protected void InitEmulated(BodyPartEnum Parte, Transform boneTarget, Skin VisualSkin)
		{
			this.m_Procesador = new Action<EmulatedHitSkin.ColliderCheckerBase, int, Collider[], object>(this.ProcesarCheckeo_Colliders);
			this.m_parte = Parte;
			this.m_HistorialColisionesContraColliders = new HistorialDeCollisionesEmuladas<EmulatedHitSkin.Colision>(this);
			this.m_HistorialColisionesContraColliders.collisionEnter += this.OnEnter;
			this.m_HistorialColisionesContraColliders.collisionStay += this.OnStay;
			this.m_HistorialColisionesContraColliders.collisionExit += this.OnExit;
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				Debug.LogWarning("m_PrioridadesDeObjetoEstimulado null reference.", this);
				this.m_PrioridadesDeObjetoEstimulado = ParteDelCuerpoHumanoPrioridadesOnlyFixed.instanceFemenina;
			}
			this.m_TouchedBy = new EmulatedHitSkin.TouchedBy<TocanteObjeto>(this, this.m_PrioridadesDeObjetoEstimulado, new TouchedBy<TocanteObjeto, EmulatedHitSkin, EmulatedHitSkin.Colision, EmulatedHitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>.Config
			{
				buscarEn = TouchedBy<TocanteObjeto, EmulatedHitSkin, EmulatedHitSkin.Colision, EmulatedHitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>.BuscarEn.colliders,
				buscarEnPadres = true
			});
			this.m_myCharacter = base.GetComponentInParent<Character>();
			base.InitBasica(boneTarget, VisualSkin);
			this.m_layermask = this.ObtenerLayersDeCasteo();
			this.m_QueryTriggerInteraction = this.ObtenerQueryTriggerInteraction();
			foreach (Collider collider in this.skinCollidersSet)
			{
				collider.gameObject.AddComponent<ColliderDeEmulatedHitSkin>().Init(this);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000044D8 File Offset: 0x000026D8
		public sealed override bool TryCalcularPartesImpactadasDeCollision(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, IList<BodyPartEnum> result, bool debugDraw = false)
		{
			if (!ExtendedMonoBehaviour.TryGetHitFormCollider(ownCollider, collisionPunto, collisionNormal, true, out hit, ownCollider.contactOffset, 1f, debugDraw, 1f))
			{
				return false;
			}
			result.Add(this.bodyPart);
			return true;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004514 File Offset: 0x00002714
		public sealed override bool TryCalcularPartesImpactadasDeCollision(Collision collision, Collider collider, out RaycastHit hit, IList<BodyPartEnum> result, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false)
		{
			if (!collision.TryCastCollision(true, true, out hit, collider, impactDirection, impactPoint, debugDraw))
			{
				return false;
			}
			result.Add(this.bodyPart);
			return true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004538 File Offset: 0x00002738
		public bool ContieneCollider(Collider collider)
		{
			return this.skinCollidersSet.Contains(collider);
		}

		// Token: 0x060000AB RID: 171
		protected abstract IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks();

		// Token: 0x060000AC RID: 172
		protected abstract int ObtenerLayersDeCasteo();

		// Token: 0x060000AD RID: 173
		protected abstract QueryTriggerInteraction ObtenerQueryTriggerInteraction();

		// Token: 0x060000AE RID: 174
		protected abstract bool DetectedColliderIsValid(Collider other);

		// Token: 0x060000AF RID: 175 RVA: 0x00004548 File Offset: 0x00002748
		protected bool OwnerContineCollider(Collider col)
		{
			ArmatureSkins owner = base.owner;
			return ((owner != null) ? new bool?(owner.ContineCollider(col)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000457D File Offset: 0x0000277D
		public sealed override bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques)
		{
			return this.m_TouchedBy.ContieneEstimulosDeCharacter<EstimuloTactil>(character, toques);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000458C File Offset: 0x0000278C
		public void DoCheckPublic(EmulatedHitSkin.OnColliderFound onFound, object data, float offsetMod)
		{
			if (onFound == null)
			{
				throw new ArgumentNullException("onFound", "onFound null reference.");
			}
			IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> readOnlyList = this.ObtenerChecks();
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				this.ProcesarCheckeo(readOnlyList[i], this.m_layermask, this.m_QueryTriggerInteraction, GlobalUpdater.instancia.currentFixedUpdateIndex == 0, offsetMod, new Action<EmulatedHitSkin.ColliderCheckerBase, int, Collider[], object>(this.DoCheckPublic_Procesado), new ValueTuple<EmulatedHitSkin.OnColliderFound, object>(onFound, data));
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004604 File Offset: 0x00002804
		private void DoCheckPublic_Procesado(EmulatedHitSkin.ColliderCheckerBase check, int cantidad, Collider[] hits, object extradata)
		{
			ValueTuple<EmulatedHitSkin.OnColliderFound, object> valueTuple = (ValueTuple<EmulatedHitSkin.OnColliderFound, object>)extradata;
			EmulatedHitSkin.OnColliderFound item = valueTuple.Item1;
			object item2 = valueTuple.Item2;
			for (int i = 0; i < cantidad; i++)
			{
				Collider collider = hits[i];
				item(collider, item2, this);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004640 File Offset: 0x00002840
		protected void OnEnamularEventosDeCollisiones()
		{
			IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> readOnlyList = this.ObtenerChecks();
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				this.ProcesarCheckeo(readOnlyList[i], this.m_layermask, this.m_QueryTriggerInteraction, GlobalUpdater.instancia.currentFixedUpdateIndex == 0, 1f, this.m_Procesador, null);
			}
			this.AfterProcesarCheckeo();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AfterProcesarCheckeo()
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000469D File Offset: 0x0000289D
		protected void OnAfterFixedUpdate()
		{
			this.m_HistorialColisionesContraColliders.AfterCollision();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000046AC File Offset: 0x000028AC
		private void ProcesarCheckeo(EmulatedHitSkin.ColliderCheckerBase check, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool esPrimierFixedStep, float offsetMod, Action<EmulatedHitSkin.ColliderCheckerBase, int, Collider[], object> Procesador, object extradata)
		{
			if (check == null)
			{
				return;
			}
			if (check.saver == null)
			{
				return;
			}
			Collider ownCollider = check.ownCollider;
			if (ownCollider == null || !ownCollider.enabled || !ownCollider.gameObject.activeInHierarchy)
			{
				return;
			}
			int num = 0;
			try
			{
				if (esPrimierFixedStep)
				{
					check.UpdateLossyScale();
				}
				num = check.DoCheck(this.resultsTEMP, layerMask, queryTriggerInteraction, offsetMod);
				Procesador(check, num, this.resultsTEMP, extradata);
			}
			finally
			{
				Array.Clear(this.resultsTEMP, 0, num);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000473C File Offset: 0x0000293C
		private void ProcesarCheckeo_Colliders(EmulatedHitSkin.ColliderCheckerBase check, int cantidad, Collider[] Hits, object extradata)
		{
			for (int i = 0; i < cantidad; i++)
			{
				Collider collider = Hits[i];
				Collider ownCollider = check.ownCollider;
				if (!(collider == ownCollider) && !(collider.gameObject.tag == "IgnoreCollider") && !this.OwnerContineCollider(collider) && this.DetectedColliderIsValid(collider))
				{
					EmulatedHitSkin.CollisionData item = this.m_poolDeCollisionData.GetItem();
					item.otherCollider = collider;
					item.ownCollider = ownCollider;
					item.ownSaver = check.saver;
					item.checker = check;
					IState<EmulatedHitSkin.Colision, IColisionEmuladaData, Collider> state = (IState<EmulatedHitSkin.Colision, IColisionEmuladaData, Collider>)this.m_HistorialColisionesContraColliders.currentState;
					if (!state.Contains(collider))
					{
						if (this.isDebug)
						{
							Debug.Log("Emulated Hit Skin " + base.name + ". onContact: " + collider.name, this);
						}
						Action<IColisionEmuladaData> action = this.onContact;
						if (action != null)
						{
							action(item);
						}
						this.m_HistorialColisionesContraColliders.OnCollisionEnter(item);
					}
					else
					{
						state.GetCollision(collider).SumarRelativeVelocity(this, item);
					}
					this.m_poolDeCollisionData.ReturnItem(item);
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004854 File Offset: 0x00002A54
		public sealed override void OnUpdateEvent1()
		{
			try
			{
				if (this.m_doUpdate)
				{
					this.OnEnamularEventosDeCollisiones();
				}
			}
			finally
			{
				this.OnAfterFixedUpdate();
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000488C File Offset: 0x00002A8C
		bool IBasicUser<EmulatedHitSkin.Colision, IColisionEmuladaData>.PoblarColision(EmulatedHitSkin.Colision fromPool, IColisionEmuladaData data)
		{
			EmulatedHitSkin.CollisionData collisionData = (EmulatedHitSkin.CollisionData)data;
			RaycastHit? raycastHit = EmulatedHitSkin.CheckCast(collisionData);
			if (raycastHit == null)
			{
				return false;
			}
			fromPool.Poblar(this, collisionData, raycastHit.Value, false);
			return true;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000048C4 File Offset: 0x00002AC4
		protected virtual void OnEnter(EmulatedHitSkin.Colision collision)
		{
			if (this.debugLogCollisionInfo)
			{
				string text = "OnEnter-> ";
				Collider colliderChocandonos = collision.colliderChocandonos;
				Debug.Log(text + ((colliderChocandonos != null) ? colliderChocandonos.ToString() : null));
			}
			bool flag = this.debugDrawCollisionInfo;
			if (collision.chocandonosTieneRigidbody)
			{
				collision.rigidbodyChocandonos.GetComponents<ISkinOnCollisionEnterListiner>(EmulatedHitSkin.m_enterListenersTemp);
			}
			else
			{
				collision.colliderChocandonos.GetComponents<ISkinOnCollisionEnterListiner>(EmulatedHitSkin.m_enterListenersTemp);
			}
			try
			{
				for (int i = 0; i < EmulatedHitSkin.m_enterListenersTemp.Count; i++)
				{
					ISkinOnCollisionEnterListiner skinOnCollisionEnterListiner = EmulatedHitSkin.m_enterListenersTemp[i];
					if (skinOnCollisionEnterListiner != null)
					{
						skinOnCollisionEnterListiner.OnEnter(collision, this);
					}
				}
			}
			finally
			{
				EmulatedHitSkin.m_enterListenersTemp.Clear();
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004978 File Offset: 0x00002B78
		protected virtual void OnStay(EmulatedHitSkin.Colision collision)
		{
			if (this.debugLogCollisionInfo)
			{
				string text = "OnStay-> ";
				Collider colliderChocandonos = collision.colliderChocandonos;
				Debug.Log(text + ((colliderChocandonos != null) ? colliderChocandonos.ToString() : null));
			}
			bool flag = this.debugDrawCollisionInfo;
			if (collision.chocandonosTieneRigidbody)
			{
				collision.rigidbodyChocandonos.GetComponents<ISkinOnCollisionStayListiner>(EmulatedHitSkin.m_stayListenersTemp);
			}
			else
			{
				collision.colliderChocandonos.GetComponents<ISkinOnCollisionStayListiner>(EmulatedHitSkin.m_stayListenersTemp);
			}
			try
			{
				for (int i = 0; i < EmulatedHitSkin.m_stayListenersTemp.Count; i++)
				{
					ISkinOnCollisionStayListiner skinOnCollisionStayListiner = EmulatedHitSkin.m_stayListenersTemp[i];
					if (skinOnCollisionStayListiner != null)
					{
						skinOnCollisionStayListiner.OnStay(collision, this);
					}
				}
			}
			finally
			{
				EmulatedHitSkin.m_stayListenersTemp.Clear();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004A2C File Offset: 0x00002C2C
		protected virtual void OnExit(EmulatedHitSkin.Colision collision)
		{
			if (this.debugLogCollisionInfo)
			{
				string text = "OnExit-> ";
				Collider colliderChocandonos = collision.colliderChocandonos;
				Debug.Log(text + ((colliderChocandonos != null) ? colliderChocandonos.ToString() : null));
			}
			bool flag = this.debugDrawCollisionInfo;
			if (collision.chocandonosTieneRigidbody)
			{
				Rigidbody rigidbodyChocandonos = collision.rigidbodyChocandonos;
				if (rigidbodyChocandonos != null)
				{
					rigidbodyChocandonos.GetComponents<ISkinOnCollisionExitListiner>(EmulatedHitSkin.m_exiListenersTemp);
				}
			}
			else
			{
				Collider colliderChocandonos2 = collision.colliderChocandonos;
				if (colliderChocandonos2 != null)
				{
					colliderChocandonos2.GetComponents<ISkinOnCollisionExitListiner>(EmulatedHitSkin.m_exiListenersTemp);
				}
			}
			try
			{
				for (int i = 0; i < EmulatedHitSkin.m_exiListenersTemp.Count; i++)
				{
					ISkinOnCollisionExitListiner skinOnCollisionExitListiner = EmulatedHitSkin.m_exiListenersTemp[i];
					if (skinOnCollisionExitListiner != null)
					{
						skinOnCollisionExitListiner.OnExit(collision, this);
					}
				}
			}
			finally
			{
				EmulatedHitSkin.m_exiListenersTemp.Clear();
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004AEC File Offset: 0x00002CEC
		private static RaycastHit? CheckCast(EmulatedHitSkin.CollisionData data)
		{
			Collider collider = ((data != null) ? data.otherCollider : null);
			Collider collider2 = ((data != null) ? data.ownCollider : null);
			if (collider == null || collider2 == null)
			{
				return null;
			}
			Vector3 vector = collider.bounds.center;
			Bounds bounds = collider2.bounds;
			Vector3 vector2 = bounds.center - vector;
			Vector3 vector3 = vector2.normalized;
			float magnitude = bounds.size.magnitude;
			if (vector3 == Vector3.zero)
			{
				vector2 = collider2.transform.position - collider.transform.position;
				vector3 = vector2.normalized;
				if (vector3 == Vector3.zero)
				{
					vector3 = collider.transform.forward;
					vector2 = vector3 * magnitude;
				}
			}
			vector += -vector3 * magnitude;
			Ray ray = new Ray(vector, vector3);
			RaycastHit raycastHit;
			if (!collider2.Raycast(ray, out raycastHit, vector2.magnitude + magnitude))
			{
				return null;
			}
			return new RaycastHit?(raycastHit);
		}

		// Token: 0x060000BE RID: 190
		protected abstract bool UsaPhysicsRelativeVelocity(IColisionEmuladaData data, EmulatedHitSkin.ColliderCheckerBase checker, RaycastHit hit, Vector3 emulatedRelativeVelocity, out Vector3 physicsRelativeVelocity);

		// Token: 0x04000079 RID: 121
		[SerializeField]
		[ReadOnlyUI]
		protected bool m_doUpdate = true;

		// Token: 0x0400007A RID: 122
		public bool debugLogCollisionInfo;

		// Token: 0x0400007B RID: 123
		public bool debugDrawCollisionInfo;

		// Token: 0x0400007C RID: 124
		[SerializeField]
		[ReadOnlyUI]
		private BodyPartEnum m_parte;

		// Token: 0x0400007D RID: 125
		private Character m_myCharacter;

		// Token: 0x0400007E RID: 126
		private HistorialDeCollisionesEmuladas<EmulatedHitSkin.Colision> m_HistorialColisionesContraColliders;

		// Token: 0x0400007F RID: 127
		private SimplePoolDeClearables<EmulatedHitSkin.CollisionData> m_poolDeCollisionData = new SimplePoolDeClearables<EmulatedHitSkin.CollisionData>();

		// Token: 0x04000080 RID: 128
		private EmulatedHitSkin.TouchedBy<TocanteObjeto> m_TouchedBy;

		// Token: 0x04000081 RID: 129
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x04000082 RID: 130
		private Action<EmulatedHitSkin.ColliderCheckerBase, int, Collider[], object> m_Procesador;

		// Token: 0x04000083 RID: 131
		private int m_layermask;

		// Token: 0x04000084 RID: 132
		private QueryTriggerInteraction m_QueryTriggerInteraction;

		// Token: 0x04000085 RID: 133
		private Collider[] resultsTEMP = new Collider[20];

		// Token: 0x04000086 RID: 134
		private static List<ISkinOnCollisionEnterListiner> m_enterListenersTemp = new List<ISkinOnCollisionEnterListiner>();

		// Token: 0x04000087 RID: 135
		private static List<ISkinOnCollisionStayListiner> m_stayListenersTemp = new List<ISkinOnCollisionStayListiner>();

		// Token: 0x04000088 RID: 136
		private static List<ISkinOnCollisionExitListiner> m_exiListenersTemp = new List<ISkinOnCollisionExitListiner>();

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x060000C2 RID: 194
		public delegate void OnColliderFound(Collider collider, object data, EmulatedHitSkin sender);

		// Token: 0x0200001D RID: 29
		public class Colision : ColisionEmuladaV2, IColisionContraBodyPartes
		{
			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004C59 File Offset: 0x00002E59
			public sealed override bool usaPhyscisVelocidadRelativa
			{
				get
				{
					return this.m_usaPhysicsRelativeVelocity;
				}
			}

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004C61 File Offset: 0x00002E61
			public sealed override Vector3 physcisVelocidadRelativa
			{
				get
				{
					return this.m_PhysicsRelativeVelocity;
				}
			}

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004C69 File Offset: 0x00002E69
			IReadOnlyList<BodyPartEnum> IColisionContraBodyPartes.partesImpactadas
			{
				get
				{
					return this.m_paretesImpactadas;
				}
			}

			// Token: 0x060000C8 RID: 200 RVA: 0x00004C74 File Offset: 0x00002E74
			public void Poblar(EmulatedHitSkin skin, EmulatedHitSkin.CollisionData dataDeCollicion, RaycastHit hit, bool isNormalInverted)
			{
				this.m_paretesImpactadas[0] = skin.parte;
				base.PoblarDesdeData(dataDeCollicion, hit.normal, hit.point, dataDeCollicion.ownSaver, skin.boneTarget);
				this.m_usaPhysicsRelativeVelocity = skin.UsaPhysicsRelativeVelocity(dataDeCollicion, dataDeCollicion.checker, hit, base.velocidadEmuladaRelativa, out this.m_PhysicsRelativeVelocity);
				this.m_lastHit = hit;
			}

			// Token: 0x060000C9 RID: 201 RVA: 0x00004CD8 File Offset: 0x00002ED8
			public void SumarRelativeVelocity(EmulatedHitSkin skin, EmulatedHitSkin.CollisionData dataDeCollicion)
			{
				if (base.data == null)
				{
					return;
				}
				Vector3 vector;
				this.m_usaPhysicsRelativeVelocity = skin.UsaPhysicsRelativeVelocity(dataDeCollicion, dataDeCollicion.checker, this.m_lastHit, base.velocidadEmuladaRelativa, out vector) || this.m_usaPhysicsRelativeVelocity;
				this.m_PhysicsRelativeVelocity += vector;
			}

			// Token: 0x060000CA RID: 202 RVA: 0x00004D2C File Offset: 0x00002F2C
			protected sealed override void OnClearEmulada()
			{
				this.m_paretesImpactadas[0] = BodyPartEnum.pecho;
				this.m_usaPhysicsRelativeVelocity = false;
			}

			// Token: 0x04000089 RID: 137
			private BodyPartEnum[] m_paretesImpactadas = new BodyPartEnum[1];

			// Token: 0x0400008A RID: 138
			[SerializeField]
			[ReadOnlyUI]
			private bool m_usaPhysicsRelativeVelocity;

			// Token: 0x0400008B RID: 139
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_PhysicsRelativeVelocity;

			// Token: 0x0400008C RID: 140
			private RaycastHit m_lastHit;
		}

		// Token: 0x0200001E RID: 30
		[Serializable]
		public class CollisionData : IColisionEmuladaData, IClearable
		{
			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060000CC RID: 204 RVA: 0x00004D53 File Offset: 0x00002F53
			// (set) Token: 0x060000CD RID: 205 RVA: 0x00004D60 File Offset: 0x00002F60
			public IStepVelocitySaverEmulated ownSaver
			{
				get
				{
					return this.m_saver as IStepVelocitySaverEmulated;
				}
				set
				{
					this.m_saver = value as Object;
				}
			}

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x060000CE RID: 206 RVA: 0x00004D6E File Offset: 0x00002F6E
			Collider IColisionEmuladaData.otherCollider
			{
				get
				{
					return this.otherCollider;
				}
			}

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x060000CF RID: 207 RVA: 0x00004D76 File Offset: 0x00002F76
			Collider IColisionEmuladaData.ownCollider
			{
				get
				{
					return this.ownCollider;
				}
			}

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004D7E File Offset: 0x00002F7E
			IStepVelocitySaverEmulated IColisionEmuladaData.ownSaver
			{
				get
				{
					return this.ownSaver;
				}
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x00004D86 File Offset: 0x00002F86
			void IClearable.Clear()
			{
				this.m_saver = null;
				this.otherCollider = null;
				this.ownCollider = null;
				this.checker = null;
			}

			// Token: 0x0400008D RID: 141
			public EmulatedHitSkin.ColliderCheckerBase checker;

			// Token: 0x0400008E RID: 142
			public Collider otherCollider;

			// Token: 0x0400008F RID: 143
			public Collider ownCollider;

			// Token: 0x04000090 RID: 144
			[SerializeField]
			private Object m_saver;
		}

		// Token: 0x0200001F RID: 31
		public abstract class ColliderCheckerBase
		{
			// Token: 0x17000041 RID: 65
			// (get) Token: 0x060000D3 RID: 211
			public abstract Collider ownCollider { get; }

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x060000D4 RID: 212
			public abstract IStepVelocitySaverEmulated saver { get; }

			// Token: 0x060000D5 RID: 213
			public abstract int DoCheck(Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float offsetMod);

			// Token: 0x060000D6 RID: 214 RVA: 0x00004DA4 File Offset: 0x00002FA4
			public void UpdateLossyScale()
			{
				this.currentColliderEscala = this.ownCollider.transform.localScale.Escala();
			}

			// Token: 0x04000091 RID: 145
			public float currentColliderEscala;
		}

		// Token: 0x02000020 RID: 32
		public class TouchedBy<Ttocando> : TouchedBy<Ttocando, EmulatedHitSkin, EmulatedHitSkin.Colision, EmulatedHitSkin.TouchedBy<Ttocando>.SkinTouchStats> where Ttocando : TocanteObjeto
		{
			// Token: 0x060000D8 RID: 216 RVA: 0x00004DC1 File Offset: 0x00002FC1
			public TouchedBy(EmulatedHitSkin skin, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, TouchedBy<Ttocando, EmulatedHitSkin, EmulatedHitSkin.Colision, EmulatedHitSkin.TouchedBy<Ttocando>.SkinTouchStats>.Config config)
				: base(skin, PrioridadesDeObjetoEstimulado, skin.m_HistorialColisionesContraColliders, config)
			{
				if (skin == null)
				{
					throw new ArgumentNullException("skin", "skin null reference.");
				}
				if (config == null)
				{
					throw new ArgumentNullException("config", "config null reference.");
				}
			}

			// Token: 0x02000021 RID: 33
			[Serializable]
			public sealed class SkinTouchStats : TouchedBy<Ttocando, EmulatedHitSkin, EmulatedHitSkin.Colision, EmulatedHitSkin.TouchedBy<Ttocando>.SkinTouchStats>.TouchStats
			{
				// Token: 0x060000D9 RID: 217 RVA: 0x00004DFE File Offset: 0x00002FFE
				public override void Poblar(Ttocando touchingMono, EmulatedHitSkin touchedMono, IParteDelCuerpoHumanoPrioridades touchedMonoPrioridades, List<EmulatedHitSkin.Colision> collisionesDelToque, bool limpiar)
				{
					base.Poblar(touchingMono, touchedMono, touchedMonoPrioridades, collisionesDelToque, limpiar);
				}

				// Token: 0x060000DA RID: 218 RVA: 0x00004E0D File Offset: 0x0000300D
				protected override void CargarPartesTocadas()
				{
					base.AddParteEstimulada(((EmulatedHitSkin)base.estimulado).m_parte.ParseAParteHumana());
				}
			}
		}
	}
}
