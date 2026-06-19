using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers.Memoria;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Handlers.Memoria
{
	// Token: 0x0200006C RID: 108
	[MemoriaRelatedBehaviour]
	public class MemoriaDePiscinaDeSujetosDePersonalidadFemenina : CustomMonobehaviour, ISujetosMemoriaDePiscina<ISujetoIdentificable>
	{
		// Token: 0x060004E9 RID: 1257 RVA: 0x00011C1C File Offset: 0x0000FE1C
		public static IList<ISujetoIdentificable> LeerPersonalidades(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			IList<ISujetoIdentificable> list2;
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/Personalidad/", PiscinaID, MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp);
				List<ISujetoIdentificable> list = new List<ISujetoIdentificable>(MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp.Count);
				foreach (string text in MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp)
				{
					ISujetoIdentificable sujetoIdentificable = MemoriaDeSujetosDePersonalidadFemenina.LeerSujetoDesdeMemoria(GlobalSingletonV2<MemoriaJson>.instance, text);
					if (sujetoIdentificable != null)
					{
						list.Add(sujetoIdentificable);
					}
				}
				list2 = list;
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp.Clear();
			}
			return list2;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00011CCC File Offset: 0x0000FECC
		public static void EscribirPersonalidades(string PiscinaID, IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			foreach (ISujetoIdentificable sujetoIdentificable in sujetos)
			{
				MemoriaDeSujetosDePersonalidadFemenina.EscribirSujetoAMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujetoIdentificable);
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.SetSujetoReferenceToPool(PiscinaID, sujetoIdentificable.sujetoID.ToString());
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00011D40 File Offset: 0x0000FF40
		public static void BorrarPersonalidades(string PiscinaID, bool forzar)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/Personalidad/", PiscinaID, MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDePersonalidadFemenina.RemoveSujetoReferenceToPool(PiscinaID, text);
					MemoriaDeSujetosDePersonalidadFemenina.BorrarPersonalidadMapa(GlobalSingletonV2<MemoriaJson>.instance, text, forzar);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00011DD4 File Offset: 0x0000FFD4
		public static void SetSujetosReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/Personalidad/", PiscinaID, MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDePersonalidadFemenina.SetSujetoReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00011E5C File Offset: 0x0001005C
		public static void SetSujetoReferenceToPool(string PiscinaID, string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosDePersonalidadFemenina.SetSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool", PiscinaID);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00011E7C File Offset: 0x0001007C
		public static void RemoveSujetosReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/Personalidad/", PiscinaID, MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp)
				{
					MemoriaDePiscinaDeSujetosDePersonalidadFemenina.RemoveSujetoReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.m_temp.Clear();
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00011F04 File Offset: 0x00010104
		public static void RemoveSujetoReferenceToPool(string PiscinaID, string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string sujetoReferencia = MemoriaDeSujetosDePersonalidadFemenina.GetSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool");
			if (sujetoReferencia == null)
			{
				return;
			}
			if (PiscinaID == sujetoReferencia)
			{
				MemoriaDeSujetosDePersonalidadFemenina.DeleteSujetoReferencia(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, "InPool");
				return;
			}
			Debug.LogError("No se pudo borrar sujeto: " + sujetoID + " de piscina: " + PiscinaID);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00011F63 File Offset: 0x00010163
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

		// Token: 0x060004F1 RID: 1265 RVA: 0x00011F97 File Offset: 0x00010197
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00011F9F File Offset: 0x0001019F
		public List<ISujetoIdentificable> LeerSujetosEnMemoria()
		{
			return MemoriaDePiscinaDeSujetosDePersonalidadFemenina.LeerPersonalidades(this.m_piscina.ID) as List<ISujetoIdentificable>;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00011FB8 File Offset: 0x000101B8
		public bool EscribirSujetosEnMemoria(IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			bool flag;
			try
			{
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.EscribirPersonalidades(this.m_piscina.ID, sujetos);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00011FF8 File Offset: 0x000101F8
		public void LeerSujetosIDsEnMemoria(List<string> resultadoSujetosIDs)
		{
			MemoriaDePiscinaDeSujetosUtil.LeerIDs("root/Piscinas/Personalidad/", this.m_piscina.ID, resultadoSujetosIDs);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00012010 File Offset: 0x00010210
		public bool EscribirSujetosIDsEnMemoria(IReadOnlyList<ISujetoIdentificable> sujetos)
		{
			bool flag;
			try
			{
				MemoriaDePiscinaDeSujetosUtil.EscribirIDs<ISujetoIdentificable>("root/Piscinas/Personalidad/", this.m_piscina.ID, sujetos);
				MemoriaDePiscinaDeSujetosDePersonalidadFemenina.SetSujetosReferenceToPool(this.m_piscina.ID);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00012064 File Offset: 0x00010264
		public void BorrarSujetosEnMemoria()
		{
			MemoriaDePiscinaDeSujetosDePersonalidadFemenina.BorrarPersonalidades(this.m_piscina.ID, false);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00012077 File Offset: 0x00010277
		public void BorrarSujetosIDsEnMemoria()
		{
			MemoriaDePiscinaDeSujetosDePersonalidadFemenina.RemoveSujetosReferenceToPool(this.m_piscina.ID);
			MemoriaDePiscinaDeSujetosUtil.BorrarIDs("root/Piscinas/Personalidad/", this.m_piscina.ID);
		}

		// Token: 0x04000231 RID: 561
		public const string rutaDeIDs = "root/Piscinas/Personalidad/";

		// Token: 0x04000232 RID: 562
		public const string sujetoReferencedDataName = "InPool";

		// Token: 0x04000233 RID: 563
		private static List<string> m_temp = new List<string>();

		// Token: 0x04000234 RID: 564
		private IPiscinaManagerDeSujetos<ISujetoIdentificable> m_piscina;
	}
}
