using System;

namespace TValleCustomClases
{
	// Token: 0x02000061 RID: 97
	public class DynamicConstraintInstantiation<TConstraint, TParam1, TParam2> : DynamicInstantiation<TParam1, TParam2> where TConstraint : class
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000DE45 File Offset: 0x0000C045
		public static DynamicConstraintInstantiation<TConstraint, TParam1, TParam2> constraintInstance
		{
			get
			{
				if (DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>.m_singleton == null)
				{
					DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>.m_singleton = new DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>();
				}
				return DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>.m_singleton;
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000DE5D File Offset: 0x0000C05D
		public static T InstantiateConstraintType<T>(Type type, TParam1 param1, TParam2 param2) where T : TConstraint
		{
			return (T)((object)DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>.constraintInstance.Instantiate(type, param1, param2));
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000DE71 File Offset: 0x0000C071
		public static TConstraint InstantiateConstraintType(Type type, TParam1 param1, TParam2 param2)
		{
			return (TConstraint)((object)DynamicConstraintInstantiation<TConstraint, TParam1, TParam2>.constraintInstance.Instantiate(type, param1, param2));
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000DE85 File Offset: 0x0000C085
		protected override bool EvaluateType(Type type)
		{
			return typeof(TConstraint).IsAssignableFrom(type);
		}

		// Token: 0x0400009F RID: 159
		private static DynamicConstraintInstantiation<TConstraint, TParam1, TParam2> m_singleton;
	}
}
