using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.UI;
using Assets._ReusableScripts.Textos;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI
{
	// Token: 0x02000388 RID: 904
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDeRopaCubreConTextoMutado : OpcionesDeDonaDeRopaCubre
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x00055DD7 File Offset: 0x00053FD7
		public Personalidad personalidad
		{
			get
			{
				return this.m_Personalidad;
			}
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x00055DDF File Offset: 0x00053FDF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00055E12 File Offset: 0x00054012
		public override string TextDeIndex(int index)
		{
			return OpcionesDeDonaDeRopaCubreConTextoMutado.NombreLocalizadoNoMutadoDeRopaCubre(GenericOpcionesDeDonaDeEnumerable<RopaCubre, OpcionesDeDonaDeRopaCubre.CurrentClicked>.valores[index]);
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x00055E24 File Offset: 0x00054024
		public static string NombreLocalizadoNoMutadoDeRopaCubre(RopaCubre ropaCubre)
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = OpcionesDeDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(ropaCubre);
			if (dialogoInfoParteDelCuerpo == null)
			{
				return ropaCubre.ToString();
			}
			return dialogoInfoParteDelCuerpo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, 2);
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x00055E60 File Offset: 0x00054060
		public static string NombreLocalizadoMutadoDeRopaCubre(RestriccionDeEdad restriccion, RopaCubre ropaCubre)
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = OpcionesDeDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(ropaCubre);
			if (dialogoInfoParteDelCuerpo == null)
			{
				return ropaCubre.ToString();
			}
			return dialogoInfoParteDelCuerpo.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccion, Sexo.noDefinido, 2);
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x00055EA8 File Offset: 0x000540A8
		public static DialogoInfoParteDelCuerpo DialogoDeRopaCubre(RopaCubre ropaCubre)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = ropaCubre.ParceToParteDelCuerpoHumano();
			return Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parteDelCuerpoHumano);
		}

		// Token: 0x0400106F RID: 4207
		private Personalidad m_Personalidad;
	}
}
