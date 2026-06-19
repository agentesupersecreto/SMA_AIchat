using System;
using UnityEngine;

namespace Assets.Scripts.Testing
{
	// Token: 0x02000042 RID: 66
	public class BarycentricsCalculeTest : CustomMonobehaviour
	{
		// Token: 0x06000144 RID: 324 RVA: 0x0000B524 File Offset: 0x00009724
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			if (this.a && this.b)
			{
				Gizmos.DrawLine(this.a.position, this.b.position);
			}
			if (this.b && this.c)
			{
				Gizmos.DrawLine(this.b.position, this.c.position);
			}
			if (this.c && this.a)
			{
				Gizmos.DrawLine(this.c.position, this.a.position);
			}
			if (this.a && this.b && this.c)
			{
				Vector3 vector = Math3d.CalculateSurfaceNormal(this.a.position, this.b.position, this.c.position);
				Vector3 vector2 = (this.a.position + this.b.position + this.c.position) / 3f;
				float magnitude = (this.a.position - this.b.position + (this.b.position - this.c.position) + (this.c.position - this.b.position)).magnitude;
				Gizmos.DrawRay(vector2, vector * magnitude / 3f);
				if (this.p)
				{
					Gizmos.color = Color.black;
					DebugExtension.DrawPoint(this.p.position, Color.black, magnitude * 0.05f);
					Vector3 vector3 = Math3d.ProjectPointOnPlane(vector, vector2, this.p.position);
					DebugExtension.DrawPoint(vector3, Color.white, magnitude * 0.05f);
					Vector3 vector4 = Math3d.CalculateBarycentricCoordinate(vector3, this.a.position, this.b.position, this.c.position);
					Vector3 vector5 = this.a.position * vector4.x + this.b.position * vector4.y + this.c.position * vector4.z;
					Color color;
					if (vector4.x < 0f || vector4.y < 0f || vector4.z < 0f)
					{
						color = Color.red;
					}
					else
					{
						color = Color.green;
					}
					DebugExtension.DrawPoint(vector5, color, magnitude * 0.05f);
				}
			}
		}

		// Token: 0x040000B1 RID: 177
		public Transform p;

		// Token: 0x040000B2 RID: 178
		public Transform a;

		// Token: 0x040000B3 RID: 179
		public Transform b;

		// Token: 0x040000B4 RID: 180
		public Transform c;
	}
}
