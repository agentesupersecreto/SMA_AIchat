using System;
using UnityEngine;

namespace InterfaceFields
{
	// Token: 0x020000A0 RID: 160
	public class ConstraintTypeAttribute : PropertyAttribute
	{
		// Token: 0x060004E9 RID: 1257 RVA: 0x00016112 File Offset: 0x00014312
		public ConstraintTypeAttribute(Type Constraint)
		{
			this.constraint = Constraint;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00016121 File Offset: 0x00014321
		public ConstraintTypeAttribute(Type Constraint, bool Required)
		{
			this.constraint = Constraint;
			this.required = Required;
		}

		// Token: 0x0400014E RID: 334
		public Type constraint;

		// Token: 0x0400014F RID: 335
		public bool required;
	}
}
