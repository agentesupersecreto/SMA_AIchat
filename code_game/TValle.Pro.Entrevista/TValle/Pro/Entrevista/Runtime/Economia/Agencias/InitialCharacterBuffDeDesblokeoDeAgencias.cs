using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Mapas.Buff;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias
{
	// Token: 0x020000CB RID: 203
	public class InitialCharacterBuffDeDesblokeoDeAgencias : CustomMonobehaviour
	{
		// Token: 0x060007A0 RID: 1952 RVA: 0x0002BF6C File Offset: 0x0002A16C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_BuffDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_BuffDeCharacter == null)
			{
				throw new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference.");
			}
			this.m_BuffDeCharacter.stared += this.M_BuffDeCharacter_stared;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0002BFC4 File Offset: 0x0002A1C4
		private void M_BuffDeCharacter_stared(object sender)
		{
			HashSet<string> hashSet = new HashSet<string>();
			for (int i = 0; i < this.m_buffIds.Count; i++)
			{
				string text = this.m_buffIds[i];
				BuffMap map = Singleton<BuffManager>.instance.GetMap(text);
				if (!(map == null))
				{
					if (!hashSet.Add(text))
					{
						Debug.LogError("Ya hay un buff con id: " + text + " en este collecion", this);
					}
					if (!map.esVolatil)
					{
						Debug.LogError("No es recomendable añadir buff no volatiles de esta manera (cada vez q se inicie el juego con un save se van a stack up)", this);
					}
					AgenciasBuffMap agenciasBuffMap = map as AgenciasBuffMap;
					if (agenciasBuffMap == null)
					{
						Debug.LogError("buff: " + text + " no es un buff para agencias", this);
					}
					else
					{
						BuffEvento eventoBuffParaAgencias = agenciasBuffMap.GetEventoBuffParaAgencias<DesblokeoDeAgenciasArg>(Singleton<TiempoDeJuego>.instance.tiempoActual, string.Empty, new DesblokeoDeAgenciasArg());
						this.m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuffParaAgencias, false, true);
					}
				}
			}
			this.m_BuffDeCharacter.eventos.Sort();
		}

		// Token: 0x0400045B RID: 1115
		[SerializeField]
		[StringSelectorV2(typeof(ProveedorBuffIdsAttribute))]
		private List<string> m_buffIds = new List<string>();

		// Token: 0x0400045C RID: 1116
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
