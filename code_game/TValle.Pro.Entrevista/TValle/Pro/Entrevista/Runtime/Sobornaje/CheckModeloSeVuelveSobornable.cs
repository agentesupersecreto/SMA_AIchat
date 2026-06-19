using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje
{
	// Token: 0x02000077 RID: 119
	[Obsolete("el jugador ahora intenta pagarle a la modelo, pero es solo una artima;a para ver si se deja comprar", true)]
	public class CheckModeloSeVuelveSobornable : CustomMonobehaviour
	{
		// Token: 0x06000501 RID: 1281 RVA: 0x0001CE20 File Offset: 0x0001B020
		protected override void AwakeUnityEvent()
		{
			this.m_forzar = false;
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001CE35 File Offset: 0x0001B035
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_modelo = this.GetComponentEnRoot(false);
			if (this.m_modelo == null)
			{
				throw new ArgumentNullException("m_modelo", "m_modelo null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_Deseos = this.GetComponentEnRoot(false);
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
			this.m_memPermanente = this.GetComponentEnRoot(false);
			if (this.m_memPermanente == null)
			{
				throw new ArgumentNullException("m_memPermanente", "m_memPermanente null reference.");
			}
			this.m_memTemp = this.GetComponentEnRoot(false);
			if (this.m_memTemp == null)
			{
				throw new ArgumentNullException("m_memTemp", "m_memTemp null reference.");
			}
			while (!this.m_modelo.loaded)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001CE44 File Offset: 0x0001B044
		private IEnumerator CheckSobornableRutine()
		{
			yield return null;
			yield break;
		}

		// Token: 0x040002FC RID: 764
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040002FD RID: 765
		private Character m_modelo;

		// Token: 0x040002FE RID: 766
		private CoroutineCapsule m_Coroutine;

		// Token: 0x040002FF RID: 767
		private Personalidad m_Personalidad;

		// Token: 0x04000300 RID: 768
		private Deseos m_Deseos;

		// Token: 0x04000301 RID: 769
		private MemoriaDeCharacterGeneralPermanente m_memPermanente;

		// Token: 0x04000302 RID: 770
		private MemoriaDeCharacterGeneralTemporal m_memTemp;

		// Token: 0x04000303 RID: 771
		[SerializeField]
		[Range(0f, 1f)]
		private float m_minDeseo = 0.2f;

		// Token: 0x04000304 RID: 772
		[SerializeField]
		[Range(0f, 1f)]
		private float m_maxDeseo = 1f;

		// Token: 0x04000305 RID: 773
		[SerializeField]
		private bool m_forzar;
	}
}
