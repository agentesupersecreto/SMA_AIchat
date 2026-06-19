using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Testing
{
	// Token: 0x020000F3 RID: 243
	[RequireComponent(typeof(Interaccion))]
	public sealed class InteraccionInterfaceActivadorTESTING : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000920 RID: 2336 RVA: 0x000297D0 File Offset: 0x000279D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interaccion = base.GetComponent<Interaccion>();
			if (this.m_interaccion == null)
			{
				throw new ArgumentNullException("m_interaccion", "m_interaccion null reference.");
			}
			this.detenerLabel = "Detener Interaccion " + this.m_interaccion.name;
			this.ejecutarLabel = string.Concat(new string[]
			{
				"Ejecutar Interaccion ",
				this.m_interaccion.name,
				" por ",
				this.time.ToString(),
				" segundos"
			});
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00029870 File Offset: 0x00027A70
		private void OnGUI()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			GUILayout.Space(this.space);
			if (this.m_interaccion.algunaEstaEjecutandose)
			{
				if (GUILayout.Button(this.detenerLabel, Array.Empty<GUILayoutOption>()))
				{
					this.m_interaccion.Detener(false);
					return;
				}
			}
			else if (GUILayout.Button(this.ejecutarLabel, Array.Empty<GUILayoutOption>()))
			{
				this.m_interaccion.Ejecutar(int.MaxValue, this.time, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
			}
		}

		// Token: 0x040005B4 RID: 1460
		public float time = -1f;

		// Token: 0x040005B5 RID: 1461
		public float space = 30f;

		// Token: 0x040005B6 RID: 1462
		private Interaccion m_interaccion;

		// Token: 0x040005B7 RID: 1463
		private string detenerLabel;

		// Token: 0x040005B8 RID: 1464
		private string ejecutarLabel;
	}
}
