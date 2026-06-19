using System;
using System.Collections.Generic;
using Assets.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts
{
	// Token: 0x02000094 RID: 148
	public abstract class LinearBoneChainBase : ChainStretched
	{
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000467 RID: 1127
		public abstract IReadOnlyList<RecalculableJointBase> puntosBase { get; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x0000E722 File Offset: 0x0000C922
		public int Count
		{
			get
			{
				return this.puntosBase.Count;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000E72F File Offset: 0x0000C92F
		public LinearBoneChainBase.EstadoDePuntos estadoDePuntos
		{
			get
			{
				return this.m_EstadoDePuntos;
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000E737 File Offset: 0x0000C937
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_EstadoDePuntos = new LinearBoneChainBase.EstadoDePuntos(this);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000E74B File Offset: 0x0000C94B
		public sealed override void OnUpdateEvent1()
		{
			this.estadoDePuntos.posicionesLocales.Actializar();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000E760 File Offset: 0x0000C960
		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			LinearBoneChainBase.EstadoDePuntos estadoDePuntos = this.m_EstadoDePuntos;
			if (!estadoDePuntos.initiated)
			{
				return;
			}
			Vector3 centroDePuntos = estadoDePuntos.posicionesLocales.centroDePuntos;
			Vector3 centroDePuntos2 = estadoDePuntos.posicionesLocalesIniciales.centroDePuntos;
			Gizmos.color = Color.green;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawSphere(centroDePuntos, 0.002f);
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(centroDePuntos2, 0.001f);
		}

		// Token: 0x040002A3 RID: 675
		[SerializeField]
		protected LinearBoneChainBase.EstadoDePuntos m_EstadoDePuntos;

		// Token: 0x02000185 RID: 389
		[Serializable]
		public class EstadoDePuntos
		{
			// Token: 0x06000EA4 RID: 3748 RVA: 0x0003221F File Offset: 0x0003041F
			public EstadoDePuntos(LinearBoneChainBase owner)
			{
				if (owner == null)
				{
					throw new ArgumentNullException("owner", "owner null reference.");
				}
				this.m_owner = owner;
				this.m_posicionesLocales = new LinearBoneChainBase.EstadoDePuntos.ActualLocal(owner);
				this.m_posicionesLocalesIniciales = new LinearBoneChainBase.EstadoDePuntos.InicialesLocal(owner);
			}

			// Token: 0x17000505 RID: 1285
			// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x0003225F File Offset: 0x0003045F
			public bool initiated
			{
				get
				{
					return this.m_owner != null;
				}
			}

			// Token: 0x17000506 RID: 1286
			// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0003226D File Offset: 0x0003046D
			public LinearBoneChainBase.EstadoDePuntos.ActualLocal posicionesLocales
			{
				get
				{
					return this.m_posicionesLocales;
				}
			}

			// Token: 0x17000507 RID: 1287
			// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x00032275 File Offset: 0x00030475
			public LinearBoneChainBase.EstadoDePuntos.InicialesLocal posicionesLocalesIniciales
			{
				get
				{
					return this.m_posicionesLocalesIniciales;
				}
			}

			// Token: 0x17000508 RID: 1288
			// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0003227D File Offset: 0x0003047D
			public LinearBoneChainBase owner
			{
				get
				{
					return this.m_owner;
				}
			}

			// Token: 0x06000EA9 RID: 3753 RVA: 0x00032288 File Offset: 0x00030488
			public void CopiarA(LinearBoneChainBase.EstadoDePuntos other)
			{
				try
				{
					this.m_posicionesLocales.CopiarA(other.m_posicionesLocales);
					this.m_posicionesLocalesIniciales.CopiarA(other.m_posicionesLocalesIniciales);
				}
				catch (Exception)
				{
					throw;
				}
			}

			// Token: 0x040008C7 RID: 2247
			private LinearBoneChainBase m_owner;

			// Token: 0x040008C8 RID: 2248
			[SerializeField]
			private LinearBoneChainBase.EstadoDePuntos.ActualLocal m_posicionesLocales;

			// Token: 0x040008C9 RID: 2249
			[SerializeField]
			private LinearBoneChainBase.EstadoDePuntos.InicialesLocal m_posicionesLocalesIniciales;

			// Token: 0x02000223 RID: 547
			[Serializable]
			public class ActualLocal : LinearBoneChainBase.EstadoDePuntos.Base
			{
				// Token: 0x0600101D RID: 4125 RVA: 0x00035F73 File Offset: 0x00034173
				public ActualLocal(LinearBoneChainBase owner)
					: base(owner)
				{
				}

				// Token: 0x17000543 RID: 1347
				// (get) Token: 0x0600101E RID: 4126 RVA: 0x00035F7C File Offset: 0x0003417C
				public Vector3 centroDePuntos
				{
					get
					{
						return this.m_centroDePuntos;
					}
				}

				// Token: 0x0600101F RID: 4127 RVA: 0x00035F84 File Offset: 0x00034184
				public void Actializar()
				{
					this.m_centroDePuntos = Vector3.zero;
					for (int i = 0; i < this.m_owner.puntosBase.Count; i++)
					{
						RecalculableJointBase recalculableJointBase = this.m_owner.puntosBase[i];
						this.m_centroDePuntos += recalculableJointBase.targetBodyTransform.localPosition;
					}
					this.m_centroDePuntos /= (float)this.m_owner.puntosBase.Count;
				}

				// Token: 0x06001020 RID: 4128 RVA: 0x00036007 File Offset: 0x00034207
				public override void CopiarA(LinearBoneChainBase.EstadoDePuntos.Base other)
				{
					((LinearBoneChainBase.EstadoDePuntos.ActualLocal)other).m_centroDePuntos = this.m_centroDePuntos;
				}

				// Token: 0x04000B2E RID: 2862
				[SerializeField]
				private Vector3 m_centroDePuntos;
			}

			// Token: 0x02000224 RID: 548
			[Serializable]
			public class InicialesLocal : LinearBoneChainBase.EstadoDePuntos.Base
			{
				// Token: 0x06001021 RID: 4129 RVA: 0x0003601A File Offset: 0x0003421A
				public InicialesLocal(LinearBoneChainBase owner)
					: base(owner)
				{
				}

				// Token: 0x17000544 RID: 1348
				// (get) Token: 0x06001022 RID: 4130 RVA: 0x00036023 File Offset: 0x00034223
				public Vector3 centroDePuntos
				{
					get
					{
						return this.m_centroDePuntos;
					}
				}

				// Token: 0x06001023 RID: 4131 RVA: 0x0003602C File Offset: 0x0003422C
				[Obsolete]
				public Vector3 ObtenerCentroDePuntosInicialActual()
				{
					Vector3 vector = Vector3.zero;
					for (int i = 0; i < this.m_owner.puntosBase.Count; i++)
					{
						RecalculableJointBase recalculableJointBase = this.m_owner.puntosBase[i];
						vector += recalculableJointBase.distancesAdmin.WorldSpaceJointTargetPoint();
					}
					vector /= (float)this.m_owner.puntosBase.Count;
					return this.m_owner.transform.InverseTransformPoint(vector);
				}

				// Token: 0x06001024 RID: 4132 RVA: 0x000360A8 File Offset: 0x000342A8
				public void Actializar()
				{
					Vector3 vector = Vector3.zero;
					for (int i = 0; i < this.m_owner.puntosBase.Count; i++)
					{
						RecalculableJointBase recalculableJointBase = this.m_owner.puntosBase[i];
						vector += recalculableJointBase.distancesAdmin.WorldSpaceJointTargetPoint();
					}
					vector /= (float)this.m_owner.puntosBase.Count;
					this.m_centroDePuntos = this.m_owner.transform.InverseTransformPoint(vector);
				}

				// Token: 0x06001025 RID: 4133 RVA: 0x00036129 File Offset: 0x00034329
				public override void CopiarA(LinearBoneChainBase.EstadoDePuntos.Base other)
				{
					((LinearBoneChainBase.EstadoDePuntos.InicialesLocal)other).m_centroDePuntos = this.m_centroDePuntos;
				}

				// Token: 0x04000B2F RID: 2863
				[SerializeField]
				private Vector3 m_centroDePuntos;
			}

			// Token: 0x02000225 RID: 549
			[Serializable]
			public abstract class Base
			{
				// Token: 0x06001026 RID: 4134 RVA: 0x0003613C File Offset: 0x0003433C
				public Base(LinearBoneChainBase owner)
				{
					if (owner == null)
					{
						throw new ArgumentNullException("owner", "owner null reference.");
					}
					this.m_owner = owner;
					this.OnInit();
				}

				// Token: 0x06001027 RID: 4135 RVA: 0x0003616A File Offset: 0x0003436A
				protected virtual void OnInit()
				{
				}

				// Token: 0x06001028 RID: 4136
				public abstract void CopiarA(LinearBoneChainBase.EstadoDePuntos.Base other);

				// Token: 0x04000B30 RID: 2864
				protected LinearBoneChainBase m_owner;
			}
		}
	}
}
