using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D3 RID: 211
	public abstract class DatosDeInteraccionDynamicaGenerica : DatosDeInteraccionDynamica
	{
		// Token: 0x060007A4 RID: 1956 RVA: 0x00025000 File Offset: 0x00023200
		protected override void OnAdded(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			base.transform.parent = arg2.GetRootDeLayer(arg1.interactionLayer);
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00025054 File Offset: 0x00023254
		protected override void OnRemoved(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
