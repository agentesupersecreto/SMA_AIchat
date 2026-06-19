using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes
{
	// Token: 0x02000119 RID: 281
	[Serializable]
	public class SphereModificable
	{
		// Token: 0x060005C5 RID: 1477 RVA: 0x000209B8 File Offset: 0x0001EBB8
		public SphereModificable(SphereCollider collider)
		{
			if (collider == null)
			{
				throw new ArgumentNullException("collider", "collider null reference.");
			}
			this.m_collider = collider;
			Vector3 center = this.m_collider.center;
			this.centerX.@base = center.x;
			this.centerY.@base = center.y;
			this.centerZ.@base = center.z;
			this.radius.@base = collider.radius;
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00020A68 File Offset: 0x0001EC68
		public void Fix()
		{
			this.m_collider.center = new Vector3(this.centerX.@base, this.centerY.@base, this.centerZ.@base);
			this.m_collider.radius = this.radius.@base;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00020ABC File Offset: 0x0001ECBC
		public void Actualizar()
		{
			this.m_collider.radius = this.radius.valorMidifcado;
			this.m_collider.center = new Vector3(this.centerX.valorMidifcado, this.centerY.valorMidifcado, this.centerZ.valorMidifcado);
		}

		// Token: 0x04000480 RID: 1152
		private SphereCollider m_collider;

		// Token: 0x04000481 RID: 1153
		public ValorFlotante centerX = new ValorFlotante();

		// Token: 0x04000482 RID: 1154
		public ValorFlotante centerY = new ValorFlotante();

		// Token: 0x04000483 RID: 1155
		public ValorFlotante centerZ = new ValorFlotante();

		// Token: 0x04000484 RID: 1156
		public ValorFlotante radius = new ValorFlotante();
	}
}
