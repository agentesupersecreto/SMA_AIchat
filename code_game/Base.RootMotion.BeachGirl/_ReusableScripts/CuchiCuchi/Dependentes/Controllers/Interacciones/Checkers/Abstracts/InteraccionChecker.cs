using System;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers.Abstracts
{
	// Token: 0x020000F9 RID: 249
	public abstract class InteraccionChecker : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000944 RID: 2372 RVA: 0x0002A2F4 File Offset: 0x000284F4
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.checking = new InteraccionChecker.Checking
			{
				player = false,
				walls = true,
				ground = true,
				toRagdols = true
			};
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x0002A336 File Offset: 0x00028536
		public IAnimatorCharacter currentCharacter
		{
			get
			{
				return this.m_currentCharacter;
			}
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0002A340 File Offset: 0x00028540
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponentInParent<Interaccion>();
			if (this.m_Interaccion == null)
			{
				throw new ArgumentNullException("m_Interaccion", "m_Interaccion null reference.");
			}
			this.m_Interaccion.checkObstacles += this.Inter_onPuedeEjecutarse;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0002A394 File Offset: 0x00028594
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_Interaccion == null)
			{
				return;
			}
			this.m_Interaccion.checkObstacles -= this.Inter_onPuedeEjecutarse;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0002A3C4 File Offset: 0x000285C4
		private void Inter_onPuedeEjecutarse(Interaccion.AbortingArgs args, object sender)
		{
			if (!this.checkOnPuedeEjecutarse)
			{
				return;
			}
			if (this.m_Interaccion != args.interaccion)
			{
				Debug.LogException(new InvalidOperationException(), this);
				return;
			}
			object obj;
			if (args == null)
			{
				obj = null;
			}
			else
			{
				Interaccion interaccion = args.interaccion;
				if (interaccion == null)
				{
					obj = null;
				}
				else
				{
					IInteraccionesDeCharacter owner = interaccion.owner;
					obj = ((owner != null) ? owner.character : null);
				}
			}
			this.m_currentCharacter = obj as IAnimatorCharacter;
			if (this.m_currentCharacter == null)
			{
				object obj2;
				if (args == null)
				{
					obj2 = null;
				}
				else
				{
					Interaccion interaccion2 = args.interaccion;
					obj2 = ((interaccion2 != null) ? interaccion2.user : null);
				}
				this.m_currentCharacter = (obj2 as Component).GetComponentEnRoot(false);
			}
			if (this.m_currentCharacter == null)
			{
				Debug.LogException(new NullReferenceException("m_currentCharacter"), this);
				return;
			}
			if (this.DoCheck())
			{
				args.Abort();
			}
		}

		// Token: 0x06000949 RID: 2377
		public abstract bool DoCheck();

		// Token: 0x0600094A RID: 2378
		public abstract bool DoCheck(out Transform obstacle, out Vector3 worldPosition);

		// Token: 0x0600094B RID: 2379 RVA: 0x0002A480 File Offset: 0x00028680
		public bool DoCheck(IAnimatorCharacter onCharacter)
		{
			if (onCharacter == null)
			{
				throw new ArgumentNullException("onCharacter", "onCharacter null reference.");
			}
			this.m_currentCharacter = onCharacter;
			return this.DoCheck();
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0002A4A2 File Offset: 0x000286A2
		public bool DoCheck(IAnimatorCharacter onCharacter, out Transform obstacle, out Vector3 worldPosition)
		{
			if (onCharacter == null)
			{
				throw new ArgumentNullException("onCharacter", "onCharacter null reference.");
			}
			this.m_currentCharacter = onCharacter;
			return this.DoCheck(out obstacle, out worldPosition);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0002A4C8 File Offset: 0x000286C8
		protected static void GetRadiusAndWorldCenter(Collider collider, out float radius, out Vector3 worldCenter)
		{
			Vector3 vector;
			if (collider is BoxCollider)
			{
				BoxCollider boxCollider = (BoxCollider)collider;
				radius = boxCollider.size.Middle();
				vector = boxCollider.center;
			}
			else if (collider is SphereCollider)
			{
				SphereCollider sphereCollider = (SphereCollider)collider;
				radius = sphereCollider.radius;
				vector = sphereCollider.center;
			}
			else
			{
				if (!(collider is CapsuleCollider))
				{
					throw new ArgumentOutOfRangeException();
				}
				CapsuleCollider capsuleCollider = (CapsuleCollider)collider;
				radius = Mathf.Max(capsuleCollider.radius, capsuleCollider.height * 0.5f);
				vector = capsuleCollider.center;
			}
			worldCenter = collider.transform.TransformPoint(vector);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0002A564 File Offset: 0x00028764
		protected static float GetRadius(Collider collider)
		{
			if (collider is BoxCollider)
			{
				return ((BoxCollider)collider).size.Middle();
			}
			if (collider is SphereCollider)
			{
				return ((SphereCollider)collider).radius;
			}
			if (collider is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = (CapsuleCollider)collider;
				return Mathf.Max(capsuleCollider.radius, capsuleCollider.height * 0.5f);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0002A5CC File Offset: 0x000287CC
		protected static Vector3 GetWorldCenter(Collider collider)
		{
			Vector3 vector;
			if (collider is BoxCollider)
			{
				vector = ((BoxCollider)collider).center;
			}
			else if (collider is SphereCollider)
			{
				vector = ((SphereCollider)collider).center;
			}
			else
			{
				if (!(collider is CapsuleCollider))
				{
					throw new ArgumentOutOfRangeException();
				}
				vector = ((CapsuleCollider)collider).center;
			}
			return collider.transform.TransformPoint(vector);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0002A630 File Offset: 0x00028830
		protected static bool CheckCollider(Collider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float sizeMod = 1f, bool debugDraw = false)
		{
			if (collider is CapsuleCollider)
			{
				return InteraccionChecker.checkCollider((CapsuleCollider)collider, pose, layerMask, queryTriggerInteraction, sizeMod, debugDraw);
			}
			if (collider is BoxCollider)
			{
				return InteraccionChecker.checkCollider((BoxCollider)collider, pose, layerMask, queryTriggerInteraction, sizeMod, debugDraw);
			}
			if (collider is SphereCollider)
			{
				return InteraccionChecker.checkCollider((SphereCollider)collider, pose, layerMask, queryTriggerInteraction, sizeMod, debugDraw);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0002A694 File Offset: 0x00028894
		private static bool checkCollider(CapsuleCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float sizeMod = 1f, bool debugDraw = false)
		{
			Vector3 vector;
			switch (collider.direction)
			{
			case 0:
				vector = Vector3.right;
				break;
			case 1:
				vector = Vector3.up;
				break;
			case 2:
				vector = Vector3.forward;
				break;
			default:
				throw new ArgumentOutOfRangeException(collider.direction.ToString());
			}
			float num = collider.height / 2f - collider.radius;
			Vector3 vector2 = collider.center + vector * num;
			Vector3 vector3 = collider.center - vector * num;
			float num2 = pose.lossyScale.Escala();
			bool flag = Physics.CheckCapsule(pose.TransformPoint(vector2), pose.TransformPoint(vector3), num2 * sizeMod * collider.radius, layerMask, queryTriggerInteraction);
			if (debugDraw)
			{
				if (!flag)
				{
					Color green = Color.green;
				}
				else
				{
					Color red = Color.red;
				}
			}
			return flag;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0002A770 File Offset: 0x00028970
		private static bool checkCollider(SphereCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float sizeMod = 1f, bool debugDraw = false)
		{
			float num = pose.lossyScale.Escala();
			bool flag = Physics.CheckSphere(pose.TransformPoint(collider.center), num * sizeMod * collider.radius, layerMask, queryTriggerInteraction);
			if (debugDraw)
			{
				if (!flag)
				{
					Color green = Color.green;
				}
				else
				{
					Color red = Color.red;
				}
			}
			return flag;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0002A7C0 File Offset: 0x000289C0
		private static bool checkCollider(BoxCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float sizeMod = 1f, bool debugDraw = false)
		{
			Vector3 vector = Vector3.Scale(pose.lossyScale, collider.size) * 0.5f * sizeMod;
			bool flag = Physics.CheckBox(pose.TransformPoint(collider.center), vector, pose.rotation, layerMask, queryTriggerInteraction);
			if (debugDraw)
			{
				if (!flag)
				{
					Color green = Color.green;
				}
				else
				{
					Color red = Color.red;
				}
			}
			return flag;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0002A824 File Offset: 0x00028A24
		protected static bool CheckCollider(Collider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Func<Collider, bool> colliderEsValido, out Collider hitted, float sizeMod = 1f, bool debugDraw = false)
		{
			if (collider is CapsuleCollider)
			{
				return InteraccionChecker.checkCollider((CapsuleCollider)collider, pose, layerMask, queryTriggerInteraction, colliderEsValido, out hitted, sizeMod, debugDraw);
			}
			if (collider is BoxCollider)
			{
				return InteraccionChecker.checkCollider((BoxCollider)collider, pose, layerMask, queryTriggerInteraction, colliderEsValido, out hitted, sizeMod, debugDraw);
			}
			if (collider is SphereCollider)
			{
				return InteraccionChecker.checkCollider((SphereCollider)collider, pose, layerMask, queryTriggerInteraction, colliderEsValido, out hitted, sizeMod, debugDraw);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0002A894 File Offset: 0x00028A94
		private static bool checkCollider(CapsuleCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Func<Collider, bool> colliderEsValido, out Collider hitted, float sizeMod = 1f, bool debugDraw = false)
		{
			hitted = null;
			int num = 0;
			bool flag;
			try
			{
				Vector3 vector;
				switch (collider.direction)
				{
				case 0:
					vector = Vector3.right;
					break;
				case 1:
					vector = Vector3.up;
					break;
				case 2:
					vector = Vector3.forward;
					break;
				default:
					throw new ArgumentOutOfRangeException(collider.direction.ToString());
				}
				float num2 = collider.height / 2f - collider.radius;
				Vector3 vector2 = collider.center + vector * num2;
				Vector3 vector3 = collider.center - vector * num2;
				float num3 = pose.lossyScale.Escala();
				num = Physics.OverlapCapsuleNonAlloc(pose.TransformPoint(vector2), pose.TransformPoint(vector3), num3 * sizeMod * collider.radius, InteraccionChecker.m_collidersTemp, layerMask, queryTriggerInteraction);
				for (int i = 0; i < num; i++)
				{
					Collider collider2 = InteraccionChecker.m_collidersTemp[i];
					if (colliderEsValido(collider2))
					{
						hitted = collider2;
						break;
					}
				}
				if (debugDraw)
				{
					if (!(hitted != null))
					{
						Color green = Color.green;
					}
					else
					{
						Color red = Color.red;
					}
				}
				flag = hitted != null;
			}
			finally
			{
				Array.Clear(InteraccionChecker.m_collidersTemp, 0, num);
			}
			return flag;
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0002A9E4 File Offset: 0x00028BE4
		private static bool checkCollider(SphereCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Func<Collider, bool> colliderEsValido, out Collider hitted, float sizeMod = 1f, bool debugDraw = false)
		{
			hitted = null;
			int num = 0;
			bool flag;
			try
			{
				float num2 = pose.lossyScale.Escala();
				num = Physics.OverlapSphereNonAlloc(pose.TransformPoint(collider.center), num2 * sizeMod * collider.radius, InteraccionChecker.m_collidersTemp, layerMask, queryTriggerInteraction);
				for (int i = 0; i < num; i++)
				{
					Collider collider2 = InteraccionChecker.m_collidersTemp[i];
					if (colliderEsValido(collider2))
					{
						hitted = collider2;
						break;
					}
				}
				if (debugDraw)
				{
					if (!(hitted != null))
					{
						Color green = Color.green;
					}
					else
					{
						Color red = Color.red;
					}
				}
				flag = hitted != null;
			}
			finally
			{
				Array.Clear(InteraccionChecker.m_collidersTemp, 0, num);
			}
			return flag;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0002AA94 File Offset: 0x00028C94
		private static bool checkCollider(BoxCollider collider, Transform pose, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Func<Collider, bool> colliderEsValido, out Collider hitted, float sizeMod = 1f, bool debugDraw = false)
		{
			hitted = null;
			int num = 0;
			bool flag;
			try
			{
				Vector3 vector = Vector3.Scale(pose.lossyScale, collider.size) * 0.5f * sizeMod;
				num = Physics.OverlapBoxNonAlloc(pose.TransformPoint(collider.center), vector, InteraccionChecker.m_collidersTemp, pose.rotation, layerMask, queryTriggerInteraction);
				for (int i = 0; i < num; i++)
				{
					Collider collider2 = InteraccionChecker.m_collidersTemp[i];
					if (colliderEsValido(collider2))
					{
						hitted = collider2;
						break;
					}
				}
				if (debugDraw)
				{
					if (!(hitted != null))
					{
						Color green = Color.green;
					}
					else
					{
						Color red = Color.red;
					}
				}
				flag = hitted != null;
			}
			finally
			{
				Array.Clear(InteraccionChecker.m_collidersTemp, 0, num);
			}
			return flag;
		}

		// Token: 0x040005C9 RID: 1481
		public bool checkOnPuedeEjecutarse = true;

		// Token: 0x040005CA RID: 1482
		public InteraccionChecker.Checking checking;

		// Token: 0x040005CB RID: 1483
		public LayerMask extraLayerMask = 0;

		// Token: 0x040005CC RID: 1484
		private IAnimatorCharacter m_currentCharacter;

		// Token: 0x040005CD RID: 1485
		protected Interaccion m_Interaccion;

		// Token: 0x040005CE RID: 1486
		private static Collider[] m_collidersTemp = new Collider[100];

		// Token: 0x020001C3 RID: 451
		[Serializable]
		public struct Checking
		{
			// Token: 0x06000D12 RID: 3346 RVA: 0x00039B1C File Offset: 0x00037D1C
			public static InteraccionChecker.Checking SoloPlayer()
			{
				return new InteraccionChecker.Checking
				{
					player = true,
					walls = false,
					ground = false,
					toRagdols = false
				};
			}

			// Token: 0x06000D13 RID: 3347 RVA: 0x00039B54 File Offset: 0x00037D54
			[Obsolete("", true)]
			public static InteraccionChecker.Checking TodosMenosPlayer()
			{
				return new InteraccionChecker.Checking
				{
					player = false,
					walls = true,
					ground = true,
					toRagdols = true
				};
			}

			// Token: 0x06000D14 RID: 3348 RVA: 0x00039B8C File Offset: 0x00037D8C
			public int GetLayerMask(int defaults)
			{
				ConfiguracionGlobal instance = MapaSingleton<ConfiguracionGlobal>.instance;
				int num = defaults;
				if (this.player)
				{
					num |= instance.layers.layerMaskRagdolls;
					num |= instance.layers.layerMaskCharacters;
				}
				if (this.walls)
				{
					num |= instance.layers.layerMaskWalls;
				}
				if (this.ground)
				{
					num |= instance.layers.layerMaskGround;
				}
				if (this.toRagdols)
				{
					num |= instance.layers.layerMaskAgainstRagdolls;
				}
				return num;
			}

			// Token: 0x040009CF RID: 2511
			public bool player;

			// Token: 0x040009D0 RID: 2512
			public bool walls;

			// Token: 0x040009D1 RID: 2513
			public bool ground;

			// Token: 0x040009D2 RID: 2514
			public bool toRagdols;
		}
	}
}
