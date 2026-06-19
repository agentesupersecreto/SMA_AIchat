using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x0200010F RID: 271
	[RequireComponent(typeof(Rigidbody))]
	public class PuppetPart : CustomUpdatedMonobehaviourBase, IUserDeCollisionesPhysicas<PuppetPart.PartColision>, IBasicUser<PuppetPart.PartColision, Collision>, IStepVelocitySaverEmulated, IStepVelocitySaver, ISideable, IBoneReferenceable, IMuscleCollidersUpdater, ITouchablePuppetParte, IPuppetParte, IComponentEnabable, IHistorialColisionesEventos
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0001F5D1 File Offset: 0x0001D7D1
		public Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0001F5D9 File Offset: 0x0001D7D9
		public IMassModifier massModifier
		{
			get
			{
				return this.m_Saver.massModifier;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x0001F5E6 File Offset: 0x0001D7E6
		public Vector3 velocidadEnDeltaTime
		{
			get
			{
				return this.m_Saver.velocidadEnDeltaTime;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0001F5F3 File Offset: 0x0001D7F3
		[Obsolete("", true)]
		public Vector3 velocidadEnFixedDeltaTime
		{
			get
			{
				return this.m_Saver.velocidadEnFixedDeltaTime;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0001F600 File Offset: 0x0001D800
		public Vector3 metrosPorSegundo
		{
			get
			{
				return this.m_Saver.metrosPorSegundo;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0001F60D File Offset: 0x0001D80D
		public bool usaRigidBody
		{
			get
			{
				return this.m_Saver.usaRigidBody;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0001F61A File Offset: 0x0001D81A
		public Vector3 physicsMetrosPorSegundo
		{
			get
			{
				return this.m_Saver.physicsMetrosPorSegundo;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001F627 File Offset: 0x0001D827
		public Muscle muscle
		{
			get
			{
				return this.m_muscle;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0001F62F File Offset: 0x0001D82F
		public sealed override int updateEvent1Index
		{
			get
			{
				return 28;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001F633 File Offset: 0x0001D833
		public sealed override int updateEvent6Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600055E RID: 1374 RVA: 0x0001F638 File Offset: 0x0001D838
		// (remove) Token: 0x0600055F RID: 1375 RVA: 0x0001F670 File Offset: 0x0001D870
		public event Action<Collision> onCollisionEnter;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000560 RID: 1376 RVA: 0x0001F6A8 File Offset: 0x0001D8A8
		// (remove) Token: 0x06000561 RID: 1377 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
		public event Action<Collision> onCollisionStay;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000562 RID: 1378 RVA: 0x0001F718 File Offset: 0x0001D918
		// (remove) Token: 0x06000563 RID: 1379 RVA: 0x0001F750 File Offset: 0x0001D950
		public event Action<Collision> onCollisionExit;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000564 RID: 1380 RVA: 0x0001F785 File Offset: 0x0001D985
		// (remove) Token: 0x06000565 RID: 1381 RVA: 0x0001F793 File Offset: 0x0001D993
		public event Action<ColisionBasicaV2> collisionEnterBase
		{
			add
			{
				this.m_historial.collisionEnterBase += value;
			}
			remove
			{
				this.m_historial.collisionEnterBase -= value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000566 RID: 1382 RVA: 0x0001F7A1 File Offset: 0x0001D9A1
		// (remove) Token: 0x06000567 RID: 1383 RVA: 0x0001F7AF File Offset: 0x0001D9AF
		public event Action<ColisionBasicaV2> collisionStayBase
		{
			add
			{
				this.m_historial.collisionStayBase += value;
			}
			remove
			{
				this.m_historial.collisionStayBase -= value;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000568 RID: 1384 RVA: 0x0001F7BD File Offset: 0x0001D9BD
		// (remove) Token: 0x06000569 RID: 1385 RVA: 0x0001F7CB File Offset: 0x0001D9CB
		public event Action<ColisionBasicaV2> collisionExitBase
		{
			add
			{
				this.m_historial.collisionExitBase += value;
			}
			remove
			{
				this.m_historial.collisionExitBase -= value;
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600056A RID: 1386 RVA: 0x0001F7D9 File Offset: 0x0001D9D9
		// (remove) Token: 0x0600056B RID: 1387 RVA: 0x0001F7E7 File Offset: 0x0001D9E7
		public event Action<PuppetPart.PartColision> collisionEnter
		{
			add
			{
				this.m_historial.collisionEnter += value;
			}
			remove
			{
				this.m_historial.collisionEnter -= value;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600056C RID: 1388 RVA: 0x0001F7F5 File Offset: 0x0001D9F5
		// (remove) Token: 0x0600056D RID: 1389 RVA: 0x0001F803 File Offset: 0x0001DA03
		public event Action<PuppetPart.PartColision> collisionStay
		{
			add
			{
				this.m_historial.collisionStay += value;
			}
			remove
			{
				this.m_historial.collisionStay -= value;
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600056E RID: 1390 RVA: 0x0001F811 File Offset: 0x0001DA11
		// (remove) Token: 0x0600056F RID: 1391 RVA: 0x0001F81F File Offset: 0x0001DA1F
		public event Action<PuppetPart.PartColision> collisionExit
		{
			add
			{
				this.m_historial.collisionExit += value;
			}
			remove
			{
				this.m_historial.collisionExit -= value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0001F82D File Offset: 0x0001DA2D
		public Rigidbody rigid
		{
			get
			{
				return this.m_Rigidbody;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0001F835 File Offset: 0x0001DA35
		public PuppetPartMainColliderVolumer mainColliderScaler
		{
			get
			{
				return this.m_PuppetPartMainColliderScaler;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0001F83D File Offset: 0x0001DA3D
		Transform IBoneReferenceable.bone
		{
			get
			{
				return this.muscle.target;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0001F84A File Offset: 0x0001DA4A
		public IHistorialColisiones<PuppetPart.PartColision> historial
		{
			get
			{
				return this.m_historial;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001F852 File Offset: 0x0001DA52
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001F85C File Offset: 0x0001DA5C
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			this.m_Saver = this.GetComponentNotNull<EmulatedStepVelocitySaver>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_CorrectorDeMasaParaMusculo = this.GetComponentNotNull<CorrectorDeMasaParaMusculo>();
			this.m_CorrectorDeMasaParaMusculo.weigthSumando = 0.85f;
			this.m_CorrectorDeMasaParaMusculo.weigthRestando = 0.75f;
			this.m_PuppetPartMainColliderScaler = this.GetComponentNotNull<PuppetPartMainColliderVolumer>();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001F8D8 File Offset: 0x0001DAD8
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_administrarMateriales)
			{
				this.SetDefaultMaterial();
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001F8F0 File Offset: 0x0001DAF0
		public void Init(PuppetParte parte, Muscle muscle, Side side, bool administrarMateriales, bool estimulable)
		{
			this.m_administrarMateriales = administrarMateriales;
			this.m_side = side;
			this.m_parte = parte;
			this.m_muscle = muscle;
			this.m_historial = new HistorialDeCollisionesPhysicas<PuppetPart.PartColision>(this);
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			if (estimulable)
			{
				this.m_TouchedBy = new PuppetPart.TouchedBy<TocanteObjeto>(this, this.m_PrioridadesDeObjetoEstimulado, this.m_historial, new TouchedBy<TocanteObjeto, PuppetPart, PuppetPart.PartColision, PuppetPart.TouchedBy<TocanteObjeto>.PartTouchStats>.Config
				{
					buscarEn = TouchedBy<TocanteObjeto, PuppetPart, PuppetPart.PartColision, PuppetPart.TouchedBy<TocanteObjeto>.PartTouchStats>.BuscarEn.rigids,
					buscarEnPadres = true
				});
			}
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001F986 File Offset: 0x0001DB86
		public bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques)
		{
			return this.m_TouchedBy != null && this.m_TouchedBy.ContieneEstimulosDeCharacter<EstimuloTactil>(character, toques);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001F99F File Offset: 0x0001DB9F
		bool IBasicUser<PuppetPart.PartColision, Collision>.PoblarColision(PuppetPart.PartColision fromPool, Collision collision)
		{
			fromPool.Poblar(collision, this, this.m_parte);
			return true;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001F9B0 File Offset: 0x0001DBB0
		public void SetDefaultMaterial()
		{
			for (int i = 0; i < this.muscle.colliders.Length; i++)
			{
				this.muscle.colliders[i].sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.skinNoBounce;
			}
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001F9F1 File Offset: 0x0001DBF1
		public sealed override void OnUpdateEvent6()
		{
			PuppetPart.TouchedBy<TocanteObjeto> touchedBy = this.m_TouchedBy;
			if (touchedBy == null)
			{
				return;
			}
			touchedBy.Update_();
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001FA03 File Offset: 0x0001DC03
		public sealed override void OnUpdateEvent1()
		{
			this.m_historial.AfterCollision();
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001FA10 File Offset: 0x0001DC10
		private void OnCollisionEnter(Collision collision)
		{
			this.m_historial.OnCollisionEnter(collision);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001FA1E File Offset: 0x0001DC1E
		private void OnCollisionStay(Collision collision)
		{
			this.m_historial.OnCollisionStay(collision);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001FA2C File Offset: 0x0001DC2C
		private void OnCollisionExit(Collision collision)
		{
			this.m_historial.OnCollisionExit(collision);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001FA3A File Offset: 0x0001DC3A
		public void UpdateColliders()
		{
			this.m_muscle.UpdateColliders();
			if (this.m_administrarMateriales)
			{
				this.SetDefaultMaterial();
			}
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001FA55 File Offset: 0x0001DC55
		string IStepVelocitySaver.get_name()
		{
			return base.name;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001FA5D File Offset: 0x0001DC5D
		bool IStepVelocitySaver.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001FA65 File Offset: 0x0001DC65
		void IStepVelocitySaver.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		Transform IStepVelocitySaver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000458 RID: 1112
		[ReadOnlyUI]
		[SerializeField]
		private bool m_administrarMateriales;

		// Token: 0x04000459 RID: 1113
		private Side m_side;

		// Token: 0x0400045A RID: 1114
		private Rigidbody m_Rigidbody;

		// Token: 0x0400045B RID: 1115
		private HistorialDeCollisionesPhysicas<PuppetPart.PartColision> m_historial;

		// Token: 0x0400045C RID: 1116
		[ReadOnlyUI]
		[SerializeField]
		private PuppetParte m_parte;

		// Token: 0x0400045D RID: 1117
		[ReadOnlyUI]
		[SerializeField]
		private Muscle m_muscle;

		// Token: 0x04000461 RID: 1121
		private Character m_Character;

		// Token: 0x04000462 RID: 1122
		private EmulatedStepVelocitySaver m_Saver;

		// Token: 0x04000463 RID: 1123
		[NonSerialized]
		private PuppetPart.TouchedBy<TocanteObjeto> m_TouchedBy;

		// Token: 0x04000464 RID: 1124
		private CorrectorDeMasaParaMusculo m_CorrectorDeMasaParaMusculo;

		// Token: 0x04000465 RID: 1125
		private PuppetPartMainColliderVolumer m_PuppetPartMainColliderScaler;

		// Token: 0x04000466 RID: 1126
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x02000110 RID: 272
		public sealed class TouchedBy<T> : TouchedBy<T, PuppetPart, PuppetPart.PartColision, PuppetPart.TouchedBy<T>.PartTouchStats> where T : TocanteObjeto
		{
			// Token: 0x06000586 RID: 1414 RVA: 0x0001FA76 File Offset: 0x0001DC76
			public TouchedBy(PuppetPart owner, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, HistorialDeCollisionesPhysicas<PuppetPart.PartColision> historial, TouchedBy<T, PuppetPart, PuppetPart.PartColision, PuppetPart.TouchedBy<T>.PartTouchStats>.Config config)
				: base(owner, PrioridadesDeObjetoEstimulado, historial, config)
			{
			}

			// Token: 0x02000111 RID: 273
			[Serializable]
			public sealed class PartTouchStats : TouchedBy<T, PuppetPart, PuppetPart.PartColision, PuppetPart.TouchedBy<T>.PartTouchStats>.TouchStats
			{
				// Token: 0x17000113 RID: 275
				// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001FA83 File Offset: 0x0001DC83
				public List<PuppetPart.PartColision> collisionesContraPuppetPart
				{
					get
					{
						return base.collisions;
					}
				}

				// Token: 0x17000114 RID: 276
				// (get) Token: 0x06000588 RID: 1416 RVA: 0x0001FA8B File Offset: 0x0001DC8B
				public PuppetPart parteEstimulada
				{
					get
					{
						return base.touched;
					}
				}

				// Token: 0x06000589 RID: 1417 RVA: 0x0001FA94 File Offset: 0x0001DC94
				protected override void CargarPartesTocadas()
				{
					List<PuppetPart.PartColision> collisions = base.collisions;
					for (int i = 0; i < collisions.Count; i++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = collisions[i].parte.ParseAParteHumana();
						base.AddParteEstimulada(parteDelCuerpoHumano);
					}
				}
			}
		}

		// Token: 0x02000112 RID: 274
		public sealed class PartColision : ColisionPhysicaV2
		{
			// Token: 0x17000115 RID: 277
			// (get) Token: 0x0600058B RID: 1419 RVA: 0x0001FADB File Offset: 0x0001DCDB
			// (set) Token: 0x0600058C RID: 1420 RVA: 0x0001FAE3 File Offset: 0x0001DCE3
			public PuppetParte parte { get; private set; }

			// Token: 0x0600058D RID: 1421 RVA: 0x0001FAEC File Offset: 0x0001DCEC
			public void Poblar(Collision collision, PuppetPart part, PuppetParte parte)
			{
				Vector3 vector;
				Vector3 vector2;
				collision.PromediarPuntoYNormalDeCollision(out vector, out vector2);
				this.parte = parte;
				base.PoblarDesdeCollision(collision, vector2, vector, part, part.m_muscle.target);
			}

			// Token: 0x0600058E RID: 1422 RVA: 0x0001FB1F File Offset: 0x0001DD1F
			protected sealed override void OnClearPhysica()
			{
				this.parte = PuppetParte.spine2;
			}
		}
	}
}
