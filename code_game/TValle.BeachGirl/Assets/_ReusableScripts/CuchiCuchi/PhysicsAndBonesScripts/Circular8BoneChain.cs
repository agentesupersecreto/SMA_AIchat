using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000DC RID: 220
	[RequireComponent(typeof(Rigidbody))]
	public abstract class Circular8BoneChain : BoneStretchedChain
	{
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x060008B9 RID: 2233
		public abstract CircularChainPointStretcherJoint _3 { get; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x060008BA RID: 2234
		public abstract CircularChainPointStretcherJoint _9 { get; }

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x060008BB RID: 2235
		public abstract CircularChainPointStretcherJoint _130 { get; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x060008BC RID: 2236
		public abstract CircularChainPointStretcherJoint _430 { get; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x060008BD RID: 2237
		public abstract CircularChainPointStretcherJoint _1030 { get; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x060008BE RID: 2238
		public abstract CircularChainPointStretcherJoint _730 { get; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0001BAF0 File Offset: 0x00019CF0
		[Obsolete]
		public virtual FondoOfHole fondoOfHole
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0001BAF4 File Offset: 0x00019CF4
		protected override void LoadPointsToSet(HashSet<CircularChainPointStretcherJoint> target)
		{
			base.LoadPointsToSet(target);
			this.m_pointsSet.Add(this._3);
			this.m_pointsSet.Add(this._9);
			this.m_pointsSet.Add(this._130);
			this.m_pointsSet.Add(this._430);
			this.m_pointsSet.Add(this._1030);
			this.m_pointsSet.Add(this._730);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0001BB74 File Offset: 0x00019D74
		public void ObtenerAperturaYProfundidad(Circular8BoneChain.Punto punto, out float apertura, out float profundidad)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			base.ObtenerAperturaYProfundidad(circularChainPointStretcherJoint, out apertura, out profundidad);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001BB94 File Offset: 0x00019D94
		public override Vector3 ObtenerCentroDePuntosLocal()
		{
			if (this._12.transform.parent != this.centroDePuntos.parent || this._12.otherBody.transform.parent != this.centroDePuntos.parent)
			{
				throw new NotSupportedException("este algoritmo se desarrollo teniendo en cuenta q los puntos tendrian el mismo padre, para amentar el rendimiento");
			}
			Vector3 localPosition = this._12.otherBody.transform.localPosition;
			Vector3 localPosition2 = this._6.otherBody.transform.localPosition;
			Vector3 localPosition3 = this._3.otherBody.transform.localPosition;
			Vector3 localPosition4 = this._9.otherBody.transform.localPosition;
			return (localPosition + localPosition2 + localPosition3 + localPosition4) / 4f;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0001BC68 File Offset: 0x00019E68
		public override void ObtenerAperturaEntreColliderDePuntos(out float max, out float min)
		{
			Transform centroDePuntos = this.centroDePuntos;
			Vector3 vector = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._12));
			Vector3 vector2 = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._6));
			Vector3 vector3 = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._3));
			Vector3 vector4 = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._9));
			Vector3 vector5 = centroDePuntos.InverseTransformDirection(base.worldOutHoleDirection);
			Vector3 zero = Vector3.zero;
			vector = Math3d.ProjectPointOnPlane(vector5, zero, vector);
			vector2 = Math3d.ProjectPointOnPlane(vector5, zero, vector2);
			vector3 = Math3d.ProjectPointOnPlane(vector5, zero, vector3);
			vector4 = Math3d.ProjectPointOnPlane(vector5, zero, vector4);
			float num = Vector3.Distance(vector, vector2);
			float num2 = Vector3.Distance(vector3, vector4);
			max = Mathf.Max(num, num2);
			min = Mathf.Min(num, num2);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0001BD28 File Offset: 0x00019F28
		public override void ObtenerAperturaEntreColliderDePuntosUnidadesGlobales(out float max, out float min)
		{
			Vector3 vector = this.GetEdgeOfColliderWorldPosition(this._12);
			Vector3 vector2 = this.GetEdgeOfColliderWorldPosition(this._6);
			Vector3 vector3 = this.GetEdgeOfColliderWorldPosition(this._3);
			Vector3 vector4 = this.GetEdgeOfColliderWorldPosition(this._9);
			Vector3 worldOutHoleDirection = base.worldOutHoleDirection;
			Vector3 position = this.centroDePuntos.position;
			vector = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector);
			vector2 = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector2);
			vector3 = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector3);
			vector4 = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector4);
			float num = Vector3.Distance(vector, vector2);
			float num2 = Vector3.Distance(vector3, vector4);
			max = Mathf.Max(num, num2);
			min = Mathf.Min(num, num2);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0001BDCB File Offset: 0x00019FCB
		[Obsolete("re hacer pero con espacios locales")]
		public float DistanciaEntrePuntoYCentro(Circular8BoneChain.Punto punto)
		{
			return Vector3.Distance(this.ObtenerPunto(punto).otherBody.transform.position, this.centroDePuntos.position);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0001BDF4 File Offset: 0x00019FF4
		public float ObtenerApertura(Circular8BoneChain.Punto punto)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			Vector3 vector = this.centroDePuntos.InverseTransformPoint(circularChainPointStretcherJoint.otherBody.transform.position);
			vector.z = 0f;
			return vector.magnitude;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0001BE38 File Offset: 0x0001A038
		public float ObtenerProfundidad(Circular8BoneChain.Punto punto)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			return this.centroDePuntos.InverseTransformPoint(circularChainPointStretcherJoint.otherBody.transform.position).z;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0001BE70 File Offset: 0x0001A070
		public CircularChainPointStretcherJoint ObtenerPunto(Circular8BoneChain.Punto point)
		{
			switch (point)
			{
			case Circular8BoneChain.Punto._12:
				return this._12;
			case Circular8BoneChain.Punto._6:
				return this._6;
			case Circular8BoneChain.Punto._3:
				return this._3;
			case Circular8BoneChain.Punto._9:
				return this._9;
			case Circular8BoneChain.Punto._130:
				return this._130;
			case Circular8BoneChain.Punto._430:
				return this._430;
			case Circular8BoneChain.Punto._1030:
				return this._1030;
			case Circular8BoneChain.Punto._730:
				return this._730;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001BEE4 File Offset: 0x0001A0E4
		public Circular8BoneChain.Punto ObtenerPuntoEnum(CircularChainPointStretcherJoint point)
		{
			if (this._12 == point)
			{
				return Circular8BoneChain.Punto._12;
			}
			if (this._1030 == point)
			{
				return Circular8BoneChain.Punto._1030;
			}
			if (this._130 == point)
			{
				return Circular8BoneChain.Punto._130;
			}
			if (this._3 == point)
			{
				return Circular8BoneChain.Punto._3;
			}
			if (this._430 == point)
			{
				return Circular8BoneChain.Punto._430;
			}
			if (this._6 == point)
			{
				return Circular8BoneChain.Punto._6;
			}
			if (this._730 == point)
			{
				return Circular8BoneChain.Punto._730;
			}
			if (this._9 == point)
			{
				return Circular8BoneChain.Punto._9;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001BF78 File Offset: 0x0001A178
		public override int ObtenerPunto(CircularChainPointStretcherJoint point)
		{
			if (this._1030 == point)
			{
				return 6;
			}
			if (this._130 == point)
			{
				return 4;
			}
			if (this._3 == point)
			{
				return 2;
			}
			if (this._430 == point)
			{
				return 5;
			}
			if (this._730 == point)
			{
				return 7;
			}
			if (this._9 == point)
			{
				return 3;
			}
			return base.ObtenerPunto(point);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001BFEC File Offset: 0x0001A1EC
		public override CircularChainPointStretcherJoint ObtenerPunto(int point)
		{
			switch (point)
			{
			case 0:
				return this._12;
			case 1:
				return this._6;
			case 2:
				return this._3;
			case 3:
				return this._9;
			case 4:
				return this._130;
			case 5:
				return this._430;
			case 6:
				return this._1030;
			case 7:
				return this._730;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x020001B7 RID: 439
		public enum Punto
		{
			// Token: 0x040009E1 RID: 2529
			_12,
			// Token: 0x040009E2 RID: 2530
			_6,
			// Token: 0x040009E3 RID: 2531
			_3,
			// Token: 0x040009E4 RID: 2532
			_9,
			// Token: 0x040009E5 RID: 2533
			_130,
			// Token: 0x040009E6 RID: 2534
			_430,
			// Token: 0x040009E7 RID: 2535
			_1030,
			// Token: 0x040009E8 RID: 2536
			_730
		}
	}
}
