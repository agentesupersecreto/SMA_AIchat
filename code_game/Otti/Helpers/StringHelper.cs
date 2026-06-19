using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000036 RID: 54
	public class StringHelper
	{
		// Token: 0x06000295 RID: 661 RVA: 0x0000C6E4 File Offset: 0x0000A8E4
		public static string ToSimpleString(int rValue)
		{
			return string.Format("{0}", rValue);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000C6F6 File Offset: 0x0000A8F6
		public static string ToSimpleString(float rValue)
		{
			return string.Format("{0:f2}", rValue);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000C708 File Offset: 0x0000A908
		public static string ToSimpleString(bool rValue)
		{
			if (!rValue)
			{
				return "false";
			}
			return "true";
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000C718 File Offset: 0x0000A918
		public static string ToSimpleString(string rValue)
		{
			return rValue;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000C71B File Offset: 0x0000A91B
		public static string ToSimpleString(Vector2 rValue)
		{
			return string.Format("{0:f2}, {1:f2}", rValue.x, rValue.y);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000C73D File Offset: 0x0000A93D
		public static string ToSimpleString(Vector3 rValue)
		{
			return string.Format("{0:f2}, {1:f2}, {2:f2}", rValue.x, rValue.y, rValue.z);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000C76C File Offset: 0x0000A96C
		public static string ToSimpleString(Vector4 rValue)
		{
			return string.Format("{0:f2}, {1:f2}, {2:f2}, {3:f2}", new object[] { rValue.x, rValue.y, rValue.z, rValue.w });
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000C7C4 File Offset: 0x0000A9C4
		public static string ToSimpleString(Quaternion rValue)
		{
			Vector3 eulerAngles = rValue.eulerAngles;
			return string.Format("{0:f5}, {1:f5}, {2:f5}", eulerAngles.x, eulerAngles.y, eulerAngles.z);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000C804 File Offset: 0x0000AA04
		public static string ToSimpleString(Transform rValue)
		{
			if (rValue == null)
			{
				return "null";
			}
			return string.Format("{0}", rValue.name);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000C825 File Offset: 0x0000AA25
		public static string ToSimpleString(GameObject rValue)
		{
			if (rValue == null)
			{
				return "null";
			}
			return string.Format("{0}", rValue.name);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000C846 File Offset: 0x0000AA46
		public static string ToSimpleString(Object rValue)
		{
			if (rValue == null)
			{
				return "null";
			}
			return string.Format("{0}", rValue.name);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000C867 File Offset: 0x0000AA67
		public static string ToSimpleString(object rValue)
		{
			if (rValue == null)
			{
				return "null";
			}
			return string.Format("{0}", rValue.ToString());
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000C884 File Offset: 0x0000AA84
		public static string ToString(Vector3 rInput)
		{
			return string.Format("[m:{0:f6} x:{1:f6} y:{2:f6} z:{3:f6}]", new object[] { rInput.magnitude, rInput.x, rInput.y, rInput.z });
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000C8DC File Offset: 0x0000AADC
		public static string ToString(Quaternion rInput)
		{
			Vector3 eulerAngles = rInput.eulerAngles;
			float num = 0f;
			Vector3 zero = Vector3.zero;
			rInput.ToAngleAxis(out num, out zero);
			return string.Format("[p:{0:f4} y:{1:f4} r:{2:f4} x:{3:f7} y:{4:f7} z:{5:f7} w:{6:f7} angle:{7:f7} axis:{8}]", new object[]
			{
				eulerAngles.x,
				eulerAngles.y,
				eulerAngles.z,
				rInput.x,
				rInput.y,
				rInput.z,
				rInput.w,
				num,
				StringHelper.ToString(zero)
			});
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000C98D File Offset: 0x0000AB8D
		public static string FormatCamelCase(string rInput)
		{
			return Regex.Replace(Regex.Replace(rInput, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000C9AE File Offset: 0x0000ABAE
		public static string CleanString(string rInput)
		{
			return rInput.Replace(" ", string.Empty).Replace("_", string.Empty).ToLower();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000C9D4 File Offset: 0x0000ABD4
		public static int Split(string rString, char rDelimiter)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < rString.Length; i++)
			{
				if (rString[i] == rDelimiter)
				{
					StringHelper.SharedStrings[num] = rString.Substring(num2, i - num2);
					num++;
					num2 = i + 1;
				}
			}
			StringHelper.SharedStrings[num] = rString.Substring(num2, rString.Length - num2);
			return num + 1;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000CA34 File Offset: 0x0000AC34
		public static string[] Split(string rString, string rDelimiter, string rQualifier, bool rIgnoreCase)
		{
			int num = 0;
			bool flag = false;
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < rString.Length - 1; i++)
			{
				if (rQualifier != null && string.Compare(rString.Substring(i, rQualifier.Length), rQualifier, rIgnoreCase) == 0)
				{
					flag = !flag;
				}
				else if (!flag && string.Compare(rString.Substring(i, rDelimiter.Length), rDelimiter, rIgnoreCase) == 0)
				{
					arrayList.Add(rString.Substring(num, i - num));
					num = i + rDelimiter.Length;
				}
			}
			if (num < rString.Length)
			{
				arrayList.Add(rString.Substring(num, rString.Length - num));
			}
			string[] array = new string[arrayList.Count];
			arrayList.CopyTo(array);
			return array;
		}

		// Token: 0x04000186 RID: 390
		public const int MAX_STRINGS = 100;

		// Token: 0x04000187 RID: 391
		public static string[] SharedStrings = new string[100];
	}
}
