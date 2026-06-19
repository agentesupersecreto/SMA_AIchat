using System;

namespace TValleCustomClases
{
	// Token: 0x0200005F RID: 95
	public class DynamicConstraintInstantiation<TConstraint, TParam> : DynamicInstantiation<TParam> where TConstraint : class
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000DCB2 File Offset: 0x0000BEB2
		public static DynamicConstraintInstantiation<TConstraint, TParam> constraintInstance
		{
			get
			{
				if (DynamicConstraintInstantiation<TConstraint, TParam>.m_singleton == null)
				{
					DynamicConstraintInstantiation<TConstraint, TParam>.m_singleton = new DynamicConstraintInstantiation<TConstraint, TParam>();
				}
				return DynamicConstraintInstantiation<TConstraint, TParam>.m_singleton;
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000DCCA File Offset: 0x0000BECA
		public static T InstantiateConstraintType<T>(Type type, TParam param) where T : TConstraint
		{
			return (T)((object)DynamicConstraintInstantiation<TConstraint, TParam>.constraintInstance.Instantiate(type, param));
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000DCDD File Offset: 0x0000BEDD
		public static TConstraint InstantiateConstraintType(Type type, TParam param)
		{
			return (TConstraint)((object)DynamicConstraintInstantiation<TConstraint, TParam>.constraintInstance.Instantiate(type, param));
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		protected override bool EvaluateType(Type type)
		{
			return typeof(TConstraint).IsAssignableFrom(type);
		}

		// Token: 0x0400009C RID: 156
		private static DynamicConstraintInstantiation<TConstraint, TParam> m_singleton;
	}
}
