using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands.AI
{
	// Token: 0x0200027A RID: 634
	public class HandJobTouchInyector : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060010B3 RID: 4275 RVA: 0x00038B4B File Offset: 0x00036D4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI0);
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x0004E937 File Offset: 0x0004CB37
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI1);
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060010B5 RID: 4277 RVA: 0x000066D6 File Offset: 0x000048D6
		public override int updateEvent2ExtraCalls
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0004E940 File Offset: 0x0004CB40
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.controller = this.GetComponentEnRoot(false);
			if (this.controller == null)
			{
				throw new ArgumentNullException("controller", "controller null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0004E9A3 File Offset: 0x0004CBA3
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.controller.onJobHandlerUpdate += this.Controller_onJobHandlerUpdate;
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x0004E9C2 File Offset: 0x0004CBC2
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.controller != null)
			{
				this.controller.onJobHandlerUpdate -= this.Controller_onJobHandlerUpdate;
			}
			this.RetornarTodoAPool();
			this.m_pedidos.Clear();
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0004EA04 File Offset: 0x0004CC04
		private void Controller_onJobHandlerUpdate(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, Penetrador toPenetrator)
		{
			if (comenzando || terminando || terminada)
			{
				return;
			}
			this.m_pedidos.Add(new HandJobTouchInyector.Pedido
			{
				velocidadPhyscis = velocidadPhyscis,
				recorridoPosition = recorridoPosition,
				recoridoRotation = recoridoRotation,
				por = por,
				porHand = porHand,
				to = to,
				toPenetrator = toPenetrator
			});
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0004EA6C File Offset: 0x0004CC6C
		public override void OnUpdateEvent1()
		{
			this.RetornarTodoAPool();
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0004EA74 File Offset: 0x0004CC74
		private void RetornarTodoAPool()
		{
			for (int i = 0; i < this.m_usados.Count; i++)
			{
				this.m_poolDeEstimulos.ReturnItem(this.m_usados[i]);
			}
			this.m_usados.Clear();
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0004EABC File Offset: 0x0004CCBC
		public override void OnUpdateEvent2()
		{
			if (GlobalUpdater.CurrentUserCallCount(base.updaterUser) != 2)
			{
				return;
			}
			for (int i = this.m_pedidos.Count - 1; i >= 0; i--)
			{
				HandJobTouchInyector.Pedido pedido = this.m_pedidos[i];
				PenisPart penisPart = pedido.toPenetrator.partesEnOrden[pedido.toPenetrator.partesEnOrden.Count - 1];
				TocanteObjeto component = penisPart.GetComponent<TocanteObjeto>();
				TocanteObjeto component2 = pedido.porHand.GetComponent<TocanteObjeto>();
				HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats item = this.m_poolDeEstimulos.GetItem();
				HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats item2 = this.m_poolDeEstimulos.GetItem();
				item2.DefinirReferencias(component, this.m_PrioridadesDeObjetoEstimulado, component2, pedido.porHand.boneTarget, null);
				item2.DefinirTransformsYVectores(penisPart.physicBone.transform, new Vector3?(pedido.recoridoRotation * Vector3.forward), new Vector3?(pedido.recorridoPosition), null);
				item.DefinirReferencias(component2, this.m_PrioridadesDeObjetoEstimulado, component, penisPart.physicBone.transform, null);
				item.DefinirTransformsYVectores(pedido.porHand.boneTarget, new Vector3?(pedido.recoridoRotation * Vector3.forward), new Vector3?(pedido.recorridoPosition), null);
				item.side = (item2.side = Side.none);
				item2.AddParteEstimulada(ParteDelCuerpoHumano.pene);
				item.AddParteEstimulada(ParteDelCuerpoHumano.manos);
				item.tipoDeEstimulo = (item2.tipoDeEstimulo = TipoDeEstimulo.tactil);
				item2.tipo = DireccionDeEstimulo.dada;
				item.tipo = DireccionDeEstimulo.recibida;
				item2.SetTipoDeEstimuloTactil(TipoDeEstimuloTactil.caricia);
				item.SetTipoDeEstimuloTactil(TipoDeEstimuloTactil.caricia);
				item2.SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido.handjob);
				item.SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido.None);
				item.velocidadRelativaEmuladaMaxima = (item2.velocidadRelativaEmuladaMaxima = pedido.velocidadPhyscis.magnitude);
				item.velocidadRelativaEmuladaTotal = (item2.velocidadRelativaEmuladaTotal = item2.velocidadRelativaEmuladaMaxima);
				item.velocidadEstimuladoEmulada = (item2.velocidadEstimuladoEmulada = pedido.velocidadPhyscis);
				item.velocidadEstimulanteEmulada = (item2.velocidadEstimulanteEmulada = pedido.velocidadPhyscis);
				item.velocidadRelativaEmulada = (item2.velocidadRelativaEmulada = pedido.velocidadPhyscis);
				item.velocidadRelativaPhysics = (item2.velocidadRelativaPhysics = pedido.velocidadPhyscis);
				item.velocidadRelativaPhysicsMagnitud = (item2.velocidadRelativaPhysicsMagnitud = pedido.velocidadPhyscis.magnitude);
				item.impulsoPhysics = (item2.impulsoPhysics = pedido.velocidadPhyscis);
				item.esDePhysicsEngine = (item2.esDePhysicsEngine = false);
				item.cantidadDeContanctos = (item2.cantidadDeContanctos = 1);
				pedido.porHand.touchedByCharacteres.TryInyectar<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>(pedido.to, component2, item2);
				pedido.porHand.touchedByCharacteres.TryInyectar<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>(pedido.to, component, item);
				((IInteracionEstimulanteInversible)item2).SetAsInvertedCopy(item);
				this.m_usados.Add(item2);
				this.m_usados.Add(item);
				this.m_pedidos.RemoveAt(i);
			}
		}

		// Token: 0x04000C2F RID: 3119
		private HandJobController controller;

		// Token: 0x04000C30 RID: 3120
		[SerializeField]
		private List<HandJobTouchInyector.Pedido> m_pedidos = new List<HandJobTouchInyector.Pedido>();

		// Token: 0x04000C31 RID: 3121
		[SerializeField]
		private List<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats> m_usados = new List<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>();

		// Token: 0x04000C32 RID: 3122
		private PoolDeInteraccionEstimulante<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats> m_poolDeEstimulos = new PoolDeInteraccionEstimulante<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>();

		// Token: 0x04000C33 RID: 3123
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x0200027B RID: 635
		[Serializable]
		public struct Pedido
		{
			// Token: 0x04000C34 RID: 3124
			public Vector3 velocidadPhyscis;

			// Token: 0x04000C35 RID: 3125
			public Vector3 recorridoPosition;

			// Token: 0x04000C36 RID: 3126
			public Quaternion recoridoRotation;

			// Token: 0x04000C37 RID: 3127
			public ICharacter por;

			// Token: 0x04000C38 RID: 3128
			public HitSkin porHand;

			// Token: 0x04000C39 RID: 3129
			public ICharacter to;

			// Token: 0x04000C3A RID: 3130
			public Penetrador toPenetrator;
		}
	}
}
