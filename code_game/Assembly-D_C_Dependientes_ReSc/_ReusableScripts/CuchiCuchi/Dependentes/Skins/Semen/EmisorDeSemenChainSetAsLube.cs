using System;
using Assets.Base.Tiempo.Runtime;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen
{
	// Token: 0x02000046 RID: 70
	[RequireComponent(typeof(EmisorDeSemenChain))]
	public class EmisorDeSemenChainSetAsLube : CustomMonobehaviour
	{
		// Token: 0x0600019E RID: 414 RVA: 0x0000BB16 File Offset: 0x00009D16
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emisor = base.GetComponent<EmisorDeSemenChain>();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000BB2A File Offset: 0x00009D2A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_emisor.onChainCreated += this.M_emisor_onChainCreated;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000BB49 File Offset: 0x00009D49
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_emisor != null)
			{
				this.m_emisor.onChainCreated -= this.M_emisor_onChainCreated;
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000BB78 File Offset: 0x00009D78
		private void M_emisor_onChainCreated(SemenChain arg1, EmisorDeSemenChain arg2)
		{
			for (int i = 0; i < arg1.semenPuntos.Count; i++)
			{
				SemenPunto semenPunto = arg1.semenPuntos[i];
				SonidoProductor sonidoProductor = semenPunto.gameObject.AddComponent<SonidoProductor>();
				semenPunto.gameObject.AddComponent<DestroyGameObjectAfterTiempoDeJuego>().duration = 3600f;
				sonidoProductor.textura = TexturaDeObjetoSonoro.liquido;
				sonidoProductor.forma = FormaDeObjetoSonoro.circular;
				semenPunto.gameObject.AddComponent<SemenPuntoCollisionContraSkin>().bindProc = 1f;
				semenPunto.reduceScaleByLifeTime = true;
				semenPunto.SetTipo(TipoDeSemen.lubricante);
			}
		}

		// Token: 0x04000186 RID: 390
		private EmisorDeSemenChain m_emisor;
	}
}
