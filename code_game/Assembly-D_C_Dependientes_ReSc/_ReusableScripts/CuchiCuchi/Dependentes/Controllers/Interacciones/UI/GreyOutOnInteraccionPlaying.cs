using System;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI
{
	// Token: 0x020001B5 RID: 437
	public class GreyOutOnInteraccionPlaying : CustomUpdatedMonobehaviourBase, ICheckerIsGreyOut
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00034380 File Offset: 0x00032580
		bool ICheckerIsGreyOut.isGreyOut
		{
			get
			{
				if (this.m_interacciones == null)
				{
					return false;
				}
				for (int i = 0; i < this.m_interacciones.interaccionesPrimariasBases.Count; i++)
				{
					InteraccionDeCharacter interaccionDeCharacter = this.m_interacciones.interaccionesPrimariasBases[i];
					Interaccion interaccion = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null);
					if (interaccion != null && interaccion.algunaEstaEjecutandose)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000343E4 File Offset: 0x000325E4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
		}

		// Token: 0x040007ED RID: 2029
		private IInteraccionesDeCharacter m_interacciones;
	}
}
