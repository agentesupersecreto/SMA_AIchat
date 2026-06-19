using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.UserControllers
{
	// Token: 0x020001AF RID: 431
	public class UserController : AplicableBehaviour
	{
		// Token: 0x06000A56 RID: 2646 RVA: 0x00033A1A File Offset: 0x00031C1A
		protected void PrintInput(object value)
		{
			Debug.Log(base.name + " Input: " + ((value != null) ? value.ToString() : null), base.gameObject);
		}

		// Token: 0x040007CC RID: 1996
		public bool debugUserInputs;
	}
}
