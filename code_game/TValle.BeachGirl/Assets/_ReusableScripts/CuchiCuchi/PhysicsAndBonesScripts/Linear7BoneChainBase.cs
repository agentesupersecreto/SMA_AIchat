using System;
using System.Collections.Generic;
using Assets.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000DE RID: 222
	public abstract class Linear7BoneChainBase : ChainStretched
	{
		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060008DF RID: 2271
		public abstract ChainPointStretcherJoint _000Base { get; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060008E0 RID: 2272
		public abstract ChainPointStretcherJoint _001Base { get; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060008E1 RID: 2273
		public abstract ChainPointStretcherJoint _002Base { get; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060008E2 RID: 2274
		public abstract ChainPointStretcherJoint _003Base { get; }

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060008E3 RID: 2275
		public abstract ChainPointStretcherJoint _004Base { get; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060008E4 RID: 2276
		public abstract ChainPointStretcherJoint _005Base { get; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060008E5 RID: 2277
		public abstract ChainPointStretcherJoint _006Base { get; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060008E6 RID: 2278
		public abstract IList<ChainPointStretcherJoint> puntosBase { get; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0001C1E0 File Offset: 0x0001A3E0
		public Linear7BoneChainBase.EstadoDePuntos estadoDePuntos
		{
			get
			{
				return this.m_EstadoDePuntos;
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001C1E8 File Offset: 0x0001A3E8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_EstadoDePuntos = new Linear7BoneChainBase.EstadoDePuntos(this);
			this.m_EstadoDePuntos.posicionesLocalesIniciales.Actializar();
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001C20C File Offset: 0x0001A40C
		public override void OnUpdateEvent1()
		{
			this.estadoDePuntos.posicionesLocales.Actializar();
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001C21E File Offset: 0x0001A41E
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x040004B6 RID: 1206
		[SerializeField]
		private Linear7BoneChainBase.EstadoDePuntos m_EstadoDePuntos;

		// Token: 0x020001B8 RID: 440
		[Serializable]
		public class EstadoDePuntos
		{
			// Token: 0x06000F3C RID: 3900 RVA: 0x000341EC File Offset: 0x000323EC
			public EstadoDePuntos(Linear7BoneChainBase owner)
			{
				if (owner == null)
				{
					throw new ArgumentNullException("owner", "owner null reference.");
				}
				this.m_owner = owner;
				this.m_posicionesLocales = new Linear7BoneChainBase.EstadoDePuntos.ActualLocal(owner);
				this.m_posicionesLocalesIniciales = new Linear7BoneChainBase.EstadoDePuntos.InicialesLocal(owner);
			}

			// Token: 0x1700051C RID: 1308
			// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0003422C File Offset: 0x0003242C
			public Linear7BoneChainBase.EstadoDePuntos.ActualLocal posicionesLocales
			{
				get
				{
					return this.m_posicionesLocales;
				}
			}

			// Token: 0x1700051D RID: 1309
			// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00034234 File Offset: 0x00032434
			public Linear7BoneChainBase.EstadoDePuntos.InicialesLocal posicionesLocalesIniciales
			{
				get
				{
					return this.m_posicionesLocalesIniciales;
				}
			}

			// Token: 0x1700051E RID: 1310
			// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0003423C File Offset: 0x0003243C
			public Linear7BoneChainBase owner
			{
				get
				{
					return this.m_owner;
				}
			}

			// Token: 0x06000F40 RID: 3904 RVA: 0x00034244 File Offset: 0x00032444
			public void CopiarA(Linear7BoneChainBase.EstadoDePuntos other)
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

			// Token: 0x040009E9 RID: 2537
			private Linear7BoneChainBase m_owner;

			// Token: 0x040009EA RID: 2538
			[SerializeField]
			private Linear7BoneChainBase.EstadoDePuntos.ActualLocal m_posicionesLocales;

			// Token: 0x040009EB RID: 2539
			[SerializeField]
			private Linear7BoneChainBase.EstadoDePuntos.InicialesLocal m_posicionesLocalesIniciales;

			// Token: 0x0200022F RID: 559
			[Serializable]
			public class ActualLocal : Linear7BoneChainBase.EstadoDePuntos.Base
			{
				// Token: 0x06001057 RID: 4183 RVA: 0x0003674A File Offset: 0x0003494A
				public ActualLocal(Linear7BoneChainBase owner)
					: base(owner)
				{
				}

				// Token: 0x17000557 RID: 1367
				// (get) Token: 0x06001058 RID: 4184 RVA: 0x00036753 File Offset: 0x00034953
				public Vector3 centroDePuntos
				{
					get
					{
						return this.m_centroDePuntos;
					}
				}

				// Token: 0x06001059 RID: 4185 RVA: 0x0003675C File Offset: 0x0003495C
				public void Actializar()
				{
					this.m_centroDePuntos = Vector3.zero;
					this.m_centroDePuntos += this.m_owner._000Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._001Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._002Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._003Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._004Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._005Base.otherBody.transform.localPosition;
					this.m_centroDePuntos += this.m_owner._006Base.otherBody.transform.localPosition;
					this.m_centroDePuntos /= 7f;
				}

				// Token: 0x0600105A RID: 4186 RVA: 0x000368B7 File Offset: 0x00034AB7
				public override void CopiarA(Linear7BoneChainBase.EstadoDePuntos.Base other)
				{
					((Linear7BoneChainBase.EstadoDePuntos.ActualLocal)other).m_centroDePuntos = this.m_centroDePuntos;
				}

				// Token: 0x04000B46 RID: 2886
				[SerializeField]
				private Vector3 m_centroDePuntos;
			}

			// Token: 0x02000230 RID: 560
			[Serializable]
			public class InicialesLocal : Linear7BoneChainBase.EstadoDePuntos.Base
			{
				// Token: 0x0600105B RID: 4187 RVA: 0x000368CA File Offset: 0x00034ACA
				public InicialesLocal(Linear7BoneChainBase owner)
					: base(owner)
				{
				}

				// Token: 0x17000558 RID: 1368
				// (get) Token: 0x0600105C RID: 4188 RVA: 0x000368D3 File Offset: 0x00034AD3
				public Vector3 centroDePuntos
				{
					get
					{
						return this.m_centroDePuntos;
					}
				}

				// Token: 0x0600105D RID: 4189 RVA: 0x000368DC File Offset: 0x00034ADC
				[Obsolete]
				public Vector3 ObtenerCentroDePuntosInicialActual()
				{
					Vector3 vector = Vector3.zero;
					vector += this.m_owner._000Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._001Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._002Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._003Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._004Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._005Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._006Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector /= 7f;
					return this.m_owner.transform.InverseTransformPoint(vector);
				}

				// Token: 0x0600105E RID: 4190 RVA: 0x000369D0 File Offset: 0x00034BD0
				public void Actializar()
				{
					Vector3 vector = Vector3.zero;
					vector += this.m_owner._000Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._001Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._002Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._003Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._004Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._005Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector += this.m_owner._006Base.jointDistancesAdmin.WorldSpaceJointTargetPoint();
					vector /= 7f;
					this.m_centroDePuntos = this.m_owner.transform.InverseTransformPoint(vector);
				}

				// Token: 0x0600105F RID: 4191 RVA: 0x00036ACA File Offset: 0x00034CCA
				public override void CopiarA(Linear7BoneChainBase.EstadoDePuntos.Base other)
				{
					((Linear7BoneChainBase.EstadoDePuntos.InicialesLocal)other).m_centroDePuntos = this.m_centroDePuntos;
				}

				// Token: 0x04000B47 RID: 2887
				[SerializeField]
				private Vector3 m_centroDePuntos;
			}

			// Token: 0x02000231 RID: 561
			[Serializable]
			public abstract class Base
			{
				// Token: 0x06001060 RID: 4192 RVA: 0x00036ADD File Offset: 0x00034CDD
				public Base(Linear7BoneChainBase owner)
				{
					if (owner == null)
					{
						throw new ArgumentNullException("owner", "owner null reference.");
					}
					this.m_owner = owner;
					this.OnInit();
				}

				// Token: 0x06001061 RID: 4193 RVA: 0x00036B0B File Offset: 0x00034D0B
				protected virtual void OnInit()
				{
				}

				// Token: 0x06001062 RID: 4194
				public abstract void CopiarA(Linear7BoneChainBase.EstadoDePuntos.Base other);

				// Token: 0x04000B48 RID: 2888
				protected Linear7BoneChainBase m_owner;
			}
		}
	}
}
