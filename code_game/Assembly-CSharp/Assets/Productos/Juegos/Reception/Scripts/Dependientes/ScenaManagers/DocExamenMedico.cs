using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BA RID: 186
	public class DocExamenMedico : ConDoctoraScenaManager
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x00014EB7 File Offset: 0x000130B7
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00014EBE File Offset: 0x000130BE
		protected override void OnDocStared(FemaleChar doc)
		{
		}
	}
}
