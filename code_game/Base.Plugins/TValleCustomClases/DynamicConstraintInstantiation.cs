using System;

namespace TValleCustomClases
{
	// Token: 0x0200005D RID: 93
	public class DynamicConstraintInstantiation<TConstraint> : DynamicInstantiation where TConstraint : class
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000DB5E File Offset: 0x0000BD5E
		public static DynamicConstraintInstantiation<TConstraint> constraintInstance
		{
			get
			{
				if (DynamicConstraintInstantiation<TConstraint>.m_singleton == null)
				{
					DynamicConstraintInstantiation<TConstraint>.m_singleton = new DynamicConstraintInstantiation<TConstraint>();
				}
				return DynamicConstraintInstantiation<TConstraint>.m_singleton;
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000DB76 File Offset: 0x0000BD76
		public static T InstantiateConstraintType<T>(Type type) where T : TConstraint
		{
			return (T)((object)DynamicConstraintInstantiation<TConstraint>.constraintInstance.Instantiate(type));
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000DB88 File Offset: 0x0000BD88
		public static TConstraint InstantiateConstraintType(Type type)
		{
			return (TConstraint)((object)DynamicConstraintInstantiation<TConstraint>.constraintInstance.Instantiate(type));
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000DB9A File Offset: 0x0000BD9A
		protected override bool EvaluateType(Type type)
		{
			return typeof(TConstraint).IsAssignableFrom(type);
		}

		// Token: 0x04000099 RID: 153
		private static DynamicConstraintInstantiation<TConstraint> m_singleton;
	}
}
