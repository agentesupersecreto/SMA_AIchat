using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Puntos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Cadenas
{
	// Token: 0x02000114 RID: 276
	[RequireComponent(typeof(CadenaLinearDeLargoVariable))]
	public sealed class CollidersParaCadenaLinearDeLargoVariable : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000C2C RID: 3116 RVA: 0x000292B6 File Offset: 0x000274B6
		public IReadOnlyList<Collider> colliders
		{
			get
			{
				return this.m_collidersProducidos;
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x000292C0 File Offset: 0x000274C0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_cadena = base.GetComponent<CadenaLinearDeLargoVariable>();
			if (this.m_cadena == null)
			{
				throw new ArgumentNullException("m_cadena", "m_cadena null reference.");
			}
			if (this.material == null)
			{
				throw new ArgumentNullException("material", "material null reference.");
			}
			this.m_cadena.pointsStared += this.M_cadena_pointsStared;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00029334 File Offset: 0x00027534
		private void M_cadena_pointsStared(LinearChainTipo2<PuntoGenerico, PuntoGenerico.Configuracion> obj)
		{
			int cantidadDePuntos = this.m_cadena.cantidadDePuntos;
			for (int i = 0; i < cantidadDePuntos; i++)
			{
				bool flag = i == cantidadDePuntos - 1;
				if (!flag || this.addLast)
				{
					PuntoGenerico puntoGenerico = this.m_cadena[i];
					if (!flag)
					{
						Transform transform = this.m_cadena[i + 1].jointRigidbody.transform;
						if (!(transform == null))
						{
							float num = Vector3.Distance(puntoGenerico.jointRigidbody.transform.position, transform.position);
							if (num > 0f)
							{
								BoxCollider boxCollider = puntoGenerico.jointRigidbody.transform.CreateChild(puntoGenerico.name + "Collider").gameObject.AddComponent<BoxCollider>();
								ExtendedMonoBehaviour.PointToPointCollider(boxCollider, puntoGenerico.jointRigidbody.transform, transform, this.largoAAnchoMod * num, false, false);
								this.m_collidersProducidos.Add(boxCollider);
								boxCollider.sharedMaterial = this.material;
							}
						}
					}
					else
					{
						Vector3 vector = this.m_cadena[i - 1].jointRigidbody.transform.position - puntoGenerico.jointRigidbody.transform.position;
						float magnitude = vector.magnitude;
						if (magnitude > 0f)
						{
							BoxCollider boxCollider2 = puntoGenerico.jointRigidbody.transform.CreateChild(puntoGenerico.name + "Collider").gameObject.AddComponent<BoxCollider>();
							ExtendedMonoBehaviour.PointToPointCollider(boxCollider2, puntoGenerico.jointRigidbody.transform, puntoGenerico.jointRigidbody.transform.position + -vector.normalized * magnitude, this.largoAAnchoMod * magnitude, false, false);
							this.m_collidersProducidos.Add(boxCollider2);
							boxCollider2.sharedMaterial = this.material;
						}
					}
				}
			}
		}

		// Token: 0x04000697 RID: 1687
		public PhysicMaterial material;

		// Token: 0x04000698 RID: 1688
		public bool addLast = true;

		// Token: 0x04000699 RID: 1689
		[Range(0f, 1f)]
		public float largoAAnchoMod = 0.33f;

		// Token: 0x0400069A RID: 1690
		private CadenaLinearDeLargoVariable m_cadena;

		// Token: 0x0400069B RID: 1691
		[CoolArrayItem(removable = false)]
		private List<BoxCollider> m_collidersProducidos = new List<BoxCollider>();
	}
}
