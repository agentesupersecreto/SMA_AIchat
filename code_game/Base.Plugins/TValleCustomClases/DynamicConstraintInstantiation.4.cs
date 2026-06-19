using System;

namespace TValleCustomClases
{
	// Token: 0x02000063 RID: 99
	public class DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3> : DynamicInstantiation<TParam1, TParam2, TParam3> where TConstraint : class
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0000E018 File Offset: 0x0000C218
		public static DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3> constraintInstance
		{
			get
			{
				if (DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>.m_singleton == null)
				{
					DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>.m_singleton = new DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>();
				}
				return DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>.m_singleton;
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000E030 File Offset: 0x0000C230
		public static T InstantiateConstraintType<T>(Type type, TParam1 param1, TParam2 param2, TParam3 param3) where T : TConstraint
		{
			return (T)((object)DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>.constraintInstance.Instantiate(type, param1, param2, param3));
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000E045 File Offset: 0x0000C245
		public static TConstraint InstantiateConstraintType(Type type, TParam1 param1, TParam2 param2, TParam3 param3)
		{
			return (TConstraint)((object)DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3>.constraintInstance.Instantiate(type, param1, param2, param3));
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000E05A File Offset: 0x0000C25A
		protected override bool EvaluateType(Type type)
		{
			return typeof(TConstraint).IsAssignableFrom(type);
		}

		// Token: 0x040000A2 RID: 162
		private static DynamicConstraintInstantiation<TConstraint, TParam1, TParam2, TParam3> m_singleton;
	}
}
