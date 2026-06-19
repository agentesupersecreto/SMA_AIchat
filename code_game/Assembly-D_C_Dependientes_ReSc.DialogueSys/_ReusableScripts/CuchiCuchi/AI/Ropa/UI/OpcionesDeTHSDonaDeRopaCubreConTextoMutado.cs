using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Textos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI
{
	// Token: 0x02000006 RID: 6
	public abstract class OpcionesDeTHSDonaDeRopaCubreConTextoMutado : GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000262E File Offset: 0x0000082E
		public Personalidad personalidad
		{
			get
			{
				return this.m_Personalidad;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002636 File Offset: 0x00000836
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002669 File Offset: 0x00000869
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.puedeDesvestir = true;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000267C File Offset: 0x0000087C
		protected override bool PuedeDibujarIndex(int index)
		{
			return GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.None && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.pene && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.testiculos && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.hombros && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.canillas && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.pies && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.labiosVaginales && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.rostro && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.torzo && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.cuello && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.espalda && GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index] != RopaCubre.cabeza;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002771 File Offset: 0x00000971
		protected override string TextDeIndex(int index)
		{
			return OpcionesDeTHSDonaDeRopaCubreConTextoMutado.NombreLocalizadoNoMutadoDeRopaCubre(GenericOpcionesDeTHSDonaDeEnumerable<RopaCubre>.valores[index]);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002784 File Offset: 0x00000984
		public static string NombreLocalizadoNoMutadoDeRopaCubre(RopaCubre ropaCubre)
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = OpcionesDeTHSDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(ropaCubre);
			if (dialogoInfoParteDelCuerpo == null)
			{
				return ropaCubre.ToString();
			}
			return dialogoInfoParteDelCuerpo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, 2);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000027C0 File Offset: 0x000009C0
		public static string NombreLocalizadoMutadoDeRopaCubre(RestriccionDeEdad restriccion, Sexo sexRestriction, RopaCubre ropaCubre)
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = OpcionesDeTHSDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(ropaCubre);
			if (dialogoInfoParteDelCuerpo == null)
			{
				return ropaCubre.ToString();
			}
			return dialogoInfoParteDelCuerpo.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccion, sexRestriction, 2);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002808 File Offset: 0x00000A08
		public static DialogoInfoParteDelCuerpo DialogoDeRopaCubre(RopaCubre ropaCubre)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = ropaCubre.ParceToParteDelCuerpoHumano();
			return Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parteDelCuerpoHumano);
		}

		// Token: 0x0400000C RID: 12
		private Personalidad m_Personalidad;

		// Token: 0x0400000D RID: 13
		public bool puedeDesvestir = true;
	}
}
