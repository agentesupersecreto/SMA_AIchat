using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000266 RID: 614
	public sealed class HandPickController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x0600102B RID: 4139 RVA: 0x0004B0B5 File Offset: 0x000492B5
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x0004B0BE File Offset: 0x000492BE
		public HandPickController.Hand r
		{
			get
			{
				return this.m_r;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x0004B0C6 File Offset: 0x000492C6
		public HandPickController.Hand l
		{
			get
			{
				return this.m_l;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x0004B0CE File Offset: 0x000492CE
		public LayerMask castingLayer
		{
			get
			{
				return this.m_castingLayer;
			}
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x0004B0D8 File Offset: 0x000492D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interacciones = this.GetComponentEnRoot(false);
			if (this.m_Interacciones == null)
			{
				throw new ArgumentNullException("m_InteraccionesBasicasDeMale", "m_InteraccionesBasicasDeMale null reference.");
			}
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			if (!this.m_Interacciones.isAwaken)
			{
				this.m_Interacciones.ManualAwake();
			}
			this.m_r.Init(Side.R, this);
			this.m_l.Init(Side.L, this);
			int num = 0;
			for (int i = 0; i < 32; i++)
			{
				if (!Physics.GetIgnoreLayerCollision(this.m_handColliderLayer, i))
				{
					num |= i.ToLayerMask();
				}
			}
			this.m_castingLayer = num;
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0004B1A0 File Offset: 0x000493A0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interacciones.comenzada += this.M_InteraccionesBasicasDeMale_comenzada;
			this.m_Interacciones.terminada += this.M_InteraccionesBasicasDeMale_terminada;
			this.m_r.OnEnable();
			this.m_l.OnEnable();
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0004B1F8 File Offset: 0x000493F8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Interacciones != null)
			{
				this.m_Interacciones.comenzada -= this.M_InteraccionesBasicasDeMale_comenzada;
				this.m_Interacciones.terminada -= this.M_InteraccionesBasicasDeMale_terminada;
			}
			this.m_r.OnDisable();
			this.m_l.OnDisable();
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0004B258 File Offset: 0x00049458
		private void M_InteraccionesBasicasDeMale_comenzada(InteraccionDeCharacter obj)
		{
			HandPickHandlerBase componentInChildren = obj.instancia.GetComponentInChildren<HandPickHandlerBase>();
			if (componentInChildren == null)
			{
				return;
			}
			this.m_l.OInterComienza(obj, componentInChildren);
			this.m_r.OInterComienza(obj, componentInChildren);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0004B295 File Offset: 0x00049495
		private void M_InteraccionesBasicasDeMale_terminada(InteraccionDeCharacter obj)
		{
			this.m_l.OInterTermina(obj);
			this.m_r.OInterTermina(obj);
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0004B2AF File Offset: 0x000494AF
		public override void OnUpdateEvent1()
		{
			this.m_l.Update(this);
			this.m_r.Update(this);
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0004B2C9 File Offset: 0x000494C9
		private void OnDrawGizmosSelected()
		{
			this.m_l.OnDrawGizmosSelected();
			this.m_r.OnDrawGizmosSelected();
		}

		// Token: 0x04000BA2 RID: 2978
		public float velocidadMod = 1f;

		// Token: 0x04000BA3 RID: 2979
		public HandPickController.Config config = new HandPickController.Config();

		// Token: 0x04000BA4 RID: 2980
		private IInteraccionesDeCharacter m_Interacciones;

		// Token: 0x04000BA5 RID: 2981
		[SerializeField]
		private int m_handColliderLayer;

		// Token: 0x04000BA6 RID: 2982
		[SerializeField]
		private HandPickController.Hand m_r = new HandPickController.Hand();

		// Token: 0x04000BA7 RID: 2983
		[SerializeField]
		private HandPickController.Hand m_l = new HandPickController.Hand();

		// Token: 0x04000BA8 RID: 2984
		private Character m_Character;

		// Token: 0x04000BA9 RID: 2985
		[ReadOnlyUI]
		[SerializeField]
		private LayerMask m_castingLayer;

		// Token: 0x02000267 RID: 615
		[Serializable]
		public class Config
		{
			// Token: 0x04000BAA RID: 2986
			public float velocidadPosicion = 6f;

			// Token: 0x04000BAB RID: 2987
			public float velocidadRotacion = 999f;
		}

		// Token: 0x02000268 RID: 616
		[Serializable]
		public class Hand
		{
			// Token: 0x170003FF RID: 1023
			// (get) Token: 0x06001038 RID: 4152 RVA: 0x0004B333 File Offset: 0x00049533
			public bool tomando
			{
				get
				{
					return this.w == 1f || this.m_TomandoObjetoPhysico;
				}
			}

			// Token: 0x17000400 RID: 1024
			// (get) Token: 0x06001039 RID: 4153 RVA: 0x0004B34A File Offset: 0x0004954A
			public bool tomandoObjetoPhysico
			{
				get
				{
					return this.m_TomandoObjetoPhysico;
				}
			}

			// Token: 0x17000401 RID: 1025
			// (get) Token: 0x0600103A RID: 4154 RVA: 0x0004B352 File Offset: 0x00049552
			public bool dedosCollisionandoContraObjetoPhysico
			{
				get
				{
					return this.m_dedosCollisionandoContraObjetoPhysico;
				}
			}

			// Token: 0x17000402 RID: 1026
			// (get) Token: 0x0600103B RID: 4155 RVA: 0x0004B35A File Offset: 0x0004955A
			public HandPickHandlerBase currentHandler
			{
				get
				{
					HandPickController.CurrentHandler currentHandler = this.m_CurrentHandler;
					if (currentHandler == null)
					{
						return null;
					}
					return currentHandler.handPickHandler;
				}
			}

			// Token: 0x17000403 RID: 1027
			// (get) Token: 0x0600103C RID: 4156 RVA: 0x0004B36D File Offset: 0x0004956D
			[TupleElementNames(new string[] { "tomando", "punto", "normal" })]
			public IReadOnlyList<ValueTuple<Collider, Vector3, Vector3>> collidersTomando
			{
				[return: TupleElementNames(new string[] { "tomando", "punto", "normal" })]
				get
				{
					return this.m_collidersTomando;
				}
			}

			// Token: 0x17000404 RID: 1028
			// (get) Token: 0x0600103D RID: 4157 RVA: 0x0004B375 File Offset: 0x00049575
			public Vector3 currentWorldPresionPointCentral
			{
				get
				{
					return this.m_currentWorldPresionPointCentral;
				}
			}

			// Token: 0x17000405 RID: 1029
			// (get) Token: 0x0600103E RID: 4158 RVA: 0x0004B37D File Offset: 0x0004957D
			public Vector3 currentWorldPresionPointA
			{
				get
				{
					return this.m_currentWorldPresionPointA;
				}
			}

			// Token: 0x17000406 RID: 1030
			// (get) Token: 0x0600103F RID: 4159 RVA: 0x0004B385 File Offset: 0x00049585
			public Vector3 currentWorldPresionPointB
			{
				get
				{
					return this.m_currentWorldPresionPointB;
				}
			}

			// Token: 0x17000407 RID: 1031
			// (get) Token: 0x06001040 RID: 4160 RVA: 0x0004B38D File Offset: 0x0004958D
			public Vector3 currentWorldPresionPointC
			{
				get
				{
					return this.m_currentWorldPresionPointC;
				}
			}

			// Token: 0x17000408 RID: 1032
			// (get) Token: 0x06001041 RID: 4161 RVA: 0x0004B395 File Offset: 0x00049595
			public Vector3 currentWorldPresionPointD
			{
				get
				{
					return this.m_currentWorldPresionPointD;
				}
			}

			// Token: 0x17000409 RID: 1033
			// (get) Token: 0x06001042 RID: 4162 RVA: 0x0004B39D File Offset: 0x0004959D
			public Vector3 startWorldPresionPoint
			{
				get
				{
					return this.m_startWorldPresionPoint;
				}
			}

			// Token: 0x1700040A RID: 1034
			// (get) Token: 0x06001043 RID: 4163 RVA: 0x0004B3A5 File Offset: 0x000495A5
			public ModificableDeBool cerrandoManoOR
			{
				get
				{
					return this.m_cerrandoManoOR;
				}
			}

			// Token: 0x1700040B RID: 1035
			// (get) Token: 0x06001044 RID: 4164 RVA: 0x0004B3AD File Offset: 0x000495AD
			public ModificableDeFloat dedosTomandoMinCountMod
			{
				get
				{
					return this.m_dedosTomandoMinCountMod;
				}
			}

			// Token: 0x1700040C RID: 1036
			// (get) Token: 0x06001045 RID: 4165 RVA: 0x0004B3B5 File Offset: 0x000495B5
			public ModificableDeBool puedeTomarObjetoPhysicoAnd
			{
				get
				{
					return this.m_puedeTomarObjetoPhysicoAnd;
				}
			}

			// Token: 0x1700040D RID: 1037
			// (get) Token: 0x06001046 RID: 4166 RVA: 0x0004B3BD File Offset: 0x000495BD
			public HandPickController owner
			{
				get
				{
					return this.m_owner;
				}
			}

			// Token: 0x06001047 RID: 4167 RVA: 0x0004B3C5 File Offset: 0x000495C5
			public void Init(Side Side, HandPickController Owner)
			{
				this.m_owner = Owner;
				this.m_side = Side;
			}

			// Token: 0x06001048 RID: 4168 RVA: 0x0004B3D5 File Offset: 0x000495D5
			internal void OnEnable()
			{
				this.m_CurrentHandler = new HandPickController.CurrentHandler();
			}

			// Token: 0x06001049 RID: 4169 RVA: 0x0004B3E2 File Offset: 0x000495E2
			internal void OnDisable()
			{
				this.m_lastTmandoState = false;
				this.m_CurrentHandler = null;
			}

			// Token: 0x0600104A RID: 4170 RVA: 0x0004B3F4 File Offset: 0x000495F4
			internal void OInterComienza(InteraccionDeCharacter obj, HandPickHandlerBase handler)
			{
				if (handler.side != this.m_side)
				{
					return;
				}
				this.m_CurrentHandler.interaccionDeCharacter = obj;
				this.m_CurrentHandler.handPickHandler = handler;
				this.m_CurrentHandler.dedosIK = ((handler != null) ? handler.GetComponent<DedosIK>() : null);
				if (!this.m_CurrentHandler.isValid)
				{
					this.m_CurrentHandler.Clear();
					return;
				}
			}

			// Token: 0x0600104B RID: 4171 RVA: 0x0004B458 File Offset: 0x00049658
			internal void OInterTermina(InteraccionDeCharacter obj)
			{
				if (this.m_CurrentHandler.interaccionDeCharacter == obj)
				{
					this.m_CurrentHandler.SetDedosEnable(false);
					this.m_CurrentHandler.Clear();
				}
			}

			// Token: 0x0600104C RID: 4172 RVA: 0x0004B480 File Offset: 0x00049680
			internal void Update(HandPickController controller)
			{
				if (!this.canPick || !this.m_CurrentHandler.isValid)
				{
					this.m_lastTmandoState = false;
					this.m_currentWorldPresionPointCentral = Vector3.zero;
					this.m_TomandoObjetoPhysico = false;
					this.w = 0f;
					this.m_wPulgar = (this.m_wIndex = (this.m_wMiddle = (this.m_wAngular = (this.m_wLittle = 0f))));
					this.m_dedosCollisionandoContraObjetoPhysico = false;
					this.m_collidersTomando.Clear();
					return;
				}
				this.m_CurrentHandler.SetDedosEnable(true);
				int num = 0;
				Vector3 vector;
				Collider collider;
				Vector3 vector2;
				Vector3 vector3;
				if (this.UpdateFinger(controller, this.m_CurrentHandler.handPickHandler.pulgar, this.m_CurrentHandler.dedosIK.pulgar, out vector, out collider, out vector2, out vector3, out this.m_wPulgar))
				{
					num++;
				}
				Vector3 vector4;
				Collider collider2;
				Vector3 vector5;
				Vector3 vector6;
				if (this.UpdateFinger(controller, this.m_CurrentHandler.handPickHandler.indice, this.m_CurrentHandler.dedosIK.indice, out vector4, out collider2, out vector5, out vector6, out this.m_wIndex))
				{
					num++;
				}
				Vector3 vector7;
				Collider collider3;
				Vector3 vector8;
				Vector3 vector9;
				if (this.UpdateFinger(controller, this.m_CurrentHandler.handPickHandler.medio, this.m_CurrentHandler.dedosIK.medio, out vector7, out collider3, out vector8, out vector9, out this.m_wMiddle))
				{
					num++;
				}
				Vector3 vector10;
				Collider collider4;
				Vector3 vector11;
				Vector3 vector12;
				if (this.UpdateFinger(controller, this.m_CurrentHandler.handPickHandler.angular, this.m_CurrentHandler.dedosIK.angular, out vector10, out collider4, out vector11, out vector12, out this.m_wAngular))
				{
					num++;
				}
				Vector3 vector13;
				Collider collider5;
				Vector3 vector14;
				Vector3 vector15;
				if (this.UpdateFinger(controller, this.m_CurrentHandler.handPickHandler.menique, this.m_CurrentHandler.dedosIK.menique, out vector13, out collider5, out vector14, out vector15, out this.m_wLittle))
				{
					num++;
				}
				this.m_currentWorldPresionPointA = vector;
				this.m_currentWorldPresionPointB = vector4;
				this.m_currentWorldPresionPointC = vector13;
				this.m_currentWorldPresionPointD = this.m_CurrentHandler.handPickHandler.GetHandColliders().colliders.handCenter.boneCollider.bounds.center;
				vector7 = Vector3.Lerp(vector7, vector4, 0.8f);
				vector10 = Vector3.Lerp(vector10, vector4, 0.8f);
				vector13 = Vector3.Lerp(vector13, vector4, 0.8f);
				Vector3 vector16 = (vector4 + vector7 + vector10 + vector13) / 4f;
				this.m_currentWorldPresionPointCentral = (vector16 + vector) / 2f;
				int num2 = Mathf.Clamp(Mathf.CeilToInt(this.m_dedosTomandoMinCountMod.ModificarValor(3f)), 1, 5);
				bool flag = num >= num2;
				this.m_lastTmandoDedosState = flag;
				float num3;
				if (!this.m_dedosTomandoBuffer.IsBuffered(flag != this.m_lastTmandoDedosState, out num3) || flag)
				{
					this.m_lastTmandoDedosState = flag;
				}
				if (this.m_lastTmandoDedosState != flag)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						Time.frameCount.ToString(),
						" valor was bufered, valor real: ",
						flag.ToString(),
						" pero se retorno: ",
						this.m_lastTmandoDedosState.ToString()
					}));
				}
				if (flag || !this.m_lastTmandoDedosState)
				{
					this.m_collidersTomando.Clear();
				}
				if (flag)
				{
					if (collider != null)
					{
						this.m_collidersTomando.Add(new ValueTuple<Collider, Vector3, Vector3>(collider, vector2, vector3));
					}
					if (collider2 != null)
					{
						this.m_collidersTomando.Add(new ValueTuple<Collider, Vector3, Vector3>(collider2, vector5, vector6));
					}
					if (collider3 != null)
					{
						this.m_collidersTomando.Add(new ValueTuple<Collider, Vector3, Vector3>(collider3, vector8, vector9));
					}
					if (collider4 != null)
					{
						this.m_collidersTomando.Add(new ValueTuple<Collider, Vector3, Vector3>(collider4, vector11, vector12));
					}
					if (collider5 != null)
					{
						this.m_collidersTomando.Add(new ValueTuple<Collider, Vector3, Vector3>(collider5, vector14, vector15));
					}
				}
				bool flag2 = this.m_cerrandoManoOR.Or(false);
				this.m_TomandoObjetoPhysico = flag2 && this.m_lastTmandoDedosState && this.m_collidersTomando.Count > 0;
				this.m_TomandoObjetoPhysico = this.m_puedeTomarObjetoPhysicoAnd.And(this.m_TomandoObjetoPhysico);
				this.m_dedosCollisionandoContraObjetoPhysico = this.m_TomandoObjetoPhysico && this.m_wPulgar < 1f && this.m_wIndex < 1f && this.m_wMiddle < 1f && this.m_wAngular < 1f && this.m_wLittle < 1f;
				if (this.m_lastTmandoState != this.tomando && this.tomando)
				{
					this.m_startWorldPresionPoint = this.m_currentWorldPresionPointCentral;
				}
				this.m_lastTmandoState = this.tomando;
				this.m_LastW = this.w;
			}

			// Token: 0x0600104D RID: 4173 RVA: 0x0004B938 File Offset: 0x00049B38
			private bool UpdateFinger(HandPickController controller, HandPickHandlerBase.Par par, DedosIK.Par parIK, out Vector3 currentWorldPresionPoint, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal, out float fingerW)
			{
				float num = parIK.hand.transform.lossyScale.Escala();
				bool flag;
				Vector3 vector;
				Quaternion quaternion;
				par.MoveTowardsPosePhysics(this.w, this.w, this.m_CurrentHandler.handPickHandler.config.outPowerPosicion, this.m_CurrentHandler.handPickHandler.config.outPowerRotacion, this.w > this.m_LastW || this.w == 1f || this.w == 0f, this.useCollision ? null : new LayerMask?((this.overrideLayerMask != null) ? this.overrideLayerMask.Value : controller.m_castingLayer), num, out flag, out currentWorldPresionPoint, controller.config.velocidadPosicion * controller.velocidadMod * num, controller.config.velocidadRotacion * controller.velocidadMod, out vector, out quaternion, out chocando, out collisionPoint, out collisionNormal, out fingerW);
				par.tipTarget.SetPositionAndRotation(vector, quaternion);
				return flag;
			}

			// Token: 0x0600104E RID: 4174 RVA: 0x0004BA40 File Offset: 0x00049C40
			internal void OnDrawGizmosSelected()
			{
				if (this.tomando)
				{
					Gizmos.color = Color.green;
					Gizmos.DrawSphere(this.m_startWorldPresionPoint, 0.01f);
					Gizmos.color = Color.red;
					Gizmos.DrawSphere(this.m_currentWorldPresionPointCentral, 0.01f);
				}
			}

			// Token: 0x04000BAC RID: 2988
			public const int dedosTomandoMinCount = 3;

			// Token: 0x04000BAD RID: 2989
			[Range(0f, 1f)]
			public float w;

			// Token: 0x04000BAE RID: 2990
			[ReadOnlyUI]
			[SerializeField]
			private float m_LastW;

			// Token: 0x04000BAF RID: 2991
			[ReadOnlyUI]
			[SerializeField]
			private float m_wPulgar;

			// Token: 0x04000BB0 RID: 2992
			[ReadOnlyUI]
			[SerializeField]
			private float m_wIndex;

			// Token: 0x04000BB1 RID: 2993
			[ReadOnlyUI]
			[SerializeField]
			private float m_wMiddle;

			// Token: 0x04000BB2 RID: 2994
			[ReadOnlyUI]
			[SerializeField]
			private float m_wAngular;

			// Token: 0x04000BB3 RID: 2995
			[ReadOnlyUI]
			[SerializeField]
			private float m_wLittle;

			// Token: 0x04000BB4 RID: 2996
			[ReadOnlyUI]
			[SerializeField]
			private bool m_TomandoObjetoPhysico;

			// Token: 0x04000BB5 RID: 2997
			[ReadOnlyUI]
			[SerializeField]
			private bool m_dedosCollisionandoContraObjetoPhysico;

			// Token: 0x04000BB6 RID: 2998
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_startWorldPresionPoint;

			// Token: 0x04000BB7 RID: 2999
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentWorldPresionPointCentral;

			// Token: 0x04000BB8 RID: 3000
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentWorldPresionPointA;

			// Token: 0x04000BB9 RID: 3001
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentWorldPresionPointB;

			// Token: 0x04000BBA RID: 3002
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentWorldPresionPointC;

			// Token: 0x04000BBB RID: 3003
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentWorldPresionPointD;

			// Token: 0x04000BBC RID: 3004
			public bool canPick = true;

			// Token: 0x04000BBD RID: 3005
			public bool useCollision = true;

			// Token: 0x04000BBE RID: 3006
			public LayerMask? overrideLayerMask;

			// Token: 0x04000BBF RID: 3007
			[SerializeField]
			private ModificableDeBool m_cerrandoManoOR = new ModificableDeBool(false);

			// Token: 0x04000BC0 RID: 3008
			[SerializeField]
			private ModificableDeFloat m_dedosTomandoMinCountMod = new ModificableDeFloat(1f);

			// Token: 0x04000BC1 RID: 3009
			[SerializeField]
			private ModificableDeBool m_puedeTomarObjetoPhysicoAnd = new ModificableDeBool(true);

			// Token: 0x04000BC2 RID: 3010
			private bool m_lastTmandoState;

			// Token: 0x04000BC3 RID: 3011
			private bool m_lastTmandoDedosState;

			// Token: 0x04000BC4 RID: 3012
			[SerializeField]
			[ReadOnlyUI]
			private HandPickController.CurrentHandler m_CurrentHandler;

			// Token: 0x04000BC5 RID: 3013
			private List<ValueTuple<Collider, Vector3, Vector3>> m_collidersTomando = new List<ValueTuple<Collider, Vector3, Vector3>>();

			// Token: 0x04000BC6 RID: 3014
			private BufferedCoolDown m_dedosTomandoBuffer = new BufferedCoolDown();

			// Token: 0x04000BC7 RID: 3015
			[ReadOnlyUI]
			[SerializeField]
			private Side m_side;

			// Token: 0x04000BC8 RID: 3016
			[ReadOnlyUI]
			[SerializeField]
			private HandPickController m_owner;
		}

		// Token: 0x02000269 RID: 617
		[Serializable]
		private class CurrentHandler
		{
			// Token: 0x1700040E RID: 1038
			// (get) Token: 0x06001050 RID: 4176 RVA: 0x0004BADF File Offset: 0x00049CDF
			public bool isValid
			{
				get
				{
					return this.interaccionDeCharacter != null && this.handPickHandler != null && this.handPickHandler.isValid;
				}
			}

			// Token: 0x06001051 RID: 4177 RVA: 0x0004BB04 File Offset: 0x00049D04
			public void SetDedosEnable(bool enabled)
			{
				if (this.dedosIK != null && this.dedosIK.enabled != enabled)
				{
					this.dedosIK.enabled = enabled;
				}
			}

			// Token: 0x06001052 RID: 4178 RVA: 0x0004BB2E File Offset: 0x00049D2E
			public void Clear()
			{
				this.interaccionDeCharacter = null;
				this.handPickHandler = null;
				if (this.dedosIK != null && this.dedosIK.enabled)
				{
					this.dedosIK.enabled = false;
				}
				this.dedosIK = null;
			}

			// Token: 0x04000BC9 RID: 3017
			[SerializeReference]
			public InteraccionDeCharacter interaccionDeCharacter;

			// Token: 0x04000BCA RID: 3018
			public HandPickHandlerBase handPickHandler;

			// Token: 0x04000BCB RID: 3019
			public DedosIK dedosIK;
		}
	}
}
