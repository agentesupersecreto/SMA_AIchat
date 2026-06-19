using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes
{
	// Token: 0x0200011A RID: 282
	[Serializable]
	public class CapsuleModificable
	{
		// Token: 0x060005C8 RID: 1480 RVA: 0x00020B10 File Offset: 0x0001ED10
		public CapsuleModificable(CapsuleCollider collider)
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
			this.height.@base = collider.height;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00020BDC File Offset: 0x0001EDDC
		public void Fix()
		{
			this.m_collider.center = new Vector3(this.centerX.@base, this.centerY.@base, this.centerZ.@base);
			this.m_collider.radius = this.radius.@base;
			this.m_collider.height = this.height.@base;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00020C48 File Offset: 0x0001EE48
		public void Actualizar()
		{
			this.m_collider.radius = this.radius.valorMidifcado;
			this.m_collider.height = this.height.valorMidifcado;
			this.m_collider.center = new Vector3(this.centerX.valorMidifcado, this.centerY.valorMidifcado, this.centerZ.valorMidifcado);
		}

		// Token: 0x04000485 RID: 1157
		private CapsuleCollider m_collider;

		// Token: 0x04000486 RID: 1158
		public ValorFlotante centerX = new ValorFlotante();

		// Token: 0x04000487 RID: 1159
		public ValorFlotante centerY = new ValorFlotante();

		// Token: 0x04000488 RID: 1160
		public ValorFlotante centerZ = new ValorFlotante();

		// Token: 0x04000489 RID: 1161
		public ValorFlotante radius = new ValorFlotante();

		// Token: 0x0400048A RID: 1162
		public ValorFlotante height = new ValorFlotante();
	}
}
