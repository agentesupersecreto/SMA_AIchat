using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200007B RID: 123
	public static class CollisionExt
	{
		// Token: 0x06000391 RID: 913 RVA: 0x0000F3E8 File Offset: 0x0000D5E8
		public static void DrawCollision(this Collision col)
		{
			for (int i = 0; i < col.contactCount; i++)
			{
				ContactPoint contact = col.GetContact(i);
				Debug.DrawRay(contact.point, contact.normal * 3f, Color.blue, 10f, false);
				Debug.DrawRay(contact.point, col.relativeVelocity.normalized * 3f, Color.red, 10f, false);
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000F468 File Offset: 0x0000D668
		private static float correctAngle(float angle, float limit = 90f)
		{
			if (angle < 0f)
			{
				angle *= -1f;
			}
			float num = limit + limit;
			if (angle >= num)
			{
				return 0f;
			}
			if (angle > limit)
			{
				return num - angle;
			}
			return angle;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000F49D File Offset: 0x0000D69D
		private static float KineticEnergy(float mass, float SqeVelocity)
		{
			return 0.5f * mass * SqeVelocity;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000F4A8 File Offset: 0x0000D6A8
		private static double KineticEnergyDoublePrecision(float mass, float SqeVelocity)
		{
			return 0.5 * (double)mass * (double)SqeVelocity;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000F4BC File Offset: 0x0000D6BC
		private static double getOtherEnergyOnCollision(Collision col, Vector3 myVelocityOnCollision)
		{
			if (col.rigidbody == null)
			{
				return 0.0;
			}
			Vector3 vector = col.relativeVelocity + myVelocityOnCollision;
			return CollisionExt.KineticEnergyDoublePrecision(col.rigidbody.mass, vector.sqrMagnitude);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000F508 File Offset: 0x0000D708
		private static double getOtherEnergyAfterCollision(Collision col)
		{
			if (col.rigidbody == null)
			{
				return 0.0;
			}
			return CollisionExt.KineticEnergyDoublePrecision(col.rigidbody.mass, col.rigidbody.velocity.sqrMagnitude);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000F550 File Offset: 0x0000D750
		public static bool AreContatctsBug(this Collision col)
		{
			return col.contactCount == 0;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000F55C File Offset: 0x0000D75C
		public static bool AreContactsBug(this Collision col, out Vector3 firstPoint)
		{
			bool flag = col.AreContatctsBug();
			if (flag)
			{
				firstPoint = default(Vector3);
				return flag;
			}
			firstPoint = col.GetContact(0).point;
			return flag;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000F590 File Offset: 0x0000D790
		public static void CollisionEnergyStats(this Collision col, Rigidbody myRigidbody, Vector3 myVelocityOnCollision, out double TotalEnergyOnCollision, out double TotalEnergyLostAfterCollision, out double DamageMod, bool isDebugging = false)
		{
			double num = CollisionExt.KineticEnergyDoublePrecision(myRigidbody.mass, myVelocityOnCollision.sqrMagnitude);
			double otherEnergyOnCollision = CollisionExt.getOtherEnergyOnCollision(col, myVelocityOnCollision);
			double num2 = CollisionExt.KineticEnergyDoublePrecision(myRigidbody.mass, myRigidbody.velocity.sqrMagnitude);
			double otherEnergyAfterCollision = CollisionExt.getOtherEnergyAfterCollision(col);
			TotalEnergyOnCollision = num + otherEnergyOnCollision;
			double num3 = num2 + otherEnergyAfterCollision;
			TotalEnergyLostAfterCollision = TotalEnergyOnCollision - num3;
			if (TotalEnergyLostAfterCollision < 0.0)
			{
				TotalEnergyLostAfterCollision = 0.0;
			}
			DamageMod = TotalEnergyLostAfterCollision / TotalEnergyOnCollision;
			if (isDebugging)
			{
				Debug.Log(string.Concat(new string[]
				{
					" total energy on collision ",
					TotalEnergyOnCollision.ToString(),
					" total energy after collision ",
					num3.ToString(),
					" energy lost ",
					TotalEnergyLostAfterCollision.ToString(),
					" mod ",
					DamageMod.ToString()
				}));
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000F668 File Offset: 0x0000D868
		public static float EnergyChangeAfterCollision(this Collision col, Rigidbody myRigidbody, Vector3 myVelocityOnCollision)
		{
			float num = CollisionExt.KineticEnergy(myRigidbody.mass, myVelocityOnCollision.sqrMagnitude);
			float num2 = CollisionExt.KineticEnergy(myRigidbody.mass, myRigidbody.velocity.sqrMagnitude);
			float num3 = num - num2;
			if (num3 < 0f)
			{
				num3 = Mathf.Abs(num3);
			}
			return num3;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000F6B4 File Offset: 0x0000D8B4
		public static float GetCollisionAngleFast(this Collision col)
		{
			if (col.AreContatctsBug())
			{
				return 0f;
			}
			return CollisionExt.correctAngle(Vector3.Angle(col.GetContact(0).normal, col.relativeVelocity), 90f);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		public static float GetCollisionAngle(this Collision col)
		{
			if (col.AreContatctsBug())
			{
				return 0f;
			}
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < col.contactCount; i++)
			{
				vector += col.GetContact(i).normal;
			}
			vector /= (float)col.contactCount;
			return CollisionExt.correctAngle(Vector3.Angle(vector, col.relativeVelocity), 90f);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000F760 File Offset: 0x0000D960
		public static float GetCollisionBounceFast(this Collision col)
		{
			if (col.AreContatctsBug())
			{
				return 0f;
			}
			ContactPoint contact = col.GetContact(0);
			PhysicMaterial sharedMaterial = contact.thisCollider.sharedMaterial;
			PhysicMaterial sharedMaterial2 = contact.otherCollider.sharedMaterial;
			if (sharedMaterial == null)
			{
				return 0f;
			}
			float bounciness = sharedMaterial.bounciness;
			float num;
			if (sharedMaterial2 == null)
			{
				num = 0f;
			}
			else
			{
				num = sharedMaterial2.bounciness;
			}
			float num2 = 0f;
			switch (sharedMaterial.bounceCombine)
			{
			case PhysicMaterialCombine.Average:
				num2 += (bounciness + num) / 2f;
				break;
			case PhysicMaterialCombine.Multiply:
				num2 += bounciness * num;
				break;
			case PhysicMaterialCombine.Minimum:
				num2 += Mathf.Min(bounciness, num);
				break;
			case PhysicMaterialCombine.Maximum:
				num2 += Mathf.Max(bounciness, num);
				break;
			}
			return Mathf.Clamp(num2, 0f, 1f);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000F840 File Offset: 0x0000DA40
		public static float GetCollisionBounce(this Collision col)
		{
			if (col.AreContatctsBug())
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < col.contactCount; i++)
			{
				ContactPoint contact = col.GetContact(i);
				PhysicMaterial sharedMaterial = contact.thisCollider.sharedMaterial;
				PhysicMaterial sharedMaterial2 = contact.otherCollider.sharedMaterial;
				if (!(sharedMaterial == null) && !(sharedMaterial2 == null))
				{
					switch (sharedMaterial.bounceCombine)
					{
					case PhysicMaterialCombine.Average:
						num += (sharedMaterial.bounciness + sharedMaterial2.bounciness) / 2f;
						break;
					case PhysicMaterialCombine.Multiply:
						num += sharedMaterial.bounciness * sharedMaterial2.bounciness;
						break;
					case PhysicMaterialCombine.Minimum:
						num += Mathf.Min(sharedMaterial.bounciness, sharedMaterial2.bounciness);
						break;
					case PhysicMaterialCombine.Maximum:
						num += Mathf.Max(sharedMaterial.bounciness, sharedMaterial2.bounciness);
						break;
					}
				}
			}
			float num2 = num / (float)col.contactCount;
			if (float.IsNaN(num2))
			{
				Debug.LogWarning("damage is NaN");
			}
			return num2;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000F948 File Offset: 0x0000DB48
		public static double GetPhysicsDamage(this Collision collision, Rigidbody myRigidbody, Vector3 myVelocityOnCollision, bool isDebugging = false)
		{
			double num;
			double num2;
			double num3;
			collision.CollisionEnergyStats(myRigidbody, myVelocityOnCollision, out num, out num2, out num3, isDebugging);
			return num * num3 * 0.002591995522379875;
		}

		// Token: 0x040000C8 RID: 200
		public const float CollisionDamageModificador = 0.0025919955f;
	}
}
