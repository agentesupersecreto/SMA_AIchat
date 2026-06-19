using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers.Memoria;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Handlers.Memoria
{
	// Token: 0x0200006B RID: 107
	[MemoriaRelatedBehaviour]
	public class MemoriaDePiscinaDeSujetosDeAparienciaFemenina : CustomMonobehaviour, ISujetosMemoriaDePiscina<ISujetoIdentificable>
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x00011784 File Offset: 0x0000F984
		public static IList<ISujetoIdentificable> LeerApariencias(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			IList<ISujetoIdentificable> list2;
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/AparienciaFisica/", PiscinaID, MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp);
				List<ISujetoIdentificable> list = new List<ISujetoIdentificable>(MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp.Count);
				foreach (string text in MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp)
				{
					ISujetoIdentificable sujetoIdentificable = MemoriaDeSujetosDeAparienciaFemenina.LeerSujetoDesdeMemoria(GlobalSingletonV2<MemoriaJson>.instance, text);
					if (sujetoIdentificable != null)
					{
						list.Add(sujetoIdentificable);
					}
				}
				list2 = list;
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp.Clear();
			}
			return list2;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00011834 File Offset: 0x0000FA34
		public static void EscribirApariencias(string PiscinaID, IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			foreach (ISujetoIdentificable sujetoIdentificable in sujetos)
			{
				MemoriaDeSujetosDeAparienciaFemenina.EscribirSujetoAMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujetoIdentificable);
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.SetSujetoReferenceToPool(PiscinaID, sujetoIdentificable.sujetoID.ToString());
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000118A8 File Offset: 0x0000FAA8
		public static void BorrarApariencias(string PiscinaID, bool forzar)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/AparienciaFisica/", PiscinaID, MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDeAparienciaFemenina.RemoveSujetoReferenceToPool(PiscinaID, text);
					MemoriaDeSujetosDeAparienciaFemenina.BorrarNodeEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, text, forzar);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001193C File Offset: 0x0000FB3C
		public static void SetSujetosReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/AparienciaFisica/", PiscinaID, MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDeAparienciaFemenina.SetSujetoReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000119C4 File Offset: 0x0000FBC4
		public static void SetSujetoReferenceToPool(string PiscinaID, string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosDeAparienciaFemenina.SetSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool", PiscinaID);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000119E4 File Offset: 0x0000FBE4
		public static void RemoveSujetosReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/AparienciaFisica/", PiscinaID, MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDeAparienciaFemenina.RemoveSujetoReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00011A6C File Offset: 0x0000FC6C
		public static void RemoveSujetoReferenceToPool(string PiscinaID, string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string sujetoReferencia = MemoriaDeSujetosDeAparienciaFemenina.GetSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool");
			if (sujetoReferencia == null)
			{
				return;
			}
			if (PiscinaID == sujetoReferencia)
			{
				MemoriaDeSujetosDeAparienciaFemenina.DeleteSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool");
				return;
			}
			Debug.LogError("No se pudo borrar sujeto: " + sujetoID + " de piscina: " + PiscinaID);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00011ACB File Offset: 0x0000FCCB
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_piscina = base.GetComponentInParent<IPiscinaManagerDeSujetos<ISujetoIdentificable>>();
			if (this.m_piscina == null)
			{
				throw new ArgumentNullException("m_piscina", "m_piscina null reference.");
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00011AFF File Offset: 0x0000FCFF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00011B07 File Offset: 0x0000FD07
		public List<ISujetoIdentificable> LeerSujetosEnMemoria()
		{
			return MemoriaDePiscinaDeSujetosDeAparienciaFemenina.LeerApariencias(this.m_piscina.ID) as List<ISujetoIdentificable>;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00011B20 File Offset: 0x0000FD20
		public bool EscribirSujetosEnMemoria(IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			bool flag;
			try
			{
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.EscribirApariencias(this.m_piscina.ID, sujetos);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00011B60 File Offset: 0x0000FD60
		public void LeerSujetosIDsEnMemoria(List<string> resultadoSujetosIDs)
		{
			MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/AparienciaFisica/", this.m_piscina.ID, resultadoSujetosIDs);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00011B78 File Offset: 0x0000FD78
		public bool EscribirSujetosIDsEnMemoria(IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			bool flag;
			try
			{
				MemoriaDePiscinaDeSujetosUtil.EscribirIDs<ISujetoIdentificable>("root/Piscinas/AparienciaFisica/", this.m_piscina.ID, sujetos);
				MemoriaDePiscinaDeSujetosDeAparienciaFemenina.SetSujetosReferenceToPool(this.m_piscina.ID);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00011BCC File Offset: 0x0000FDCC
		public void BorrarSujetosEnMemoria()
		{
			MemoriaDePiscinaDeSujetosDeAparienciaFemenina.BorrarApariencias(this.m_piscina.ID, false);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00011BDF File Offset: 0x0000FDDF
		public void BorrarSujetosIDsEnMemoria()
		{
			MemoriaDePiscinaDeSujetosDeAparienciaFemenina.RemoveSujetosReferenceToPool(this.m_piscina.ID);
			MemoriaDePiscinaDeSujetosUtil.BorrarIDs("root/Piscinas/AparienciaFisica/", this.m_piscina.ID);
		}

		// Token: 0x0400022D RID: 557
		public const string rutaDeIDs = "root/Piscinas/AparienciaFisica/";

		// Token: 0x0400022E RID: 558
		public const string sujetoReferencedDataName = "InPool";

		// Token: 0x0400022F RID: 559
		private static List<string> m_temp = new List<string>();

		// Token: 0x04000230 RID: 560
		private IPiscinaManagerDeSujetos<ISujetoIdentificable> m_piscina;
	}
}
