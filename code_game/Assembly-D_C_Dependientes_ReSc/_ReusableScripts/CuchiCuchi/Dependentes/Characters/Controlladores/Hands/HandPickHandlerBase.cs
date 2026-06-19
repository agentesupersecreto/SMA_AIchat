using System;
using System.Collections.Generic;
using Assets.Base.Joints.Runtime.Historiales;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200024A RID: 586
	public abstract class HandPickHandlerBase : AplicableCustomMonobehaviour
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x00044D09 File Offset: 0x00042F09
		public bool isValid
		{
			get
			{
				return this.pulgar.isValid && this.indice.isValid;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x00044D25 File Offset: 0x00042F25
		public Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00044D30 File Offset: 0x00042F30
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Side side = this.m_side;
			if (side - Side.L > 1)
			{
				throw new ArgumentOutOfRangeException(this.m_side.ToString());
			}
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x000299B4 File Offset: 0x00027BB4
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Auto Fill",
				confirmar = true,
				playTimeVisible = false
			};
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00044D67 File Offset: 0x00042F67
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.m_EditorAutoFill.Set(this);
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00044D7B File Offset: 0x00042F7B
		protected void InitFingers()
		{
			this.pulgar.Init(this);
			this.indice.Init(this);
			this.medio.Init(this);
			this.angular.Init(this);
			this.menique.Init(this);
		}

		// Token: 0x06000F88 RID: 3976
		public abstract CreadorDeCollidersParaManos GetHandColliders();

		// Token: 0x06000F89 RID: 3977 RVA: 0x00044DBC File Offset: 0x00042FBC
		protected void SetUser(Transform InteractionHand, Rigidbody rigidbodyHandUser, CreadorDeCollidersParaManos colliders)
		{
			this.pulgar.SetUser(InteractionHand, rigidbodyHandUser, colliders);
			this.indice.SetUser(InteractionHand, rigidbodyHandUser, colliders);
			this.medio.SetUser(InteractionHand, rigidbodyHandUser, colliders);
			this.angular.SetUser(InteractionHand, rigidbodyHandUser, colliders);
			this.menique.SetUser(InteractionHand, rigidbodyHandUser, colliders);
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x00044E0F File Offset: 0x0004300F
		protected void ClearUser()
		{
			this.pulgar.ClearUser();
			this.indice.ClearUser();
			this.medio.ClearUser();
			this.angular.ClearUser();
			this.menique.ClearUser();
		}

		// Token: 0x04000AB4 RID: 2740
		public HandPickHandlerBase.Config config;

		// Token: 0x04000AB5 RID: 2741
		public HandPickHandlerBase.Par pulgar;

		// Token: 0x04000AB6 RID: 2742
		public HandPickHandlerBase.Par indice;

		// Token: 0x04000AB7 RID: 2743
		public HandPickHandlerBase.Par medio;

		// Token: 0x04000AB8 RID: 2744
		public HandPickHandlerBase.Par angular;

		// Token: 0x04000AB9 RID: 2745
		public HandPickHandlerBase.Par menique;

		// Token: 0x04000ABA RID: 2746
		[SerializeField]
		private float m_toleranciaEnGrados = 75f;

		// Token: 0x04000ABB RID: 2747
		[SerializeField]
		protected Side m_side;

		// Token: 0x04000ABC RID: 2748
		[Header("EDITOR")]
		[SerializeField]
		private HandPickHandlerBase.EditorAutoFill m_EditorAutoFill;

		// Token: 0x0200024B RID: 587
		[Serializable]
		public class Config
		{
			// Token: 0x04000ABD RID: 2749
			public float outPowerPosicion = 1f;

			// Token: 0x04000ABE RID: 2750
			public float outPowerRotacion = 2f;
		}

		// Token: 0x0200024C RID: 588
		[Serializable]
		public class Par
		{
			// Token: 0x170003EA RID: 1002
			// (get) Token: 0x06000F8D RID: 3981 RVA: 0x00044E79 File Offset: 0x00043079
			public bool isValid
			{
				get
				{
					return this.m_boneHand != null && this.m_recopilador != null;
				}
			}

			// Token: 0x06000F8E RID: 3982 RVA: 0x00044E98 File Offset: 0x00043098
			public void Init(HandPickHandlerBase parent)
			{
				if (this.tipStart == null)
				{
					throw new ArgumentNullException("tipStart", "tipStart null reference.");
				}
				if (this.tipEnd == null)
				{
					throw new ArgumentNullException("tipEnd", "tipEnd null reference.");
				}
				if (this.bone3Start == null)
				{
					throw new ArgumentNullException("bone3Start", "bone3Start null reference.");
				}
				this.m_parent = parent;
				if (this.m_parent == null)
				{
					throw new ArgumentNullException("m_parent", "m_parent null reference.");
				}
				this.m_usaMedTip = this.tipMed != null;
				this.m_localDirectionToBone3 = this.tipStart.InverseTransformDirection(this.bone3Start.position - this.tipStart.position).normalized;
			}

			// Token: 0x06000F8F RID: 3983 RVA: 0x00044F6C File Offset: 0x0004316C
			public void SetUser(Transform BoneHand, Rigidbody rigidbodyHandUser, CreadorDeCollidersParaManos colliders)
			{
				this.ClearUser();
				this.m_boneHand = BoneHand;
				if (this.m_boneHand == null)
				{
					throw new ArgumentNullException("interactionHand", "interactionHand null reference.");
				}
				if (this.handStart == this.m_boneHand)
				{
					throw new InvalidOperationException();
				}
				AnimatorDedoParteCollider animatorCollider = colliders.colliders.GetAnimatorCollider(this.bone1);
				AnimatorDedoParteCollider animatorCollider2 = colliders.colliders.GetAnimatorCollider(this.bone2);
				AnimatorDedoParteCollider animatorCollider3 = colliders.colliders.GetAnimatorCollider(this.bone3);
				this.m_FingerColliders = new Collider[] { animatorCollider.col, animatorCollider2.col, animatorCollider3.col };
				this.m_FingerCollidersSet = new HashSet<Collider>(this.m_FingerColliders);
				this.m_recopilador = rigidbodyHandUser.gameObject.AddComponent<RecopiladorDeDatosDeCurrentCollisionesDeColliders>();
				this.m_recopilador.Init(this.m_FingerColliders);
			}

			// Token: 0x06000F90 RID: 3984 RVA: 0x0004504D File Offset: 0x0004324D
			public void ClearUser()
			{
				if (this.m_recopilador != null)
				{
					Object.Destroy(this.m_recopilador);
				}
				this.m_recopilador = null;
				this.m_boneHand = null;
			}

			// Token: 0x06000F91 RID: 3985 RVA: 0x00045078 File Offset: 0x00043278
			public void CurrentPose(float wP, float wR, float outPowP, float outPowR, out Vector3 posicion, out Quaternion rotacion)
			{
				if (!this.m_usaMedTip)
				{
					posicion = Vector3.Slerp(this.tipStart.position, this.tipEnd.position, wP.OutPow(outPowP));
					rotacion = Quaternion.Slerp(this.tipStart.rotation, this.tipEnd.rotation, wR.OutPow(outPowR));
					return;
				}
				posicion = MathfExtension.SlerpConMedio(this.tipStart.position, this.tipMed.position, this.tipEnd.position, wP, outPowP, 1f);
				rotacion = MathfExtension.SlerpConMedio(this.tipStart.rotation, this.tipMed.rotation, this.tipEnd.rotation, wR, outPowR, 1f);
			}

			// Token: 0x06000F92 RID: 3986 RVA: 0x0004514C File Offset: 0x0004334C
			private float CalculeWFromDistance(Vector3 startPosition, Vector3 medPosition, Vector3 endPosition, float distance)
			{
				float num;
				if (!this.m_usaMedTip)
				{
					num = Vector3.Distance(startPosition, endPosition);
				}
				else
				{
					num = Vector3.Distance(startPosition, medPosition) + Vector3.Distance(medPosition, endPosition);
				}
				return Mathf.InverseLerp(0f, num, distance);
			}

			// Token: 0x06000F93 RID: 3987 RVA: 0x00045188 File Offset: 0x00043388
			public void MoveTowardsPose(LayerMask? doCastTo, float wP, float wR, float? forzedW, float outPowP, float outPowR, float vPosition, float vRotation, out Vector3 posicion, out Quaternion rotacion)
			{
				if (forzedW == null)
				{
					this.m_wP = Mathf.MoveTowards(this.m_wP, wP, Time.deltaTime * vPosition);
					this.m_wR = Mathf.MoveTowards(this.m_wR, wR, Time.deltaTime * vRotation);
				}
				else
				{
					this.m_wP = Mathf.MoveTowards(this.m_wP, forzedW.Value, Time.deltaTime * vPosition * 0.5f);
					this.m_wR = Mathf.MoveTowards(this.m_wR, forzedW.Value, Time.deltaTime * vRotation * 0.5f);
				}
				this.CurrentPose(this.m_wP, this.m_wR, outPowP, outPowR, out posicion, out rotacion);
				posicion = Vector3.MoveTowards(this.tipTarget.position, posicion, Time.deltaTime * vPosition);
				rotacion = Quaternion.RotateTowards(this.tipTarget.rotation, rotacion, Time.deltaTime * vRotation);
			}

			// Token: 0x06000F94 RID: 3988 RVA: 0x00045288 File Offset: 0x00043488
			public void MoveTowardsPosePhysics(float wP, float wR, float outPowP, float outPowR, bool apretando, LayerMask? doCastTo, float handWScale, out bool collisionando, out Vector3 currentWorldPresionPoint, float vPosition, float vRotation, out Vector3 handSpacePosicion, out Quaternion handSpaceRotacion, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal, out float fingerW)
			{
				chocando = null;
				collisionPoint = default(Vector3);
				collisionNormal = default(Vector3);
				collisionando = false;
				float wP2 = this.m_wP;
				float wR2 = this.m_wR;
				currentWorldPresionPoint = this.m_boneHand.TransformPoint(this.handStart.InverseTransformPoint(this.tipTarget.position));
				Vector3 vector = this.m_boneHand.TransformPoint(this.handStart.InverseTransformPoint(this.tipStart.position));
				Vector3 vector2 = (this.m_usaMedTip ? this.m_boneHand.TransformPoint(this.handStart.InverseTransformPoint(this.tipMed.position)) : Vector3.zero);
				Vector3 vector3 = this.m_boneHand.TransformPoint(this.handStart.InverseTransformPoint(this.tipEnd.position));
				float? num = null;
				if (doCastTo != null)
				{
					float num2 = 0.004f * handWScale;
					float num3;
					collisionando = this.RayCastRecorrido(num2, vector, vector2, vector3, doCastTo.Value, out chocando, out collisionPoint, out collisionNormal, out num3);
					if (collisionando)
					{
						float num4 = this.retrocederOffset * handWScale;
						num = new float?(this.CalculeWFromDistance(vector, vector2, vector3, num3 - num4));
					}
					else if (wP >= 1f)
					{
						collisionando = this.RayCastRecorridoExtra(num2, vector, vector2, vector3, doCastTo.Value, handWScale, out chocando, out collisionPoint, out collisionNormal, out num3);
					}
				}
				this.MoveTowardsPose(doCastTo, wP, wR, num, outPowP, outPowR, vPosition, vRotation, out handSpacePosicion, out handSpaceRotacion);
				fingerW = ((num != null) ? num.Value : this.m_wP);
				if (doCastTo == null)
				{
					collisionando = this.m_recopilador.CollisisonandoHacia(vector3, this.m_parent.m_toleranciaEnGrados, out chocando, out collisionPoint, out collisionNormal);
					if (collisionando)
					{
						this.m_wP = wP2;
						this.m_wR = wR2;
						handSpacePosicion = this.tipTarget.position;
						handSpaceRotacion = this.tipTarget.rotation;
						return;
					}
				}
			}

			// Token: 0x06000F95 RID: 3989 RVA: 0x00045478 File Offset: 0x00043678
			[Obsolete("usar sphere cast por presicion")]
			private static bool RayCastHitHacia(Vector3 startPoistion, Vector3 endPoistion, LayerMask layer, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal)
			{
				chocando = null;
				collisionPoint = default(Vector3);
				collisionNormal = default(Vector3);
				Vector3 vector = endPoistion - startPoistion;
				float magnitude = vector.magnitude;
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(startPoistion, vector, out raycastHit, magnitude, layer, QueryTriggerInteraction.Ignore);
				if (flag)
				{
					collisionPoint = raycastHit.point;
					collisionNormal = raycastHit.normal;
					chocando = raycastHit.collider;
				}
				return flag;
			}

			// Token: 0x06000F96 RID: 3990 RVA: 0x000454E4 File Offset: 0x000436E4
			private bool RayCastRecorridoExtra(float worldFingerRadius, Vector3 startPosition, Vector3 medPosition, Vector3 endPosition, LayerMask layer, float handWScale, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal, out float distanciaRecorrida)
			{
				Vector3 vector;
				if (!this.m_usaMedTip)
				{
					vector = endPosition - startPosition;
				}
				else
				{
					vector = endPosition - medPosition;
				}
				float num = 0.02f * handWScale;
				Vector3 vector2 = endPosition + vector.normalized * num;
				return HandPickHandlerBase.Par.RayCastRecorrido(worldFingerRadius, endPosition, vector2, layer, this.m_parent, out chocando, out collisionPoint, out collisionNormal, out distanciaRecorrida);
			}

			// Token: 0x06000F97 RID: 3991 RVA: 0x00045548 File Offset: 0x00043748
			private bool RayCastRecorrido(float worldFingerRadius, Vector3 startPosition, Vector3 medPosition, Vector3 endPosition, LayerMask layer, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal, out float distanciaRecorrida)
			{
				distanciaRecorrida = 0f;
				if (!this.m_usaMedTip)
				{
					return HandPickHandlerBase.Par.RayCastRecorrido(worldFingerRadius, startPosition, endPosition, layer, this.m_parent, out chocando, out collisionPoint, out collisionNormal, out distanciaRecorrida);
				}
				if (HandPickHandlerBase.Par.RayCastRecorrido(worldFingerRadius, startPosition, medPosition, layer, this.m_parent, out chocando, out collisionPoint, out collisionNormal, out distanciaRecorrida))
				{
					return true;
				}
				bool flag = HandPickHandlerBase.Par.RayCastRecorrido(worldFingerRadius, medPosition, endPosition, layer, this.m_parent, out chocando, out collisionPoint, out collisionNormal, out distanciaRecorrida);
				distanciaRecorrida += Vector3.Distance(startPosition, medPosition);
				return flag;
			}

			// Token: 0x06000F98 RID: 3992 RVA: 0x000455C4 File Offset: 0x000437C4
			private static bool RayCastRecorrido(float worldFingerRadius, Vector3 startPosition, Vector3 endPosition, LayerMask layer, HandPickHandlerBase picker, out Collider chocando, out Vector3 collisionPoint, out Vector3 collisionNormal, out float distanciaRecorrida)
			{
				int num = 0;
				bool flag2;
				try
				{
					chocando = null;
					collisionPoint = default(Vector3);
					collisionNormal = default(Vector3);
					Vector3 vector = endPosition - startPosition;
					Vector3 normalized = vector.normalized;
					startPosition -= normalized * worldFingerRadius;
					distanciaRecorrida = vector.magnitude;
					num = Physics.SphereCastNonAlloc(startPosition, worldFingerRadius, normalized, HandPickHandlerBase.Par.m_HitsTemp, distanciaRecorrida, layer, QueryTriggerInteraction.Ignore);
					RaycastHit raycastHit = default(RaycastHit);
					float num2 = float.MaxValue;
					bool flag = false;
					for (int i = 0; i < num; i++)
					{
						RaycastHit raycastHit2 = HandPickHandlerBase.Par.m_HitsTemp[i];
						if (!picker.pulgar.m_FingerCollidersSet.Contains(raycastHit2.collider) && !picker.indice.m_FingerCollidersSet.Contains(raycastHit2.collider) && !picker.medio.m_FingerCollidersSet.Contains(raycastHit2.collider) && !picker.angular.m_FingerCollidersSet.Contains(raycastHit2.collider) && !picker.menique.m_FingerCollidersSet.Contains(raycastHit2.collider))
						{
							float distance = raycastHit2.distance;
							if (distance < num2)
							{
								raycastHit = raycastHit2;
								flag = true;
								num2 = distance;
							}
						}
					}
					if (flag)
					{
						collisionPoint = raycastHit.point;
						collisionNormal = raycastHit.normal;
						chocando = raycastHit.collider;
						distanciaRecorrida = raycastHit.distance;
					}
					flag2 = flag;
				}
				finally
				{
					Array.Clear(HandPickHandlerBase.Par.m_HitsTemp, 0, num);
				}
				return flag2;
			}

			// Token: 0x04000ABF RID: 2751
			[ReadOnlyUI]
			[SerializeField]
			private HandPickHandlerBase m_parent;

			// Token: 0x04000AC0 RID: 2752
			[ReadOnlyUI]
			[SerializeField]
			private float m_wP;

			// Token: 0x04000AC1 RID: 2753
			[ReadOnlyUI]
			[SerializeField]
			private float m_wR;

			// Token: 0x04000AC2 RID: 2754
			public Transform handStart;

			// Token: 0x04000AC3 RID: 2755
			public Transform bone3Start;

			// Token: 0x04000AC4 RID: 2756
			public Transform tipStart;

			// Token: 0x04000AC5 RID: 2757
			[Tooltip("Optional")]
			public Transform tipMed;

			// Token: 0x04000AC6 RID: 2758
			public Transform tipEnd;

			// Token: 0x04000AC7 RID: 2759
			public Transform tipTarget;

			// Token: 0x04000AC8 RID: 2760
			public float retrocederOffset;

			// Token: 0x04000AC9 RID: 2761
			[ReadOnlyUI]
			[SerializeField]
			private Transform m_boneHand;

			// Token: 0x04000ACA RID: 2762
			[ReadOnlyUI]
			[SerializeField]
			private RecopiladorDeDatosDeCurrentCollisionesDeColliders m_recopilador;

			// Token: 0x04000ACB RID: 2763
			public HumanBodyBones bone1;

			// Token: 0x04000ACC RID: 2764
			public HumanBodyBones bone2;

			// Token: 0x04000ACD RID: 2765
			public HumanBodyBones bone3;

			// Token: 0x04000ACE RID: 2766
			private Vector3 m_localDirectionToBone3;

			// Token: 0x04000ACF RID: 2767
			private bool m_usaMedTip;

			// Token: 0x04000AD0 RID: 2768
			private Collider[] m_FingerColliders;

			// Token: 0x04000AD1 RID: 2769
			private HashSet<Collider> m_FingerCollidersSet;

			// Token: 0x04000AD2 RID: 2770
			private static RaycastHit[] m_HitsTemp = new RaycastHit[100];
		}

		// Token: 0x0200024D RID: 589
		[Serializable]
		internal class EditorAutoFill
		{
			// Token: 0x06000F9B RID: 3995 RVA: 0x00045774 File Offset: 0x00043974
			public void Set(HandPickHandlerBase owner)
			{
				Side side = this.side;
				HumanBodyBones humanBodyBones;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(this.side.ToString());
					}
					humanBodyBones = HumanBodyBones.RightHand;
					owner.pulgar.bone1 = HumanBodyBones.RightThumbProximal;
					owner.pulgar.bone2 = HumanBodyBones.RightThumbIntermediate;
					owner.pulgar.bone3 = HumanBodyBones.RightThumbDistal;
					owner.indice.bone1 = HumanBodyBones.RightIndexProximal;
					owner.indice.bone2 = HumanBodyBones.RightIndexIntermediate;
					owner.indice.bone3 = HumanBodyBones.RightIndexDistal;
					owner.medio.bone1 = HumanBodyBones.RightMiddleProximal;
					owner.medio.bone2 = HumanBodyBones.RightMiddleIntermediate;
					owner.medio.bone3 = HumanBodyBones.RightMiddleDistal;
					owner.angular.bone1 = HumanBodyBones.RightRingProximal;
					owner.angular.bone2 = HumanBodyBones.RightRingIntermediate;
					owner.angular.bone3 = HumanBodyBones.RightRingDistal;
					owner.menique.bone1 = HumanBodyBones.RightLittleProximal;
					owner.menique.bone2 = HumanBodyBones.RightLittleIntermediate;
					owner.menique.bone3 = HumanBodyBones.RightLittleDistal;
				}
				else
				{
					humanBodyBones = HumanBodyBones.LeftHand;
					owner.pulgar.bone1 = HumanBodyBones.LeftThumbProximal;
					owner.pulgar.bone2 = HumanBodyBones.LeftThumbIntermediate;
					owner.pulgar.bone3 = HumanBodyBones.LeftThumbDistal;
					owner.indice.bone1 = HumanBodyBones.LeftIndexProximal;
					owner.indice.bone2 = HumanBodyBones.LeftIndexIntermediate;
					owner.indice.bone3 = HumanBodyBones.LeftIndexDistal;
					owner.medio.bone1 = HumanBodyBones.LeftMiddleProximal;
					owner.medio.bone2 = HumanBodyBones.LeftMiddleIntermediate;
					owner.medio.bone3 = HumanBodyBones.LeftMiddleDistal;
					owner.angular.bone1 = HumanBodyBones.LeftRingProximal;
					owner.angular.bone2 = HumanBodyBones.LeftRingIntermediate;
					owner.angular.bone3 = HumanBodyBones.LeftRingDistal;
					owner.menique.bone1 = HumanBodyBones.LeftLittleProximal;
					owner.menique.bone2 = HumanBodyBones.LeftLittleIntermediate;
					owner.menique.bone3 = HumanBodyBones.LeftLittleDistal;
				}
				Transform boneTransform = this.animator.GetBoneTransform(humanBodyBones);
				Transform boneTransform2 = this.animator.GetBoneTransform(owner.pulgar.bone3);
				Transform boneTransform3 = this.animator.GetBoneTransform(owner.indice.bone3);
				Transform boneTransform4 = this.animator.GetBoneTransform(owner.medio.bone3);
				Transform boneTransform5 = this.animator.GetBoneTransform(owner.angular.bone3);
				Transform boneTransform6 = this.animator.GetBoneTransform(owner.menique.bone3);
				this.Set(owner.pulgar, boneTransform, boneTransform2, 0.0125f);
				this.Set(owner.indice, boneTransform, boneTransform3, 0.001f);
				this.Set(owner.medio, boneTransform, boneTransform4, 0.001f);
				this.Set(owner.angular, boneTransform, boneTransform5, 0.001f);
				this.Set(owner.menique, boneTransform, boneTransform6, 0.001f);
				this.initialPose = null;
				this.endPose = null;
				this.medPose = null;
				this.targets = null;
				this.animator = null;
				TValleEditorTools.SetDirty(owner);
			}

			// Token: 0x06000F9C RID: 3996 RVA: 0x00045A54 File Offset: 0x00043C54
			private void Set(HandPickHandlerBase.Par par, Transform handBone, Transform Bone3, float retrocederOffset)
			{
				par.handStart = this.initialPose.FindDeepChild(handBone.name, true);
				par.bone3Start = this.initialPose.FindDeepChild(Bone3.name, true);
				par.tipStart = this.initialPose.FindDeepChild(Bone3.GetChild(0).name, true);
				par.tipMed = ((this.medPose != null) ? this.medPose.FindDeepChild(par.tipStart.name, true) : null);
				par.tipEnd = this.endPose.FindDeepChild(par.tipStart.name, true);
				par.tipTarget = this.targets.FindDeepChild(par.tipStart.name, true);
				par.retrocederOffset = retrocederOffset;
			}

			// Token: 0x04000AD3 RID: 2771
			public Side side;

			// Token: 0x04000AD4 RID: 2772
			public Transform initialPose;

			// Token: 0x04000AD5 RID: 2773
			[Tooltip("Optional")]
			public Transform medPose;

			// Token: 0x04000AD6 RID: 2774
			public Transform endPose;

			// Token: 0x04000AD7 RID: 2775
			public Transform targets;

			// Token: 0x04000AD8 RID: 2776
			public Animator animator;
		}
	}
}
