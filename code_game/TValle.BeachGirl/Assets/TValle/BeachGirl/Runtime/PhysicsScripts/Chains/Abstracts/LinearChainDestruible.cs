using System;
using System.Collections.Generic;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts
{
	// Token: 0x02000095 RID: 149
	public abstract class LinearChainDestruible<Tpoint, Tconfig> : AplicableBehaviour, ILinearChain where Tpoint : RecalculableJoint<Tconfig> where Tconfig : RecalculableJointBase.JointConfiguracion
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600046E RID: 1134
		public abstract int cantidadDePuntos { get; }

		// Token: 0x0600046F RID: 1135 RVA: 0x0000E7DD File Offset: 0x0000C9DD
		protected sealed override void AfterStartUnityEvent()
		{
			base.AfterStartUnityEvent();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000E7E5 File Offset: 0x0000C9E5
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000E7F0 File Offset: 0x0000C9F0
		protected virtual void LoadPuntos()
		{
			for (int i = 0; i < this.cantidadDePuntos; i++)
			{
				Tpoint tpoint = this.LoadPunto(i);
				this.CustomizarPunto(tpoint, i);
				this.m_puntos.Add(i, tpoint);
				this.m_puntosList.Add(tpoint);
				tpoint.SetManualStart();
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000E844 File Offset: 0x0000CA44
		protected virtual Tpoint LoadPunto(int index)
		{
			Transform jointTransformOfPoint = this.GetJointTransformOfPoint(index);
			Transform targetBodyTransformOfPoint = this.GetTargetBodyTransformOfPoint(index);
			if (jointTransformOfPoint == null)
			{
				throw new ArgumentNullException("JointTransform", "JointTransform null reference.");
			}
			if (targetBodyTransformOfPoint == null)
			{
				throw new ArgumentNullException("TargetTransform", "TargetTransform null reference.");
			}
			Transform charBoneTargetTransformOfPoint = this.GetCharBoneTargetTransformOfPoint(index);
			Tpoint point = this.GetPoint(index, jointTransformOfPoint, targetBodyTransformOfPoint);
			point.scalerBone = charBoneTargetTransformOfPoint;
			return point;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000E8B0 File Offset: 0x0000CAB0
		protected virtual Tpoint GetPoint(int index, Transform jointTransform, Transform targetTransform)
		{
			Tpoint tpoint = jointTransform.gameObject.AddComponent<Tpoint>();
			Tconfig tconfig = this.puntosConfig;
			tpoint.configuracion = tconfig;
			tpoint.jointTransform = jointTransform;
			tpoint.targetBodyTransform = targetTransform;
			return tpoint;
		}

		// Token: 0x06000474 RID: 1140
		protected abstract Transform GetJointTransformOfPoint(int index);

		// Token: 0x06000475 RID: 1141
		protected abstract Transform GetTargetBodyTransformOfPoint(int index);

		// Token: 0x06000476 RID: 1142
		protected abstract Transform GetCharBoneTargetTransformOfPoint(int index);

		// Token: 0x06000477 RID: 1143 RVA: 0x0000E8F3 File Offset: 0x0000CAF3
		protected virtual void CustomizarPunto(Tpoint punto, int index)
		{
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000E8F8 File Offset: 0x0000CAF8
		protected void StartPoints()
		{
			for (int i = 0; i < this.m_puntosList.Count; i++)
			{
				this.m_puntosList[i].ManualStart();
			}
			for (int j = 0; j < this.m_puntosList.Count; j++)
			{
				Tpoint tpoint = this.m_puntosList[j];
				this.AfterStartPoint(tpoint);
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000E95B File Offset: 0x0000CB5B
		protected virtual void AfterStartPoint(Tpoint point)
		{
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000E95D File Offset: 0x0000CB5D
		EstadoDeCadena ILinearChain.estado
		{
			get
			{
				return EstadoDeCadena.activa;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0000E960 File Offset: 0x0000CB60
		public IReadOnlyList<RecalculableJointBase> puntosExcluyendoRootList
		{
			get
			{
				return this.m_puntosList;
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000E968 File Offset: 0x0000CB68
		public virtual void FixEnOrdenAsc()
		{
			for (int i = 0; i < this.m_puntosList.Count; i++)
			{
				this.m_puntosList[i].FixAdmins();
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000E9A4 File Offset: 0x0000CBA4
		public virtual void KillForces()
		{
			for (int i = 0; i < this.m_puntosList.Count; i++)
			{
				this.m_puntosList[i].KillForces();
			}
		}

		// Token: 0x040002A4 RID: 676
		public Tconfig puntosConfig;

		// Token: 0x040002A5 RID: 677
		private Dictionary<int, Tpoint> m_puntos = new Dictionary<int, Tpoint>();

		// Token: 0x040002A6 RID: 678
		[NonSerialized]
		private List<Tpoint> m_puntosList = new List<Tpoint>();
	}
}
