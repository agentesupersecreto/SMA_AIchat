using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes
{
	// Token: 0x02000118 RID: 280
	[Serializable]
	public class BoxModificable
	{
		// Token: 0x060005C2 RID: 1474 RVA: 0x000207E4 File Offset: 0x0001E9E4
		public BoxModificable(BoxCollider collider)
		{
			if (collider == null)
			{
				throw new ArgumentNullException("collider", "collider null reference.");
			}
			this.m_collider = collider;
			Vector3 size = this.m_collider.size;
			Vector3 center = this.m_collider.center;
			this.sizeX.@base = size.x;
			this.sizeY.@base = size.y;
			this.sizeZ.@base = size.z;
			this.centerX.@base = center.x;
			this.centerY.@base = center.y;
			this.centerZ.@base = center.z;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x000208D8 File Offset: 0x0001EAD8
		public void Fix()
		{
			this.m_collider.size = new Vector3(this.sizeX.@base, this.sizeY.@base, this.sizeZ.@base);
			this.m_collider.center = new Vector3(this.centerX.@base, this.centerY.@base, this.centerZ.@base);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00020948 File Offset: 0x0001EB48
		public void Actualizar()
		{
			this.m_collider.size = new Vector3(this.sizeX.valorMidifcado, this.sizeY.valorMidifcado, this.sizeZ.valorMidifcado);
			this.m_collider.center = new Vector3(this.centerX.valorMidifcado, this.centerY.valorMidifcado, this.centerZ.valorMidifcado);
		}

		// Token: 0x04000479 RID: 1145
		private BoxCollider m_collider;

		// Token: 0x0400047A RID: 1146
		public ValorFlotante centerX = new ValorFlotante();

		// Token: 0x0400047B RID: 1147
		public ValorFlotante centerY = new ValorFlotante();

		// Token: 0x0400047C RID: 1148
		public ValorFlotante centerZ = new ValorFlotante();

		// Token: 0x0400047D RID: 1149
		public ValorFlotante sizeX = new ValorFlotante();

		// Token: 0x0400047E RID: 1150
		public ValorFlotante sizeY = new ValorFlotante();

		// Token: 0x0400047F RID: 1151
		public ValorFlotante sizeZ = new ValorFlotante();
	}
}
