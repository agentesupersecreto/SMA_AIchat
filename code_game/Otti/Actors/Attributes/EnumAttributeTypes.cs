using System;
using UnityEngine;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000D7 RID: 215
	public class EnumAttributeTypes
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x000349C8 File Offset: 0x00032BC8
		public static int GetEnum(Type rType)
		{
			for (int i = 0; i < EnumAttributeTypes.Types.Length; i++)
			{
				if (EnumAttributeTypes.Types[i] == rType)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x000349FC File Offset: 0x00032BFC
		public static string GetName(Type rType)
		{
			for (int i = 0; i < EnumAttributeTypes.Types.Length; i++)
			{
				if (EnumAttributeTypes.Types[i] == rType)
				{
					return EnumAttributeTypes.Names[i];
				}
			}
			return "Tag";
		}

		// Token: 0x040005AC RID: 1452
		public const int TAG = 0;

		// Token: 0x040005AD RID: 1453
		public const int STRING = 1;

		// Token: 0x040005AE RID: 1454
		public const int FLOAT = 2;

		// Token: 0x040005AF RID: 1455
		public const int INT = 3;

		// Token: 0x040005B0 RID: 1456
		public const int BOOL = 4;

		// Token: 0x040005B1 RID: 1457
		public const int VECTOR2 = 5;

		// Token: 0x040005B2 RID: 1458
		public const int VECTOR3 = 6;

		// Token: 0x040005B3 RID: 1459
		public const int VECTOR4 = 7;

		// Token: 0x040005B4 RID: 1460
		public const int QUATERNION = 8;

		// Token: 0x040005B5 RID: 1461
		public const int TRANSFORM = 9;

		// Token: 0x040005B6 RID: 1462
		public const int GAMEOBJECT = 10;

		// Token: 0x040005B7 RID: 1463
		public static string[] Names = new string[]
		{
			"Tag", "String", "Float", "Integer", "Boolean", "Vector2", "Vector3", "Vector4", "Quaternion", "Transform",
			"GameObject"
		};

		// Token: 0x040005B8 RID: 1464
		public static Type[] Types = new Type[]
		{
			null,
			typeof(string),
			typeof(float),
			typeof(int),
			typeof(bool),
			typeof(Vector2),
			typeof(Vector3),
			typeof(Vector4),
			typeof(Quaternion),
			typeof(Transform),
			typeof(GameObject)
		};
	}
}
