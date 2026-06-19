using System;
using System.Reflection;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000046 RID: 70
	public class ColliderProxy : MonoBehaviour
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000366 RID: 870 RVA: 0x000114EF File Offset: 0x0000F6EF
		// (set) Token: 0x06000367 RID: 871 RVA: 0x000114F7 File Offset: 0x0000F6F7
		public GameObject Target
		{
			get
			{
				return this._Target;
			}
			set
			{
				this._Target = value;
				this.BindTarget(this._Target);
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0001150C File Offset: 0x0000F70C
		protected virtual void Awake()
		{
			if (this._Target != null)
			{
				this.BindTarget(this._Target);
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00011528 File Offset: 0x0000F728
		public virtual void Reset()
		{
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0001152A File Offset: 0x0000F72A
		public virtual void EnableColliders(bool rEnable, float rSpeed = 0f)
		{
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0001152C File Offset: 0x0000F72C
		protected void BindTarget(GameObject rTarget)
		{
			this.mOnTriggerEnter = null;
			this.mOnTriggerStay = null;
			this.mOnTriggerExit = null;
			if (rTarget != null)
			{
				BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
				Component[] components = rTarget.GetComponents<Component>();
				for (int i = 0; i < components.Length; i++)
				{
					Type type = components[i].GetType();
					if (!(type == typeof(Transform)) && !(type == typeof(Rigidbody)) && !(type == typeof(Collider)) && !(type == typeof(AudioSource)))
					{
						this.mOnTriggerEnter = type.GetMethod("OnTriggerEnter", bindingFlags, null, new Type[] { typeof(Collider) }, null);
						if (this.mOnTriggerEnter != null)
						{
							this.mTarget = components[i];
							this.mOnTriggerStay = type.GetMethod("OnTriggerStay", bindingFlags, null, new Type[] { typeof(Collider) }, null);
							this.mOnTriggerExit = type.GetMethod("OnTriggerExit", bindingFlags, null, new Type[] { typeof(Collider) }, null);
						}
						if (this.mTarget != null)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001166F File Offset: 0x0000F86F
		protected virtual void OnTriggerEnter(Collider rCollider)
		{
			if (this.mOnTriggerEnter != null)
			{
				this.mOnTriggerEnter.Invoke(this.mTarget, new object[] { rCollider });
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0001169B File Offset: 0x0000F89B
		protected virtual void OnTriggerStay(Collider rCollider)
		{
			if (this.mOnTriggerStay != null)
			{
				this.mOnTriggerStay.Invoke(this.mTarget, new object[] { rCollider });
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000116C7 File Offset: 0x0000F8C7
		protected virtual void OnTriggerExit(Collider rCollider)
		{
			if (this.mOnTriggerExit != null)
			{
				this.mOnTriggerExit.Invoke(this.mTarget, new object[] { rCollider });
			}
		}

		// Token: 0x040001E3 RID: 483
		public GameObject _Target;

		// Token: 0x040001E4 RID: 484
		protected Component mTarget;

		// Token: 0x040001E5 RID: 485
		protected MethodInfo mOnTriggerEnter;

		// Token: 0x040001E6 RID: 486
		protected MethodInfo mOnTriggerStay;

		// Token: 0x040001E7 RID: 487
		protected MethodInfo mOnTriggerExit;
	}
}
